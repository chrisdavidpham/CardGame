using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Tests {
    [TestClass()]
    public class HandTests {

        public Hand newFourOfAKindHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(2, 2));
            cardList.Add(new Card(2, 3));
            cardList.Add(new Card(2, 4));
            cardList.Add(new Card(3, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Hand newStraightHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(3, 2));
            cardList.Add(new Card(4, 3));
            cardList.Add(new Card(5, 4));
            cardList.Add(new Card(6, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Hand newFullHouseHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(2, 2));
            cardList.Add(new Card(2, 3));
            cardList.Add(new Card(3, 4));
            cardList.Add(new Card(3, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Hand newOnePairHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(5, 2));
            cardList.Add(new Card(10, 3));
            cardList.Add(new Card(14, 4));
            cardList.Add(new Card(14, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Hand newHighCardHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(5, 2));
            cardList.Add(new Card(10, 3));
            cardList.Add(new Card(12, 4));
            cardList.Add(new Card(14, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        public Hand newFlushHand() {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(2, 1));
            cardList.Add(new Card(5, 1));
            cardList.Add(new Card(10, 1));
            cardList.Add(new Card(12, 1));
            cardList.Add(new Card(14, 1));
            Hand h = new Hand(cardList);
            return h;
        }

        [TestMethod()]
        public void getFourOfAKindTrueTest() {
            Hand h = newFourOfAKindHand();
            int val = h.getFourOfAKind();
            Assert.IsTrue(2 == val);
            Assert.IsTrue(h.isFourOfAKind);
        }
        [TestMethod()]
        public void getFourOfAKindFalseTest() {
            Hand h = newStraightHand();
            int val = h.getFourOfAKind();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isFourOfAKind);
        }

        [TestMethod()]
        public void getStraightTrueTest() {
            Hand h = newStraightHand();
            int val = h.getStraight();
            Assert.IsTrue(6 == val);
            Assert.IsTrue(h.isStraight);
        }
        [TestMethod()]
        public void getStraightFalseTest() {
            Hand h = newFourOfAKindHand();
            int val = h.getStraight();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isStraight);
        }

        [TestMethod()]
        public void getFullHouseTrueTest() {
            Hand h = newFullHouseHand();
            int val = h.getFullHouse();
            Assert.IsTrue(3 == val);
            Assert.IsTrue(h.isFullHouse);
        }
        [TestMethod()]
        public void getFullHouseFalseTest() {
            Hand h = newStraightHand();
            int val = h.getFullHouse();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isFullHouse);
        }

        [TestMethod()]
        public void getOnePairTrueTest() {
            Hand h = newOnePairHand();
            int val = h.getOnePair();
            Assert.IsTrue(14 == val);
            Assert.IsTrue(h.isOnePair);
        }
        [TestMethod()]
        public void getOnePairFalseTest() {
            Hand h = newHighCardHand();
            int val = h.getOnePair();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isOnePair);
        }

        [TestMethod()]
        public void getTwoPairTrueTest() {
            Hand h = newFullHouseHand();
            int val = h.getTwoPair();
            Assert.IsTrue(val == 3);
            Assert.IsTrue(h.isTwoPair);
        }
        [TestMethod()]
        public void getTwoPairFalseTest() {
            Hand h = newHighCardHand();
            int val = h.getTwoPair();
            Assert.IsTrue(val == 0);
            Assert.IsFalse(h.isTwoPair);
        }

        [TestMethod()]
        public void getFlushTrueTest() {
            Hand h = newFlushHand();
            int val = h.getFlush();
            Assert.IsTrue(val != 0);
            Assert.IsTrue(h.isFlush);
        }
        [TestMethod()]
        public void getFlushFalseTest() {
            Hand h = newHighCardHand();
            int val = h.getFlush();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isFlush);
        }

        [TestMethod()]
        public void getThreeOfAKindTrueTest() {
            Hand h = newFullHouseHand();
            int val = h.getThreeOfAKind();
            Assert.IsTrue(2 == val);
            Assert.IsTrue(h.isThreeOfAKind);
        }
        [TestMethod()]
        public void getThreeOfAKindFalseTest() {
            Hand h = newStraightHand();
            int val = h.getThreeOfAKind();
            Assert.IsTrue(0 == val);
            Assert.IsFalse(h.isThreeOfAKind);
        }
    }
}
