using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class FileSistem
    {
        private List<Area> areas = new List<Area>();
        private Dictionary<int, bool> configuration = new Dictionary<int, bool>();

        public FileSistem() 
        {
            areas = LoadArea();
            configuration = LoadConfiguration();
        }

        public Dictionary<int, bool> Config 
        {
            get { return configuration; }
        }

        public List<Area> Areas 
        {
            get { return areas; }
        }

        public List<Area> LoadArea() 
        {
            List<Area> result = new List<Area>();

            try
            {
                DirectoryInfo d = new DirectoryInfo(@"Data");
                FileInfo[] files = d.GetFiles("*.csv");

                foreach (string line in System.IO.File.ReadAllLines(files[0].FullName))
                {
                    string[] data = line.Split(';');

                    Area area = new Area();
                    area.Name = data[0];
                    area.Code = data[1];

                    result.Add(area);
                }
            }
            catch (Exception e) { }
            

            return result;
        }

        public void SaveArea(List<Area> areas) 
        {
            try
            {
                DirectoryInfo d = new DirectoryInfo(@"Data");
                FileInfo[] files = d.GetFiles("*.csv");

                using (Stream stream = files[0].OpenWrite())
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        foreach (Area area in areas)
                        {
                            writer.WriteLine(area.Name + ";" + area.Code);
                        }
                    }
                }
            }
            catch (Exception e) { }
            
        }

        public Dictionary<int, bool> LoadConfiguration() 
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();

            try
            {

                DirectoryInfo d = new DirectoryInfo(@"Data");
                FileInfo[] files = d.GetFiles("*.csv");

                foreach (string line in System.IO.File.ReadAllLines(files[1].FullName))
                {
                    string[] data = line.Split(';');

                    result.Add(int.Parse(data[0]), data[1] == "1");
                }
            }
            catch (Exception e) { }

            return result;
        }
    }
}
