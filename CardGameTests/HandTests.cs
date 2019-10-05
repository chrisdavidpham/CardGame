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
            List<Card> fourOfAKindList = new List<Card>();
            fourOfAKindList.Add(new Card(2, 1));
            fourOfAKindList.Add(new Card(2, 2));
            fourOfAKindList.Add(new Card(2, 3));
            fourOfAKindList.Add(new Card(2, 4));
            fourOfAKindList.Add(new Card(3, 1));
            Hand h = new Hand(fourOfAKindList);
            return h;
        }

        public Hand newStraightHand() {
            List<Card> straightList = new List<Card>();
            straightList.Add(new Card(2, 1));
            straightList.Add(new Card(3, 2));
            straightList.Add(new Card(4, 3));
            straightList.Add(new Card(5, 4));
            straightList.Add(new Card(6, 1));
            Hand h = new Hand(straightList);
            return h;
        }

        public Hand newFullHouseHand() {
            List<Card> straightList = new List<Card>();
            straightList.Add(new Card(2, 1));
            straightList.Add(new Card(2, 2));
            straightList.Add(new Card(2, 3));
            straightList.Add(new Card(3, 4));
            straightList.Add(new Card(3, 1));
            Hand h = new Hand(straightList);
            return h;
        }

        public Hand newOnePairHand() {
            List<Card> straightList = new List<Card>();
            straightList.Add(new Card(2, 1));
            straightList.Add(new Card(5, 2));
            straightList.Add(new Card(10, 3));
            straightList.Add(new Card(14, 4));
            straightList.Add(new Card(14, 1));
            Hand h = new Hand(straightList);
            return h;
        }

        public Hand newHighCardHand() {
            List<Card> straightList = new List<Card>();
            straightList.Add(new Card(2, 1));
            straightList.Add(new Card(5, 2));
            straightList.Add(new Card(10, 3));
            straightList.Add(new Card(12, 4));
            straightList.Add(new Card(14, 1));
            Hand h = new Hand(straightList);
            return h;
        }

        [TestMethod()]
        public void getFourOfAKindTrueTest() {
            Hand h = newFourOfAKindHand();
            int val = h.getFourOfAKind();
            Assert.IsTrue(2 == val);
        }
        [TestMethod()]
        public void getFourOfAKindFalseTest() {
            Hand h = newStraightHand();
            int val = h.getFourOfAKind();
            Assert.IsTrue(0 == val);
        }
        [TestMethod()]
        public void getStraightTrueTest() {
            Hand h = newStraightHand();
            int val = h.getStraight();
            Assert.IsTrue(6 == val);
        }
        [TestMethod()]
        public void getStraightFalseTest() {
            Hand h = newFourOfAKindHand();
            int val = h.getStraight();
            Assert.IsTrue(0 == val);
        }
        [TestMethod()]
        public void getFullHouseTrueTest() {
            Hand h = newFullHouseHand();
            int val = h.getFullHouse();
            Assert.IsTrue(3 == val);
        }
        [TestMethod()]
        public void getFullHouseFalseTest() {
            Hand h = newStraightHand();
            int val = h.getFullHouse();
            Assert.IsTrue(0 == val);
        }
        [TestMethod()]
        public void getOnePairTrueTest() {
            Hand h = newOnePairHand();
            int val = h.getOnePair();
            Assert.IsTrue(14 == val);
        }
        [TestMethod()]
        public void getOnePairFalseTest() {
            Hand h = newHighCardHand();
            int val = h.getOnePair();
            Assert.IsTrue(0 == val);
        }
        [TestMethod()]
        public void getTwoPairTrueTest() {
            Hand h = newFullHouseHand();
            int[] val = h.getTwoPair();
            Assert.IsTrue(val[0] == 3);
            Assert.IsTrue(val[1] == 2);
        }
        [TestMethod()]
        public void getTwoPairFalseTest() {
            Hand h = newHighCardHand();
            int[] val = h.getTwoPair();
            Assert.IsTrue(val[0] == 0);
            Assert.IsTrue(val[1] == 0);
        }
    }
}
