using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=C:\Users\User\Downloads\test c#.net-20250731T051208Z-1-001\test c#.net\test C#.net Treeroj Kullakitpaisarn\test.db;Version=3;";
        private SQLiteDataAdapter adapter = null!;
        private DataTable dt = null!;
        public Form1()
        {
            InitializeComponent();
            LoadAllData();
        }
        //โหลดข้อมูล
        private void LoadAllData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT " +
                        "PRODUCTID," +
                        "PRODUCTNAME," +
                        "PRODUCTTYPEID," +
                        "CASE WHEN PRODUCTSTATUS = 0 THEN 'ใช้งาน' " +
                        "WHEN PRODUCTSTATUS = 9 THEN 'ไม่ใช้งาน' " +
                        "ELSE 'อื่น ๆ' " +
                        "END AS PRODUCTSTATUS," +
                        "CREATEUSER," +
                        "CREATEDATE," +
                        "UPDATEUSER," +
                        "UPDATEDATE " +
                        "FROM PRODUCTMASTER";

                    adapter = new SQLiteDataAdapter(query, connection);
                    SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);

                    dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("ไม่มีข้อมูล");
                    }

                    if (dataGridView1.Columns.Contains("PRODUCTID"))
                    {
                        dataGridView1.Columns["PRODUCTID"].ReadOnly = true;
                    }
                    
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("โหลดข้อมูลผิดพลาด: " + ex.Message);
                }
            }
        }
        //ค้นหาข้อมูล
        private void btSelect_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSelect.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadAllData();
            }
            else
            {
                SearchData(searchTerm);
            }
        }
        private void SearchData(string searchTerm)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT " +
                        "PRODUCTID," +
                        "PRODUCTNAME," +
                        "PRODUCTTYPEID," +
                        "CASE WHEN PRODUCTSTATUS = 0 THEN 'ใช้งาน' " +
                        "WHEN PRODUCTSTATUS = 9 THEN 'ไม่ใช้งาน' " +
                        "ELSE 'อื่น ๆ' " +
                        "END AS PRODUCTSTATUS," +
                        "CREATEUSER," +
                        "CREATEDATE," +
                        "UPDATEUSER," +
                        "UPDATEDATE " +
                        "FROM PRODUCTMASTER " +
                        "WHERE PRODUCTID LIKE @searchTerm" +
                        " or PRODUCTNAME LIKE @searchTerm" +
                        " or PRODUCTTYPEID LIKE @searchTerm" +
                        " OR (CASE " +
                        "WHEN PRODUCTSTATUS = 0 THEN 'ใช้งาน' " +
                        "WHEN PRODUCTSTATUS = 9 THEN 'ไม่ใช้งาน' " +
                        "ELSE 'อื่น ๆ' " +
                        "END) = @searchTerm";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchTerm",  searchTerm );
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("ไม่พบข้อมูล");
                    }
                    if (dataGridView1.Columns.Contains("PRODUCTID"))
                    {
                        dataGridView1.Columns["PRODUCTID"].ReadOnly = true;
                    }
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ค้นหาข้อมูลผิดพลาด: " + ex.Message);
                }
            }
        }
        //เพิ่มข้อมูล
        private void btAdd_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    string productName = form2.CustomProductName;
                    string productTypeId = form2.CustomProductTypeId;
                    string productStatus = form2.CustomProductStatus;
                    string createUser = form2.CREATEUSER;
                    AddProductToDatabase(createUser, productName, productTypeId, productStatus);
                }
            }
        }
        //เช็ค PK ID 
        private int GetNextProductId()
        {
            int nextId = 1;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PRODUCTID FROM PRODUCTMASTER ORDER BY PRODUCTID";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<int> existingIds = new List<int>();
                    while (reader.Read())
                    {
                        existingIds.Add(reader.GetInt32(0));
                    }
                    for (int i = 1; i <= existingIds.Count + 1; i++)
                    {
                        if (!existingIds.Contains(i))
                        {
                            nextId = i;
                            break;
                        }
                    }
                }
            }
            return nextId;
        }
        //โหลดข้อมูลที่เพิ่ม
        private void AddProductToDatabase(string USER, string productName, string productTypeId, string productStatus)
        {
            int newProductId = GetNextProductId();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO PRODUCTMASTER (PRODUCTID,CREATEUSER,PRODUCTNAME, PRODUCTTYPEID, PRODUCTSTATUS,CREATEDATE) " +
                                   "VALUES (@PRODUCTID,@CREATEUSER,@productName, @productTypeId, @productStatus,@CREATEDATE)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PRODUCTID", newProductId);
                        command.Parameters.AddWithValue("@CREATEUSER", USER);
                        command.Parameters.AddWithValue("@productName", productName);
                        command.Parameters.AddWithValue("@productTypeId", productTypeId);
                        command.Parameters.AddWithValue("@productStatus", productStatus);
                        command.Parameters.AddWithValue("@CREATEDATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                    LoadAllData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เพิ่มข้อมูลผิดพลาด: " + ex.Message);
                }
            }
        }
        //แก้ไขข้อมูล
        private void btEdit_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string productId = selectedRow.Cells["PRODUCTID"].Value?.ToString() ?? string.Empty;
                string productName = selectedRow.Cells["PRODUCTNAME"].Value?.ToString() ?? string.Empty;
                string productTypeId = selectedRow.Cells["PRODUCTTYPEID"].Value?.ToString() ?? string.Empty;
                string productStatusText = selectedRow.Cells["PRODUCTSTATUS"].Value?.ToString() ?? string.Empty;
                string productStatusValue = productStatusText switch
                {
                    "ใช้งาน" => "0",
                    "ไม่ใช้งาน" => "9",
                    _ => ""
                };
                using (Form2 form2 = new Form2())
                {
                    form2.CustomProductName = productName;
                    form2.CustomProductTypeId = productTypeId;
                    form2.CustomProductStatus = productStatusValue;
                    form2.IsEdit = true;
                    if (form2.ShowDialog() == DialogResult.OK)
                    {
                        string updateUSER = form2.CREATEUSER;
                        string updatedProductName = form2.CustomProductName;
                        string updatedProductTypeId = form2.CustomProductTypeId;
                        string updatedProductStatus = form2.CustomProductStatus;
                        UpdateProductInDatabase(productId, updateUSER, updatedProductName, updatedProductTypeId, updatedProductStatus);
                    }
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่จะแก้ไข");
            }
        }
        //โหลดข้อมูลที่แก้ไข
        private void UpdateProductInDatabase(string productId, string updateUSER, string updatedProductName, string updatedProductTypeId, string updatedProductStatus)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE PRODUCTMASTER SET PRODUCTNAME = @updatedProductName, PRODUCTTYPEID = @updatedProductTypeId, PRODUCTSTATUS = @updatedProductStatus , UPDATEUSER = @updatedUSER , UPDATEDATE = @updatedDATE WHERE PRODUCTID = @productId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        command.Parameters.AddWithValue("@updatedUSER", updateUSER);
                        command.Parameters.AddWithValue("@updatedProductName", updatedProductName);
                        command.Parameters.AddWithValue("@updatedProductTypeId", updatedProductTypeId);
                        command.Parameters.AddWithValue("@updatedProductStatus", updatedProductStatus);
                        command.Parameters.AddWithValue("@updatedDATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("อัปเดตข้อมูลสำเร็จ");
                    LoadAllData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการอัปเดตข้อมูล: " + ex.Message);
                }
            }
        }
        //ลบข้อมูล
        private void btDelect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                string productId = selectedRow.Cells["PRODUCTID"].Value?.ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(productId))
                {
                    var confirmResult = MessageBox.Show("คุณต้องการลบข้อมูลนี้ใช่หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteProductFromDatabase(productId);
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ");
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกข้อมูลที่ต้องการลบ");
            }
        }
        private void DeleteProductFromDatabase(string productId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM PRODUCTMASTER WHERE PRODUCTID = @productId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("ลบข้อมูลสำเร็จ");
                            LoadAllData();
                        }
                        else
                        {
                            MessageBox.Show("ลบข้อมูลไม่สำเร็จ");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message);
                }
            }
        }
    }
}
