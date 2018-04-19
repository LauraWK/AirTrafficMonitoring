using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface IMonitoredPlanes
    {
        void Update(ITrack track1, ITrack track2);
    }
}
