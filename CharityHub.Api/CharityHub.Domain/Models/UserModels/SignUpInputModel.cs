using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class SignUpInputModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Male, Female
        /// </summary>
        //public string Sex { get; set; } 
    }
}
