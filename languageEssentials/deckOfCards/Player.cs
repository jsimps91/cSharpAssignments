using System;
using System.Collections.Generic;
namespace deckOfCards{
    public class Player{
        List<Card> hand = new List<Card>();
        public Player draw(Deck deck)
        {
            this.hand.Add(deck.deal());
            return this;
        }
        public Card discard(int idx)
        {
            if(idx < this.hand.Count)
            {
                Card cardToRemove = this.hand[idx];
                this.hand.Remove(cardToRemove);
                return cardToRemove;
            }
            return null;
        }
        public void readHand()
        {
            foreach(Card card in this.hand)
            {
                System.Console.WriteLine("{0} of {1}", card.stringVal, card.suit);
            }
        }
    }
}