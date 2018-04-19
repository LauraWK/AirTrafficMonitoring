using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AirTrafficMonitoring.Boundary
{
    class XMLSeperationEvent
    {
        public static void Save(SeperationEvent seperation, string path)
        {
            FileStream fs = new FileStream(path,FileMode.Create);

            XmlSerializer serializer = new XmlSerializer(typeof(SeperationEvent));

            serializer.Serialize(fs, seperation);
            fs.Close();
        }
    }
}
