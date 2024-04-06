using System;
using System.IO;
using System.Collections.Generic;
namespace AssuranceLOgiciel_UA3_Projet
{
    public class Course
    {
        public int CourseNumber { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }

        public Course(int courseNumber, string code, string title)
        {
            CourseNumber = courseNumber;
            Code = code;
            Title = title;
        }
    }
}
