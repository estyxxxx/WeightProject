﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeightModel.model
{
    [Table("Subscriber")]
    public class Subscriber
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        [RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [MaxLength(10)]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
