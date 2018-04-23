using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Boundary;
using TransponderReceiver;


namespace AirTrafficMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
                    ControllerList controllerlist = new ControllerList();
            var controller = new ControllerReceivedData(TransponderReceiverFactory.CreateTransponderDataReceiver(), controllerlist);
                    
            controller.StartReceiving();
           
            Console.ReadKey();


          
        }
    }
}