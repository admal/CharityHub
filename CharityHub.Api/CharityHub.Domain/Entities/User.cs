using CharityHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public DateTime? BornDate { get; set; }
        //public Sex Sex { get; set; }
    }
}
