using StudentManagementSystem.Classes;
using System.Xml.Linq;

namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            MenuAndUserInteraction menuAndUserInteraction = new MenuAndUserInteraction();

            while (true)
            {
                menuAndUserInteraction.MenuScreen();

                string chooseOption = Console.ReadLine()!;

                switch (chooseOption)
                {
                    case "1":

                        studentManager.ShowAllStudents();
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;

                    case "2":
                        menuAndUserInteraction.ManageStudentAddInput(studentManager);
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;

                    case "3":
                        string studentId = menuAndUserInteraction.ManageStudentRemoveInput(studentManager);
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;
                    case "4":
                        Console.WriteLine("Under konstruktion");
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;

                    case "5":
                        studentId = menuAndUserInteraction.ManageCalculateAverageStudentGradeAndInput(studentManager);
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;

                    case "6":
                        menuAndUserInteraction.ManageListStudentsWithGradeAbove(studentManager);
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;

                    case "7":
                        Console.WriteLine("Avslutar programet");
                        return;

                    default:
                        Console.WriteLine("Felaktigt val");
                        menuAndUserInteraction.ReturnToMenuScreen();
                        break;
                }
            }
        }
    }
}
