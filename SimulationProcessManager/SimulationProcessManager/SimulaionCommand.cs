using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProcessManager
{
    class SimulaionCommand
    {

        public string _item { get; private set; }
        public int _stepNumber { get; private set; }
        public string _direction { get; private set; }
        public int _gridSpaces { get; private set; }
        public int _speedIncrement { get; private set; }


        public SimulaionCommand(string item, int stepNumber, string direction, int gridSpaces, int speedIncrement)
        {
            _item = item;
            _stepNumber = stepNumber;
            _direction = direction;
            _gridSpaces = gridSpaces;
            _speedIncrement = speedIncrement;
        }
    }
}
