using System;
using System.Collections.Generic;

namespace CardGame {
    public class CardGame {
        static int Main(string[] args) {
            List<Player> players = new List<Player>();
            string line = "";
            System.IO.StreamReader file = new System.IO.StreamReader(args[0]);

            Deck gameDeck = new Deck();

            while ((line = file.ReadLine()) != null) {
                if (String.IsNullOrWhiteSpace(line)) {
                    continue;
                }
                
                List<Card> playerHand = new List<Card>();

                for (int j = 0; j < 5; j++) {
                    try {
                        playerHand.Add(gameDeck.getRandom());
                    }
                    catch (System.InvalidOperationException ex) {
                        //System.InvalidOperationException emptyEx = new System.InvalidOperationException("There are not enough cards for all the players");
                        //throw emptyEx;
                        Console.WriteLine("There are not enough cards for all the players. Press enter to continue");
                        Console.ReadLine();
                        return 1;
                    }
                }

                Player newPlayer = new Player(line, playerHand);
                players.Add(newPlayer);
            }

            if (0 == players.Count) {
                Console.WriteLine("There are no players. Press enter to continue");
                Console.ReadLine();
                return 0;
            }

            Console.WriteLine("Welcome players");
            for (int i = 0; i < players.Count; i++) {
                Console.WriteLine(players[i].name + " : " + players[i].getHandString());
                
                if (players[i].hand.getFourOfAKind() > 0) {
                    Console.WriteLine("fourOfAKind: true");
                }
                else {
                    Console.WriteLine("fourOfAKind: false");
                }

                if (players[i].hand.getFullHouse() > 0) {
                    Console.WriteLine("fullHouse: true");
                }
                else {
                    Console.WriteLine("fullHouse: false");
                }

                if (players[i].hand.getFlush()) {
                    Console.WriteLine("flush: true");
                }
                else {
                    Console.WriteLine("flush: false");
                }

                if (players[i].hand.getStraight() > 0) {
                    Console.WriteLine("straight: true");
                }
                else {
                    Console.WriteLine("straight: false");
                }

                if (players[i].hand.getThreeOfAKind() > 0) {
                    Console.WriteLine("threeOfAKind: true");
                }
                else {
                    Console.WriteLine("threeOfAKind: false");
                }

                int[] twoPair = players[i].hand.getTwoPair();
                if (twoPair[0] > 0) {
                    Console.WriteLine("twoPair: true");
                }
                else {
                    Console.WriteLine("twoPair: false");
                }

                if (players[i].hand.getOnePair() > 0) {
                    Console.WriteLine("onePair: true");
                }
                else {
                    Console.WriteLine("onePair: false");
                }
            }

            Console.WriteLine("Done! Press enter to continue");
            Console.ReadLine();
            return 0;
        }
    }
}