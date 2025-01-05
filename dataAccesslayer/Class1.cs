using System.Data;

using Microsoft.Data.SqlClient;

namespace dataAccesslayer
{


    internal static class Settings
    {
        public static string connectionString = "Server=.;Database=studentApi;Trusted_Connection=True;TrustServerCertificate=True";
    }
    public class DataAccess

    {
        public static List<sclass.Students> getAllStudents()
        {


          

            
            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("_getAllStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            List<sclass.Students> students = new List<sclass.Students>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add
                            (
                             new sclass.Students
                             {
                                 id = (int)reader["id"],
                                 Name = (string)reader["Name"],
                                 Age = (int)reader["Age"],
                                 Grade = (int)reader["Grade"]
                             }


                            );
                            
                    }
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return students;
        }


        public static List<sclass.Students> getPassedStudents()
        {





            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("getPassedStudents", connection);
            command.CommandType = CommandType.StoredProcedure;
            List<sclass.Students> students = new List<sclass.Students>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add
                            (
                             new sclass.Students
                             {
                                 id = (int)reader["id"],
                                 Name = (string)reader["Name"],
                                 Age = (int)reader["Age"],
                                 Grade = (int)reader["Grade"]
                             }


                            );

                    }
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return students;
        }
        public static sclass.Students getStudentById(int id)
        {
            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("getStudentById", connection);
            command.Parameters.AddWithValue("@id", id);
            command.CommandType = CommandType.StoredProcedure;
            sclass.Students student = new sclass.Students();
            bool found = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    student.id = (int)reader["id"];
                    student.Name = (string)reader["Name"];
                    student.Age = (int)reader["Age"];
                    student.Grade = (int)reader["Grade"];
                      
                    
                }
               


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return found==true?student:null;

        }
        public static sclass.Students AddStudent(sclass.Students newstudent)
        {
            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("addStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", newstudent.Name);
            command.Parameters.AddWithValue("@Age", newstudent.Age);
            command.Parameters.AddWithValue("@Grade", newstudent.Grade);
            bool excuted = false;
            sclass.Students student = new sclass.Students();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    excuted = true;

                }



                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return excuted == true ? student : null;

        }
        public static bool deleteStudent(int id)
        {
            bool deleted = false;
            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("deleteStudent", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                int numOfRowsEffected = command.ExecuteNonQuery();
                if (numOfRowsEffected > 0)
                {
                    deleted = true;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                connection.Close();
            }

            return deleted;
        }

        public static sclass.Students updateStudent(sclass.Students newstudent)
        {
            SqlConnection connection = new SqlConnection(Settings.connectionString);
            SqlCommand command = new SqlCommand("updateStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", newstudent.id);
            command.Parameters.AddWithValue("@Name", newstudent.Name);
            command.Parameters.AddWithValue("@Age", newstudent.Age);
            command.Parameters.AddWithValue("@Grade", newstudent.Grade);
            bool excuted = false;
            sclass.Students student = new sclass.Students();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    excuted = true;

                }



                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return excuted==true?student:null ;

        }
    }
    }

