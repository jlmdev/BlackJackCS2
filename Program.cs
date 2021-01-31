using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCS2
{

    class Card
    {
        public string Suit { get; set; }
        public string Face { get; set; }
        public int Value()
        {
            switch (Face)
            {
                case "A":
                    return 11;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 10;
                case "Q":
                    return 10;
                case "K":
                    return 10;
                default:
                    return 0;
            }
        }
    }

    class Player
    {
        public string PlayerName { get; set; }
        public List<Card> Hand = new List<Card>();
        public int HandValue()
        {
            int handTotal = 0;
            foreach (Card cardInHand in Hand)
            {
                handTotal = handTotal + cardInHand.Value();
            }
            return handTotal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Prompt player for name
            Console.WriteLine("Welcome. What's your name?");
            string userName = Console.ReadLine();

            // Test userName population
            // Console.WriteLine($"Hi {userName}");

            // Create Deck
            var deck = new List<Card>();
            // Define arrays of suits and faces for assignment
            var assignedSuit = new string[] { "\u2660", "\u2663", "\u2665", "\u2666" };
            var assignedFace = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // Assign suits and faces to cards
            // Suit Loop
            foreach (var suit in assignedSuit)
            {
                // Face Loop
                foreach (var face in assignedFace)
                {
                    // create new card instance
                    var newCard = new Card();
                    {
                        // Assign suit and face to card
                        newCard.Suit = suit;
                        newCard.Face = face;
                    }

                    // Add new card to deck
                    deck.Add(newCard);
                }
            }

            // Test deck creation
            // foreach (var createdCard in deck)
            // {
            //     Console.WriteLine($"{createdCard.Face}{createdCard.Suit}");
            // }

            // Shuffling Algorithm

            // Declare Variables
            var numberOfCards = deck.Count();
            var randomNumberGenerator = new Random();

            // Shuffle Loop
            for (var rightIndex = numberOfCards - 1; rightIndex > 0; rightIndex--)
            {
                var leftIndex = randomNumberGenerator.Next(rightIndex);
                var leftCard = deck[rightIndex];
                var rightCard = deck[leftIndex];
                deck[rightIndex] = rightCard;
                deck[leftIndex] = leftCard;
            }

            // Test deck creation
            // foreach (var createdCard in deck)
            // {
            //     Console.WriteLine($"{createdCard.Face}{createdCard.Suit}");
            // }

            // Create Dealer player instance
            var dealer = new Player();
            {
                dealer.PlayerName = "Dealer";
            }

            Console.WriteLine($"{dealer.PlayerName}");

            // Create human player instance
            var humanPlayer = new Player();
            {
                humanPlayer.PlayerName = userName;
            }

            Console.WriteLine($"{humanPlayer.PlayerName}");
        }
    }
}
