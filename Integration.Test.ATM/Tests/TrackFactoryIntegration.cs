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
        private ITracksInAirSpaceController _tracksInAirspace;
        private IAirspace _airspace;
        private ISortingPlanesController _sortingPlanes;
        private IDisplay _display;
        private List<string> list;

        [SetUp]
        public void SetUp()
        {
            _tracksInAirspace = Substitute.For<ITracksInAirSpaceController>();
            _track = Substitute.For<ITrack>();
            _trackFactory = new TrackFactory();
            _receiver = Substitute.For<ITransponderReceiver>();
            _airspace = Substitute.For<IAirspace>();
            _sortingPlanes = Substitute.For<ISortingPlanesController>();
            _display = Substitute.For<IDisplay>();

            _driver = new ReceivedDataController(_receiver,_tracksInAirspace);

      
        }

        [Test]
        public void Tag_Is_Converted_Correctly()
        {
            var track = "ABC123;30000;40000;10000;20180404121230000";
            list = new List<string>{track};
            _driver.DataReady(this, new RawTransponderDataEventArgs(list));
            _tracksInAirspace.Received().AddToList(Arg.Is<ITrack>(s => s.Tag == "ABC123"));


            // _driver.DataReady(this, new RawTransponderDataEventArgs(new List<string>{ "ABC123;30000,40000;10000;20180404221230123" }));




            //_display.Received().ShowTrack(Arg.Is<Track>((x) => x.Tag == "ABC123"));

        }
    }
}
