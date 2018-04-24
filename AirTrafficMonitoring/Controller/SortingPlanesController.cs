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
        private IDisplay _display;
        private MonitoredPlanes monitoredPlanes;
        private List<ITrack> tracksToRemove;
        private IMonitoredPlanes seperationEvent;
      


        public SortingPlanesController(List<ITrack> currentlist, IDisplay display, MonitoredPlanes monitor, IMonitoredPlanes sepevent, List<ITrack> tracktoremove)
        {
            CurrentTracks = currentlist;
            _display = display;
            monitoredPlanes = monitor;
            seperationEvent = sepevent;
            tracksToRemove = tracktoremove;
        }

        public void MatchTracks(ITrack track)
        {
                foreach (var t in CurrentTracks)
                {
                    if (track.Tag == t.Tag)
                    {
                        track.Velocity = Velocity.DetermineVelocity(track, t);
                        track.CompassCourse = CompassCourse.Direction(track,t);
                        tracksToRemove.Add(t);
                    }
                }
            CurrentTracks.Add(track);
            _display.ShowTrack(track);
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
