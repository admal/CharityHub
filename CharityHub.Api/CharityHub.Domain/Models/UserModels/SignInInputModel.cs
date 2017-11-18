using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class SignInInputModel
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
