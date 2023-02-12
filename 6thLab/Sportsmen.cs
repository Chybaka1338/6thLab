using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6thLab
{
    internal struct Sportsmen
    {
        string _lastName;
        int _timeSecond;

        public string LastName { get { return _lastName; } }
        public int TimeSecond { get { return _timeSecond; } }

        public Sportsmen(string lastName, int timeSecond)
        {
            _lastName = lastName;
            _timeSecond = timeSecond;
        }
    }
}
