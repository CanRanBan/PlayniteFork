namespace Playnite;

public static partial class Loc
{

    /// <summary>
    /// English
    /// </summary>
    public static string language_name()
    {
        return GetString("language-name");
    }
    /// <summary>
    /// Playnite language
    /// </summary>
    public static string language_settings_label()
    {
        return GetString("language-settings-label");
    }
    /// <summary>
    /// Exit
    /// </summary>
    public static string exit_app_label()
    {
        return GetString("exit-app-label");
    }
    /// <summary>
    /// Filter Active
    /// </summary>
    public static string filter_active_label()
    {
        return GetString("filter-active-label");
    }
    /// <summary>
    /// Filter Disabled
    /// </summary>
    public static string filter_inactive_label()
    {
        return GetString("filter-inactive-label");
    }
    /// <summary>
    /// Additional filters
    /// </summary>
    public static string additional_filters()
    {
        return GetString("additional-filters");
    }
    /// <summary>
    /// Filters
    /// </summary>
    public static string filters()
    {
        return GetString("filters");
    }
    /// <summary>
    /// Filter
    /// </summary>
    public static string filter()
    {
        return GetString("filter");
    }
    /// <summary>
    /// Invalid Data
    /// </summary>
    public static string invalid_data_title()
    {
        return GetString("invalid-data-title");
    }
    /// <summary>
    /// Save Changes?
    /// </summary>
    public static string save_changes_ask_title()
    {
        return GetString("save-changes-ask-title");
    }
    /// <summary>
    /// Homepage at www.playnite.link
    /// </summary>
    public static string about_home_page_link()
    {
        return GetString("about-home-page-link");
    }
    /// <summary>
    /// Source Code at GitHub
    /// </summary>
    public static string about_source_link()
    {
        return GetString("about-source-link");
    }
    /// <summary>
    /// Create diag. package
    /// </summary>
    public static string about_create_diag_button()
    {
        return GetString("about-create-diag-button");
    }
    /// <summary>
    /// Send diag. information
    /// </summary>
    public static string about_send_diag_button()
    {
        return GetString("about-send-diag-button");
    }
    /// <summary>
    /// About Playnite
    /// </summary>
    public static string about_window_title()
    {
        return GetString("about-window-title");
    }
    /// <summary>
    /// Made by Josef Němec
    /// </summary>
    public static string about_author()
    {
        return GetString("about-author");
    }
    /// <summary>
    /// Assign Category
    /// </summary>
    public static string category_window_title()
    {
        return GetString("category-window-title");
    }
    /// <summary>
    /// Set Categories
    /// </summary>
    public static string category_set_button()
    {
        return GetString("category-set-button");
    }
    /// <summary>
    /// Add Category
    /// </summary>
    public static string category_add_cat_button()
    {
        return GetString("category-add-cat-button");
    }
    /// <summary>
    /// Checked - Assign category
    /// Unchecked - Remove category
    /// Indeterminate - No changes (when editing multiple games)
    /// </summary>
    public static string category_tooltip()
    {
        return GetString("category-tooltip");
    }
    /// <summary>
    /// No Category
    /// </summary>
    public static string no_category()
    {
        return GetString("no-category");
    }
    /// <summary>
    /// No Platform
    /// </summary>
    public static string no_platform()
    {
        return GetString("no-platform");
    }
    /// <summary>
    /// Whoops! Something went wrong…
    /// </summary>
    public static string crash_window_title()
    {
        return GetString("crash-window-title");
    }
    /// <summary>
    /// An unrecoverable error has occurred.
    /// 
    /// If you would like to help us fix this issue, please briefly describe the actions taken before the crash, and then send diagnostic information. If you are online, the package will be uploaded to the Playnite server for analysis.
    /// 
    /// Alternatively, you can click on the 'Report Crash' button to create a new GitHub issue and report the crash manually.
    /// 
    /// Thank you for your help.
    /// </summary>
    public static string crash_description()
    {
        return GetString("crash-description");
    }
    /// <summary>
    /// Extension "{$name}" caused an unrecoverable error.
    /// 
    /// We recommend saving the log file and reporting the issue to extension's developer. If the issue keeps reoccurring, disable the extension.
    /// </summary>
    public static string ext_crash_description(object name)
    {
        return GetString("ext-crash-description", ("name", name));
    }
    /// <summary>
    /// Extension "{$name}" caused an unrecoverable error.
    /// 
    /// We recommend reporting the issue to extension's developer. If the issue keeps reoccurring, disable the extension.
    /// </summary>
    public static string ext_crash_description_fs(object name)
    {
        return GetString("ext-crash-description-fs", ("name", name));
    }
    /// <summary>
    /// Unknown extension or a theme caused an unrecoverable error.
    /// 
    /// We recommend disabling 3rd party add-ons, isolating the problematic one and reporting the issue to add-on's developer.
    /// </summary>
    public static string ext_crash_description_unknown()
    {
        return GetString("ext-crash-description-unknown");
    }
    /// <summary>
    /// Unrecoverable error occurred.
    /// 
    /// If you want to help us fix this issue, please send diagnostic information. Thank you.
    /// </summary>
    public static string crash_description_fullscreen()
    {
        return GetString("crash-description-fullscreen");
    }
    /// <summary>
    /// Disable extension
    /// </summary>
    public static string crash_disable_extension()
    {
        return GetString("crash-disable-extension");
    }
    /// <summary>
    /// Save log file
    /// </summary>
    public static string crash_save_log()
    {
        return GetString("crash-save-log");
    }
    /// <summary>
    /// Send diag. info
    /// </summary>
    public static string crash_send_diag()
    {
        return GetString("crash-send-diag");
    }
    /// <summary>
    /// Report Crash
    /// </summary>
    public static string crash_report_issue()
    {
        return GetString("crash-report-issue");
    }
    /// <summary>
    /// Restart Playnite
    /// </summary>
    public static string crash_restart_playnite()
    {
        return GetString("crash-restart-playnite");
    }
    /// <summary>
    /// Restart in Safe Mode
    /// </summary>
    public static string crash_restart_safe()
    {
        return GetString("crash-restart-safe");
    }
    /// <summary>
    /// Disabling all 3rd party extensions and using default theme.
    /// </summary>
    public static string crash_restart_safe_tooltip()
    {
        return GetString("crash-restart-safe-tooltip");
    }
    /// <summary>
    /// Exit Playnite
    /// </summary>
    public static string crash_close_playnite()
    {
        return GetString("crash-close-playnite");
    }
    /// <summary>
    /// Actions taken before the crash (in English):
    /// </summary>
    public static string crash_user_actions_description()
    {
        return GetString("crash-user-actions-description");
    }
    /// <summary>
    /// Library Manager
    /// </summary>
    public static string library_manager()
    {
        return GetString("library-manager");
    }
    /// <summary>
    /// Remove Game(s)?
    /// </summary>
    public static string game_remove_ask_title()
    {
        return GetString("game-remove-ask-title");
    }
    /// <summary>
    /// Cannot remove - Game or installer is running.
    /// </summary>
    public static string game_remove_running_error()
    {
        return GetString("game-remove-running-error");
    }
    /// <summary>
    /// Cannot uninstall - Game is running.
    /// </summary>
    public static string game_uninstall_running_error()
    {
        return GetString("game-uninstall-running-error");
    }
    /// <summary>
    /// Are you sure you want to remove {$gameName}?
    /// </summary>
    public static string game_remove_ask_message(object gameName)
    {
        return GetString("game-remove-ask-message", ("gameName", gameName));
    }
    /// <summary>
    /// Are you sure you want to remove {$gameCount} games?
    /// </summary>
    public static string games_remove_ask_message(object gameCount)
    {
        return GetString("games-remove-ask-message", ("gameCount", gameCount));
    }
    /// <summary>
    /// Are you sure you want to remove {$gameName}?
    /// 
    /// Selecting "add to exclusion list" option will prevent game from being imported again next time library is updated.
    /// </summary>
    public static string game_remove_ask_message_ignore_option(object gameName)
    {
        return GetString("game-remove-ask-message-ignore-option", ("gameName", gameName));
    }
    /// <summary>
    /// Are you sure you want to remove {$gameCount} games?
    /// 
    /// Selecting "add to exclusion list" option will prevent games from being imported again next time library is updated.
    /// </summary>
    public static string games_remove_ask_message_ignore_option(object gameCount)
    {
        return GetString("games-remove-ask-message-ignore-option", ("gameCount", gameCount));
    }
    /// <summary>
    /// Are you sure you want to remove {$entryCount} entries that are currently not in use?
    /// </summary>
    public static string remove_unused_fields_ask_message(object entryCount)
    {
        return GetString("remove-unused-fields-ask-message", ("entryCount", entryCount));
    }
    /// <summary>
    /// No unused fields found.
    /// </summary>
    public static string remove_unused_fields_no_unused_message()
    {
        return GetString("remove-unused-fields-no-unused-message");
    }
    /// <summary>
    /// Yes (add to exclusion list)
    /// </summary>
    public static string remove_ask_add_to_exclusion_list_yes_response()
    {
        return GetString("remove-ask-add-to-exclusion-list-yes-response");
    }
    /// <summary>
    /// There are unsaved changes in this section
    /// </summary>
    public static string game_edit_change_notif()
    {
        return GetString("game-edit-change-notif");
    }
    /// <summary>
    /// Updating game library format…
    /// </summary>
    public static string db_upgrade_progress()
    {
        return GetString("db-upgrade-progress");
    }
    /// <summary>
    /// Database update failed.
    /// </summary>
    public static string db_upgrade_fail()
    {
        return GetString("db-upgrade-fail");
    }
    /// <summary>
    /// Cannot update game library. {$megaBytes} MBs of free space is required.
    /// </summary>
    public static string db_upgrade_empty_space_fail(object megaBytes)
    {
        return GetString("db-upgrade-empty-space-fail", ("megaBytes", megaBytes));
    }
    /// <summary>
    /// GameError
    /// </summary>
    public static string game_error()
    {
        return GetString("game-error");
    }
    /// <summary>
    /// Cannot start game. '{$gameId}' was not found in database.
    /// </summary>
    public static string game_start_error_no_game(object gameId)
    {
        return GetString("game-start-error-no-game", ("gameId", gameId));
    }
    /// <summary>
    /// Cannot start game.
    /// </summary>
    public static string game_start_error()
    {
        return GetString("game-start-error");
    }
    /// <summary>
    /// Cannot start action.
    /// </summary>
    public static string game_start_action_error()
    {
        return GetString("game-start-action-error");
    }
    /// <summary>
    /// Cannot open game location.
    /// </summary>
    public static string game_open_location_error()
    {
        return GetString("game-open-location-error");
    }
    /// <summary>
    /// Could not detect game install size.
    /// </summary>
    public static string calculate_game_size_error()
    {
        return GetString("calculate-game-size-error");
    }
    /// <summary>
    /// Install size scan error
    /// </summary>
    public static string calculate_game_size_error_caption()
    {
        return GetString("calculate-game-size-error-caption");
    }
    /// <summary>
    /// There were {$errorCount} errors during install size scan
    /// </summary>
    public static string calculate_games_size_error_message(object errorCount)
    {
        return GetString("calculate-games-size-error-message", ("errorCount", errorCount));
    }
    /// <summary>
    /// Failed to create shortcut.
    /// </summary>
    public static string game_shortcut_error()
    {
        return GetString("game-shortcut-error");
    }
    /// <summary>
    /// Failed to open manual.
    /// </summary>
    public static string manual_open_error()
    {
        return GetString("manual-open-error");
    }
    /// <summary>
    /// Cannot install game.
    /// </summary>
    public static string game_install_error()
    {
        return GetString("game-install-error");
    }
    /// <summary>
    /// Cannot un-install game.
    /// </summary>
    public static string game_uninstall_error()
    {
        return GetString("game-uninstall-error");
    }
    /// <summary>
    /// No valid game startup actions found. When using emulator actions, make sure platform definitions match between the game and emulator configuration.
    /// </summary>
    public static string error_no_play_action()
    {
        return GetString("error-no-play-action");
    }
    /// <summary>
    /// Installation implementation is not available.
    /// </summary>
    public static string error_no_install_action()
    {
        return GetString("error-no-install-action");
    }
    /// <summary>
    /// The library plugin responsible for this game is disabled or not installed.
    /// </summary>
    public static string error_library_plugin_not_found()
    {
        return GetString("error-library-plugin-not-found");
    }
    /// <summary>
    /// Official metadata download is not available.
    /// </summary>
    public static string error_no_metadata_downloader()
    {
        return GetString("error-no-metadata-downloader");
    }
    /// <summary>
    /// No game is selected.
    /// </summary>
    public static string error_no_game_selected()
    {
        return GetString("error-no-game-selected");
    }
    /// <summary>
    /// Game's script execution failed.
    /// </summary>
    public static string error_game_script_action()
    {
        return GetString("error-game-script-action");
    }
    /// <summary>
    /// Application script execution failed.
    /// </summary>
    public static string error_application_script()
    {
        return GetString("error-application-script");
    }
    /// <summary>
    /// Global script execution failed.
    /// </summary>
    public static string error_global_script_action()
    {
        return GetString("error-global-script-action");
    }
    /// <summary>
    /// Emulator script execution failed.
    /// </summary>
    public static string error_emulator_script_action()
    {
        return GetString("error-emulator-script-action");
    }
    /// <summary>
    /// Play script action execution failed.
    /// </summary>
    public static string error_play_script_action()
    {
        return GetString("error-play-script-action");
    }
    /// <summary>
    /// PowerShell 3.0 or newer is not installed.
    /// </summary>
    public static string error_power_shell_not_installed()
    {
        return GetString("error-power-shell-not-installed");
    }
    /// <summary>
    /// Couldn't determine how to start the game.
    /// </summary>
    public static string error_startup_no_controller()
    {
        return GetString("error-startup-no-controller");
    }
    /// <summary>
    /// Enabled
    /// </summary>
    public static string enabled_title()
    {
        return GetString("enabled-title");
    }
    /// <summary>
    /// Remove
    /// </summary>
    public static string remove_title()
    {
        return GetString("remove-title");
    }
    /// <summary>
    /// Remove unused
    /// </summary>
    public static string remove_unused_title()
    {
        return GetString("remove-unused-title");
    }
    /// <summary>
    /// Rename
    /// </summary>
    public static string rename_title()
    {
        return GetString("rename-title");
    }
    /// <summary>
    /// Copy
    /// </summary>
    public static string copy_title()
    {
        return GetString("copy-title");
    }
    /// <summary>
    /// Add
    /// </summary>
    public static string add_title()
    {
        return GetString("add-title");
    }
    /// <summary>
    /// Default Icon
    /// </summary>
    public static string default_icon_title()
    {
        return GetString("default-icon-title");
    }
    /// <summary>
    /// Default Cover Image
    /// </summary>
    public static string default_cover_title()
    {
        return GetString("default-cover-title");
    }
    /// <summary>
    /// Default Background Image
    /// </summary>
    public static string default_background_title()
    {
        return GetString("default-background-title");
    }
    /// <summary>
    /// Finish
    /// </summary>
    public static string finish_label()
    {
        return GetString("finish-label");
    }
    /// <summary>
    /// Next
    /// </summary>
    public static string next_label()
    {
        return GetString("next-label");
    }
    /// <summary>
    /// Back
    /// </summary>
    public static string back_label()
    {
        return GetString("back-label");
    }
    /// <summary>
    /// DONE
    /// </summary>
    public static string done_cap_label()
    {
        return GetString("done-cap-label");
    }
    /// <summary>
    /// BACK
    /// </summary>
    public static string back_cap_label()
    {
        return GetString("back-cap-label");
    }
    /// <summary>
    /// CLEAR
    /// </summary>
    public static string clear_cap_label()
    {
        return GetString("clear-cap-label");
    }
    /// <summary>
    /// Clear
    /// </summary>
    public static string clear_label()
    {
        return GetString("clear-label");
    }
    /// <summary>
    /// Dismiss
    /// </summary>
    public static string dismiss()
    {
        return GetString("dismiss");
    }
    /// <summary>
    /// Dismiss All
    /// </summary>
    public static string dismiss_all()
    {
        return GetString("dismiss-all");
    }
    /// <summary>
    /// Import
    /// </summary>
    public static string import_label()
    {
        return GetString("import-label");
    }
    /// <summary>
    /// Name
    /// </summary>
    public static string name_label()
    {
        return GetString("name-label");
    }
    /// <summary>
    /// Author
    /// </summary>
    public static string author_label()
    {
        return GetString("author-label");
    }
    /// <summary>
    /// Module
    /// </summary>
    public static string module_label()
    {
        return GetString("module-label");
    }
    /// <summary>
    /// Series
    /// </summary>
    public static string series_label()
    {
        return GetString("series-label");
    }
    /// <summary>
    /// Version
    /// </summary>
    public static string version_label()
    {
        return GetString("version-label");
    }
    /// <summary>
    /// Last Played
    /// </summary>
    public static string last_played_label()
    {
        return GetString("last-played-label");
    }
    /// <summary>
    /// Most Played
    /// </summary>
    public static string most_played_label()
    {
        return GetString("most-played-label");
    }
    /// <summary>
    /// Play Count
    /// </summary>
    public static string play_count_label()
    {
        return GetString("play-count-label");
    }
    /// <summary>
    /// Install Size
    /// </summary>
    public static string install_size_label()
    {
        return GetString("install-size-label");
    }
    /// <summary>
    /// Folder
    /// </summary>
    public static string folder_label()
    {
        return GetString("folder-label");
    }
    /// <summary>
    /// Notes
    /// </summary>
    public static string notes_label()
    {
        return GetString("notes-label");
    }
    /// <summary>
    /// Added
    /// </summary>
    public static string added_label()
    {
        return GetString("added-label");
    }
    /// <summary>
    /// Date Added
    /// </summary>
    public static string date_added_label()
    {
        return GetString("date-added-label");
    }
    /// <summary>
    /// Modified
    /// </summary>
    public static string modified_label()
    {
        return GetString("modified-label");
    }
    /// <summary>
    /// Date Modified
    /// </summary>
    public static string date_modified_label()
    {
        return GetString("date-modified-label");
    }
    /// <summary>
    /// Website
    /// </summary>
    public static string website_label()
    {
        return GetString("website-label");
    }
    /// <summary>
    /// Path
    /// </summary>
    public static string path_label()
    {
        return GetString("path-label");
    }
    /// <summary>
    /// OK
    /// </summary>
    public static string ok_label()
    {
        return GetString("ok-label");
    }
    /// <summary>
    /// Save
    /// </summary>
    public static string save_label()
    {
        return GetString("save-label");
    }
    /// <summary>
    /// Close
    /// </summary>
    public static string close_label()
    {
        return GetString("close-label");
    }
    /// <summary>
    /// Cancel
    /// </summary>
    public static string cancel_label()
    {
        return GetString("cancel-label");
    }
    /// <summary>
    /// Confirm
    /// </summary>
    public static string confirm_label()
    {
        return GetString("confirm-label");
    }
    /// <summary>
    /// Reset
    /// </summary>
    public static string reset_label()
    {
        return GetString("reset-label");
    }
    /// <summary>
    /// Yes
    /// </summary>
    public static string yes_label()
    {
        return GetString("yes-label");
    }
    /// <summary>
    /// No
    /// </summary>
    public static string no_label()
    {
        return GetString("no-label");
    }
    /// <summary>
    /// Welcome
    /// </summary>
    public static string welcome_label()
    {
        return GetString("welcome-label");
    }
    /// <summary>
    /// Local User
    /// </summary>
    public static string local_user_label()
    {
        return GetString("local-user-label");
    }
    /// <summary>
    /// General
    /// </summary>
    public static string general_label()
    {
        return GetString("general-label");
    }
    /// <summary>
    /// Media
    /// </summary>
    public static string media_label()
    {
        return GetString("media-label");
    }
    /// <summary>
    /// Links
    /// </summary>
    public static string links_label()
    {
        return GetString("links-label");
    }
    /// <summary>
    /// Installation
    /// </summary>
    public static string installation_label()
    {
        return GetString("installation-label");
    }
    /// <summary>
    /// Actions
    /// </summary>
    public static string actions_label()
    {
        return GetString("actions-label");
    }
    /// <summary>
    /// Downloading…
    /// </summary>
    public static string downloading_label()
    {
        return GetString("downloading-label");
    }
    /// <summary>
    /// Downloading media…
    /// </summary>
    public static string downloading_media_label()
    {
        return GetString("downloading-media-label");
    }
    /// <summary>
    /// Loading…
    /// </summary>
    public static string loading_label()
    {
        return GetString("loading-label");
    }
    /// <summary>
    /// Type
    /// </summary>
    public static string type_label()
    {
        return GetString("type-label");
    }
    /// <summary>
    /// Profile
    /// </summary>
    public static string profile_label()
    {
        return GetString("profile-label");
    }
    /// <summary>
    /// Profiles
    /// </summary>
    public static string profiles_label()
    {
        return GetString("profiles-label");
    }
    /// <summary>
    /// Remove
    /// </summary>
    public static string remove_label()
    {
        return GetString("remove-label");
    }
    /// <summary>
    /// Download
    /// </summary>
    public static string download_label()
    {
        return GetString("download-label");
    }
    /// <summary>
    /// Search
    /// </summary>
    public static string search_label()
    {
        return GetString("search-label");
    }
    /// <summary>
    /// Resolution:
    /// </summary>
    public static string search_resolution_label()
    {
        return GetString("search-resolution-label");
    }
    /// <summary>
    /// Any
    /// </summary>
    public static string search_resolution_any_label()
    {
        return GetString("search-resolution-any-label");
    }
    /// <summary>
    /// Zoom
    /// </summary>
    public static string zoom_label()
    {
        return GetString("zoom-label");
    }
    /// <summary>
    /// List View
    /// </summary>
    public static string list_view_label()
    {
        return GetString("list-view-label");
    }
    /// <summary>
    /// Covers
    /// </summary>
    public static string covers_label()
    {
        return GetString("covers-label");
    }
    /// <summary>
    /// Grid View
    /// </summary>
    public static string grid_view_label()
    {
        return GetString("grid-view-label");
    }
    /// <summary>
    /// Details View
    /// </summary>
    public static string details_view_label()
    {
        return GetString("details-view-label");
    }
    /// <summary>
    /// Custom
    /// </summary>
    public static string custom_label()
    {
        return GetString("custom-label");
    }
    /// <summary>
    /// URL
    /// </summary>
    public static string url_label()
    {
        return GetString("url-label");
    }
    /// <summary>
    /// Patrons
    /// </summary>
    public static string patrons_label()
    {
        return GetString("patrons-label");
    }
    /// <summary>
    /// License
    /// </summary>
    public static string license_label()
    {
        return GetString("license-label");
    }
    /// <summary>
    /// Contributors
    /// </summary>
    public static string contributors_label()
    {
        return GetString("contributors-label");
    }
    /// <summary>
    /// Exiting Playnite…
    /// </summary>
    public static string closing_playnite()
    {
        return GetString("closing-playnite");
    }
    /// <summary>
    /// Today
    /// </summary>
    public static string today()
    {
        return GetString("today");
    }
    /// <summary>
    /// Yesterday
    /// </summary>
    public static string yesterday()
    {
        return GetString("yesterday");
    }
    /// <summary>
    /// Monday
    /// </summary>
    public static string monday()
    {
        return GetString("monday");
    }
    /// <summary>
    /// Tuesday
    /// </summary>
    public static string tuesday()
    {
        return GetString("tuesday");
    }
    /// <summary>
    /// Wednesday
    /// </summary>
    public static string wednesday()
    {
        return GetString("wednesday");
    }
    /// <summary>
    /// Thursday
    /// </summary>
    public static string thursday()
    {
        return GetString("thursday");
    }
    /// <summary>
    /// Friday
    /// </summary>
    public static string friday()
    {
        return GetString("friday");
    }
    /// <summary>
    /// Saturday
    /// </summary>
    public static string saturday()
    {
        return GetString("saturday");
    }
    /// <summary>
    /// Sunday
    /// </summary>
    public static string sunday()
    {
        return GetString("sunday");
    }
    /// <summary>
    /// Past Week
    /// </summary>
    public static string past_week()
    {
        return GetString("past-week");
    }
    /// <summary>
    /// Past Month
    /// </summary>
    public static string past_month()
    {
        return GetString("past-month");
    }
    /// <summary>
    /// Past Year
    /// </summary>
    public static string past_year()
    {
        return GetString("past-year");
    }
    /// <summary>
    /// More than a year ago
    /// </summary>
    public static string more_then_year()
    {
        return GetString("more-then-year");
    }
    /// <summary>
    /// 0 to 100MB
    /// </summary>
    public static string size_zero_to100_mb()
    {
        return GetString("size-zero-to100-mb");
    }
    /// <summary>
    /// 100MB to 1GB
    /// </summary>
    public static string size100_mb_to1_gb()
    {
        return GetString("size100-mb-to1-gb");
    }
    /// <summary>
    /// 1GB to 5GB
    /// </summary>
    public static string size1_gb_to5_gb()
    {
        return GetString("size1-gb-to5-gb");
    }
    /// <summary>
    /// 5GB to 10GB
    /// </summary>
    public static string size5_gb_to10_gb()
    {
        return GetString("size5-gb-to10-gb");
    }
    /// <summary>
    /// 10GB to 20GB
    /// </summary>
    public static string size10_gb_to20_gb()
    {
        return GetString("size10-gb-to20-gb");
    }
    /// <summary>
    /// 20GB to 40GB
    /// </summary>
    public static string size20_gb_to40_gb()
    {
        return GetString("size20-gb-to40-gb");
    }
    /// <summary>
    /// 40GB to 100GB
    /// </summary>
    public static string size40_gb_to100_gb()
    {
        return GetString("size40-gb-to100-gb");
    }
    /// <summary>
    /// 100GB or more
    /// </summary>
    public static string size_more_than100_gb()
    {
        return GetString("size-more-than100-gb");
    }
    /// <summary>
    /// Import completed successfully.
    /// </summary>
    public static string import_completed()
    {
        return GetString("import-completed");
    }
    /// <summary>
    /// All Games
    /// </summary>
    public static string all_games()
    {
        return GetString("all-games");
    }
    /// <summary>
    /// Game Id
    /// </summary>
    public static string game_id()
    {
        return GetString("game-id");
    }
    /// <summary>
    /// Database Id
    /// </summary>
    public static string database_id()
    {
        return GetString("database-id");
    }
    /// <summary>
    /// Presets
    /// </summary>
    public static string presets()
    {
        return GetString("presets");
    }
    /// <summary>
    /// Column
    /// </summary>
    public static string column()
    {
        return GetString("column");
    }
    /// <summary>
    /// Columns
    /// </summary>
    public static string columns()
    {
        return GetString("columns");
    }
    /// <summary>
    /// Row
    /// </summary>
    public static string row()
    {
        return GetString("row");
    }
    /// <summary>
    /// Rows
    /// </summary>
    public static string rows()
    {
        return GetString("rows");
    }
    /// <summary>
    /// Couldn't get icon from Play action. There's no action of File type present.
    /// </summary>
    public static string exec_icon_missing_play_action()
    {
        return GetString("exec-icon-missing-play-action");
    }
    /// <summary>
    /// Only download missing metadata
    /// </summary>
    public static string meta_skip_non_empty()
    {
        return GetString("meta-skip-non-empty");
    }
    /// <summary>
    /// Enabling this option will skip downloading metadata for data fields that already contain information.
    /// </summary>
    public static string meta_skip_non_empty_tooltip()
    {
        return GetString("meta-skip-non-empty-tooltip");
    }
    /// <summary>
    /// Games selection
    /// </summary>
    public static string meta_games_source_intro()
    {
        return GetString("meta-games-source-intro");
    }
    /// <summary>
    /// Please select which games should to be updated with new metadata:
    /// </summary>
    public static string meta_games_source_description()
    {
        return GetString("meta-games-source-description");
    }
    /// <summary>
    /// All games from database
    /// </summary>
    public static string meta_game_source_all()
    {
        return GetString("meta-game-source-all");
    }
    /// <summary>
    /// All currently filtered games
    /// </summary>
    public static string meta_game_source_filtered()
    {
        return GetString("meta-game-source-filtered");
    }
    /// <summary>
    /// Selected games only
    /// </summary>
    public static string meta_game_source_selected()
    {
        return GetString("meta-game-source-selected");
    }
    /// <summary>
    /// Official Store
    /// </summary>
    public static string meta_source_store()
    {
        return GetString("meta-source-store");
    }
    /// <summary>
    /// IGDB
    /// </summary>
    public static string meta_source_igdb()
    {
        return GetString("meta-source-igdb");
    }
    /// <summary>
    /// Please select which fields should be automatically populated by Playnite and which sources should be used to obtain the data from.
    /// </summary>
    public static string meta_description_fields()
    {
        return GetString("meta-description-fields");
    }
    /// <summary>
    /// Please consider clicking on the logo above and contribute updates to igdb.com database in order to improve data Playnite uses.
    /// </summary>
    public static string meta_igdb_contrib_notif()
    {
        return GetString("meta-igdb-contrib-notif");
    }
    /// <summary>
    /// Downloading metadata…
    /// </summary>
    public static string progress_metadata()
    {
        return GetString("progress-metadata");
    }
    /// <summary>
    /// Importing installed games…
    /// </summary>
    public static string progress_installed_games()
    {
        return GetString("progress-installed-games");
    }
    /// <summary>
    /// Importing {$libraryName} games…
    /// </summary>
    public static string progress_importing_games(object libraryName)
    {
        return GetString("progress-importing-games", ("libraryName", libraryName));
    }
    /// <summary>
    /// Importing emulated games from {$scannerName}…
    /// </summary>
    public static string progress_importing_emulated_games(object scannerName)
    {
        return GetString("progress-importing-emulated-games", ("scannerName", scannerName));
    }
    /// <summary>
    /// Downloading library updates…
    /// </summary>
    public static string progress_library_games()
    {
        return GetString("progress-library-games");
    }
    /// <summary>
    /// Scanning size of games in library…
    /// </summary>
    public static string progress_scanning_games_install_size()
    {
        return GetString("progress-scanning-games-install-size");
    }
    /// <summary>
    /// Scanning size of imported games…
    /// </summary>
    public static string progress_scanning_imported_games_install_size()
    {
        return GetString("progress-scanning-imported-games-install-size");
    }
    /// <summary>
    /// Library update finished
    /// </summary>
    public static string progress_lib_import_finish()
    {
        return GetString("progress-lib-import-finish");
    }
    /// <summary>
    /// Releasing resources…
    /// </summary>
    public static string progress_releasing_resources()
    {
        return GetString("progress-releasing-resources");
    }
    /// <summary>
    /// Configuration
    /// </summary>
    public static string menu_configuration_title()
    {
        return GetString("menu-configuration-title");
    }
    /// <summary>
    /// Settings…
    /// </summary>
    public static string menu_playnite_settings_title()
    {
        return GetString("menu-playnite-settings-title");
    }
    /// <summary>
    /// Platforms and Emulators
    /// </summary>
    public static string menu_platform_emulator_settings_title()
    {
        return GetString("menu-platform-emulator-settings-title");
    }
    /// <summary>
    /// Configure Emulators…
    /// </summary>
    public static string menu_configure_emulators_menu_title()
    {
        return GetString("menu-configure-emulators-menu-title");
    }
    /// <summary>
    /// Library Manager…
    /// </summary>
    public static string menu_library_manager_title()
    {
        return GetString("menu-library-manager-title");
    }
    /// <summary>
    /// Tools
    /// </summary>
    public static string menu_tools()
    {
        return GetString("menu-tools");
    }
    /// <summary>
    /// Download Metadata…
    /// </summary>
    public static string menu_download_metadata()
    {
        return GetString("menu-download-metadata");
    }
    /// <summary>
    /// Software Tools…
    /// </summary>
    public static string menu_software_tools()
    {
        return GetString("menu-software-tools");
    }
    /// <summary>
    /// Configure Integrations…
    /// </summary>
    public static string menu_configure_integrations()
    {
        return GetString("menu-configure-integrations");
    }
    /// <summary>
    /// Open 3rd Party Client
    /// </summary>
    public static string menu_open_client()
    {
        return GetString("menu-open-client");
    }
    /// <summary>
    /// 3rd Party Clients
    /// </summary>
    public static string menu_clients()
    {
        return GetString("menu-clients");
    }
    /// <summary>
    /// Update Game Library
    /// </summary>
    public static string menu_reload_library()
    {
        return GetString("menu-reload-library");
    }
    /// <summary>
    /// Cancel Library Update
    /// </summary>
    public static string menu_cancel_library_update()
    {
        return GetString("menu-cancel-library-update");
    }
    /// <summary>
    /// Update Emulated Folders
    /// </summary>
    public static string menu_update_emulated_dirs()
    {
        return GetString("menu-update-emulated-dirs");
    }
    /// <summary>
    /// Add Game
    /// </summary>
    public static string menu_add_game()
    {
        return GetString("menu-add-game");
    }
    /// <summary>
    /// Manually…
    /// </summary>
    public static string menu_add_game_manual()
    {
        return GetString("menu-add-game-manual");
    }
    /// <summary>
    /// Scan Automatically…
    /// </summary>
    public static string menu_add_game_installed()
    {
        return GetString("menu-add-game-installed");
    }
    /// <summary>
    /// Emulated Game…
    /// </summary>
    public static string menu_add_game_emulated()
    {
        return GetString("menu-add-game-emulated");
    }
    /// <summary>
    /// Microsoft Store application…
    /// </summary>
    public static string menu_add_windows_store()
    {
        return GetString("menu-add-windows-store");
    }
    /// <summary>
    /// About Playnite
    /// </summary>
    public static string menu_about()
    {
        return GetString("menu-about");
    }
    /// <summary>
    /// Send Feedback
    /// </summary>
    public static string menu_issues()
    {
        return GetString("menu-issues");
    }
    /// <summary>
    /// Switch to Fullscreen Mode
    /// </summary>
    public static string menu_open_fullscreen()
    {
        return GetString("menu-open-fullscreen");
    }
    /// <summary>
    /// Links
    /// </summary>
    public static string menu_links_title()
    {
        return GetString("menu-links-title");
    }
    /// <summary>
    /// Help
    /// </summary>
    public static string menu_help_title()
    {
        return GetString("menu-help-title");
    }
    /// <summary>
    /// Support on Patreon
    /// </summary>
    public static string menu_patreon_support()
    {
        return GetString("menu-patreon-support");
    }
    /// <summary>
    /// SDK Documentation
    /// </summary>
    public static string sdk_documentation()
    {
        return GetString("sdk-documentation");
    }
    /// <summary>
    /// Restart System
    /// </summary>
    public static string menu_restart_system()
    {
        return GetString("menu-restart-system");
    }
    /// <summary>
    /// Turn Off System
    /// </summary>
    public static string menu_shutdown_system()
    {
        return GetString("menu-shutdown-system");
    }
    /// <summary>
    /// Suspend System
    /// </summary>
    public static string menu_suspend_system()
    {
        return GetString("menu-suspend-system");
    }
    /// <summary>
    /// Hibernate System
    /// </summary>
    public static string menu_hibernate_system()
    {
        return GetString("menu-hibernate-system");
    }
    /// <summary>
    /// Pick a Random Game
    /// </summary>
    public static string menu_select_random_game()
    {
        return GetString("menu-select-random-game");
    }
    /// <summary>
    /// Game fields to be displayed on details panel:
    /// </summary>
    public static string settings_details_panel_items()
    {
        return GetString("settings-details-panel-items");
    }
    /// <summary>
    /// Item spacing
    /// </summary>
    public static string settings_grid_item_spacing()
    {
        return GetString("settings-grid-item-spacing");
    }
    /// <summary>
    /// Draw grid item background
    /// </summary>
    public static string settings_grid_item_draw_background()
    {
        return GetString("settings-grid-item-draw-background");
    }
    /// <summary>
    /// Grid item border width
    /// </summary>
    public static string settings_grid_item_cover_margin()
    {
        return GetString("settings-grid-item-cover-margin");
    }
    /// <summary>
    /// Missing game icon source
    /// </summary>
    public static string settings_default_icon_source()
    {
        return GetString("settings-default-icon-source");
    }
    /// <summary>
    /// Missing game cover source
    /// </summary>
    public static string settings_default_cover_source()
    {
        return GetString("settings-default-cover-source");
    }
    /// <summary>
    /// Missing game background source
    /// </summary>
    public static string settings_default_background_source()
    {
        return GetString("settings-default-background-source");
    }
    /// <summary>
    /// Vertical spacing to game details
    /// </summary>
    public static string settings_indent_game_details()
    {
        return GetString("settings-indent-game-details");
    }
    /// <summary>
    /// Grid view details position
    /// </summary>
    public static string settings_grid_view_details_position()
    {
        return GetString("settings-grid-view-details-position");
    }
    /// <summary>
    /// Details view game list position
    /// </summary>
    public static string settings_details_game_list_position()
    {
        return GetString("settings-details-game-list-position");
    }
    /// <summary>
    /// Draw separator between panels
    /// </summary>
    public static string settings_draw_panel_separators()
    {
        return GetString("settings-draw-panel-separators");
    }
    /// <summary>
    /// Game cover image height
    /// </summary>
    public static string settings_game_details_cover_height()
    {
        return GetString("settings-game-details-cover-height");
    }
    /// <summary>
    /// Game list icon height
    /// </summary>
    public static string settings_game_details_list_icon_size()
    {
        return GetString("settings-game-details-list-icon-size");
    }
    /// <summary>
    /// Application font
    /// </summary>
    public static string settings_interface_font()
    {
        return GetString("settings-interface-font");
    }
    /// <summary>
    /// Monospaced font
    /// </summary>
    public static string settings_interface_mono_font()
    {
        return GetString("settings-interface-mono-font");
    }
    /// <summary>
    /// Filter panel position
    /// </summary>
    public static string settings_filter_panel_position()
    {
        return GetString("settings-filter-panel-position");
    }
    /// <summary>
    /// Explorer panel position
    /// </summary>
    public static string settings_explorer_panel_position()
    {
        return GetString("settings-explorer-panel-position");
    }
    /// <summary>
    /// Cover art rendering
    /// </summary>
    public static string settings_cover_art_rendering_label()
    {
        return GetString("settings-cover-art-rendering-label");
    }
    /// <summary>
    /// Target aspect ratio
    /// </summary>
    public static string settings_target_aspect_ratio_label()
    {
        return GetString("settings-target-aspect-ratio-label");
    }
    /// <summary>
    /// Following options also affect tile rendering in Fullscreen mode!
    /// </summary>
    public static string settings_grid_tile_layout_fsnote()
    {
        return GetString("settings-grid-tile-layout-fsnote");
    }
    /// <summary>
    /// Stretch mode
    /// </summary>
    public static string settings_stretch_mode_label()
    {
        return GetString("settings-stretch-mode-label");
    }
    /// <summary>
    /// DVD Box
    /// </summary>
    public static string settings_covert_aspect_dvd()
    {
        return GetString("settings-covert-aspect-dvd");
    }
    /// <summary>
    /// Epic Games Store
    /// </summary>
    public static string settings_covert_aspect_epic_games_store()
    {
        return GetString("settings-covert-aspect-epic-games-store");
    }
    /// <summary>
    /// GOG Galaxy 2.0
    /// </summary>
    public static string settings_covert_aspect_gog_galaxy2()
    {
        return GetString("settings-covert-aspect-gog-galaxy2");
    }
    /// <summary>
    /// IGDB
    /// </summary>
    public static string settings_covert_aspect_igdb()
    {
        return GetString("settings-covert-aspect-igdb");
    }
    /// <summary>
    /// Square
    /// </summary>
    public static string settings_covert_aspect_square()
    {
        return GetString("settings-covert-aspect-square");
    }
    /// <summary>
    /// Steam Banner
    /// </summary>
    public static string settings_covert_aspect_steam()
    {
        return GetString("settings-covert-aspect-steam");
    }
    /// <summary>
    /// Steam vertical cover
    /// </summary>
    public static string settings_covert_aspect_steam_vertical()
    {
        return GetString("settings-covert-aspect-steam-vertical");
    }
    /// <summary>
    /// Twitch
    /// </summary>
    public static string settings_covert_aspect_twitch()
    {
        return GetString("settings-covert-aspect-twitch");
    }
    /// <summary>
    /// * Requires restart to apply
    /// </summary>
    public static string settings_restart_notification()
    {
        return GetString("settings-restart-notification");
    }
    /// <summary>
    /// Settings
    /// </summary>
    public static string settings_label()
    {
        return GetString("settings-label");
    }
    /// <summary>
    /// General
    /// </summary>
    public static string settings_general_label()
    {
        return GetString("settings-general-label");
    }
    /// <summary>
    /// Top panel
    /// </summary>
    public static string settings_top_panel_label()
    {
        return GetString("settings-top-panel-label");
    }
    /// <summary>
    /// Appearance
    /// </summary>
    public static string settings_appearance_label()
    {
        return GetString("settings-appearance-label");
    }
    /// <summary>
    /// Game Details
    /// </summary>
    public static string settings_game_details_label()
    {
        return GetString("settings-game-details-label");
    }
    /// <summary>
    /// Layout
    /// </summary>
    public static string settings_layout_label()
    {
        return GetString("settings-layout-label");
    }
    /// <summary>
    /// Advanced
    /// </summary>
    public static string settings_advanced_label()
    {
        return GetString("settings-advanced-label");
    }
    /// <summary>
    /// Fullscreen
    /// </summary>
    public static string settings_fullscreen_label()
    {
        return GetString("settings-fullscreen-label");
    }
    /// <summary>
    /// Input
    /// </summary>
    public static string settings_input_label()
    {
        return GetString("settings-input-label");
    }
    /// <summary>
    /// Performance
    /// </summary>
    public static string settings_performance_label()
    {
        return GetString("settings-performance-label");
    }
    /// <summary>
    /// Metadata
    /// </summary>
    public static string settings_metadata_label()
    {
        return GetString("settings-metadata-label");
    }
    /// <summary>
    /// Updating
    /// </summary>
    public static string settings_updating()
    {
        return GetString("settings-updating");
    }
    /// <summary>
    /// Search
    /// </summary>
    public static string settings_search()
    {
        return GetString("settings-search");
    }
    /// <summary>
    /// Backup
    /// </summary>
    public static string settings_backup()
    {
        return GetString("settings-backup");
    }
    /// <summary>
    /// Backup Library Data
    /// </summary>
    public static string menu_backup_data()
    {
        return GetString("menu-backup-data");
    }
    /// <summary>
    /// Restore Data Backup
    /// </summary>
    public static string menu_restore_backup()
    {
        return GetString("menu-restore-backup");
    }
    /// <summary>
    /// Import changes in library automatically
    /// </summary>
    public static string settings_import_label()
    {
        return GetString("settings-import-label");
    }
    /// <summary>
    /// Invalid database file location, proper file path must be set.
    /// </summary>
    public static string settings_invalid_db_location()
    {
        return GetString("settings-invalid-db-location");
    }
    /// <summary>
    /// Account name cannot be empty.
    /// </summary>
    public static string settings_invalid_account_name()
    {
        return GetString("settings-invalid-account-name");
    }
    /// <summary>
    /// Download metadata after importing games
    /// </summary>
    public static string settings_download_metadata_on_import()
    {
        return GetString("settings-download-metadata-on-import");
    }
    /// <summary>
    /// Launch Playnite minimized
    /// </summary>
    public static string settings_start_minimized()
    {
        return GetString("settings-start-minimized");
    }
    /// <summary>
    /// Launch Playnite when you start your computer
    /// </summary>
    public static string settings_start_on_boot()
    {
        return GetString("settings-start-on-boot");
    }
    /// <summary>
    /// Start closed to tray
    /// </summary>
    public static string settings_start_on_boot_closed_to_tray()
    {
        return GetString("settings-start-on-boot-closed-to-tray");
    }
    /// <summary>
    /// Failed to register Playnite to launch when computer starts.
    /// </summary>
    public static string settings_start_on_boot_registration_error()
    {
        return GetString("settings-start-on-boot-registration-error");
    }
    /// <summary>
    /// Launch in Fullscreen Mode
    /// </summary>
    public static string settings_start_in_fullscreen()
    {
        return GetString("settings-start-in-fullscreen");
    }
    /// <summary>
    /// Asynchronous image loading
    /// </summary>
    public static string settings_async_image_loading()
    {
        return GetString("settings-async-image-loading");
    }
    /// <summary>
    /// Can improve scrolling smoothness of game lists in exchange for slower image load times.
    /// </summary>
    public static string settings_async_image_loading_tooltip()
    {
        return GetString("settings-async-image-loading-tooltip");
    }
    /// <summary>
    /// Show game name if cover art is missing
    /// </summary>
    public static string settings_show_name_empty_cover()
    {
        return GetString("settings-show-name-empty-cover");
    }
    /// <summary>
    /// Show game names on Grid view
    /// </summary>
    public static string settings_show_names_under_cover()
    {
        return GetString("settings-show-names-under-cover");
    }
    /// <summary>
    /// Darken not installed games
    /// </summary>
    public static string settings_darken_uninstalled_grid_covers()
    {
        return GetString("settings-darken-uninstalled-grid-covers");
    }
    /// <summary>
    /// Show game icons on Details view list
    /// </summary>
    public static string settings_show_icon_list()
    {
        return GetString("settings-show-icon-list");
    }
    /// <summary>
    /// Show item count on group descriptions
    /// </summary>
    public static string settings_show_group_count()
    {
        return GetString("settings-show-group-count");
    }
    /// <summary>
    /// Show only assigned fields on filter and explorer panels
    /// </summary>
    public static string settings_used_fields_only_on_filter_lists()
    {
        return GetString("settings-used-fields-only-on-filter-lists");
    }
    /// <summary>
    /// Disable hardware acceleration
    /// </summary>
    public static string settings_disable_acceleration()
    {
        return GetString("settings-disable-acceleration");
    }
    /// <summary>
    /// Use when experiencing stuttering or similar UI issues
    /// </summary>
    public static string settings_disable_acceleration_tooltip()
    {
        return GetString("settings-disable-acceleration-tooltip");
    }
    /// <summary>
    /// Show hidden games in quick launch lists
    /// </summary>
    public static string settings_hidden_in_quick_launch()
    {
        return GetString("settings-hidden-in-quick-launch");
    }
    /// <summary>
    /// Affects Jump List and tray menu lists.
    /// </summary>
    public static string settings_hidden_in_quick_launch_tooltip()
    {
        return GetString("settings-hidden-in-quick-launch-tooltip");
    }
    /// <summary>
    /// Number of quick launch items
    /// </summary>
    public static string settings_quick_launch_items()
    {
        return GetString("settings-quick-launch-items");
    }
    /// <summary>
    /// Use game background image as window background
    /// </summary>
    public static string settings_show_background_window_image()
    {
        return GetString("settings-show-background-window-image");
    }
    /// <summary>
    /// Blur background
    /// </summary>
    public static string settings_blur_window_background_image()
    {
        return GetString("settings-blur-window-background-image");
    }
    /// <summary>
    /// High Quality
    /// </summary>
    public static string settings_blur_high_quality()
    {
        return GetString("settings-blur-high-quality");
    }
    /// <summary>
    /// Darken background
    /// </summary>
    public static string settings_darken_window_background_image()
    {
        return GetString("settings-darken-window-background-image");
    }
    /// <summary>
    /// Show on Grid view
    /// </summary>
    public static string settings_show_back_image_on_grid_view()
    {
        return GetString("settings-show-back-image-on-grid-view");
    }
    /// <summary>
    /// Theme
    /// </summary>
    public static string settings_skin()
    {
        return GetString("settings-skin");
    }
    /// <summary>
    /// Theme Profile
    /// </summary>
    public static string settings_skin_color()
    {
        return GetString("settings-skin-color");
    }
    /// <summary>
    /// Fullscreen Theme
    /// </summary>
    public static string settings_skin_fullscreen()
    {
        return GetString("settings-skin-fullscreen");
    }
    /// <summary>
    /// Fullscreen Theme Profile
    /// </summary>
    public static string settings_skin_color_fullscreen()
    {
        return GetString("settings-skin-color-fullscreen");
    }
    /// <summary>
    /// Database Location
    /// </summary>
    public static string settings_db_location()
    {
        return GetString("settings-db-location");
    }
    /// <summary>
    /// Login status:
    /// </summary>
    public static string settings_login_status()
    {
        return GetString("settings-login-status");
    }
    /// <summary>
    /// Playnite Settings
    /// </summary>
    public static string settings_window_title()
    {
        return GetString("settings-window-title");
    }
    /// <summary>
    /// Clear web cache
    /// </summary>
    public static string settings_clear_web_cache()
    {
        return GetString("settings-clear-web-cache");
    }
    /// <summary>
    /// May solve issues encountered while linking accounts.
    /// </summary>
    public static string settings_clear_web_cache_tooltip()
    {
        return GetString("settings-clear-web-cache-tooltip");
    }
    /// <summary>
    /// Show system tray icon
    /// </summary>
    public static string settings_show_tray()
    {
        return GetString("settings-show-tray");
    }
    /// <summary>
    /// Minimize Playnite to system tray
    /// </summary>
    public static string settings_minimize_to_tray()
    {
        return GetString("settings-minimize-to-tray");
    }
    /// <summary>
    /// Minimize Playnite to system tray when the application window is closed
    /// </summary>
    public static string settings_close_to_tray()
    {
        return GetString("settings-close-to-tray");
    }
    /// <summary>
    /// When game starts:
    /// </summary>
    public static string settings_after_game_start()
    {
        return GetString("settings-after-game-start");
    }
    /// <summary>
    /// After game closes:
    /// </summary>
    public static string settings_after_game_close()
    {
        return GetString("settings-after-game-close");
    }
    /// <summary>
    /// Format time played to indicate the number of days played
    /// </summary>
    public static string settings_playtime_use_days_format_label()
    {
        return GetString("settings-playtime-use-days-format-label");
    }
    /// <summary>
    /// Dates formats:
    /// </summary>
    public static string settings_dates_formats_label()
    {
        return GetString("settings-dates-formats-label");
    }
    /// <summary>
    /// This will log you out of all linked services. Application restart is required, do you want to proceed?
    /// </summary>
    public static string settings_clear_cache_warn()
    {
        return GetString("settings-clear-cache-warn");
    }
    /// <summary>
    /// Clear Cache?
    /// </summary>
    public static string settings_clear_cache_title()
    {
        return GetString("settings-clear-cache-title");
    }
    /// <summary>
    /// Playnite restart is required to apply new theme
    /// </summary>
    public static string settings_skin_change_restart()
    {
        return GetString("settings-skin-change-restart");
    }
    /// <summary>
    /// Get more themes
    /// </summary>
    public static string settings_get_themes()
    {
        return GetString("settings-get-themes");
    }
    /// <summary>
    /// Create new theme
    /// </summary>
    public static string settings_create_themes()
    {
        return GetString("settings-create-themes");
    }
    /// <summary>
    /// Get more extensions
    /// </summary>
    public static string settings_get_extensions()
    {
        return GetString("settings-get-extensions");
    }
    /// <summary>
    /// Create new extension
    /// </summary>
    public static string settings_create_extensions()
    {
        return GetString("settings-create-extensions");
    }
    /// <summary>
    /// Help us translate Playnite
    /// </summary>
    public static string settings_create_localization()
    {
        return GetString("settings-create-localization");
    }
    /// <summary>
    /// Playnite needs to be restarted in order to apply new settings. Restart now?
    /// 
    /// Restarting will cancel any active tasks (downloads) currently in progress.
    /// </summary>
    public static string settings_restart_ask_message()
    {
        return GetString("settings-restart-ask-message");
    }
    /// <summary>
    /// Restart Playnite?
    /// </summary>
    public static string settings_restart_title()
    {
        return GetString("settings-restart-title");
    }
    /// <summary>
    /// Playnite cannot move your library files automatically. You must manually move/copy the files before changing the location. If there is no library in the target location, a new one will be created.
    /// 
    /// The new database location will not be used until Playnite is restarted.
    /// </summary>
    public static string settings_db_path_notification()
    {
        return GetString("settings-db-path-notification");
    }
    /// <summary>
    /// Play time will not be recorded if "Close" action is set.
    /// </summary>
    public static string settings_close_playtime_notif()
    {
        return GetString("settings-close-playtime-notif");
    }
    /// <summary>
    /// Number of rows
    /// </summary>
    public static string settings_fullscreen_rows()
    {
        return GetString("settings-fullscreen-rows");
    }
    /// <summary>
    /// Number of columns
    /// </summary>
    public static string settings_fullscreen_columns()
    {
        return GetString("settings-fullscreen-columns");
    }
    /// <summary>
    /// Number of detail view rows
    /// </summary>
    public static string settings_fullscreen_row_details()
    {
        return GetString("settings-fullscreen-row-details");
    }
    /// <summary>
    /// Show Background Image on Main Screen
    /// </summary>
    public static string settings_fullscreen_background_on_main_screen()
    {
        return GetString("settings-fullscreen-background-on-main-screen");
    }
    /// <summary>
    /// Doesn't apply retrospectively to existing games without re-downloading metadata.
    /// </summary>
    public static string background_image_screen_option_tooltip()
    {
        return GetString("background-image-screen-option-tooltip");
    }
    /// <summary>
    /// Import playtime of games in library:
    /// </summary>
    public static string settings_playtime_import_mode()
    {
        return GetString("settings-playtime-import-mode");
    }
    /// <summary>
    /// Configures when should Playnite import the playtime reported by library plugins for games in the Playnite database. Support by the library plugins in charge of handling the game(s) is needed to be able to use this feature.
    /// 
    /// Always: Imports playtime for new imported and existing games in Playnite database.
    /// Only for newly imported games: Imports playtime only for new imported games.
    /// Never: Never imports playtime under any circumstance.
    /// </summary>
    public static string settings_playtime_import_mode_tooltip()
    {
        return GetString("settings-playtime-import-mode-tooltip");
    }
    /// <summary>
    /// Always
    /// </summary>
    public static string settings_playtime_import_mode_always()
    {
        return GetString("settings-playtime-import-mode-always");
    }
    /// <summary>
    /// Only for newly imported games
    /// </summary>
    public static string settings_playtime_import_mode_new_imports_only()
    {
        return GetString("settings-playtime-import-mode-new-imports-only");
    }
    /// <summary>
    /// Never
    /// </summary>
    public static string settings_playtime_import_mode_never()
    {
        return GetString("settings-playtime-import-mode-never");
    }
    /// <summary>
    /// Enable controller support in Desktop Mode
    /// </summary>
    public static string settings_xinput_in_desktop_mode()
    {
        return GetString("settings-xinput-in-desktop-mode");
    }
    /// <summary>
    /// Guide button opens Fullscreen mode
    /// </summary>
    public static string settings_xinput_guide_opens_fullscreen()
    {
        return GetString("settings-xinput-guide-opens-fullscreen");
    }
    /// <summary>
    /// Automatic Metadata download settings for newly imported games.
    /// </summary>
    public static string settings_default_metadata_description()
    {
        return GetString("settings-default-metadata-description");
    }
    /// <summary>
    /// Target display
    /// </summary>
    public static string settings_target_display()
    {
        return GetString("settings-target-display");
    }
    /// <summary>
    /// Always use primary display
    /// </summary>
    public static string settings_always_use_primary_display()
    {
        return GetString("settings-always-use-primary-display");
    }
    /// <summary>
    /// Show Game Titles
    /// </summary>
    public static string settings_fullscreen_show_game_titles()
    {
        return GetString("settings-fullscreen-show-game-titles");
    }
    /// <summary>
    /// Show Battery Status
    /// </summary>
    public static string settings_show_battery_status()
    {
        return GetString("settings-show-battery-status");
    }
    /// <summary>
    /// Show Battery Percentage
    /// </summary>
    public static string settings_show_battery_percentage()
    {
        return GetString("settings-show-battery-percentage");
    }
    /// <summary>
    /// Show Clock
    /// </summary>
    public static string settings_show_clock()
    {
        return GetString("settings-show-clock");
    }
    /// <summary>
    /// Hide Mouse Cursor
    /// </summary>
    public static string settings_hide_mouse_cursor()
    {
        return GetString("settings-hide-mouse-cursor");
    }
    /// <summary>
    /// Installed Only in Quick Filters
    /// </summary>
    public static string settings_fullscreen_quick_filter_installed()
    {
        return GetString("settings-fullscreen-quick-filter-installed");
    }
    /// <summary>
    /// Button Prompts
    /// </summary>
    public static string settings_fullscreen_button_prompts()
    {
        return GetString("settings-fullscreen-button-prompts");
    }
    /// <summary>
    /// Layout
    /// </summary>
    public static string settings_fullscreen_layout()
    {
        return GetString("settings-fullscreen-layout");
    }
    /// <summary>
    /// Horizontal Scrolling
    /// </summary>
    public static string settings_fullscreen_horizontal_scrolling()
    {
        return GetString("settings-fullscreen-horizontal-scrolling");
    }
    /// <summary>
    /// Select one of the subsections
    /// </summary>
    public static string settings_select_child_section()
    {
        return GetString("settings-select-child-section");
    }
    /// <summary>
    /// No settings available
    /// </summary>
    public static string settings_no_settings_available()
    {
        return GetString("settings-no-settings-available");
    }
    /// <summary>
    /// Failed to load settings
    /// </summary>
    public static string settings_error_loading_settings()
    {
        return GetString("settings-error-loading-settings");
    }
    /// <summary>
    /// These scripts are executed for every game in the library. Individual scripts can be assigned to each game separately while editing game details.
    /// </summary>
    public static string settings_scripting_notice()
    {
        return GetString("settings-scripting-notice");
    }
    /// <summary>
    /// Animate background image transitions
    /// </summary>
    public static string settings_background_image_animation()
    {
        return GetString("settings-background-image-animation");
    }
    /// <summary>
    /// Font sizes
    /// </summary>
    public static string settings_font_sizes()
    {
        return GetString("settings-font-sizes");
    }
    /// <summary>
    /// Auto
    /// </summary>
    public static string settings_text_rendering_mode_option_auto()
    {
        return GetString("settings-text-rendering-mode-option-auto");
    }
    /// <summary>
    /// Aliased
    /// </summary>
    public static string settings_text_rendering_mode_option_aliased()
    {
        return GetString("settings-text-rendering-mode-option-aliased");
    }
    /// <summary>
    /// Grayscale
    /// </summary>
    public static string settings_text_rendering_mode_option_grayscale()
    {
        return GetString("settings-text-rendering-mode-option-grayscale");
    }
    /// <summary>
    /// ClearType
    /// </summary>
    public static string settings_text_rendering_mode_option_clear_type()
    {
        return GetString("settings-text-rendering-mode-option-clear-type");
    }
    /// <summary>
    /// Ideal
    /// </summary>
    public static string settings_text_formatting_mode_option_ideal()
    {
        return GetString("settings-text-formatting-mode-option-ideal");
    }
    /// <summary>
    /// Display
    /// </summary>
    public static string settings_text_formatting_mode_option_display()
    {
        return GetString("settings-text-formatting-mode-option-display");
    }
    /// <summary>
    /// Text formatting mode
    /// </summary>
    public static string settings_text_formatting_mode()
    {
        return GetString("settings-text-formatting-mode");
    }
    /// <summary>
    /// Text rendering mode
    /// </summary>
    public static string settings_text_rendering_mode()
    {
        return GetString("settings-text-rendering-mode");
    }
    /// <summary>
    /// Text rendering and formatting methods are currently not used for game descriptions.
    /// </summary>
    public static string settings_text_rendering_notice()
    {
        return GetString("settings-text-rendering-notice");
    }
    /// <summary>
    /// Preload background images
    /// </summary>
    public static string settings_immediate_background_download()
    {
        return GetString("settings-immediate-background-download");
    }
    /// <summary>
    /// If enabled, Playnite will download background artwork while downloading metadata, using more disk space and making artwork available when offline.
    /// 
    /// If disabled, background artwork is downloaded only when first needed, using less space, but may result in a delay before artwork is displayed and some images might not be available when offline.
    /// </summary>
    public static string settings_immediate_background_download_tooltip()
    {
        return GetString("settings-immediate-background-download-tooltip");
    }
    /// <summary>
    /// Automatically close third party client after game exits
    /// </summary>
    public static string settings_auto_close_launcher_option()
    {
        return GetString("settings-auto-close-launcher-option");
    }
    /// <summary>
    /// Client shutdown delay (in seconds)
    /// </summary>
    public static string settings_auto_close_grace_period()
    {
        return GetString("settings-auto-close-grace-period");
    }
    /// <summary>
    /// Don't close after game sessions shorter than (in seconds)
    /// </summary>
    public static string settings_auto_close_minimal_session_time()
    {
        return GetString("settings-auto-close-minimal-session-time");
    }
    /// <summary>
    /// Automatically close following clients:
    /// </summary>
    public static string settings_auto_close_specific_clients()
    {
        return GetString("settings-auto-close-specific-clients");
    }
    /// <summary>
    /// Auto Close Clients
    /// </summary>
    public static string settings_auto_close_section()
    {
        return GetString("settings-auto-close-section");
    }
    /// <summary>
    /// Import Exclusion List
    /// </summary>
    public static string settings_import_exclusion_list()
    {
        return GetString("settings-import-exclusion-list");
    }
    /// <summary>
    /// Display warning when assigning too large game media
    /// </summary>
    public static string settings_show_media_size_warning()
    {
        return GetString("settings-show-media-size-warning");
    }
    /// <summary>
    /// Folder open command
    /// </summary>
    public static string open_directory_command()
    {
        return GetString("open-directory-command");
    }
    /// <summary>
    /// Preferred age rating organization
    /// </summary>
    public static string settings_preferred_age_rating_org()
    {
        return GetString("settings-preferred-age-rating-org");
    }
    /// <summary>
    /// Update install size of games on library update
    /// </summary>
    public static string settings_scan_lib_install_size_on_lib_update()
    {
        return GetString("settings-scan-lib-install-size-on-lib-update");
    }
    /// <summary>
    /// Scans and updates the install size of games if it is detected that their files have been modified since the last scan
    /// </summary>
    public static string settings_scan_lib_install_size_on_lib_update_tooltip()
    {
        return GetString("settings-scan-lib-install-size-on-lib-update-tooltip");
    }
    /// <summary>
    /// None
    /// </summary>
    public static string stretch_none()
    {
        return GetString("stretch-none");
    }
    /// <summary>
    /// Fill
    /// </summary>
    public static string stretch_fill()
    {
        return GetString("stretch-fill");
    }
    /// <summary>
    /// Uniform
    /// </summary>
    public static string stretch_uniform()
    {
        return GetString("stretch-uniform");
    }
    /// <summary>
    /// Uniform to fill
    /// </summary>
    public static string stretch_uniform_to_fill()
    {
        return GetString("stretch-uniform-to-fill");
    }
    /// <summary>
    /// Left
    /// </summary>
    public static string dock_left()
    {
        return GetString("dock-left");
    }
    /// <summary>
    /// Right
    /// </summary>
    public static string dock_right()
    {
        return GetString("dock-right");
    }
    /// <summary>
    /// Top
    /// </summary>
    public static string dock_top()
    {
        return GetString("dock-top");
    }
    /// <summary>
    /// Bottom
    /// </summary>
    public static string dock_bottom()
    {
        return GetString("dock-bottom");
    }
    /// <summary>
    /// Import Error
    /// </summary>
    public static string import_error()
    {
        return GetString("import-error");
    }
    /// <summary>
    /// Authentication required
    /// </summary>
    public static string login_required()
    {
        return GetString("login-required");
    }
    /// <summary>
    /// Authentication failed
    /// </summary>
    public static string login_failed()
    {
        return GetString("login-failed");
    }
    /// <summary>
    /// Alternative web view rendering mode
    /// </summary>
    public static string settings_alt_web_view_rendering()
    {
        return GetString("settings-alt-web-view-rendering");
    }
    /// <summary>
    /// Use when experiencing issues with web views, for example integration authentication dialogs.
    /// </summary>
    public static string settings_alt_web_view_rendering_tooltip()
    {
        return GetString("settings-alt-web-view-rendering-tooltip");
    }
    /// <summary>
    /// Partial loading of large game descriptions
    /// </summary>
    public static string settings_partial_description_loading()
    {
        return GetString("settings-partial-description-loading");
    }
    /// <summary>
    /// Large descriptions can cause noticeable lag when selecting games.
    /// 
    /// When enabled, only part of description text will be initially loaded with an option to load the rest on demand.
    /// </summary>
    public static string settings_partial_description_loading_tooltip()
    {
        return GetString("settings-partial-description-loading-tooltip");
    }
    /// <summary>
    /// Metadata Import
    /// </summary>
    public static string meta_import_window_title()
    {
        return GetString("meta-import-window-title");
    }
    /// <summary>
    /// Download Metadata
    /// </summary>
    public static string download_meta_button()
    {
        return GetString("download-meta-button");
    }
    /// <summary>
    /// Set selected configuration to be used for any future metadata downloads.
    /// Can also be changed in application settings.
    /// </summary>
    public static string save_default_tooltip()
    {
        return GetString("save-default-tooltip");
    }
    /// <summary>
    /// Emulation Import Wizard
    /// </summary>
    public static string emu_wizard_window_title()
    {
        return GetString("emu-wizard-window-title");
    }
    /// <summary>
    /// This wizard will guide you through the process of downloading and importing console emulators and importing emulated games.
    /// </summary>
    public static string emu_wizard_intro()
    {
        return GetString("emu-wizard-intro");
    }
    /// <summary>
    /// Keep in mind that you can always add additional emulators and/or games later via main menu (under "Library" menu for Emulator settings and "Add Games" menu for emulated games).
    /// </summary>
    public static string emu_wizard_notice()
    {
        return GetString("emu-wizard-notice");
    }
    /// <summary>
    /// Below is a list of emulators that Playnite can recognize and configure automatically. You can download emulator installers from their websites. Once you have the emulators installed (manually), you can import them on emulator configuration dialog.
    /// </summary>
    public static string emu_download_description()
    {
        return GetString("emu-download-description");
    }
    /// <summary>
    /// You can import any emulators that are installed on your PC by clicking the 'Autodetect From Folder…' button. Playnite will search the selected folder for any known emulators and provide the option to import them. You can use this button multiple times to import emulators from different folders. Emulators will be added to the bottom of the current list.
    /// </summary>
    public static string emu_wizard_emu_import_intro()
    {
        return GetString("emu-wizard-emu-import-intro");
    }
    /// <summary>
    /// You can import games by clicking the 'Scan Folder Using Emulator' button. Selecting the appropriate emulator will tell Playnite which file types should be scanned and imported. You can use this button multiple times to import games from different folders. Games will be added to the bottom of the current list.
    /// </summary>
    public static string emu_wizard_game_import_intro()
    {
        return GetString("emu-wizard-game-import-intro");
    }
    /// <summary>
    /// There are no emulators selected for import. You won't be able to automatically import any emulated games without configuring emulators first. Are you sure you want to continue and exit import process?
    /// </summary>
    public static string emu_wizard_no_emulator_warning()
    {
        return GetString("emu-wizard-no-emulator-warning");
    }
    /// <summary>
    /// There are no emulators configured in Playnite. You cannot import games without first configuring the emulator and selecting the appropriate file types. Do you want to add some emulators now?
    /// </summary>
    public static string emu_wizard_no_emulator_for_games_warning()
    {
        return GetString("emu-wizard-no-emulator-for-games-warning");
    }
    /// <summary>
    /// Scan folder using Emulator
    /// </summary>
    public static string emu_wizard_button_scan_games()
    {
        return GetString("emu-wizard-button-scan-games");
    }
    /// <summary>
    /// Select files
    /// </summary>
    public static string emu_wizard_button_select_files()
    {
        return GetString("emu-wizard-button-select-files");
    }
    /// <summary>
    /// Autodetect From Folder…
    /// </summary>
    public static string emu_wizard_button_scan_emulator()
    {
        return GetString("emu-wizard-button-scan-emulator");
    }
    /// <summary>
    /// Configure Emulators…
    /// </summary>
    public static string emu_wizard_button_configure_emulator()
    {
        return GetString("emu-wizard-button-configure-emulator");
    }
    /// <summary>
    /// Scanning…
    /// </summary>
    public static string emu_wizard_scanning()
    {
        return GetString("emu-wizard-scanning");
    }
    /// <summary>
    /// Scanning {$path}…
    /// </summary>
    public static string emu_wizard_scanning_specific(object path)
    {
        return GetString("emu-wizard-scanning-specific", ("path", path));
    }
    /// <summary>
    /// First Time Configuration
    /// </summary>
    public static string first_window_title()
    {
        return GetString("first-window-title");
    }
    /// <summary>
    /// This process will guide you through an automatic import and configuration of external game libraries. Playnite can automatically import games from multiple game services, such as Steam or GOG.
    /// 
    /// Keep in mind that you can also manually add any custom or emulated game for any platform later from main menu.
    /// </summary>
    public static string first_intro()
    {
        return GetString("first-intro");
    }
    /// <summary>
    /// Library Integration
    /// </summary>
    public static string first_external_title()
    {
        return GetString("first-external-title");
    }
    /// <summary>
    /// Following is the list of some curated library integrations Playnite supports. Please select ones you want to install.
    /// 
    /// More integrations can be installed later from "Add-ons" menu.
    /// </summary>
    public static string first_import_introduction()
    {
        return GetString("first-import-introduction");
    }
    /// <summary>
    /// Configuration Finished
    /// </summary>
    public static string first_config_finished_title()
    {
        return GetString("first-config-finished-title");
    }
    /// <summary>
    /// The initial setup has been completed. Remember that you can change all settings later as well as add additional integrations from main menu.
    /// </summary>
    public static string first_config_finished_text()
    {
        return GetString("first-config-finished-text");
    }
    /// <summary>
    /// Failed to download one or more extensions.
    /// 
    /// You can try to re-download integrations from add-ons menu after first run wizard finishes.
    /// </summary>
    public static string first_plugin_download_error()
    {
        return GetString("first-plugin-download-error");
    }
    /// <summary>
    /// Downloading {$integrationName} integration…
    /// </summary>
    public static string first_downloading_addon(object integrationName)
    {
        return GetString("first-downloading-addon", ("integrationName", integrationName));
    }
    /// <summary>
    /// Downloading list of recommended integrations…
    /// </summary>
    public static string default_addon_list_download()
    {
        return GetString("default-addon-list-download");
    }
    /// <summary>
    /// Failed to download list of recommended integrations. You can try and re-download integrations later via the Addons menu.
    /// </summary>
    public static string default_addon_list_download_error()
    {
        return GetString("default-addon-list-download-error");
    }
    /// <summary>
    /// Configure Platforms and Emulators
    /// </summary>
    public static string platforms_window_title()
    {
        return GetString("platforms-window-title");
    }
    /// <summary>
    /// Configure Emulators
    /// </summary>
    public static string emulators_window_title()
    {
        return GetString("emulators-window-title");
    }
    /// <summary>
    /// Platforms
    /// </summary>
    public static string platforms_title()
    {
        return GetString("platforms-title");
    }
    /// <summary>
    /// Platform
    /// </summary>
    public static string platform_title()
    {
        return GetString("platform-title");
    }
    /// <summary>
    /// Emulators
    /// </summary>
    public static string emulators_title()
    {
        return GetString("emulators-title");
    }
    /// <summary>
    /// Emulator
    /// </summary>
    public static string emulator_title()
    {
        return GetString("emulator-title");
    }
    /// <summary>
    /// Add Platform
    /// </summary>
    public static string add_platform_title()
    {
        return GetString("add-platform-title");
    }
    /// <summary>
    /// Select Icon
    /// </summary>
    public static string select_icon_title()
    {
        return GetString("select-icon-title");
    }
    /// <summary>
    /// Select Cover
    /// </summary>
    public static string select_cover_title()
    {
        return GetString("select-cover-title");
    }
    /// <summary>
    /// Select Image
    /// </summary>
    public static string select_image_title()
    {
        return GetString("select-image-title");
    }
    /// <summary>
    /// Select Item
    /// </summary>
    public static string select_item_title()
    {
        return GetString("select-item-title");
    }
    /// <summary>
    /// Select Background
    /// </summary>
    public static string select_background_title()
    {
        return GetString("select-background-title");
    }
    /// <summary>
    /// Select File
    /// </summary>
    public static string select_file_title()
    {
        return GetString("select-file-title");
    }
    /// <summary>
    /// Select URL
    /// </summary>
    public static string select_url_title()
    {
        return GetString("select-url-title");
    }
    /// <summary>
    /// Add Emulator
    /// </summary>
    public static string add_emulator_title()
    {
        return GetString("add-emulator-title");
    }
    /// <summary>
    /// Supported Platform(s)
    /// </summary>
    public static string supported_platforms_title()
    {
        return GetString("supported-platforms-title");
    }
    /// <summary>
    /// Do you want to save platform changes?
    /// </summary>
    public static string confirm_unsaved_platforms_title()
    {
        return GetString("confirm-unsaved-platforms-title");
    }
    /// <summary>
    /// Do you want to save emulator changes?
    /// </summary>
    public static string confirm_unsaved_emulators_title()
    {
        return GetString("confirm-unsaved-emulators-title");
    }
    /// <summary>
    /// Executable
    /// </summary>
    public static string executable_title()
    {
        return GetString("executable-title");
    }
    /// <summary>
    /// Arguments
    /// </summary>
    public static string arguments_title()
    {
        return GetString("arguments-title");
    }
    /// <summary>
    /// Working Directory
    /// </summary>
    public static string working_dir_title()
    {
        return GetString("working-dir-title");
    }
    /// <summary>
    /// Supported File Types
    /// </summary>
    public static string supported_files_title()
    {
        return GetString("supported-files-title");
    }
    /// <summary>
    /// Import Emulators…
    /// </summary>
    public static string import_emulators_button()
    {
        return GetString("import-emulators-button");
    }
    /// <summary>
    /// Download Emulators…
    /// </summary>
    public static string download_emulators_button()
    {
        return GetString("download-emulators-button");
    }
    /// <summary>
    /// Load arguments preset from known emulator profile
    /// </summary>
    public static string emu_load_args_preset_tooltip()
    {
        return GetString("emu-load-args-preset-tooltip");
    }
    /// <summary>
    /// Are you sure you want to remove {$emulatorName} emulator?
    /// It's currently being used by {$gameCount} game(s).
    /// </summary>
    public static string emu_removal_confirmation(object emulatorName, object gameCount)
    {
        return GetString("emu-removal-confirmation", ("emulatorName", emulatorName), ("gameCount", gameCount));
    }
    /// <summary>
    /// Are you sure you want to remove {$platformName} platform?
    /// It's currently being used by {$gamesCount} game(s) and {$emulatorsCount} emulator(s).
    /// </summary>
    public static string platform_removal_confirmation(object platformName, object gamesCount, object emulatorsCount)
    {
        return GetString("platform-removal-confirmation", ("platformName", platformName), ("gamesCount", gamesCount), ("emulatorsCount", emulatorsCount));
    }
    /// <summary>
    /// Settings help
    /// </summary>
    public static string emulator_settings_help()
    {
        return GetString("emulator-settings-help");
    }
    /// <summary>
    /// Sort By
    /// </summary>
    public static string menu_sort_by_title()
    {
        return GetString("menu-sort-by-title");
    }
    /// <summary>
    /// Sort Direction
    /// </summary>
    public static string menu_sort_by_direction()
    {
        return GetString("menu-sort-by-direction");
    }
    /// <summary>
    /// Group By
    /// </summary>
    public static string menu_group_by_title()
    {
        return GetString("menu-group-by-title");
    }
    /// <summary>
    /// Ascending
    /// </summary>
    public static string menu_sort_ascending()
    {
        return GetString("menu-sort-ascending");
    }
    /// <summary>
    /// Descending
    /// </summary>
    public static string menu_sort_descending()
    {
        return GetString("menu-sort-descending");
    }
    /// <summary>
    /// Don't group
    /// </summary>
    public static string menu_group_no_group()
    {
        return GetString("menu-group-no-group");
    }
    /// <summary>
    /// Group by Library
    /// </summary>
    public static string menu_group_provider()
    {
        return GetString("menu-group-provider");
    }
    /// <summary>
    /// Group by Category
    /// </summary>
    public static string menu_group_category()
    {
        return GetString("menu-group-category");
    }
    /// <summary>
    /// Group by Platform
    /// </summary>
    public static string menu_group_platform()
    {
        return GetString("menu-group-platform");
    }
    /// <summary>
    /// View Type
    /// </summary>
    public static string view_type()
    {
        return GetString("view-type");
    }
    /// <summary>
    /// View
    /// </summary>
    public static string menu_view()
    {
        return GetString("menu-view");
    }
    /// <summary>
    /// Explorer Panel
    /// </summary>
    public static string menu_view_explorer_panel()
    {
        return GetString("menu-view-explorer-panel");
    }
    /// <summary>
    /// Filter Panel
    /// </summary>
    public static string menu_view_filter_panel()
    {
        return GetString("menu-view-filter-panel");
    }
    /// <summary>
    /// Icon
    /// </summary>
    public static string game_icon_title()
    {
        return GetString("game-icon-title");
    }
    /// <summary>
    /// Library Icon
    /// </summary>
    public static string library_icon_title()
    {
        return GetString("library-icon-title");
    }
    /// <summary>
    /// Cover Image
    /// </summary>
    public static string game_cover_image_title()
    {
        return GetString("game-cover-image-title");
    }
    /// <summary>
    /// Background Image
    /// </summary>
    public static string game_background_title()
    {
        return GetString("game-background-title");
    }
    /// <summary>
    /// Sorting Name
    /// </summary>
    public static string game_sorting_name_title()
    {
        return GetString("game-sorting-name-title");
    }
    /// <summary>
    /// Library
    /// </summary>
    public static string game_provider_title()
    {
        return GetString("game-provider-title");
    }
    /// <summary>
    /// Manual
    /// </summary>
    public static string game_manual_title()
    {
        return GetString("game-manual-title");
    }
    /// <summary>
    /// Name
    /// </summary>
    public static string game_name_title()
    {
        return GetString("game-name-title");
    }
    /// <summary>
    /// Install Drive
    /// </summary>
    public static string install_drive_title()
    {
        return GetString("install-drive-title");
    }
    /// <summary>
    /// Account Name
    /// </summary>
    public static string game_account_name_title()
    {
        return GetString("game-account-name-title");
    }
    /// <summary>
    /// Platform
    /// </summary>
    public static string game_platform_title()
    {
        return GetString("game-platform-title");
    }
    /// <summary>
    /// Category
    /// </summary>
    public static string game_categories_title()
    {
        return GetString("game-categories-title");
    }
    /// <summary>
    /// Genre
    /// </summary>
    public static string game_genres_title()
    {
        return GetString("game-genres-title");
    }
    /// <summary>
    /// Release Date
    /// </summary>
    public static string game_release_date_title()
    {
        return GetString("game-release-date-title");
    }
    /// <summary>
    /// Release Year
    /// </summary>
    public static string game_release_year_title()
    {
        return GetString("game-release-year-title");
    }
    /// <summary>
    /// Developer
    /// </summary>
    public static string game_developers_title()
    {
        return GetString("game-developers-title");
    }
    /// <summary>
    /// Tag
    /// </summary>
    public static string game_tags_title()
    {
        return GetString("game-tags-title");
    }
    /// <summary>
    /// Publisher
    /// </summary>
    public static string game_publishers_title()
    {
        return GetString("game-publishers-title");
    }
    /// <summary>
    /// Installation Status
    /// </summary>
    public static string game_installation_status()
    {
        return GetString("game-installation-status");
    }
    /// <summary>
    /// Match all filters
    /// </summary>
    public static string use_filter_style_and_title()
    {
        return GetString("use-filter-style-and-title");
    }
    /// <summary>
    /// If enabled, only games that use all the items in all the filters will be included in the view.
    /// If disabled, games that use any item in any filter will be included in the view.
    /// </summary>
    public static string use_filter_style_and_tooltip()
    {
        return GetString("use-filter-style-and-tooltip");
    }
    /// <summary>
    /// Installed
    /// </summary>
    public static string game_is_installed_title()
    {
        return GetString("game-is-installed-title");
    }
    /// <summary>
    /// Installed
    /// </summary>
    public static string game_is_game_installed_title()
    {
        return GetString("game-is-game-installed-title");
    }
    /// <summary>
    /// Not installed
    /// </summary>
    public static string game_is_un_installed_title()
    {
        return GetString("game-is-un-installed-title");
    }
    /// <summary>
    /// Hidden
    /// </summary>
    public static string game_hidden_title()
    {
        return GetString("game-hidden-title");
    }
    /// <summary>
    /// Favorite
    /// </summary>
    public static string game_favorite_title()
    {
        return GetString("game-favorite-title");
    }
    /// <summary>
    /// Enable HDR Support
    /// </summary>
    public static string game_hdr_title()
    {
        return GetString("game-hdr-title");
    }
    /// <summary>
    /// If enabled, HDR will be enabled on the primary display before starting the game.
    /// </summary>
    public static string game_hdr_tooltip()
    {
        return GetString("game-hdr-tooltip");
    }
    /// <summary>
    /// Note that HDR is not supported on your primary display.
    /// </summary>
    public static string game_hdr_not_supported_tooltip()
    {
        return GetString("game-hdr-not-supported-tooltip");
    }
    /// <summary>
    /// Last Played
    /// </summary>
    public static string game_last_activity_title()
    {
        return GetString("game-last-activity-title");
    }
    /// <summary>
    /// Category
    /// </summary>
    public static string game_category_title()
    {
        return GetString("game-category-title");
    }
    /// <summary>
    /// Description
    /// </summary>
    public static string game_description_title()
    {
        return GetString("game-description-title");
    }
    /// <summary>
    /// Installation Folder
    /// </summary>
    public static string game_install_dir_title()
    {
        return GetString("game-install-dir-title");
    }
    /// <summary>
    /// Cover Image
    /// </summary>
    public static string game_cover_title()
    {
        return GetString("game-cover-title");
    }
    /// <summary>
    /// Links
    /// </summary>
    public static string game_links_title()
    {
        return GetString("game-links-title");
    }
    /// <summary>
    /// Image, ROM or ISO Path
    /// </summary>
    public static string game_rom_title()
    {
        return GetString("game-rom-title");
    }
    /// <summary>
    /// Genre
    /// </summary>
    public static string genre_label()
    {
        return GetString("genre-label");
    }
    /// <summary>
    /// Genres
    /// </summary>
    public static string genres_label()
    {
        return GetString("genres-label");
    }
    /// <summary>
    /// Company
    /// </summary>
    public static string company_label()
    {
        return GetString("company-label");
    }
    /// <summary>
    /// Companies
    /// </summary>
    public static string companies_label()
    {
        return GetString("companies-label");
    }
    /// <summary>
    /// Developer
    /// </summary>
    public static string developer_label()
    {
        return GetString("developer-label");
    }
    /// <summary>
    /// Developers
    /// </summary>
    public static string developers_label()
    {
        return GetString("developers-label");
    }
    /// <summary>
    /// Publisher
    /// </summary>
    public static string publisher_label()
    {
        return GetString("publisher-label");
    }
    /// <summary>
    /// Publishers
    /// </summary>
    public static string publishers_label()
    {
        return GetString("publishers-label");
    }
    /// <summary>
    /// Category
    /// </summary>
    public static string category_label()
    {
        return GetString("category-label");
    }
    /// <summary>
    /// Categories
    /// </summary>
    public static string categories_label()
    {
        return GetString("categories-label");
    }
    /// <summary>
    /// Tag
    /// </summary>
    public static string tag_label()
    {
        return GetString("tag-label");
    }
    /// <summary>
    /// Tags
    /// </summary>
    public static string tags_label()
    {
        return GetString("tags-label");
    }
    /// <summary>
    /// Feature
    /// </summary>
    public static string feature_label()
    {
        return GetString("feature-label");
    }
    /// <summary>
    /// Features
    /// </summary>
    public static string features_label()
    {
        return GetString("features-label");
    }
    /// <summary>
    /// Age Rating
    /// </summary>
    public static string age_rating_label()
    {
        return GetString("age-rating-label");
    }
    /// <summary>
    /// Age Ratings
    /// </summary>
    public static string age_ratings_label()
    {
        return GetString("age-ratings-label");
    }
    /// <summary>
    /// Region
    /// </summary>
    public static string region_label()
    {
        return GetString("region-label");
    }
    /// <summary>
    /// Regions
    /// </summary>
    public static string regions_label()
    {
        return GetString("regions-label");
    }
    /// <summary>
    /// Source
    /// </summary>
    public static string source_label()
    {
        return GetString("source-label");
    }
    /// <summary>
    /// Sources
    /// </summary>
    public static string sources_label()
    {
        return GetString("sources-label");
    }
    /// <summary>
    /// Recent Activity
    /// </summary>
    public static string recent_activity_label()
    {
        return GetString("recent-activity-label");
    }
    /// <summary>
    /// Database Error
    /// </summary>
    public static string database_error_title()
    {
        return GetString("database-error-title");
    }
    /// <summary>
    /// Failed to open library database.
    /// </summary>
    public static string database_open_error()
    {
        return GetString("database-open-error");
    }
    /// <summary>
    /// Database is not opened.
    /// </summary>
    public static string database_not_opened_error()
    {
        return GetString("database-not-opened-error");
    }
    /// <summary>
    /// Cannot access library database. File "{$path}" is being used by another process or it's in inaccessible location.
    /// </summary>
    public static string database_open_access_error(object path)
    {
        return GetString("database-open-access-error", ("path", path));
    }
    /// <summary>
    /// Failed to create diagnostics package.
    /// </summary>
    public static string diag_package_creation_error()
    {
        return GetString("diag-package-creation-error");
    }
    /// <summary>
    /// Failed to automatically upload diagnostics package.
    /// </summary>
    public static string diag_package_upload_error()
    {
        return GetString("diag-package-upload-error");
    }
    /// <summary>
    /// Diagnostics information was sent successfully.
    /// </summary>
    public static string diag_package_sent_success()
    {
        return GetString("diag-package-sent-success");
    }
    /// <summary>
    /// The diagnostics package has been created and submitted successfully.
    /// Please attach the following ID to your issue report:
    /// </summary>
    public static string diag_package_creation_success()
    {
        return GetString("diag-package-creation-success");
    }
    /// <summary>
    /// Failed to import games from {$libraryName}.
    /// </summary>
    public static string library_import_error(object libraryName)
    {
        return GetString("library-import-error", ("libraryName", libraryName));
    }
    /// <summary>
    /// Failed to import emulated games from {$scannerName}.
    /// </summary>
    public static string library_import_emulated_error(object scannerName)
    {
        return GetString("library-import-emulated-error", ("scannerName", scannerName));
    }
    /// <summary>
    /// Cannot search for games by selected emulator profile. Profile doesn't contain any file extensions or platforms.
    /// </summary>
    public static string scan_emulator_games_empty_profile_error()
    {
        return GetString("scan-emulator-games-empty-profile-error");
    }
    /// <summary>
    /// Playnite failed to start. Please close all other instances and try again.
    /// </summary>
    public static string start_generic_error()
    {
        return GetString("start-generic-error");
    }
    /// <summary>
    /// Cannot open link, URL is not in valid format.
    /// </summary>
    public static string url_format_error()
    {
        return GetString("url-format-error");
    }
    /// <summary>
    /// Failed to start the application.
    /// </summary>
    public static string app_startup_error()
    {
        return GetString("app-startup-error");
    }
    /// <summary>
    /// Failed to initialize web view component. Playnite cannot continue with startup process.
    /// 
    /// More information at https://playnite.link/cefstartup
    /// </summary>
    public static string cef_sharp_init_error()
    {
        return GetString("cef-sharp-init-error");
    }
    /// <summary>
    /// Cannot import emulators due to missing or corrupted definition file.
    /// </summary>
    public static string emulator_import_no_definitions_error()
    {
        return GetString("emulator-import-no-definitions-error");
    }
    /// <summary>
    /// Failed to initialize XInput interface.
    /// </summary>
    public static string xinput_init_error_message()
    {
        return GetString("xinput-init-error-message");
    }
    /// <summary>
    /// Failed to execute menu action.
    /// </summary>
    public static string menu_action_exec_error()
    {
        return GetString("menu-action-exec-error");
    }
    /// <summary>
    /// Edit Game Details
    /// </summary>
    public static string game_edit_window_title()
    {
        return GetString("game-edit-window-title");
    }
    /// <summary>
    /// From Play action
    /// </summary>
    public static string use_exe_icon()
    {
        return GetString("use-exe-icon");
    }
    /// <summary>
    /// Image URL
    /// </summary>
    public static string image_url()
    {
        return GetString("image-url");
    }
    /// <summary>
    /// Add Link
    /// </summary>
    public static string add_link_button()
    {
        return GetString("add-link-button");
    }
    /// <summary>
    /// Add ROM
    /// </summary>
    public static string add_rom()
    {
        return GetString("add-rom");
    }
    /// <summary>
    /// Save Changes
    /// </summary>
    public static string save_changes()
    {
        return GetString("save-changes");
    }
    /// <summary>
    /// Apply field changes to game(s) being edited.
    /// </summary>
    public static string game_edit_change_save_tooltip()
    {
        return GetString("game-edit-change-save-tooltip");
    }
    /// <summary>
    /// Add Action
    /// </summary>
    public static string add_action()
    {
        return GetString("add-action");
    }
    /// <summary>
    /// Remove
    /// </summary>
    public static string delete_action()
    {
        return GetString("delete-action");
    }
    /// <summary>
    /// Remove Play Action
    /// </summary>
    public static string remove_play_action()
    {
        return GetString("remove-play-action");
    }
    /// <summary>
    /// Add Games
    /// </summary>
    public static string add_games()
    {
        return GetString("add-games");
    }
    /// <summary>
    /// Scan Folder…
    /// </summary>
    public static string scan_folder()
    {
        return GetString("scan-folder");
    }
    /// <summary>
    /// Detect Installed
    /// </summary>
    public static string detect_installed()
    {
        return GetString("detect-installed");
    }
    /// <summary>
    /// Browse…
    /// </summary>
    public static string browse()
    {
        return GetString("browse");
    }
    /// <summary>
    /// Open Playnite
    /// </summary>
    public static string open_playnite()
    {
        return GetString("open-playnite");
    }
    /// <summary>
    /// Profile Settings
    /// </summary>
    public static string profile_settings()
    {
        return GetString("profile-settings");
    }
    /// <summary>
    /// Game name cannot be empty.
    /// </summary>
    public static string empty_game_name_error()
    {
        return GetString("empty-game-name-error");
    }
    /// <summary>
    /// Game action tracking directory cannot be empty.
    /// </summary>
    public static string empty_tracking_folder_error()
    {
        return GetString("empty-tracking-folder-error");
    }
    /// <summary>
    /// Game name cannot be empty before searching metadata.
    /// </summary>
    public static string empty_game_name_meta_search_error()
    {
        return GetString("empty-game-name-meta-search-error");
    }
    /// <summary>
    /// Invalid game data
    /// </summary>
    public static string invalid_game_data()
    {
        return GetString("invalid-game-data");
    }
    /// <summary>
    /// Enter valid web URL starting with http:// or https://
    /// </summary>
    public static string url_input_info()
    {
        return GetString("url-input-info");
    }
    /// <summary>
    /// Select URL
    /// </summary>
    public static string url_input_info_title()
    {
        return GetString("url-input-info-title");
    }
    /// <summary>
    /// Failed to download metadata.
    /// </summary>
    public static string metadata_download_error()
    {
        return GetString("metadata-download-error");
    }
    /// <summary>
    /// Download Error
    /// </summary>
    public static string download_error()
    {
        return GetString("download-error");
    }
    /// <summary>
    /// Clear Filters
    /// </summary>
    public static string clear_filters()
    {
        return GetString("clear-filters");
    }
    /// <summary>
    /// Private Account
    /// </summary>
    public static string private_account()
    {
        return GetString("private-account");
    }
    /// <summary>
    /// Public Account
    /// </summary>
    public static string public_account()
    {
        return GetString("public-account");
    }
    /// <summary>
    /// API Key
    /// </summary>
    public static string api_key()
    {
        return GetString("api-key");
    }
    /// <summary>
    /// Startup Error
    /// </summary>
    public static string startup_error()
    {
        return GetString("startup-error");
    }
    /// <summary>
    /// Theme Error
    /// </summary>
    public static string skin_error()
    {
        return GetString("skin-error");
    }
    /// <summary>
    /// Clear All
    /// </summary>
    public static string clear_all()
    {
        return GetString("clear-all");
    }
    /// <summary>
    /// Installing
    /// </summary>
    public static string setup_running()
    {
        return GetString("setup-running");
    }
    /// <summary>
    /// Uninstalling
    /// </summary>
    public static string uninstalling()
    {
        return GetString("uninstalling");
    }
    /// <summary>
    /// Launching
    /// </summary>
    public static string game_launching()
    {
        return GetString("game-launching");
    }
    /// <summary>
    /// Running
    /// </summary>
    public static string game_running()
    {
        return GetString("game-running");
    }
    /// <summary>
    /// Invalid URL
    /// </summary>
    public static string invalid_url()
    {
        return GetString("invalid-url");
    }
    /// <summary>
    /// Do nothing
    /// </summary>
    public static string do_nothing()
    {
        return GetString("do-nothing");
    }
    /// <summary>
    /// Minimize
    /// </summary>
    public static string minimize()
    {
        return GetString("minimize");
    }
    /// <summary>
    /// Restore window
    /// </summary>
    public static string restore_window()
    {
        return GetString("restore-window");
    }
    /// <summary>
    /// Close
    /// </summary>
    public static string close()
    {
        return GetString("close");
    }
    /// <summary>
    /// Change
    /// </summary>
    public static string change()
    {
        return GetString("change");
    }
    /// <summary>
    /// Advanced
    /// </summary>
    public static string advanced()
    {
        return GetString("advanced");
    }
    /// <summary>
    /// Never
    /// </summary>
    public static string never()
    {
        return GetString("never");
    }
    /// <summary>
    /// Completion Status
    /// </summary>
    public static string completion_status()
    {
        return GetString("completion-status");
    }
    /// <summary>
    /// Completion Statuses
    /// </summary>
    public static string completion_statuses()
    {
        return GetString("completion-statuses");
    }
    /// <summary>
    /// User Score
    /// </summary>
    public static string user_score()
    {
        return GetString("user-score");
    }
    /// <summary>
    /// Critic Score
    /// </summary>
    public static string critic_score()
    {
        return GetString("critic-score");
    }
    /// <summary>
    /// Community Score
    /// </summary>
    public static string community_score()
    {
        return GetString("community-score");
    }
    /// <summary>
    /// Game scripts
    /// </summary>
    public static string game_scripts()
    {
        return GetString("game-scripts");
    }
    /// <summary>
    /// Application scripts
    /// </summary>
    public static string application_scripts()
    {
        return GetString("application-scripts");
    }
    /// <summary>
    /// Scripts
    /// </summary>
    public static string scripts()
    {
        return GetString("scripts");
    }
    /// <summary>
    /// Plugins
    /// </summary>
    public static string plugins()
    {
        return GetString("plugins");
    }
    /// <summary>
    /// Metadata Sources
    /// </summary>
    public static string metadata_providers()
    {
        return GetString("metadata-providers");
    }
    /// <summary>
    /// Extensions
    /// </summary>
    public static string extensions()
    {
        return GetString("extensions");
    }
    /// <summary>
    /// Extension ID
    /// </summary>
    public static string extension_id()
    {
        return GetString("extension-id");
    }
    /// <summary>
    /// Reload Scripts
    /// </summary>
    public static string reload_scripts()
    {
        return GetString("reload-scripts");
    }
    /// <summary>
    /// Interactive SDK PowerShell
    /// </summary>
    public static string start_interactive_power_shell()
    {
        return GetString("start-interactive-power-shell");
    }
    /// <summary>
    /// All scripts reloaded successfully.
    /// </summary>
    public static string reload_scripts_success()
    {
        return GetString("reload-scripts-success");
    }
    /// <summary>
    /// No games found for specified search/filter criteria
    /// </summary>
    public static string no_games_found()
    {
        return GetString("no-games-found");
    }
    /// <summary>
    /// No items found
    /// </summary>
    public static string no_items_found()
    {
        return GetString("no-items-found");
    }
    /// <summary>
    /// Switch to Desktop Mode
    /// </summary>
    public static string back_to_desktop_mode()
    {
        return GetString("back-to-desktop-mode");
    }
    /// <summary>
    /// Exit Playnite
    /// </summary>
    public static string exit_playnite()
    {
        return GetString("exit-playnite");
    }
    /// <summary>
    /// Libraries
    /// </summary>
    public static string libraries()
    {
        return GetString("libraries");
    }
    /// <summary>
    /// Update All
    /// </summary>
    public static string update_all()
    {
        return GetString("update-all");
    }
    /// <summary>
    /// Created By:
    /// </summary>
    public static string extension_created_by()
    {
        return GetString("extension-created-by");
    }
    /// <summary>
    /// Version:
    /// </summary>
    public static string extension_version()
    {
        return GetString("extension-version");
    }
    /// <summary>
    /// Updated:
    /// </summary>
    public static string extension_updated()
    {
        return GetString("extension-updated");
    }
    /// <summary>
    /// Module:
    /// </summary>
    public static string extension_module()
    {
        return GetString("extension-module");
    }
    /// <summary>
    /// Library
    /// </summary>
    public static string library()
    {
        return GetString("library");
    }
    /// <summary>
    /// Statistics
    /// </summary>
    public static string statistics()
    {
        return GetString("statistics");
    }
    /// <summary>
    /// All
    /// </summary>
    public static string all()
    {
        return GetString("all");
    }
    /// <summary>
    /// None
    /// </summary>
    public static string none()
    {
        return GetString("none");
    }
    /// <summary>
    /// Notifications
    /// </summary>
    public static string notifications()
    {
        return GetString("notifications");
    }
    /// <summary>
    /// Width
    /// </summary>
    public static string width()
    {
        return GetString("width");
    }
    /// <summary>
    /// Height
    /// </summary>
    public static string height()
    {
        return GetString("height");
    }
    /// <summary>
    /// Size
    /// </summary>
    public static string size()
    {
        return GetString("size");
    }
    /// <summary>
    /// Small
    /// </summary>
    public static string font_small()
    {
        return GetString("font-small");
    }
    /// <summary>
    /// Normal
    /// </summary>
    public static string font_normal()
    {
        return GetString("font-normal");
    }
    /// <summary>
    /// Large
    /// </summary>
    public static string font_large()
    {
        return GetString("font-large");
    }
    /// <summary>
    /// Larger
    /// </summary>
    public static string font_larger()
    {
        return GetString("font-larger");
    }
    /// <summary>
    /// Largest
    /// </summary>
    public static string font_largest()
    {
        return GetString("font-largest");
    }
    /// <summary>
    /// Default
    /// </summary>
    public static string default_label()
    {
        return GetString("default-label");
    }
    /// <summary>
    /// Select
    /// </summary>
    public static string select()
    {
        return GetString("select");
    }
    /// <summary>
    /// Select All
    /// </summary>
    public static string select_all()
    {
        return GetString("select-all");
    }
    /// <summary>
    /// Deselect All
    /// </summary>
    public static string deselect_all()
    {
        return GetString("deselect-all");
    }
    /// <summary>
    /// First
    /// </summary>
    public static string first()
    {
        return GetString("first");
    }
    /// <summary>
    /// Random
    /// </summary>
    public static string random()
    {
        return GetString("random");
    }
    /// <summary>
    /// User select
    /// </summary>
    public static string user_select()
    {
        return GetString("user-select");
    }
    /// <summary>
    /// Load more
    /// </summary>
    public static string load_more()
    {
        return GetString("load-more");
    }
    /// <summary>
    /// Transparent
    /// </summary>
    public static string transparent()
    {
        return GetString("transparent");
    }
    /// <summary>
    /// Collapse
    /// </summary>
    public static string collapse()
    {
        return GetString("collapse");
    }
    /// <summary>
    /// Expand
    /// </summary>
    public static string expand()
    {
        return GetString("expand");
    }
    /// <summary>
    /// Collapse All
    /// </summary>
    public static string collapse_all()
    {
        return GetString("collapse-all");
    }
    /// <summary>
    /// Expand All
    /// </summary>
    public static string expand_all()
    {
        return GetString("expand-all");
    }
    /// <summary>
    /// Other
    /// </summary>
    public static string other()
    {
        return GetString("other");
    }
    /// <summary>
    /// Themes
    /// </summary>
    public static string themes()
    {
        return GetString("themes");
    }
    /// <summary>
    /// Emulator Arguments
    /// </summary>
    public static string emulator_arguments()
    {
        return GetString("emulator-arguments");
    }
    /// <summary>
    /// Built-in Arguments
    /// </summary>
    public static string builtin_arguments()
    {
        return GetString("builtin-arguments");
    }
    /// <summary>
    /// Custom Arguments
    /// </summary>
    public static string custom_arguments()
    {
        return GetString("custom-arguments");
    }
    /// <summary>
    /// Additional Emulator Arguments
    /// </summary>
    public static string additional_emulator_arguments()
    {
        return GetString("additional-emulator-arguments");
    }
    /// <summary>
    /// Override Emulator Arguments
    /// </summary>
    public static string override_emulator_arguments()
    {
        return GetString("override-emulator-arguments");
    }
    /// <summary>
    /// Play action
    /// </summary>
    public static string is_play_action()
    {
        return GetString("is-play-action");
    }
    /// <summary>
    /// Select metadata to import
    /// </summary>
    public static string metadata_diff_window_title()
    {
        return GetString("metadata-diff-window-title");
    }
    /// <summary>
    /// Select Games to Import
    /// </summary>
    public static string game_import_window_title()
    {
        return GetString("game-import-window-title");
    }
    /// <summary>
    /// Metadata search
    /// </summary>
    public static string meta_lookup_window_title()
    {
        return GetString("meta-lookup-window-title");
    }
    /// <summary>
    /// Update Available
    /// </summary>
    public static string updater_window_title()
    {
        return GetString("updater-window-title");
    }
    /// <summary>
    /// Changes since last update
    /// </summary>
    public static string updater_changes_info()
    {
        return GetString("updater-changes-info");
    }
    /// <summary>
    /// Download and Install Update
    /// </summary>
    public static string updater_install_update()
    {
        return GetString("updater-install-update");
    }
    /// <summary>
    /// Check for Updates
    /// </summary>
    public static string check_for_updates()
    {
        return GetString("check-for-updates");
    }
    /// <summary>
    /// Update Error
    /// </summary>
    public static string update_error()
    {
        return GetString("update-error");
    }
    /// <summary>
    /// Failed to check for new version.
    /// </summary>
    public static string update_check_fail_message()
    {
        return GetString("update-check-fail-message");
    }
    /// <summary>
    /// No new version found, you are up to date.
    /// </summary>
    public static string update_no_new_update_message()
    {
        return GetString("update-no-new-update-message");
    }
    /// <summary>
    /// Failed to download and install update.
    /// </summary>
    public static string general_update_fail_message()
    {
        return GetString("general-update-fail-message");
    }
    /// <summary>
    /// Some background task is currently in progress. Do you want to cancel it and proceed with the update?
    /// </summary>
    public static string update_progress_cancel_ask()
    {
        return GetString("update-progress-cancel-ask");
    }
    /// <summary>
    /// Some background task is currently in progress. Do you want to cancel it and exit Playnite?
    /// </summary>
    public static string background_progress_cancel_ask_exit()
    {
        return GetString("background-progress-cancel-ask-exit");
    }
    /// <summary>
    /// Some background task is currently in progress. Switching modes will cancel the task, do you want to switch anyways?
    /// </summary>
    public static string background_progress_cancel_ask_switch_mode()
    {
        return GetString("background-progress-cancel-ask-switch-mode");
    }
    /// <summary>
    /// An update for Playnite is available
    /// </summary>
    public static string update_is_available_notification_body()
    {
        return GetString("update-is-available-notification-body");
    }
    /// <summary>
    /// Reload theme list
    /// </summary>
    public static string theme_test_reload_list()
    {
        return GetString("theme-test-reload-list");
    }
    /// <summary>
    /// Apply selected theme
    /// </summary>
    public static string theme_test_apply_skin()
    {
        return GetString("theme-test-apply-skin");
    }
    /// <summary>
    /// Watch file changes
    /// </summary>
    public static string theme_test_watch_changes()
    {
        return GetString("theme-test-watch-changes");
    }
    /// <summary>
    /// Automatically apply theme when the source file changes
    /// </summary>
    public static string theme_test_watch_changes_tooltip()
    {
        return GetString("theme-test-watch-changes-tooltip");
    }
    /// <summary>
    /// Script runtime
    /// </summary>
    public static string script_runtime()
    {
        return GetString("script-runtime");
    }
    /// <summary>
    /// Execute before starting a game
    /// </summary>
    public static string pre_script_description()
    {
        return GetString("pre-script-description");
    }
    /// <summary>
    /// Execute after exiting a game
    /// </summary>
    public static string post_script_description()
    {
        return GetString("post-script-description");
    }
    /// <summary>
    /// Execute after a game is started
    /// </summary>
    public static string game_started_script_description()
    {
        return GetString("game-started-script-description");
    }
    /// <summary>
    /// Execute on application start
    /// </summary>
    public static string app_script_startup_description()
    {
        return GetString("app-script-startup-description");
    }
    /// <summary>
    /// Execute on application shutdown
    /// </summary>
    public static string app_script_shutdown_description()
    {
        return GetString("app-script-shutdown-description");
    }
    /// <summary>
    /// Game starting script
    /// </summary>
    public static string script_type_starting()
    {
        return GetString("script-type-starting");
    }
    /// <summary>
    /// Game started script
    /// </summary>
    public static string script_type_started()
    {
        return GetString("script-type-started");
    }
    /// <summary>
    /// Game stopped script
    /// </summary>
    public static string script_type_exit()
    {
        return GetString("script-type-exit");
    }
    /// <summary>
    /// Execute global script
    /// </summary>
    public static string execute_global_script()
    {
        return GetString("execute-global-script");
    }
    /// <summary>
    /// Global
    /// </summary>
    public static string stats_global()
    {
        return GetString("stats-global");
    }
    /// <summary>
    /// Filtered
    /// </summary>
    public static string stats_filtered()
    {
        return GetString("stats-filtered");
    }
    /// <summary>
    /// Current
    /// </summary>
    public static string metadata_diff_current()
    {
        return GetString("metadata-diff-current");
    }
    /// <summary>
    /// New
    /// </summary>
    public static string metadata_diff_new()
    {
        return GetString("metadata-diff-new");
    }
    /// <summary>
    /// Test script
    /// </summary>
    public static string test_script()
    {
        return GetString("test-script");
    }
    /// <summary>
    /// Show only selected items.
    /// </summary>
    public static string only_items_selected_tooltip()
    {
        return GetString("only-items-selected-tooltip");
    }
    /// <summary>
    /// Save as default
    /// </summary>
    public static string save_as_default()
    {
        return GetString("save-as-default");
    }
    /// <summary>
    /// Add to Favorites
    /// </summary>
    public static string favorite_game()
    {
        return GetString("favorite-game");
    }
    /// <summary>
    /// Remove from Favorites
    /// </summary>
    public static string remove_favorite_game()
    {
        return GetString("remove-favorite-game");
    }
    /// <summary>
    /// Hide this game
    /// </summary>
    public static string hide_game()
    {
        return GetString("hide-game");
    }
    /// <summary>
    /// Remove from Hidden
    /// </summary>
    public static string un_hide_game()
    {
        return GetString("un-hide-game");
    }
    /// <summary>
    /// Enable HDR Support
    /// </summary>
    public static string enable_hdr()
    {
        return GetString("enable-hdr");
    }
    /// <summary>
    /// Disable HDR Support
    /// </summary>
    public static string disable_hdr()
    {
        return GetString("disable-hdr");
    }
    /// <summary>
    /// Edit…
    /// </summary>
    public static string edit_game()
    {
        return GetString("edit-game");
    }
    /// <summary>
    /// Calculate install size
    /// </summary>
    public static string calculate_install_size()
    {
        return GetString("calculate-install-size");
    }
    /// <summary>
    /// Calculate install size (All games)
    /// </summary>
    public static string calculate_games_all_install_size()
    {
        return GetString("calculate-games-all-install-size");
    }
    /// <summary>
    /// Calculate install size (Only missing data)
    /// </summary>
    public static string calculate_games_missing_install_size()
    {
        return GetString("calculate-games-missing-install-size");
    }
    /// <summary>
    /// Install size
    /// </summary>
    public static string install_size_menu_label()
    {
        return GetString("install-size-menu-label");
    }
    /// <summary>
    /// Set Category…
    /// </summary>
    public static string set_game_category()
    {
        return GetString("set-game-category");
    }
    /// <summary>
    /// Set Completion Status
    /// </summary>
    public static string set_completion_status()
    {
        return GetString("set-completion-status");
    }
    /// <summary>
    /// Remove
    /// </summary>
    public static string remove_game()
    {
        return GetString("remove-game");
    }
    /// <summary>
    /// Play
    /// </summary>
    public static string play_game()
    {
        return GetString("play-game");
    }
    /// <summary>
    /// Install
    /// </summary>
    public static string install_game()
    {
        return GetString("install-game");
    }
    /// <summary>
    /// Game Options
    /// </summary>
    public static string game_options()
    {
        return GetString("game-options");
    }
    /// <summary>
    /// Details
    /// </summary>
    public static string game_details()
    {
        return GetString("game-details");
    }
    /// <summary>
    /// Uninstall
    /// </summary>
    public static string uninstall_game()
    {
        return GetString("uninstall-game");
    }
    /// <summary>
    /// Open Installation Location
    /// </summary>
    public static string open_game_location()
    {
        return GetString("open-game-location");
    }
    /// <summary>
    /// Create Desktop Shortcut
    /// </summary>
    public static string create_desktop_shortcut()
    {
        return GetString("create-desktop-shortcut");
    }
    /// <summary>
    /// Open Manual
    /// </summary>
    public static string open_game_manual()
    {
        return GetString("open-game-manual");
    }
    /// <summary>
    /// More
    /// </summary>
    public static string more_action()
    {
        return GetString("more-action");
    }
    /// <summary>
    /// Managed by the library plugin
    /// </summary>
    public static string play_action_use_plugin()
    {
        return GetString("play-action-use-plugin");
    }
    /// <summary>
    /// The game starting process will be managed by the library plugin responsible for this game.
    /// </summary>
    public static string play_action_use_plugin_tooltip()
    {
        return GetString("play-action-use-plugin-tooltip");
    }
    /// <summary>
    /// Tip: You can use more advanced metadata download process while editing single game via "Edit" menu option.
    /// </summary>
    public static string meta_download_single_game_tip()
    {
        return GetString("meta-download-single-game-tip");
    }
    /// <summary>
    /// Not available when some action is in progress.
    /// </summary>
    public static string progress_availability_message()
    {
        return GetString("progress-availability-message");
    }
    /// <summary>
    /// Description text is HTML syntax sensitive
    /// </summary>
    public static string description_html_support_tooltip()
    {
        return GetString("description-html-support-tooltip");
    }
    /// <summary>
    /// Game time is recorded in seconds.
    /// </summary>
    public static string description_playtime_seconds()
    {
        return GetString("description-playtime-seconds");
    }
    /// <summary>
    /// Install size is indicated in bytes.
    /// </summary>
    public static string description_size_bytes()
    {
        return GetString("description-size-bytes");
    }
    /// <summary>
    /// Release date must be set in 'year-month-day' format. Month and Day values can be omitted.
    /// </summary>
    public static string release_date_tooltip()
    {
        return GetString("release-date-tooltip");
    }
    /// <summary>
    /// Values from 0 to 100 or empty for no score.
    /// </summary>
    public static string description_score_values()
    {
        return GetString("description-score-values");
    }
    /// <summary>
    /// Playnite's development is supported by these patrons:
    /// </summary>
    public static string patreon_develop_message()
    {
        return GetString("patreon-develop-message");
    }
    /// <summary>
    /// Code, localization and other contributors in no particular order:
    /// </summary>
    public static string about_contributors_message()
    {
        return GetString("about-contributors-message");
    }
    /// <summary>
    /// Cancel game monitoring?
    /// </summary>
    public static string cancel_monitoring_ask_title()
    {
        return GetString("cancel-monitoring-ask-title");
    }
    /// <summary>
    /// Installation monitoring is currently running. Do you want to cancel the process and return the game to the previous state?
    /// </summary>
    public static string cancel_monitoring_setup_ask()
    {
        return GetString("cancel-monitoring-setup-ask");
    }
    /// <summary>
    /// Game execution monitoring is currently running. Do you want to cancel the process and return the game to the previous state?
    /// </summary>
    public static string cancel_monitoring_execution_ask()
    {
        return GetString("cancel-monitoring-execution-ask");
    }
    /// <summary>
    /// Time Played
    /// </summary>
    public static string time_played()
    {
        return GetString("time-played");
    }
    /// <summary>
    /// Last Played
    /// </summary>
    public static string last_played()
    {
        return GetString("last-played");
    }
    /// <summary>
    /// {$days}d {$hours}h {$minutes}m
    /// </summary>
    public static string played_days(object days, object hours, object minutes)
    {
        return GetString("played-days", ("days", days), ("hours", hours), ("minutes", minutes));
    }
    /// <summary>
    /// {$hours}h {$minutes}m
    /// </summary>
    public static string played_hours(object hours, object minutes)
    {
        return GetString("played-hours", ("hours", hours), ("minutes", minutes));
    }
    /// <summary>
    /// {$minutes} minutes
    /// </summary>
    public static string played_minutes(object minutes)
    {
        return GetString("played-minutes", ("minutes", minutes));
    }
    /// <summary>
    /// {$seconds} seconds
    /// </summary>
    public static string played_seconds(object seconds)
    {
        return GetString("played-seconds", ("seconds", seconds));
    }
    /// <summary>
    /// Not Played
    /// </summary>
    public static string played_none()
    {
        return GetString("played-none");
    }
    /// <summary>
    /// Opening Desktop mode…
    /// </summary>
    public static string opening_desktop_mode_message()
    {
        return GetString("opening-desktop-mode-message");
    }
    /// <summary>
    /// Opening Fullscreen mode…
    /// </summary>
    public static string opening_fullscreen_mode_message()
    {
        return GetString("opening-fullscreen-mode-message");
    }
    /// <summary>
    /// Loading game library…
    /// </summary>
    public static string opening_database()
    {
        return GetString("opening-database");
    }
    /// <summary>
    /// Calculating install size…
    /// </summary>
    public static string calculating_install_size_message()
    {
        return GetString("calculating-install-size-message");
    }
    /// <summary>
    /// Calculating install size of {$gameName}…
    /// </summary>
    public static string calculating_install_size_of_game_message(object gameName)
    {
        return GetString("calculating-install-size-of-game-message", ("gameName", gameName));
    }
    /// <summary>
    /// Failed to install script file.
    /// </summary>
    public static string script_install_fail()
    {
        return GetString("script-install-fail");
    }
    /// <summary>
    /// Script installed successfully.
    /// </summary>
    public static string script_install_success()
    {
        return GetString("script-install-success");
    }
    /// <summary>
    /// Install Script
    /// </summary>
    public static string install_script()
    {
        return GetString("install-script");
    }
    /// <summary>
    /// Script error
    /// </summary>
    public static string script_error()
    {
        return GetString("script-error");
    }
    /// <summary>
    /// Failed to execute extension function.
    /// </summary>
    public static string script_execution_error()
    {
        return GetString("script-execution-error");
    }
    /// <summary>
    /// Open metadata folder
    /// </summary>
    public static string open_metadata_folder()
    {
        return GetString("open-metadata-folder");
    }
    /// <summary>
    /// Calculate
    /// </summary>
    public static string install_size_calculate()
    {
        return GetString("install-size-calculate");
    }
    /// <summary>
    /// Automatically calculates the install size using the ROMs if the game has any or the installation directory if it has been set
    /// </summary>
    public static string install_size_calculate_edit_button_tooltip()
    {
        return GetString("install-size-calculate-edit-button-tooltip");
    }
    /// <summary>
    /// {$clientName} client is not installed.
    /// </summary>
    public static string client_not_installed_error(object clientName)
    {
        return GetString("client-not-installed-error", ("clientName", clientName));
    }
    /// <summary>
    /// {$clientName} client will now open. Please sign in and then close this message.
    /// </summary>
    public static string sign_in_external_notif(object clientName)
    {
        return GetString("sign-in-external-notif", ("clientName", clientName));
    }
    /// <summary>
    /// Waiting for user to sign in, please close this when you're done…
    /// </summary>
    public static string sign_in_external_wait_message()
    {
        return GetString("sign-in-external-wait-message");
    }
    /// <summary>
    /// Game's installation folder not found.
    /// </summary>
    public static string install_dir_not_found_error()
    {
        return GetString("install-dir-not-found-error");
    }
    /// <summary>
    /// Invalid game action configuration.
    /// </summary>
    public static string invalid_game_action_settings()
    {
        return GetString("invalid-game-action-settings");
    }
    /// <summary>
    /// Troubleshooting account sync issues
    /// </summary>
    public static string trouble_shooting_account_link()
    {
        return GetString("trouble-shooting-account-link");
    }
    /// <summary>
    /// Troubleshooting issues
    /// </summary>
    public static string trouble_shooting_issues()
    {
        return GetString("trouble-shooting-issues");
    }
    /// <summary>
    /// Rename item
    /// </summary>
    public static string rename_item()
    {
        return GetString("rename-item");
    }
    /// <summary>
    /// Add new item
    /// </summary>
    public static string add_new_item()
    {
        return GetString("add-new-item");
    }
    /// <summary>
    /// Enter name
    /// </summary>
    public static string enter_name()
    {
        return GetString("enter-name");
    }
    /// <summary>
    /// Enter new name
    /// </summary>
    public static string enter_new_name()
    {
        return GetString("enter-new-name");
    }
    /// <summary>
    /// Less than an hour
    /// </summary>
    public static string playtime_less_then_an_hour()
    {
        return GetString("playtime-less-then-an-hour");
    }
    /// <summary>
    /// 1 to 10 hours
    /// </summary>
    public static string playtime1to10()
    {
        return GetString("playtime1to10");
    }
    /// <summary>
    /// 10 to 100 hours
    /// </summary>
    public static string playtime10to100()
    {
        return GetString("playtime10to100");
    }
    /// <summary>
    /// 100 to 500 hours
    /// </summary>
    public static string playtime100to500()
    {
        return GetString("playtime100to500");
    }
    /// <summary>
    /// 500 to 1000 hours
    /// </summary>
    public static string playtime500to1000()
    {
        return GetString("playtime500to1000");
    }
    /// <summary>
    /// Over 1000 hours
    /// </summary>
    public static string playtime1000plus()
    {
        return GetString("playtime1000plus");
    }
    /// <summary>
    /// Playnite must be restarted to complete the installation. Do you want to restart now?
    /// </summary>
    public static string ext_installation_restart_notif()
    {
        return GetString("ext-installation-restart-notif");
    }
    /// <summary>
    /// Extension is not packaged properly.
    /// </summary>
    public static string general_extension_package_error()
    {
        return GetString("general-extension-package-error");
    }
    /// <summary>
    /// Theme is not packaged properly.
    /// </summary>
    public static string general_theme_package_error()
    {
        return GetString("general-theme-package-error");
    }
    /// <summary>
    /// Extension "{$extensionName}" failed to load properly.
    /// </summary>
    public static string specific_extension_load_error(object extensionName)
    {
        return GetString("specific-extension-load-error", ("extensionName", extensionName));
    }
    /// <summary>
    /// Can't load "{$extensionName}" extension, current Playnite version is not supported.
    /// </summary>
    public static string specific_extension_load_sdk_error(object extensionName)
    {
        return GetString("specific-extension-load-sdk-error", ("extensionName", extensionName));
    }
    /// <summary>
    /// Theme "{$themeName}" failed to load properly.
    /// </summary>
    public static string specific_theme_load_error(object themeName)
    {
        return GetString("specific-theme-load-error", ("themeName", themeName));
    }
    /// <summary>
    /// Can't load "{$themeName}" theme, current Playnite version is not supported.
    /// </summary>
    public static string specific_theme_load_sdk_error(object themeName)
    {
        return GetString("specific-theme-load-sdk-error", ("themeName", themeName));
    }
    /// <summary>
    /// Extension failed to load properly.
    /// </summary>
    public static string general_extension_load_error()
    {
        return GetString("general-extension-load-error");
    }
    /// <summary>
    /// Theme failed to load properly.
    /// </summary>
    public static string general_theme_load_error()
    {
        return GetString("general-theme-load-error");
    }
    /// <summary>
    /// Theme/Extension is using unsupported API version.
    /// </summary>
    public static string general_extension_install_api_version_fails()
    {
        return GetString("general-extension-install-api-version-fails");
    }
    /// <summary>
    /// Installation was successful.
    /// </summary>
    public static string general_extension_install_success()
    {
        return GetString("general-extension-install-success");
    }
    /// <summary>
    /// Install add-on?
    /// </summary>
    public static string general_extension_install_title()
    {
        return GetString("general-extension-install-title");
    }
    /// <summary>
    /// Generic
    /// </summary>
    public static string extension_generic()
    {
        return GetString("extension-generic");
    }
    /// <summary>
    /// Failed to install "{$addonName}" add-on.
    /// </summary>
    public static string addon_install_failed(object addonName)
    {
        return GetString("addon-install-failed", ("addonName", addonName));
    }
    /// <summary>
    /// Failed to install extension.
    /// </summary>
    public static string extension_install_fail()
    {
        return GetString("extension-install-fail");
    }
    /// <summary>
    /// Do you want to install a new extension?
    /// 
    /// {$name}
    /// By {$author}
    /// Version {$version}
    /// </summary>
    public static string extension_install_prompt(object name, object author, object version)
    {
        return GetString("extension-install-prompt", ("name", name), ("author", author), ("version", version));
    }
    /// <summary>
    /// Do you want to update "{$name}" extension?
    /// 
    /// Current version: {$currentVersion}
    /// New version: {$newVersion}
    /// </summary>
    public static string extension_update_prompt(object name, object currentVersion, object newVersion)
    {
        return GetString("extension-update-prompt", ("name", name), ("currentVersion", currentVersion), ("newVersion", newVersion));
    }
    /// <summary>
    /// Failed to install theme.
    /// </summary>
    public static string theme_install_fail()
    {
        return GetString("theme-install-fail");
    }
    /// <summary>
    /// Do you want to install a new theme?
    /// 
    /// {$name}
    /// By {$author}
    /// Version {$version}
    /// </summary>
    public static string theme_install_prompt(object name, object author, object version)
    {
        return GetString("theme-install-prompt", ("name", name), ("author", author), ("version", version));
    }
    /// <summary>
    /// Do you want to update "{$name}" theme?
    /// 
    /// Current version: {$currentVersion}
    /// New version: {$newVersion}
    /// </summary>
    public static string theme_update_prompt(object name, object currentVersion, object newVersion)
    {
        return GetString("theme-update-prompt", ("name", name), ("currentVersion", currentVersion), ("newVersion", newVersion));
    }
    /// <summary>
    /// You are about to leave Playnite and navigate to the following web page using your default web browser. Do you want to continue?
    /// 
    /// {$pageUrl}
    /// </summary>
    public static string url_navigation_message(object pageUrl)
    {
        return GetString("url-navigation-message", ("pageUrl", pageUrl));
    }
    /// <summary>
    /// The selected image(s) might be too large for optimal performance. Using very large images can result in worse UI responsiveness and increased memory usage. 
    /// 
    /// Maximum recommended resolutions:
    /// Icons: {$iconPixels} mega pixels
    /// Covers: {$coverPixels} mega pixels
    /// Backgrounds: {$backgroundPixels} mega pixels
    /// </summary>
    public static string game_image_size_warning(object iconPixels, object coverPixels, object backgroundPixels)
    {
        return GetString("game-image-size-warning", ("iconPixels", iconPixels), ("coverPixels", coverPixels), ("backgroundPixels", backgroundPixels));
    }
    /// <summary>
    /// Performance Warning
    /// </summary>
    public static string performance_warning_title()
    {
        return GetString("performance-warning-title");
    }
    /// <summary>
    /// Don't Show Again
    /// </summary>
    public static string dont_show_again_title()
    {
        return GetString("dont-show-again-title");
    }
    /// <summary>
    /// File with extension {$extensionName} is not compatible.
    /// </summary>
    public static string incompatible_drag_and_drop_extension_error(object extensionName)
    {
        return GetString("incompatible-drag-and-drop-extension-error", ("extensionName", extensionName));
    }
    /// <summary>
    /// Incompatible file extension
    /// </summary>
    public static string incompatible_drag_and_drop_extension_error_title()
    {
        return GetString("incompatible-drag-and-drop-extension-error-title");
    }
    /// <summary>
    /// Selected image file might be too large for optimal performance.
    /// </summary>
    public static string large_media_warning_tooltip()
    {
        return GetString("large-media-warning-tooltip");
    }
    /// <summary>
    /// Are you sure you want to uninstall selected theme? Uninstallation will be queued to next application start.
    /// </summary>
    public static string theme_uninstall_question()
    {
        return GetString("theme-uninstall-question");
    }
    /// <summary>
    /// Built-in themes can't be uninstalled.
    /// </summary>
    public static string theme_built_in_uninstall_hint()
    {
        return GetString("theme-built-in-uninstall-hint");
    }
    /// <summary>
    /// This theme doesn't support this version of Playnite.
    /// </summary>
    public static string theme_unsupported()
    {
        return GetString("theme-unsupported");
    }
    /// <summary>
    /// Are you sure you want to uninstall selected extension? Uninstallation will be queued to next application start.
    /// </summary>
    public static string extension_uninstall_question()
    {
        return GetString("extension-uninstall-question");
    }
    /// <summary>
    /// Built-in extensions can't be uninstalled.
    /// </summary>
    public static string extension_built_in_uninstall_hint()
    {
        return GetString("extension-built-in-uninstall-hint");
    }
    /// <summary>
    /// This extension doesn't support this version of Playnite.
    /// </summary>
    public static string extension_unsupported()
    {
        return GetString("extension-unsupported");
    }
    /// <summary>
    /// Installation folder
    /// </summary>
    public static string extension_install_dir()
    {
        return GetString("extension-install-dir");
    }
    /// <summary>
    /// Data folder
    /// </summary>
    public static string extension_data_dir()
    {
        return GetString("extension-data-dir");
    }
    /// <summary>
    /// Generating diagnostics package…
    /// </summary>
    public static string diag_generating()
    {
        return GetString("diag-generating");
    }
    /// <summary>
    /// Uploading diagnostics package…
    /// </summary>
    public static string diag_uploading()
    {
        return GetString("diag-uploading");
    }
    /// <summary>
    /// Import file…
    /// </summary>
    public static string add_from_exe()
    {
        return GetString("add-from-exe");
    }
    /// <summary>
    /// What is this?
    /// </summary>
    public static string what_is_this()
    {
        return GetString("what-is-this");
    }
    /// <summary>
    /// Are you sure you want to do this?
    /// </summary>
    public static string confirmation_ask_generic()
    {
        return GetString("confirmation-ask-generic");
    }
    /// <summary>
    /// Total play time
    /// </summary>
    public static string stats_total_play_time()
    {
        return GetString("stats-total-play-time");
    }
    /// <summary>
    /// Average play time
    /// </summary>
    public static string stats_average_play_time()
    {
        return GetString("stats-average-play-time");
    }
    /// <summary>
    /// Top play time
    /// </summary>
    public static string stats_top_play_time()
    {
        return GetString("stats-top-play-time");
    }
    /// <summary>
    /// Total install size
    /// </summary>
    public static string stats_total_install_size()
    {
        return GetString("stats-total-install-size");
    }
    /// <summary>
    /// Overview
    /// </summary>
    public static string overview_label()
    {
        return GetString("overview-label");
    }
    /// <summary>
    /// Sidebar
    /// </summary>
    public static string sidebar()
    {
        return GetString("sidebar");
    }
    /// <summary>
    /// Show on Sidebar
    /// </summary>
    public static string tools_show_on_sidebar()
    {
        return GetString("tools-show-on-sidebar");
    }
    /// <summary>
    /// Reset settings
    /// </summary>
    public static string settings_reset()
    {
        return GetString("settings-reset");
    }
    /// <summary>
    /// All application settings will be reset to default values, excluding:
    /// - Database location
    /// - Import exclusion list
    /// - Extension settings, including library integrations
    /// 
    /// Application restart is required to finish the process. Do you want to reset settings?
    /// </summary>
    public static string settings_default_reset_desc()
    {
        return GetString("settings-default-reset-desc");
    }
    /// <summary>
    /// For developers
    /// </summary>
    public static string settings_for_developers()
    {
        return GetString("settings-for-developers");
    }
    /// <summary>
    /// External extensions
    /// </summary>
    public static string settings_external_extensions()
    {
        return GetString("settings-external-extensions");
    }
    /// <summary>
    /// Enter full folder path.
    /// </summary>
    public static string settings_new_external_extension_box()
    {
        return GetString("settings-new-external-extension-box");
    }
    /// <summary>
    /// Achievements
    /// </summary>
    public static string common_links_achievements()
    {
        return GetString("common-links-achievements");
    }
    /// <summary>
    /// Forum
    /// </summary>
    public static string common_links_forum()
    {
        return GetString("common-links-forum");
    }
    /// <summary>
    /// News
    /// </summary>
    public static string common_links_news()
    {
        return GetString("common-links-news");
    }
    /// <summary>
    /// Store Page
    /// </summary>
    public static string common_links_store_page()
    {
        return GetString("common-links-store-page");
    }
    /// <summary>
    /// The initial setup is not complete. Playnite will now restart to Desktop Mode to finish the procedure.
    /// </summary>
    public static string fullscreen_first_time_error()
    {
        return GetString("fullscreen-first-time-error");
    }
    /// <summary>
    /// Recently Played
    /// </summary>
    public static string quick_filter_recently_played()
    {
        return GetString("quick-filter-recently-played");
    }
    /// <summary>
    /// Favorites
    /// </summary>
    public static string quick_filter_favorites()
    {
        return GetString("quick-filter-favorites");
    }
    /// <summary>
    /// Most Played
    /// </summary>
    public static string quick_filter_most_played()
    {
        return GetString("quick-filter-most-played");
    }
    /// <summary>
    /// All
    /// </summary>
    public static string quick_filter_all_games()
    {
        return GetString("quick-filter-all-games");
    }
    /// <summary>
    /// There are filters applied.
    /// </summary>
    public static string game_list_filtered()
    {
        return GetString("game-list-filtered");
    }
    /// <summary>
    /// There are additional filters applied.
    /// </summary>
    public static string game_list_extra_filtered()
    {
        return GetString("game-list-extra-filtered");
    }
    /// <summary>
    /// Showing search results for:
    /// </summary>
    public static string game_list_search_results()
    {
        return GetString("game-list-search-results");
    }
    /// <summary>
    /// An item with the same name already exists.
    /// </summary>
    public static string item_already_exists()
    {
        return GetString("item-already-exists");
    }
    /// <summary>
    /// Limit selection to current filter
    /// </summary>
    public static string random_game_limit_to_filter()
    {
        return GetString("random-game-limit-to-filter");
    }
    /// <summary>
    /// Pick another
    /// </summary>
    public static string random_game_pick_another()
    {
        return GetString("random-game-pick-another");
    }
    /// <summary>
    /// Add-ons…
    /// </summary>
    public static string menu_addons()
    {
        return GetString("menu-addons");
    }
    /// <summary>
    /// Installed
    /// </summary>
    public static string extensions_installed()
    {
        return GetString("extensions-installed");
    }
    /// <summary>
    /// Extensions settings
    /// </summary>
    public static string extensions_settings()
    {
        return GetString("extensions-settings");
    }
    /// <summary>
    /// Browse
    /// </summary>
    public static string extensions_browse()
    {
        return GetString("extensions-browse");
    }
    /// <summary>
    /// Updates
    /// </summary>
    public static string extensions_updates()
    {
        return GetString("extensions-updates");
    }
    /// <summary>
    /// Updates ({$updatesCount})
    /// </summary>
    public static string extensions_updates_count(object updatesCount)
    {
        return GetString("extensions-updates-count", ("updatesCount", updatesCount));
    }
    /// <summary>
    /// Management of installed extensions and themes, including their settings, has been moved to a new "Add-ons" menu.
    /// </summary>
    public static string addons_config_move_info()
    {
        return GetString("addons-config-move-info");
    }
    /// <summary>
    /// All currently installed library integration extensions can be configured here.
    /// 
    /// If you want to install or uninstall additional integrations, use "Add-ons" option from main menu.
    /// </summary>
    public static string libraries_config_window_description()
    {
        return GetString("libraries-config-window-description");
    }
    /// <summary>
    /// Themes Desktop
    /// </summary>
    public static string addons_themes_desktop()
    {
        return GetString("addons-themes-desktop");
    }
    /// <summary>
    /// Themes Fullscreen
    /// </summary>
    public static string addons_themes_fullscreen()
    {
        return GetString("addons-themes-fullscreen");
    }
    /// <summary>
    /// Searching…
    /// </summary>
    public static string addons_searching()
    {
        return GetString("addons-searching");
    }
    /// <summary>
    /// Add-on is not compatible with this version of Playnite.
    /// </summary>
    public static string addon_error_not_compatible()
    {
        return GetString("addon-error-not-compatible");
    }
    /// <summary>
    /// Failed to download add-on installation package.
    /// </summary>
    public static string addon_error_download_failed()
    {
        return GetString("addon-error-download-failed");
    }
    /// <summary>
    /// Failed to download add-on installation manifest.
    /// </summary>
    public static string addon_error_manifest_download_error()
    {
        return GetString("addon-error-manifest-download-error");
    }
    /// <summary>
    /// Application restart is required to apply pending changes.
    /// </summary>
    public static string addon_changes_restart()
    {
        return GetString("addon-changes-restart");
    }
    /// <summary>
    /// This add-on is scheduled for installation.
    /// </summary>
    public static string addon_queued_for_install()
    {
        return GetString("addon-queued-for-install");
    }
    /// <summary>
    /// Install
    /// </summary>
    public static string addon_install()
    {
        return GetString("addon-install");
    }
    /// <summary>
    /// Uninstall
    /// </summary>
    public static string addon_uninstall()
    {
        return GetString("addon-uninstall");
    }
    /// <summary>
    /// Already installed
    /// </summary>
    public static string addon_already_installed()
    {
        return GetString("addon-already-installed");
    }
    /// <summary>
    /// No new add-on updates found.
    /// </summary>
    public static string addon_no_addons_available()
    {
        return GetString("addon-no-addons-available");
    }
    /// <summary>
    /// Update add-ons
    /// </summary>
    public static string addon_update_addons()
    {
        return GetString("addon-update-addons");
    }
    /// <summary>
    /// Changelog is not available
    /// </summary>
    public static string addon_changelog_not_available()
    {
        return GetString("addon-changelog-not-available");
    }
    /// <summary>
    /// Scheduled for installation
    /// </summary>
    public static string addon_update_status_downloaded()
    {
        return GetString("addon-update-status-downloaded");
    }
    /// <summary>
    /// Download failed
    /// </summary>
    public static string addon_update_status_failed()
    {
        return GetString("addon-update-status-failed");
    }
    /// <summary>
    /// License rejected
    /// </summary>
    public static string addon_update_status_license_rejected()
    {
        return GetString("addon-update-status-license-rejected");
    }
    /// <summary>
    /// Downloading {$addonName}…
    /// </summary>
    public static string addon_downloading_addon(object addonName)
    {
        return GetString("addon-downloading-addon", ("addonName", addonName));
    }
    /// <summary>
    /// Looking for add-on updates…
    /// </summary>
    public static string addon_looking_for_updates()
    {
        return GetString("addon-looking-for-updates");
    }
    /// <summary>
    /// One or more add-on updates are available.
    /// </summary>
    public static string addon_updates_available()
    {
        return GetString("addon-updates-available");
    }
    /// <summary>
    /// Select items to update
    /// </summary>
    public static string addon_select_to_update()
    {
        return GetString("addon-select-to-update");
    }
    /// <summary>
    /// Extension development instance
    /// </summary>
    public static string addon_dev_reference_loaded()
    {
        return GetString("addon-dev-reference-loaded");
    }
    /// <summary>
    /// {$addonName} license agreement
    /// </summary>
    public static string addon_license_window_title(object addonName)
    {
        return GetString("addon-license-window-title", ("addonName", addonName));
    }
    /// <summary>
    /// Accept
    /// </summary>
    public static string license_accept()
    {
        return GetString("license-accept");
    }
    /// <summary>
    /// Decline
    /// </summary>
    public static string license_decline()
    {
        return GetString("license-decline");
    }
    /// <summary>
    /// Include library integration play actions
    /// </summary>
    public static string include_plugin_game_actions()
    {
        return GetString("include-plugin-game-actions");
    }
    /// <summary>
    /// Select action
    /// </summary>
    public static string select_action_title()
    {
        return GetString("select-action-title");
    }
    /// <summary>
    /// Tracking Mode
    /// </summary>
    public static string action_tracking_mode()
    {
        return GetString("action-tracking-mode");
    }
    /// <summary>
    /// Tracking Path
    /// </summary>
    public static string action_tracking_path()
    {
        return GetString("action-tracking-path");
    }
    /// <summary>
    /// Link
    /// </summary>
    public static string game_action_type_link()
    {
        return GetString("game-action-type-link");
    }
    /// <summary>
    /// File
    /// </summary>
    public static string game_action_type_file()
    {
        return GetString("game-action-type-file");
    }
    /// <summary>
    /// Emulator
    /// </summary>
    public static string game_action_type_emulator()
    {
        return GetString("game-action-type-emulator");
    }
    /// <summary>
    /// Script
    /// </summary>
    public static string game_action_type_script()
    {
        return GetString("game-action-type-script");
    }
    /// <summary>
    /// Default
    /// </summary>
    public static string action_tracking_mode_default()
    {
        return GetString("action-tracking-mode-default");
    }
    /// <summary>
    /// Process
    /// </summary>
    public static string action_tracking_mode_process()
    {
        return GetString("action-tracking-mode-process");
    }
    /// <summary>
    /// Folder
    /// </summary>
    public static string action_tracking_mode_directory()
    {
        return GetString("action-tracking-mode-directory");
    }
    /// <summary>
    /// Original process
    /// </summary>
    public static string action_tracking_original_process()
    {
        return GetString("action-tracking-original-process");
    }
    /// <summary>
    /// Log trace messages
    /// </summary>
    public static string devel_trace_log_enable()
    {
        return GetString("devel-trace-log-enable");
    }
    /// <summary>
    /// Following changes overwrite data for all currently selected games!
    /// </summary>
    public static string multi_edit_overwrite_warning()
    {
        return GetString("multi-edit-overwrite-warning");
    }
    /// <summary>
    /// None
    /// </summary>
    public static string grid_view_spacing_mode_none()
    {
        return GetString("grid-view-spacing-mode-none");
    }
    /// <summary>
    /// Uniform
    /// </summary>
    public static string grid_view_spacing_mode_uniform()
    {
        return GetString("grid-view-spacing-mode-uniform");
    }
    /// <summary>
    /// Items only
    /// </summary>
    public static string grid_view_spacing_mode_between_items_only()
    {
        return GetString("grid-view-spacing-mode-between-items-only");
    }
    /// <summary>
    /// Start and end only
    /// </summary>
    public static string grid_view_spacing_mode_start_and_end_only()
    {
        return GetString("grid-view-spacing-mode-start-and-end-only");
    }
    /// <summary>
    /// Scrolling sensitivity
    /// </summary>
    public static string scrolling_sensitivity()
    {
        return GetString("scrolling-sensitivity");
    }
    /// <summary>
    /// Smooth scrolling
    /// </summary>
    public static string smooth_scrolling()
    {
        return GetString("smooth-scrolling");
    }
    /// <summary>
    /// Animation speed
    /// </summary>
    public static string smooth_scrolling_speed()
    {
        return GetString("smooth-scrolling-speed");
    }
    /// <summary>
    /// Remove item?
    /// </summary>
    public static string ask_remove_item_title()
    {
        return GetString("ask-remove-item-title");
    }
    /// <summary>
    /// Are you sure you want to remove this item?
    /// </summary>
    public static string ask_remove_item_message()
    {
        return GetString("ask-remove-item-message");
    }
    /// <summary>
    /// Show buttons on top panel:
    /// </summary>
    public static string settings_top_panel_items()
    {
        return GetString("settings-top-panel-items");
    }
    /// <summary>
    /// General view settings
    /// </summary>
    public static string settings_top_panel_general_view_item()
    {
        return GetString("settings-top-panel-general-view-item");
    }
    /// <summary>
    /// Grouping settings
    /// </summary>
    public static string settings_top_panel_grouping_item()
    {
        return GetString("settings-top-panel-grouping-item");
    }
    /// <summary>
    /// Sorting settings
    /// </summary>
    public static string settings_top_panel_sorting_item()
    {
        return GetString("settings-top-panel-sorting-item");
    }
    /// <summary>
    /// Filter presets
    /// </summary>
    public static string settings_top_panel_filter_presets_item()
    {
        return GetString("settings-top-panel-filter-presets-item");
    }
    /// <summary>
    /// Plugin items position
    /// </summary>
    public static string top_panel_plugin_panel_position()
    {
        return GetString("top-panel-plugin-panel-position");
    }
    /// <summary>
    /// Section separator width
    /// </summary>
    public static string top_panel_separator_width()
    {
        return GetString("top-panel-separator-width");
    }
    /// <summary>
    /// Move main menu button to the sidebar
    /// </summary>
    public static string top_panel_main_button_move()
    {
        return GetString("top-panel-main-button-move");
    }
    /// <summary>
    /// Explorer panel
    /// </summary>
    public static string top_panel_explorer_switch()
    {
        return GetString("top-panel-explorer-switch");
    }
    /// <summary>
    /// Random game picker
    /// </summary>
    public static string top_panel_select_random_game_button()
    {
        return GetString("top-panel-select-random-game-button");
    }
    /// <summary>
    /// Views random game selector
    /// </summary>
    public static string top_panel_view_select_random_game_button()
    {
        return GetString("top-panel-view-select-random-game-button");
    }
    /// <summary>
    /// Select random game from the view
    /// </summary>
    public static string top_panel_view_select_random_game_button_tooltip()
    {
        return GetString("top-panel-view-select-random-game-button-tooltip");
    }
    /// <summary>
    /// Save grouping and sorting settings
    /// </summary>
    public static string filter_preset_save_view_options()
    {
        return GetString("filter-preset-save-view-options");
    }
    /// <summary>
    /// Show as quick filter in Fullscreen mode
    /// </summary>
    public static string filter_preset_show_on_fs_top_panel()
    {
        return GetString("filter-preset-show-on-fs-top-panel");
    }
    /// <summary>
    /// In past 7 days
    /// </summary>
    public static string in_past7_days()
    {
        return GetString("in-past7-days");
    }
    /// <summary>
    /// In past 31 days
    /// </summary>
    public static string in_past31_days()
    {
        return GetString("in-past31-days");
    }
    /// <summary>
    /// In past 365 days
    /// </summary>
    public static string in_past365_days()
    {
        return GetString("in-past365-days");
    }
    /// <summary>
    /// More than 365 days ago
    /// </summary>
    public static string more_than365_days_ago()
    {
        return GetString("more-than365-days-ago");
    }
    /// <summary>
    /// Configure
    /// </summary>
    public static string configure()
    {
        return GetString("configure");
    }
    /// <summary>
    /// Save preset
    /// </summary>
    public static string filter_preset_save()
    {
        return GetString("filter-preset-save");
    }
    /// <summary>
    /// Minimize after starting game
    /// </summary>
    public static string settings_minimize_after_starting_game()
    {
        return GetString("settings-minimize-after-starting-game");
    }
    /// <summary>
    /// Minimize Playnite after a game is started.
    /// 
    /// Disabling this can lead to issues with games not getting input focus on startup!
    /// </summary>
    public static string settings_minimize_after_starting_game_description()
    {
        return GetString("settings-minimize-after-starting-game-description");
    }
    /// <summary>
    /// Font Size
    /// </summary>
    public static string settings_font_size()
    {
        return GetString("settings-font-size");
    }
    /// <summary>
    /// Font Size Small
    /// </summary>
    public static string settings_font_size_small()
    {
        return GetString("settings-font-size-small");
    }
    /// <summary>
    /// XInput Device Support
    /// </summary>
    public static string settings_xinput_processing()
    {
        return GetString("settings-xinput-processing");
    }
    /// <summary>
    /// If disabled, Playnite won't accept any XInput interface inputs.
    /// 
    /// Disable if you use tools that translate XInput inputs to mouse/keyboards inputs and you are getting double inputs in Playnite.
    /// </summary>
    public static string settings_xinput_processing_description()
    {
        return GetString("settings-xinput-processing-description");
    }
    /// <summary>
    /// Show items on main menu:
    /// </summary>
    public static string settings_show_items_main_menu_header()
    {
        return GetString("settings-show-items-main-menu-header");
    }
    /// <summary>
    /// Inverted X/A main view button binding
    /// </summary>
    public static string settings_swap_main_view_xa_buttons()
    {
        return GetString("settings-swap-main-view-xa-buttons");
    }
    /// <summary>
    /// Swaps button bindings for starting a game and showing game details page on main view.
    /// </summary>
    public static string settings_swap_main_view_xa_buttons_descriptions()
    {
        return GetString("settings-swap-main-view-xa-buttons-descriptions");
    }
    /// <summary>
    /// Swap confirmation/cancellation button binding
    /// </summary>
    public static string settings_swap_confirm_cancel_buttons()
    {
        return GetString("settings-swap-confirm-cancel-buttons");
    }
    /// <summary>
    /// Inverts A/B button bindings for confirmation and cancellation.
    /// </summary>
    public static string settings_swap_confirm_cancel_buttons_descriptions()
    {
        return GetString("settings-swap-confirm-cancel-buttons-descriptions");
    }
    /// <summary>
    /// Primary controller only
    /// </summary>
    public static string settings_primary_controller_only()
    {
        return GetString("settings-primary-controller-only");
    }
    /// <summary>
    /// Only accept inputs from primary controller when enabled.
    /// </summary>
    public static string settings_primary_controller_only_description()
    {
        return GetString("settings-primary-controller-only-description");
    }
    /// <summary>
    /// Guide button focuses Playnite
    /// </summary>
    public static string settings_refocus_on_guid_button()
    {
        return GetString("settings-refocus-on-guid-button");
    }
    /// <summary>
    /// Interface volume
    /// </summary>
    public static string settings_interface_volume()
    {
        return GetString("settings-interface-volume");
    }
    /// <summary>
    /// Background volume
    /// </summary>
    public static string settings_music_volume()
    {
        return GetString("settings-music-volume");
    }
    /// <summary>
    /// Mute when in background
    /// </summary>
    public static string settings_mute_background()
    {
        return GetString("settings-mute-background");
    }
    /// <summary>
    /// Failed to initialize audio interface.
    /// </summary>
    public static string error_audio_interface_init()
    {
        return GetString("error-audio-interface-init");
    }
    /// <summary>
    /// Output API
    /// </summary>
    public static string settings_audio_output_api()
    {
        return GetString("settings-audio-output-api");
    }
    /// <summary>
    /// API used for audio output. Change if you are experiencing issues with sound.
    /// </summary>
    public static string settings_audio_output_api_description()
    {
        return GetString("settings-audio-output-api-description");
    }
    /// <summary>
    /// General
    /// </summary>
    public static string settings_fs_section_general()
    {
        return GetString("settings-fs-section-general");
    }
    /// <summary>
    /// Visuals
    /// </summary>
    public static string settings_fs_section_visuals()
    {
        return GetString("settings-fs-section-visuals");
    }
    /// <summary>
    /// Audio
    /// </summary>
    public static string settings_fs_section_audio()
    {
        return GetString("settings-fs-section-audio");
    }
    /// <summary>
    /// Layout
    /// </summary>
    public static string settings_fs_section_layout()
    {
        return GetString("settings-fs-section-layout");
    }
    /// <summary>
    /// Menus
    /// </summary>
    public static string settings_fs_section_menus()
    {
        return GetString("settings-fs-section-menus");
    }
    /// <summary>
    /// Input
    /// </summary>
    public static string settings_fs_section()
    {
        return GetString("settings-fs-section");
    }
    /// <summary>
    /// {$gameName} is starting…
    /// </summary>
    public static string game_is_starting(object gameName)
    {
        return GetString("game-is-starting", ("gameName", gameName));
    }
    /// <summary>
    /// {$gameName} is running…
    /// </summary>
    public static string game_is_running(object gameName)
    {
        return GetString("game-is-running", ("gameName", gameName));
    }
    /// <summary>
    /// Caps
    /// </summary>
    public static string text_input_capitalize()
    {
        return GetString("text-input-capitalize");
    }
    /// <summary>
    /// Space
    /// </summary>
    public static string text_input_space()
    {
        return GetString("text-input-space");
    }
    /// <summary>
    /// Image rendering scaler
    /// </summary>
    public static string settings_image_scaler_mode()
    {
        return GetString("settings-image-scaler-mode");
    }
    /// <summary>
    /// Alternative
    /// </summary>
    public static string settings_image_scaling_alternative()
    {
        return GetString("settings-image-scaling-alternative");
    }
    /// <summary>
    /// Balanced
    /// </summary>
    public static string settings_image_scaling_balanced()
    {
        return GetString("settings-image-scaling-balanced");
    }
    /// <summary>
    /// Quality
    /// </summary>
    public static string settings_image_scaling_quality()
    {
        return GetString("settings-image-scaling-quality");
    }
    /// <summary>
    /// Quality:
    /// Best image quality, slow, high memory usage.
    /// 
    /// Balanced:
    /// Good quality, fast, low memory usage.
    /// 
    /// Alternative:
    /// Better quality, medium speed, low memory usage.
    /// </summary>
    public static string settings_image_scaler_mode_tooltip()
    {
        return GetString("settings-image-scaler-mode-tooltip");
    }
    /// <summary>
    /// Select file…
    /// </summary>
    public static string select_file_tooltip()
    {
        return GetString("select-file-tooltip");
    }
    /// <summary>
    /// Select folder…
    /// </summary>
    public static string select_directory_tooltip()
    {
        return GetString("select-directory-tooltip");
    }
    /// <summary>
    /// Startup script
    /// </summary>
    public static string startup_script()
    {
        return GetString("startup-script");
    }
    /// <summary>
    /// Please note that both extensions and themes can greatly affect Playnite's performance, stability and security.
    /// 
    /// If you start experiencing some issues after installing a theme or an extension, try disabling/uninstalling them first to see if they are root of the issue.
    /// </summary>
    public static string addon_perf_notice()
    {
        return GetString("addon-perf-notice");
    }
    /// <summary>
    /// Choose on startup
    /// </summary>
    public static string game_action_select_on_start()
    {
        return GetString("game-action-select-on-start");
    }
    /// <summary>
    /// Choose on startup
    /// </summary>
    public static string emulator_select_on_start()
    {
        return GetString("emulator-select-on-start");
    }
    /// <summary>
    /// Built-in profiles
    /// </summary>
    public static string emulator_built_in_profiles()
    {
        return GetString("emulator-built-in-profiles");
    }
    /// <summary>
    /// Built-in profile
    /// </summary>
    public static string emulator_built_in_profile()
    {
        return GetString("emulator-built-in-profile");
    }
    /// <summary>
    /// Custom profiles
    /// </summary>
    public static string emulator_custom_profiles()
    {
        return GetString("emulator-custom-profiles");
    }
    /// <summary>
    /// Custom profile
    /// </summary>
    public static string emulator_custom_profile()
    {
        return GetString("emulator-custom-profile");
    }
    /// <summary>
    /// Handled by a built-in script
    /// </summary>
    public static string emulator_function_handled_by_script()
    {
        return GetString("emulator-function-handled-by-script");
    }
    /// <summary>
    /// Emulator specification
    /// </summary>
    public static string emulator_spec()
    {
        return GetString("emulator-spec");
    }
    /// <summary>
    /// Platform specification
    /// </summary>
    public static string platform_spec()
    {
        return GetString("platform-spec");
    }
    /// <summary>
    /// Region specification
    /// </summary>
    public static string region_spec()
    {
        return GetString("region-spec");
    }
    /// <summary>
    /// Execute before starting emulator
    /// </summary>
    public static string emulator_pre_script_description()
    {
        return GetString("emulator-pre-script-description");
    }
    /// <summary>
    /// Execute after emulator is started
    /// </summary>
    public static string emulator_post_script_description()
    {
        return GetString("emulator-post-script-description");
    }
    /// <summary>
    /// Execute after exiting emulator
    /// </summary>
    public static string emulator_started_script_description()
    {
        return GetString("emulator-started-script-description");
    }
    /// <summary>
    /// Emulator executable not found.
    /// </summary>
    public static string error_emulator_executable_not_found()
    {
        return GetString("error-emulator-executable-not-found");
    }
    /// <summary>
    /// Emulator specification not found.
    /// </summary>
    public static string error_emulator_specification_not_found()
    {
        return GetString("error-emulator-specification-not-found");
    }
    /// <summary>
    /// Emulator startup script not found.
    /// </summary>
    public static string error_emulator_startup_script_not_found()
    {
        return GetString("error-emulator-startup-script-not-found");
    }
    /// <summary>
    /// Split as separate games
    /// </summary>
    public static string split_emu_import_split_games()
    {
        return GetString("split-emu-import-split-games");
    }
    /// <summary>
    /// Merge into one game
    /// </summary>
    public static string split_emu_import_merge_games()
    {
        return GetString("split-emu-import-merge-games");
    }
    /// <summary>
    /// Set platform
    /// </summary>
    public static string emu_import_assign_platform()
    {
        return GetString("emu-import-assign-platform");
    }
    /// <summary>
    /// Set region
    /// </summary>
    public static string emu_import_assign_region()
    {
        return GetString("emu-import-assign-region");
    }
    /// <summary>
    /// Scan folder
    /// </summary>
    public static string emu_scan_directory()
    {
        return GetString("emu-scan-directory");
    }
    /// <summary>
    /// Scan configurations
    /// </summary>
    public static string emu_scan_configurations()
    {
        return GetString("emu-scan-configurations");
    }
    /// <summary>
    /// Exclude patterns from checksum scan
    /// </summary>
    public static string emu_crc_exclude_file_types()
    {
        return GetString("emu-crc-exclude-file-types");
    }
    /// <summary>
    /// Files matching specified pattern(s) won't be scanned for checksum and will be matched by file name. See emulator help page for more information.
    /// </summary>
    public static string emu_crc_exclude_file_types_tooltip()
    {
        return GetString("emu-crc-exclude-file-types-tooltip");
    }
    /// <summary>
    /// Scan with emulator
    /// </summary>
    public static string emu_scan_emulator()
    {
        return GetString("emu-scan-emulator");
    }
    /// <summary>
    /// Name has to be set when saving new configuration.
    /// </summary>
    public static string scan_config_name_error()
    {
        return GetString("scan-config-name-error");
    }
    /// <summary>
    /// Emulator or emulator profile is not set.
    /// </summary>
    public static string scan_config_no_emulator_error()
    {
        return GetString("scan-config-no-emulator-error");
    }
    /// <summary>
    /// Directory to scan is not specified or it doesn't exist.
    /// </summary>
    public static string scan_config_directory_error()
    {
        return GetString("scan-config-directory-error");
    }
    /// <summary>
    /// Scan configuration is not set properly.
    /// </summary>
    public static string scan_config_error()
    {
        return GetString("scan-config-error");
    }
    /// <summary>
    /// Include in bulk scan auto-scan
    /// </summary>
    public static string emu_scan_include_global_update()
    {
        return GetString("emu-scan-include-global-update");
    }
    /// <summary>
    /// Failed to scan folder for emulators.
    /// </summary>
    public static string emulator_scan_failed()
    {
        return GetString("emulator-scan-failed");
    }
    /// <summary>
    /// Failed to scan folder(s) for emulated games.
    /// </summary>
    public static string emulated_game_scan_failed()
    {
        return GetString("emulated-game-scan-failed");
    }
    /// <summary>
    /// Hide imported
    /// </summary>
    public static string emu_scan_hide_imported()
    {
        return GetString("emu-scan-hide-imported");
    }
    /// <summary>
    /// Profiles to import:
    /// </summary>
    public static string emu_import_profiles_to_import_header()
    {
        return GetString("emu-import-profiles-to-import-header");
    }
    /// <summary>
    /// Auto-scan configurations
    /// </summary>
    public static string emu_auto_scan_configurations()
    {
        return GetString("emu-auto-scan-configurations");
    }
    /// <summary>
    /// Save as auto-scan configuration
    /// </summary>
    public static string emu_save_scan_config()
    {
        return GetString("emu-save-scan-config");
    }
    /// <summary>
    /// Saves configuration for later use during library update. Saved configurations can be managed via "Configure Emulators" menu.
    /// </summary>
    public static string emu_save_scan_config_tooltip()
    {
        return GetString("emu-save-scan-config-tooltip");
    }
    /// <summary>
    /// Import using relative paths
    /// </summary>
    public static string emu_import_with_relative_paths()
    {
        return GetString("emu-import-with-relative-paths");
    }
    /// <summary>
    /// If possible import game files using paths relative to Playnite's installation folder or emulator's installation folder.
    /// </summary>
    public static string emu_import_with_relative_paths_tooltip()
    {
        return GetString("emu-import-with-relative-paths-tooltip");
    }
    /// <summary>
    /// Scan sub-folders
    /// </summary>
    public static string emu_import_scan_subfolders()
    {
        return GetString("emu-import-scan-subfolders");
    }
    /// <summary>
    /// Scan inside archives
    /// </summary>
    public static string emu_import_scan_inside_archives()
    {
        return GetString("emu-import-scan-inside-archives");
    }
    /// <summary>
    /// Merge related files
    /// </summary>
    public static string emu_merge_related_files()
    {
        return GetString("emu-merge-related-files");
    }
    /// <summary>
    /// Merge related game files, like individual game discs, under one game entry.
    /// </summary>
    public static string emu_merge_related_files_tooltip()
    {
        return GetString("emu-merge-related-files-tooltip");
    }
    /// <summary>
    /// Add scanner
    /// </summary>
    public static string emu_add_scanner()
    {
        return GetString("emu-add-scanner");
    }
    /// <summary>
    /// Add saved scanner
    /// </summary>
    public static string emu_add_saved_scanner()
    {
        return GetString("emu-add-saved-scanner");
    }
    /// <summary>
    /// Start scan
    /// </summary>
    public static string start_scan()
    {
        return GetString("start-scan");
    }
    /// <summary>
    /// Add scan configuration(s) with emulators to scan specific folders. Make sure that emulators are properly configured prior to importing games (via Library -> Configure Emulators menu).
    /// </summary>
    public static string emu_import_directory_config_desc()
    {
        return GetString("emu-import-directory-config-desc");
    }
    /// <summary>
    /// Default status assigned to newly added games
    /// </summary>
    public static string completion_status_default_status_desc()
    {
        return GetString("completion-status-default-status-desc");
    }
    /// <summary>
    /// Status assigned to games played for the first time
    /// </summary>
    public static string completion_status_played_status_desc()
    {
        return GetString("completion-status-played-status-desc");
    }
    /// <summary>
    /// Failed to initialize PowerShell script runtime. If you are Windows 7 user, try (re)installing PowerShell 5.1 to fix the issue.
    /// </summary>
    public static string power_shell_creation_error()
    {
        return GetString("power-shell-creation-error");
    }
    /// <summary>
    /// Filter preset with specified name already exists. Update preset with new settings?
    /// </summary>
    public static string filter_preset_name_conflict()
    {
        return GetString("filter-preset-name-conflict");
    }
    /// <summary>
    /// Automatically fill sorting name for batch-added games
    /// </summary>
    public static string sorting_name_autofill()
    {
        return GetString("sorting-name-autofill");
    }
    /// <summary>
    /// When you add games via a library update, an emulator folder scan, or a normal folder scan, automatically fill the "Sorting Name" field with a better sortable representation of the game's name, for example "The Witcher 3" will get a Sorting Name of "Witcher 03"
    /// </summary>
    public static string sorting_name_autofill_tooltip()
    {
        return GetString("sorting-name-autofill-tooltip");
    }
    /// <summary>
    /// These words will be removed from the start of the automatically filled Sorting Name value:
    /// </summary>
    public static string sorting_name_removed_articles()
    {
        return GetString("sorting-name-removed-articles");
    }
    /// <summary>
    /// Use this for ignoring words at the start of a string for sorting purposes. The default is "The", "An", and "A".
    /// </summary>
    public static string sorting_name_removed_articles_tooltip()
    {
        return GetString("sorting-name-removed-articles-tooltip");
    }
    /// <summary>
    /// Fill Sorting Name for games without one
    /// </summary>
    public static string sorting_name_autofill_button()
    {
        return GetString("sorting-name-autofill-button");
    }
    /// <summary>
    /// Sorting
    /// </summary>
    public static string settings_sorting_label()
    {
        return GetString("settings-sorting-label");
    }
    /// <summary>
    /// Filling Sorting Name values…
    /// </summary>
    public static string sorting_name_autofill_progress()
    {
        return GetString("sorting-name-autofill-progress");
    }
    /// <summary>
    /// Nahimic service has been detected to be running on your system. This service is known to cause rendering issues to Playnite (and other apps).
    /// 
    /// If you encounter any graphics corruption or other rendering issues in Playnite, we recommend disabling or completely uninstalling Nahimic service.
    /// 
    /// More information at https://playnite.link/nahimicsucks
    /// </summary>
    public static string nahimic_service_warning()
    {
        return GetString("nahimic-service-warning");
    }
    /// <summary>
    /// Playnite is running with elevated privileges (as an administrator). This is not recommended since it gives elevated privileges to all installed extensions and all games/apps started from Playnite!
    /// 
    /// More information at https://playnite.link/adminfaq
    /// </summary>
    public static string elevated_process_warning()
    {
        return GetString("elevated-process-warning");
    }
    /// <summary>
    /// Show warning if Playnite is running with elevated privileges
    /// </summary>
    public static string elevated_process_warning_show_option()
    {
        return GetString("elevated-process-warning-show-option");
    }
    /// <summary>
    /// Get the real size on drive when calculating the size of games
    /// </summary>
    public static string install_size_scan_use_size_on_disk_option()
    {
        return GetString("install-size-scan-use-size-on-disk-option");
    }
    /// <summary>
    /// If enabled, scans will be slower and will get the real size that files use in the drive.
    /// If disabled, scans will be faster and will use the size of the files themselves.
    /// </summary>
    public static string install_size_scan_use_size_on_disk_option_tooltip()
    {
        return GetString("install-size-scan-use-size-on-disk-option-tooltip");
    }
    /// <summary>
    /// Following add-on(s) have been reported as potentially problematic, either due to high stability/performance impact or security issues. We strongly recommend that you uninstall them:
    /// 
    /// {$addonNames}
    /// </summary>
    public static string warning_blacklisted_extensions(object addonNames)
    {
        return GetString("warning-blacklisted-extensions", ("addonNames", addonNames));
    }
    /// <summary>
    /// Exclude online files from scan
    /// </summary>
    public static string emu_exclude_online_files()
    {
        return GetString("emu-exclude-online-files");
    }
    /// <summary>
    /// Files stored on cloud storage won't be scanned and imported if not available locally.
    /// Supported only for: Google Drive, DropBox, OneDrive
    /// </summary>
    public static string emu_exclude_online_files_tooltip()
    {
        return GetString("emu-exclude-online-files-tooltip");
    }
    /// <summary>
    /// Scan but using simplified method without file content
    /// </summary>
    public static string emu_use_simplified_online_file_scan()
    {
        return GetString("emu-use-simplified-online-file-scan");
    }
    /// <summary>
    /// Files will be imported but using less accurate method that doesn't require file content to be downloaded and present locally.
    /// </summary>
    public static string emu_use_simplified_online_file_scan_tooltip()
    {
        return GetString("emu-use-simplified-online-file-scan-tooltip");
    }
    /// <summary>
    /// Apply to all
    /// </summary>
    public static string metadata_set_all_fields_to_value()
    {
        return GetString("metadata-set-all-fields-to-value");
    }
    /// <summary>
    /// Override installation state
    /// </summary>
    public static string override_install_state()
    {
        return GetString("override-install-state");
    }
    /// <summary>
    /// When set, Playnite will ignore installation state (including installation directory) set by the integration plugin that imports this game.
    /// 
    /// This option may not fully work with plugins that use specific game import method unless they also take this override option into account.
    /// </summary>
    public static string override_install_state_tooltip()
    {
        return GetString("override-install-state-tooltip");
    }
    /// <summary>
    /// Only manually
    /// </summary>
    public static string option_only_manually()
    {
        return GetString("option-only-manually");
    }
    /// <summary>
    /// Once a day
    /// </summary>
    public static string option_once_a_day()
    {
        return GetString("option-once-a-day");
    }
    /// <summary>
    /// Once a week
    /// </summary>
    public static string option_once_a_week()
    {
        return GetString("option-once-a-week");
    }
    /// <summary>
    /// On every startup
    /// </summary>
    public static string option_on_every_startup()
    {
        return GetString("option-on-every-startup");
    }
    /// <summary>
    /// Check for program updates
    /// </summary>
    public static string check_program_updates()
    {
        return GetString("check-program-updates");
    }
    /// <summary>
    /// Check for add-on updates
    /// </summary>
    public static string check_addon_updates()
    {
        return GetString("check-addon-updates");
    }
    /// <summary>
    /// Update libraries
    /// </summary>
    public static string check_library_updates()
    {
        return GetString("check-library-updates");
    }
    /// <summary>
    /// Scan emulation folders
    /// </summary>
    public static string check_emulated_library_updates()
    {
        return GetString("check-emulated-library-updates");
    }
    /// <summary>
    /// Include hidden games
    /// </summary>
    public static string stats_include_hidden()
    {
        return GetString("stats-include-hidden");
    }
    /// <summary>
    /// Edit fields
    /// </summary>
    public static string menu_set_fields()
    {
        return GetString("menu-set-fields");
    }
    /// <summary>
    /// Select / Deselect all
    /// </summary>
    public static string item_selection_select_deselect_all()
    {
        return GetString("item-selection-select-deselect-all");
    }
    /// <summary>
    /// Open
    /// </summary>
    public static string open()
    {
        return GetString("open");
    }
    /// <summary>
    /// Activate
    /// </summary>
    public static string activate()
    {
        return GetString("activate");
    }
    /// <summary>
    /// Assign
    /// </summary>
    public static string assign()
    {
        return GetString("assign");
    }
    /// <summary>
    /// Start typing to search for games… [F1] for help
    /// </summary>
    public static string default_search_description()
    {
        return GetString("default-search-description");
    }
    /// <summary>
    /// Starting with # brings up a list of available commands.
    /// Starting with / brings up a list of available search providers/plugins.
    /// Typing search keyword and ending with SPACE switches immediately to that search.
    /// 
    /// TAB: switch action
    /// ENTER: activate selected action
    /// SHIFT-ENTER: open item menu
    /// </summary>
    public static string default_search_hint()
    {
        return GetString("default-search-hint");
    }
    /// <summary>
    /// Include uninstalled games
    /// </summary>
    public static string search_filter_uninstalled()
    {
        return GetString("search-filter-uninstalled");
    }
    /// <summary>
    /// Include hidden games
    /// </summary>
    public static string search_filter_hidden()
    {
        return GetString("search-filter-hidden");
    }
    /// <summary>
    /// Uninstalled games included
    /// </summary>
    public static string search_filter_uninstalled_included()
    {
        return GetString("search-filter-uninstalled-included");
    }
    /// <summary>
    /// Uninstalled games excluded
    /// </summary>
    public static string search_filter_uninstalled_excluded()
    {
        return GetString("search-filter-uninstalled-excluded");
    }
    /// <summary>
    /// Hidden games included
    /// </summary>
    public static string search_filter_hidden_included()
    {
        return GetString("search-filter-hidden-included");
    }
    /// <summary>
    /// Hidden games excluded
    /// </summary>
    public static string search_filter_hidden_excluded()
    {
        return GetString("search-filter-hidden-excluded");
    }
    /// <summary>
    /// Play or Install
    /// </summary>
    public static string game_search_item_action_play()
    {
        return GetString("game-search-item-action-play");
    }
    /// <summary>
    /// Go to details
    /// </summary>
    public static string game_search_item_action_switch_to()
    {
        return GetString("game-search-item-action-switch-to");
    }
    /// <summary>
    /// Game menu
    /// </summary>
    public static string game_search_item_action_open_menu()
    {
        return GetString("game-search-item-action-open-menu");
    }
    /// <summary>
    /// Edit game
    /// </summary>
    public static string game_search_item_action_edit()
    {
        return GetString("game-search-item-action-edit");
    }
    /// <summary>
    /// Open search
    /// </summary>
    public static string open_search()
    {
        return GetString("open-search");
    }
    /// <summary>
    /// Search box
    /// </summary>
    public static string top_panel_search_box()
    {
        return GetString("top-panel-search-box");
    }
    /// <summary>
    /// Search button
    /// </summary>
    public static string top_panel_search_button()
    {
        return GetString("top-panel-search-button");
    }
    /// <summary>
    /// Primary game action
    /// </summary>
    public static string search_settings_primary_action()
    {
        return GetString("search-settings-primary-action");
    }
    /// <summary>
    /// Secondary game action
    /// </summary>
    public static string search_settings_secondary_action()
    {
        return GetString("search-settings-secondary-action");
    }
    /// <summary>
    /// CTRL-F opens global search instead of focusing search box
    /// </summary>
    public static string search_settings_keyboard_open_search()
    {
        return GetString("search-settings-keyboard-open-search");
    }
    /// <summary>
    /// Save game filter settings between search sessions
    /// </summary>
    public static string search_settings_save_filter()
    {
        return GetString("search-settings-save-filter");
    }
    /// <summary>
    /// Search providers
    /// </summary>
    public static string search_settings_search_providers()
    {
        return GetString("search-settings-search-providers");
    }
    /// <summary>
    /// Default keyword
    /// </summary>
    public static string search_settings_default_keyword()
    {
        return GetString("search-settings-default-keyword");
    }
    /// <summary>
    /// Custom keyword
    /// </summary>
    public static string search_settings_custom_keyword()
    {
        return GetString("search-settings-custom-keyword");
    }
    /// <summary>
    /// System wide shortcut
    /// </summary>
    public static string search_settings_system_wide_shortcut()
    {
        return GetString("search-settings-system-wide-shortcut");
    }
    /// <summary>
    /// Playnite search
    /// </summary>
    public static string search_title()
    {
        return GetString("search-title");
    }
    /// <summary>
    /// Extension Settings
    /// </summary>
    public static string extension_settings_menu()
    {
        return GetString("extension-settings-menu");
    }
    /// <summary>
    /// Exclusions
    /// </summary>
    public static string exclusions()
    {
        return GetString("exclusions");
    }
    /// <summary>
    /// Excluded files relative to scan folder
    /// </summary>
    public static string emu_scanner_excluded_files()
    {
        return GetString("emu-scanner-excluded-files");
    }
    /// <summary>
    /// Excluded folders relative to scan folder
    /// </summary>
    public static string emu_scanner_excluded_folders()
    {
        return GetString("emu-scanner-excluded-folders");
    }
    /// <summary>
    /// Add file to exclusion list
    /// </summary>
    public static string emu_import_add_rom_exclusion_list()
    {
        return GetString("emu-import-add-rom-exclusion-list");
    }
    /// <summary>
    /// Add folder to exclusion list
    /// </summary>
    public static string emu_import_add_folder_exclusion_list()
    {
        return GetString("emu-import-add-folder-exclusion-list");
    }
    /// <summary>
    /// Exclusions can be only added to saved scanner configurations.
    /// </summary>
    public static string emu_exclusion_no_config_error()
    {
        return GetString("emu-exclusion-no-config-error");
    }
    /// <summary>
    /// Exclusions have been added to "{$scannerName}" scanner.
    /// </summary>
    public static string emu_exclusion_added_message(object scannerName)
    {
        return GetString("emu-exclusion-added-message", ("scannerName", scannerName));
    }
    /// <summary>
    /// Override platform
    /// </summary>
    public static string emu_override_platform()
    {
        return GetString("emu-override-platform");
    }
    /// <summary>
    /// When set, scanner will assign this platform to all games, overwriting any automatically detected platforms.
    /// </summary>
    public static string emu_override_platform_tooltip()
    {
        return GetString("emu-override-platform-tooltip");
    }
    /// <summary>
    /// Include commands in default search
    /// </summary>
    public static string search_include_commands_in_default()
    {
        return GetString("search-include-commands-in-default");
    }
    /// <summary>
    /// When disabled, commands won't be included in default search until # prefix is used.
    /// </summary>
    public static string search_include_commands_in_default_tooltip()
    {
        return GetString("search-include-commands-in-default-tooltip");
    }
    /// <summary>
    /// Use fuzzy matching in name filter
    /// </summary>
    public static string name_filter_use_fuzzy_matching()
    {
        return GetString("name-filter-use-fuzzy-matching");
    }
    /// <summary>
    /// When enabled, name filter will match game names the same way as global search.
    /// Strict matching can be enforced on an individual case by prefixing filter with ! character.
    /// </summary>
    public static string name_filter_use_fuzzy_matching_tooltip()
    {
        return GetString("name-filter-use-fuzzy-matching-tooltip");
    }
    /// <summary>
    /// Fields to be displayed for game results:
    /// </summary>
    public static string search_view_game_field_options()
    {
        return GetString("search-view-game-field-options");
    }
    /// <summary>
    /// Hidden Status
    /// </summary>
    public static string hidden_status()
    {
        return GetString("hidden-status");
    }
    /// <summary>
    /// Data backup was cancelled.
    /// </summary>
    public static string backup_cancelled()
    {
        return GetString("backup-cancelled");
    }
    /// <summary>
    /// Data backup failed.
    /// </summary>
    public static string backup_failed()
    {
        return GetString("backup-failed");
    }
    /// <summary>
    /// Data backup error
    /// </summary>
    public static string backup_error_title()
    {
        return GetString("backup-error-title");
    }
    /// <summary>
    /// Data backup in progress…
    /// </summary>
    public static string backup_progress()
    {
        return GetString("backup-progress");
    }
    /// <summary>
    /// Restoring data from backup…
    /// </summary>
    public static string backup_restore_progress()
    {
        return GetString("backup-restore-progress");
    }
    /// <summary>
    /// Failed to restore data from backup.
    /// </summary>
    public static string backup_restore_failed()
    {
        return GetString("backup-restore-failed");
    }
    /// <summary>
    /// Settings
    /// </summary>
    public static string backup_option_settings()
    {
        return GetString("backup-option-settings");
    }
    /// <summary>
    /// Game library
    /// </summary>
    public static string backup_option_library()
    {
        return GetString("backup-option-library");
    }
    /// <summary>
    /// Game library media
    /// </summary>
    public static string backup_option_game_media()
    {
        return GetString("backup-option-game-media");
    }
    /// <summary>
    /// Installed extensions
    /// </summary>
    public static string backup_option_extensions()
    {
        return GetString("backup-option-extensions");
    }
    /// <summary>
    /// Extensions data
    /// </summary>
    public static string backup_option_extensions_data()
    {
        return GetString("backup-option-extensions-data");
    }
    /// <summary>
    /// Installed themes
    /// </summary>
    public static string backup_option_themes()
    {
        return GetString("backup-option-themes");
    }
    /// <summary>
    /// Select data to be restored from specified backup file.
    /// 
    /// Playnite will automatically restart to start backup restore process.
    /// </summary>
    public static string backup_restore_message()
    {
        return GetString("backup-restore-message");
    }
    /// <summary>
    /// Select items to be included with data backup. Application settings and game library data are included by default.
    /// 
    /// Playnite will automatically restart to start backup process.
    /// </summary>
    public static string backup_data_backup_message()
    {
        return GetString("backup-data-backup-message");
    }
    /// <summary>
    /// Automatic data backup
    /// </summary>
    public static string settings_enable_automatic_backup()
    {
        return GetString("settings-enable-automatic-backup");
    }
    /// <summary>
    /// Auto backup frequency
    /// </summary>
    public static string settings_auto_backup_frequency()
    {
        return GetString("settings-auto-backup-frequency");
    }
    /// <summary>
    /// Backup folder
    /// </summary>
    public static string settings_backup_folder()
    {
        return GetString("settings-backup-folder");
    }
    /// <summary>
    /// Rotating backups
    /// </summary>
    public static string settings_rotating_backups()
    {
        return GetString("settings-rotating-backups");
    }
    /// <summary>
    /// Include additional data:
    /// </summary>
    public static string settings_auto_backup_include_items()
    {
        return GetString("settings-auto-backup-include-items");
    }
    /// <summary>
    /// Backup folder needs to be set if auto backup is enabled.
    /// </summary>
    public static string settings_no_backup_dir_specified_error()
    {
        return GetString("settings-no-backup-dir-specified-error");
    }
    /// <summary>
    /// Show notifications for patch releases only
    /// </summary>
    public static string update_notify_only_patches()
    {
        return GetString("update-notify-only-patches");
    }
    /// <summary>
    /// When enabled, only updates available for currently installed major release will result in update notification.
    /// New major releases will not result in update notification.
    /// </summary>
    public static string update_notify_only_patches_tooltip()
    {
        return GetString("update-notify-only-patches-tooltip");
    }
    /// <summary>
    /// Use relative dates for the past week
    /// </summary>
    public static string settings_past_week_relative_format()
    {
        return GetString("settings-past-week-relative-format");
    }
    /// <summary>
    /// Use relative dates in "Today", "Yesterday" etc. format if the date is less than a week old.
    /// 
    /// The specified date format will be used for all other dates.
    /// </summary>
    public static string settings_past_week_relative_format_tooltip()
    {
        return GetString("settings-past-week-relative-format-tooltip");
    }
    /// <summary>
    /// Web image search
    /// </summary>
    public static string settings_web_image_search()
    {
        return GetString("settings-web-image-search");
    }
    /// <summary>
    /// Icon image search string
    /// </summary>
    public static string settings_web_image_search_icon_term()
    {
        return GetString("settings-web-image-search-icon-term");
    }
    /// <summary>
    /// Cover image search string
    /// </summary>
    public static string settings_web_image_search_cover_term()
    {
        return GetString("settings-web-image-search-cover-term");
    }
    /// <summary>
    /// Background image search string
    /// </summary>
    public static string settings_web_image_search_background()
    {
        return GetString("settings-web-image-search-background");
    }
    /// <summary>
    /// Getting add-on information…
    /// </summary>
    public static string settings_addon_information()
    {
        return GetString("settings-addon-information");
    }
    /// <summary>
    /// No metadata source is available
    /// </summary>
    public static string no_metadata_source()
    {
        return GetString("no-metadata-source");
    }
    /// <summary>
    /// Play action settings
    /// </summary>
    public static string scanner_config_play_action_settings()
    {
        return GetString("scanner-config-play-action-settings");
    }
    /// <summary>
    /// Use scanner settings
    /// </summary>
    public static string scanner_config_play_action_settings_scanner()
    {
        return GetString("scanner-config-play-action-settings-scanner");
    }
    /// <summary>
    /// Select profile on startup
    /// </summary>
    public static string scanner_config_play_action_settings_select_profile()
    {
        return GetString("scanner-config-play-action-settings-select-profile");
    }
    /// <summary>
    /// Select emulator on startup
    /// </summary>
    public static string scanner_config_play_action_settings_select_emulator()
    {
        return GetString("scanner-config-play-action-settings-select-emulator");
    }
    /// <summary>
    /// Automatic
    /// </summary>
    public static string automatic()
    {
        return GetString("automatic");
    }
    /// <summary>
    /// Always on
    /// </summary>
    public static string always_on()
    {
        return GetString("always-on");
    }
    /// <summary>
    /// Always off
    /// </summary>
    public static string always_off()
    {
        return GetString("always-off");
    }
    /// <summary>
    /// Accessibility (screen reader) support
    /// </summary>
    public static string settings_accessibility_interface()
    {
        return GetString("settings-accessibility-interface");
    }
    /// <summary>
    /// Application menu
    /// </summary>
    public static string application_menu()
    {
        return GetString("application-menu");
    }
    /// <summary>
    /// Game menu
    /// </summary>
    public static string game_menu()
    {
        return GetString("game-menu");
    }
    /// <summary>
    /// Program folder
    /// </summary>
    public static string program_folder()
    {
        return GetString("program-folder");
    }
    /// <summary>
    /// User data directory
    /// </summary>
    public static string user_data_folder()
    {
        return GetString("user-data-folder");
    }
    /// <summary>
    /// Library file corruption has been detected, Playnite will now shutdown.
    /// 
    /// Open new issue on Playnite's GitHub page with a request to fix corruption in your files.
    /// </summary>
    public static string db_corruption_crash_message()
    {
        return GetString("db-corruption-crash-message");
    }
    /// <summary>
    /// Not Played
    /// </summary>
    public static string completion_not_played()
    {
        return GetString("completion-not-played");
    }
    /// <summary>
    /// Played
    /// </summary>
    public static string completion_played()
    {
        return GetString("completion-played");
    }
    /// <summary>
    /// Beaten
    /// </summary>
    public static string completion_beaten()
    {
        return GetString("completion-beaten");
    }
    /// <summary>
    /// Completed
    /// </summary>
    public static string completion_completed()
    {
        return GetString("completion-completed");
    }
    /// <summary>
    /// Playing
    /// </summary>
    public static string completion_playing()
    {
        return GetString("completion-playing");
    }
    /// <summary>
    /// Abandoned
    /// </summary>
    public static string completion_abandoned()
    {
        return GetString("completion-abandoned");
    }
    /// <summary>
    /// On Hold
    /// </summary>
    public static string completion_on_hold()
    {
        return GetString("completion-on-hold");
    }
    /// <summary>
    /// Plan to Play
    /// </summary>
    public static string completion_plan_to_play()
    {
        return GetString("completion-plan-to-play");
    }
}
