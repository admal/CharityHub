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
           
        }

        private static void InitUsers(CharityHubContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]{
                new User(){ Name = "Adam"},
                new User(){ Name = "Patryk"},
                new User(){ Name = "Krystian"},
                new User(){ Name = "Damian"},
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
                    Owner = adam
                },
                new Charity()
                {
                    Name = "Testowy Rycha",
                    Description = "Opis2",
                    Category = CharityCategory.NonProfit,
                    CreatedDate = DateTime.Now,
                    Owner = rychu
                }
            };

            foreach (var s in charities)
            {
                context.Charities.Add(s);
            }

            context.SaveChanges();
        }
    }
}
