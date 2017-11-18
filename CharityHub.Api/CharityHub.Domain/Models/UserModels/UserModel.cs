using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class UserModel
    {
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public DateTime BornDate { get; set; }
        //public Sex Sex { get; set; }
    }
}
