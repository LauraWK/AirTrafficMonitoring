using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Boundary;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    class SeperationEventsTest
    {
        private SeperationEvent uut;
        private ITrack faketrack1;
        private ITrack faketrack2;
        private IDisplay fakeDisplay;
        private ILogFile fakeLogFile;
        private MonitoredPlanes fakeMonitoredPlanes;


        [SetUp]
        public void SetUp()
        {
            fakeMonitoredPlanes = Substitute.For<MonitoredPlanes>();
            fakeDisplay = Substitute.For<IDisplay>();
            fakeLogFile = Substitute.For<ILogFile>();
            uut = new SeperationEvent(fakeMonitoredPlanes,fakeDisplay);
            faketrack1 = new Track();
            faketrack2 = new Track();
        }

        [Test]
        public void Update_WasCalled()
        {
            uut.Update(faketrack1,faketrack2);
            fakeLogFile.Received().LogToFile(faketrack1,faketrack2);
            fakeDisplay.Received().ShowSeperationEvent(faketrack1,faketrack2);
        }
    }
}
