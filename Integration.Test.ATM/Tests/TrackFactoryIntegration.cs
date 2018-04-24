using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace Integration.Test.ATM
{
    [TestFixture()]
    class TrackFactoryIntegration
    {
        private ReceivedDataController _driver;
        private ITrack _track;
        private TrackFactory _trackFactory;
        private ITransponderReceiver _receiver;
        private TracksInAirspaceController _tracksInAirspace;
        private IAirspace _airspace;
        private SortingPlanesController _sortingPlanes;
        private IDisplay _display;

        [SetUp]
        public void SetUp()
        {
            _tracksInAirspace = Substitute.For<TracksInAirspaceController>();
            _track = Substitute.For<ITrack>();
            _trackFactory = new TrackFactory();
            _receiver = Substitute.For<ITransponderReceiver>();
            _airspace = Substitute.For<IAirspace>();
            _sortingPlanes = Substitute.For<SortingPlanesController>();
            _display = Substitute.For<IDisplay>();

            _tracksInAirspace = new TracksInAirspaceController(_airspace, _sortingPlanes);

            _driver = new ReceivedDataController(_receiver,_tracksInAirspace);

            var track = "ABC123;30000,40000;10000;20180404121200123";
        }

        [Test]
        public void Tag_Is_Converted_Correctly()
        {
            _driver.StartReceiving();
            ITrack tr = _trackFactory.Create("ABC123;30000,40000;10000;20180404121200123");
            _tracksInAirspace.Received().AddToList(tr);

            _display.Received().ShowTrack(Arg.Is<Track>((x) => x.Tag == "ABC123"));

        }
    }
}
