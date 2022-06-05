using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class DataManger
    {
        DataSet _dset;
        MySqlDataAdapter _adapter;
        MySqlConnection _con;


        public DataManger()
        {
            var mySql = new MySqlConnectionStringBuilder();
            mySql.Server = "127.0.0.1";
            mySql.Password = "";
            mySql.UserID = "root";
            mySql.Database = "studentsdb";
            _con = new MySqlConnection(mySql.ConnectionString);
        }

        public DataTable LoadTable()
        {
            _con.Open();
            var adapter = new 
                MySqlDataAdapter("select * from groups", _con);
            var tab = new DataTable();
            adapter.Fill(tab);
            _con.Close();
            return tab;
        }
    }
}
