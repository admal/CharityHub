using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class SignUpInputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BornDate { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Male, Female
        /// </summary>
        public string Sex { get; set; }
    }
}
