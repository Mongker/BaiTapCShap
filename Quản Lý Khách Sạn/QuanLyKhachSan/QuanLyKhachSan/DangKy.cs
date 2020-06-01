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
using System.Text.RegularExpressions;

namespace QuanLyKhachSan
{   

    public partial class DangKy : Form
    {
        public static string con = "Data Source=DESKTOP-UCOQP8F;Initial Catalog=QuanLyKhachSan_Nhom5;Integrated Security=True";
        public DangKy()
        {
            InitializeComponent();
        }
        
        private void DangKy_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {   //truoc khi insert du lieu kiem tra xem textbox da nhap du lieu chua neu chua nhap dua ra thong bao
            //neu da nhap du lieu chuyen sang else
            //else kiem tra xem nhap du lieu email dung dinh dang chua neu dung dinh dang roi thi cho insert du lieu
            //neu chua dung dinh dang ko cho insert ding thoi dua ra thong bao cho nguoi dung
            if (txtNameDK.Text == "Full name" && txtEmailDK.Text == "Email" && txtPassDK.Text == "Password")
            {
                MessageBox.Show("Not be empty");
            }
            else {
                //bat su kien nhap email dung dinh dang someone.@gmail.com
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(txtEmailDK.Text, pattern))
                {
                    errorProvider1.Clear();
                    string p_namdk = txtNameDK.Text.Trim();
                    string p_emaildk = txtEmailDK.Text.Trim();
                    string p_passdk = txtPassDK.Text.Trim();
                    SqlConnection conn = new SqlConnection(con);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Register_Insert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = p_namdk;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = p_emaildk;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = p_passdk;
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show(" Đăng ký thành công");
                        DangNhap dn = new DangNhap();
                        dn.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại");
                    }
                    cmd.Dispose();
                    conn.Close();
                }
                else
                {
                    errorProvider1.SetError(this.txtEmailDK, "Please enter the correct email format !");
                }
                  
            }
        }
        private void txtNameDK_KeyPress(object sender, KeyPressEventArgs e)
        {
                //bat su kien chi cho nhap ki tu ko nhap so 
                e.Handled =!(e.KeyChar >= 65 && e.KeyChar <= 122 || (e.KeyChar ==8));
            
        }

        private void txtNameDK_Enter(object sender, EventArgs e)
        {
            if (txtNameDK.Text == "Full name")
            {
                txtNameDK.Text = "";
                txtNameDK.ForeColor = Color.Black;
            }
        }

        private void txtNameDK_Leave(object sender, EventArgs e)
        {
            if (txtNameDK.Text == "")
            {
                txtNameDK.Text = "Full name";
                txtNameDK.ForeColor = Color.Black;
            }
        }

        private void txtEmailDK_Enter(object sender, EventArgs e)
        {   
            //khi hien thi voi hidden Email kich chuot vao textbox thi o textbox rong cho phep nhap du lieu chu mau den
            if (txtEmailDK.Text == "Email")
            {
                txtEmailDK.Text = "";
                txtEmailDK.ForeColor = Color.Black;
            }
        }
        private void txtEmailDK_Leave(object sender, EventArgs e)
        {   
            //khi ko nhap chuyen chuot qua vi tri khac hien thi lai hidden la Email
            if (txtEmailDK.Text == "")
            {
                txtEmailDK.Text = "Email";
                txtEmailDK.ForeColor = Color.Black;
            }
        }

        private void txtPassDK_Enter(object sender, EventArgs e)
        {
            if (txtPassDK.Text == "Password")
            {
                txtPassDK.Text = "";
                txtPassDK.ForeColor = Color.Black;
            }
        }

        private void txtPassDK_Leave(object sender, EventArgs e)
        {
            if (txtPassDK.Text == "")
            {
                txtPassDK.Text = "Password";
                txtPassDK.ForeColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }
    }
}
