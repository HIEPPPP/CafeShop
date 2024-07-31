using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeShop.DAO
{
    internal class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }

            private set { instance  = value; }
        }

        private DataProvider()
        {

        }

        private string connectionString = @"Server=DESKTOP-8P7C3VC;Database=CafeShop;User ID=sa;Password=123123;TrustServerCertificate=True";

        public DataTable ExcuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if(parameters != null)
                {
                    string[] listParameters = query.Split(' ');
                    int i = 0;
                    foreach (var item in listParameters)
                    {
                        if(item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;                
        }

        public int ExcuteNonQuery(string query, object[] parameters = null)
        {
            int data;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listParameters = query.Split(' ');
                    int i = 0;
                    foreach (var item in listParameters)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public int ExcuteSacalarQuery(string query, object[] parameters = null)
        {
            int data;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    string[] listParameters = query.Split(' ');
                    int i = 0;
                    foreach (var item in listParameters)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
    }
}
