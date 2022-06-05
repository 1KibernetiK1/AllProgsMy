namespace Sql
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
            this.myDatabase2022DataSet = new Sql.MyDatabase2022DataSet();
            this.myDatabase2022DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDatabase2022DataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.academicGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academicGroupTableAdapter = new Sql.MyDatabase2022DataSetTableAdapters.AcademicGroupTableAdapter();
            this.academicGroupidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicGroupBindingSource)).BeginInit();
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(785, 426);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // myDatabase2022DataSet
            // 
            this.myDatabase2022DataSet.DataSetName = "MyDatabase2022DataSet";
            this.myDatabase2022DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // myDatabase2022DataSetBindingSource
            // 
            this.myDatabase2022DataSetBindingSource.DataSource = this.myDatabase2022DataSet;
            this.myDatabase2022DataSetBindingSource.Position = 0;
            // 
            // myDatabase2022DataSetBindingSource1
            // 
            this.myDatabase2022DataSetBindingSource1.DataSource = this.myDatabase2022DataSet;
            this.myDatabase2022DataSetBindingSource1.Position = 0;
            // 
            // academicGroupBindingSource
            // 
            this.academicGroupBindingSource.DataMember = "AcademicGroup";
            this.academicGroupBindingSource.DataSource = this.myDatabase2022DataSetBindingSource1;
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
            this.academicGroupidDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название группы";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Год поступления";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDatabase2022DataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicGroupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource myDatabase2022DataSetBindingSource;
        private MyDatabase2022DataSet myDatabase2022DataSet;
        private System.Windows.Forms.BindingSource myDatabase2022DataSetBindingSource1;
        private System.Windows.Forms.BindingSource academicGroupBindingSource;
        private MyDatabase2022DataSetTableAdapters.AcademicGroupTableAdapter academicGroupTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn academicGroupidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
    }
}

