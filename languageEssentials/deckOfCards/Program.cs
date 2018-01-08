using System;

namespace deckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            // myDeck.shuffle();
            //myDeck.reset();
            Player player1 = new Player();
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.draw(myDeck);
            player1.readHand();
            player1.discard(6);
            player1.readHand();
            
            
        }
    }
}
