using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Boundary;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;
using TransponderReceiver;


namespace AirTrafficMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            //Det her er for at constructor-injecte SortingPlanesController
            IDisplay display = new Display();
            ILogFile logfile = new LogFile();
            IMonitoredPlanes monitor = new MonitoredPlanes();
            List<ITrack> currentlist = new List<ITrack>();
            List<ITrack> removelist = new List<ITrack>();
            List<ITrack> otherRemoveList = new List<ITrack>();
            SortingPlanesController sortingcontroller = new SortingPlanesController(currentlist, display, monitor, removelist, new Calculator(), otherRemoveList);

            //Det her er for at constructor-injecte TracksInAirspaceController
            IAirspace airspace = new Airspace();
            TracksInAirspaceController controllerlist = new TracksInAirspaceController(airspace,sortingcontroller);

            var controller = new ReceivedDataController(TransponderReceiverFactory.CreateTransponderDataReceiver(), controllerlist);

            controller.StartReceiving();
           
            Console.ReadKey();


          
        }
    }
}