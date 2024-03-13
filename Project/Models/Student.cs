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

        //[Required(ErrorMessage = "First name is required")]
        //[StringLength(50, ErrorMessage = "First name must not exceed 50 characters")]
        public string first_name { get; set; }

        //[Required(ErrorMessage = "Last name is required")]
        //[StringLength(50, ErrorMessage = "Last name must not exceed 50 characters")]
        public string last_name { get; set; }

        //[Required(ErrorMessage = "Address is required")]
        //[StringLength(255, ErrorMessage = "Address must not exceed 255 characters")]
        public string address { get; set; }

        //[Required(ErrorMessage = "Gender is required")]
        //[StringLength(10, ErrorMessage = "Gender must not exceed 10 characters")]
        public string gender { get; set; }

        //[Required(ErrorMessage = "Phone number is required")]
        //[StringLength(20, ErrorMessage = "Phone number must not exceed 20 characters")]
        public string phone_no { get; set; }

        //[Required(ErrorMessage = "Course name is required")]
        //[StringLength(100, ErrorMessage = "Course name must not exceed 100 characters")]
        public string course_name { get; set; }

        //[Required(ErrorMessage = "password  is required")]
        //[StringLength(100, ErrorMessage = "password must not exceed 10 characters")]
        public string password
        {
            get; set;
        }

    }
}