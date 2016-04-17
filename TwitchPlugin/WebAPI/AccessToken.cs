using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TwitchPlugin.WebAPI
{
    /// <summary>
    /// The class TwitchPlugin.WebAPI.AccessToken is the main implementation used for object operations related to the access token received from the Twitch API.
    /// </summary>

    public class AccessToken : INamespace
    {

        #region Declaration

        private const string mBaseRequestURL = "https://api.twitch.tv/api/channels";
        private List<NamespaceParameter> mParameters;
        private string mRequestURL;

        #endregion Declaration

        #region Constructors

        public AccessToken(List<NamespaceParameter> Parameters)
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
                        mRequestURL = mRequestURL + "/" + mParameters[0].Value + "/access_token";
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
                return typeof(AccessTokenDataContract);
            }
        }

        #endregion Properties

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.AccessTokenParameters is used for providing supported parameter for URL operations in the namespace "Games" from the Twitch API.
    /// </summary>

    public class AccessTokenParameters : INamespaceParameters
    {
        #region Declaration

        private string mChannelName;

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
            return Collection;
        }

        #endregion Methods

    }

    /// <summary>
    /// The class TwitchPlugin.WebAPI.AccessTokenDataContract is used for deserialization of the Json returened by the Twitch API.
    /// </summary>

    [DataContractAttribute]
    public class AccessTokenDataContract
    {
        [DataMemberAttribute(Name = "token")]
        public string Token { get; set; }

        [DataMemberAttribute(Name = "sig")]
        public string Sig { get; set; }

        [DataMemberAttribute(Name = "mobile_restricted")]
        public bool MobileRestricted { get; set; }
    }
}