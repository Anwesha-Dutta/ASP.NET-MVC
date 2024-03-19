
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Project.Models;
using System.Configuration;
using System.Data;


namespace Project.Controllers
{
    public class Students_newController : Controller

    {
        string constring = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration(Student user1)
        {
            var list = new List<string> { "HTML", "CSS", "JavaScript", "SQL", "ASP.NET" };
            ViewBag.list = list;
            try
            {

                using (SqlConnection connection = new SqlConnection(constring))
                {
                    SqlCommand command = new SqlCommand("insert into [dbo].[Students_New](student_id,first_name,last_name,address,gender,phone_no,course_name,password) values(@student_id, @first_name, @last_name, @address, @gender, @phone_no, @course_name,@password)", connection);


                    command.Parameters.AddWithValue("@student_id", user1.student_id);
                    command.Parameters.AddWithValue("@first_name", user1.first_name);
                    command.Parameters.AddWithValue("@last_name", user1.last_name);
                    command.Parameters.AddWithValue("@address", user1.address);
                    command.Parameters.AddWithValue("@gender", user1.gender);
                    command.Parameters.AddWithValue("@phone_no", user1.phone_no);
                    command.Parameters.AddWithValue("@course_name", user1.course_name);
                    command.Parameters.AddWithValue("@password", user1.password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return RedirectToAction("Login");

            }
            catch
            {
                return View();
            }

        }

        public ActionResult Login(Login user1)
        {
            if (user1.phone_no != null && user1.password != null)
            {
                using (SqlConnection connection = new SqlConnection(constring))
                {
                    SqlCommand command = new SqlCommand("select [phone_no],[password] from [Students_New] where [phone_no]=@phone_no and [password]=@password", connection);


                    command.Parameters.AddWithValue("@phone_no", user1.phone_no);
                    command.Parameters.AddWithValue("@password", user1.password);
                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Session["user_name"] = user1.phone_no.ToString();
                        return RedirectToAction("welcome");
                    }
                    else
                    {

                        ViewData["Message"] = "User Login Details Failed";
                    }



                }



            }


            return View();

        }

        public ActionResult Welcome()
        {
            return View();
        }

    }

}