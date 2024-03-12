using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginPage.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginPage.Controllers
{
    public class userController : Controller
    {
        // GET: user
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user user1)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            using(SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand("select [email],[password] from [user] where [email]=@email and [password] =@password ", connection);
                connection.Open();

                command.Parameters.AddWithValue("@email", user1.user_name);
                command.Parameters.AddWithValue("@password", user1.password);

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    Session["user_name"] = user1.user_name.ToString();
                    return RedirectToAction("welcome");
                }
                else
                {
                    ViewData["Message"] = "User Login Details Failed";
                }
                connection.Close();
                return View();
            }
          
        }

        public ActionResult welcome()
        {
            return View();
        }
    }
}