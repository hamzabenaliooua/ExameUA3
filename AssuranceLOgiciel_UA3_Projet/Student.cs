using System;
using System.IO;
using System.Collections.Generic;
namespace AssuranceLOgiciel_UA3_Projet
{
    public class Student
    {
        public int StudentNumber { get; private set; }
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string Address { get; private set; }

        public Student(int studentNumber, string lastName, string firstName, string address)
        {
            StudentNumber = studentNumber;
            LastName = lastName;
            FirstName = firstName;
            Address = address;
        }
    }
}
