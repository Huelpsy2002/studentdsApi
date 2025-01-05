using dataAccesslayer;
using sclass;
using System.Data;

namespace bussinessLayer
{
    public class BussinessLogic
    {


        public static List<sclass.Students>? getAllStudents()
        {
            return DataAccess.getAllStudents().Count > 0 ? DataAccess.getAllStudents() : null;
           
        }
        public static sclass.Students getStudentById(int id)
        {
            return DataAccess.getStudentById(id);
        }

        public static List<sclass.Students>? getPassedStudents()
        {
            return DataAccess.getPassedStudents().Count > 0 ? DataAccess.getPassedStudents() : null;

        }
        public static sclass.Students addStudent(sclass.Students newstudent)
        {
            if ( string.IsNullOrEmpty(newstudent.Name) || newstudent.Age < 0 || newstudent.Grade < 0 || newstudent.Grade > 100) 
            {
                return null;
            }
                return DataAccess.AddStudent(newstudent);
        }

        public static bool deleteStudent(int id)
        {
            if (DataAccess.deleteStudent(id)) return true;
            return false;
        }

        public static sclass.Students updateStudent(sclass.Students student)
        {
            if (string.IsNullOrEmpty(student.Name) || student.Age < 0 || student.Grade < 0 || student.Grade > 100)
            {
                return null;
            }
            var updatedStudent = DataAccess.updateStudent(student);
            if (updatedStudent != null)
            {
                return updatedStudent;
            }
            return null;
        }

    }
}
