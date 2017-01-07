using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace TwitchPlugin.WebAPI
{

    /// <summary>
    /// The class TwitchPlugin.WebAPI.RequestHandler is used for communication with the Twitch API.
    /// </summary>

    public static class RequestHandler
    {
        #region Declaration

        private const string mClientID = "9lnhiieac8zs5f8qgbqd0416bxt3lyx";

        #endregion Declaration

        #region Constructors

        static RequestHandler()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        #endregion Constructors

        #region Methods

        static public object Request(INamespace objNamespace)
        {
            UriBuilder Builder = new UriBuilder(objNamespace.RequestURL);
            HttpWebRequest HTTPRequest = WebRequest.Create(Builder.Uri) as HttpWebRequest;
            HTTPRequest.Accept = "application/vnd.twitchtv.v3+json";
            HTTPRequest.Headers.Add("Client-ID", mClientID);
            HttpWebResponse HTTPResponse = HTTPRequest.GetResponse() as HttpWebResponse;
            if (HTTPResponse.StatusCode == HttpStatusCode.OK)
            {
                DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(objNamespace.DataContract);
                object ResponseObject = JsonSerializer.ReadObject(HTTPResponse.GetResponseStream());
                return ResponseObject;
            }
            else
            {
                return null;
            }
        }

        static public byte[] Request(Playlist objPlaylist)
        {
            UriBuilder Builder = new UriBuilder(objPlaylist.RequestURL);
            HttpWebRequest HTTPRequest = WebRequest.Create(Builder.Uri) as HttpWebRequest;
            HTTPRequest.Accept = "application/vnd.apple.mpegurl";
            HttpWebResponse HTTPResponse = HTTPRequest.GetResponse() as HttpWebResponse;
            if (HTTPResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream HTTPStream = HTTPResponse.GetResponseStream();
                StreamReader HTTPStreamReader = new StreamReader(HTTPStream, Encoding.Default);
                string HTTPResponseData = HTTPStreamReader.ReadToEnd();
                byte[] bytReturn = Encoding.Default.GetBytes(HTTPResponseData);
                return bytReturn;
            }
            else
            {
                return null;
            }
        }

        static public byte[] Request(string URL ,string MIMEType)
        {
            UriBuilder Builder = new UriBuilder(URL);
            HttpWebRequest HTTPRequest = WebRequest.Create(Builder.Uri) as HttpWebRequest;
            HTTPRequest.Accept = MIMEType;
            HttpWebResponse HTTPResponse = HTTPRequest.GetResponse() as HttpWebResponse;
            if (HTTPResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream HTTPStream = HTTPResponse.GetResponseStream();
                StreamReader HTTPStreamReader = new StreamReader(HTTPStream,Encoding.Default);
                string HTTPResponseData = HTTPStreamReader.ReadToEnd();
                byte[] bytReturn = Encoding.Default.GetBytes(HTTPResponseData);
                return bytReturn;
            }
            else
            {
                return null;
            }
        }

        #endregion Methods

    }
}
