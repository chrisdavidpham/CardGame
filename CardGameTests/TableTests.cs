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
        public Hand newFourOfAKindHand1() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(2, 2));
            cardList.Add(new Card(2, 3));
            cardList.Add(new Card(2, 4));
            cardList.Add(new Card(4, 1));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newFourOfAKindHand2() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(3, 1));
            cardList.Add(new Card(3, 2));
            cardList.Add(new Card(3, 3));
            cardList.Add(new Card(3, 4));
            cardList.Add(new Card(4, 2));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newStraightFlushHand(int offset, int suit) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2 + offset, suit));
            cardList.Add(new Card(3 + offset, suit));
            cardList.Add(new Card(4 + offset, suit));
            cardList.Add(new Card(5 + offset, suit));
            cardList.Add(new Card(6 + offset, suit));
            Hand h = new Hand(cardList);
            return h;
        }

        public Table newFourOfAKindTable() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFourOfAKindHand1();
            Hand hand2 = newFourOfAKindHand2();
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            playerList.Add(player1);
            playerList.Add(player2);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightFlushTable1() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightFlushHand(0, 1);
            Hand hand2 = newStraightFlushHand(1, 2);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            playerList.Add(player1);
            playerList.Add(player2);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightFlushTable2() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightFlushHand(0, 1);
            Hand hand2 = newStraightFlushHand(0, 2);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            playerList.Add(player1);
            playerList.Add(player2);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }

        [TestMethod]
        public void testFourOfAKindWinner() {
            Table table = newFourOfAKindTable();
            table.evaluateWinner();
            Assert.IsTrue(table.fourOfAKindPlayers.Count == 2);
            Assert.IsTrue(table.winningPlayer.name == "player2");
        }

        [TestMethod]
        public void testStraightFlushWinner2() {
            Table table = newStraightFlushTable2();
            table.evaluateWinner();
            Assert.IsTrue(table.straightFlushPlayers.Count == 2);
            Assert.IsTrue(table.tiePlayers.Count == 2);
            Assert.IsTrue(table.tiePlayers[0].name == "player2");
            Assert.IsTrue(table.tiePlayers[1].name == "player1");
            Assert.IsTrue(table.winningPlayer == null);
        }
        /*
        [TestMethod]
        public void testStraightFlushWinner1() {
            Table table = newStraightFlushTable1();
            table.evaluateWinner();
            Assert.IsTrue(table.straightFlushPlayers.Count == 2);
            Assert.IsTrue(table.winningPlayer.name == "player2");
            Assert.IsTrue(table.tiePlayers.Count == 0);
        }
        */
    }
}
