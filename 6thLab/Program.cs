using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal class Program
    {
        static int seed = DateTime.Now.Millisecond;
        static Random r = new Random(seed);

        static void Main(string[] args)
        {
            Task1_1();
            Console.ReadKey();
        }

        #region Level1
        #region Task1
        static void Task1_1()
        {
            int countParticipants = 0;
            while(countParticipants == 0) 
                int.TryParse(Console.ReadLine(), out countParticipants);

            List<Person> participants = new List<Person>();
            for(int i = 0; i < countParticipants; i++)
            {
                Console.Write("Enter the last name of participant: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter the society: ");
                string society = Console.ReadLine();
                participants.Add(new Person(lastName, society, GetLength(), GetLength()));
            }

            participants.Sort(delegate (Person person1, Person person2)
            {
                return person1.TotalLength.CompareTo(person2.TotalLength) * (-1);
            });

            int place = 1;
            foreach(var participant in participants)
            {
                Console.WriteLine($"place: {place}, last name: {participant.lastName}, society: {participant.society}, " +
                    $"total length = {participant.TotalLength}, fist try = {participant.firstTry}, last try = {participant.lastTry}");
                place++;
            }
        }

        static double GetLength()
        {
            return (r.NextDouble() + 1) * 3;
        }
        #endregion
        #endregion
    }
}
