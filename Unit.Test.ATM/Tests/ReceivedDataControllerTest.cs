using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Controller;
using TransponderReceiver;
using NUnit.Framework;
using NSubstitute;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    public class ReceivedDataControllerTest
    {
        private ITransponderReceiver receiver;
        private ReceivedDataController uut;
        private TrackFactory fakefactory;
        private AirTrafficMonitoring.Controller.TracksInAirspaceController fakeAirspaceController;

        [SetUp]
        public void SetUp()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            fakefactory = Substitute.For<TrackFactory>();
            fakeAirspaceController = Substitute.For<AirTrafficMonitoring.Controller.TracksInAirspaceController>();
            uut = new ReceivedDataController(receiver, fakeAirspaceController);

        }

        [Test]
        public void StartReceivingData_DataReady_CorrectCall()
        {
            uut.StartReceiving();
            receiver.Received().TransponderDataReady += uut.DataReady;
        }

        [Test]
        public void DataReady_IsCalled()
        {
            var listofdata = new List<string>() {"ATR423;39045;12932;12932;14000;20180412123244765"};
            uut.DataReady(this,new RawTransponderDataEventArgs(listofdata));
            fakefactory.Received().Create("ATR423;39045;12932;12932;14000;20180412123244765");
        }

    }
}
