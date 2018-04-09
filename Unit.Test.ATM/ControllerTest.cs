using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    public class ControllerTest
    {
        private ITransponderReceiver receiver;
        private ControllerReceivedData uut;
        private TrackFactory fakeFactory;
      

        [SetUp]
        public void Setup()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            fakeFactory = Substitute.For<TrackFactory>();
            uut = new ControllerReceivedData(receiver);
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
            var listofdata = new List<string>() { "ATR423;39045;12932;14000;20180412123244765" };
            uut.DataReady(this, new RawTransponderDataEventArgs(listofdata));
            fakeFactory.Received().Create("ATR423;39045;12932;14000;20180412123244765");
        }



        
    }
}
