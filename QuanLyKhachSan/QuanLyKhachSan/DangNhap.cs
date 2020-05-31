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
    public partial class DangNhap : Form
    {
        public static string con = "Data Source=DESKTOP-LRPVL0F;Initial Catalog=QuanLyKhachSan_Nhom5;Integrated Security=True";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
           
            txtPass.Text = "Password";
            txtEmail.Text = "Email";
        }
        private void txtPass_Click(object sender, EventArgs e)
        {
            this.txtPass.PasswordChar = '*';
            txtPass.Text = "";
            txtPass.ForeColor = Color.Black;
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtEmail.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangKy frm = new DangKy();
            frm.Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Text;
            if (txtEmail.Text == "Email" && txtPass.Text == "Password")
            {
                MessageBox.Show("Not be empty");
            }
            else
            {
                if (Login(email, password))
                {
                    Form1 f = new Form1();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
                }
            }
        }
        bool Login(string email, string password)
        {
            return AccountDAO.Instance.Login(email, password);
        }

        private void radHienthi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //khi ko nhap chuyen chuot qua vi tri khac hien thi lai hidden la Email
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {

            //khi hien thi voi hidden Email kich chuot vao textbox thi o textbox rong cho phep nhap du lieu chu mau den
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Password";
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
            }
        }
    }
}
