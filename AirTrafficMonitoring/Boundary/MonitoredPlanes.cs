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
                    if (trackList.Count >= 2 && trackList[i].Tag != trackList[j].Tag )
                    {
                        double xCoordinate1 = trackList[i].XCoordinate;
                        double xCoordinate2 = trackList[j].XCoordinate;
                        double yCoordinate1 = trackList[i].YCoordinate;
                        double yCoordinate2 = trackList[j].YCoordinate;

                        if (Math.Abs(xCoordinate1 - xCoordinate2) < 300 && Math.Abs(yCoordinate2 - yCoordinate1) < 300
                            && Math.Abs(trackList[i].Altitude - trackList[j].Altitude) < 5000 )
                        {
                            Notify(trackList[i],trackList[j]);
                        }
                    }
                }
            }

        }
    }
}
