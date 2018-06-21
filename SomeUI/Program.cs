
namespace SomeUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;

    using SamuraiApp.Data;
    using SamuraiApp.Domain;

    public class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        static void Main(string[] args)
        {
            // InsertSamurai();
            // InsertMultipleSamurais();
            // InsertMultipleDifferentObjects();
            // GetListOfSamurais();
            // SimpleSamuraiQuery();
            MoreQuerie();
        }

        private static void GetListOfSamurais()
        {
            using (SamuraiContext context = new SamuraiContext())
            {
                List<Samurai> samurais = context.Samurais.ToList();
            }
        }

        private static void SimpleSamuraiQuery()
        {
            using (SamuraiContext context = new SamuraiContext())
            {
                List<Samurai> samurais = context.Samurais.ToList();

                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai.Name);
                }
            }
        }

        private static void InsertMultipleDifferentObjects()
        {
            Samurai samurai = new Samurai { Name = "Miguel" };
            Battle battle = new Battle
            {
                Name = "Battle of Nagashino",
                StartDate = new DateTime(1575, 06, 16),
                EndDate = new DateTime(1575, 06, 28)
            };
            using (SamuraiContext context = new SamuraiContext())
            {
                context.AddRange(samurai, battle);
                context.SaveChanges();
            }
        }

        private static void InsertSamurai()
        {
            Samurai samurai = new Samurai { Name = "Julie" };
            using (SamuraiContext context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleSamurais()
        {
            Samurai samurai = new Samurai { Name = "Julie" };
            Samurai samuraiSammy = new Samurai { Name = "Sampson" };
            using (SamuraiContext context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurai, samuraiSammy);
                context.SaveChanges();
            }
        }

        private static void MoreQuerie()
        {
            List<Samurai> samurai = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
        }
    }
}
