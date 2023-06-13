using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCardScraper.Classes
{
    public class CardFormat
    {
        public class Card
        {
            public string Name { get; }
            public string cardPack { get; }
            public int? setID { get; set; }
            public int cardId { get; }
            public string cardLink { get; }

            public Card(string name, string cardPack, int cardId, string cardLink)
            {
                Name = name;
                this.cardPack = cardPack;
                this.cardId = cardId;
                this.cardLink = cardLink;
            }
        }

        public class CardSet
        {
            public string Name { get; set; }
            public int setID { get; set; }
            public string setLink { get; set; }
            public int cardNumTotal { get; set; }
            public List<Card>? Cards { get; set; }

            public CardSet(string name, int setID, string setLink, int cardNumTotal)
            {
                Name = name;
                this.setID = setID;
                this.setLink = setLink;
                this.cardNumTotal = cardNumTotal;
            }
        }

        public class PokemonDeck
        {
            int cardCount;
            public int cardLimit = 4;
            public List<Card>? cards;

        }

        public class DeckCollection
        {
            public List<PokemonDeck>? decks;
        }

        public class CardPack
        {
            public string Name { get; set; }
            public int setID { get; set; }
            public string setLink { get; set; }
            public int cardNumTotal { get; set; }
            public List<PokemonCard> Cards { get; }

            public CardPack(string name, int setID, string setLink, int cardNumTotal)
            {
                Name = name;
                this.setID = setID;
                this.setLink = setLink;
                this.cardNumTotal = cardNumTotal;
                Cards = new List<PokemonCard>();    
            }
        }

        public class PokemonCard
        {
            public string name;
            public string setName;
            public string link;
            public PokemonCard(string name, string setName, string link)
            {
                this.name = name;
                this.setName = setName;
                this.link = link;
            }
            public string mn1 { get; set; }
            public string mn2 { get; set; }
            public string mn3 { get; set; }
            public string me1 { get; set; }
            public string me2 { get; set; }
            public string me3 { get; set; }

        }


    }
}
