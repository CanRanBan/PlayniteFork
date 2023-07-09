using Playnite.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Playnite.SDK.Plugins
{
    

    /// <summary>
    /// Represents installation controller.
    /// </summary>
    public abstract class InstallController : ControllerBase
    {
        internal event EventHandler<GameInstalledEventArgs> Installed;

        /// <summary>
        /// Creates new instance of <see cref="InstallController"/>.
        /// </summary>
        /// <param name="game"></param>
        public InstallController(Game game) : base(game)
        {
        }

        /// <summary>
        /// Start installation.
        /// </summary>
        public abstract void Install(InstallActionArgs args);

        /// <summary>
        /// Invoke to signal that installation completed.
        /// </summary>
        /// <param name="args"></param>
        protected void InvokeOnInstalled(GameInstalledEventArgs args)
        {
            args.Source = this;
            execContext.Send((a) => Installed?.Invoke(this, args), null);
        }
    }

    /// <summary>
    /// Represents uninstallation controller.
    /// </summary>
    public abstract class UninstallController : ControllerBase
    {
        internal event EventHandler<GameUninstalledEventArgs> Uninstalled;

        /// <summary>
        /// Creates new instance of <see cref="UninstallController"/>.
        /// </summary>
        /// <param name="game"></param>
        public UninstallController(Game game) : base(game)
        {
        }

        /// <summary>
        /// Start uninstallation.
        /// </summary>
        public abstract void Uninstall(UninstallActionArgs args);

        /// <summary>
        /// Invoke to signal that uninstallation completed.
        /// </summary>
        /// <param name="args"></param>
        protected void InvokeOnUninstalled(GameUninstalledEventArgs args)
        {
            args.Source = this;
            execContext.Send((a) => Uninstalled?.Invoke(this, args), null);
        }

        /// <summary>
        /// Invoke to signal that uninstallation completed.
        /// </summary>
        protected void InvokeOnUninstalled()
        {
            InvokeOnUninstalled(new GameUninstalledEventArgs());
        }
    }

    /// <summary>
    /// Represents arguments for installation action.
    /// </summary>
    public class InstallActionArgs
    {
        /// <summary>
        ///
        /// </summary>
        public InstallActionArgs()
        {
        }
    }

    /// <summary>
    /// Represents arguments for uninstallation actions.
    /// </summary>
    public class UninstallActionArgs
    {
        /// <summary>
        ///
        /// </summary>
        public UninstallActionArgs()
        {
        }
    }

    /// <summary>
    /// Represents arguments for game uninstalled event.
    /// </summary>
    public class GameUninstalledEventArgs
    {
        internal UninstallController Source { get; set; }

        /// <summary>
        ///
        /// </summary>
        public GameUninstalledEventArgs()
        {
        }
    }

    /// <summary>
    /// Represents data for game installation.
    /// </summary>
    public class GameInstallationData
    {
        /// <summary>
        /// Gets or sets installation directory.
        /// </summary>
        public string InstallDirectory { get; set; }

        /// <summary>
        /// Gets or sets Roms.
        /// </summary>
        public List<GameRom> Roms { get; set; }
    }

    /// <summary>
    /// Represents arguments for game installed event.
    /// </summary>
    public class GameInstalledEventArgs
    {
        internal InstallController Source { get; set; }

        /// <summary>
        /// Gets or sets data for newly installed game.
        /// </summary>
        public GameInstallationData InstalledInfo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public GameInstalledEventArgs()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="installData"></param>
        public GameInstalledEventArgs(GameInstallationData installData)
        {
            InstalledInfo = installData;
        }
    }
}
