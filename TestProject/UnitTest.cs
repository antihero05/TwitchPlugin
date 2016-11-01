using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using TwitchPlugin.WebAPI;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            GamesParameters objGamesParameters = new GamesParameters();
            objGamesParameters.ResponseItemLimit = 12;
            objGamesParameters.ResponseItemOffset = 0;
            Games objGames = new Games(objGamesParameters.GetParameters());
            GamesDataContract objReturnedGames = (GamesDataContract) RequestHandler.Request(objGames);
            StreamsParameters objStreamParameters = new StreamsParameters();
            objStreamParameters.GameName = objReturnedGames.Top[0].Game.Name;
            objStreamParameters.ResponseItemLimit = 12;
            objStreamParameters.ResponseItemOffset = 0;
            Streams objStreams = new Streams(objStreamParameters.GetParameters());
            StreamsDataContract objReturnedStreams = (StreamsDataContract) RequestHandler.Request(objStreams);
            AccessTokenParameters objAccessTokenParameters = new AccessTokenParameters();
            objAccessTokenParameters.ChannelName = objReturnedStreams.Streams[0].Channel.Name;
            AccessToken objAccessToken = new AccessToken(objAccessTokenParameters.GetParameters());
            AccessTokenDataContract objReturnedAccessToken = (AccessTokenDataContract) RequestHandler.Request(objAccessToken);
            PlaylistParameters objPlaylistParameters = new PlaylistParameters();
            objPlaylistParameters.ChannelName = objReturnedStreams.Streams[0].Channel.Name;
            objPlaylistParameters.Token = objReturnedAccessToken.Token;
            objPlaylistParameters.Signature = objReturnedAccessToken.Sig;
            objPlaylistParameters.AllowAudioOnly = true;
            objPlaylistParameters.AllowSource = true;
            objPlaylistParameters.Type = "any";
            Playlist objPlaylist = new Playlist(objPlaylistParameters.GetParameters());
            byte[] bytReturnedPlaylist = RequestHandler.Request(objPlaylist);
            System.IO.FileStream objFileStream = new System.IO.FileStream("C:\\playlist.m3u8", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            objFileStream.Write(bytReturnedPlaylist,0,bytReturnedPlaylist.Length);
            objFileStream.Close();
            string strReturnedPlaylist = System.Text.Encoding.ASCII.GetString(bytReturnedPlaylist);
        }        
    }
}
