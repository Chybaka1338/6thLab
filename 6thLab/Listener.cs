using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal struct Listener
    {
        List<string> _answers;

        public string this[int index]
        {
            get { return _answers[index]; }
        }

        private Listener(List<string> answers)
        {
            _answers = answers;
        }

        public static Listener InitializeListener(List<String> questions)
        {
            Console.WriteLine();
            List<string> answers = new List<string>();
            questions.ForEach(question =>
            {
                Console.Write(question + " ");
                answers.Add(Console.ReadLine());
            });
            return new Listener(answers);
        }
    }
}
