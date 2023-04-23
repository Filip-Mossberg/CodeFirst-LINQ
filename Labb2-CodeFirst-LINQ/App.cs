using Labb2_CodeFirst_LINQ.ContextDB;
using Labb2_CodeFirst_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_CodeFirst_LINQ
{
    internal class App
    {
        public SchoolContext db { get; set; }
        public App(SchoolContext DB)
        {
            this.db = DB;
        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tWelcome to Campus Varberg!" +
                    "\n\t1. All math teachers" +
                    "\n\t2. Student and their teachers" +
                    "\n\t3. Subject Programming" +
                    "\n\t4. Update teacher");

                var input = Console.ReadLine();
                if (int.TryParse(input, out int pick))
                {
                    Console.Clear();
                    switch (pick)
                    {
                        case 1:
                            TeachersTeachingMath();
                            break;
                        case 2:
                            StudentsWithTeachers();
                            break;
                        case 3:
                            UpdateSubjectProgramming();
                            break;
                        case 4:
                            ChangeTeacherMenu();
                            break;
                        default:
                            Console.WriteLine("Not a valid pick!");
                            Console.ReadLine();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid pick!");
                    Console.ReadLine();
                }
            }
        }
        public void TeachersTeachingMath()
        {
            var MathTeachers2 = (from teacher in db.teachers
                                join con in db.connects on teacher.Tconnect.ConnectID equals con.ConnectID
                                join subj in db.subjects on con.Subject.SubjectID equals subj.SubjectID
                                where subj.SubjectName == "Math"
                                select new
                                {
                                    TeacherName = teacher.FirstName,
                                    SubjectName = con.Subject.SubjectName,
                                    ClassName = con.Name
                                });



            Console.WriteLine("\n\t-------- Math Teachers --------");
            foreach (var item in MathTeachers2)
            {
                Console.WriteLine($"\n\tTeacher {item.TeacherName}, Subject {item.SubjectName}, ClassName {item.ClassName}");
            }
            Console.ReadLine();
        }

        public void StudentsWithTeachers()
        {
            Console.Clear();
            string green = System.Drawing.Color.Green.ToString();

            // Student has an copy of its connection to the other tables in the studentConnect object
            var students = db.student.Include(s => s.Studconnect.TeacherList).Distinct();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t---- Students With Their Teachers ----");
            foreach (var s in students)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t\tStudent: {s.FirstName} {s.LastName}");
                foreach (var teacher in s.Studconnect.TeacherList)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\t\tTeacher: {teacher.FirstName} {teacher.LastName}");
                }
            }
            Console.ResetColor();
            Console.ReadLine();
        }


        public void ContainsSubject()
        {
            // Contains checks wheather a collection contains a specific element,
            // while Any checks if any element in a collection satisfies a specified condition.
            if (db.subjects.Any(x => x.SubjectName == "Programming2"))
            {
                Console.WriteLine("\n\tSubject Programming2 Found!");
            }
            else if (db.subjects.Any(x => x.SubjectName == "OOP"))
            {
                Console.WriteLine("\n\tSubject OOP Found!");
            }
            Console.ReadLine();
            UpdateSubjectProgramming();
        }


        public void UpdateSubjectProgramming()
        {
            Console.Clear();
            Console.WriteLine("\n\tChange programming subject" +
                "\n\t1. Programming2 => OOP" +
                "\n\t2. OOP => Programming2" +
                "\n\t3. Check");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int pick))
            {
                Console.Clear();
                switch (pick)
                {
                    case 1:
                        UpdateToOOP();
                        break;
                    case 2:
                        UpdateToProgramming2();
                        break;
                    case 3:
                        ContainsSubject();
                        break;
                    default:
                        Console.WriteLine("Not a valid pick!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void UpdateToOOP()
        {
            var Update = db.subjects.FirstOrDefault(x => x.SubjectName == "Programming2");
            Update.SubjectName = "OOP";

            db.SaveChanges();

            Console.WriteLine("\n\tChanged subject Programming2 to OOP");
            Console.ReadLine();
            UpdateSubjectProgramming();
        }
        public void UpdateToProgramming2()
        {
            var Update = db.subjects.FirstOrDefault(x => x.SubjectName == "OOP");
            Update.SubjectName = "Programming2";

            db.SaveChanges();

            Console.WriteLine("\n\tChanged subject OOP to Programming2");
            Console.ReadLine();
            UpdateSubjectProgramming();
        }

        public void ChangeTeacher(string current, string updated)
        {
            var test = db.teachers.FirstOrDefault(x => x.FirstName == current);
            test.FirstName = updated;

            db.SaveChanges();

            var Update = (from stud in db.student
                          join con in db.connects on stud.Studconnect.ConnectID equals con.ConnectID
                          join teach in db.teachers on con.ConnectID equals teach.Tconnect.ConnectID
                          where teach.FirstName == updated
                          select new
                          {
                              StudentFirstName = stud.FirstName,
                              StudentLastName = stud.LastName,
                              StudentClass = con.Name,
                              TeacherFirstName = teach.FirstName,
                              TeacherLastName = teach.LastName
                          });

            Console.WriteLine("\n\tStudents with new teacher {0}", updated);
            foreach (var item in Update)
            {
                Console.WriteLine($"\n\tStudent {item.StudentFirstName} {item.StudentLastName} has teacher {item.TeacherFirstName} {item.TeacherLastName} Class = {item.StudentClass}");
            }
            Console.ReadLine();
            ChangeTeacherMenu();
        }

        public void ChangeTeacherMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\tChange Teacher" +
                "\n\t1. Anas => Reidar" +
                "\n\t2. Reidar => Anas" +
                "\n\t3. Check");

            var input = Console.ReadLine();
            if (int.TryParse(input, out int pick))
            {
                Console.Clear();
                switch (pick)
                {
                    case 1:
                        ChangeTeacher("Anas", "Reidar");
                        break;
                    case 2:
                        ChangeTeacher("Reidar", "Anas");
                        break;
                    case 3:
                        ContainsTeacher();
                        break;
                    default:
                        Console.WriteLine("Not a valid pick!");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public void ContainsTeacher()
        {
            if (db.teachers.Any(x => x.FirstName == "Anas"))
            {
                Console.WriteLine("\n\tTeacher Anas Found!");
            }
            else if (db.teachers.Any(x => x.FirstName == "Reidar"))
            {
                Console.WriteLine("\n\tTeacher Reidar Found!");
            }
            Console.ReadLine();
            ChangeTeacherMenu();
        }


    }
}
