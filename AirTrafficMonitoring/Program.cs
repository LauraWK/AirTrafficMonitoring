using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var Reciver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            
            Reciver.TransponderDataReady += Reciver_TransponderDataReady; //+= betyder man hækler en event på en eventhandler

  

            Console.ReadKey();
        }
        // Event
        private static void Reciver_TransponderDataReady(object sender, RawTransponderDataEventArgs e) // sender og e er argumnter
        {
            var TF = new TrackFactory();
            var myList = e.TransponderData;
            
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            foreach (var item in myList)
            {
                TF.Create(item);
            }
            
        }
    }
}
