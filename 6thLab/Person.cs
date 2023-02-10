using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    public struct Person
    {
        public string _lastName;
        public string _society;
        public double _firstTry;
        public double _lastTry;

        public readonly double TotalLength;

        public Person(string lastName, string society, double firstTry, double lastTry)
        {
            _lastName = lastName;
            _society = society;
            _firstTry = firstTry;
            _lastTry = lastTry;
            TotalLength = firstTry + lastTry;
        }

        public static List<Person> GetParticipants()
        {
            List<Person> participants = new List<Person>();
            Console.WriteLine("To end the input, enter an empty line");
            while (true)
            {
                Console.Write("Enter the last name of participant: ");
                string lastName = Console.ReadLine();
                if (String.IsNullOrEmpty(lastName)) break;

                Console.Write("Enter the society: ");
                string society = Console.ReadLine();
                if (String.IsNullOrEmpty(society)) break;

                participants.Add(new Person(lastName, society, GetJumpLength(), GetJumpLength()));
            }
            Console.WriteLine("input was ended");
            return participants;
        }

        static double GetJumpLength()
        {
            return (Program.r.NextDouble()) * 3;
        }
    }
}
