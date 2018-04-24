using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace Integration.Test.ATM.Tests
{
    [TestFixture]
    class AirspaceIntergrationTest
    {
        private Airspace _airspace;
        private ISortingPlanesController _controller;
        private TracksInAirspaceController _tracksInAirspaceController;
        private ITransponderReceiver _receiver;
        private ITrack track1;
        private ITrack track2;

        [SetUp]
        public void SetUp()
        {
            _airspace = new Airspace();
            _controller = Substitute.For<ISortingPlanesController>();
            _tracksInAirspaceController = new TracksInAirspaceController(_airspace,_controller);
            track1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 2000,
            };
            track2 = new Track()
            {
                Tag = "DEF456",
                XCoordinate = 10,
                YCoordinate = 10,
                Altitude = 4,
            };
        }

        [Test]
        public void TrackIsInAirspace()
        {
            _tracksInAirspaceController.AddToList(track1);
            Assert.That(_airspace.DefineAirspace(track1),Is.EqualTo(true));
        }

        [Test]
        public void TracksIsNotInAirspace()
        {
            _tracksInAirspaceController.AddToList(track2);
            Assert.That(_airspace.DefineAirspace(track2),Is.EqualTo(false));
        }
           
    }
}
