using Entity;
using Interfaces;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TableRepo : ITableRepo
    {
        DatabaseConnectionClass dcc;
        public TableRepo()
        {
            dcc = new DatabaseConnectionClass();
        }


        public bool InsertTable(Table table)
        {
            string query = "INSERT into Tables VALUES ('" + table.TableId + "', '" + table.NumberOfSeats + "','" + table.Status + "')";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool DeleteTable(Table table)
        {
            string query = "DELETE from Tables WHERE TableId = '" + table.TableId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool UpdateTable(Table table)
        {
            string query = "UPDATE Tables SET NoOfSeats ='" + table.NumberOfSeats + "',Status='" + table.Status + "' WHERE TableId = '" + table.TableId + "'";
            try
            {
                dcc.ConnectWithDB();
                int n = dcc.ExecuteSQL(query);
                dcc.CloseConnection();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }


        public Table GetTable(int tableId)
        {
            Table table = null;
            string query = "SELECT * from Tables WHERE TableId = " + tableId + "";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                table = new Table();
                table.TableId = Convert.ToInt32(sdr["TableId"].ToString());
                table.NumberOfSeats = Convert.ToInt32(sdr["NumberOfSeats"].ToString());
                table.Status = Convert.ToInt32(sdr["Status"].ToString());
            }

            dcc.CloseConnection();
            return table;
        }

        public List<Table> GetAllTables()
        {
            List<Table> listOfTable = new List<Table>();
            string query = "SELECT * from Tables";

            dcc.ConnectWithDB();
            SqlDataReader sdr = dcc.GetData(query);

            while (sdr.Read())
            {
                Table table = new Table();
                table.TableId = Convert.ToInt32(sdr["TableId"].ToString());
                table.NumberOfSeats = Convert.ToInt32(sdr["NoOfSeats"].ToString());
                table.Status = Convert.ToInt32(sdr["Status"].ToString());
                listOfTable.Add(table);
            }

            dcc.CloseConnection();

            return listOfTable;
        }

        


    }
}
