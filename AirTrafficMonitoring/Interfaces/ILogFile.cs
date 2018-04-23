using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    interface ILogFile
    {
        void LogToFile(TextWriter w, ITrack track1, ITrack track2);
    }
}
