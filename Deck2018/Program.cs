using System;

namespace Deck2018
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiates an object of class Deck
            Deck myDeck = new Deck();
            //Instantiates an object of class Card
            Card myCard = new Card();

            //Creates the array that holds the cards for the deck
            myDeck.MakeDeck();

        
            //Calls the DrawCard method to find the array position of the winner
            int winner = myDeck.DrawCard();
            //Accesses the card in the array of the winner's position...the name of the card
            string winner2 = myDeck.cards[winner];
            //This outputs the winning card
            Console.WriteLine("The winner is {0}!", winner2);
            //This line was outputting the array position also
            //Console.WriteLine("{0} is the winner! {1}",winner2, winner);
            
            Console.ReadLine();
        }
        
    }
    class Deck
    {
        //Creates the array of cards 
        public string[] cards = new string[52];
        //Needed a counter to keep track of each new card bc of embedded for statements
        int counter = 0;
        
        /// <summary>
        /// Creates an array that holds 52 cards in a regular deck
        /// </summary>
        public void MakeDeck()
        { 
        //Uses an aray of suits 
        string[] suits = new string[4] { "hearts", "diamonds", "clubs", "spades" };
            //Loops through the 4 suits 
            foreach (string suit in suits)
            {
                //As it loops through a suit, a the vaues 1-13 are assigned
                for (int i = 1; i < 14; i++)
                {
                    //changes the integer from counter to a string for concatenation
                    string numName = i.ToString();
                    //Uses the FullCardName method to name the card using the suit and number
                    cards[counter] = Card.FullCardName(suit, numName);
                    //This is just to check that all cards have been assigned to the array
                    Console.WriteLine(cards[counter]);
                    //Increases the counter so it will go from 1-52
                    counter++;
                }
            }
            
        }

        public int DrawCard()
        {
            //Istantiates a random object
            Random rnd = new Random();
            //assigns the winner a value from 0-51
            int chosen = rnd.Next(0, 51);
            //returns the winners int value
            return chosen;
        }

       
    }

    class Card
    {
        //The properties of Card
        public string number { get; set; }
        public string suit { get; set; }
        public string color { get; set; }

        /// <summary>
        /// Creates the Full Name of the card 
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="number"></param>
        /// <returns>a string with the number and suit of the card</returns>
        public static string FullCardName(string suit, string number)
        {
            //For 1 and 11,12,13 assigns word values for special cards
            if (number == "1") number = "Ace";
            if (number == "11") number = "Jack";
            if (number == "12") number = "Queen";
            if (number == "13") number = "King";
            //Concatenates the number and suit into one variable
            string fullname = number + " of " + suit;
            return fullname;
        }
    }
}
