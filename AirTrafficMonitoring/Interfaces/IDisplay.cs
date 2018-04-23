using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface IDisplay
    {
        void ShowTrack(ITrack _track);
        void ShowSeperationEvent(ITrack track1, ITrack track2);
    }
}
