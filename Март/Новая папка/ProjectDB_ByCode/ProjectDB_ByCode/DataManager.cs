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

        private Dictionary<Type, SqlDbType> _typeMap = 
            new Dictionary<Type, SqlDbType>
        {
            { typeof(int), SqlDbType.Int },
            { typeof(string), SqlDbType.NVarChar }
        };


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

                if (_dataSet.Tables[tableName] != null)
                {
                    _dataSet.Tables[tableName].Clear();
                }

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

        public void AddAcademicGroup(string title, int year)
        {
            var table = _dataSet.Tables[EnumTables.AcademicGroup.ToString()];
            DataRow row = table.NewRow();
            row["Name"] = title;
            row["Year"] = year;
            table.Rows.Add(row);
        }

        public void ChangeAcademicGroup(string id, string title, int year)
        {
            var table = _dataSet.Tables[EnumTables.AcademicGroup.ToString()];
            DataRow row = table
                .Rows
                .Cast<DataRow>()
                .Where(r => r.RowState != DataRowState.Deleted)
                .First(r => r["AcademicGroupId"].ToString() == id);

            row["Name"] = title;
            row["Year"] = year;
        }

        public void RemoveAcademicGroup(string selectedGroupId)
        {
            DataTable table = _dataSet.Tables[EnumTables.AcademicGroup.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string strGroupId = row["AcademicGroupId"].ToString();
                if (strGroupId == selectedGroupId)
                {
                    row.Delete();
                    break;
                }
            }
        }

        internal void AddStudentId(string text1, string text2, string selectedStudentId)
        {
            var table = _dataSet.Tables[EnumTables.AcademicGroup.ToString()];
            DataRow row = table.NewRow();
            row["Firstname"] = text1;
            row["Lastname"] = text2;
            table.Rows.Add(row);
        }

        internal void RemoveStudent(string selectedStudentId)
        {
            DataTable table = _dataSet.Tables[EnumTables.Student.ToString()];
            foreach (DataRow row in table.Rows)
            {
                string strGroupId = row["AcademicGroupId"].ToString();
                if (strGroupId == selectedStudentId)
                {
                    row.Delete();
                    break;
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

        public DataView GetTableView(EnumTables enumTable, string columnName)
        {
            string tableName = enumTable.ToString();

            var table = _dataSet.Tables[tableName];

            var tableView = new DataView(table, "", columnName, DataViewRowState.CurrentRows);

            return tableView;
        }


        private SqlCommand GetDeleteCommand(string tableName)
        {
            // @id - переменная для ADO .NET внутри запроса
            string strSqlText =
                $@"delete from dbo.[{tableName}] " +
                 $"where ({tableName}Id = @id)";

            var sqlDeleteCmd = new SqlCommand(strSqlText, _connection);
            var parameter = new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                SourceColumn = $"{tableName}Id",
            };
            sqlDeleteCmd.Parameters.Add(parameter);

            return sqlDeleteCmd;
        }

        private SqlCommand GetInsertCommand(string tableName)
        {
            var sb = new StringBuilder();
            var table = _dataSet.Tables[tableName];
            sb.Append($@"INSERT INTO dbo.[{tableName}] ");
            string strId = $"{tableName}Id";

            var columns = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .Select(c => c.ColumnName)
                .ToList();

            sb.Append("( [");
            sb.Append(string.Join("], [", columns) + "] ) ");

            sb.Append("VALUES ( @");
            sb.Append( string.Join(", @", columns )+ "); ");

            sb.Append($"SELECT {strId} From [{tableName}] ");
            sb.Append($"WHERE {strId} = SCOPE_IDENTITY()");

            var sqlCommand = new SqlCommand(sb.ToString(), _connection);
            sqlCommand.Parameters.AddRange(GetParameters(table).ToArray());

            return sqlCommand;
        }

        private List<SqlParameter> GetParameters(DataTable table)
        {
            string tableName = table.TableName;
            string strId = $"{tableName}Id";
            var columns = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .ToList();

            var list = new List<SqlParameter>();
            foreach (var c in columns)
            {
                var parameter = new SqlParameter()
                {
                    ParameterName = "@"+c.ColumnName,
                    SourceColumn = c.ColumnName,
                    SqlDbType = _typeMap[c.DataType]
                };
                list.Add(parameter);
            }

            return list;
        }

        private SqlCommand GetUpdateCommand(string tableName)
        {
            var sb = new StringBuilder();
            var table = _dataSet.Tables[tableName];
            sb.Append($@"UPDATE dbo.[{tableName}] ");
            string strId = $"{tableName}Id";
            var columns = table
                .Columns
                .Cast<DataColumn>()
                .Where(c => c.ColumnName != strId)
                .Select(c => $"[{c.ColumnName}] = @{c.ColumnName}" )
                .ToList();
            sb.Append("SET ");
            sb.Append(string.Join(", ", columns));
            sb.Append($" WHERE [{strId}] = @id");
            var sqlCommand = new SqlCommand(sb.ToString(), _connection);
            sqlCommand.Parameters.AddRange(GetParameters(table).ToArray());
            var parameter = new SqlParameter()
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                SourceColumn = $"{tableName}Id",
            };
            sqlCommand.Parameters.Add(parameter);
            return sqlCommand;
        }

        public bool SaveChanges(EnumTables enumTable)
        {
            bool isDone = false;
            try
            {
                _connection.Open();

                string tableName = enumTable.ToString();

                _adapter.DeleteCommand = GetDeleteCommand(tableName);
                _adapter.InsertCommand = GetInsertCommand(tableName);
                _adapter.UpdateCommand = GetUpdateCommand(tableName);

                _adapter.Update(_dataSet.Tables[tableName]);

                _connection.Close();
                isDone = true;
            }

            catch(SqlException e1)
            {
                if (e1
                    .Message
                    .StartsWith("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    MessageBox.Show("Попытка удаления записи для которой есть зависимости");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            return isDone;
        }
    }
}
