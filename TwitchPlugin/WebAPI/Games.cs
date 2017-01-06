using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TwitchPlugin.WebAPI
{

    /// <summary>
    /// The class TwitchPlugin.WebAPI.Games is the main implementation used for object operations in the namespace "Games" from the Twitch API.
    /// </summary>

    public class Games : INamespace
    {

        #region Declaration

        private const string mBaseRequestURL = "https://api.twitch.tv/kraken/games/top";
        private List<NamespaceParameter> mParameters;
        private string mRequestURL;

        #endregion Declaration

        #region Constructors

        public Games()
        {
        }

        public Games(List<NamespaceParameter> Parameters)
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
                return typeof(GamesDataContract);
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.GamesParameters is used for providing supported parameter for URL operations in the namespace "Games" from the Twitch API.
    /// </summary>

    public class GamesParameters: INamespaceParameters
    {
        #region Declaration

        private int mResponseItemLimit;
        private int mResponseItemOffset;

        #endregion Declaration

        #region Properties

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

        #endregion Properties

        #region Methods

        public List<NamespaceParameter> GetParameters()
        {
            List<NamespaceParameter> Collection = new List<NamespaceParameter> { };
            if (mResponseItemLimit != 0)
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
            if (mResponseItemOffset != 0)
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
            return Collection;
        }

        #endregion Methods

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.GamesDataContract is used for deserialization of the Json returened by the Twitch API.
    /// </summary>

    [DataContractAttribute]
    public class GamesDataContract
    {
        [DataMemberAttribute(Name="_links")]
        public _links Links {get; set; }

        [DataContractAttribute]
        public class _links
        {
            [DataMemberAttribute(Name = "self")]
            public string Self { get; set; }

            [DataMemberAttribute(Name = "next")]
            public string Next { get; set; }
        }

        [DataMemberAttribute(Name = "_total")]
        public int Total { get; set; }

        [DataMemberAttribute(Name = "top")]
        public top[] Top { get; set; }

        [DataContractAttribute]
        public class top
        {

            [DataMemberAttribute(Name = "game")]
            public game Game { get; set; }

            [DataContractAttribute]
            public class game
            {
                [DataMemberAttribute(Name = "name")]
                public string Name { get; set; }

                [DataMemberAttribute(Name = "box")]
                public box Box { get; set; }

                [DataContractAttribute]
                public class box
                {
                    [DataMemberAttribute(Name = "large")]
                    public string Large { get; set; }

                    [DataMemberAttribute(Name = "medium")]
                    public string Medium { get; set; }

                    [DataMemberAttribute(Name = "small")]
                    public string Small { get; set; }

                    [DataMemberAttribute(Name = "template")]
                    public string Template { get; set; }
                }

                [DataMemberAttribute(Name = "logo")]
                public logo Logo { get; set; }

                [DataContractAttribute]
                public class logo
                {
                    [DataMemberAttribute(Name = "large")]
                    public string Large { get; set; }

                    [DataMemberAttribute(Name = "medium")]
                    public string Medium { get; set; }

                    [DataMemberAttribute(Name = "small")]
                    public string Small { get; set; }

                    [DataMemberAttribute(Name = "template")]
                    public string Template { get; set; }
                }

                [DataMemberAttribute(Name = "_links")]
                public game_links Links {get; set; }

                [DataContractAttribute]
                public class game_links
                {
                }

                [DataMemberAttribute(Name = "_id")]
                public int Id { get; set; }

                [DataMemberAttribute(Name = "giantbomb_id")]
                public int GiantbombId { get; set; }
            }

            [DataMemberAttribute(Name = "viewers")]
            public int Viewers { get; set; }

            [DataMemberAttribute(Name = "channels")]
            public int Channels { get; set; }
        }
    }
}