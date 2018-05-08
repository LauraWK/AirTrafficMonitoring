using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    public class TracksInAirspaceController
    {
        private IAirspace _airspace;
        private ISortingPlanesController _controller;
        private AirTrafficMonitoring.Controller.TracksInAirspaceController _uut;
        private ITrack faketrack1;
        private ITrack faketrack2;

        [SetUp]
        public void SetUp()
        {
            _airspace = Substitute.For<IAirspace>();
            _controller = Substitute.For<ISortingPlanesController>();
            _uut = new AirTrafficMonitoring.Controller.TracksInAirspaceController(_airspace,_controller);
            faketrack1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 500,
            };
            faketrack2 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 100000,
                YCoordinate = 100000,
                Altitude = 30000,
            };
            _airspace.DefineAirspace(faketrack1).Returns(true);
            _airspace.DefineAirspace(faketrack2).Returns(false);
        }

        [Test]
        public void AddToList_TrackInAirspace_MatchTracks_IsCalled()
        {
            _uut.AddToList(faketrack1);
            _controller.Received().MatchTracks(faketrack1);

        }
        [Test]
        public void AddToList_TrackOutOfAirspace_RemoveTracks_IsCalled()
        {
            _uut.AddToList(faketrack2);
            _controller.Received().removeTrack(faketrack2);

        }

    }
}
