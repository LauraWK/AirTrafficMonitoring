using AirTrafficMonitoring;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace Unit.Test.ATM
{
    [TestFixture]
    public class ControllerTest
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

        
    }
}
