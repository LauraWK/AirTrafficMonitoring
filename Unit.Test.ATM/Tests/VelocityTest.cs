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
        private Track faketrack1;
        private Track faketrack2;
        private Velocity uut;

        [SetUp]
        public void SetUp()
        {
            faketrack1 = new Track(){};
            faketrack2 = new Track(){};
            uut = new Velocity();
        }


    }
}
