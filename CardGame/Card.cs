using System;

namespace CardGame {
    public class Card {
        public Card(int val, int suit) {
            if (val < 2 || val > 14) {
                throw new ArgumentException("value not in range 2-14");
            }
            if (suit < 1 || suit > 4) {
                throw new ArgumentException("suit not in range 1-4");
            }
            cardValue = val;
            cardSuit = suit;
        }

        public int cardValue;
        public int cardSuit;
    }
}