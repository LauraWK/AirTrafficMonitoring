using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Domain;
using NUnit;
using NSubstitute;
using NUnit.Framework;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    public class VelocityTest
    {
        private ITrack faketrack1;
        private ITrack fakeTrack2;
            
        private Velocity uut;

        [SetUp]
        public void SetUp()
        {
            
            uut = new Velocity();
        }

        [TestCase(100, 100, 10, 14.142)]

        public void DetermineVelocityIsCorrect(int X, int Y, int Time, double Result)
        {
            faketrack1 = new Track() { Tag = "ABC123", XCoordinate = 5000, YCoordinate = 5000, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00, 000) };
            fakeTrack2 = new Track() { Tag = "ABC123", XCoordinate = 5000 + X, YCoordinate = 5000 + Y, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00 + Time, 000) };
            Assert.That(uut.DetermineVelocity(faketrack1,fakeTrack2), Is.EqualTo(Result));
        }


    }
}
