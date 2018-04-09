using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    public class ControllerTest
    {
        private ITransponderReceiver receiver;
        private ControllerReceivedData uut;
      

        [SetUp]
        public void Setup()
        {
            receiver = Substitute.For<ITransponderReceiver>();        
            uut = new ControllerReceivedData(receiver);
        }

        [Test]
        public void StartReceivingData_DataReady_CorrectCall()
        {
            uut.StartReceiving();
            receiver.Received().TransponderDataReady += uut.DataReady;
        }

        [Test]
        public void DataReady_CreateTrackIsCalled_PrintToConsole()
        {
            var listofdata = new List<string>() { "ATR423;39045;12932;14000;20180412123244765" };
            uut.DataReady(this, RawTransponderDataEventArgs(listofdata));
            Assert.AreEqual("Tag: ATR423 XCoordinate: 39045 YCoordinate: 12932 Altitude: 14000 Timestamp: 12-04-2018 12:32:44", Console.Out);


        }



        
    }
}
