/*****************************************************************
    PROGRAMME	:	ASSN03 Card Shuffle

    OUTLINE		:	This form contains 52 objects of class Card
                    and it acts as a deck of cards. It allows
                    for the cards to be shuffled and displays
                    the deck to the main form.

    PROGRAMMER	:	Saikrishna Tadepalli

    DATE		:   January 6th 2020
*****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TadepalliS_ASSN03
{
    class DeckOfCards
    {
        public Card[] deck = new Card[52];

        public DeckOfCards()
        {
            string[] faces = { "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suites = { "Clubs", "Diamonds", "Hearts", "Spades" };
            int count = 0;

            for (int i = 0; i < faces.Length; i++)
            {
                for (int j = 0; j < suites.Length; j++)
                {
                    deck[count] = new Card(faces[i], suites[j]);
                    count += 1;
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            Card[] newOrder = new Card[52];
            int[] integers = new int[52];

            for (int i = 0; i < integers.Length; i++)
                integers[i] = i;

            integers = integers.OrderBy(x => rand.Next()).ToArray();

            for (int i = 0; i < integers.Length; i++)
                newOrder[i] = deck[integers[i]];

            deck = newOrder;
        }

        public void QuickShuffle()
        {
            deck = deck.ToList().OrderBy(a => Guid.NewGuid()).ToList().ToArray();
        }
    }
}
