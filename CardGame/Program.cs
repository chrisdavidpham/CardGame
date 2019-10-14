using System;
using System.Collections.Generic;

namespace CardGame {
    public class CardGame {
        static int Main(string[] args) {
            if (0 == args.Length) {
                Console.WriteLine("No input file is specified. A file must be provided. Press enter to continue");
                Console.ReadLine();
                return 0;
            }

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
                        playerHand.Add(gameDeck.drawRandomCard());
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
                Console.WriteLine(players[i].getHandString());
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