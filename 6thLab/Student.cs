using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal struct Student
    {
        int[] _marks;
        double _middle;
        string _name;

        public double Middle
        {
            get { return _middle; }
        }

        public int this[int index]
        {
            get
            {
                if(index >= 0 && index < _marks.Length)
                    return _marks[index];
                return 0;
            }
        }

        public string Name
        {
            get { return _name; }
        }

        public Student(int[] marks)
        {
            _marks = marks;
            _middle = GetMiddle(marks);
            _name = "";
        }

        public Student(int[] marks, string name)
        {
            _marks = marks;
            _middle = GetMiddle(marks);
            _name = name;
        }

        static double GetMiddle(int[] marks)
        {
            if (marks == null) return 0;
            double middle = 0;
            foreach(var mark in marks)
            {
                middle += mark;
            }
            return middle / marks.Length;
        }

        public static Student? InitializeStudent(int numberExams)
        {
            Console.Write("enter a name student: ");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name)) return null;
            int[] marks = Program.SetMarks(numberExams);

            return new Student(marks, name);
        }
    }
}
