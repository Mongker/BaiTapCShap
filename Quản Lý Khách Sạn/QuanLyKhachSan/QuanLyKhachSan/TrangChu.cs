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
    public partial class Form1 :DevComponents.DotNetBar.Office2007RibbonForm
    {
        public static string con = "Data Source=DESKTOP-UCOQP8F;Initial Catalog=QuanLyKhachSan_Nhom5;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }


       
        private void buttonItem15_Click(object sender, EventArgs e)
        {
            QuanLyKH kh = new QuanLyKH();
            kh.Show();
            
        }
    }
}
