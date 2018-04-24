using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public abstract class SubjectMonitoredPlanes
    {
        private List<ISeperationEvent> observerList = new List<ISeperationEvent>();

        public void Attach(ISeperationEvent observer)
        {
            observerList.Add(observer);
        }

        public void Detach(ISeperationEvent observer)
        {
            observerList.Remove(observer);
        }

        public void Notify(ITrack track1, ITrack track2)
        {
            foreach (var observer in observerList)
            {
                observer.Update(track1, track2);
            }
        }
    }
}
