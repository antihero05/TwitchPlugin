using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchPlugin.WebAPI;

namespace TwitchPlugin.Container
{

    /// <summary>
    /// The class TwitchPlugin.Container.Game is the main implementation used for retrieving and providing "Games" related objects from the Twitch API.
    /// </summary>

    public class Game
    {

        #region Declaration

        private int mId;
        private string mName;
        private int mViewers;
        private int mChannels;
        private Thumb mCoverThumb;
        private Thumb mLogoThumb;
        private List<Streams> mStreams;

        #endregion Declaration

        #region Constructors

        public Game(GamesDataContract DataContract, int EntryNumber)
        {
            mId = DataContract.Top[EntryNumber].Game.Id;
            mName = DataContract.Top[EntryNumber].Game.Name;
            mViewers = DataContract.Top[EntryNumber].Viewers;
            mChannels = DataContract.Top[EntryNumber].Viewers;
            mCoverThumb = new Thumb(DataContract.Top[EntryNumber].Game, Thumb.enuThumbType.cover);
            mLogoThumb = new Thumb(DataContract.Top[EntryNumber].Game, Thumb.enuThumbType.logo);
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

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public int Viewers
        {
            get
            {
                return mViewers;
            }
        }

        public int Channels
        {
            get
            {
                return mChannels;
            }
        }

        public Thumb CoverThumb
        {
            get
            {
                return mCoverThumb;
            }
        }

        public Thumb LogoThumb
        {
            get
            {
                return mLogoThumb;
            }
        }

        #endregion Properties

        #region Methods

        public List<Streams> GetStreams()
        {
            return mStreams;
        }

        #endregion Methods

    }
}