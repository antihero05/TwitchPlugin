using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TwitchPlugin.WebAPI
{

    /// <summary>
    /// The class TwitchPlugin.WebAPI.Streams is the main implementation used for object operations in the namespace "Streams" from the Twitch API.
    /// </summary>

    public class Streams : INamespace
    {

        #region Declaration

        private const string mBaseRequestURL = "https://api.twitch.tv/kraken/streams";
        private List<NamespaceParameter> mParameters;
        private string mRequestURL;

        #endregion Declaration

        #region Constructors

        public Streams()
        {
        }

        public Streams(List<NamespaceParameter> Parameters)
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
                    mRequestURL = mRequestURL + "?" + mParameters[0].Name + "=" + mParameters[0].Value;
                    if (mParameters.Count > 1)
                    {
                        for (int intLoop = 1; intLoop <= (mParameters.Count - 1); intLoop++)
                        {
                            mRequestURL = mRequestURL + "&" + mParameters[intLoop].Name + "=" + mParameters[intLoop].Value;
                        }
                    }
                }
                return mRequestURL;
            }
        }

        public Type DataContract
        {
            get
            {
                return typeof(StreamsDataContract);
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.StreamsParameters is used for providing supported parameter for URL operations in the namespace "Streams" from the Twitch API.
    /// </summary>

    public class StreamsParameters : INamespaceParameters
    {

        #region Enumerations

        public enum enuStreamType
        {
          all,
          playlist,
          live
        };

        #endregion Enumerations

        #region Declaration

        private string mGameName;
        private string mChannelList;
        private int mResponseItemLimit;
        private int mResponseItemOffset;
        private string mClientId;
        private enuStreamType mStreamType; 

        #endregion Declaration

        #region Properties

        public string GameName
        {
            get
            {
                return mGameName;
            }
            set
            {
                mGameName = value;
            }
        }

        public string ChannelList
        {
            get
            {
                return mChannelList;
            }
            set
            {
                mChannelList = value;
            }
        }

        public int ResponseItemLimit
        {
            get
            {
                return mResponseItemLimit;
            }
            set
            {
                mResponseItemLimit = value;
            }
        }

        public int ResponseItemOffset
        {
            get
            {
                return mResponseItemOffset;
            }
            set
            {
                mResponseItemOffset = value;
            }
        }

        public string ClientId
        {
            get
            {
                return mClientId;
            }
            set
            {
                mClientId = value;
            }
        }

        public enuStreamType StreamType
        {
            get
            {
                return mStreamType;
            }
            set
            {
                mStreamType = value;
            }
        }

        #endregion Properties

        #region Methods

        public List<NamespaceParameter> GetParameters()
        {
            List<NamespaceParameter> Collection = new List<NamespaceParameter> { };
            if (mGameName != null)
            {
                string strGameName = mGameName.ToString();
                if (String.IsNullOrEmpty(strGameName) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "game";
                    Item.Value = strGameName;
                    Collection.Add(Item);
                }
            }
            if (mChannelList != null)
            {
                string strChannelList = mChannelList.ToString();
                if (String.IsNullOrEmpty(strChannelList) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "channel";
                    Item.Value = strChannelList;
                    Collection.Add(Item);
                }
            }
            if (mResponseItemLimit != null)
            {
                string strResponseItemLimit = mResponseItemLimit.ToString();
                if (String.IsNullOrEmpty(strResponseItemLimit) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "limit";
                    Item.Value = strResponseItemLimit;
                    Collection.Add(Item);
                }
            }
            if (mResponseItemOffset != null)
            {
                string strResponseItemOffset = mResponseItemOffset.ToString();
                if (String.IsNullOrEmpty(strResponseItemOffset) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "offset";
                    Item.Value = strResponseItemOffset;
                    Collection.Add(Item);
                }
            }
            if (mClientId != null)
            {
                string strClientId = mClientId.ToString();
                if (String.IsNullOrEmpty(strClientId) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "client_id";
                    Item.Value = strClientId;
                    Collection.Add(Item);
                }
            }
            if (mStreamType != null)
            {
                string strStreamType = mStreamType.ToString();
                if (String.IsNullOrEmpty(strStreamType) == false)
                {
                    NamespaceParameter Item = new NamespaceParameter();
                    Item.Name = "stream_type";
                    Item.Value = strStreamType;
                    Collection.Add(Item);
                }
            }
            return Collection;
        }

        #endregion Methods

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.StreamsDataContract is used for deserialization of the Json returened by the Twitch API.
    /// </summary>

    [DataContractAttribute]
    public class StreamsDataContract
    {
        [DataMemberAttribute(Name = "_total")]
        public int Total { get; set; }

        [DataMemberAttribute(Name = "streams")]
        public streams[] Streams { get; set; }

        [DataContractAttribute]
        public class streams
        {
            [DataMemberAttribute(Name = "game")]
            public string Game { get; set; }

            [DataMemberAttribute(Name = "viewers")]
            public int Viewers { get; set; }

            [DataMemberAttribute(Name = "average_fps")]
            public double AverageFPS { get; set; }

            [DataMemberAttribute(Name = "delay")]
            public int Delay { get; set; }

            [DataMemberAttribute(Name = "video_height")]
            public int VideoHeight { get; set; }

            [DataMemberAttribute(Name = "is_playlist")]
            public bool IsPlaylist { get; set; }

            [DataMemberAttribute(Name = "created_at")]
            public string CreatedAt { get; set; }

            [DataMemberAttribute(Name = "_id")]
            public long Id { get; set; }

            [DataMemberAttribute(Name = "channel")]
            public channel Channel { get; set; }

            [DataContractAttribute]
            public class channel
            {
                [DataMemberAttribute(Name = "mature")]
                public string Mature { get; set; }

                [DataMemberAttribute(Name = "status")]
                public string Status { get; set; }

                [DataMemberAttribute(Name = "broadcaster_language")]
                public string BroadcasterLanguage { get; set; }

                [DataMemberAttribute(Name = "display_name")]
                public string DisplayName { get; set; }

                [DataMemberAttribute(Name = "game")]
                public string Game { get; set; }

                [DataMemberAttribute(Name = "delay")]
                public object Delay { get; set; }

                [DataMemberAttribute(Name = "language")]
                public string Language { get; set; }

                [DataMemberAttribute(Name = "_id")]
                public int Id { get; set; }

                [DataMemberAttribute(Name = "name")]
                public string Name { get; set; }

                [DataMemberAttribute(Name = "created_at")]
                public string CreatedAt { get; set; }

                [DataMemberAttribute(Name = "updated_at")]
                public string UpdatedAt { get; set; }

                [DataMemberAttribute(Name = "logo")]
                public string Logo { get; set; }

                [DataMemberAttribute(Name = "banner")]
                public string Banner { get; set; }

                [DataMemberAttribute(Name = "video_banner")]
                public string VideoBanner { get; set; }

                [DataMemberAttribute(Name = "background")]
                public object Background { get; set; }

                [DataMemberAttribute(Name = "profile_banner")]
                public string ProfileBanner { get; set; }

                [DataMemberAttribute(Name = "profile_banner_background_color")]
                public string ProfileBannerBackgroundColor { get; set; }

                [DataMemberAttribute(Name = "partner")]
                public bool Partner { get; set; }

                [DataMemberAttribute(Name = "url")]
                public string URL { get; set; }

                [DataMemberAttribute(Name = "views")]
                public int Views { get; set; }

                [DataMemberAttribute(Name = "followers")]
                public int Followers { get; set; }

                [DataMemberAttribute(Name = "_links")]
                public _links Links { get; set; }

                [DataContractAttribute]
                public class _links
                {
                    [DataMemberAttribute(Name = "self")]
                    public string Self { get; set; }

                    [DataMemberAttribute(Name = "follows")]
                    public string Follows { get; set; }

                    [DataMemberAttribute(Name = "commercial")]
                    public string Commercial { get; set; }

                    [DataMemberAttribute(Name = "stream_key")]
                    public string StreamKey { get; set; }

                    [DataMemberAttribute(Name = "chat")]
                    public string Chat { get; set; }

                    [DataMemberAttribute(Name = "features")]
                    public string Features { get; set; }

                    [DataMemberAttribute(Name = "subscription")]
                    public string Subscription { get; set; }

                    [DataMemberAttribute(Name = "editors")]
                    public string Editors { get; set; }

                    [DataMemberAttribute(Name = "teams")]
                    public string Teams { get; set; }

                    [DataMemberAttribute(Name = "videos")]
                    public string Videos { get; set; }
                }
            }

            [DataMemberAttribute(Name = "preview")]
            public preview Preview { get; set; }

            [DataContractAttribute]
            public class preview
            {
                [DataMemberAttribute(Name = "small")]
                public string Small { get; set; }

                [DataMemberAttribute(Name = "medium")]
                public string Medium { get; set; }

                [DataMemberAttribute(Name = "large")]
                public string Large { get; set; }

                [DataMemberAttribute(Name = "template")]
                public string Template { get; set; }
            }

            [DataMemberAttribute(Name = "_links")]
            public _links Links { get; set; }

            [DataContractAttribute]
            public class _links
            {
                [DataMemberAttribute(Name = "self")]
                public string Self { get; set; }
            }
        }

        [DataMemberAttribute(Name = "_links")]
        public _links Links { get; set; }

        [DataContractAttribute]
        public class _links
        {
            [DataMemberAttribute(Name = "summary")]
            public string Summary { get; set; }

            [DataMemberAttribute(Name = "followed")]
            public string Followed { get; set; }

            [DataMemberAttribute(Name = "next")]
            public string Next { get; set; }

            [DataMemberAttribute(Name = "featured")]
            public string Featured { get; set; }

            [DataMemberAttribute(Name = "self")]
            public string Self { get; set; }
        }
    }
}