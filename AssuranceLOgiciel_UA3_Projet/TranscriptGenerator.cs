using System;

using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace AssuranceLOgiciel_UA3_Projet
{
    

    public class TranscriptGenerator
    {
        private List<Student> students;
        private List<Course> courses;
        private List<Grade> grades;

        public TranscriptGenerator(List<Student> students, List<Course> courses, List<Grade> grades)
        {
            this.students = students;
            this.courses = courses;
            this.grades = grades;
        }

        public void GenerateTranscript(int studentNumber)
        {
            var student = students.FirstOrDefault(s => s.StudentNumber == studentNumber);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var studentGrades = grades.Where(g => g.StudentNumber == studentNumber).ToList();
            if (studentGrades.Count == 0)
            {
                Console.WriteLine("No grades found for this student.");
                return;
            }

            string transcriptFileName = $"Transcript_{student.StudentNumber}.txt";
            using (StreamWriter writer = new StreamWriter(transcriptFileName))
            {
                writer.WriteLine("Relevé de Notes");
                writer.WriteLine($"Numéro d'inscription: {student.StudentNumber}");
                writer.WriteLine($"Nom: {student.LastName}");
                writer.WriteLine($"Prénom: {student.FirstName}");
                writer.WriteLine($"Adresse: {student.Address}");

                writer.WriteLine("\nMatière\t\tCoefficient\tNote");
                foreach (var grade in studentGrades)
                {
                    var course = courses.FirstOrDefault(c => c.CourseNumber == grade.CourseNumber);
                    if (course != null)
                    {
                        int coefficient = 1; // Placeholder for actual coefficient
                        writer.WriteLine($"{course.Title}\t{coefficient}\t{grade.Note}");
                    }
                }

                double average = studentGrades.Average(g => g.Note);
                writer.WriteLine($"\nMoyenne Générale: {average:0.00}");

                string mention = GetMention(average);
                writer.WriteLine($"Mention: {mention}");
            }

            Console.WriteLine($"Transcript generated: {transcriptFileName}");
        }

        private string GetMention(double average)
        {
            if (average >= 90) return "Excellent";
            if (average >= 80) return "Très Bien";
            if (average >= 70) return "Bien";
            if (average >= 60) return "Assez Bien";
            if (average >= 50) return "Passable";
            return "Insuffisant";
        }

    }

}
