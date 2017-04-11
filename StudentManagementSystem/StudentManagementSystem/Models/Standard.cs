using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Standard
    {
        [Key]
        public int StandardId { get; set; }
        public string Class { get; set; }
    }
}