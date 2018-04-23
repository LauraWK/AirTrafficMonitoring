using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public class MonitoredPlanes : SubjectMonitoredPlanes
    {
        
        public void HandleSeperationEvents(List<ITrack> trackList) 
        {
            for (int i = 0; i < trackList.Count; i++)
            {
                for (int j = i+1; j < trackList.Count; j++)
                {
                    if (trackList.Count >= 2 && trackList[i].Tag != trackList[j].Tag)
                    {
                        double xCoordinate1 = trackList[i].XCoordinate;
                        double xCoordinate2 = trackList[j].XCoordinate;
                        double yCoordinate1 = trackList[i].YCoordinate;
                        double yCoordinate2 = trackList[j].YCoordinate;
                        double altitude1 = trackList[i].Altitude;
                        double altitude2 = trackList[j].Altitude;

                        if (Math.Abs(xCoordinate1 - xCoordinate2) < 5000 && Math.Abs(yCoordinate2 - yCoordinate1) < 5000
                            && Math.Abs(altitude1 - altitude2) < 300)
                        {
                            Notify(trackList[i],trackList[j]);
                        }
                    }
                }
            }

        }
    }
}
