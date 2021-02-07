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

            // Play again loop
            var playAgain = "y";
            while (playAgain == "y")
            {

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

                // Create Dealer player instance
                var dealer = new Player();
                {
                    dealer.PlayerName = "Dealer";
                }

                // Create human player instance
                var humanPlayer = new Player();
                {
                    humanPlayer.PlayerName = userName;
                }

                // Deal initial cards to the dealer
                dealer.Hand.Add(deck[0]);
                dealer.Hand.Add(deck[1]);

                // Remove Dealer's initial cards from deck
                deck.RemoveAt(0);
                deck.RemoveAt(0);

                // Deal initial cards to the Player
                humanPlayer.Hand.Add(deck[0]);
                humanPlayer.Hand.Add(deck[1]);

                // Remove Player's initial cards from deck
                deck.RemoveAt(0);
                deck.RemoveAt(0);

                // Player Choice Loop

                // Declare variables
                var dealAgain = "y";
                string hitStandLoop = "y";

                // Hit, stand, or bust
                while (dealAgain == "y")
                {
                    // Hit Stand Loop
                    while (hitStandLoop != "n")
                    {
                        // Show Player Hand
                        Console.WriteLine($"{humanPlayer.PlayerName}'s cards:");
                        foreach (var playerCard in humanPlayer.Hand)
                        {
                            Console.WriteLine($"{playerCard.Face}{playerCard.Suit} Value: {playerCard.Value()}");
                        }

                        // Display the current value of the hand
                        Console.WriteLine($"{humanPlayer.PlayerName}'s Hand Value: {humanPlayer.HandValue()}");

                        // Check for Bust condition
                        if (humanPlayer.HandValue() > 21)
                        {
                            dealAgain = "n";
                            hitStandLoop = "n";
                            break;
                        }

                        // Play Player hand
                        Console.WriteLine("Do you want to hit or stand?");
                        string hitStandResponse = Console.ReadLine();
                        switch (hitStandResponse)
                        {
                            case "h":
                                humanPlayer.Hand.Add(deck[0]);
                                deck.RemoveAt(0);
                                hitStandLoop = "y";
                                break;
                            case "s":
                                dealAgain = "n";
                                hitStandLoop = "n";
                                break;
                            default:
                                Console.WriteLine("H or S, please.");
                                break;
                        }
                    }
                }

                // Play Dealer Hand

                // Show Dealer's Hand
                string dealerStand = "default";
                while (dealerStand != "y")
                {
                    Console.WriteLine("Dealer's Hand:");
                    foreach (var dealerCard in dealer.Hand)
                    {
                        Console.WriteLine($"{dealerCard.Face} of {dealerCard.Suit} with value of {dealerCard.Value()}");
                    }

                    Console.WriteLine($"Dealer's Hand Value: {dealer.HandValue()}");

                    // Check the value of the dealer's hand

                    // Check for dealer stand conditions: Player Bust, Dealer > 16
                    if ((humanPlayer.HandValue() > 21) || (dealer.HandValue() > 16))
                    {
                        dealerStand = "y";
                    }
                    // Dealer draws a card if player has not busted and dealer's hand value < 17
                    else
                    {
                        dealer.Hand.Add(deck[0]);
                        deck.RemoveAt(0);
                        dealerStand = "n";
                    }
                }

                // Calculate Winner
                // Check for player bust condition
                if (humanPlayer.HandValue() > 21)
                {
                    Console.WriteLine($"{humanPlayer.PlayerName} busts");
                }

                // Check for dealer bust condition
                else if (dealer.HandValue() > 21)
                {
                    Console.WriteLine("Dealer Busts");
                }

                // Check for player win condition
                else if (humanPlayer.HandValue() > dealer.HandValue())
                {
                    Console.WriteLine($"{humanPlayer.PlayerName} wins!");
                }

                // Dealer wins otherwise
                else
                {
                    Console.WriteLine("Dealer wins.");
                }

                // Prompt to play again
                Console.WriteLine($"Would you like to play again, {humanPlayer.PlayerName}? (y/n)");
                playAgain = Console.ReadLine();
            }
        }
    }
}