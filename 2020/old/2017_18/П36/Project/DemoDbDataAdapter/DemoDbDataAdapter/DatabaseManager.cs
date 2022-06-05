using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---------------------------
using System.Data;
using System.Data.SqlClient; // Ms SQL
using System.Windows.Forms;

namespace DemoDbDataAdapter
{
    class DatabaseManager
    {
        // для соединения с сервером
        private SqlConnection _sqlConnect;
        // адаптер - данные загружать и отправлять
        private SqlDataAdapter _adapter;
        // строка подключения (настройки)
        private string _stConnect;
        // локальное хранилище
        private DataSet _dset;

        // 1) вручную создать связи
        // Primary Key указать
        // Relation
        // BindingSource

        // 2) использовать фильтры
        // DataTable


        public void Filter(int IdGenre)
        {
            DataTable tab = 
                _dset.Tables["Games"];
            tab.DefaultView.RowFilter = 
               string.Format("IdGenre = {0}", IdGenre);
        }

        public DataView Genres
        {
            get {
                return _dset
                    .Tables["Genres"]
                    .AsDataView();
            }
        }

        public DataView Games
        {
            get
            {
                return _dset
                    .Tables["Games"]
                    .DefaultView;
                    
            }
        }



        public DatabaseManager(string st)
        {
            _stConnect = st;
            _dset = new DataSet();
            _sqlConnect = new SqlConnection(st);
            _adapter = new SqlDataAdapter();
        }

        public void LoadTable(string tableName)
        {
            string stCom = "select * from "+tableName;
            DataTable tab = null;
            try
            {
                // 1) отркыли соединение
                _sqlConnect.Open();
                // 2) команда селект
                _adapter.SelectCommand = new SqlCommand(stCom, _sqlConnect);
                // 3) пустая таблица
                tab = new DataTable(tableName);
                // 4) данные с сервера заливаем в таблицу
                _adapter.Fill(tab);
                // 5) закрыли соединение
                _sqlConnect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // 6) добавили таблицу в лок хранилище
            _dset.Tables.Add(tab);


        }
    }
}
