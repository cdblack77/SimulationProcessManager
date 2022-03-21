using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationProcessManager
{
    class TimeLineItemsList : List<TimeLineItem>
    {


        public DateTime _processStartTime { get; private set; }
        public DateTime _processEndTime { get; private set; }

        public double _processDuration { get; private set; }

        public void calculateProcessDuration(DateTime startTime, DateTime endTime)
        {
            _processDuration =Math.Round( (endTime - startTime).TotalSeconds, 3);
        }

    }
}
