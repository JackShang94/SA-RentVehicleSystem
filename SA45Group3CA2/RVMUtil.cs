using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SA45Group3CA2
{
    class RVMUtil
    {
        public static bool isEmpty(String s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            else
                return false;
        }

        public static bool isEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
