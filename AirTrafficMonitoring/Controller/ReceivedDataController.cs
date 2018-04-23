using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Controller;
using AirTrafficMonitoring.Domain;
using TransponderReceiver;

namespace AirTrafficMonitoring
{
    public class ReceivedDataController
    {

        private ITransponderReceiver _reciever;
        private TracksInAirspaceController _airspaceController;
        public ReceivedDataController(ITransponderReceiver reciever, TracksInAirspaceController airspaceController)
        {
            _reciever = reciever;
            _airspaceController = airspaceController;

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
                var track = TF.Create(item);
                _airspaceController.AddToList(track);
            }

           
            
        }
    }
}
