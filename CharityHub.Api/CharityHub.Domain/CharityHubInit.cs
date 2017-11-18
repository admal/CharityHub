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
            InitEventNotification(context);
        }
        
        private static void InitUsers(CharityHubContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]{
                new User(){ Name = "Adam", Surname = "Malewski", EmailAddress = "adam.malewski@wp.pl", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"},
                new User(){ Name = "Patryk", Surname = "Wołosz", EmailAddress = "wolosz.patryk@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"},
                new User(){ Name = "Krystian", Surname = "Rytel", EmailAddress = "krystian.rytel@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"},
                new User(){ Name = "Damian", Surname = "Dmochowski", EmailAddress = "dmochowskidd@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"},
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
            var damian = context.Users.First(x => x.Name == "Damian");

            var charities = new Charity[]
            {
                new Charity()
                {
                    Name = "Organizacja zbierania jedzenia dla ubogich",
                    Description = "Celem organizacji jest zbieranie jedzenia dla bezdomnych. Jedzenie zbieramy po przez zbiórki w miejscach publicznych lub innych",
                    Category = CharityCategory.NonProfit,
                    CreatedDate = DateTime.Now,
                    Owner = adam,
                    OwnerId = adam.Id
                },
                new Charity()
                {
                    Name = "Organizacja zbierania pieniędzy dla dzieci",
                    Description = "Celem organizacji jest zbieranie pieniędzy które będą przekazywane najbiedniejszych dzieci w naszej okolicy.",
                    Category = CharityCategory.Profit,
                    CreatedDate = DateTime.Now,
                    Owner = damian,
                    OwnerId = damian.Id
                }
            };
            
            foreach (var s in charities)
            {
                context.Charities.Add(s);
            }

            adam.Charity = charities[0];
            damian.Charity = charities[1];

            context.SaveChanges();
        }

        private static void InitCharityEvents(CharityHubContext context)
        {
            if (context.CharityEvents.Any())
            {
                return;
            }
            var charityAdam = context.Charities.First(x => x.Name == "Organizacja zbierania jedzenia dla ubogich");
            var charityRychu = context.Charities.First(x => x.Name == "Organizacja zbierania pieniędzy dla dzieci");

            var charityEvents = new CharityEvent[]
            {
                new CharityEvent()
                {
                    Name = "Zbieranie jedzenia dla biednych rodziny w Warszawy",
                    Charity = charityAdam,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,19),
                    EndDate = new DateTime(2017,11,21),
                    Description = "W Warszawie jest wiele ubogich rodzin u których nie starcza pieniędzy na jedzenie." +
                                  "Możemy im pomóc. Zapraszamy",
                    EventCategory = EventCategory.FoodCollection,
                },
                 new CharityEvent()
                {
                    Name = "Zbieranie jedznia dla noclegowni",
                    Charity = charityAdam,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,22),
                    EndDate = new DateTime(2017,11,24),
                    Description = "Noclegownia z Ursynowa ma ograniczony budżet. Jakość posiłków nie jeset tam najlepsza. Zbieramy podstawowe produkty takie jak mąka, cukier itp.",
                    EventCategory = EventCategory.FoodCollection,
                },
                new CharityEvent()
                {
                    Name = "Dzieci w domu dziecka potrzebują remontu łazienki",
                    Charity = charityRychu,
                    CreatedDate = new DateTime(2017,11,18),
                    StartDate = new DateTime(2017,11,19),
                    EndDate = new DateTime(2017,11,21),
                    Description = "Dzieci w domu dziecka potrzebują remontu łazienki. Na remont potrzebne jest oko. 10.000zł. Jeżeli dużo osób pomoże to się uda :)",
                    EventCategory = EventCategory.FoodCollection,
                }
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
            var damian = context.Users.First(x => x.Name == "Damian");
            var patryk = context.Users.First(x => x.Name == "Patryk");
            var krystian = context.Users.First(x => x.Name == "Krystian");

            var dlaJanaJedzenie = context.CharityEvents.First((x => x.Name == "Zbieranie jedzenia dla biednych rodziny w Warszawy"));
            var dlaNoclegowniJedzenie = context.CharityEvents.First((x => x.Name == "Zbieranie jedznia dla noclegowni"));
            var naRemontLazienki = context.CharityEvents.First((x => x.Name == "Dzieci w domu dziecka potrzebują remontu łazienki"));

            var eventParticipants = new EventParticipant[]
            {
                new EventParticipant()
                {
                    User = damian,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = false,
                    CharityEvent = dlaJanaJedzenie
                },
                new EventParticipant()
                {
                    User = patryk,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = true,
                    CharityEvent = dlaJanaJedzenie
                },
                new EventParticipant()
                {
                    User = krystian,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    IsAccepted = false,
                    CharityEvent = dlaJanaJedzenie
                },
                new EventParticipant()
                {
                    User = patryk,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    CharityEvent = dlaNoclegowniJedzenie
                },
                new EventParticipant()
                {
                    User = damian,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    CharityEvent = dlaNoclegowniJedzenie
                },
                new EventParticipant()
                {
                    User = krystian,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    CharityEvent = naRemontLazienki
                },
                new EventParticipant()
                {
                    User = adam,
                    ParticipationRequestDate = new DateTime(2017,11,18),
                    CharityEvent = naRemontLazienki
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
                new User_Charity(){ CharityId = 1, UserId = 4},
                new User_Charity(){ CharityId = 2, UserId = 2},
                new User_Charity(){ CharityId = 2, UserId = 3}
            };

            foreach (var s in user_Charities)
            {
                context.Users_Charities.Add(s);
            }

            context.SaveChanges();
        }

        private static void InitEventNotification(CharityHubContext context)
        {
            if (context.EventNotifications.Any())
            {
                return;
            }

            var eventNotifications = new EventNotification[]{
                new EventNotification()
                {
                    Subject = "Zbiórka",
                    CreatedDate = new DateTime(2017,11,18,12,32,12),
                    Body = "Przy pałacu kultury o godzinie 12:30. Zapraszam!",
                    CharityEventId = 1,
                },
                new EventNotification()
                {
                    Subject = "Zmiana terminu",
                    CreatedDate = new DateTime(2017,11,18,13,32,12),
                    Body = "Zbiórka jednak o 14:00. Z góry przepraszamy",
                    CharityEventId = 1,
                },
                new EventNotification()
                {
                    Subject = "Rodzaj jedzenia",
                    CreatedDate = new DateTime(2017,11,19,12,32,12),
                    Body = "Prosimy o nie przynoszenie produktów z krótkim terminem przydatności",
                    CharityEventId = 2,
                },
                new EventNotification()
                {
                    Subject = "Zbiórka",
                    CreatedDate = new DateTime(2017,11,18,11,32,12),
                    Body = "W centrum o godzinie 10:30. Zapraszam!",
                    CharityEventId = 2,
                },
                new EventNotification()
                {
                    Subject = "Pieniądze",
                    CreatedDate = new DateTime(2017,11,20,12,32,12),
                    Body = "Pieniądze przekazujemy jedynie po przez przelew na konto",
                    CharityEventId = 3,
                },
            };

            foreach (var s in eventNotifications)
            {
                context.EventNotifications.Add(s);
            }

            context.SaveChanges();
        }
    }
}
