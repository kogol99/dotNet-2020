using System;
using System.Collections.Generic;
using System.Text;

namespace Zad1
{
    class Student
    {
        public string Name { get; }
        public string Surname { get; }
        public int Index { get; }
        public string Mail { get; }

        public Student(string name, string surname, int index, string mail)
        {
            Name = name;
            Surname = surname;
            Index = index;
            Mail = mail;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} = index {Index}, mail {Mail}";
        }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                Name == student.Name &&
                Surname == student.Surname &&
                Index == student.Index &&
                Mail == student.Mail;
        }
    }
}
