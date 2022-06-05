namespace DZbdWF
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
            this.testDBDataSet1 = new DZbdWF.TestDBDataSet1();
            this.testDBDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoreStudentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scoreStudentTableAdapter = new DZbdWF.TestDBDataSet1TableAdapters.ScoreStudentTableAdapter();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsTableAdapter = new DZbdWF.TestDBDataSet1TableAdapters.StudentsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreStudentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataSource = this.testDBDataSet1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-5, -6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(803, 444);
            this.dataGridView1.TabIndex = 0;
            // 
            // testDBDataSet1
            // 
            this.testDBDataSet1.DataSetName = "TestDBDataSet1";
            this.testDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testDBDataSet1BindingSource
            // 
            this.testDBDataSet1BindingSource.DataSource = this.testDBDataSet1;
            this.testDBDataSet1BindingSource.Position = 0;
            // 
            // scoreStudentBindingSource
            // 
            this.scoreStudentBindingSource.DataMember = "ScoreStudent";
            this.scoreStudentBindingSource.DataSource = this.testDBDataSet1BindingSource;
            // 
            // scoreStudentTableAdapter
            // 
            this.scoreStudentTableAdapter.ClearBeforeFill = true;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataMember = "Students";
            this.studentsBindingSource.DataSource = this.testDBDataSet1BindingSource;
            // 
            // studentsTableAdapter
            // 
            this.studentsTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDBDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreStudentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource testDBDataSet1BindingSource;
        private TestDBDataSet1 testDBDataSet1;
        private System.Windows.Forms.BindingSource scoreStudentBindingSource;
        private TestDBDataSet1TableAdapters.ScoreStudentTableAdapter scoreStudentTableAdapter;
        private System.Windows.Forms.BindingSource studentsBindingSource;
        private TestDBDataSet1TableAdapters.StudentsTableAdapter studentsTableAdapter;
    }
}

