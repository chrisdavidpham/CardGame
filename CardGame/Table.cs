using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Table {
        public List<Player> players;
        public List<Player> fourOfAKindPlayers;
        public List<Player> straightFlushPlayers;
        public List<Player> straightPlayers;
        public List<Player> flushPlayers;
        public List<Player> fullHousePlayers;
        public List<Player> threeOfAKindPlayers;
        public List<Player> twoPairPlayers;
        public List<Player> onePairPlayers;
        public List<Player> highCardPlayers;
        public Player winningPlayer;
        public List<Player> tiePlayers;

        public Table(List<Player> playerList) {
            players = playerList;
            fourOfAKindPlayers = new List<Player>();
            straightFlushPlayers = new List<Player>();
            straightPlayers = new List<Player>();
            flushPlayers = new List<Player>();
            fullHousePlayers = new List<Player>();
            threeOfAKindPlayers = new List<Player>();
            twoPairPlayers = new List<Player>();
            onePairPlayers = new List<Player>();
            highCardPlayers = new List<Player>();
            tiePlayers = new List<Player>();
        }

        // return 0 if tie, 1 if cardList1 wins, 2 if cardList2 wins
        public int evaluateKickerWinner(List<Card> cardList1, List<Card> cardList2) {
            int winner = 0;
            if(cardList1.Count != cardList2.Count) {
                throw new ArgumentException("card lists must be same size");
            }
            for (int i=0; i<cardList1.Count; i++) {
                if (cardList1[i].cardValue > cardList2[i].cardValue) {
                    winner = 1;
                    break;
                }
                if (cardList1[i].cardValue < cardList2[i].cardValue) {
                    winner = 2;
                    break;
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

            // Four of a Kind
            if (fourOfAKindPlayers.Count > 0) {
                for (int i = 0; i + 1 < fourOfAKindPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(players[winner].hand.fourOfAKindKickers, players[i + 1].hand.fourOfAKindKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                winningPlayer = fourOfAKindPlayers[winner];
                // Don't need to check for tiebreakers, not possible to tie with four of a kind
            }
            else if (straightFlushPlayers.Count > 0) {
                for (int i = 0; i + 1 < straightFlushPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(players[winner].hand.straightKickers, players[i + 1].hand.straightKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < straightFlushPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < 5; j++) {
                        int val1 = straightFlushPlayers[winner].hand.straightKickers[j].cardValue;
                        int val2 = straightFlushPlayers[i].hand.straightKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(straightFlushPlayers[i]);
                    }
                }
                if(tiePlayers.Count > 0) {
                    tiePlayers.Add(straightFlushPlayers[winner]);
                }
                else {
                    winningPlayer = straightFlushPlayers[winner];
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
