using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;


namespace Integration.Test.ATM.Tests
{
    [TestFixture]
    class TracksInAirspaceControllerIntergration
    {
        private IAirspace _airspace;
        private ISortingPlanesController _controller;
        private TracksInAirspaceController _tracksInAirspaceController;
        private ReceivedDataController _driver;
        private ITransponderReceiver _receiver;
        private List<string> _myList;
        private ITrack track1;

        [SetUp]
        public void SetUp()
        {
            _airspace = Substitute.For<IAirspace>();
            _controller = Substitute.For<ISortingPlanesController>();
            _tracksInAirspaceController = new TracksInAirspaceController(_airspace, _controller);
            _receiver = Substitute.For<ITransponderReceiver>();
            _driver = new ReceivedDataController(_receiver,_tracksInAirspaceController);
            track1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 1000,
            };
            
        }

        [Test]
        public void AddToList_TracksInAirspace_MatchTracks_IsCalled()
        {
            var trackstring = "ABC123;10000;10000;1000;20180306000000000";
            _myList = new List<string> { trackstring };
            _airspace.DefineAirspace(new Track()).ReturnsForAnyArgs(true);
            _driver.DataReady(this,new RawTransponderDataEventArgs(_myList));
            _controller.Received().MatchTracks(Arg.Is<Track>((x) => x.Tag == "ABC123"));
        }

        [Test]
        public void AddToList_TracksNotInAirspace_RemoveTracks_IsCalled()
        {
            var track2 = "DEF456;200000;200000;200000;20180306000000000";
            _myList = new List<string> { track2 };
            _driver.DataReady(this,new RawTransponderDataEventArgs(_myList));
            _controller.Received().removeTrack(Arg.Is<Track>((x) => x.Tag == "DEF456"));
        }

    }
}
