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
                foreach(var pair in _answers[i])
                {
                    if(String.IsNullOrEmpty(pair.Key)) _answers[i].Remove(pair.Key);
                }
            }
        }

        private void SetTotalNumberAnswers()
        {
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
            Dictionary<String, int>[] popularAnswers = new Dictionary<String, int>[_answers.Length];
            for(int i = 0; i < _answers.Length; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    var popularAnswer = GetPopularAnswer(_answers[i]);
                    popularAnswers[i].Add(popularAnswer.Key, popularAnswer.Value);
                    _answers[i].Remove(popularAnswer.Key);
                }
            }

            _popularAnswers = popularAnswers;
        }

        static KeyValuePair<string, int> GetPopularAnswer(Dictionary<String, int> dict)
        {
            int max = int.MinValue;
            KeyValuePair<String, int> popularAnswer = new KeyValuePair<string, int>();
            foreach(var pair in dict)
            {
                if(max < pair.Value)
                {
                    max = pair.Value;
                    popularAnswer = pair;
                }
            }
            return popularAnswer;
        }

        public void PrintPopularAnswers()
        {
            for(int i = 0; i < _popularAnswers.Length; i++)
            {
                foreach(var pair in _popularAnswers[i])
                {
                    var percent = (double)pair.Value / _countAnswers[i]; 
                    Console.WriteLine($"{pair.Key}, {pair.Value}, {percent}%");
                }
            }
        }
    }
}
