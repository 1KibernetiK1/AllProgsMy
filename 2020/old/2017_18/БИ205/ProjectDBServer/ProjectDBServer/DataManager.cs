using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectDBServer
{
    class DataManager
    {
        private SqlConnection _sqlCon;
        private SqlDataAdapter _adapter;
        private DataSet _dset;
        private string _strCon;
        public DataManager(string _strCon)
        {
            _dset = new DataSet();
            _adapter = new SqlDataAdapter();
            _sqlCon = new SqlConnection(_strCon);

        }
        public void LoadBrands()
        {
            try
            {
                _sqlCon.Open();
                _adapter.SelectCommand = new SqlCommand("select * from Brands",_sqlCon);
                var table = new DataTable("Brands");
                _adapter.Fill(table);
                _dset.Tables.Add(table);
                _sqlCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void AddBrand(string txt)
        {
            var table = _dset.Tables["Brands"];
            if (table == null) return;
            DataRow row = table.NewRow();
            row["Title"] = txt;
            table.Rows.Add(row);
        }

        public void SynchonizeBrands()
        {
            string com = "Insert Into Brands(Title) Values(@Title)";
            _adapter.InsertCommand = new SqlCommand(com,_sqlCon);
            var p = new SqlParameter();
            p.ParameterName = "@Title";
            p.SourceColumn = "Title";
            p.SqlDbType = SqlDbType.VarChar;
            _adapter.InsertCommand.Parameters.Add(p);
            var table = _dset.Tables["Brands"];
            try
            {
                _sqlCon.Open();
                _adapter.Update(table);
                _sqlCon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Синхронизация с сервером,
        /// получение новых Id
        /// СПОСОБ II-й
        /// </summary>
        public void SyncBrandsV2()
        { // идея - после отправки на сервер
          // таблицу ЦЕЛИКОМ обновить
            SynchonizeBrands();
            var table = _dset.Tables["Brands"];
            table.Clear();
            _dset.Tables.Remove(table);
            LoadBrands();
        }

        /// <summary>
        /// Синхронизация с сервером,
        /// получение новых Id
        /// СПОСОБ III-й
        /// </summary>
        public void SyncBrandsV3()
        {
            string com = "Insert Into Brands(Title) Values(@Title); ";
            com += "Select Id From dbo.Brands Where " 
                +  "Id = SCOPE_IDENTITY();";
            _adapter.InsertCommand = new SqlCommand(com, _sqlCon);
            var p = new SqlParameter();
            p.ParameterName = "@Title";
            p.SourceColumn = "Title";
            p.SqlDbType = SqlDbType.VarChar;
            _adapter.InsertCommand.Parameters.Add(p);
            var table = _dset.Tables["Brands"];
            try
            {
                _sqlCon.Open();
                var changes = table.GetChanges(DataRowState.Added);
                _adapter.Update(changes);
                _sqlCon.Close();
                // Id из таблицы changes переносим в исходную
                // table.Merge(changes);

                foreach (DataRow row in changes.Rows)
                {
                    string title = row["Title"].ToString();
                    int Id = (int) row["Id"];
                    string filter = $"Title like '{title}'";
                    DataRow srcRow =
                        table.Select(filter, "Title")
                        .FirstOrDefault();
                    srcRow["Id"] = Id;
                }
                table.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         * CREATE PROCEDURE [dbo].[InsertBrand]
	            @Title varchar(50),
	            @Id int OUT
            AS
	            INSERT INTO Brands (Title) VALUES(@Title)
	            SET @Id = SCOPE_IDENTITY()
         * */
        /// <summary>
        /// Синхронизация с сервером,
        /// получение новых Id
        /// СПОСОБ IV-й
        /// </summary>
        public void SyncBransV4()
        { // вызов хранимой процедуры
            string com = "Insert Into Brands(Title) Values(@Title)";

            _adapter.InsertCommand = 
                new SqlCommand("dbo.InsertBrand", _sqlCon);
            _adapter.InsertCommand.CommandType = 
                CommandType.StoredProcedure;

            var p = new SqlParameter();
            p.ParameterName = "@Title";
            p.SourceColumn = "Title";
            p.SqlDbType = SqlDbType.VarChar;
            _adapter.InsertCommand.Parameters.Add(p);
            //---------------------------------------
            var p2 = new SqlParameter();
            p2.ParameterName = "@Id";
            p2.SourceColumn = "Id";
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Output;
            _adapter.InsertCommand.Parameters.Add(p2);


            var table = _dset.Tables["Brands"];
            try
            {
                _sqlCon.Open();
                _adapter.Update(table);
                _sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataView ViewBrands
        {
            get
            {
                var table = _dset.Tables["Brands"];
                if (table == null) return null;
                return table.AsDataView();
            }
        }
    }
}
