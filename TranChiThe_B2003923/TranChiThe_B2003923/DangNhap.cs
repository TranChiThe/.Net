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

namespace TranChiThe_B2003923
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        XacThucTK xt = new XacThucTK();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtMaCB.Text;
            string pwd = txtPwd.Text;
            if (user.Trim() == " ")
            {
                MessageBox.Show("Vui lòng nhập vào mã cán bộ!!!");
            }
            else if (pwd.Trim() == " ")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu tài khoản");
            }
            else
            {
                string str = "select * from DS_Can_Bo where MaCB = '" + user + "' and MatKhau = '" + pwd + "'";
                if (xt.TaiKhoans(str).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    TrangChu t = new TrangChu(txtMaCB.Text);
                    this.Hide();
                    t.ShowDialog();
                    //this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Đăng nhập không thành công", "Thông báo");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show( "Bạn có chắc muốn thoát!!!", "Thông báo");
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LayMatKhau dk = new LayMatKhau();
            this.Hide();
            dk.ShowDialog();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
