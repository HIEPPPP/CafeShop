using CaffeShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeShop.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        private TableDAO() { }

        public static TableDAO Instance 
        { 
            get
            {
                if (instance == null) instance = new TableDAO();
                return instance;
            }
            private set => instance = value; 
        }

        public static int TableWith = 95;
        public static int TableHeight = 95;

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table> ();

            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetTableList");

            foreach (DataRow t in data.Rows)
            {
                Table tabel = new Table(t);
                tableList.Add(tabel);
            }

            return tableList;
        }
    }
}
