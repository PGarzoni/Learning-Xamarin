using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TicTacToe
{
    public class PlayerManager
    {
        public struct PlayerType
        {
            public object PlayerToken { get; set; }
            public bool CurrentPlayer { get; set; }

            public PlayerType(object PlayerToken, bool CurrentPlayer)
            {
                this.PlayerToken = PlayerToken;
                this.CurrentPlayer = CurrentPlayer;
            }
        }

        private List<PlayerType> playerList = new List<PlayerType>();

        public void AddPlayer(object PlayerToken, bool CurrentPlayer)
        {
            playerList.Add(new PlayerType(PlayerToken, CurrentPlayer));
        }



    }
}