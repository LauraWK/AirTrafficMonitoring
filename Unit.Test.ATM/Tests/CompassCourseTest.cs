using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Unit.Test.ATM.Tests
{
    [TestFixture]
    class CompassCourseTest
    {
        private ITrack fakeTrack1;
        private ITrack fakeTrack2;
        private CompassCourse uut;

        [SetUp]
        public void Setup()
        {
            uut = new CompassCourse();
        }

        [TestCase(10000, 10000, 10000, 90000, 0)]
        [TestCase(10000, 90000, 90000, 90000, 90)]
        [TestCase(10000, 90000, 10000, 90000, 180)]
        [TestCase(90000, 90000, 10000, 90000, 270)]

        public void DegreesIsCorrect(int x1, int y1, int x2, int y2, double result)
        {
            fakeTrack1 = new Track() { Tag = "ABC123", XCoordinate = x1, YCoordinate = y1};
            fakeTrack2 = new Track() { Tag = "ABC123", XCoordinate = x2, YCoordinate = y2};
            Assert.That(Math.Round(uut.Direction(fakeTrack1, fakeTrack2)),Is.EqualTo(result));

        }


    }
}
