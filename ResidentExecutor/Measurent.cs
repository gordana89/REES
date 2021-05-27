using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class Measurent
    {
        public Measurent() 
        {
            Timestamp = DateTime.Now;
        }

        public Area Area { get; set; }
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }
    }
}
