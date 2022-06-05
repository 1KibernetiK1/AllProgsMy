using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//----------------
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDataSet
{
    /// <summary>
    /// Класс, инкапсулирующий
    /// механизмы для работы
    /// с ДАННЫМИ! (реляционными)
    /// </summary>
    public class DatabaseManager
    {
        private BindingSource _bsMaster;
        private BindingSource _bsSlave;

        public void Save(string fname)
        {
            _dset.WriteXml(fname+".xml");
        }

        public void Load(string fname)
        {
            _dset = new DataSet();
            _dset.ReadXml(fname + ".xml");
        }

        public void AddGroup(string title)
        {
            title = title.Trim();
            title = title.ToUpper();
            if (title[1] != '-')
            {
                title = title.Insert(1, "-");
            }
            // проверка группы (на присуствие)
            DataTable tab = _dset.Tables["Groups"];
            bool IsFound = false;
            foreach (DataRow r in tab.Rows)
            {
                string text = r["Title"].ToString();
                if (text == title)
                {
                    IsFound = true;
                    break;
                }
            }
            if (IsFound) return;
            //------------------------
            DataRow row = tab.NewRow();
            row["Title"] = title;
            tab.Rows.Add(row);
        }

        public void AddStudent(string name, 
                               string Lastname,
                               int idGroup)
        {
            DataTable tab = _dset.Tables["Students"];
            DataRow r = tab.NewRow();
            r["Name"] = name;
            r["Lastname"] = Lastname;
            r["IdGroup"] = idGroup;
            tab.Rows.Add(r);
        }

        public BindingSource BindGroups
        {
            get { return _bsMaster; }
        }

        public BindingSource BindStudents
        {
            get { return _bsSlave; }
        }

        public void CreateBinding()
        {
            _bsMaster = new BindingSource();
            _bsMaster.DataSource = _dset.Tables["Groups"];

            _bsSlave = new BindingSource();
            _bsSlave.DataSource = _bsMaster;
            _bsSlave.DataMember = "StudentsGroup";
        }


        /// <summary>
        ///  набор данных
        /// </summary>
        private DataSet _dset;

        public DataView Groups
        {
            get
            {
                return _dset
                    .Tables["Groups"]
                    .AsDataView();
            }
        }

        public DataView Students
        {
            get
            {
                return _dset
                    .Tables["Students"]
                    .AsDataView();
            }
        }


        public DatabaseManager()
        {
            _dset = new DataSet("DbStudents");
            // создать две таблицы
            CreateTableGroups();
            CreateTableStudents();
            // связываем!
            CreateRelation();
        }

        public void AddSomeData()
        {
            DataTable tab1 =
                _dset.Tables["Groups"];

            DataRow row = tab1.NewRow();
            row["Title"] = "П-36";
            tab1.Rows.Add(row);
            int idP36 = (int) row["Id"];
            //-----------------
            row = tab1.NewRow();
            row["Title"] = "П-27";
            tab1.Rows.Add(row);
            int idP27 = (int)row["Id"];
            //=========================
            DataTable tab2 = _dset
                .Tables["Students"];
            row = tab2.NewRow();
            row["Name"] = "Влад";
            row["Lastname"] = "Комельков";
            row["IdGroup"] = idP36;
            tab2.Rows.Add(row);
            //---------------------
            row = tab2.NewRow();
            row["Name"] = "Глеб";
            row["Lastname"] = "Завизенов";
            row["IdGroup"] = idP27;
            tab2.Rows.Add(row);
        }

        private void CreateRelation()
        {
            DataColumn parentColumn =
                _dset
                .Tables["Groups"]
                .Columns["Id"];
            //----------------------
            DataColumn childColumn =
                _dset
                .Tables["Students"]
                .Columns["IdGroup"];
            //----------------------
            _dset.Relations.Add("StudentsGroup",
                                parentColumn, 
                                childColumn);
        }

        private void CreateTableGroups()
        {
            // 1) создаём таблицу
            DataTable tab = new DataTable("Groups");
            CreatePrimaryKey(tab);
            //---------------------------------------
            // СТОЛБЕЦ с данными
            tab.Columns.Add("Title", typeof(string));
            // прикрепляем таблицу в хранилище
            // DataSet
            _dset.Tables.Add(tab);
        }

        private void CreatePrimaryKey(DataTable tab)
        {
            // 2) создаём ключевой столбец
            DataColumn PK = new DataColumn("Id", typeof(int));
            // 3) выставялем специальные свойства
            // запрещены пустые строки
            PK.AllowDBNull = false;
            // все знач д/б уникальные
            PK.Unique = true;
            // выставляем автоинкремент
            PK.AutoIncrement = true;
            PK.AutoIncrementSeed = 1;
            // 4) Указываем таблице, какой у неё ключ
            tab.Columns.Add(PK);
            tab.PrimaryKey = new DataColumn[] { PK };   
        }

        private void CreateTableStudents()
        {
            // 1) создаём таблицу
            DataTable tab = new DataTable("Students");
            CreatePrimaryKey(tab);
            //---------------------------------------
            // СТОЛБЕЦ с данными
            tab.Columns.Add("Name", typeof(string));
            tab.Columns.Add("Lastname", typeof(string));
            tab.Columns.Add("IdGroup", typeof(int));
            // прикрепляем таблицу в хранилище
            // DataSet
            _dset.Tables.Add(tab);
        }
    }
}
