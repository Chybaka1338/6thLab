using System;
using System.Collections.Generic;

namespace _6thLab
{
    public struct Women
    {
        public string _lastName;
        public string _nameGroup;
        public string _lastNameTeacher;
        public int _timeSeconds;

        public Women(string lastName, string nameGroup, string lastNameTeacher, int timeMilliseconds)
        {
            _lastName = lastName;
            _nameGroup = nameGroup;
            _lastNameTeacher = lastNameTeacher;
            _timeSeconds = timeMilliseconds;
        }

        public static List<Women> GetParticipants()
        {
            List<Women> participants = new List<Women>();
            while(true)
            {
                Console.Write("enter the last name: ");
                string lastName = Console.ReadLine();
                if (String.IsNullOrEmpty(lastName)) break;

                Console.Write("enter the name of the group: ");
                string nameGroup = Console.ReadLine();
                if (String.IsNullOrEmpty(nameGroup)) break;

                Console.Write("enter the teacher`s name: ");
                string lastNameTeacher = Console.ReadLine();
                if (String.IsNullOrEmpty(lastNameTeacher)) break;

                participants.Add(new Women(lastName, nameGroup, lastNameTeacher, GetTime()));
            }
            return participants;
        }

        static int GetTime()
        {
            int minTimeSeconds = 105;
            int maxTimeSeconds = 120;
            return Program.r.Next(minTimeSeconds, maxTimeSeconds);
        }
    }
}