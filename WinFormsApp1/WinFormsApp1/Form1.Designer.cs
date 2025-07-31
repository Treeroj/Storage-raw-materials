namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            btSelect = new Button();
            textBoxSelect = new TextBox();
            dataGridView1 = new DataGridView();
            btAdd = new Button();
            btEdit = new Button();
            btDelect = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 25);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 0;
            // 
            // btSelect
            // 
            btSelect.Location = new Point(21, 21);
            btSelect.Name = "btSelect";
            btSelect.Size = new Size(94, 29);
            btSelect.TabIndex = 1;
            btSelect.Text = "ค้นหา";
            btSelect.UseVisualStyleBackColor = true;
            btSelect.Click += btSelect_Click;
            // 
            // textBoxSelect
            // 
            textBoxSelect.Location = new Point(121, 22);
            textBoxSelect.Name = "textBoxSelect";
            textBoxSelect.Size = new Size(276, 27);
            textBoxSelect.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1250, 500);
            dataGridView1.TabIndex = 3;
            // 
            // btAdd
            // 
            btAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btAdd.Location = new Point(977, 12);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(94, 29);
            btAdd.TabIndex = 4;
            btAdd.Text = "เพิ่มข้อมูล";
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Click += btAdd_Click;
            // 
            // btEdit
            // 
            btEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btEdit.Location = new Point(1077, 12);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(94, 29);
            btEdit.TabIndex = 5;
            btEdit.Text = "แก้ไข";
            btEdit.UseVisualStyleBackColor = true;
            btEdit.Click += btEdit_Click;
            // 
            // btDelect
            // 
            btDelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btDelect.Location = new Point(1177, 12);
            btDelect.Name = "btDelect";
            btDelect.Size = new Size(94, 29);
            btDelect.TabIndex = 6;
            btDelect.Text = "ลบข้อมูล";
            btDelect.UseVisualStyleBackColor = true;
            btDelect.Click += btDelect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1283, 568);
            Controls.Add(btDelect);
            Controls.Add(btEdit);
            Controls.Add(btAdd);
            Controls.Add(dataGridView1);
            Controls.Add(textBoxSelect);
            Controls.Add(btSelect);
            Controls.Add(label2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btSelect;
        private TextBox textBoxSelect;
        private DataGridView dataGridView1;
        private Button btAdd;
        private Button btEdit;
        private Button btDelect;
    }
}
