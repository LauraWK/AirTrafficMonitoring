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
using NUnit.Framework.Internal;

namespace Integration.Test.ATM.Tests
{
    [TestFixture]
    class SeperationEventsIntergrationTest
    {

        private ISortingPlanesController _controller;
        private MonitoredPlanes _monitoredPlanes;
        private ILogFile _logfile;
        private List<ITrack> currentlist;
        private IDisplay _display;
        private List<ITrack> tracksToRemove;
        private ICalculator _calculator;
        private List<ITrack> othertracksToRemove;
        private ISeperationEvent seperationEvent;
        private ITrack track1;
        private ITrack track2;

        [SetUp]
        public void SetUp()
        {
            _monitoredPlanes = new MonitoredPlanes();
            currentlist = new List<ITrack>();
            _display = Substitute.For<IDisplay>();
            tracksToRemove = new List<ITrack>();
            _calculator = Substitute.For<ICalculator>();
            othertracksToRemove = new List<ITrack>();
            _logfile = Substitute.For<ILogFile>();
            seperationEvent = new SeperationEvent(_monitoredPlanes,_display,_logfile);
            _controller = new SortingPlanesController(currentlist, _display, _monitoredPlanes, tracksToRemove, _calculator, othertracksToRemove);
            _monitoredPlanes.Attach(seperationEvent);
        }

        [TestCase(0, 0, 0)]
        [TestCase(4999, 4999, 299)]
        public void HandleSeperationEvents_IsTooClose(int X, int Y, int Altitude)
        {
            track1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 500,
            };

            track2 = new Track()
            {
                Tag = "DEF456",
                XCoordinate = 10000 + X,
                YCoordinate = 10000 + Y,
                Altitude = 500 + Altitude,
            };
            currentlist.Add(track1);

            _controller.MatchTracks(track2);
            _logfile.Received().LogToFile(track1,track2);
            _display.Received().ShowSeperationEvent(track1,track2);
        }
        [TestCase(5000, 50000, 300)]
        public void HandleSeperationEvents_IsNotTooClose(int X, int Y, int Altitude)
        {
            track1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 500,
            };

            track2 = new Track()
            {
                Tag = "DEF456",
                XCoordinate = 10000 + X,
                YCoordinate = 10000 + Y,
                Altitude = 500 + Altitude,
            };
            currentlist.Add(track1);

            _controller.MatchTracks(track2);
            _logfile.DidNotReceive().LogToFile(track1,track2);
            _display.DidNotReceive().ShowSeperationEvent(track1,track2);
        }
    }
}
