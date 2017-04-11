using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Models
{
    public class Division
    {
        [Key]
        public int DivisionId { get; set; }
        public string DName { get; set; }
    }
}