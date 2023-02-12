using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal struct Group
    {
        List<Student?> _students;
        double _middleScoreGroup;
        string _nameGroup;

        public List<Student?> Students
        {
            get { return _students; }
        }

        public double MiddleScoreGroup
        {
            get { return _middleScoreGroup; }
        }

        public string NameGroup
        {
            get { return _nameGroup; }
        }

        public Group(int numberExams, int i)
        {
            _students = new List<Student?>();
            Student? student;
            while(true)
            {
                student = Student.InitializeStudent(numberExams);
                if (student == null) break;
                _students.Add(student);
            }

            _middleScoreGroup = GetMiddleScoreGroup(_students);

            _nameGroup = $"group №{i}";
        }

        static double GetMiddleScoreGroup(List<Student?> students)
        {
            double middleScoreGroup = 0;
            foreach(var student in students)
            {
                middleScoreGroup += student.Value.Middle;
            }

            return middleScoreGroup / students.Count;
        }

        public void SortGroup()
        {
            _students.Sort((Student? s1, Student? s2) =>
            {
                return s1.Value.Middle.CompareTo(s2.Value.Middle) * (-1);
            });
        }

        public void PrintGroup()
        {
            int i = 1;
            Console.WriteLine($"\n{_nameGroup}");
            foreach (var student in _students)
            {
                Console.WriteLine($"{i}.{student.Value.Name} has middle score = {student.Value.Middle}");
                i++;
            }
        }
    }
}
