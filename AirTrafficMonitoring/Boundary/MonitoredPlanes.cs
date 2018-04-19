using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public class MonitoredPlanes : IMonitoredPlanes
    {

        public MonitoredPlanes(Display display, SeperationEvent seperation)
        {
            display.Attach(this);
            seperation.Attach(this);

        }

        public void Update(string alarm)
        {
            
        }
    }
}
