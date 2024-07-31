using CaffeShop.DAO;
using CaffeShop.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaffeShop
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }

        #region Methods

        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (var table in tableList)
            {
                Button btn = new Button();
                btn.Text = table.Name + '\n' + '\n' + table.Status;
                btn.Width = TableDAO.TableWith;
                btn.Height = TableDAO.TableHeight;

                // Tag kiểu dữ liệu là object
                btn.Tag = table;

                btn.Click += Btn_Click;

                if (table.Status == "Trống")
                {
                    btn.BackColor = Color.Green;
                } else btn.BackColor = Color.Red;

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {

        }

        #endregion



        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = (sender as Table).Id;
            ShowBill(tableID);
        }

        private void mnsProfile_Click(object sender, EventArgs e)
        {
            AccountProfile account = new AccountProfile();
            account.ShowDialog();
        }

        private void mnsLogout_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();   
            fAdmin.ShowDialog();
        }
        #endregion  
    }
}
