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
        public Hand newFourOfAKindHand(int val) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(val, 1));
            cardList.Add(new Card(val, 2));
            cardList.Add(new Card(val, 3));
            cardList.Add(new Card(val, 4));
            cardList.Add(new Card(val+1, 1));
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
        public Hand newStraightHand(int offset) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2 + offset, 1));
            cardList.Add(new Card(3 + offset, 2));
            cardList.Add(new Card(4 + offset, 3));
            cardList.Add(new Card(5 + offset, 4));
            cardList.Add(new Card(6 + offset, 1));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newFlushHand(int offset, int suit) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2 + offset, suit));
            cardList.Add(new Card(4 + offset, suit));
            cardList.Add(new Card(6 + offset, suit));
            cardList.Add(new Card(8 + offset, suit));
            cardList.Add(new Card(10 + offset, suit));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newFullHouseHand(int offset) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2 + offset, 1));
            cardList.Add(new Card(2 + offset, 2));
            cardList.Add(new Card(2 + offset, 3));
            cardList.Add(new Card(3 + offset, 4));
            cardList.Add(new Card(3 + offset, 1));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newTwoPairHand(int pairVal1, int pairVal2, int kickerVal) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(pairVal1, 1));
            cardList.Add(new Card(pairVal1, 2));
            cardList.Add(new Card(pairVal2, 3));
            cardList.Add(new Card(pairVal2, 4));
            cardList.Add(new Card(kickerVal, 1));
            Hand h = new Hand(cardList);
            return h;
        }
        public Hand newHand(int kickerVal1, int kickerVal2, int kickerVal3, int kickerVal4, int kickerVal5) {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(kickerVal1, 1));
            cardList.Add(new Card(kickerVal2, 2));
            cardList.Add(new Card(kickerVal3, 3));
            cardList.Add(new Card(kickerVal4, 4));
            cardList.Add(new Card(kickerVal5, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Table newFourOfAKindTable() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFourOfAKindHand(2);
            Hand hand2 = newFourOfAKindHand(4);
            Hand hand3 = newFourOfAKindHand(3);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newSingleFourOfAKindTable() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFourOfAKindHand(2);
            Player player1 = new Player("player1", hand1);
            playerList.Add(player1);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightFlushTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightFlushHand(0, 1);
            Hand hand2 = newStraightFlushHand(1, 2);
            Hand hand3 = newStraightFlushHand(2, 3);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightFlushTableTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightFlushHand(0, 1);
            Hand hand2 = newStraightFlushHand(0, 2);
            Hand hand3 = newStraightFlushHand(0, 3);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightHand(0);
            Hand hand2 = newStraightHand(2);
            Hand hand3 = newStraightHand(0);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newStraightTableTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newStraightHand(0);
            Hand hand2 = newStraightHand(0);
            Hand hand3 = newStraightHand(0);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newFlushTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFlushHand(4, 1);
            Hand hand2 = newFlushHand(2, 2);
            Hand hand3 = newFlushHand(0, 3);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newFlushTableWinnerTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFlushHand(0, 1);
            Hand hand2 = newFlushHand(0, 2);
            Hand hand3 = newFlushHand(0, 3);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newFullHouseTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newFullHouseHand(0);
            Hand hand2 = newFullHouseHand(4);
            Hand hand3 = newFullHouseHand(2);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newTwoPairTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newTwoPairHand(4,5,10);
            Hand hand2 = newTwoPairHand(4,5,11);
            Hand hand3 = newTwoPairHand(2,3,5);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newTwoPairTableTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newTwoPairHand(4, 5, 10);
            Hand hand2 = newTwoPairHand(4, 5, 10);
            Hand hand3 = newTwoPairHand(2, 3, 5);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newOnePairTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newHand(14, 5, 4, 3, 14);
            Hand hand2 = newHand(3, 14, 2, 14, 4);
            Hand hand3 = newHand(13, 11, 12, 10, 13);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newOnePairTableWinnerTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newHand(14, 14, 5, 4, 3);
            Hand hand2 = newHand(5, 4, 3, 14, 14);
            Hand hand3 = newHand(13, 13, 12, 10, 8);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newHighCardTableWinner() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newHand(14, 6, 5, 4, 3);
            Hand hand2 = newHand(14, 7, 6, 3, 2);
            Hand hand3 = newHand(12, 10, 9, 8, 4);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }
        public Table newHighCardTableWinnerTie() {
            List<Player> playerList = new List<Player>();
            Hand hand1 = newHand(2, 3, 4, 5, 6);
            Hand hand2 = newHand(2, 3, 4, 5, 6);
            Hand hand3 = newHand(2, 3, 4, 5, 6);
            Player player1 = new Player("player1", hand1);
            Player player2 = new Player("player2", hand2);
            Player player3 = new Player("player3", hand3);
            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            Table newTable = new CardGame.Table(playerList);
            return newTable;
        }

        [TestMethod]
        public void testFourOfAKindWinner() {
            Table table = newFourOfAKindTable();
            table.evaluateWinner();
            Assert.IsTrue(table.fourOfAKindPlayers.Count == 3);
            Assert.IsTrue(table.winningPlayer.name == "player2");
        }
        [TestMethod]
        public void testSingleFourOfAKindWinner() {
            Table table = newSingleFourOfAKindTable();
            table.evaluateWinner();
            Assert.IsTrue(table.fourOfAKindPlayers.Count == 1);
            Assert.IsTrue(table.winningPlayer.name == "player1");
        }
        [TestMethod]
        public void testStraightFlushWinner() {
            Table table = newStraightFlushTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.straightFlushPlayers.Count == 3);
            Assert.IsTrue(table.winningPlayer.name == "player3");
            Assert.IsTrue(table.tiePlayers.Count == 0);
        }
        [TestMethod]
        public void testStraightFlushWinnerTie() {
            Table table = newStraightFlushTableTie();
            table.evaluateWinner();
            Assert.IsTrue(table.straightFlushPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 3);
            Assert.IsNull(table.winningPlayer);
        }
        [TestMethod]
        public void testStraighthWinner() {
            Table table = newStraightTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.straightPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 0);
            Assert.IsTrue(table.winningPlayer.name == "player2");
        }
        [TestMethod]
        public void testStraighthWinnerTie() {
            Table table = newStraightTableTie();
            table.evaluateWinner();
            Assert.IsTrue(table.straightPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 3);
            Assert.IsNull(table.winningPlayer);
        }
        [TestMethod]
        public void testFlushWinner() {
            Table table = newFlushTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.flushPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 0);
            Assert.IsTrue(table.winningPlayer.name == "player1");
        }
        [TestMethod]
        public void testFlushWinnerTie() {
            Table table = newFlushTableWinnerTie();
            table.evaluateWinner();
            Assert.IsTrue(table.flushPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 3);
            Assert.IsNull(table.winningPlayer);
        }
        [TestMethod]
        public void testFullHouseWinner() {
            Table table = newFullHouseTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.fullHousePlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 0);
            Assert.IsTrue(table.winningPlayer.name == "player2");
        }
        [TestMethod]
        public void testTwoPairWinner() {
            Table table = newTwoPairTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.twoPairPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 0);
            Assert.IsTrue(table.winningPlayer.name == "player2");
        }
        [TestMethod]
        public void testTwoPairWinnerTie() {
            Table table = newTwoPairTableTie();
            table.evaluateWinner();
            Assert.IsTrue(table.twoPairPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 2);
            Assert.IsNull(table.winningPlayer);
        }
        [TestMethod]
        public void testOnePairWinner() {
            Table table = newOnePairTableWinner();
            table.evaluateWinner();
            Assert.IsTrue(table.onePairPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 0);
            Assert.IsTrue(table.winningPlayer.name == "player1");
        }
        [TestMethod]
        public void testOnePairWinnerTie() {
            Table table = newOnePairTableWinnerTie();
            table.evaluateWinner();
            Assert.IsTrue(table.onePairPlayers.Count == 3);
            Assert.IsTrue(table.tiePlayers.Count == 2);
            Assert.IsNull(table.winningPlayer);
        }
    }
}
