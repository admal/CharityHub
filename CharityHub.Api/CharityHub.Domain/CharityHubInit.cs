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
    }
}
