using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame {
    public class Player {
        public Hand hand;
        public string name;

        public Player(string playerName, List<Card> cardList) {
            name = playerName;
            hand = new Hand(cardList);
        }

        public string getHandString() {
            if (hand.getCount() < 5) {
                throw new IndexOutOfRangeException();
            }
            string handString = "";
            for (int i = 0; i < 4; i++) {
                handString += hand.at(i).cardSuit + "-" + hand.at(i).cardValue + ", ";
            }
            handString += hand.at(4).cardSuit + "-" + hand.at(4).cardValue;
            return handString;
        }
    }
}
