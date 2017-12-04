using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Customer
    {
        private String customerId;
        private String customerName;
        private String phoneNumber;
        private String emailAddress;

        public string CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }

            set
            {
                emailAddress = value;
            }
        }
    }
}
