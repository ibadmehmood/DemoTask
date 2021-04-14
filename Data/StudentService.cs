using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolManagementSystem.Data
{
    public class StudentService
    {

      


            public List<Student> GetStudents()
            {
                List<Student> students = new List<Student>();

                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetStudents";
             

                con.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Student student = new Student();
                        student.StudentId = sqlDataReader.GetInt32(0);
                        student.Name= sqlDataReader.GetString(1);

                        student.FullName = sqlDataReader.GetString(2);
                        student.Phone = sqlDataReader.GetString(3);
                        student.FatherCnic= sqlDataReader.GetString(4);
                        student.Address= sqlDataReader.GetString(5);
                        student.Class= sqlDataReader.GetString(6);
                        students.Add(student);

                }
                }


                return students;
            }

        /*
            public void InsertItem(Student student)
            {

                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);

                SqlCommand sqlCommand = con.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "InsertItems";
                sqlCommand.Parameters.AddWithValue("ItemName", item.ItemName);

                sqlCommand.Parameters.AddWithValue("quantity", item.quantity);
                con.Open();
                sqlCommand.ExecuteNonQuery();

            }
*/


        public Student InsertStudent( Student student)
        {
            

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InsertStudent";

            sqlCommand.Parameters.AddWithValue("Name", student.Name);
            sqlCommand.Parameters.AddWithValue("FullName", student.FullName);
            sqlCommand.Parameters.AddWithValue("Phone", student.Phone);
            sqlCommand.Parameters.AddWithValue("FatherCnic", student.FatherCnic);
            sqlCommand.Parameters.AddWithValue("Address", student.Address);
            sqlCommand.Parameters.AddWithValue("Class", student.Class);
            SqlParameter studentid = sqlCommand.Parameters.Add(new SqlParameter("@New_Identity", DbType.Int32));


            con.Open();

            sqlCommand.ExecuteNonQuery();

            studentid.Direction = ParameterDirection.InputOutput;
            student.StudentId = (int)studentid.Value;
            Console.WriteLine(student.StudentId);


            return student;
        }

        public Student GetStudent(int id)
        {

            Student student = new Student();

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetStudent";
            sqlCommand.Parameters.AddWithValue("StudentId", id);


            con.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                   
                    student.StudentId = sqlDataReader.GetInt32(0);
                    student.Name = sqlDataReader.GetString(1);

                    student.FullName = sqlDataReader.GetString(2);
                    student.Phone = sqlDataReader.GetString(3);
                    student.FatherCnic = sqlDataReader.GetString(4);
                    student.Address = sqlDataReader.GetString(5);
                    student.Class = sqlDataReader.GetString(6);
                    

                }
            }


            return student;
        }



        public bool UpdateStudent(Student student)
        {


            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.UpdateStudent";
            sqlCommand.Parameters.AddWithValue("StudentId", student.StudentId);
            sqlCommand.Parameters.AddWithValue("Name", student.Name);
            sqlCommand.Parameters.AddWithValue("FullName", student.FullName);
            sqlCommand.Parameters.AddWithValue("Phone", student.Phone);
            sqlCommand.Parameters.AddWithValue("FatherCnic", student.FatherCnic);
            sqlCommand.Parameters.AddWithValue("Address", student.Address);
            sqlCommand.Parameters.AddWithValue("Class", student.Class);
            SqlParameter studentid = sqlCommand.Parameters.Add(new SqlParameter("@New_Identity", DbType.Int32));


            con.Open();

            sqlCommand.ExecuteNonQuery();
            studentid.Direction = ParameterDirection.InputOutput;
            student.StudentId = (int)studentid.Value;
            Console.WriteLine(student.StudentId);

            return true;
        }


        public List<Qualification> GetQualifications(int studentId)
        {
            List<Qualification> qualifications= new List<Qualification>();

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetQualifications";
            sqlCommand.Parameters.AddWithValue("StudentId", studentId);



            con.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    Qualification qualification = new Qualification();
                    qualification.QualificationId = sqlDataReader.GetInt32(0);
                    qualification.Degree= sqlDataReader.GetString(1);

                    qualification.TotalMarks = sqlDataReader.GetInt32(2);
                    qualification.ObtainMarks = sqlDataReader.GetInt32(3);
                    qualification.Percentage= sqlDataReader.GetInt32(4);
                    qualification.Grade = sqlDataReader.GetString(5);
                    qualification.StudentId = sqlDataReader.GetInt32(6);
                    qualifications.Add(qualification);

                }
            }


            return qualifications;
        }


        public Qualification InsertQualification(Qualification qualification)
        {


            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "dbo.InsertQualification";

            sqlCommand.Parameters.AddWithValue("Degree", qualification.Degree);
            sqlCommand.Parameters.AddWithValue("TotalMarks", qualification.TotalMarks);
            sqlCommand.Parameters.AddWithValue("ObtainMarks", qualification.ObtainMarks);
            sqlCommand.Parameters.AddWithValue("Percentage", qualification.Percentage);
            sqlCommand.Parameters.AddWithValue("Grade", qualification.Grade);
            sqlCommand.Parameters.AddWithValue("StudentId", qualification.StudentId);


            con.Open();

            sqlCommand.ExecuteNonQuery();


            return qualification;
        }


        public bool DeleteQualification(int qualificationid)
        {

           

            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "DeleteQualification";
            sqlCommand.Parameters.AddWithValue("QualificationId", qualificationid);


            con.Open();
            try
            {


                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }



           
        }


    }
}