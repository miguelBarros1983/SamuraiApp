﻿
namespace SamuraiApp.Domain
{
    using System.Collections.Generic;
    public class Samurai
    {
        public Samurai()
        {
            Quotes = new List<Quote>();
        }

        public int Id { get; set; }

        public  string Name { get; set; }

        public List<Quote> Quotes { get; set; }

        public List<SamuraiBattle> SamuraiBattles { get; set; }

        public SecretIdentity SecretIidentity { get; set; }

    }
}
