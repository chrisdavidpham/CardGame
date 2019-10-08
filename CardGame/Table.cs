using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Table {
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

        // return 0 if tie, 1 if cardList1 wins, 2 if cardList2 wins
        public int evaluateKickerWinner(List<Card> cardList1, List<Card> cardList2) {
            int winner = 0;
            if(cardList1.Count != cardList2.Count) {
                throw new ArgumentException("card lists must be same size");
            }
            for (int i=0; i<hand1.Count; i++) {
                if (cardList1[i].cardValue > cardList2[i].cardValue) {
                    winner = 1;
                }
                if (cardList1[i].cardValue < cardList2[i].cardValue) {
                    winner = 2;
                }
            }
            return winner;
        }

        public void evaluateWinner() {
            // Populate possible winning player hands
            for (int i=0; i<players.Count; i++) {
                players[i].hand.evaluateHand();
                if (players[i].hand.isFourOfAKind) {
                    fourOfAKindPlayers.Add(players[i]);
                }
                else if (players[i].hand.isStraight && players[i].hand.isFlush) {
                    straightFlushPlayers.Add(players[i]);
                }
                else if (players[i].hand.isStraight) {
                    straightPlayers.Add(players[i]);
                }
                else if (players[i].hand.isFlush) {
                    flushPlayers.Add(players[i]);
                }
                else if (players[i].hand.isThreeOfAKind) {
                    threeOfAKindPlayers.Add(players[i]);
                }
                else if (players[i].hand.isTwoPair) {
                    twoPairPlayers.Add(players[i]);
                }
                else if (players[i].hand.isOnePair) {
                    onePairPlayers.Add(players[i]);
                }
                else {
                    highCardPlayers.Add(players[i]);
                }
            }

            // assume winner is index 0 and prove
            int winner = 0;
            List<int> tieWinners = new List<int>;

            // Four of a Kind
            if (fourOfAKindPlayers.Count > 0) {
                for (int i = 0; i + 1 < fourOfAKindPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(players[winner].hand.fourOfAKindKickers, players[i + 1].hand.fourOfAKindKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }

                for (int i = 0; i + 1 < fourOfAKindPlayers.Count; i++) {
                    if (i == winner) {
                        continue;
                    }
                    bool tie = true;
                    for (int j = 0; j < 5; j++) {
                        if (players[winner].hand.at(j) != players[winner].hand.at(j)) {
                            tie = false;
                            break;
                        }
                    } 
                    if (tie) {
                        tieWinners.Add(i);
                    }
                }
            }
            // Straight Flush
            // Straight
            // Flush
            // Three of a Kind
            // Two Pair
            // One Pair
            // High Card
        }
    }
}
