using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoOnDemandProjectDay1
{
    public class Username
    {
        string user = string.Empty;
        public bool CheckUser(string user, bool access)
        {
            
            if (user == string.Empty && access == false)
            {
                return false;
            }
            else if (user != string.Empty && access == true)
            {     
                return true;   
            }
            else if (user != string.Empty && access == false)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
