using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;
using NUnit.Framework;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    class AirspaceTest
    {
        private ITrack faketrack;
        private IAirspace uut;

        [SetUp]
        public void SetUp()
        {
            uut = new Airspace();
        }

        [TestCase(9000,9000,50)]
        [TestCase(79999,79999,19549)]
        public void DefineAirspace_IsCorrect(int X, int Y, int Altitude)
        {
            faketrack = new Track(){XCoordinate = 1000+X, YCoordinate = 1000+Y, Altitude = 450+Altitude};

            Assert.That(uut.DefineAirspace(faketrack),Is.EqualTo(true));
        }

        [TestCase(-1,-1,-1)]
        [TestCase(80001,80001,19501)]
        [TestCase(-1,-1,0)]
        [TestCase(0,0,-1)]
        public void DefineAirspace_IsOutOfAirspace(int X, int Y, int Altitude)
        {
            faketrack = new Track() { XCoordinate = 10000 + X, YCoordinate = 10000 + Y, Altitude = 500 + Altitude };

            Assert.That(uut.DefineAirspace(faketrack), Is.EqualTo(false));
        }
    }
}
