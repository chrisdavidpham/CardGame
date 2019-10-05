using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Hand {
        List<Card> hand;

        public Hand(List<Card> cardList) {
            hand = cardList;
            SortAscending();
        }

        public int getCount() {
            return hand.Count;
        }

        public void SortAscending() {
            hand.Sort(delegate (Card c1, Card c2) { return c1.cardValue.CompareTo(c2.cardValue); });
            return;
        }

        public Card at(int index) {
            if (index < 0 || index > 4) {
                throw new IndexOutOfRangeException();
            }
            return hand[index];
        }

        public int getFourOfAKind() {
            int fourOfAKindValue = 0;
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[3].cardValue) {
                fourOfAKindValue = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                fourOfAKindValue = hand[1].cardValue;
            }
            return fourOfAKindValue;
        }

        public int getStraight() {
            int highCard = 0;
            bool straight = true;
            for (int i = 0; i < 4; i++) {
                if (hand[i].cardValue != hand[i + 1].cardValue) {
                    straight = false;
                    break;
                }
                else {
                    highCard = hand[i + 1].cardValue;
                }
            }
            if (straight) {
                return highCard;
            }
            else {
                return 0;
            }
        }

        public bool getFlush() {
            bool flush = false;
            if (hand[0].cardSuit == hand[1].cardSuit && hand[0].cardSuit == hand[2].cardSuit && hand[0].cardSuit == hand[3].cardSuit && hand[0].cardSuit == hand[4].cardSuit) {
                flush = true;
            }
            return flush;
        }

        public int getFullHouse() {
            bool fullHouse = false;
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                fullHouse = true;
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                fullHouse = true;
            }
            if (fullHouse) {
                return hand[4].cardValue;
            }
            else {
                return 0;
            }
        }

        public int getThreeOfAKind() {
            int threeOfAKind = 0;
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[3].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[3].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue && hand[0].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue) {
                threeOfAKind = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[1].cardValue;
            }
            if (hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                threeOfAKind = hand[2].cardValue;
            }
            return threeOfAKind;
        }

        public int getTwoOfAKind() {
            int twoOfAKind = 0;
            if (hand[0].cardValue == hand[1].cardValue) {
                twoOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue) {
                twoOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue) {
                twoOfAKind = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[4].cardValue) {
                twoOfAKind = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue) {
                twoOfAKind = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[3].cardValue) {
                twoOfAKind = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[4].cardValue) {
                twoOfAKind = hand[1].cardValue;
            }
            if (hand[2].cardValue == hand[3].cardValue) {
                twoOfAKind = hand[2].cardValue;
            }
            if (hand[2].cardValue == hand[4].cardValue) {
                twoOfAKind = hand[2].cardValue;
            }
            if (hand[3].cardValue == hand[4].cardValue) {
                twoOfAKind = hand[3].cardValue;
            }
            return twoOfAKind;
        }

        public int[] getTwoPair() {
            // store card values of each pair and remaining card in last index
            int[] twoPair = new int[3];
            twoPair[0] = 0;
            twoPair[1] = 0;
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[4].cardValue;
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[3].cardValue;
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[3].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[3].cardValue;
                twoPair[2] = hand[2].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[4].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue && hand[1].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[3].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[3].cardValue;
                twoPair[2] = hand[1].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue && hand[1].cardValue == hand[2].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[4].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[2].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[1].cardValue;
            }
            if (hand[0].cardValue == hand[4].cardValue && hand[1].cardValue == hand[2].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[3].cardValue;
            }
            if (hand[0].cardValue == hand[4].cardValue && hand[1].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[1].cardValue;
                twoPair[2] = hand[2].cardValue;
            }
            if (hand[0].cardValue == hand[4].cardValue && hand[2].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[1].cardValue;
                twoPair[1] = hand[3].cardValue;
                twoPair[2] = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[1].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[4].cardValue && hand[2].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[1].cardValue;
                twoPair[1] = hand[2].cardValue;
                twoPair[2] = hand[0].cardValue;
            }

            // sort descending
            if (twoPair[0] < twoPair[1]) {
                int temp = twoPair[0];
                twoPair[0] = twoPair[1];
                twoPair[1] = temp;
            }
            return twoPair;
        }

        public int highCard() {
            return hand[4].cardValue;
        }
        public int lowCard() {
            return hand[0].cardValue;
        }
    }
}
