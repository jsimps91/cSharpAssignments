using System;
using System.Collections.Generic;
namespace doc
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {

            string[] suits = { "Diamonds", "Spades", "Clubs", "Hearts" };
            string[] stringVals = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach(string suit in suits)
            {
                
                for(int i = 0; i < stringVals.Length; i++)
                {
                    Card newCard = new Card(suit, stringVals[i], i+1);
                    cards.Add(newCard);
                }
            }
        }

    }
}