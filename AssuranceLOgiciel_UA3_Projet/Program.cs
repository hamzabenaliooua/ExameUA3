using System;
using System.IO;
using System.Collections.Generic;
namespace AssuranceLOgiciel_UA3_Projet
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();
        static List<Grade> grades = new List<Grade>();
        static TranscriptGenerator transcriptGenerator = new TranscriptGenerator(students, courses, grades);


        public static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Please choose an action:");
                Console.WriteLine("1: Create a new student");
                Console.WriteLine("2: Create a new course");
                Console.WriteLine("3: Enter a grade for a student");
                Console.WriteLine("4: Display all students");
                Console.WriteLine("5: Display all courses");
                Console.WriteLine("6: Display all grades for a student");
                Console.WriteLine("7: Generate a student transcript");
                Console.WriteLine("0: Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateStudent();
                        break;
                    case "2":
                        CreateCourse();
                        break;
                    case "3":
                        EnterGrade();
                        break;
                    case "4":
                        DisplayStudents();
                        break;
                    case "5":
                        DisplayCourses();
                        break;
                    case "6":
                        DisplayGrades();
                        break;
                    case "7":
                        GenerateStudentTranscript();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
        static void CreateStudent()
        {
            Console.WriteLine("Enter student number:");
            int studentNumber;
            while (!int.TryParse(Console.ReadLine(), out studentNumber))
            {
                Console.WriteLine("Invalid number, please try again:");
            }

            Console.WriteLine("Enter student's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter student's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter student's address:");
            string address = Console.ReadLine();

            Student newStudent = new Student(studentNumber, lastName, firstName, address);
            students.Add(newStudent);

            Console.WriteLine("Student created successfully!");
        }


        static void CreateCourse()
        {
            Console.WriteLine("Enter course number:");
            int courseNumber;
            while (!int.TryParse(Console.ReadLine(), out courseNumber))
            {
                Console.WriteLine("Invalid number, please try again:");
            }

            Console.WriteLine("Enter course code:");
            string code = Console.ReadLine();

            Console.WriteLine("Enter course title:");
            string title = Console.ReadLine();

            Course newCourse = new Course(courseNumber, code, title);
            courses.Add(newCourse);

            Console.WriteLine("Course created successfully!");
        }

        static void EnterGrade()
        {
            Console.WriteLine("Enter student number for the grade entry:");
            int studentNumber;
            while (!int.TryParse(Console.ReadLine(), out studentNumber) || !StudentExists(studentNumber))
            {
                Console.WriteLine("Invalid student number or student does not exist, please try again:");
            }

            Console.WriteLine("Enter course number for the grade entry:");
            int courseNumber;
            while (!int.TryParse(Console.ReadLine(), out courseNumber) || !CourseExists(courseNumber))
            {
                Console.WriteLine("Invalid course number or course does not exist, please try again:");
            }

            Console.WriteLine("Enter the grade:");
            double grade;
            while (!double.TryParse(Console.ReadLine(), out grade) || grade < 0 || grade > 100)
            {
                Console.WriteLine("Invalid grade, please enter a number between 0 and 100:");
            }

            Grade newGrade = new Grade(studentNumber, courseNumber, grade);
            grades.Add(newGrade);

            Console.WriteLine("Grade entered successfully!");
        }

        static bool StudentExists(int studentNumber)
        {
            foreach (var student in students)
            {
                if (student.StudentNumber == studentNumber)
                    return true;
            }
            return false;
        }

        static bool CourseExists(int courseNumber)
        {
            foreach (var course in courses)
            {
                if (course.CourseNumber == courseNumber)
                    return true;
            }
            return false;
        }



        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students to display.");
                return;
            }

            Console.WriteLine("List of all students:");
            foreach (Student student in students)
            {
                Console.WriteLine($"Student Number: {student.StudentNumber}, Name: {student.FirstName} {student.LastName}, Address: {student.Address}");
            }
        }

        static void DisplayCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses to display.");
                return;
            }

            Console.WriteLine("List of all courses:");
            foreach (Course course in courses)
            {
                Console.WriteLine($"Course Number: {course.CourseNumber}, Code: {course.Code}, Title: {course.Title}");
            }
        }

        static void GenerateStudentTranscript()
        {
            Console.WriteLine("Enter the student number to generate the transcript:");
            if (int.TryParse(Console.ReadLine(), out int studentNumber))
            {
                transcriptGenerator.GenerateTranscript(studentNumber);
            }
            else
            {
                Console.WriteLine("Invalid input for student number.");
            }
        }

        static void DisplayGrades()
        {
            Console.WriteLine("Enter the student number to display grades:");
            int studentNumber;
            while (!int.TryParse(Console.ReadLine(), out studentNumber) || !StudentExists(studentNumber))
            {
                Console.WriteLine("Invalid student number or student does not exist, please try again:");
            }

            // Find and display grades for the entered student number.
            var studentGrades = grades.FindAll(g => g.StudentNumber == studentNumber);
            if (studentGrades.Count == 0)
            {
                Console.WriteLine("No grades found for the given student number.");
                return;
            }

            Console.WriteLine($"Grades for Student Number: {studentNumber}");
            foreach (var grade in studentGrades)
            {
                var course = courses.Find(c => c.CourseNumber == grade.CourseNumber);
                Console.WriteLine($"Course: {course?.Title ?? "N/A"} (Code: {course?.Code ?? "N/A"}), Grade: {grade.Note}");
            }
        }

       
    }



}
