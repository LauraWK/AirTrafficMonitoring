using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Boundary;
using TransponderReceiver;


namespace AirTrafficMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
                    
            var controller = new ControllerReceivedData(TransponderReceiverFactory.CreateTransponderDataReceiver());
                    
            controller.StartReceiving();
           
            Console.ReadKey();


          
        }
    }
}