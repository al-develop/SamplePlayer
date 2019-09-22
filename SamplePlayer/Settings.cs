using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SamplePlayer
{
    public class Settings
    {
        private string path;
        public string Root { get; set; }

        public Settings()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "\\settings.xml";
        }

        public void Save()
        {
            using(var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var ser = new XmlSerializer(typeof(Settings));
                ser.Serialize(fs, path);
            }
        }

        public Settings Load()
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var ser = new XmlSerializer(typeof(Settings));
                Settings data = ser.Deserialize(fs) as Settings;
                return data;
            }
        }
    }
}
