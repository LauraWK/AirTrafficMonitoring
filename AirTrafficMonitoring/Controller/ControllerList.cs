using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;

namespace AirTrafficMonitoring.Controller
{
    public class ControllerList
    {
        private List<ITrack> TrackList;
        private Airspace airspace;

        public ControllerList()
        {
            TrackList = new List<ITrack>();
            airspace = new Airspace();
        }

        public void AddToList(ITrack track)
        {
            if (airspace.DefineAirspace(track))
            {
                TrackList.Add(track);
            }
        }
    }
}
