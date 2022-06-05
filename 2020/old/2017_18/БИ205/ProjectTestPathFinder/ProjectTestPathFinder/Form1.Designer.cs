namespace ProjectTestPathFinder
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
            this.btnSetWall = new System.Windows.Forms.Button();
            this.btnEmpty = new System.Windows.Forms.Button();
            this.btnSetEnd = new System.Windows.Forms.Button();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.dataGridView1 = new ProjectTestPathFinder.FastDataGridView();
            this.btnFindPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetWall
            // 
            this.btnSetWall.Location = new System.Drawing.Point(12, 543);
            this.btnSetWall.Name = "btnSetWall";
            this.btnSetWall.Size = new System.Drawing.Size(75, 23);
            this.btnSetWall.TabIndex = 1;
            this.btnSetWall.Text = "Wall";
            this.btnSetWall.UseVisualStyleBackColor = true;
            this.btnSetWall.Click += new System.EventHandler(this.btnSetWall_Click);
            // 
            // btnEmpty
            // 
            this.btnEmpty.AutoEllipsis = true;
            this.btnEmpty.Location = new System.Drawing.Point(107, 543);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(75, 23);
            this.btnEmpty.TabIndex = 2;
            this.btnEmpty.Text = "Empty";
            this.btnEmpty.UseVisualStyleBackColor = true;
            this.btnEmpty.Click += new System.EventHandler(this.btnEmpty_Click);
            // 
            // btnSetEnd
            // 
            this.btnSetEnd.AutoEllipsis = true;
            this.btnSetEnd.Location = new System.Drawing.Point(369, 543);
            this.btnSetEnd.Name = "btnSetEnd";
            this.btnSetEnd.Size = new System.Drawing.Size(75, 23);
            this.btnSetEnd.TabIndex = 4;
            this.btnSetEnd.Text = "Set End";
            this.btnSetEnd.UseVisualStyleBackColor = true;
            this.btnSetEnd.Click += new System.EventHandler(this.btnSetEnd_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.AutoEllipsis = true;
            this.btnSetStart.Location = new System.Drawing.Point(274, 543);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(75, 23);
            this.btnSetStart.TabIndex = 3;
            this.btnSetStart.Text = "Set Start";
            this.btnSetStart.UseVisualStyleBackColor = true;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 506);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // btnFindPath
            // 
            this.btnFindPath.AutoEllipsis = true;
            this.btnFindPath.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnFindPath.Location = new System.Drawing.Point(587, 543);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(75, 23);
            this.btnFindPath.TabIndex = 5;
            this.btnFindPath.Text = "Find Path";
            this.btnFindPath.UseVisualStyleBackColor = true;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 606);
            this.Controls.Add(this.btnFindPath);
            this.Controls.Add(this.btnSetEnd);
            this.Controls.Add(this.btnSetStart);
            this.Controls.Add(this.btnEmpty);
            this.Controls.Add(this.btnSetWall);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastDataGridView dataGridView1;
        private System.Windows.Forms.Button btnSetWall;
        private System.Windows.Forms.Button btnEmpty;
        private System.Windows.Forms.Button btnSetEnd;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnFindPath;
    }
}

