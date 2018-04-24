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
            MonitoredPlanes monitor = new MonitoredPlanes();
            IMonitoredPlanes sepevent = new SeperationEvent(monitor,display, logfile);
            List<ITrack> currentlist = new List<ITrack>();
            List<ITrack> removelist = new List<ITrack>();
            SortingPlanesController sortingcontroller = new SortingPlanesController(currentlist, display, monitor, sepevent, removelist, new Calculator());

            //Det her er for at constructor-injecte TracksInAirspaceController
            IAirspace airspace = new Airspace();
            TracksInAirspaceController controllerlist = new TracksInAirspaceController(airspace,sortingcontroller);

            var controller = new ReceivedDataController(TransponderReceiverFactory.CreateTransponderDataReceiver(), controllerlist);

            controller.StartReceiving();
           
            Console.ReadKey();


          
        }
    }
}