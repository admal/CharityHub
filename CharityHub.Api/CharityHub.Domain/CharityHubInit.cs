using CharityHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharityHub.Domain
{
    public class CharityHubInit
    {
        public static void Initialize(CharityHubContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            InitUsers(context);
            InitCharities(context);
            InitCharityEvents(context);
            InitEventParticipants(context);
            InitUserCharity(context);
        }

        private static void InitUsers(CharityHubContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]{
                new User(){ Name = "Adam", Surname = "Malewski", EmailAddress = "adam.malewski@wp.pl", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Patryk", Surname = "Wołosz", EmailAddress = "wolosz.patryk@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Krystian", Surname = "Rytel", EmailAddress = "krystian.rytel@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Damian", Surname = "Dmochowski", EmailAddress = "dmochowskidd@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
            };

            foreach (var s in users)
            {
                context.Users.Add(s);
            }

            context.SaveChanges();
        }

        private static void InitCharities(CharityHubContext context)
        {
            if (context.Charities.Any())
            {
                return;
            }
            var adam = context.Users.First(x => x.Name == "Adam");
            var rychu = context.Users.First(x => x.Name == "Damian");
            var charities = new Charity[]
            {
                new Charity()
                {
                    Name = "Testowy Adama",
                    Description = "Opis",
                    Category = CharityCategory.Profit,
                    CreatedDate = DateTime.Now,
                    Owner = adam,
                    OwnerId = adam.Id
                },
                new Charity()
                {
                    Name = "Testowy Rycha",
                    Description = "Opis2",
                    Category = CharityCategory.NonProfit,
                    CreatedDate = DateTime.Now,
                    Owner = rychu,
                    OwnerId = rychu.Id
                }
            };
            
            foreach (var s in charities)
            {
                context.Charities.Add(s);
            }

            adam.Charity = charities[0];
            rychu.Charity = charities[1];

            context.SaveChanges();
        }

        private static void InitCharityEvents(CharityHubContext context)
        {
            if (context.CharityEvents.Any())
            {
                return;
            }
            var charityTestowyRychu = context.Charities.First(x => x.Name == "Testowy Rycha");
            var charityTestowyAdam = context.Charities.First(x => x.Name == "Testowy Adama");

            var charityEvents = new CharityEvent[]
            {
                new CharityEvent()
                {
                    Name = "Zmieranie pieniędzy dla Jana",
                    Charity = charityTestowyRychu,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,19),
                    EndDate = new DateTime(2017,11,21),
                    Description = "Jan potrzebuję dużo pieniędzy",
                    EventCategory = EventCategory.Fundraising,
                },
                 new CharityEvent()
                {
                    Name = "Zmieranie pieniędzy dla Jana 2",
                    Charity = charityTestowyRychu,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,22),
                    EndDate = new DateTime(2017,11,24),
                    Description = "Jan potrzebuję dużo pieniędzy",
                    EventCategory = EventCategory.Fundraising,
                },
                new CharityEvent()
                {
                    Name = "Zmieranie jedzenia dla Jana",
                    Charity = charityTestowyAdam,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,19),
                    EndDate = new DateTime(2017,11,21),
                    Description = "Jan potrzebuję dużo jedzenia",
                    EventCategory = EventCategory.FoodCollection,
                },
                new CharityEvent()
                {
                    Name = "Zmieranie jedzenia dla Jana 2",
                    Charity = charityTestowyAdam,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,20),
                    EndDate = new DateTime(2017,11,21),
                    Description = "Jan potrzebuję dużo jedzenia",
                    EventCategory = EventCategory.FoodCollection,
                },
            };

            foreach (var s in charityEvents)
            {
                context.CharityEvents.Add(s);
            }

            context.SaveChanges();
        }

        private static void InitEventParticipants(CharityHubContext context)
        {
            if (context.EventParticipants.Any())
            {
                return;
            }
            var adam = context.Users.First(x => x.Name == "Adam");
            var rychu = context.Users.First(x => x.Name == "Damian");

            var dlaJanaPieniadze = context.CharityEvents.First((x => x.Name == "Zmieranie pieniędzy dla Jana"));
            var dlaJanaJedzenie = context.CharityEvents.First((x => x.Name == "Zmieranie jedzenia dla Jana"));

            var eventParticipants = new EventParticipant[]
            {
                new EventParticipant()
                {
                    User = adam,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = false,
                    CharityEvent = dlaJanaPieniadze
                },
                new EventParticipant()
                {
                    User = rychu,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = true,
                    CharityEvent = dlaJanaPieniadze
                },
                new EventParticipant()
                {
                    User = adam,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = false,
                    CharityEvent = dlaJanaJedzenie
                },
                new EventParticipant()
                {
                    User = rychu,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    CharityEvent = dlaJanaJedzenie
                },
            };

            foreach (var s in eventParticipants)
            {
                context.EventParticipants.Add(s);
            }

            context.SaveChanges();
        }

        private static void InitUserCharity(CharityHubContext context)
        {
            if (context.Users_Charities.Any())
            {
                return;
            }

            var user_Charities = new User_Charity[]{
                new User_Charity(){ CharityId = 1, UserId = 2},
                new User_Charity(){ CharityId = 1, UserId = 3},
                new User_Charity(){ CharityId = 1, UserId = 4},
                new User_Charity(){ CharityId = 2, UserId = 1},
                new User_Charity(){ CharityId = 2, UserId = 4},
            };

            foreach (var s in user_Charities)
            {
                context.Users_Charities.Add(s);
            }

            context.SaveChanges();
        }
    }
}
