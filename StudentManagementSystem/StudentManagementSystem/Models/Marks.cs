using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Marks
    {
        public int Id { get; set; }
        public int Score { get; set; }

        //foreignKey Subject id
        public int SubjectId { get; set; }
        public Subjects subjects { get; set; }

        //foreignKey student Id
        public int StudentId { get; set; }
        public Students students { get; set; }
    }
}