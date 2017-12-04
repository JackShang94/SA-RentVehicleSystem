using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class Staff
    {
        private string staffID;
        private string staffName;
        private string phoneNumber;
        private string roles;

        public string StaffID
        {
            get {
                return staffID;
            }
            set
            {
                staffID = value;
            }
        }

        public string StaffName
        {
            get
            {
              return  staffName;
            }
            set
            {
                staffName = value;
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

        public string Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
            }
        }
    }
}
