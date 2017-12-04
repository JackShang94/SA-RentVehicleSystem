using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Truck : Vehicle
    {
        private string numberOfWheels;
        private string mamximumCargo;

        public string NumberOfWheels
        {
            get {
                return numberOfWheels;
            }
            set {
                numberOfWheels = value;
            }
        }

        public string MamximumCargo
        {
            get {
                return mamximumCargo;
            }
            set
            {
                mamximumCargo = value;
            }
        }
    }
}
