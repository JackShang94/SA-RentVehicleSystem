using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Car : Vehicle
    {
        private string carType;
        private string maximumSeats;

        public string CarType
        {
            get
            {
                return carType;
            }

            set
            {
                carType = value;
            }
        }

        public string MaximumSeats
        {
            get
            {
                return maximumSeats;
            }

            set
            {
                maximumSeats = value;
            }
        }
    }
}
