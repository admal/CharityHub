﻿using System.ComponentModel.DataAnnotations;

namespace CharityHub.Domain.Models.Charity
{
    public class CharityAddEditModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public int OwnerId { get; set; }
    }
}