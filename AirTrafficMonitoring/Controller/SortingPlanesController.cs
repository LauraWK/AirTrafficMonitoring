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
    public class SortingPlanesController
    {
        private List<ITrack> CurrentTracks;
        private Velocity _velocity;
        private CompassCourse _compassCourse;
        private IDisplay display;
        private MonitoredPlanes monitoredPlanes;
        private List<ITrack> tracksToRemove;


        public SortingPlanesController()
        {
            CurrentTracks = new List<ITrack>();
            _velocity = new Velocity();
            _compassCourse = new CompassCourse();
            display = new Display();
            monitoredPlanes = new MonitoredPlanes();
            tracksToRemove = new List<ITrack>();
        }

        public void MatchTracks(ITrack track)
        {
                foreach (var t in CurrentTracks)
                {
                    if (track.Tag == t.Tag)
                    {
                        track.Velocity = _velocity.DetermineVelocity(track, t);
                        track.CompassCourse = _compassCourse.Direction(track,t);
                        tracksToRemove.Add(t);
                    }
                }
            CurrentTracks.Add(track);
            display.ShowTrack(track);
            foreach (var R in tracksToRemove)
            {
                if (CurrentTracks.Contains(R))
                    CurrentTracks.Remove(R);
            }
            tracksToRemove.Clear();
            monitoredPlanes.HandleSeperationEvents(CurrentTracks);
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
