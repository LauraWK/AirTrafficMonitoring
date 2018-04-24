using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Domain;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    class CalculatorTest
    {

        private ITrack faketrack1;
        private ITrack fakeTrack2;
        private Calculator uut;

        [SetUp]
        public void SetUp()
        {
            uut = new Calculator();
        }



        [TestCase(100, 100, 10, 14.142135623730951)]
        [TestCase(500, 500, 20, 35.355339059327378)]
        [TestCase(-150, -150, 2, 106.06601717798213)]
        public void DetermineVelocityIsCorrect(int X, int Y, int Time, double Result)
        {
            faketrack1 = new Track() { Tag = "ABC123", XCoordinate = 5000, YCoordinate = 5000, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00, 000) };
            fakeTrack2 = new Track() { Tag = "ABC123", XCoordinate = 5000 + X, YCoordinate = 5000 + Y, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00 + Time, 000) };
            Assert.That(uut.DetermineVelocity(faketrack1, fakeTrack2), Is.EqualTo(Result));
        }

        [TestCase(10000, 10000, 10000, 90000, 0)]
        [TestCase(10000, 90000, 90000, 90000, 90)]
        [TestCase(10000, 90000, 10000, 90000, 180)]
        [TestCase(90000, 90000, 10000, 90000, 270)]

        public void DegreesIsCorrect(int x1, int y1, int x2, int y2, double result)
        {
            faketrack1 = new Track() {Tag = "ABC123", XCoordinate = x1, YCoordinate = y1};
            fakeTrack2 = new Track() {Tag = "ABC123", XCoordinate = x2, YCoordinate = y2};
            Assert.That(Math.Round(uut.Direction(faketrack1, fakeTrack2)), Is.EqualTo(result));
        }
    }
    }
