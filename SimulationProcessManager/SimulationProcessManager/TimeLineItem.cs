using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Autodesk.AutoCAD.Runtime;
//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.EditorInput;
//using Autodesk.AutoCAD.Geometry;
using System.Windows.Forms;
using System.Drawing;

namespace SimulationProcessManager
{
    class TimeLineItem
    {


        public int _itemNumber { get; private set; }
        public string _label { get; private set; }

        public string _conveyorNumber { get; private set; }
        public string _action { get; private set; }
        
        public DateTime _processStartTime { get;  set; }
        public DateTime _startTime { get;   set; }
        public DateTime _endTime { get;  set; }
        public double _duration { get;  set; }

        /// <summary>
        /// who owns the action? (nexus, plc, ant, conveyor 1, conveyor 2, etc.)
        /// </summary>
        public eActionOwner _actionOwner { get; private set; }

        /// <summary>
        /// this is the exception flag: if true: the action passed, if false: the action failed
        /// </summary>
        public bool _actionPassed { get;  set; }

        /// <summary>
        /// if true: is a moveable action within CAD model
        /// </summary>
        public bool _isAnimated { get; private set; }


        public  Point2d _startPoint { get; private set; }
        public Point2d _endPoint { get; private set; }

        public int _ySpaceFactor { get; private set; }

        public Color _itemColor { get; private set; }

        public TimeLineItem(int itemNumber, string label, string action, DateTime processStartTime, DateTime startTime, DateTime endTime, double duration)
        {
            _label = label;
            _action = action;
            _processStartTime = processStartTime;
            _startTime = startTime;
            _endTime = endTime;
            _duration = duration;
            _itemNumber = itemNumber;
            // calculate start point and end point
            calulatePoints(itemNumber + 1); // add one for a buffer
            setItemColor(label);

        }

        public TimeLineItem(int itemNumber,string conveyorNumber, eActionOwner actionOwner, string action, DateTime processStartTime, DateTime startTime, DateTime endTime, double duration,bool isAnimated, bool actionPassed)
        {
            _actionOwner = actionOwner;
            _action = action;
            _processStartTime = processStartTime;
            _startTime = startTime;
            _endTime = endTime;
            _duration = duration;
            _itemNumber = itemNumber;
            _actionPassed = actionPassed;
            _conveyorNumber = conveyorNumber;
            _isAnimated = isAnimated;
            formatDates();
            // calculate start point and end point
            calulatePoints(itemNumber + 1); // add one for a buffer
            setItemColor(actionOwner);

        }

        const string TIME_FORMAT = "h:mm:ss.ff";
        /// <summary>
        /// date difference function seems to have a bug where it will randomly swap out PM and AM
        /// </summary>
        private void formatDates()
        {
            string tStart = _startTime.ToString(TIME_FORMAT);
            string tEnd = _endTime.ToString(TIME_FORMAT);
            string tProcessStart = _processStartTime.ToString(TIME_FORMAT);
            _startTime = Convert.ToDateTime(tStart);
            _endTime = Convert.ToDateTime(tEnd);
            _processStartTime = Convert.ToDateTime(tProcessStart);
        }


        public enum eActionOwner { nexus, ant, plc, c1, c2, c3, c4, hmi, light_sensor, proxy_sensor, bin }

        const  int Y_SPACE_FACTOR = 25;
        const int SCALE_FACTOR = 50;
        public void calulatePoints(int itemNumber)
        {
            int yCoord = itemNumber * Y_SPACE_FACTOR;
            double timeDif = (_startTime - _processStartTime).TotalSeconds; // difference between origin start time and when the individual step occurs
            //if (itemNumber == 1)
            //{
            //    timeDif = 1; // buffer for left hand side
            //}
            _ySpaceFactor = Y_SPACE_FACTOR;

            float xStart = (float) timeDif * SCALE_FACTOR;
            float xEnd =  xStart + ((float)_duration * SCALE_FACTOR);
            _startPoint = new Point2d(xStart, yCoord);
            _endPoint = new Point2d(xEnd, yCoord);
        }

        private void setItemColor(string itemLabel)
        {
            if (itemLabel.ToLower().Trim().Equals("ant"))
            {
                _itemColor = Color.Gray;
            }
            else if (itemLabel.ToLower().Trim().Equals("bin"))
            {
                _itemColor = Color.Red;
            }
            else if (itemLabel.ToLower().Trim().Equals("ant & bin"))
            {
                _itemColor = Color.BlueViolet;
            }
            else if (itemLabel.ToLower().Trim().Equals("pick port"))
            {
                _itemColor = Color.CadetBlue;
            }
            else if (itemLabel.ToLower().Trim().Equals("front workstation"))
            {
                _itemColor = Color.DarkOliveGreen;
            }
            else
            {
                _itemColor = Color.Blue;
            }

        }

        public void setItemColor(eActionOwner itemLabel)
        {
            if (itemLabel == eActionOwner.ant)
            {
                _itemColor = Color.Gray;
            }
            else if (itemLabel == eActionOwner.bin)
            {
                _itemColor = Color.Red;
            }
            else if (itemLabel == eActionOwner.c1)
            {
                _itemColor = Color.BlueViolet;
            }
            else if (itemLabel == eActionOwner.c2)
            {
                _itemColor = Color.CadetBlue;
            }
            else if (itemLabel == eActionOwner.c3)
            {
                _itemColor = Color.DarkOliveGreen;
            }
            else if (itemLabel == eActionOwner.c4)
            {
                _itemColor = Color.Azure;
            }
            else if (itemLabel == eActionOwner.hmi)
            {
                _itemColor = Color.Orange;
            }
            else if (itemLabel == eActionOwner.light_sensor)
            {
                _itemColor = Color.OrangeRed;
            }
            else if (itemLabel == eActionOwner.nexus)
            {
                _itemColor = Color.Blue;
            }
            else if (itemLabel == eActionOwner.plc)
            {
                _itemColor = Color.DarkSeaGreen;
            }
            else if (itemLabel == eActionOwner.proxy_sensor)
            {
                _itemColor = Color.Goldenrod;
            }
            else
            {
                _itemColor = Color.Blue;
            }

        }

        //        Ant
        //Bin
        //Ant & Bin
        //Pick Port
    }
}
