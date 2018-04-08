using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NUnit.Framework;
using NSubstitute;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    public class TrackFactoryTest
    {
        private TrackFactory uut;
        private ITransponderReceiver receiver;
        private ITrack track;

        [SetUp]
        public void Setup()
        {
            uut = new TrackFactory();
            receiver = Substitute.For<ITransponderReceiver>();
            track = Substitute.For<ITrack>();
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765","ATR423")]
        public void Tag_Is_Converted_Correctly(string transponderData, string wantedTag)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.Tag, Is.EqualTo(wantedTag));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", "39045")]
        public void XCoordinate_Is_Converted_Correctly(string transponderData, int wantedXC)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.XCoordinate, Is.EqualTo(wantedXC));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", "12932")]
        public void YCoordinate_Is_Converted_Correctly(string transponderData, int wantedYC)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.YCoordinate, Is.EqualTo(wantedYC));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", "14000")]
        public void Altitude_Is_Converted_Correctly(string transponderData, int wantedAltitude)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.Altitude, Is.EqualTo(wantedAltitude));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", "20180412123244765")]
        public void DateTime_Is_Converted_Correctly(string transponderData, DateTime wantedDateTime)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.Timestamp, Is.EqualTo(wantedDateTime));
        }


    }
}
