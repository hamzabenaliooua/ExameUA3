using System;
using System.IO;
using System.Collections.Generic;
namespace AssuranceLOgiciel_UA3_Projet
{
    public class Grade
    {
        public int StudentNumber { get; private set; }
        public int CourseNumber { get; private set; }
        public double Note { get; private set; }

        public Grade(int studentNumber, int courseNumber, double note)
        {
            StudentNumber = studentNumber;
            CourseNumber = courseNumber;
            Note = note;
        }
    }
}
