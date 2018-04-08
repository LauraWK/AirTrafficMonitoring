using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    class RecieverTest
    {
        private ITransponderReceiver receiver;
        private ITrack track;
        private ITransponderReceiver uut;

        [SetUp]
        public void Setup()
        {
            receiver = Substitute.For<ITransponderReceiver>();
            track = Substitute.For<ITrack>();
            
        }

        [Test]
        public 
    }
}
