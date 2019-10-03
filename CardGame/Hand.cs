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

        public int highCard() {
            return hand[4].cardValue;
        }
        public int lowCard() {
            return hand[0].cardValue;
        }
    }
}
