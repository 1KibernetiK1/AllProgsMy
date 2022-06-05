namespace TableMaker
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
            this.myDataBaseDataSet = new TableMaker.MyDataBaseDataSet();
            this.myDataBaseDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturerTableAdapter = new TableMaker.MyDataBaseDataSetTableAdapters.ManufacturerTableAdapter();
            this.manufacturerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.manufacturerIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamesTableAdapter = new TableMaker.MyDataBaseDataSetTableAdapters.GamesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataBaseDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manufacturerIDDataGridViewTextBoxColumn,
            this.manufacturerNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.manufacturerBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(375, 438);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.manufacturerIDDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.gamesBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(393, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(404, 438);
            this.dataGridView2.TabIndex = 1;
            // 
            // myDataBaseDataSet
            // 
            this.myDataBaseDataSet.DataSetName = "MyDataBaseDataSet";
            this.myDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // myDataBaseDataSetBindingSource
            // 
            this.myDataBaseDataSetBindingSource.DataSource = this.myDataBaseDataSet;
            this.myDataBaseDataSetBindingSource.Position = 0;
            // 
            // manufacturerBindingSource
            // 
            this.manufacturerBindingSource.DataMember = "Manufacturer";
            this.manufacturerBindingSource.DataSource = this.myDataBaseDataSetBindingSource;
            // 
            // manufacturerTableAdapter
            // 
            this.manufacturerTableAdapter.ClearBeforeFill = true;
            // 
            // manufacturerIDDataGridViewTextBoxColumn
            // 
            this.manufacturerIDDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerID";
            this.manufacturerIDDataGridViewTextBoxColumn.HeaderText = "ManufacturerID";
            this.manufacturerIDDataGridViewTextBoxColumn.Name = "manufacturerIDDataGridViewTextBoxColumn";
            this.manufacturerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manufacturerNameDataGridViewTextBoxColumn
            // 
            this.manufacturerNameDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerName";
            this.manufacturerNameDataGridViewTextBoxColumn.HeaderText = "ManufacturerName";
            this.manufacturerNameDataGridViewTextBoxColumn.Name = "manufacturerNameDataGridViewTextBoxColumn";
            // 
            // manufacturerBindingSource1
            // 
            this.manufacturerBindingSource1.DataMember = "Manufacturer";
            this.manufacturerBindingSource1.DataSource = this.myDataBaseDataSetBindingSource;
            // 
            // manufacturerIDDataGridViewTextBoxColumn1
            // 
            this.manufacturerIDDataGridViewTextBoxColumn1.DataPropertyName = "ManufacturerID";
            this.manufacturerIDDataGridViewTextBoxColumn1.HeaderText = "ManufacturerID";
            this.manufacturerIDDataGridViewTextBoxColumn1.Name = "manufacturerIDDataGridViewTextBoxColumn1";
            this.manufacturerIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // gamesBindingSource
            // 
            this.gamesBindingSource.DataMember = "Games";
            this.gamesBindingSource.DataSource = this.myDataBaseDataSetBindingSource;
            // 
            // gamesTableAdapter
            // 
            this.gamesTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataBaseDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource myDataBaseDataSetBindingSource;
        private MyDataBaseDataSet myDataBaseDataSet;
        private System.Windows.Forms.BindingSource manufacturerBindingSource;
        private MyDataBaseDataSetTableAdapters.ManufacturerTableAdapter manufacturerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource manufacturerBindingSource1;
        private System.Windows.Forms.BindingSource gamesBindingSource;
        private MyDataBaseDataSetTableAdapters.GamesTableAdapter gamesTableAdapter;
    }
}

