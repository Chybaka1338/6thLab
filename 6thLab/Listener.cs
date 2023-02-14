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

        public static Listener GetListener(string[] questions)
        {
            string[] answers = new string[questions.Length];
            for(int i = 0 ; i < questions.Length; i++)
            {
                Console.WriteLine(questions[i] + " ");
                answers[i] = Console.ReadLine();
            }

            return new Listener(answers);
        }
    }
}
