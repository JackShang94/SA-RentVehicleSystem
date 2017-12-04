using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Vehicle
    {
        private string vehiclePlateNumber;
        private string model;
        private string colour;
        private string engineSeriaNo;
        private string retialStatus;

        public string VehiclePlateNumber
        {
            get
            {
                return vehiclePlateNumber;
            }

            set
            {
                vehiclePlateNumber = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Colour
        {
            get
            {
                return colour;
            }

            set
            {
                colour = value;
            }
        }

        public string EngineSeriaNo
        {
            get
            {
                return engineSeriaNo;
            }

            set
            {
                engineSeriaNo = value;
            }
        }

        public string RetialStatus
        {
            get
            {
                return retialStatus;
            }

            set
            {
                retialStatus = value;
            }
        }
    }
}
