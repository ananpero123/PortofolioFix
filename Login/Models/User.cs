﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Login.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
