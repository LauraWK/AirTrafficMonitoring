using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;

namespace AirTrafficMonitoring.Controller
{
    public class TrakcsInAirspace
    {
        private List<ITrack> CurrentTracks;
        private Velocity _velocity;
        private CompassCourse _compassCourse;
       


        public TrakcsInAirspace()
        {
            CurrentTracks = new List<ITrack>();
            _velocity = new Velocity();
            _compassCourse = new CompassCourse();
        }

        public void MatchTracks(List<ITrack> newTracks)
        {
            foreach (var n in newTracks)
            {
                foreach (var old in CurrentTracks)
                {
                    if (n.Tag == old.Tag)
                    {
                        _velocity.DetermineVelocity(n, old);
                        _compassCourse.Direction(n);
                    }
                }
            }

            CurrentTracks = newTracks;
        }
    }
}
