using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectNames { get; set; }
        public int PassingMarks { get; set; }
        public int TotalMarks { get; set; }

    }
}