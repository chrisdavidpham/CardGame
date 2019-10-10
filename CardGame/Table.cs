using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Table {
        public List<Player> players { get; private set; }
        public List<Player> fourOfAKindPlayers { get; private set; }
        public List<Player> straightFlushPlayers { get; private set; }
        public List<Player> straightPlayers { get; private set; }
        public List<Player> flushPlayers { get; private set; }
        public List<Player> fullHousePlayers { get; private set; }
        public List<Player> threeOfAKindPlayers { get; private set; }
        public List<Player> twoPairPlayers { get; private set; }
        public List<Player> onePairPlayers { get; private set; }
        public List<Player> highCardPlayers { get; private set; }
        public Player winningPlayer { get; private set; }
        public List<Player> tiePlayers { get; private set; }

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
                else if (players[i].hand.isFullHouse) {
                    fullHousePlayers.Add(players[i]);
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

            // Straight Flush
            if (straightFlushPlayers.Count > 0) {
                for (int i = 0; i + 1 < straightFlushPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(straightFlushPlayers[winner].hand.straightKickers, straightFlushPlayers[i + 1].hand.straightKickers);
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
                    for (int j = 0; j < straightFlushPlayers[winner].hand.straightKickers.Count; j++) {
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
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(straightFlushPlayers[winner]);
                }
                else {
                    winningPlayer = straightFlushPlayers[winner];
                }
            }
            // Four of a Kind
            else if (fourOfAKindPlayers.Count > 0) {
                for (int i = 0; i + 1 < fourOfAKindPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(fourOfAKindPlayers[winner].hand.fourOfAKindKickers, fourOfAKindPlayers[i + 1].hand.fourOfAKindKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                winningPlayer = fourOfAKindPlayers[winner];
                // Don't need to check for tiebreakers, not possible to tie with four of a kind
            }
            // Full House
            else if (fullHousePlayers.Count > 0) {
                for (int i = 0; i + 1 < fullHousePlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(fullHousePlayers[winner].hand.fullHouseKickers, fullHousePlayers[i + 1].hand.fullHouseKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // Don't need to check for tiebreakers, not possible to tie with Full 
                winningPlayer = fullHousePlayers[winner];
            }
            // Flush
            else if (flushPlayers.Count > 0) {
                for (int i = 0; i + 1 < flushPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(flushPlayers[winner].hand.flushKickers, flushPlayers[i + 1].hand.flushKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < flushPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < flushPlayers[winner].hand.flushKickers.Count; j++) {
                        int val1 = flushPlayers[winner].hand.flushKickers[j].cardValue;
                        int val2 = flushPlayers[i].hand.flushKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(flushPlayers[i]);
                    }
                }
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(flushPlayers[winner]);
                }
                else {
                    winningPlayer = flushPlayers[winner];
                }
            }
            // Straight
            else if (straightPlayers.Count > 0) {
                for (int i = 0; i + 1 < straightPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(straightPlayers[winner].hand.straightKickers, straightPlayers[i + 1].hand.straightKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < straightPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < straightPlayers[winner].hand.straightKickers.Count; j++) {
                        int val1 = straightPlayers[winner].hand.straightKickers[j].cardValue;
                        int val2 = straightPlayers[i].hand.straightKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(straightPlayers[i]);
                    }
                }
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(straightPlayers[winner]);
                }
                else {
                    winningPlayer = straightPlayers[winner];
                }
            }
            // Three of a Kind
            else if (threeOfAKindPlayers.Count > 0) {
                for (int i = 0; i + 1 < threeOfAKindPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(threeOfAKindPlayers[winner].hand.threeOfAKindKickers, threeOfAKindPlayers[i + 1].hand.threeOfAKindKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                winningPlayer = threeOfAKindPlayers[winner];
                // Don't need to check for tiebreakers, not possible to tie with four of a kind
            }
            // Two Pair
            else if (twoPairPlayers.Count > 0) {
                for (int i = 0; i + 1 < twoPairPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(twoPairPlayers[winner].hand.twoPairKickers, twoPairPlayers[i + 1].hand.twoPairKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < twoPairPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < twoPairPlayers[winner].hand.twoPairKickers.Count; j++) {
                        int val1 = twoPairPlayers[winner].hand.twoPairKickers[j].cardValue;
                        int val2 = twoPairPlayers[i].hand.twoPairKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(twoPairPlayers[i]);
                    }
                }
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(twoPairPlayers[winner]);
                }
                else {
                    winningPlayer = twoPairPlayers[winner];
                }
            }
            // One Pair
            else if (onePairPlayers.Count > 0) {
                for (int i = 0; i + 1 < onePairPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(onePairPlayers[winner].hand.onePairKickers, onePairPlayers[i + 1].hand.onePairKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < onePairPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < onePairPlayers[winner].hand.onePairKickers.Count; j++) {
                        int val1 = onePairPlayers[winner].hand.onePairKickers[j].cardValue;
                        int val2 = onePairPlayers[i].hand.onePairKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(onePairPlayers[i]);
                    }
                }
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(onePairPlayers[winner]);
                }
                else {
                    winningPlayer = onePairPlayers[winner];
                }
            }
            // High Card
            else if (highCardPlayers.Count > 0) {
                for (int i = 0; i + 1 < highCardPlayers.Count; i++) {
                    int kickerFlag = evaluateKickerWinner(highCardPlayers[winner].hand.highCardKickers, highCardPlayers[i + 1].hand.highCardKickers);
                    if (2 == kickerFlag) {
                        winner = i + 1;
                    }
                }
                // check for tied hands
                for (int i = 0; i < highCardPlayers.Count; i++) {
                    // Skip compare with self
                    if (i == winner) {
                        continue;
                    }
                    // Assume winner and player[i] have tied hands and test
                    bool tie = true;
                    for (int j = 0; j < highCardPlayers[winner].hand.highCardKickers.Count; j++) {
                        int val1 = highCardPlayers[winner].hand.highCardKickers[j].cardValue;
                        int val2 = highCardPlayers[i].hand.highCardKickers[j].cardValue;
                        if (val1 != val2) {
                            tie = false;
                            break;
                        }
                    }
                    if (tie) {
                        tiePlayers.Add(highCardPlayers[i]);
                    }
                }
                if (tiePlayers.Count > 0) {
                    tiePlayers.Add(highCardPlayers[winner]);
                }
                else {
                    winningPlayer = highCardPlayers[winner];
                }
            }
        }
    }
}
