using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    class Table {
        private List<Player> players;
        private List<Player> fourOfAKindPlayers;
        private List<Player> straightFlushPlayers;
        private List<Player> straightPlayers;
        private List<Player> flushPlayers;
        private List<Player> fullHousePlayers;
        private List<Player> threeOfAKindPlayers;
        private List<Player> twoPairPlayers;
        private List<Player> onePairPlayers;
        private List<Player> highCardPlayers;

        public Table(List<Player> playerList) {
            players = playerList;
        }

        public void evaluateKickerWinner() {

        }

        public void evaluateWinner() {

        }
    }
}
