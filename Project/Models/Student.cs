using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Project.Models;
namespace Project.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Student
    {

        public int student_id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string address { get; set; }

        public string gender { get; set; }

        public string phone_no { get; set; }

        public string course_name { get; set; }

        public string password
        {
            get; set;
        }

    }
}