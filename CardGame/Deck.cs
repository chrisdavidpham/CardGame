﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Deck {
        private List<Card> cardList;
        private static readonly Random random = new Random();

        public Deck() {
            cardList = new List<Card>();

            // Add all 52 cards of a standard deck to cardList.
            for (int i = 1; i <= 4; i++) {
                for (int j = 2; j <= 14; j++) {
                    cardList.Add(new Card(j, i));
                }
            }
        }

        public Card drawRandomCard() {
            // Get a Card from a random index in cardList, remove it from the cardList and return it.
            if (cardList.Count == 0) {
                throw new System.InvalidOperationException("Empty deck");
            }
            int max = cardList.Count;
            int randomInt = random.Next(max);
            Card randomCard = cardList[randomInt];
            cardList.RemoveAt(randomInt);
            return randomCard;
        }

        public int getCount() {
            return cardList.Count;
        }
    }
}
