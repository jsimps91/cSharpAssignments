using System;
using System.Collections.Generic;
namespace deckOfCards{
    public class Player{
        List<Card> hand = new List<Card>();
        public Card draw(Deck deck)
        {
            Card cardToDraw = deck.deal();
            this.hand.Add(cardToDraw);
            return cardToDraw;
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