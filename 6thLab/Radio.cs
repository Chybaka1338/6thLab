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
            for(int i = 0; i < _answers.Length; i++)
            {
                Sort(i);
            }
        }

        void Sort(int curIndex)
        {
            var pairs = _answers[curIndex].ToList();
            int numberMaxElements = pairs.Count > 5 ? 5 : pairs.Count;

            for(int i = 0; i < numberMaxElements; i++)
            {
                var currentPair = pairs[i];
                var index = i;
                for(int j = i + 1; j < pairs.Count; j++)
                {
                    if (pairs[j].Value > currentPair.Value)
                    {
                        currentPair = pairs[j];
                        index = j;
                    }
                    pairs[index] = pairs[i];
                    pairs[i] = currentPair;
                }
            }
            _answers[curIndex] = pairs.ToDictionary(p => p.Key, p => p.Value);
        }

        public void PrintPopularAnswers()
        {
            for(int i = 0; i < _answers.Length; i++)
            {
                Console.WriteLine($"popular answers for this question: {_questions[i]}");

                if (_answers[i].Count == 0)
                {
                    Console.WriteLine("Никто не ответил на данный вопрос");
                }

                int numberMaxElements = _answers[i].Count > 5 ? 5 : _answers[i].Count;
                foreach(var pair in _answers[i])
                {
                    var percent = (double)pair.Value / _countAnswers[i] * 100; 
                    Console.WriteLine($"{pair.Key}, {pair.Value}, {Math.Round(percent, 1)}%");
                    numberMaxElements--;
                    if (numberMaxElements == 0) break;
                }
                Console.WriteLine();
            }
        }
    }
}
