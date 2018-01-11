using System;
using System.Collections.Generic;

namespace deckOfCards{
    public class Deck{
        List<Card> cards = new List<Card>();
        string[] stringVals = new string[]{"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] suits = new string[]{"Clubs", "Spades", "Hearts", "Diamonds"};
        
        public Card deal()
        {
            Card cardToDeal = this.cards[this.cards.Count-1];
            this.cards.Remove(cardToDeal);
            return cardToDeal;
        }
        public void readDeck()
        {
            foreach(Card card in this.cards)
            {
                System.Console.WriteLine("{0} of {1}", card.stringVal, card.suit);
            }
        }
        public Deck reset()
        {
            this.cards = new List<Card>();
            foreach(string suit in suits){
                int num = 1;
                foreach(string stringVal in stringVals)
                {
                    Card card = new Card(suit, stringVal, num);
                    this.cards.Add(card);
                    num++;
                }
            }
            return this;
        }
        public Deck shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < this.cards.Count; i++)
            {
                int idx = rand.Next(0, 53);
                Card temp = this.cards[i];
                this.cards[i] = this.cards[idx];
                this.cards[idx] = temp;
            }
            return this;
        }
        public Deck(){
            foreach(string suit in suits){
                int num = 1;
                foreach(string stringVal in stringVals)
                {
                    Card card = new Card(suit, stringVal, num);
                    this.cards.Add(card);
                    num++;
                }
            }
        }


        
    }
}