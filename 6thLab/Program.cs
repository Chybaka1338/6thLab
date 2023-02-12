using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _6thLab
{
    internal class Program
    {
        public static int seed = DateTime.Now.Millisecond;
        public static Random r = new Random(seed);

        static void Main(string[] args)
        {
            //Task1_1();
            //Task1_2();
            //Task2_1();
            //Task2_2();
            Console.WriteLine("\nTo finish the process, press any key");
            Console.ReadKey();
        }

        #region Level1
        #region Task1
        static void Task1_1()
        {
            List<Person> participants = Person.GetParticipants();

            participants.Sort((Person p1, Person p2) =>
            {
                return p1.TotalLength.CompareTo(p2.TotalLength) * (-1);
            });

            int place = 1;
            foreach(var participant in participants)
            {
                Console.WriteLine($"place: {place}, last name: {participant._lastName}, society: {participant._society}, " +
                    $"total length = {Math.Round(participant.TotalLength, 3)}, " +
                    $"fist try = {Math.Round(participant._firstTry, 3)}, " +
                    $"last try = {Math.Round(participant._lastTry, 3)}");
                place++;
            }
        }


        #endregion

        #region Task2
        static void Task1_2()
        {
            List<Women> participants = Women.GetParticipants();

            participants.Sort((Women w1, Women w2) =>
            {
                return w1._timeSeconds.CompareTo(w2._timeSeconds) * (-1);
            });

            int standart = 120;

            int count = 0;
            foreach(var participant in participants)
            {
                bool isPassed = participant._timeSeconds < standart;
                if (isPassed) count++;

                DateTime time = new DateTime().AddSeconds(participant._timeSeconds);
                Console.WriteLine($"{participant._lastName}, {participant._nameGroup}, " +
                    $"{participant._lastNameTeacher}, {time.Minute}:{time.Second} " +
                    $"test: {isPassed}");
            }

            Console.WriteLine("");
        }
        #endregion
        #endregion

        #region Level2
        #region Task1
        static void Task2_1()
        {
            List<Student> students = new List<Student>();

            int numberExams = 4;
            int[] marks;

            while(true)
            {
                marks = SetMarks(numberExams);
                if (marks == null) break;
                students.Add(new Student(marks));
            }

            List<Student> goodStudents = new List<Student>();
            foreach(var student in students)
            {
                if(student.Middle >= 4) goodStudents.Add(student);
            }

            goodStudents.Sort((Student s1, Student s2) =>
            {
                return s1.Middle.CompareTo(s2.Middle) * (-1);
            });

            int i = 1;
            foreach(var student in goodStudents)
            {
                Console.WriteLine($"{i} student has middle score = {student.Middle}");
            }
        }
        #endregion
        public static int[] SetMarks(int numberExams)
        {
            Console.WriteLine("Give grades to the student:");
            int[] marks = new int[numberExams];
            try
            {
                for(int i = 0; i < marks.Length; i++)
                {
                    int mark;
                    do
                    {
                        Console.Write($"Enter {i} mark = ");
                        mark = int.Parse(Console.ReadLine());
                    } while (mark < 2 && mark > 5);
                    marks[i] = mark;
                }
                return marks;
            }
            catch (Exception) { return null; }
        }

        #region Task2
        static void Task2_2()
        {
            List<Student> students = new List<Student>();

            int numberExams = 3;
            int[] marks;
            while (true)
            {
                Console.WriteLine("Give grades to the student:");
                marks = SetMarks(numberExams);
                if (marks == null) break;
                students.Add(new Student(marks));
            }

            for (int i = students.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < numberExams; j++)
                {
                    if (students[i][j] == 2) students.RemoveAt(i);
                }
            }

            students.Sort((Student s1, Student s2) =>
            {
                return s1.Middle.CompareTo(s2.Middle) * (-1);
            });

            
            foreach(var student in students)
            {
                Console.WriteLine($"student has middle score = {student.Middle}");
            }
        }
        #endregion
        #endregion

        #region Level3
        #region Task1
        static void Task3_1()
        {
            int numberExams = 5;
            int countOfGroups = 3;
            List<Group> groups = new List<Group>();
            for(int i = 0; i < countOfGroups; i++)
            {
                groups.Add(new Group(numberExams, i + 1));
            }

            foreach(var group in groups)
            {
                group.SortGroup();
            }

            foreach(var group in groups)
            {
                group.PrintGroup();
            }

            groups.Sort((Group g1, Group g2) =>
            {
                return g1.MiddleScoreGroup.CompareTo(g2.MiddleScoreGroup) * (-1);
            });

            foreach(var group in groups)
            {
                Console.WriteLine($"{group.NameGroup} has middle score = {group.MiddleScoreGroup}");
            }
        }
        #endregion

        #region Task4
        static void Task3_4()
        {
            List<Sportsmen> firstGroup = FillGroup();
            List<Sportsmen> secondGroup = FillGroup();

            firstGroup.Sort((Sportsmen s1, Sportsmen s2) =>
            {
                return s1.TimeSecond.CompareTo(s2.TimeSecond) * (-1);
            });

            PrintGroup(firstGroup);

            secondGroup.Sort((Sportsmen s1, Sportsmen s2) =>
            {
                return s1.TimeSecond.CompareTo(s2.TimeSecond) * (-1);
            });

            PrintGroup(secondGroup);

            List<Sportsmen> commonGroup = firstGroup.Concat(secondGroup).ToList();
            commonGroup.Sort((Sportsmen s1, Sportsmen s2) =>
            {
                return s1.TimeSecond.CompareTo(s2.TimeSecond) * (-1);
            });

            Console.WriteLine("All groups");
            PrintGroup(commonGroup);
        }

        static void PrintGroup(List<Sportsmen> group)
        {
            int place = 1;
            foreach(var sportsmen in group)
            {
                DateTime time = new DateTime();
                time.AddMinutes(sportsmen.TimeSecond / 60);
                time.AddSeconds(sportsmen.TimeSecond - time.Minute * 60);
                Console.WriteLine($"{place}, {sportsmen.LastName} time = ({time.Minute}m:{time.Second}s)");
                place++;
            }
        }

        static List<Sportsmen> FillGroup()
        {
            List<Sportsmen> group = new List<Sportsmen>();
            while (true)
            {
                Console.Write("enter the name: ");
                string lastName = Console.ReadLine();
                if (String.IsNullOrEmpty(lastName)) break;
                group.Add(new Sportsmen(lastName, GetTime()));
            }
            return group;
        }

        static int GetTime()
        {
            int maxTimeSecond = 1620;
            int minTimeSecond = 1350;
            return r.Next(minTimeSecond, maxTimeSecond);
        }
        #endregion

        #region Task6
        static string firstQuestion = "какое животное вы связываете с Японией и японцами?";
        static string secondQuestion = "какая черта характера присуща японцам больше всего?";
        static string thirdQuestion = "какой неодушевленный предмет или понятие вы связываете с Японией?";
        static void Task3_6()
        {
            List<Listener> listeners = new List<Listener>();
            string[] questions = { firstQuestion, secondQuestion, thirdQuestion };
            while (true)
            {
                listeners.Add(Listener.GetListener(questions));
                Console.WriteLine("would you like to end? y/n");
                if (Console.ReadKey().KeyChar.Equals('y')) break;
            }

            Radio radio = new Radio();
            radio.SetAnswers(listeners);
            Radio.PrintStatistic(Radio.SortAnswers(radio.First));
            Radio.PrintStatistic(Radio.SortAnswers(radio.Second));
            Radio.PrintStatistic(Radio.SortAnswers(radio.Third));
        }


        #endregion
        #endregion
    }
}
