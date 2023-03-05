using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace Ado.NetCategoryProductProject.Models
{
    public class DataBase
    {
        string cs  = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

        public List<Student> GetStudent ()
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

            return Student;


        }



    }
}