using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal struct Listener
    {
        string[] _answers;

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _answers.Length)
                    return _answers[index];
                return String.Empty;
            }
        }

        private Listener(string[] answers)
        {
            _answers = answers;
        }

        public static Listener? GetListener(int countOfQuestions)
        {
            string[] answers = new string[countOfQuestions];
            for(int i = 0; i < answers.Length; i++)
            {
                answers[i] = Console.ReadLine();
            }

            return new Listener(answers);
        }
    }
}
