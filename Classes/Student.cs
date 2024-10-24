using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class Student
    {
        // Skapa en elevklass:
        // Egenskaper: Namn, StudentId, Ålder och betyg(en lista med heltal).

        public string StudentName { get; set; }
        public string StudentId { get; set; }
        public int StudentAge { get; set; }
        public List<int> StudentGrade { get; set; }

        public Student (string studentName, string studentID, int studentAge, List<int> studentGrade)
        {
            StudentName = studentName;
            StudentId = studentID;
            StudentAge = studentAge;
            //StudentGrade = new List<int>();
            StudentGrade = studentGrade;
        }
    }
}
