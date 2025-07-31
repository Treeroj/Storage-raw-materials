namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxUesr = new TextBox();
            textBoxProductName = new TextBox();
            textBoxProductTypeId = new TextBox();
            buttonAdd = new Button();
            buttonCancel = new Button();
            comboBoxStatus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxUesr
            // 
            textBoxUesr.Location = new Point(121, 45);
            textBoxUesr.MaxLength = 20;
            textBoxUesr.Name = "textBoxUesr";
            textBoxUesr.Size = new Size(188, 27);
            textBoxUesr.TabIndex = 0;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(121, 130);
            textBoxProductName.MaxLength = 20;
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(188, 27);
            textBoxProductName.TabIndex = 1;
            // 
            // textBoxProductTypeId
            // 
            textBoxProductTypeId.Location = new Point(121, 214);
            textBoxProductTypeId.MaxLength = 5;
            textBoxProductTypeId.Name = "textBoxProductTypeId";
            textBoxProductTypeId.Size = new Size(188, 27);
            textBoxProductTypeId.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(54, 392);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(298, 392);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(141, 310);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(151, 28);
            comboBoxStatus.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 22);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 7;
            label1.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 107);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 8;
            label2.Text = "Product Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(121, 191);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 9;
            label3.Text = "Product TypeID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(121, 287);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 10;
            label4.Text = "Product Status";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxStatus);
            Controls.Add(textBoxUesr);
            Controls.Add(buttonCancel);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxProductTypeId);
            Controls.Add(textBoxProductName);
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxUesr;
        private TextBox textBoxProductName;
        private TextBox textBoxProductTypeId;
        private Button buttonAdd;
        private Button buttonCancel;
        private ComboBox comboBoxStatus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}