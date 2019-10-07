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

                if (players[i].hand.isFourOfAKind) {
                    Console.WriteLine("Four of a kind");
                }
                else if (players[i].hand.isStraight && players[i].hand.isFlush) {
                    Console.WriteLine("Straight flush");
                }
                else if (players[i].hand.isFlush) {
                    Console.WriteLine("Flush");
                }
                else if (players[i].hand.isStraight) {
                    Console.WriteLine("Straight");
                }
                else if (players[i].hand.isFullHouse) {
                    Console.WriteLine("Full House");
                }
                else if (players[i].hand.isThreeOfAKind) {
                    Console.WriteLine("Three of a Kind");
                }
                else if (players[i].hand.isTwoPair) {
                    Console.WriteLine("Two Pair");
                }
                else if (players[i].hand.isOnePair) {
                    Console.WriteLine("One Pair");
                }
                else {
                    Console.WriteLine("High card");
                }
            }

            Console.WriteLine("Done! Press enter to continue");
            Console.ReadLine();
            return 0;
        }
    }
}