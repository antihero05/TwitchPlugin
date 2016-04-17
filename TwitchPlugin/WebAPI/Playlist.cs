using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchPlugin.WebAPI
{

    /// <summary>
    /// The class TwitchPlugin.WebAPI.Playlist is the main implementation used for object operations related to the playlist received from the Twitch API.
    /// </summary>

    public class Playlist
    {

        #region Declaration

        private const string mBaseRequestURL = "http://usher.twitch.tv/api/channel/hls";
        private List<NamespaceParameter> mParameters;
        private string mRequestURL;

        #endregion Declaration

        #region Constructors

        public Playlist(List<NamespaceParameter> Parameters)
        {
            mParameters = Parameters;
        }

        #endregion Constructors

        #region Properties

        public string BaseRequestURL
        {
            get
            {
                return mBaseRequestURL;
            }
        }

        public List<NamespaceParameter> Parameters
        {
            get
            {
                return mParameters;
            }
            set
            {
                mParameters = value;
            }
        }

        public string RequestURL
        {
            get
            {
                mRequestURL = mBaseRequestURL;
                    if (mParameters.Count >= 1)
                    {
                        mRequestURL = mRequestURL + "/" + mParameters[0].Value + ".m3u8?player=twitchweb";
                        if (mParameters.Count > 1)
                        {
                            for (int intLoop = 1; intLoop <= (mParameters.Count - 1); intLoop++)
                            {
                                {
                                    mRequestURL = mRequestURL + "&" + mParameters[intLoop].Name + "=" + mParameters[intLoop].Value;
                                }
                            }
                        }
                }
                return mRequestURL;
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.AccessTokenParameters is used for providing supported parameter for URL operations in the namespace "Games" from the Twitch API.
    /// </summary>

    public class PlaylistParameters : INamespaceParameters
    {
        #region Declaration

        private string mChannelName;
        private string mToken;
        private string mSignature;
        private bool mAllowAudioOnly;
        private bool mAllowSource;
        private string mType;

        #endregion Declaration

        #region Properties

        public string ChannelName
        {
            get
            {
                return mChannelName;
            }
            set
            {
                mChannelName = value;
            }
        }

        public string Token
        {
            get
            {
                return mToken;
            }
            set
            {
                mToken = value;
            }
        }

        public string Signature
        {
            get
            {
                return mSignature;
            }
            set
            {
                mSignature = value;
            }
        }

        public bool AllowAudioOnly
        {
            get
            {
                return mAllowAudioOnly;
            }
            set
            {
                mAllowAudioOnly = value;
            }
        }

        public bool AllowSource
        {
            get
            {
                return mAllowSource;
            }
            set
            {
                mAllowSource = value;
            }
        }

        public string Type
        {
            get
            {
                return mType;
            }
            set
            {
                mType = value;
            }
        }

        #endregion Properties

        #region Methods

        public List<NamespaceParameter> GetParameters()
        {
            List<NamespaceParameter> Collection = new List<NamespaceParameter> { };
            if (mChannelName != null)
            {
                string strChannelName = mChannelName.ToString();
                if (String.IsNullOrEmpty(strChannelName) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "channelname";
                    Item.Value = strChannelName;
                    Collection.Add(Item);
                }
            }
            if (mToken != null)
            {
                string strToken = mToken.ToString();
                if (String.IsNullOrEmpty(strToken) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "token";
                    Item.Value = strToken;
                    Collection.Add(Item);
                }
            }
            if (mSignature != null)
            {
                string strSignature = mSignature.ToString();
                if (String.IsNullOrEmpty(strSignature) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "sig";
                    Item.Value = strSignature;
                    Collection.Add(Item);
                }
            }
            if (mAllowAudioOnly != null)
            {
                string strAllowAudioOnly = mAllowAudioOnly.ToString();
                if (String.IsNullOrEmpty(strAllowAudioOnly) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "allow_audio_only";
                    Item.Value = strAllowAudioOnly;
                    Collection.Add(Item);
                }
            }
            if (mAllowSource != null)
            {
                string strAllowSource = mAllowSource.ToString();
                if (String.IsNullOrEmpty(strAllowSource) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "allow_source";
                    Item.Value = strAllowSource;
                    Collection.Add(Item);
                }
            }
            if (mType != null)
            {
                string strType = mType.ToString();
                if (String.IsNullOrEmpty(strType) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "type";
                    Item.Value = strType;
                    Collection.Add(Item);
                }
            }
            if (true)
            {
                Random rndRandom = new Random();
                NamespaceParameter Item = new NamespaceParameter();
                Item.Name = "p";
                Item.Value = (rndRandom.Next(100000, 999999)).ToString();
                Collection.Add(Item);
            }
            return Collection;
        }

        #endregion Methods

    }
}
