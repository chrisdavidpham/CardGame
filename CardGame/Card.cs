using System;

namespace CardGame {
    public class Card {
        public Card(int val, int suit) {
            cardValue = val;
            cardSuit = suit;
        }

        public int cardValue;
        public int cardSuit;
    }
}