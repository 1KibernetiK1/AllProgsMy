namespace Sql2TableRelation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.myDatabase2022DataSet = new Sql2TableRelation.MyDatabase2022DataSet();
            this.academicGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicGroupTableAdapter = new Sql2TableRelation.MyDatabase2022DataSetTableAdapters.AcademicGroupTableAdapter();
            this.academicGroupidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myDatabase2022DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter = new Sql2TableRelation.MyDatabase2022DataSetTableAdapters.StudentTableAdapter();
            this.srudentIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middleNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.academicGroupidDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.academicGroupidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.academicGroupBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(67, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(351, 365);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srudentIdDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.middleNameDataGridViewTextBoxColumn,
            this.secondNameDataGridViewTextBoxColumn,
            this.academicGroupidDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.studentBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(486, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(549, 365);
            this.dataGridView2.TabIndex = 1;
            // 
            // myDatabase2022DataSet
            // 
            this.myDatabase2022DataSet.DataSetName = "MyDatabase2022DataSet";
            this.myDatabase2022DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // academicGroupBindingSource
            // 
            this.academicGroupBindingSource.DataMember = "AcademicGroup";
            this.academicGroupBindingSource.DataSource = this.myDatabase2022DataSet;
            // 
            // academicGroupTableAdapter
            // 
            this.academicGroupTableAdapter.ClearBeforeFill = true;
            // 
            // academicGroupidDataGridViewTextBoxColumn
            // 
            this.academicGroupidDataGridViewTextBoxColumn.DataPropertyName = "AcademicGroupid";
            this.academicGroupidDataGridViewTextBoxColumn.HeaderText = "AcademicGroupid";
            this.academicGroupidDataGridViewTextBoxColumn.Name = "academicGroupidDataGridViewTextBoxColumn";
            this.academicGroupidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // myDatabase2022DataSetBindingSource
            // 
            this.myDatabase2022DataSetBindingSource.DataSource = this.myDatabase2022DataSet;
            this.myDatabase2022DataSetBindingSource.Position = 0;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.myDatabase2022DataSetBindingSource;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // srudentIdDataGridViewTextBoxColumn
            // 
            this.srudentIdDataGridViewTextBoxColumn.DataPropertyName = "SrudentId";
            this.srudentIdDataGridViewTextBoxColumn.HeaderText = "SrudentId";
            this.srudentIdDataGridViewTextBoxColumn.Name = "srudentIdDataGridViewTextBoxColumn";
            this.srudentIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            this.middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.HeaderText = "MiddleName";
            this.middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            // 
            // secondNameDataGridViewTextBoxColumn
            // 
            this.secondNameDataGridViewTextBoxColumn.DataPropertyName = "SecondName";
            this.secondNameDataGridViewTextBoxColumn.HeaderText = "SecondName";
            this.secondNameDataGridViewTextBoxColumn.Name = "secondNameDataGridViewTextBoxColumn";
            // 
            // academicGroupidDataGridViewTextBoxColumn1
            // 
            this.academicGroupidDataGridViewTextBoxColumn1.DataPropertyName = "AcademicGroupid";
            this.academicGroupidDataGridViewTextBoxColumn1.HeaderText = "AcademicGroupid";
            this.academicGroupidDataGridViewTextBoxColumn1.Name = "academicGroupidDataGridViewTextBoxColumn1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private MyDatabase2022DataSet myDatabase2022DataSet;
        private System.Windows.Forms.BindingSource academicGroupBindingSource;
        private MyDatabase2022DataSetTableAdapters.AcademicGroupTableAdapter academicGroupTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn academicGroupidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource myDatabase2022DataSetBindingSource;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private MyDatabase2022DataSetTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn srudentIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn academicGroupidDataGridViewTextBoxColumn1;
    }
}

