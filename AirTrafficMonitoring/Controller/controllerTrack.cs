using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Controller
{
    public class ControllerTrack
    {
        private List<ITrack> list2;
        private List<ITrack> list1;

        public ControllerTrack()
        {
            list2 = new List<ITrack>();
            list1 = new List<ITrack>();
        }

        //vi skal tjekke om tagget er i list 2, hvis det er det skal vi tjekke om det er i list1, 
        //hvis det er det skal det erstatte list1, og ellers skal det add til list1, hvis det ikke findes i list2 skal det add i list2.
        //vi kan ikke finde ud af at sammenligne de to tag's med hinanden. 
        public void AddToLists(ITrack track)
        {
            if (list2)
            {
                if (list1.Contains())
                {
                    
                }
                else
                {
                    list1.Add(track);
                }
            }
            else
            {
                list2.Add(track);
            }
        }
        public void CompareTracks()
        {
            
        }

    }
}
