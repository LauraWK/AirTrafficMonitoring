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
        public class TestData
        {
            public DateTime wantedTimeStamp { get; set; }
            public string timeStampString { get; set; }
        }

        private static TestData[] _testData = new[]
        {
            new TestData()
            {
                wantedTimeStamp = new DateTime(2018, 04, 12, 12, 32, 44, 765),
                timeStampString = "20180412123244765"
                
            }
        };

        private TrackFactory uut;

        [SetUp]
        public void Setup()
        {
            uut = new TrackFactory();
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765","ATR423")]
        public void Tag_Is_Converted_Correctly(string transponderData, string wantedTag)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.Tag, Is.EqualTo(wantedTag));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", 39045)]
        public void XCoordinate_Is_Converted_Correctly(string transponderData, int wantedXC)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.XCoordinate, Is.EqualTo(wantedXC));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", 12932)]
        public void YCoordinate_Is_Converted_Correctly(string transponderData, int wantedYC)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.YCoordinate, Is.EqualTo(wantedYC));
        }

        [TestCase("ATR423;39045;12932;14000;20180412123244765", 14000)]
        public void Altitude_Is_Converted_Correctly(string transponderData, int wantedAltitude)
        {
            var result = uut.Create(transponderData);

            Assert.That(result.Altitude, Is.EqualTo(wantedAltitude));
        }

        
        [Test]
        public void DateTime_Is_Converted_Correctly([ValueSource(nameof(_testData))]TestData testData)
        {
            var result = uut.Create("ATR423;39045;12932;14000;20180412123244765");

            Assert.That(result.Timestamp, Is.EqualTo(testData.wantedTimeStamp));
        } 

    }


    
}
