using Labb2_CodeFirst_LINQ.ContextDB;
using Labb2_CodeFirst_LINQ.Models;

namespace Labb2_CodeFirst_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SchoolContext();
            //InsertData(db);

            App app = new App(db);
            app.Menu();

        }

        public static void InsertData(SchoolContext db)
        {
            // Create some subjects
            var subject1 = new Subject { SubjectName = "Math", };
            var subject2 = new Subject { SubjectName = "English" };
            var subject3 = new Subject { SubjectName = "Programming2" };

            //Adds all subjects to the database
            db.subjects.Add(subject1);
            db.subjects.Add(subject2);
            db.subjects.Add(subject3);

            //Saves changes to database
            db.SaveChanges();

            // Create some Connections
            var connect1 = new Connect { Name = "SUT21", Subject = subject1 };
            var connect2 = new Connect { Name = "SUT22", Subject = subject3 };
            var connect3 = new Connect { Name = "SUT23", Subject = subject1 };

            db.connects.Add(connect1);
            db.connects.Add(connect2);
            db.connects.Add(connect3);

            //Saves changes to database
            db.SaveChanges();

            // Create some teachers
            var teacher1 = new Teacher { FirstName = "John", LastName = "Doe", Tconnect = connect1};
            var teacher2 = new Teacher { FirstName = "Jane", LastName = "Smith", Tconnect = connect1 };
            var teacher3 = new Teacher { FirstName = "Mike", LastName = "Johnson", Tconnect = connect2 };
            var teacher4 = new Teacher { FirstName = "Anas", LastName = "Qlok", Tconnect = connect2 };
            var teacher5 = new Teacher { FirstName = "James", LastName = "Bond", Tconnect = connect3};
            var teacher6 = new Teacher { FirstName = "Leonard", LastName = "Smith", Tconnect = connect3};

            //Adds all teachers to the database
            db.teachers.Add(teacher1);
            db.teachers.Add(teacher2);
            db.teachers.Add(teacher3);
            db.teachers.Add(teacher4);
            db.teachers.Add(teacher5);
            db.teachers.Add(teacher6);

            //Saves changes to database
            db.SaveChanges();

            //// Create some students
            var student1 = new Student { FirstName = "Alice", LastName = "Jones", Studconnect = connect1 };
            var student2 = new Student { FirstName = "Bob", LastName = "Smith", Studconnect = connect1 };
            var student3 = new Student { FirstName = "Charlie", LastName = "Brown", Studconnect = connect1 };
            var student4 = new Student { FirstName = "David", LastName = "Lee", Studconnect = connect1 };
            var student5 = new Student { FirstName = "Emily", LastName = "Chen", Studconnect = connect1 };
            var student6 = new Student { FirstName = "Frank", LastName = "Lin", Studconnect = connect1 };
            var student7 = new Student { FirstName = "George", LastName = "Wang", Studconnect = connect2 };
            var student8 = new Student { FirstName = "Hannah", LastName = "Cheng", Studconnect = connect2 };
            var student9 = new Student { FirstName = "Isaac", LastName = "Liu", Studconnect = connect2 };
            var student10 = new Student { FirstName = "Jack", LastName = "Wu", Studconnect = connect2 };
            var student11 = new Student { FirstName = "Tobias", LastName = "Qlok", Studconnect = connect2 };
            var student12 = new Student { FirstName = "Reidar", LastName = "Qlok", Studconnect = connect2 };
            var student13 = new Student { FirstName = "Dom", LastName = "Inick", Studconnect = connect3 };
            var student14 = new Student { FirstName = "Kristian", LastName = "Qlok", Studconnect = connect3 };
            var student15 = new Student { FirstName = "Sarah", LastName = "Chai", Studconnect = connect3 };
            var student16 = new Student { FirstName = "Kristoffer", LastName = "Stone", Studconnect = connect3 };
            var student17 = new Student { FirstName = "Adan", LastName = "Chams", Studconnect = connect3 };
            var student18 = new Student { FirstName = "Eric", LastName = "Skrm", Studconnect = connect3 };

            //Adds all students to the database
            db.student.Add(student1);
            db.student.Add(student2);
            db.student.Add(student3);
            db.student.Add(student4);
            db.student.Add(student5);
            db.student.Add(student6);
            db.student.Add(student7);
            db.student.Add(student8);
            db.student.Add(student9);
            db.student.Add(student10);
            db.student.Add(student11);
            db.student.Add(student12);
            db.student.Add(student13);
            db.student.Add(student14);
            db.student.Add(student15);
            db.student.Add(student16);
            db.student.Add(student17);
            db.student.Add(student18);

            //Saves changes to database
            db.SaveChanges();
        }
    }
}