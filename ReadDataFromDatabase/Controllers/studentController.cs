using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using ReadDataFromDatabase.Models;

namespace ReadDataFromDatabase.Controllers
{
    public class studentController : Controller
    {

        string Consring = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

        // GET: Student
        public ActionResult Index()
        {
            List<student> list = new List<student>();
            student student = null;
            using (SqlConnection connection = new SqlConnection(Consring))
            {
                SqlCommand command = new SqlCommand("Select [id],[name],[age],[gender] from student", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new student
                        {
                            id = Convert.ToInt32(reader["id"].ToString()),
                            name = reader["name"].ToString(),
                            age = Convert.ToInt32(reader["age"].ToString()),
                            gender = reader["gender"].ToString()
                        });
                    }
                }
                reader.Close();

                return View(list);
            }
        }

            //------------------------------------------------------------------------------------------------------------

           
            [HttpGet]
            public ActionResult GetstudentById(int id)
            {
                student student = null;
                using (SqlConnection connection = new SqlConnection(Consring))
                {
                    SqlCommand command = new SqlCommand("Select [id],[name],[age],[gender] from student where id =@id", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    reader.Read();
                    student = new student
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        name = reader["name"].ToString(),
                        age = Convert.ToInt32(reader["age"].ToString()),
                        gender = reader["gender"].ToString()
                    };


                }

                reader.Close();

                    return View(student);
                }
            }
        }
    }
