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
                List<Card> playerHand = new List<Card>();

                if (String.IsNullOrWhiteSpace(line)) {
                    continue;
                }

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
            }

            Console.WriteLine("Done! Press enter to continue");
            Console.ReadLine();
            return 0;
        }
    }
}