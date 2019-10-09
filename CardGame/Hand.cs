using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Hand {
        private List<Card> hand;
        public List<Card> fourOfAKindKickers;
        public List<Card> straightKickers;
        public List<Card> flushKickers;
        public List<Card> fullHouseKickers;
        public List<Card> threeOfAKindKickers;
        public List<Card> twoPairKickers;
        public List<Card> onePairKickers;
        public List<Card> highCardKickers;
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
            fullHouseKickers = new List<Card>();
            threeOfAKindKickers = new List<Card>();
            twoPairKickers = new List<Card>();
            onePairKickers = new List<Card>();
            highCardKickers = new List<Card>();
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

        public Card at(int index) {
            if (index < 0 || index > 4) {
                throw new IndexOutOfRangeException();
            }
            return hand[index];
        }

        // get value of four of a kind, 0 if not applicable
        public void getFourOfAKind() {
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[3].cardValue) {
                fourOfAKindKickers.Add(hand[0]);
                fourOfAKindKickers.Add(hand[4]);
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                fourOfAKindKickers.Add(hand[1]);
                fourOfAKindKickers.Add(hand[0]);
            }
        }

        public void getStraight() {
            bool straight = true;
            for (int i = 0; i < 4; i++) {
                if (hand[i].cardValue + 1 != hand[i + 1].cardValue) {
                    straight = false;
                    break;
                }
            }
            if (straight) {
                straightKickers.Add(hand[4]);
                straightKickers.Add(hand[3]);
                straightKickers.Add(hand[2]);
                straightKickers.Add(hand[1]);
                straightKickers.Add(hand[0]);
            }
        }

        public void getFlush() {
            if (hand[0].cardSuit == hand[1].cardSuit && hand[0].cardSuit == hand[2].cardSuit && hand[0].cardSuit == hand[3].cardSuit && hand[0].cardSuit == hand[4].cardSuit) {
                for(int i=4; i>=0; i--) {
                    flushKickers.Add(hand[i]);
                }
            }
        }

        public void getFullHouse() {
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                fullHouseKickers.Add(hand[0]);
                fullHouseKickers.Add(hand[3]);
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                fullHouseKickers.Add(hand[2]);
                fullHouseKickers.Add(hand[0]);
            }
        }

        public void getThreeOfAKind() {
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue) {
                threeOfAKindKickers.Add(hand[0]);
                threeOfAKindKickers.Add(hand[3]);
                threeOfAKindKickers.Add(hand[4]);
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue) {
                threeOfAKindKickers.Add(hand[1]);
                threeOfAKindKickers.Add(hand[4]);
                threeOfAKindKickers.Add(hand[0]);
            }
            if (hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                threeOfAKindKickers.Add(hand[2]);
                threeOfAKindKickers.Add(hand[1]);
                threeOfAKindKickers.Add(hand[0]);
            }
        }

        public void getOnePair() {
            if (hand[0].cardValue == hand[1].cardValue) {
                onePairKickers.Add(hand[0]);
                onePairKickers.Add(hand[4]);
                onePairKickers.Add(hand[3]);
                onePairKickers.Add(hand[2]);
            }
            if (hand[1].cardValue == hand[2].cardValue) {
                onePairKickers.Add(hand[1]);
                onePairKickers.Add(hand[4]);
                onePairKickers.Add(hand[3]);
                onePairKickers.Add(hand[0]);
            }
            if (hand[2].cardValue == hand[3].cardValue) {
                onePairKickers.Add(hand[2]);
                onePairKickers.Add(hand[4]);
                onePairKickers.Add(hand[1]);
                onePairKickers.Add(hand[0]);
            }
            if (hand[3].cardValue == hand[4].cardValue) {
                onePairKickers.Add(hand[3]);
                onePairKickers.Add(hand[2]);
                onePairKickers.Add(hand[1]);
                onePairKickers.Add(hand[0]);
            }
        }

        public void getTwoPair() {
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
                // sort pairs descending
                if (twoPair[0].cardValue < twoPair[1].cardValue) {
                    Card temp = twoPair[0];
                    twoPair[0] = twoPair[1];
                    twoPair[1] = temp;
                }
                twoPairKickers.Add(twoPair[0]);
                twoPairKickers.Add(twoPair[1]);
                twoPairKickers.Add(twoPair[2]);
            }
        }

        public void getHighCard() {
            for (int i=4; i>=0; i--) {
                highCardKickers.Add(hand[i]);
            }
        }

        public void evaluateHand() {
            getFourOfAKind();
            getStraight();
            getFlush();
            getFullHouse();
            getThreeOfAKind();
            getTwoPair();
            getOnePair();
            getHighCard();

            if(fourOfAKindKickers.Count > 0) {
                isFourOfAKind = true;
            }
            if(straightKickers.Count > 0) {
                isStraight = true;
            }
            if(flushKickers.Count > 0) {
                isFlush = true;
            }
            if(fullHouseKickers.Count > 0) {
                isFullHouse = true;
            }
            if(threeOfAKindKickers.Count > 0) {
                isThreeOfAKind = true;
            } 
            if (twoPairKickers.Count > 0) {
                isTwoPair = true;
            }
            if (onePairKickers.Count > 0) {
                isOnePair = true;
            }
        }
    }
}
