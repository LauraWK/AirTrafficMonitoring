using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class TrackFactory
    {
        public ITrack Create(string type)
        {
            var separatedValues = type.Split(';');

            var contverter = new Track()
            {
                Tag = separatedValues[0],
                XCoordinate = Convert.ToInt32(separatedValues[1]),
                YCoordinate = Convert.ToInt32(separatedValues[2]),
                Altitude = Convert.ToInt32(separatedValues[3]),
                Timestamp = DateTime.ParseExact("yyyymmddhhmmssfff", "yyyy - mm - dd hh: mm:ss,fff",
                    System.Globalization.CultureInfo.InvariantCulture),
            };
            return contverter;
        }
    }
}
