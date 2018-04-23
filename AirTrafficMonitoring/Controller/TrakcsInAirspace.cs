using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Boundary;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Controller
{
    public class TrakcsInAirspace
    {
        private List<ITrack> CurrentTracks;
        private Velocity _velocity;
        private CompassCourse _compassCourse;
        private IDisplay display;
        private MonitoredPlanes monitoredPlanes;


        public TrakcsInAirspace()
        {
            CurrentTracks = new List<ITrack>();
            _velocity = new Velocity();
            _compassCourse = new CompassCourse();
            display = new Display();
            monitoredPlanes = new MonitoredPlanes();
        }

        public void MatchTracks(ITrack track)
        {
                foreach (var t in CurrentTracks)
                {
                    if (track.Tag == t.Tag)
                    {
                        track.Velocity = _velocity.DetermineVelocity(track, t);
                        track.CompassCourse = _compassCourse.Direction(track);
                    }
                }
            CurrentTracks.Add(track);
            display.ShowTrack(track);
        }

        public void removeTrack(ITrack track)
        {
            foreach (var old in CurrentTracks)
            {
                if (track.Tag == old.Tag)
                {
                    CurrentTracks.Remove(old);
                }
            }
        }
    }
}
