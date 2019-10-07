using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Hand {
        private List<Card> hand;
        List<Card> fourOfAKindKickers;
        List<Card> straightKickers;
        List<Card> flushKickers;
        List<Card> threeOfAKindKickers;
        List<Card> twoPairKickers;
        public bool isFourOfAKind;
        public bool isStraight;
        public bool isFlush;
        public bool isFullHouse;
        public bool isThreeOfAKind;
        public bool isTwoPair;
        public bool isOnePair;

        public Hand(List<Card> cardList) {
            hand = cardList;
            fourOfAKindKickers = new List<Card>();
            straightKickers = new List<Card>();
            flushKickers = new List<Card>();
            threeOfAKindKickers = new List<Card>();
            twoPairKickers = new List<Card>();
            isFourOfAKind = false;
            isStraight = false;
            isFlush = false;
            isFullHouse = false;
            isThreeOfAKind = false;
            isTwoPair = false;
            isOnePair = false;
            hand = sortAscending(hand);
        }

        public int getCount() {
            return hand.Count;
        }

        private List<Card> sortAscending(List<Card> cardList) {
            cardList.Sort(delegate (Card c1, Card c2) { return c1.cardValue.CompareTo(c2.cardValue); });
            return cardList;
        }
        private List<Card> sortDescending(List<Card> cardList) {
            cardList.Sort(delegate (Card c1, Card c2) { return c2.cardValue.CompareTo(c1.cardValue); });
            return cardList;
        }

        public Card At(int index) {
            if (index < 0 || index > 4) {
                throw new IndexOutOfRangeException();
            }
            return hand[index];
        }

        // get value of four of a kind, 0 if not applicable
        public int getFourOfAKind() {
            int val = 0;
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[3].cardValue) {
                val = hand[0].cardValue;
                fourOfAKindKickers.Add(hand[4]);
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                val = hand[1].cardValue;
                fourOfAKindKickers.Add(hand[0]);
            }
            return val;
        }

        public int getStraight() {
            bool straight = true;
            for (int i = 0; i < 4; i++) {
                if (hand[i].cardValue + 1 != hand[i + 1].cardValue) {
                    straight = false;
                    break;
                }
            }
            if (straight) {
                straightKickers.Add(hand[3]);
                straightKickers.Add(hand[2]);
                straightKickers.Add(hand[1]);
                straightKickers.Add(hand[0]);
                return hand[4].cardValue;
            }
            else {
                return 0;
            }
        }

        public int getFlush() {
            if (hand[0].cardSuit == hand[1].cardSuit && hand[0].cardSuit == hand[2].cardSuit && hand[0].cardSuit == hand[3].cardSuit && hand[0].cardSuit == hand[4].cardSuit) {
                for(int i=4; i>=0; i--) {
                    flushKickers.Add(hand[i]);
                }
                return hand[4].cardValue;
            }
            return 0;
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
                threeOfAKindKickers.Add(hand[3]);
                threeOfAKindKickers.Add(hand[4]);
                threeOfAKindKickers = sortDescending(threeOfAKindKickers);
                threeOfAKind = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue) {
                threeOfAKindKickers.Add(hand[0]);
                threeOfAKindKickers.Add(hand[4]);
                threeOfAKindKickers = sortDescending(threeOfAKindKickers);
                threeOfAKind = hand[1].cardValue;
            }
            if (hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                threeOfAKindKickers.Add(hand[0]);
                threeOfAKindKickers.Add(hand[1]);
                threeOfAKindKickers = sortDescending(threeOfAKindKickers);
                threeOfAKind = hand[2].cardValue;
            }
            return threeOfAKind;
        }

        public int getOnePair() {
            int onePair = 0;
            if (hand[0].cardValue == hand[1].cardValue) {
                onePair = hand[0].cardValue;
            }
            if (hand[1].cardValue == hand[2].cardValue) {
                onePair = hand[1].cardValue;
            }
            if (hand[2].cardValue == hand[3].cardValue) {
                onePair = hand[2].cardValue;
            }
            if (hand[3].cardValue == hand[4].cardValue) {
                onePair = hand[3].cardValue;
            }
            return onePair;
        }

        public int getTwoPair() {
            // store card values of each pair and kicker card in last index
            Card[] twoPair = new Card[3];
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[3].cardValue) {
                twoPair[0] = hand[0];
                twoPair[1] = hand[2];
                twoPair[2] = hand[4];
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[3].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[0];
                twoPair[1] = hand[3];
                twoPair[2] = hand[2];
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                twoPair[0] = hand[1];
                twoPair[1] = hand[3];
                twoPair[2] = hand[0];
            }

            if (twoPair[0] != null && twoPair[1] != null && twoPair[2] != null) {
                // sort descending
                if (twoPair[0].cardValue < twoPair[1].cardValue) {
                    Card temp = twoPair[0];
                    twoPair[0] = twoPair[1];
                    twoPair[1] = temp;
                }
                twoPairKickers.Add(twoPair[1]);
                twoPairKickers.Add(twoPair[2]);
                return twoPair[0].cardValue;
            }
            else {
                return 0;
            }
        }

        public int getHighCard() {
            return hand[4].cardValue;
        }

        public void evaluateHand() {
            int fourOfAKind = getFourOfAKind();
            int straight = getStraight();
            int flush = getFlush();
            int fullHouse = getFullHouse();
            int threeOfAKind = getThreeOfAKind();
            int twoPair = getTwoPair();
            int onePair = getOnePair();
            
            if(fourOfAKind > 0) {
                isFourOfAKind = true;
            }
            if(straight > 0) {
                isStraight = true;
            }
            if(flush > 0) {
                isFlush = true;
            }
            if(fullHouse > 0) {
                isFullHouse = true;
            }
            if(threeOfAKind > 0) {
                isThreeOfAKind = true;
            } 
            if (twoPair > 0) {
                isTwoPair = true;
            }
            if (onePair > 0) {
                isOnePair = true;
            }
        }
    }
}
