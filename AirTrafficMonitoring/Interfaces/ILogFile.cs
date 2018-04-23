using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface ILogFile
    {
        void LogToFile(ITrack track1, ITrack track2);
    }
}
