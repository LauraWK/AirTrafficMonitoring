using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Boundary;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    public class SortingPlanesControllerTest
    {
        private List<ITrack> CurrentTracks;
        private IDisplay _display;
        private MonitoredPlanes monitoredPlanes;
        private List<ITrack> tracksToRemove;
        private IMonitoredPlanes seperationEvent;
        private ITrack newtrack;
        private ITrack oldtrack;
        private SortingPlanesController uut;

        [SetUp]
        public void SetUp()
        {
            CurrentTracks = new List<ITrack>(){oldtrack};
            _display = Substitute.For<IDisplay>();
            monitoredPlanes = Substitute.For<MonitoredPlanes>();
            tracksToRemove = new List<ITrack>(){oldtrack};
            seperationEvent = Substitute.For<IMonitoredPlanes>();
            newtrack = new Track() {Tag = "ABC123"};
            oldtrack = new Track() {Tag = "ABC123"};
            uut = new SortingPlanesController(CurrentTracks,_display,monitoredPlanes,seperationEvent,tracksToRemove);
        }

        [Test]
        public void MatchTracks_RemoveOldTrack()
        {
            uut.MatchTracks(newtrack);
            Assert.That(!CurrentTracks.Contains(oldtrack));
        }





    }
}
