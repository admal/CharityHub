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
        public string Surname { get; set; }
        //public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Male, Female
        /// </summary>
        //public string Sex { get; set; } 

        public bool AddOrganization { get; set; }

        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public int OrganizationType { get; set; }
    }
}
