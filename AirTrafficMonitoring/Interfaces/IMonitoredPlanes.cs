﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface IMonitoredPlanes
    {
        void HandleSeperationEvents(List<ITrack> tracklist);
    }
}
