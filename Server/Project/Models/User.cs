﻿using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class User
    {
       [Key]
        public int ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
            