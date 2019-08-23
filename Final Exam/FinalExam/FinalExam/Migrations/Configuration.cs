namespace FinalExam.Migrations
{
    using FinalExam.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalExam.Infraestructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalExam.Infraestructure.ApplicationDbContext context)
        {
            context.Countries.AddOrUpdate(l => l.Name,
                      new Country()
                      {
                          Name = "Canada"
                      },
                      new Country()
                      {
                          Name = "France"
                      },
                      new Country()
                      {
                          Name = "Mexico"
                      },
                      new Country()
                      {
                          Name = "Peru"
                      },
                      new Country()
                      {
                          Name = "United Kingdom"
                      },
                      new Country()
                      {
                          Name = "United States"
                      }
                 );

            Country usaCountry = context.Countries.Where(c => c.Name == "United States").FirstOrDefault();
            Country canadaCountry = context.Countries.Where(c => c.Name == "Canada").FirstOrDefault();
            context.States.AddOrUpdate(l => l.Name,
                new State()
                {
                    Name = "Alberta",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "British Columbia",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Manitoba",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "New Brunswick",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Newfoundland and Labrador",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Nova Scotia",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Ontario",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Prince Edward Island",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Quebec",
                    CountryId = canadaCountry.Id
                },
                new State()
                {
                    Name = "Saskatchewan",
                    CountryId = canadaCountry.Id
                }
                );

            context.States.AddOrUpdate(l => l.Name,
                new State()
                {
                    Name = "Alabama",
                    CountryId = usaCountry.Id
                },
                new State()
                {
                    Name = "California",
                    CountryId = usaCountry.Id
                },
                new State()
                {
                    Name = "New York",
                    CountryId = usaCountry.Id
                },
                new State()
                {
                    Name = "Washington",
                    CountryId = usaCountry.Id
                });

            context.Events.AddOrUpdate(l => l.Name,
                new Event()
                {
                    Name = "Cross Country Saint-Laurent",
                    EventDate = new DateTime(2019, 9, 18),
                    IsClosed = false
                },
                new Event()
                {
                    Name = "Le Cross des Couleurs",
                    EventDate = new DateTime(2019, 10, 13),
                    IsClosed = false
                },
                new Event()
                {
                    Name = "Classique du Parc La Fontaine",
                    EventDate = new DateTime(2019, 10, 20),
                    IsClosed = false
                }
            );
        }
    }
}
