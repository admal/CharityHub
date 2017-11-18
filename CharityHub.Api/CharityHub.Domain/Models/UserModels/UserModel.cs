using System;
using System.Collections.Generic;
using System.Text;

namespace CharityHub.Domain.Models.UserModels
{
    public class UserModel
    {
        public int? Id { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int OrganizationId { get; set; }
    }
}
