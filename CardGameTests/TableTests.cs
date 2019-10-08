using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameTests {
    [TestClass]
    public class TableTests {

        public Table newFourOfAKindTable() {
            List<Player> playerList = new List<Player>();
            Deck deck = new Deck();
            for (int i = 0; i < 5; i++) {
                List<Card> cardList = new List<Card>();
                for (int j = 0; j < 5; j++) {
                    cardList.Add(deck.getRandom());
                }
                Player player = new Player("Player" + i, cardList);
                playerList.Add(player);
            }
        public Table newTable = new CardGame.Table(playerList);
        return newTable;
    }

        [TestMethod]
        public void TestFourOfAKindWinner() {

        }
    }
}
