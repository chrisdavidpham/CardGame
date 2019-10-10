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
            if (hand.getCount() < 5) {
                throw new IndexOutOfRangeException();
            }
            string handString = "";
            for (int i = 0; i < 4; i++) {
                handString += hand.at(i).cardValue + "-" + hand.at(i).cardSuit + ", ";
            }
            handString += hand.at(4).cardValue + "-" + hand.at(4).cardSuit;
            return handString;
        }
    }
}
