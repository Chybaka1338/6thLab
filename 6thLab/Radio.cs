using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Policy;
using System.Threading;

namespace _6thLab
{
    internal struct Radio
    {
        List<String> _questions;
        Dictionary<String, int>[] _answers;
        Dictionary<String, int>[] _popularAnswers;
        int[] _countAnswers;

        static public Radio InitializeRadio(List<String> questions, List<Listener> listeners)
        {
            Radio radio = new Radio();
            radio.SetQuestions(questions);
            radio.SetAnswers(listeners);
            radio.DeleteAllEmptyAnswers();
            radio.SetTotalNumberAnswers();
            radio.SetPopularAnswers();
            return radio;
        }

        private void SetQuestions(List<String> questions)
        {
            _questions = questions;
        }

        private void SetAnswers(List<Listener> listeners)
        {
            _answers = new Dictionary<string, int>[_questions.Count];
            for (int i = 0; i < _answers.Length; i++)
            {
                _answers[i] = new Dictionary<string, int>();
            }

            foreach(var listener in listeners)
            {
                for(int i = 0; i < _answers.Length; i++)
                {
                    if (!_answers[i].ContainsKey(listener[i])) _answers[i].Add(listener[i], 1);
                    else _answers[i][listener[i]]++;
                }
            }
        }

        private void DeleteAllEmptyAnswers()
        {
            for(int i = 0; i < _answers.Length; i++)
            {
                var key = _answers[i].Keys.ToArray();
                for(int j = 0; j < key.Length; j++)
                {
                    if (String.IsNullOrEmpty(key[j])) _answers[i].Remove(key[j]);
                }
            }
        }

        private void SetTotalNumberAnswers()
        {
            _countAnswers = new int[_answers.Length];

            for(int i = 0; i < _answers.Length; i++)
            {
                _countAnswers[i] = 0;
                foreach(var pair in _answers[i])
                {
                    _countAnswers[i] += pair.Value;
                }
            }
        }

        void SetPopularAnswers()
        {
            _popularAnswers = new Dictionary<string, int>[_answers.Length];
            var buff = Copy();
            
            for(int i = 0; i < buff.Length; i++)
            {
                _popularAnswers[i] = GetPopularAnswers(buff[i].ToList());
            }
        }

        Dictionary<String, int>[] Copy()
        {
            Dictionary<String, int>[] dist = new Dictionary<string, int>[_answers.Length];
            for(int i = 0; i < dist.Length; i++)
            {
                dist[i] = new Dictionary<string, int>(_answers[i]);
            }
            return dist;
        }

        static Dictionary<String, int> GetPopularAnswers(List<KeyValuePair<String, int>> pairs)
        {
            Dictionary<String, int> popularAnswers = new Dictionary<string, int>();
            int numberMaxElements = pairs.Count > 5 ? 5 : pairs.Count;
            int max = int.MinValue;
            var pair = new KeyValuePair<String, int>();

            int i = 0;
            while (numberMaxElements != 0)
            {
                if (i == pairs.Count)
                {
                    max = int.MinValue;
                    i = 0;
                    numberMaxElements--;
                    popularAnswers.Add(pair.Key, pair.Value);
                    pairs.Remove(pair);
                    continue;
                }

                if (max < pairs[i].Value)
                {
                    max = pair.Value;
                    pair = pairs[i];
                }
                i++;
            }
            return popularAnswers;
        }

        public void PrintPopularAnswers()
        {
            for(int i = 0; i < _popularAnswers.Length; i++)
            {
                Console.WriteLine($"popular answers for this question: {_questions[i]}");

                if (_popularAnswers[i].Count == 0)
                {
                    Console.WriteLine("Никто не ответил на данный вопрос");
                }

                foreach(var pair in _popularAnswers[i])
                {
                    var percent = (double)pair.Value / _countAnswers[i] * 100; 
                    Console.WriteLine($"{pair.Key}, {pair.Value}, {Math.Round(percent, 1)}%");
                }
                Console.WriteLine();
            }
        }
    }
}
