using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.ViewModels.Home
{
    public class StudentsViewModel
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
        public int DivisionId { get; set; }
        public int StandardId { get; set; }

    }
}