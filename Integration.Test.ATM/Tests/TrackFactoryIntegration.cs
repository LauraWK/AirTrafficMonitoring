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
        private ITransponderReceiver _receiver;
        private ITracksInAirSpaceController _tracksInAirspace;

        [SetUp]
        public void SetUp()
        {
            _tracksInAirspace = Substitute.For<ITracksInAirSpaceController>();
            _track = Substitute.For<ITrack>();
            _driver = new ReceivedDataController(_receiver,_tracksInAirspace);
        }

        [Test]
        public void Track_Is_Converted_Correctly()
        {
            _driver.DataReady(this, new RawTransponderDataEventArgs(new List<string>{ "ABC123;30000;40000;10000;20180404221230123" }));
            _tracksInAirspace.Received().AddToList(Arg.Is<ITrack>(s => s.Tag == "ABC123"));
        }
    }
}
