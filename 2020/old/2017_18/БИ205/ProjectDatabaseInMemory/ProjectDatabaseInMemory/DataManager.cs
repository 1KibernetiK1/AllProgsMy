using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ProjectDatabaseInMemory
{
    class DataManager
    {
        private DataSet _dset;

        public BindingSource Master;
        public BindingSource Slave;

        public DataManager()
        {
            _dset = new DataSet("StudentsDb");
            CreateTableGroups();
            CreateTableStudents();
            CreateRelation();
            CreateBinding();
        }

        private void CreateBinding()
        {
            Master = new BindingSource();
            Master.DataSource = _dset.Tables["Groups"];
            Slave = new BindingSource();
            Slave.DataSource = Master;
            Slave.DataMember = "GroupStudent";
        }

        private void CreateRelation()
        {
            var parentC =
                _dset.Tables["Groups"]
                     .Columns["Id"];
            var childC =
                _dset.Tables["Students"]
                     .Columns["IdGroup"]; 
            var rel =
                new DataRelation("GroupStudent",parentC,childC);
            _dset.Relations.Add(rel);
        }

        public void AddGroup(string text)
        {
            var table = _dset.Tables["Groups"];

            string st = string.Format("Title like '{0}'", text);
            string st1 = $"Title like '{text}'";

            table.DefaultView.RowFilter = st1;
            int c = table.DefaultView.Count;
            table.DefaultView.RowFilter = "";
            if (c > 0) return;
            DataRow row = table.NewRow();
            row["Title"] = text;
            table.Rows.Add(row);
            
        }

        public DataView ViewGroups
        {
            get
            {
                return _dset
                    .Tables["Groups"]
                    .AsDataView();
            }
        }

        public DataView ViewStudents
        {
            get
            {
                return _dset
                    .Tables["Students"]
                    .AsDataView();
            }
        }

        public void MakeSomeData()
        {
            var table = _dset.Tables["Groups"];
            DataRow row = table.NewRow();
            row["Title"] = "БИ-205";
            table.Rows.Add(row);
            row = table.NewRow();
            row["Title"] = "ПИ-320";
            table.Rows.Add(row);
            //------------------
            table = _dset.Tables["Students"];
            row = table.NewRow();
            row["Name"] = "Вова";
            row["Lastname"] = "Приходько";
            row["IdGroup"] = 1;
            table.Rows.Add(row);
            row = table.NewRow();
            row["Name"] = "Вася";
            row["Lastname"] = "Васильев";
            row["IdGroup"] = 2;
            table.Rows.Add(row);
        }

        private void CreatePrimaryKey(DataTable table)
        {
            // создадим ключевой столбец
            var PK = new DataColumn("Id", typeof(int));
            // настройки столбца
            PK.AllowDBNull = false; // запрет пустых
            PK.Unique = true; // только уникальные
            PK.AutoIncrement = true; // авто инкр
            PK.AutoIncrementSeed = 1;
            // прикрепить столбец к таблице
            table.Columns.Add(PK);
            // таблице сказать что этот столбец ключевой
            table.PrimaryKey = new DataColumn[] { PK };
        }

        private void CreateTableGroups()
        {
            var table = new DataTable("Groups");
            CreatePrimaryKey(table);
            // далее - остальные столбцы
            table.Columns.Add("Title", typeof(string));
            // добавляем таблицу в ОБЩЕЕ ХРАНИЛИЩЕ
            _dset.Tables.Add(table);
        }

        private void CreateTableStudents()
        {
            var table = new DataTable("Students");
            // создадим ключевой столбец
            CreatePrimaryKey(table);
            // далее - остальные столбцы
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Lastname", typeof(string));
            table.Columns.Add("IdGroup", typeof(int));
            // добавляем таблицу в ОБЩЕЕ ХРАНИЛИЩЕ
            _dset.Tables.Add(table);
        }
    }
}
