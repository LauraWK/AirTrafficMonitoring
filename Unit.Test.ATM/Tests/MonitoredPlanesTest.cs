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
    class MonitoredPlanesTest
    {
        private MonitoredPlanes uut;
        private List<ITrack> faketracklist;
        private ITrack faketrack1;
        private ITrack faketrack2;
        private ISeperationEvent fakeSeperationEvent;

        [SetUp]
        public void SetUp()
        {
            uut = new MonitoredPlanes();
            fakeSeperationEvent = Substitute.For<ISeperationEvent>();
            faketracklist = new List<ITrack>();
            uut.Attach(fakeSeperationEvent);
        }

        [TestCase(0,0,0)]
        [TestCase(4999,4999,299)]
        public void HandleSeperationEvents_IsTooClose(int X, int Y, int Altitude)
        {
            faketrack1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 500,
            };

            faketrack2 = new Track()
            {
                Tag = "DEF456",
                XCoordinate = 10000 + X,
                YCoordinate = 10000 + Y,
                Altitude = 500 + Altitude,
            };
            faketracklist.Add(faketrack1);
            faketracklist.Add(faketrack2);

            uut.HandleSeperationEvents(faketracklist);
            fakeSeperationEvent.Received().Update(faketrack1,faketrack2);
        }

        [TestCase(5000, 50000, 300)]
        public void HandleSeperationEvents_IsNotTooClose(int X, int Y, int Altitude)
        {
            faketrack1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 10000,
                Altitude = 500,
            };

            faketrack2 = new Track()
            {
                Tag = "DEF456",
                XCoordinate = 10000 + X,
                YCoordinate = 10000 + Y,
                Altitude = 500 + Altitude,
            };
            faketracklist.Add(faketrack1);
            faketracklist.Add(faketrack2);

            uut.HandleSeperationEvents(faketracklist);
            fakeSeperationEvent.DidNotReceive().Update(faketrack1,faketrack2);
        }
    }
}
