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
    public class SortingPlanesController: ISortingPlanesController
    {
        private List<ITrack> CurrentTracks;
        private IDisplay _display;
        private IMonitoredPlanes monitoredPlanes;
        private List<ITrack> tracksToRemove;
        private ICalculator _calc;
        private List<ITrack> _otherTracksToRemove;
      


        public SortingPlanesController(List<ITrack> currentlist, IDisplay display, IMonitoredPlanes monitor,  List<ITrack> tracktoremove, ICalculator calc, List<ITrack> otherTracksToRemove)
        {
            CurrentTracks = currentlist;
            _display = display;
            monitoredPlanes = monitor;
            tracksToRemove = tracktoremove;
            _calc = calc;
            _otherTracksToRemove = otherTracksToRemove;
        }

        public void MatchTracks(ITrack track)
        {
                foreach (var t in CurrentTracks)
                {
                    if (track.Tag == t.Tag)
                    {
                        track.Velocity = _calc.DetermineVelocity(track, t);
                        track.CompassCourse = _calc.Direction(track,t);
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
                    _otherTracksToRemove.Add(old);
                }
            }

            foreach (var Ot in _otherTracksToRemove)
            {
                if (CurrentTracks.Contains(Ot))
                    CurrentTracks.Remove(Ot);
            }
            _otherTracksToRemove.Clear();
        }
    }
}
