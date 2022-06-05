using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//--------------------------
using System.Data; // ADO .NET
using System.Data.Sql; // Ms SQL Server
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectDB_ByCode
{
    public class DataManager
    {
        /// <summary>
        /// строка подключения
        /// </summary>
        protected string _connectionString;

        /// <summary>
        /// канал связи
        /// </summary>
        protected SqlConnection _connection;

        /// <summary>
        /// посредник - читать, обновлять данные
        /// </summary>
        protected SqlDataAdapter _adapter;

        /// <summary>
        /// локальное хранилище
        /// </summary>
        protected DataSet _dataSet;

        public DataManager(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _dataSet = new DataSet();
            _adapter = new SqlDataAdapter();
        }

        public void LoadTable(EnumTables enumTable)
        {
            try
            {
                string tableName = enumTable.ToString();

                // 1) Открываем канал связи
                _connection.Open();

                // 2) sql - запрос
                var command = new SqlCommand($"select * from {tableName}", _connection);

                // 3) запрос передадим адаптеру
                _adapter.SelectCommand = command;

                // 4) запрашиваем данные и сохраняем в локальный кэш
                _adapter.Fill(_dataSet, tableName);

                // Закрываем канал связи
                _connection.Close();
            }
            catch(Exception ex)
            {
                // писать в лог + 
                MessageBox.Show(ex.ToString());
            }
        }

        public void RemoveStudio(string selectedStudioId)
        {
            DataTable table = _dataSet.Tables[EnumTables.Games.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string strStudioId = row["StudioId"].ToString();
                if (strStudioId == selectedStudioId)
                {
                    row.Delete();
                    return;
                }
            }
        }

        public DataView GetTableView(EnumTables enumTable)
        {
            string tableName = enumTable.ToString();

            var tableView = _dataSet
                .Tables[tableName]
                .AsDataView();

            return tableView;
        }
    }
}
