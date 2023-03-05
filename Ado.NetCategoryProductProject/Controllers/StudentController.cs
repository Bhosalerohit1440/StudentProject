using Ado.NetCategoryProductProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;

namespace Ado.NetCategoryProductProject.Controllers
{
    public class StudentController : Controller
    {
        
        public ActionResult ListOfStudent()
        {
            string cs = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            List<Student> Student = new List<Student>();
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_GetallStudentList", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader(); 
            while (reader.Read())
            {
                Student p = new Student();
                p.id = Convert.ToInt32(reader.GetValue(0).ToString());
                p.Studentname = reader.GetValue(1).ToString();
                p.RollNumber = Convert.ToInt32(reader.GetValue(2).ToString());
                p.Qualification = reader.GetValue(3).ToString();

                Student.Add(p);
            }
            conn.Close();
            return View(Student);
        }



        public ActionResult CreateNewStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewStudent(Student student)
        {
            string cs = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_addStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Studentname", student.Studentname);
            cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
            cmd.Parameters.AddWithValue("@Qualification", student.Qualification);
            conn.Open();
              cmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("ListOfStudent");
           
        }


        public async Task<ActionResult> DeleteStudent(int  studentId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            DataBase db = new DataBase();
            var data = db.GetStudent().Single(c => c.id == studentId);
            
            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_DeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", studentId);
            conn.Open();
            await cmd.ExecuteNonQueryAsync();
            conn.Close();
            return RedirectToAction("ListOfStudent");
        }

    }
}