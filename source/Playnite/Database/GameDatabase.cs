namespace Playnite.Database
{
    public partial class GameDatabase : IGameDatabaseMain, IDisposable
    {

        #region Files

        #endregion Files
        private Game GameInfoToGame(GameMetadata game, Guid pluginId)
        {
            var toAdd = new Game()
            {
                PluginId = pluginId,
                Name = game.Name,
                GameId = game.GameId,
                Description = game.Description,
                InstallDirectory = game.InstallDirectory,
                SortingName = game.SortingName,
                GameActions = game.GameActions == null ? null : new ObservableCollection<GameAction>(game.GameActions),
                ReleaseDate = game.ReleaseDate,
                Links = game.Links == null ? null : new ObservableCollection<Link>(game.Links),
                Roms = game.Roms == null ? null : new ObservableCollection<GameRom>(game.Roms),
                IsInstalled = game.IsInstalled,
                Playtime = game.Playtime,
                PlayCount = game.PlayCount,
                LastActivity = game.LastActivity,
                Version = game.Version,
                UserScore = game.UserScore,
                CriticScore = game.CriticScore,
                CommunityScore = game.CommunityScore,
                Hidden = game.Hidden,
                Favorite = game.Favorite,
                InstallSize = game.InstallSize
            };

            if (game.Platforms?.Any() == true)
            {
                toAdd.PlatformIds = Platforms.Add(game.Platforms).Select(a => a.Id).ToList();
            }

            if (game.Regions?.Any() == true)
            {
                toAdd.RegionIds = Regions.Add(game.Regions).Select(a => a.Id).ToList();
            }

            if (game.Developers?.Any() == true)
            {
                toAdd.DeveloperIds = Companies.Add(game.Developers).Select(a => a.Id).ToList();
            }

            if (game.Publishers?.Any() == true)
            {
                toAdd.PublisherIds = Companies.Add(game.Publishers).Select(a => a.Id).ToList();
            }

            if (game.Genres?.Any() == true)
            {
                toAdd.GenreIds = Genres.Add(game.Genres).Select(a => a.Id).ToList();
            }

            if (game.Categories?.Any() == true)
            {
                toAdd.CategoryIds = Categories.Add(game.Categories).Select(a => a.Id).ToList();
            }

            if (game.Tags?.Any() == true)
            {
                toAdd.TagIds = Tags.Add(game.Tags).Select(a => a.Id).ToList();
            }

            if (game.Features?.Any() == true)
            {
                toAdd.FeatureIds = Features.Add(game.Features).Select(a => a.Id).ToList();
            }

            if (game.AgeRatings?.Any() == true)
            {
                toAdd.AgeRatingIds = AgeRatings.Add(game.AgeRatings).Select(a => a.Id).ToList();
            }

            if (game.Series?.Any() == true)
            {
                toAdd.SeriesIds = Series.Add(game.Series).Select(a => a.Id).ToList();
            }

            if (game.Source != null)
            {
                toAdd.SourceId = Sources.Add(game.Source).Id;
            }

            if (game.CompletionStatus != null)
            {
                toAdd.CompletionStatusId = CompletionStatuses.Add(game.CompletionStatus).Id;
            }

            return toAdd;
        }

        public Game ImportGame(GameMetadata game)
        {
            return ImportGame(game, Guid.Empty);
        }

        public Game ImportGame(GameMetadata game, LibraryPlugin sourcePlugin)
        {
            return ImportGame(game, sourcePlugin.Id);
        }

        public Game ImportGame(GameMetadata game, Guid pluginId)
        {
            var toAdd = GameInfoToGame(game, pluginId);

            if (game.Icon != null)
            {
                toAdd.Icon = AddFile(game.Icon, toAdd.Id, true);
            }

            if (game.CoverImage != null)
            {
                toAdd.CoverImage = AddFile(game.CoverImage, toAdd.Id, true);
            }

            if (game.BackgroundImage != null)
            {
                toAdd.BackgroundImage = AddFile(game.BackgroundImage, toAdd.Id, true);
            }

            toAdd.IncludeLibraryPluginAction = true;
            Games.Add(toAdd);
            return toAdd;
        }

        public List<Game> ImportGames(LibraryPlugin library, CancellationToken cancelToken, PlaytimeImportMode playtimeImportMode)
        {
            using (BufferedUpdate())
            {
                var statusSettings = GetCompletionStatusSettings();
                bool updateCompletionStatus(Game game, CompletionStatusSettings settings)
                {
                    var updated = false;
                    if ((game.Playtime > 0 && (game.CompletionStatusId == Guid.Empty || game.CompletionStatusId == settings.DefaultStatus)) &&
                        game.CompletionStatusId != statusSettings.PlayedStatus)
                    {
                        game.CompletionStatusId = statusSettings.PlayedStatus;
                        updated = true;
                    }
                    else if ((game.Playtime == 0 && game.CompletionStatusId == Guid.Empty) &&
                        game.CompletionStatusId != statusSettings.DefaultStatus)
                    {
                        game.CompletionStatusId = statusSettings.DefaultStatus;
                        updated = true;
                    }

                    return updated;
                }

                if (library.Properties?.HasCustomizedGameImport == true)
                {
                    var importedGames = library.ImportGames(new LibraryImportGamesArgs { CancelToken = cancelToken })?.ToList() ?? new List<Game>();
                    foreach (var game in importedGames)
                    {
                        updateCompletionStatus(game, statusSettings);
                    }

                    return importedGames;
                }
                else
                {
                    var addedGames = new List<Game>();
                    foreach (var newGame in library.GetGames(new LibraryGetGamesArgs { CancelToken = cancelToken }) ?? new List<GameMetadata>())
                    {
                        if (ImportExclusions[ImportExclusionItem.GetId(newGame.GameId, library.Id)] != null)
                        {
                            logger.Debug($"Excluding {newGame.Name} {library.Name} from import.");
                            continue;
                        }

                        var existingGame = Games.FirstOrDefault(a => a.GameId == newGame.GameId && a.PluginId == library.Id);
                        if (existingGame == null)
                        {
                            logger.Info(string.Format("Adding new game {0} from {1} plugin", newGame.GameId, library.Name));
                            try
                            {
                                if (newGame.Playtime != 0)
                                {
                                    var originalPlaytime = newGame.Playtime;
                                    newGame.Playtime = 0;
                                    if (playtimeImportMode == PlaytimeImportMode.Always ||
                                        playtimeImportMode == PlaytimeImportMode.NewImportsOnly)
                                    {
                                        newGame.Playtime = originalPlaytime;
                                    }
                                }

                                var importedGame = ImportGame(newGame, library.Id);
                                addedGames.Add(importedGame);
                                if (updateCompletionStatus(importedGame, statusSettings))
                                {
                                    Games.Update(importedGame);
                                }
                            }
                            catch (Exception e) when (!PlayniteEnvironment.ThrowAllErrors)
                            {
                                logger.Error(e, "Failed to import game into database.");
                            }
                        }
                        else
                        {
                            var existingGameUpdated = false;
                            if (!existingGame.IsCustomGame && !existingGame.OverrideInstallState)
                            {
                                if (existingGame.IsInstalled != newGame.IsInstalled)
                                {
                                    existingGame.IsInstalled = newGame.IsInstalled;
                                    existingGameUpdated = true;
                                }

                                if (string.Equals(existingGame.InstallDirectory, newGame.InstallDirectory, StringComparison.OrdinalIgnoreCase) == false)
                                {
                                    existingGame.InstallDirectory = newGame.InstallDirectory;
                                    existingGameUpdated = true;
                                }
                            }

                            if (playtimeImportMode == PlaytimeImportMode.Always && newGame.Playtime > 0)
                            {
                                if (existingGame.Playtime != newGame.Playtime)
                                {
                                    existingGame.Playtime = newGame.Playtime;
                                    existingGameUpdated = true;
                                }

                                // The LastActivity value of the newGame is only applied if newer than
                                // the existing game, to prevent cases of DRM free games being launched without
                                // the client or offline, which would prevent the date from being updated in the service
                                if (newGame.LastActivity != null &&
                                    (existingGame.LastActivity == null || newGame.LastActivity > existingGame.LastActivity))
                                {
                                    existingGame.LastActivity = newGame.LastActivity;
                                    existingGameUpdated = true;
                                }

                                if (updateCompletionStatus(existingGame, statusSettings))
                                {
                                    existingGameUpdated = true;
                                }
                            }

                            if (!existingGame.IsInstalled && newGame.InstallSize != null && newGame.InstallSize > 0 &&
                                existingGame.InstallSize != newGame.InstallSize)
                            {
                                existingGame.InstallSize = newGame.InstallSize;
                                existingGameUpdated = true;
                            }

                            if (existingGameUpdated)
                            {
                                Games.Update(existingGame);
                            }
                        }
                    }

                    return addedGames;
                }
            }
        }

        public List<FilterPreset> GetSortedFilterPresets()
        {
            if (!IsOpen)
            {
                return new List<FilterPreset>();
            }

            var filterPresetsSettings = (FilterPresets as FilterPresetsCollection).GetSettings();
            var sortingOrder = filterPresetsSettings.SortingOrder;
            var savedSortedList = FilterPresets
                .Where(x => sortingOrder.Contains(x.Id))
                .OrderBy(x => sortingOrder.IndexOf(x.Id))
                .ToList();
            var unsavedSortedList = FilterPresets
                .Where(x => !sortingOrder.Contains(x.Id))
                .OrderBy(x => x.Name);

            savedSortedList.AddRange(unsavedSortedList);
            return savedSortedList;
        }
    }
}
