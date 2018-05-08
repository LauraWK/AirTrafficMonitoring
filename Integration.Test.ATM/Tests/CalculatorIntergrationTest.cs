using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using AirTrafficMonitoring.Boundary;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Integration.Test.ATM.Tests
{
    [TestFixture]
    class CalculatorIntergrationTest
    {

        private ISortingPlanesController _controller;
        private IMonitoredPlanes _monitoredPlanes;
        private List<ITrack> currentlist;
        private IDisplay _display;
        private List<ITrack> tracksToRemove;
        private ICalculator _calculator;
        private List<ITrack> othertracksToRemove;
        private ITrack track1;
        private ITrack track2;

        [SetUp]
        public void SetUp()
        {
            _monitoredPlanes = new MonitoredPlanes();
            currentlist = new List<ITrack>();
            _display = Substitute.For<IDisplay>();
            tracksToRemove = new List<ITrack>();
            _calculator = new Calculator();
            othertracksToRemove = new List<ITrack>();
            _controller = new SortingPlanesController(currentlist, _display, _monitoredPlanes, tracksToRemove, _calculator, othertracksToRemove);
        }

        [TestCase(100, 100, 10, 14.142135623730951)]
        [TestCase(500, 500, 20, 35.355339059327378)]
        [TestCase(-150, -150, 2, 106.06601717798213)]
        public void DetermineVelocityIsCorrect(int X, int Y, int Time, double Result)
        {
            track1 = new Track() { Tag = "ABC123", XCoordinate = 5000, YCoordinate = 5000, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00, 000) };
            track2 = new Track() { Tag = "ABC123", XCoordinate = 5000 + X, YCoordinate = 5000 + Y, Altitude = 1000, Timestamp = new DateTime(2018, 03, 05, 00, 00, 00 + Time, 000) };
            Assert.That(_calculator.DetermineVelocity(track1, track2), Is.EqualTo(Result));
        }

        [TestCase(10000, 10000, 10000, 90000, 0)]
        [TestCase(10000, 90000, 90000, 90000, 90)]
        [TestCase(10000, 90000, 10000, 90000, 180)]
        [TestCase(90000, 90000, 10000, 90000, 270)]

        public void DegreesIsCorrect(int x1, int y1, int x2, int y2, double result)
        {
            track1 = new Track() { Tag = "ABC123", XCoordinate = x1, YCoordinate = y1 };
            track2 = new Track() { Tag = "ABC123", XCoordinate = x2, YCoordinate = y2 };
            Assert.That(Math.Round(_calculator.Direction(track1, track2)), Is.EqualTo(result));
        }


    }
}
