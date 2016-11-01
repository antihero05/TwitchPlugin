using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MediaPortal.Configuration;
using MediaPortal.GUI.Library;
using MediaPortal.Dialogs;

namespace TwitchPlugin
{

    [PluginIcons("TwitchPlugin.Resources.TwitchPluginEnabled.png", "TwitchPlugin.Resources.TwitchPluginDisabled.png")]

    public class TwitchPlugin : GUIWindow, ISetupForm
    {
        #region ISetupForm Members

        /// <summary>
        /// This region is providing the necessary attributes/methods required by Mediaportal for the plugin configuration.
        /// </summary>

        public string Author()
        {
            return "Max \"antihero05\" Wimmelbacher";
        }

        public bool CanEnable()
        {
            return true;
        }

        public string Description()
        {
            return "Plugin to integrate the stream platform Twitch.tv into Mediaportal.";
        }

        public bool DefaultEnabled()
        {
            return false;
        }

        public override bool Init()
        {
            return Load(GUIGraphicsContext.Skin + @"\TwitchPlugin.xml");
        }

        public bool GetHome(out string strButtonText, out string strButtonImage, out string strButtonImageFocus, out string strPictureImage)
        {
            strButtonText = this.PluginName();
            strButtonImage = string.Empty;
            strButtonImageFocus = string.Empty;
            strPictureImage = "hover_my twitchplugin.png";
            return true;
        }

        public int GetWindowId()
        {
            return 13371;
        }

        public bool HasSetup()
        {
            return false;
        }

        public string PluginName()
        {
            return "Twitch";
        }

        public void ShowPlugin()
        {
        }

        public override int GetID
        {
            get
            {
                return this.GetWindowId();
            }
            set
            {
            }
        }

        #endregion

        #region IPlugin Members

        /// <summary>
        /// This region is providing the necessary methods required by Mediaportal for interaction with the plugin.
        /// Configuration Loading and hooking on the events necessary to trigger plugin actions is done here.
        /// </summary>

        public void Start()
        {
            Log.Info("TwitchPlugin: Starting");
            Log.Info("TwitchPlugin: Started!");
        }

        public void Stop()
        {
            Log.Info("TwitchPlugin: Stopping");
            Log.Info("TwitchPlugin: Stopped!");
        }

        #endregion
    }
}
