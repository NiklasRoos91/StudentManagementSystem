using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagementSystem.Classes
{
    public class StudentManager
    {
        public List<Student> Students { get; set; }

        public StudentManager()
        {
            Students = new List<Student>();

            Students.Add(new Student("John", "1", 13, new List<int> { 3, 4, 2, 5 }) );
           Students.Add(new Student ( "Lina", "2", 12, new List<int> { 2, 2, 3, 1 }) );
           Students.Add(new Student ( "Anna", "3", 14, new List<int> { 4, 3, 3, 4 }) );
           Students.Add(new Student ( "Peter", "4", 12, new List<int> { 1, 4, 3, 4 }) );
        }
        public void AddStudent(Student student)
        {
            //Lägger till en ny student till listan.
            Students.Add(student);
        }

        public void RemoveStudent(string studentId) 
        {
            //Tar bort en student med deras ID.
            Student? studentToRemove = null;

            foreach (Student student in Students)
            {
                if ( student.StudentId == studentId )
                {
                    studentToRemove = student;
                    break;
                }
            }

            if (studentToRemove != null)
            {
                Students.Remove(studentToRemove);
                Console.WriteLine("Student borttagen");
            }
            else
            {
                Console.WriteLine("Student inte hittad");
            }
        }

        public double CalculateAverageStudentGrade(string studentId)
        {
            //Beräknar och returnerar medelbetyget för en elev.
            foreach (Student student in Students)
            {
                if (student.StudentId == studentId )
                {
                    //om studenten har betyg så lägg ihop dom och sen dela dom med antal betyg studenten har, har den inga betyg returnera 0
                    if (student.StudentGrade.Count > 0)
                    {
                        int total = 0;
                        foreach (int grade in student.StudentGrade) 
                        { 
                            total += grade; 
                        }                     
                         return (double)total / student.StudentGrade.Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }

        public void ListStudentsWithGradeAbove(int grade)
        {
            //Returnerar en lista över elever vars medelbetyg ligger över ett angivet värde.

            bool foundStudent = false;
            foreach (Student student in Students)
            {
                double averageGrade = CalculateAverageStudentGrade(student.StudentId); // eller student-objektet om du justerar metoden

                if (averageGrade > grade)
                {
                    Console.WriteLine($"{student.StudentName} har ett medelbetyg på {averageGrade}, som är över {grade}.");
                    foundStudent = true;
                }
            }
            if (!foundStudent)
            {
                Console.WriteLine("Inga studenter med ett medelbetyg över det angivna värdet hittades");
            }
        }

        public void ShowAllStudents()
        {
            foreach (Student student in Students)
            {
                Console.WriteLine($"Students namn:  {student.StudentName}. StudentId: {student.StudentId}. Students ålder:  {student.StudentAge}. Students betyg: {string.Join(" ", student.StudentGrade)}");
            }
        }
    }
}
