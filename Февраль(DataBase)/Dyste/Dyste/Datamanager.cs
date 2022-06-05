using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dyste
{
    public class Datamanager
    {
        protected string _connectionString;
        protected SqlConnection _connection;
        protected SqlDataAdapter _adapter;
        protected DataSet _dataSet;

        public Datamanager(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _dataSet = new DataSet();
            _adapter = new SqlDataAdapter();
        }

        public void LoadTableGroups()
        {
            try
            {
                _connection.Open();

                var command = new SqlCommand("select* from AcademicGroup", _connection);

                _adapter.SelectCommand = command;

                _adapter.Fill(_dataSet, "AcademicGroup");

                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
         
        }

        public void GetTableGroupsView()
        {
            var tableView = _dataSet.Tables["AcademicGroup"].AsDataView();

            return tableView;
        }
    }
}
