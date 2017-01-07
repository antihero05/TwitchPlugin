using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaPortal.Configuration;
using TwitchPlugin.WebAPI;

namespace TwitchPlugin.Container
{

    /// <summary>
    /// The class TwitchPlugin.Container.Thumb is the main implementation used for retrieving and providing thumbs based on information received from the Twitch API.
    /// </summary>

    public class Thumb
    {

        #region Enumerations

        public enum enuThumbType
        {
            cover,
            logo
        };

        #endregion Enumerations

        #region Declaration

        private string mBasePath = Config.GetFolder(Config.Dir.Thumbs);
        private enuThumbType mThumbType;
        private int mId;
        private string mRemoteLarge;
        private string mRemoteMedium;
        private string mRemoteSmall;
        private string mLocalLarge;
        private string mLocalMedium;
        private string mLocalSmall;

        #endregion Declaration

        #region Constructors

        public Thumb(GamesDataContract.top.game DataContract, enuThumbType ThumbType)
        {
            mThumbType = ThumbType;
            switch (mThumbType)
            {
                case enuThumbType.cover:
                    mRemoteLarge = DataContract.Box.Large;
                    mRemoteMedium = DataContract.Box.Medium;
                    mRemoteSmall = DataContract.Box.Small;
                    break;
                case enuThumbType.logo:
                    mRemoteLarge = DataContract.Logo.Large;
                    mRemoteMedium = DataContract.Logo.Medium;
                    mRemoteSmall = DataContract.Logo.Small;
                    break;
            }
            mId = DataContract.Id;
            Create();
        }

        #endregion Constructors

        #region Properties

        public int Id
        {
            get
            {
                return mId;
            }
        }

        public string Large
        {
            get
            {
                return mLocalLarge;
            }
        }

        public string Medium
        {
            get
            {
                return Medium;
            }
        }

        public string Small
        {
            get
            {
                return Small;
            }
        }

        #endregion Properties

        #region Methods

        private void Create()
        {
            CreatePath();
            CreateFile(mRemoteLarge, mLocalLarge);
            CreateFile(mRemoteMedium, mLocalMedium);
            CreateFile(mRemoteSmall, mLocalSmall);
        }

        private void CreatePath()
        {
            string Path = mBasePath + @"\TwitchPlugin\games\" + mThumbType.ToString() + @"\" + mId + @"\";
            CreateDirectory(Path);
            mLocalLarge = Path + "large.jpg";
            mLocalMedium = Path + "medium.jpg";
            mLocalSmall = Path + "small.jpg";
        }

        private void CreateDirectory(string Path)
        {
            if (!(Directory.Exists(Path)))
            {
                Directory.CreateDirectory(Path);
            }
        }

        private void CreateFile(string URL, string Path, bool Override = false)
        {
            if(!(File.Exists(Path)) || Override == true)
            {
                byte[] bytImage = RequestHandler.Request(URL, "image/jpeg");
                FileStream FileStream = new FileStream(Path, FileMode.Create, FileAccess.Write);
                FileStream.Write(bytImage, 0, bytImage.Length);
                FileStream.Close();
            }
        }

        public void Refresh()
        {
            CreateFile(mRemoteLarge, mLocalLarge, true);
            CreateFile(mRemoteMedium, mLocalMedium, true);
            CreateFile(mRemoteSmall, mLocalSmall, true);
        }

        public void Refresh(GamesDataContract.top.game DataContract)
        {
            switch (mThumbType)
            {
                case enuThumbType.cover:
                    mRemoteLarge = DataContract.Box.Large;
                    mRemoteMedium = DataContract.Box.Medium;
                    mRemoteSmall = DataContract.Box.Small;
                    break;
                case enuThumbType.logo:
                    mRemoteLarge = DataContract.Logo.Large;
                    mRemoteMedium = DataContract.Logo.Medium;
                    mRemoteSmall = DataContract.Logo.Small;
                    break;
            }
            CreateFile(mRemoteLarge, mLocalLarge, true);
            CreateFile(mRemoteMedium, mLocalMedium, true);
            CreateFile(mRemoteSmall, mLocalSmall, true);
        }

        #endregion Methods

    }
}