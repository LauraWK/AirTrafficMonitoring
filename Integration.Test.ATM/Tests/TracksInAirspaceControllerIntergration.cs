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


namespace Integration.Test.ATM.Tests
{
    [TestFixture]
    class TracksInAirspaceControllerIntergration
    {
        private IAirspace _airspace;
        private SortingPlanesController _controller;
        private TracksInAirspaceController _tracksInAirspaceController;
        private ReceivedDataController _driver;
        private ITransponderReceiver _receiver;
        private List<string> _myList;

        [SetUp]
        public void SetUp()
        {
            _airspace = Substitute.For<IAirspace>();
            _controller = Substitute.For<SortingPlanesController>();
            _tracksInAirspaceController = new TracksInAirspaceController(_airspace, _controller);
            _receiver = Substitute.For<ITransponderReceiver>();
            _driver = new ReceivedDataController(_receiver,_tracksInAirspaceController);

            var track = "ABC123;10000;10000;10000;201803060000000000";
            _myList = new List<string> { track };

        }
        [Test]
        public void AddToList_TracksInAirspace_MatchTracks_IsCalled()
        {
            _driver.StartReceiving();
            _driver.DataReady(this,new RawTransponderDataEventArgs(_myList));
            _tracksInAirspaceController.Received().AddToList(Arg.Is<Track>((x) => x.Tag == "ABC123"));
        }
    }
}
