using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    public struct Person
    {
        public string lastName;
        public string society;
        public double firstTry;
        public double lastTry;

        public readonly double TotalLength;

        public Person(string lastName, string society, double firstTry, double lastTry)
        {
            this.lastName = lastName;
            this.society = society;
            this.firstTry = firstTry;
            this.lastTry = lastTry;
            TotalLength = firstTry + lastTry;
        }
    }
}
