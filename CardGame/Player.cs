using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Player {
        public Hand hand { get; private set; }
        public string name { get; private set; }

        public Player(string playerName, List<Card> cardList) {
            name = playerName;
            hand = new Hand(cardList);
        }
        public Player(string playerName, Hand hand) {
            name = playerName;
            this.hand = hand;
        }

        public string getHandString() {
            // Get the value and suit of each card delimited by commas and the rank of the hand.
            if (hand.getCount() < 5) {
                throw new IndexOutOfRangeException();
            }
            string handString = "";
            for (int i = 0; i < 4; i++) {
                handString += hand.at(i).cardValue + "-" + hand.at(i).cardSuit + ", ";
            }
            handString += hand.at(4).cardValue + "-" + hand.at(4).cardSuit;

            if (hand.isFourOfAKind) {
                handString += " - Four of a kind";
            }
            else if (hand.isStraight && hand.isFlush) {
                handString += " - Straight flush";
            }
            else if (hand.isFlush) {
                handString += " - Flush";
            }
            else if (hand.isStraight) {
                handString += " - Straight";
            }
            else if (hand.isFullHouse) {
                handString += " - Full House";
            }
            else if (hand.isThreeOfAKind) {
                handString += " - Three of a Kind";
            }
            else if (hand.isTwoPair) {
                handString += " - Two Pair";
            }
            else if (hand.isOnePair) {
                handString += " - One Pair";
            }
            else {
                handString += " - High card";
            }

            return handString;
        }
    }
}
