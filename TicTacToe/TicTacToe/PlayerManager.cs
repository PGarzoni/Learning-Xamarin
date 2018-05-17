using System.Collections.Generic;

namespace TicTacToe
{
    public class PlayerManager
    {
        private List<Player> playerList = new List<Player>();
        private int currentTurn = 0;

        public class Player
        {
            public object PlayerToken { get; set; }
            public int Score { get; set; }
            public int Turn { get; set; }

            public Player(object PlayerToken)
            {
                this.PlayerToken = PlayerToken;
                Turn = 0;
                Score = 0;
            }

            public void EndTurn()
            {
                Turn++;
            }
        }

        /// <summary>
        /// Creates a new player and adds it to the list.
        /// </summary>
        /// <param name="PlayerToken"></param>
        public void AddPlayer(object PlayerToken)
        {
            playerList.Add(new Player(PlayerToken));
        }

        /// <summary>
        /// Returns the current most player from the list, will increment current turn counter to cycle back to the first player.
        /// </summary>
        /// <returns></returns>
        public Player CurrentPlayer()
        {
            foreach (Player p in playerList)
            {
                if (p.Turn == currentTurn)
                {
                    return p;
                }
            }

            currentTurn++;
            return playerList[0]; // cycle back to the first player
        }

        /// <summary>
        /// Resets all players to the default starting values
        /// </summary>
        public void ResetGame()
        {
            currentTurn = 0;
            foreach (Player p in playerList)
            {
                p.Turn = 0;
                p.Score = 0;
            }
        }
    }
}