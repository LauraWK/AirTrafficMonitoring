﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
   public interface ISeperationEvent
   {
       void Update(ITrack track1, ITrack track2);
   }
}
