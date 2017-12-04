using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Bus : Vehicle
    {
        private string television;
        private string maximumPassengers;

        public string Television
        {
            get
            {
                return television;
            }
            set
            {
                television = value;
            }
        }
    }
}
