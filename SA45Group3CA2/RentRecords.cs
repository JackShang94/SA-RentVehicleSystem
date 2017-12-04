using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class RentRecords
    {
        private string recordsID;
        private string staffID;
        private string customerID;
        private DateTime rentalStartDate;
        private DateTime rentalEndDate;
        private DateTime actualReturnDate;
        private DateTime bookingDate;
        private string vehiclePlateNumber;

        public string RecordsID
        {
            get
            {
                return recordsID;
            }
            set
            {
                recordsID = value;
            }
        }
        public string StaffID
        {
            get
            {
                return staffID;
            }
            set
            {
                staffID = value;
            }
        }
        public string CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }
        public DateTime RentalStartDate
        {
            get
            {
                return rentalStartDate;
            }
            set
            {
                rentalStartDate = value;
            }
        }
        public DateTime RentalEndDate
        {
            get
            {
                return rentalEndDate;
            }
            set
            {
                rentalEndDate = value;
            }
        }
        public DateTime ActualReturnDate
        {
            get
            {
                return actualReturnDate;
            }
            set
            {
                actualReturnDate = value;
            }
        }
        public DateTime BookingDate
        {
            get
            {
                return bookingDate;
            }
            set
            {
                bookingDate = value;
            }
        }
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
    }
}
