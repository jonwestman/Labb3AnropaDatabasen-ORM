using Labb3.Data;
using Labb3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Labb3.MethodHandling
{
    public partial class MethodHandler
    {
        public static void Menu()
        {
            string theEnd, menuInput;
            uint approvedMenuInput;

            do
            {
                do
                {
                    string[] menuArray = new string[8]
                    {
                        "1: Get all Faculty members: ",
                        "2: Get all students: ",
                        "3: Get all students from a certian class: ",
                        "4: Get all the grades from the last month: ",
                        "5: Get a list of all the courses with average GPA: ",
                        "6: Add new students: ",
                        "7: Add new Faculty: ",
                        "8: Quit: "
                    };

                    for (int i = 0; i < menuArray.Length; i++)
                    {
                        Console.WriteLine(menuArray[i]);
                    }

                    menuInput = Console.ReadLine();

                } while (!uint.TryParse(menuInput, out approvedMenuInput));


                switch (approvedMenuInput)
                {
                    case 1:
                        Console.WriteLine("Get all Faculty members press 1:\nGet all from a specific department press 2: ");
                        int choiceOfFaculty = int.Parse(Console.ReadLine());
                        GetFaculty(choiceOfFaculty);
                        break;
                    case 2:
                        Console.WriteLine("2: Get all students enrolled in NewSchool: ");
                        GetStudents();
                        break;
                    case 3:
                        Console.WriteLine("3: Get all students from a certain calss: ");
                        ChooseStudentClass();
                        break;
                    case 4:
                        Console.WriteLine("4: Get all the grades from the last month: ");
                        GetGrades();
                        break;
                    case 5:
                        Console.WriteLine("5: Get a list of all the courses with average GPA: ");
                        GetAllCoursesAndGPA();
                        break;
                    case 6:
                        Console.WriteLine("6: Add new students: ");
                        do
                        {
                            StudentRegistry();

                            Console.Clear();

                            Console.Write("Press Enter to add another Student or 'q' to quit: ");
                            theEnd = Console.ReadLine();

                            Console.Clear();

                        } while (theEnd.ToLower() != "q");

                        break;
                    case 7:
                        Console.WriteLine("7: Add new Faculty:");
                        do
                        {
                            FacultyRegistry();

                            Console.Clear();

                            Console.Write("Press Enter to add another Faculty member or 'q' to quit: ");
                            theEnd = Console.ReadLine();

                            Console.Clear();

                        } while (theEnd.ToLower() != "q");
                        break;
                    case 8:
                        Console.Clear();
                        break;
                }

                Console.Write("Enter to go back to menu or 'q' to quit: ");
                theEnd = Console.ReadLine();

                Console.Clear();

            } while (theEnd.ToLower() != "q");
        }
        public static void GetFaculty(int input)
        {
            if (input == 1)
            {
                using (var context = new NewSchoolContext())
                {
                    var myFaculty = from f in context.Faculties
                                    select f;

                    Console.Clear();

                    foreach (var faculty in myFaculty)
                    {
                        Console.WriteLine($"{faculty.Fname} {faculty.Lname}");
                        Console.WriteLine(new string('-', (30)));

                    }

                }
            }
            else if (input == 2)
            {
                using (var context = new NewSchoolContext())
                {
                    var faculty = new Faculty();

                    int facultyInput;

                    Console.WriteLine("1: Headmaster\n2: Administrator\n3: Creepy Janitor\n4: Lunchlady\n5: Guidens Councelor\n6: Teacher");
                    Console.Write("Assign type of faculty[1-6]: ");
                    facultyInput = int.Parse(Console.ReadLine());

                    var myFaculty = from f in context.Faculties
                                    where  faculty.FkFacultyTypeId == facultyInput
                                    select f;

                    Console.Clear();

                    foreach (var f in myFaculty)
                    {
                        Console.WriteLine($"{f.Fname} {f.Lname} {f.FkFacultyTypeId}");
                        Console.WriteLine(new string('-', (30)));

                    }
                }
            }
            
        }
        public static void GetStudents()
        {

            Console.WriteLine("Sort by Firstname or Lastname [1-2]: ");
            int input = int.Parse(Console.ReadLine());

            string sortByName = "";

            Console.WriteLine("Sort by 'Ascending' or 'Descending' [1-2]: ");
            int ascOrDesc = int.Parse(Console.ReadLine());

            string upOrDown = "";

            if (input == 1)
            {
                if (ascOrDesc == 1)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Fname ascending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
                else if (ascOrDesc == 2)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Fname descending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
            }
            else if (input == 2)
            {
                if (ascOrDesc == 1)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Lname ascending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
                else if (ascOrDesc == 2)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Lname descending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
            }

            
            using (var context = new NewSchoolContext())
            {
                var myStudents = from s in context.Students
                                 orderby s.Lname descending
                                 select s;

                Console.Clear();

                foreach (var student in myStudents)
                {
                    Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                    Console.WriteLine(new string('-', (30)));

                }

            }



        }

        public static void ChooseStudentClass()
        {
            Console.WriteLine("1: Beaver\n2: Eagle\n3: Swamprat\n4: Guinea Pig\n5: Horse\n6: Moose");
            Console.WriteLine("Choose class [1-6]: ");
            int input = int.Parse(Console.ReadLine());

            using (var context = new NewSchoolContext())
            {
                var myStudents = from s in context.Students
                                 where s.FkClassId == input
                                 select s;


                Console.Clear();

                foreach (var student in myStudents)
                {
                    Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonId}");
                    Console.WriteLine(new string('-', (30)));

                }

            }
        }
        public static void GetGrades()
        {
            using (var context = new NewSchoolContext())
            {
                var grades = from g in context.Grades
                             select g;

                Console.Clear();

                foreach (var grade in grades)
                {
                    Console.WriteLine($"{grade.GradeName}");
                    Console.WriteLine(new string('-', (30)));

                }

            }
        }
        public static void GetAllCoursesAndGPA()
        {
            using (var context = new NewSchoolContext())
            {
                var allCourses = from s in context.Subjects
                                 select s;

                Console.Clear();

                foreach (var item in allCourses)
                {
                    Console.WriteLine($"{item.SubjectName}");
                    Console.WriteLine(new string('-', (30)));

                }

            }
        }
        public static void StudentRegistry()
        {
            using var context = new NewSchoolContext();
            var student = new Student();

            Console.Write("Enter firstname: ");
            student.Fname = Console.ReadLine(); ;

            Console.Clear();

            Console.Write("Enter lastname: ");
            student.Lname = Console.ReadLine();

            Console.Clear();

            Console.Write("Type in PersonId [yyyy-mm-dd]: ");
            student.PersonId = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1: Beaver\n2: Eagle\n3: Swamprat\n4: Guinea Pig\n5: Horse\n6: Moose");
            Console.Write("Assign to class [1-6]: ");
            student.FkClassId = int.Parse(Console.ReadLine());

            Console.Clear();

            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Databasen är uppdaterad");

        }
        public static void FacultyRegistry()
        {
            using var context = new NewSchoolContext();
            var faculty = new Faculty();

            Console.Write("Enter firstname: ");
            faculty.Fname = Console.ReadLine(); ;

            Console.Clear();

            Console.Write("Enter lastname: ");
            faculty.Lname = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1: Headmaster\n2: Administrator\n3: Creepy Janitor\n4: Lunchlady\n5: Guidens Councelor\n6: Teacher");
            Console.Write("Assign type of faculty[1-6]: ");
            faculty.FkFacultyTypeId = int.Parse(Console.ReadLine());

            Console.Clear();

            context.Faculties.Add(faculty);
            context.SaveChanges();
            Console.WriteLine("Databasen är uppdaterad");

        }
    }

}
