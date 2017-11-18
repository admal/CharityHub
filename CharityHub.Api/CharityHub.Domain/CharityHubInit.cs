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
                new User(){ Name = "Adam", LastName = "Malewski", EmailAddress = "adam.malewski@wp.pl", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Patryk", LastName = "Wołosz", EmailAddress = "wolosz.patryk@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Krystian", LastName = "Rytel", EmailAddress = "krystian.rytel@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
                new User(){ Name = "Damian", LastName = "Dmochowski", EmailAddress = "dmochowskidd@gmail.com", PasswordHash="087c21f7779390463a98cdaf6a6b494f116c0f3f9e5b8c3596aa8c65410e6c4a"/*, Sex=Models.Sex.Male*/},
            };

            foreach (var s in users)
            {
                context.Users.Add(s);
            }

            context.SaveChanges();
        }
    }
}
