using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.Data; // ADO.NET
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProjectDbMySQL
{
    public class DataManager
    {
        // подключение к серверу
        private MySqlConnection _connection;
        // адаптер
        private MySqlDataAdapter _adapter;
        // локальное хранилище
        private DataSet _dset;

        // словарь соответсвия ТИПОВ:
        private Dictionary<Type, DbType> _dbTypes =
            new Dictionary<Type, DbType>()
        {
            { typeof(int), DbType.Int32 },
            { typeof(string), DbType.AnsiString }
        };

        public DataManager()
        {
            var strConnect = new MySqlConnectionStringBuilder();
            strConnect.Server = "127.0.0.1";
            strConnect.Database = "studentsdb";
            strConnect.UserID = "root";
            strConnect.Password = "";
            _connection = new MySqlConnection(strConnect.ConnectionString);
            _adapter = new MySqlDataAdapter();
            _dset = new DataSet();
        }

        public void AddGroup(string strGroup)
        {
            var tab = LoadTable("groups");
            DataRow row = tab.NewRow();
            row["Title"] = strGroup;
            tab.Rows.Add(row);
        }

        public string CreateInsertString(string tableName)
        {
            var table = LoadTable(tableName);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into ");
            sb.Append(tableName + " (");
            // пробегаем по столбцам - берём названия
            foreach (DataColumn c in table.Columns)
            {
                if (c.ColumnName != "Id")
                    sb.Append(c.ColumnName+",");
            }
            // удаляем последнюю запятую
            sb.Remove(sb.Length-1, 1);
            sb.Append(") Values (");
            foreach (DataColumn c in table.Columns)
            {
                if (c.ColumnName != "Id")
                    sb.Append("@"+c.ColumnName + ",");
            }
            // удаляем последнюю запятую
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            return sb.ToString();
        }

        public MySqlParameter[] GenerateParameters(string tableName)
        {
            var table = LoadTable(tableName);
            var list = new List<MySqlParameter>();
            foreach (DataColumn c in table.Columns)
            {
                if (c.ColumnName != "Id")
                {
                    var par = new MySqlParameter();
                    par.ParameterName = "@" + c.ColumnName;
                    par.SourceColumn = c.ColumnName;
                    par.DbType = _dbTypes[c.DataType];
                    list.Add(par);
                }
            }
            return list.ToArray<MySqlParameter>();
        }

        public DataTable LoadTable(string tableName)
        {
            DataTable table = _dset.Tables[tableName];
            if (table != null)
                return table;
            string sqlStr = $"select * from {tableName}";
            try
            {
                _connection.Open();
                _adapter.SelectCommand = 
                    new MySqlCommand(sqlStr, _connection);
                table = new DataTable(tableName);
                _adapter.Fill(table);
                //-------------------
                _connection.Close();
                _dset.Tables.Add(table);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return table;
        }

        // для отправки локальных изменений на сервер
        public void SyncServer(string tableName)
        {
            _connection.Open();
            string sqlStr = CreateInsertString(tableName);
            var insCom = new MySqlCommand(sqlStr, _connection);
            var parameters = GenerateParameters(tableName);
            insCom.Parameters.AddRange(parameters);
            //------------------------------------
            _adapter.InsertCommand = insCom;
            _adapter.Update(_dset.Tables["tableName"]);
            _connection.Close();
        }
    }
}
