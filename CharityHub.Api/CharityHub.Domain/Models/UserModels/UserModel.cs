using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        public string EmailAddress { get; set; }
        public Sex Sex { get; set; }
    }
}
