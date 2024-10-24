using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Classes
{
    public class MenuAndUserInteraction
    {
        public void MenuScreen()
        {
            Console.WriteLine("1) Vissa en lista med alla studenter");
            Console.WriteLine("2) Lägg till ny student");
            Console.WriteLine("3) Ta bort en student");
            Console.WriteLine("4) Lägg till betyg på en student");
            Console.WriteLine("5) Se medelbetyget på en student");
            Console.WriteLine("6) Se en lista över elever vars medelbetyg ligger över ett angivet värde");
            Console.WriteLine("7) Avsluta");
        }

        public void ReturnToMenuScreen()
        {
            Console.WriteLine("Tryck på enter för att gå tillbaka till menyn");
            Console.ReadKey();
            Console.Clear();
        }

        public void ManageListStudentsWithGradeAbove(StudentManager studentManager)
        {
            Console.Write("Skriv lägsta medelbetyget du vill ha med på listan: ");
            int grade = Convert.ToInt32(Console.ReadLine()!);

            studentManager.ListStudentsWithGradeAbove(grade);
        }

        public string ManageStudentRemoveInput(StudentManager studentManager)
        {
            Console.Write("Skriv studentId på studenten du vill ta bort: ");
            string studentId = Console.ReadLine()!;

            studentManager.RemoveStudent(studentId);
            return studentId;
        }

        public string ManageCalculateAverageStudentGradeAndInput(StudentManager studentManager)
        {
            string studentId;
            Console.Write("Skriv studentId för att se medelbetyget: ");
            studentId = Console.ReadLine()!;

            double averageGrade = studentManager.CalculateAverageStudentGrade(studentId);

            switch (averageGrade)
            {
                case > 0:
                    Console.WriteLine($"Medelbetyget är {averageGrade} ");
                    break;
                case 0:
                    Console.WriteLine("Studenten har inga betyg");
                    break;
                case -1:
                    Console.WriteLine("Studenten finns inte");
                    break;
                default:
                    Console.WriteLine("Okänt fel inträffade.");
                    break;
            }

            return studentId;
        }

        public void ManageStudentAddInput(StudentManager studentManager)
        {
            Console.Write("Skriv studentens namn: ");
            string newStudentsNamed = Console.ReadLine()!;

            Console.Write("Skriv in studentId: ");
            string newStudentId = Console.ReadLine()!;

            if (newStudentsNamed == "" || newStudentId == "")
            {
                Console.WriteLine("Namn och student-ID får inte vara tomma.");
                return;
            }

            Console.Write("Skriv studentens ålder: ");
            if (!int.TryParse(Console.ReadLine(), out int newStudentAge))
            {
                Console.WriteLine("Ogiltig ålder. Var vänlig att ange en giltig siffra.");
                return; // Avsluta om åldern inte är en giltig siffra.
            }

            List<int> StudentGrade = new List<int>();

            Console.Write("Lägg till betyg, skriv klar' när alla betyg är inlagda: ");

            while (true)
            {
                string newStudentGrade = Console.ReadLine()!;
                if (newStudentGrade.ToLower() == "klar")
                {
                    break;
                }

                if (int.TryParse(newStudentGrade, out int grade))
                {
                    StudentGrade.Add(grade);
                }
                else
                {
                    Console.WriteLine("Var vänlig och ange ett giltigt heltal eller skriv 'klar' för att avsluta.");
                }
            }

            Student newStudent = new Student(newStudentsNamed, newStudentId, newStudentAge, StudentGrade);

            studentManager.AddStudent(newStudent);

            Console.WriteLine("\nNy student: ");
            Console.WriteLine($"Students namn:  {newStudentsNamed}. StudentId: {newStudentId}. Students ålder:  {newStudentAge}. Students betyg: {string.Join(" ", StudentGrade)}");
        }
    }
}
