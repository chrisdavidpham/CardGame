using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Hand {
        private List<Card> hand;
        public List<Card> fourOfAKindKickers { get; private set; }
        public List<Card> straightKickers { get; private set; }
        public List<Card> flushKickers { get; private set; }
        public List<Card> fullHouseKickers { get; private set; }
        public List<Card> threeOfAKindKickers { get; private set; }
        public List<Card> twoPairKickers { get; private set; }
        public List<Card> onePairKickers { get; private set; }
        public List<Card> highCardKickers { get; private set; }
        public bool isFourOfAKind { get; private set; }
        public bool isStraight { get; private set; }
        public bool isFlush { get; private set; }
        public bool isFullHouse { get; private set; }
        public bool isThreeOfAKind { get; private set; }
        public bool isTwoPair { get; private set; }
        public bool isOnePair { get; private set; }

        public Hand(List<Card> cardList) {
            hand = cardList;

            // The kicker list stores the card values of a hand in descending order.
            // Kickers are used to determine a winner in the event of a tie.
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
            // Get one of the five cards in hand by index.
            if (index < 0 || index > 4) {
                throw new IndexOutOfRangeException();
            }
            return hand[index];
        }

        public void evaluateFourOfAKind() {
            // Get the value of four of a kind and add it as the first kicker value. Add the remaining kicker card to kicker list.
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[0].cardValue == hand[3].cardValue) {
                fourOfAKindKickers.Add(hand[0]);
                fourOfAKindKickers.Add(hand[4]);
            }
            if (hand[1].cardValue == hand[2].cardValue && hand[1].cardValue == hand[3].cardValue && hand[1].cardValue == hand[4].cardValue) {
                fourOfAKindKickers.Add(hand[1]);
                fourOfAKindKickers.Add(hand[0]);
            }
        }

        public void evaluateStraight() {
            // Determine if card values form a straight
            bool straight = true;
            for (int i = 0; i < 4; i++) {
                if (hand[i].cardValue + 1 != hand[i + 1].cardValue) {
                    straight = false;
                    break;
                }
            }
            if (straight) {
                // Hand is sorted in ascending order. Add cards to kicker list in descending order.
                for (int i = 4; i >= 0; i--) {
                    straightKickers.Add(hand[i]);
                }
            }
        }

        public void evaluateFlush() {
            // Check if all cards in hand are of the same suit.
            if (hand[0].cardSuit == hand[1].cardSuit && hand[0].cardSuit == hand[2].cardSuit && hand[0].cardSuit == hand[3].cardSuit && hand[0].cardSuit == hand[4].cardSuit) {
                // Hand is sorted in ascending order. Add cards to kicker list in descending order.
                for (int i=4; i>=0; i--) {
                    flushKickers.Add(hand[i]);
                }
            }
        }

        public void evaluateFullHouse() {
            // Check for a full house hand and add the values of the three-of-a-kind to kickersfollowed by the value of the two pair.
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue && hand[3].cardValue == hand[4].cardValue) {
                fullHouseKickers.Add(hand[0]);
                fullHouseKickers.Add(hand[3]);
            }
            if (hand[0].cardValue == hand[1].cardValue && hand[2].cardValue == hand[3].cardValue && hand[2].cardValue == hand[4].cardValue) {
                fullHouseKickers.Add(hand[2]);
                fullHouseKickers.Add(hand[0]);
            }
        }

        public void evaluateThreeOfAKind() {
            // Check for three-of-a-kind and add the three-of-a-kind value to kickers
            // followed by the last two kicker cards in descending order.
            if (hand[0].cardValue == hand[1].cardValue && hand[0].cardValue == hand[2].cardValue) {
                threeOfAKindKickers.Add(hand[0]);
                threeOfAKindKickers.Add(hand[4]);
                threeOfAKindKickers.Add(hand[3]);
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

        public void evaluateOnePair() {
            // Check for one-pair and add the one-pair value to kickers followed by the
            // last three kicker cards in descending order.
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

        public void evaluateTwoPair() {
            // Store the card values of each pair in indices one and two. Store kicker card in the last index.
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
                // Sort the values of the pairs in descending order.
                if (twoPair[0].cardValue < twoPair[1].cardValue) {
                    Card temp = twoPair[0];
                    twoPair[0] = twoPair[1];
                    twoPair[1] = temp;
                }
                // Store the higher valued pair in first index, followed by the remaining pair and remaining card as kickers.
                twoPairKickers.Add(twoPair[0]);
                twoPairKickers.Add(twoPair[1]);
                twoPairKickers.Add(twoPair[2]);
            }
        }

        public void evaluateHighCard() {
            // Add cards to kickers in descending order
            for (int i=4; i>=0; i--) {
                highCardKickers.Add(hand[i]);
            }
        }

        public void evaluateHand() {
            evaluateFourOfAKind();
            evaluateStraight();
            evaluateFlush();
            evaluateFullHouse();
            evaluateThreeOfAKind();
            evaluateTwoPair();
            evaluateOnePair();
            evaluateHighCard();

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
