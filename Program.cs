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
            Console.WriteLine($"Hi {userName}");
        }
    }
}
