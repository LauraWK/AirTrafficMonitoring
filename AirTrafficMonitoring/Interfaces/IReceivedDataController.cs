using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace AirTrafficMonitoring.Interfaces
{
    public interface IReceivedDataController
    {
        void StartReceiving();
        void DataReady(object sender, RawTransponderDataEventArgs e);
    }
}
