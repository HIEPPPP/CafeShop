using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeShop.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        { 
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            } 
            set => instance = value; 
        }

        private BillDAO()
        {
            
        }
    }
}
