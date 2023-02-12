using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _6thLab
{
    internal struct Radio
    {
        List<string> first;
        List<string> second;
        List<string> third;

        public List<string> First { get { return first; } }
        public List<string> Second { get { return second; } }
        public List<string> Third { get { return third; } }

        public void SetAnswers(List<Listener> listeners)
        {
            first = new List<string>();
            second = new List<string>();
            third = new List<string>();

            foreach(var listener in listeners)
            {
                first.Add(listener[0]);
                second.Add(listener[1]);
                third.Add(listener[2]);
            }
        }

        public static Dictionary<string, int> SortAnswers(List<string> answers)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            answers.RemoveAll(answer => String.IsNullOrEmpty(answer));
            answers.ForEach(answer => answer.ToLower().Trim());
            answers.Sort();
            foreach (var answer in answers)
            {
                if (!dict.ContainsKey(answer))
                    dict.Add(answer, 1);
                else
                    dict[answer]++;
            }

            var sortedDict = dict.OrderByDescending(answer => answer.Value).ToDictionary(answer => answer.Key, answer => answer.Value);
            return sortedDict;
        }

        public static void PrintPair(KeyValuePair<string, int> pair, int place, int percent)
        {
            Console.WriteLine($"{place}) Answer: {pair.Key} answers to the question {pair.Value}, {percent}");
        }

        public static void PrintStatistic(Dictionary<string, int> dict)
        {
            int countAnswers = 0;
            foreach (var pair in dict)
            {
                countAnswers += pair.Value;
            }

            int upBound = dict.Count >= 5 ? 5 : dict.Count;
            for(int i = 0; i < upBound; i++)
            {
                var pair = dict.ElementAt(i);
                int place = i + 1;
                int percent = (pair.Value / countAnswers) * 100;
                PrintPair(pair, place, percent);
            }
        }
    }
}
