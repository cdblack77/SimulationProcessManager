using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SimulationProcessManager
{
    class WorkFlowItemList
    {

        public WorkFlowItemList()
        {
            _workFlowList = new BindingList<TimeLineItem>();
        }


        public void buildWorkFlowList()
        {
            #region test data
            // hard code a bunch of items for testing... this will eventually come from an excel sheet or database table:
            double duration = 1.0;
            DateTime processStartTime = DateTime.Now;
            DateTime startTime = processStartTime;
            DateTime endTime = startTime.AddSeconds(duration) ;
            TimeLineItem t = new TimeLineItem(1, "C1", TimeLineItem.eActionOwner.nexus, "Order Ant to Pick Bin and Place", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);


            // this will be an ant movement in model
            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(2, "C1", TimeLineItem.eActionOwner.ant, "Gets Bin and Reaches Queue", processStartTime, startTime, endTime, duration, true, true); ;
            addWorkFlowItem(t);



            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(3, "C1", TimeLineItem.eActionOwner.nexus, "Initiate Handshake with PLC", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(4, "C1", TimeLineItem.eActionOwner.plc , "Completes Handshake", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(5, "C1", TimeLineItem.eActionOwner.plc, "Gets Sensor Data", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(6, "C1", TimeLineItem.eActionOwner.plc, "Confirm Bin On C1 & Ant Cleared", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(7, "C1", TimeLineItem.eActionOwner.c1, "Confirm C2 is Clear", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(8, "C1", TimeLineItem.eActionOwner.c1, "Start Timer", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(9, "C1", TimeLineItem.eActionOwner.c1, "Lift to Engage with Bin", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(10, "C1", TimeLineItem.eActionOwner.c1, "Confirm C2 is Clear", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            startTime = endTime;
            endTime = startTime.AddSeconds(duration);
            t = new TimeLineItem(11, "C1", TimeLineItem.eActionOwner.c1, "Start Rollers", processStartTime, startTime, endTime, duration, false, true); ;
            addWorkFlowItem(t);

            #endregion
        }

        public BindingList<TimeLineItem> _workFlowList { get;  set; }

        public void addWorkFlowItem(TimeLineItem tlItem)
        {
            _workFlowList.Add(tlItem);
        }

    }
}
