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

        public Card At(int index) {
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
                if (hand[i].cardValue + 1 != hand[i + 1].cardValue) {
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

        public int getOnePair() {
            int onePair = 0;
            if (hand[0].cardValue == hand[1].cardValue) {
                onePair = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[2].cardValue) {
                onePair = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[3].cardValue) {
                onePair = hand[0].cardValue;
            }
            if (hand[0].cardValue == hand[4].cardValue) {
                onePair = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue) {
                onePair = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[3].cardValue) {
                onePair = hand[1].cardValue;
            }
            if (hand[1].cardValue == hand[4].cardValue) {
                onePair = hand[1].cardValue;
            }
            if (hand[2].cardValue == hand[3].cardValue) {
                onePair = hand[2].cardValue;
            }
            if (hand[2].cardValue == hand[4].cardValue) {
                onePair = hand[2].cardValue;
            }
            if (hand[3].cardValue == hand[4].cardValue) {
                onePair = hand[3].cardValue;
            }
            return onePair;
        }

        public int[] getTwoPair() {
            // store card values of each pair and kicker card in last index
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
            if (hand[0].cardValue == hand[1].cardValue && hand[3].cardValue == hand[4].cardValue) {
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

        public Card getKicker(List<int> indices) {
            // gets card of greatest value of hand at given indices
            if (indices.Count > 5) {
                throw new ArgumentException("indices list is too long");
            }
            indices.Sort();
            if (indices[indices.Count-1] > 4 || indices[0] < 0) {
                throw new ArgumentException("index in indices is out of range (0-4)");
            }
            List<Card> cards = new List<Card>();
            for (int i=0; i<indices.Count; i++) {
                cards.Add(hand[i]);
            }
            cards.Sort(delegate (Card c1, Card c2) { return c1.cardValue.CompareTo(c2.cardValue); });
            Card kicker = cards[cards.Count - 1];
            return kicker;
        }

        public int highCard() {
            return hand[4].cardValue;
        }
        public int lowCard() {
            return hand[0].cardValue;
        }
    }
}
