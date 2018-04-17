using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
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
         //   var velocityobject = new Velocity();
          //  var velocitylist = new List<ITrack>();

            var myList = e.TransponderData;

            foreach (var item in myList)
            {
                var track = TF.Create(item);
          //      velocitylist.Add(track);
             
          //      var airspace = new Airspace(track);
            }

           // var velocity = velocityobject.DetermineVelocity(velocitylist[1], velocitylist[0]);
            
        }
    }
}
