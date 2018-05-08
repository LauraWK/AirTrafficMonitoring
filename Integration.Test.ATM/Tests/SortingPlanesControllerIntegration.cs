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
using TransponderReceiver;

namespace Integration.Test.ATM.Tests
{
    [TestFixture()]
    class SortingPlanesControllerIntegration
    {
        private TracksInAirspaceController _TIAC;
        private ICalculator _calculator;
        private IMonitoredPlanes _monitoredPlanes;
        private ISeperationEvent _seperationEvent;
        private IAirspace _airspace;
        private SortingPlanesController _sortingPlanesController;
        private ITrack track1;
        private ITrack track2;
        private List<ITrack> _list;
        private List<ITrack> _list2;
        private List<ITrack> _list3;
        private IDisplay _display;


        [SetUp]
        public void SetUp()
        {
            _calculator = Substitute.For<ICalculator>();
            _monitoredPlanes = Substitute.For<IMonitoredPlanes>();
            _seperationEvent = Substitute.For<ISeperationEvent>();
            _display = Substitute.For<IDisplay>();
            _airspace = new Airspace();
            track1 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 90000,
                Altitude = 10000,
                CompassCourse = 180
                
            };
            track2 = new Track()
            {
                Tag = "ABC123",
                XCoordinate = 10000,
                YCoordinate = 90000,
                Altitude = 10000,
                CompassCourse = 180
            };
            _list = new List<ITrack>();
            _list2 = new List<ITrack>();
            _list3 = new List<ITrack>();

            _sortingPlanesController = new SortingPlanesController(_list,_display,_monitoredPlanes,_list2,_calculator,_list3);
            _TIAC = new TracksInAirspaceController(_airspace,_sortingPlanesController);
        }

        [Test]
        public void CalculateCompassCourse()
        {
            _TIAC.AddToList(track1);
            _TIAC.AddToList(track2);
            _sortingPlanesController.MatchTracks(track1);
            _sortingPlanesController.MatchTracks(track2);
            _calculator.Received().Direction(track1,track2);
        }
        [Test]
        public void CalculateVelocity()
        {
            _TIAC.AddToList(track1);
            _TIAC.AddToList(track2);
            _sortingPlanesController.MatchTracks(track1);
            _sortingPlanesController.MatchTracks(track2);
            _calculator.Received().DetermineVelocity(track1, track2);
        }

    }
}
