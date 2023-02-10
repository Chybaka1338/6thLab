using System;
using System.Collections.Generic;

namespace _6thLab
{
    internal class Program
    {
        public static int seed = DateTime.Now.Millisecond;
        public static Random r = new Random(seed);

        static void Main(string[] args)
        {
            //Task1_1();
            DateTime time = new DateTime();
            Console.WriteLine($"{time.Minute}:{time.Millisecond}");
            time = time.AddMilliseconds(6000);
            Console.WriteLine($"{time.Minute}:{time.Second}");

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

        static void Task1_2()
        {
            List<Women> participants = Women.GetParticipants();

            participants.Sort((Women w1, Women w2) =>
            {
                return w1._timeSeconds.CompareTo(w2._timeSeconds) * (-1);
            });

            int standart = 120;

            foreach(var participant in participants)
            {
                bool isPassed = participant._timeSeconds < standart;
                
                Console.WriteLine($"{participant._lastName}, {participant._nameGroup}, {participant._lastNameTeacher}, {new DateTime()}");
            }
        }
        #endregion
    }
}
