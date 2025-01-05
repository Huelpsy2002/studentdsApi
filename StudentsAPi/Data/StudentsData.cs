using StudentsAPi.Model;

namespace StudentsAPi.Data
{
    public class StudentsData
    {
        public static readonly List<Students> studentsList = new List<Students>
        {
         new Students{id=1,Name="hussin",Age=10,Grade=100},
         new Students{id=2,Name="ali",Age=20,Grade=90},
         new Students{id=3,Name="as",Age=30,Grade=20}
        };
    }
}
