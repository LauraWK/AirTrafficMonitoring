using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class ControllerReceivedData
    {

        private ITransponderReceiver _reciever;
        public ControllerReceivedData(ITransponderReceiver reciever)
        {
            _reciever = reciever;
        }

        public void StartReceiving()
        {
            
            _reciever.TransponderDataReady += DataReady; //+= betyder man hækler en event på en eventhandler

        }

        public void DataReady(object sender, RawTransponderDataEventArgs e)
        {
            var TF = new TrackFactory();
            var myList = e.TransponderData;

            foreach (var item in myList)
            {
                var result = TF.Create(item);
                Console.WriteLine("Tag: " + result.Tag + " XCoordinate: " + result.XCoordinate + " YCoordinate: " + result.YCoordinate + " Altitude: " + result.Altitude + " Timestamp: " + result.Timestamp);

            }
        }
    }
}
