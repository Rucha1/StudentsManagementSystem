using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Pcn { get; set; }
        public string Scn { get; set; }

        //foeignKey divison id
        public int DivisionId { get; set; }
        public Division division { get; set; }

        //foreignKey classId
        public int StandardId { get; set; }
        public Standard standard { get; set; }

    }
}