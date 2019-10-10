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
            h.evaluateHand();
            Assert.IsTrue(h.isFourOfAKind);
        }
        [TestMethod()]
        public void getFourOfAKindFalseTest() {
            Hand h = newStraightHand();
            h.evaluateHand();
            Assert.IsFalse(h.isFourOfAKind);
        }

        [TestMethod()]
        public void getStraightTrueTest() {
            Hand h = newStraightHand();
            h.evaluateHand();
            Assert.IsTrue(h.isStraight);
        }
        [TestMethod()]
        public void getStraightFalseTest() {
            Hand h = newFourOfAKindHand();
            h.evaluateHand();
            Assert.IsFalse(h.isStraight);
        }

        [TestMethod()]
        public void getFullHouseTrueTest() {
            Hand h = newFullHouseHand();
            h.evaluateHand();
            Assert.IsTrue(h.isFullHouse);
        }
        [TestMethod()]
        public void getFullHouseFalseTest() {
            Hand h = newStraightHand();
            h.evaluateHand();
            Assert.IsFalse(h.isFullHouse);
        }

        [TestMethod()]
        public void getOnePairTrueTest() {
            Hand h = newOnePairHand();
            h.evaluateHand();
            Assert.IsTrue(h.isOnePair);
        }
        [TestMethod()]
        public void getOnePairFalseTest() {
            Hand h = newHighCardHand();
            h.evaluateHand();
            Assert.IsFalse(h.isOnePair);
        }

        [TestMethod()]
        public void getTwoPairTrueTest() {
            Hand h = newFullHouseHand();
            h.evaluateHand();
            Assert.IsTrue(h.isTwoPair);
        }
        [TestMethod()]
        public void getTwoPairFalseTest() {
            Hand h = newHighCardHand();
            h.evaluateHand();
            Assert.IsFalse(h.isTwoPair);
        }

        [TestMethod()]
        public void getFlushTrueTest() {
            Hand h = newFlushHand();
            h.evaluateHand();
            Assert.IsTrue(h.isFlush);
        }
        [TestMethod()]
        public void getFlushFalseTest() {
            Hand h = newHighCardHand();
            h.evaluateHand();
            Assert.IsFalse(h.isFlush);
        }

        [TestMethod()]
        public void getThreeOfAKindTrueTest() {
            Hand h = newFullHouseHand();
            h.evaluateHand();
            Assert.IsTrue(h.isThreeOfAKind);
        }
        [TestMethod()]
        public void getThreeOfAKindFalseTest() {
            Hand h = newStraightHand();
            h.evaluateHand();
            Assert.IsFalse(h.isThreeOfAKind);
        }
    }
}
