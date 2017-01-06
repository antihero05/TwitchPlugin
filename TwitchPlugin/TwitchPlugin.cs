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

        #region Skin Definition

        /// <summary>
        /// This region is providing the necessary properties for skin controls.
        /// </summary>

        [SkinControlAttribute(50)]
        public GUIFacadeControl guiFacadeControl = null;

        #endregion Skin Definition

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

        protected override void OnPageLoad()
        {
            guiFacadeControl.CurrentLayout = GUIFacadeControl.Layout.CoverFlow;
            //guiFacadeControl.CurrentLayout = GUIFacadeControl.Layout.Filmstrip;
            //guiFacadeControl.CurrentLayout = GUIFacadeControl.Layout.LargeIcons;
            //guiFacadeControl.CurrentLayout = GUIFacadeControl.Layout.List;
            //guiFacadeControl.CurrentLayout = GUIFacadeControl.Layout.SmallIcons;
            GUIListItem guiItem1 = new GUIListItem("Item1");
            guiItem1.Label = "Testlabel 1";
            guiItem1.ThumbnailImage = Config.GetFolder(Config.Dir.Skin) + @"\Titan\Media\image1.jpg";
            guiFacadeControl.Add(guiItem1);
            GUIListItem guiItem2 = new GUIListItem("Item2");
            guiItem2.Label = "Testlabel 2";
            guiItem2.ThumbnailImage = Config.GetFolder(Config.Dir.Skin) + @"\Titan\Media\image2.jpg";
            guiFacadeControl.Add(guiItem2);
        }

        #endregion
    }
}
