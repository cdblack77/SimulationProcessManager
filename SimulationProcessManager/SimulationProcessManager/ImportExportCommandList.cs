using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimulationProcessManager
{
    class ImportExportCommandList
    {



        public static void exportCommandList(string saveLocation, List<SimulaionCommand> commList)
        {
            try
            {

                List<string> sl = new List<string>();
                foreach (SimulaionCommand sc in commList)
                {
                    string lineItem = sc._stepNumber.ToString().Trim() + "$" + sc._item.Trim() + "$" + sc._direction.Trim() + "$" + sc._gridSpaces.ToString().Trim() + "$" + sc._speedIncrement.ToString().Trim();
                    sl.Add(lineItem);
                }
                string[] allLines = sl.ToArray();

                File.WriteAllLines(saveLocation, allLines);

            }
            catch
            {
                throw;

            }
        }


        public static List<SimulaionCommand> importCommandList  (string fileLocation)
        {
            
            string[] lines = File.ReadAllLines(fileLocation);
            List<SimulaionCommand> simComms = new List<SimulaionCommand>();
            foreach (string ln in lines)
            {
                string[] parse = ln.Split('$');
                SimulaionCommand sComm = new SimulaionCommand(parse[1], Convert.ToInt16( parse[0]), parse[2], Convert.ToInt16( parse[3]), Convert.ToInt16(parse[4]));
                simComms.Add(sComm);
            }

            

            return simComms;
        }
    }
}
