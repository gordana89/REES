using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidentExecutor
{
    public class Area : ViewModelBase
    {
        private string name;
        private string code;
        

        public string Name 
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged(nameof(Code));
            }
        }
    }
}
