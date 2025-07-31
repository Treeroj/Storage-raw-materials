using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public string CustomProductName { get; set; } = string.Empty;
        public string CustomProductTypeId { get; set; } = string.Empty;
        public string CustomProductStatus { get; set; } = string.Empty;
        public string CREATEUSER { get; set; } = string.Empty;
        public bool IsEdit { get; set; } = false;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBoxStatus.DisplayMember = "Key";
            comboBoxStatus.ValueMember = "Value";
            comboBoxStatus.Items.Clear();

            comboBoxStatus.Items.Add(new KeyValuePair<string, int>("ใช้งาน", 0));
            comboBoxStatus.Items.Add(new KeyValuePair<string, int>("ไม่ใช้งาน", 9));
            comboBoxStatus.SelectedValue = int.TryParse(CustomProductStatus, out int value) ? value : -1;
            if (IsEdit)
            {
                textBoxUesr.Clear();
                textBoxProductName.Text = CustomProductName;
                textBoxProductTypeId.Text = CustomProductTypeId;

                if (int.TryParse(CustomProductStatus, out int statusValue))
                {
                    foreach (KeyValuePair<string, int> item in comboBoxStatus.Items)
                    {
                        if (item.Value == statusValue)
                        {
                            comboBoxStatus.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                textBoxUesr.Clear();
                textBoxProductName.Clear();
                textBoxProductTypeId.Clear();
                comboBoxStatus.SelectedIndex = 0;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            CREATEUSER = textBoxUesr.Text.Trim();
            CustomProductName = textBoxProductName.Text.Trim();
            CustomProductTypeId = textBoxProductTypeId.Text.Trim();

            if (comboBoxStatus.SelectedItem is KeyValuePair<string, int> selectedStatus)
            {
                CustomProductStatus = selectedStatus.Value.ToString();
            }
            else
            {
                CustomProductStatus = string.Empty;
            }
            if (IsInputValid())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน");
            }
        }
        private bool IsInputValid()
        {
            return !string.IsNullOrEmpty(CREATEUSER) &&
                   !string.IsNullOrEmpty(CustomProductName) &&
                   !string.IsNullOrEmpty(CustomProductTypeId) &&
                   !string.IsNullOrEmpty(CustomProductStatus);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
