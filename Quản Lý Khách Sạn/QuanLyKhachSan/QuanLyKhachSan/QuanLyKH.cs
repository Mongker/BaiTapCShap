using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyKhachSan
{
    public partial class QuanLyKH : Form
    {
        public static string con = "Data Source=DESKTOP-UCOQP8F;Initial Catalog=QuanLyKhachSan_Nhom5;Integrated Security=True";
        public QuanLyKH()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void Khachhang_load()
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from Khachhang", conn);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            cmd.Dispose();
            conn.Close();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            SqlCommand cmd = new SqlCommand("ThemKH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HOTEN", SqlDbType.NVarChar, 50).Value = txtTenKH.Text.Trim();
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 11).Value = txtSDT.Text.Trim();
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar, 100).Value = txtDiaChi.Text.Trim();
            cmd.Parameters.Add("@NGAYSINH", SqlDbType.NVarChar, 11).Value = Convert.ToDateTime(dateTimeInput1.Text.Trim());
            if (radNam.Checked == true)
            {
                cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar, 100).Value = radNam.Text.Trim();
            }
            else
            {
                cmd.Parameters.Add("@GIOITINH", SqlDbType.NVarChar, 100).Value = radNu.Text.Trim();
            }
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 50).Value = txtEmail.Text.Trim();
            cmd.Parameters.Add("@SOCMT", SqlDbType.NVarChar, 11).Value = txtCMT.Text.Trim();
            cmd.Parameters.Add("@QUOCTICH", SqlDbType.NVarChar, 11).Value = txtQuoctich.Text.Trim();
            int kq= cmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại");
            }
            cmd.Dispose();
            Khachhang_load();
            conn.Close();


        }

        private void QuanLyKH_Load(object sender, EventArgs e)
        {
            Khachhang_load();
        }
    }
}
