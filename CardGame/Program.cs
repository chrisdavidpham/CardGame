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

            Table table = new Table(players);
            table.evaluateWinner();

            Console.WriteLine("Welcome players. Cards are represented as Value-Suit");
            for (int i = 0; i < players.Count; i++) {
                Console.WriteLine(players[i].name + " :");

                if (players[i].hand.isFourOfAKind) {
                    Console.WriteLine(players[i].getHandString() + " - Four of a kind");
                }
                else if (players[i].hand.isStraight && players[i].hand.isFlush) {
                    Console.WriteLine(players[i].getHandString() + " - Straight flush");
                }
                else if (players[i].hand.isFlush) {
                    Console.WriteLine(players[i].getHandString() + " - Flush");
                }
                else if (players[i].hand.isStraight) {
                    Console.WriteLine(players[i].getHandString() + " - Straight");
                }
                else if (players[i].hand.isFullHouse) {
                    Console.WriteLine(players[i].getHandString() + " - Full House");
                }
                else if (players[i].hand.isThreeOfAKind) {
                    Console.WriteLine(players[i].getHandString() + " - Three of a Kind");
                }
                else if (players[i].hand.isTwoPair) {
                    Console.WriteLine(players[i].getHandString() + " - Two Pair");
                }
                else if (players[i].hand.isOnePair) {
                    Console.WriteLine(players[i].getHandString() + " - One Pair");
                }
                else {
                    Console.WriteLine(players[i].getHandString() + " - High card");
                }
            }

            if (table.tiePlayers.Count > 0) {
                Console.WriteLine("It's a tie between these players");
                for(int i=0; i<table.tiePlayers.Count; i++) {
                    Console.WriteLine(table.tiePlayers[i].name);
                }
            }
            else {
                String winner = table.winningPlayer.name;
                Console.WriteLine("The winner is " + winner);
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            return 0;
        }
    }
}