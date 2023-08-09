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
    public partial class TrangChu : Form
    {
        private string mcb;
        SqlDataReader dataReader;
        public TrangChu()
        {
            InitializeComponent();
            
        }


        public TrangChu(string mcb)
        {
            InitializeComponent();
            this.mcb = mcb;
        }

        
        private void TrangChu_Load(object sender, EventArgs e)
        {
            txtMaCanBo.Text = mcb;
            txtMaCanBo.ReadOnly = true;
            loadCboMaMon();
            
            // Tải tên cán bộ tương ứng với mã cán bộ đăng nhập tài khoản
            clsDatabase.OpenConnection();
            SqlCommand cmd = new SqlCommand("select distinct HotenCB from DS_Can_bo where MaCB = @MaCB", clsDatabase.con);
            cmd.Parameters.AddWithValue("@MaCB", this.mcb);
            string ten = Convert.ToString(cmd.ExecuteScalar());
            txtTenCanBo.Text = ten.ToString();
            txtTenCanBo.ReadOnly = true;
        }


        // Tải thông tin mã lớp cán bộ giảng dạy lên comboBox.
        void loadCboMaLop()
        {
             try
             {
                clsDatabase.OpenConnection();
                DataTable table = new DataTable();
                string mamon = cboMaMon.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand("select distinct MaLop from Giang_Day where MaCB = @Macb and MaMon = @MaMon", clsDatabase.con);
                cmd.Parameters.AddWithValue("@Macb", this.mcb);
                cmd.Parameters.AddWithValue("@MaMon", mamon);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);
                table.Dispose();
                cboMaLop.DataSource = table;
                cboMaLop.ValueMember = "MaLop";
                cboMaLop.DisplayMember = "MaLop";

            }
             catch (Exception ex)
             {
                 MessageBox.Show("Không thể tải dữ liệu lên ", "Thông báo" + ex.ToString());
             }
        }


        // Tải dữ liệu lên comboBox Mã môn với thông tin các mã môn học của học phần
        void loadCboMaMon()
        {
            try
            {
                clsDatabase.OpenConnection();
                DataTable table = new DataTable();
                SqlCommand cmd = new SqlCommand("select distinct MaMon from Giang_Day where MaCB = @Macb", clsDatabase.con);
                cmd.Parameters.AddWithValue("@Macb", mcb);
                cmd.ExecuteNonQuery();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(table);
                table.Dispose();
                cboMaMon.DataSource = table;
                cboMaMon.ValueMember = "MaMon";
                cboMaMon.DisplayMember = "MaMon";
                cboMaMon.DisplayMember = "MaMon";
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể tải dữ liệu lên ", "Thông báo");
            }
        }
        
        // Liệt kê đầy đủ thông tin mà cán bộ đó giảng dạy
        private void menuHP_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            dataAdapter = new SqlDataAdapter("select distinct gd.MaMon, gd.MaLop, mh.TenMon from " +
                                                            "Giang_Day gd inner join DS_Mon_hoc mh on gd.MaMon = mh.MaMon " +
                                                            "where MaCB = '" + txtMaCanBo.Text + "'", clsDatabase.con);
            clsDatabase.CloseConnection();
            dataAdapter.Fill(table);
            dataDSHP.DataSource = table;
            dataDSHP.Columns[2].Width = 330;
        }

        // Thoát khỏi trang chủ
        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo");
            Application.Exit();
        }


        
        // Cập nhật điểm cho sinh viên
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            clsDatabase.OpenConnection();
            int i = this.dataDSSVn.CurrentRow.Index;
            string mssv = dataDSSVn.Rows[i].Cells[1].Value.ToString();
            string diem = txtDiem.Text;
            string MaMon = cboMaMon.SelectedValue.ToString();
            //string MaMon = dataDSSVn.Rows[i].Cells[2].Value.ToString();
            //string MaMon = txtMaMon.Text;
            SqlCommand cmd = new SqlCommand("update Diem_HP set  Diem = @diem where MaMon = @MaMon and MSSV = @mssv" , clsDatabase.con);
            cmd.Parameters.AddWithValue("@diem", diem);
            cmd.Parameters.AddWithValue("@MaMon",MaMon);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
            cboMaLop_SelectedIndexChanged(sender, e);
        }

        //Chọn mã lớp cần hiển thị
        private void cboMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mamon = cboMaMon.SelectedValue.ToString();
            string malop = cboMaLop.SelectedValue.ToString();
            SqlDataAdapter dataAdapter;
            clsDatabase.OpenConnection();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand("select  distinct sv.STT, d.MSSV, sv.Hoten, d.MaMon, gd.MaLop , d.Diem from " +
                                            "(Diem_HP d inner join DS_Sinh_vien sv on d.MSSV = sv.MSSV) inner join " +
                                            "Giang_Day gd on d.MaMon = gd.MaMon " +
                                            "where MaCB = @Macb and gd.MaMon = @MaMon and gd.MaLop = @MaLop", clsDatabase.con);
            cmd.Parameters.AddWithValue("@MaCb", mcb);
            cmd.Parameters.AddWithValue("@MaMon", mamon);
            cmd.Parameters.AddWithValue("@MaLop", malop);
            cmd.ExecuteNonQuery();
            dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(tb);
            tb.Dispose();
            
            dataDSSVn.DataSource = tb;
            dataDSSVn.Columns[2].Width = 250;
            dataDSSVn.Columns[0].Width = 40;
            dataDSSVn.Columns[5].Width = 60;
        }


        // Khi click chuột vào bảng sẽ hiển thị thông tin sinh viên lên các ô textbox để cập nhật điểm
        private void dataDSSVn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataDSSVn.CurrentRow.Index;
            txtMSSV.Text = dataDSSVn.Rows[i].Cells[1].Value.ToString();
            txtDiem.Text = dataDSSVn.Rows[i].Cells[5].Value.ToString();
            txtMaMon.Text = dataDSSVn.Rows[i].Cells[3].Value.ToString();
            //txtMSSV.ReadOnly = true;
            btnCapNhat.Focus();
        }


        // Chọn mã môn cần hiển thị
        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCboMaLop();
            string mamon = cboMaMon.SelectedValue.ToString();
            SqlDataAdapter dataAdapter;
            clsDatabase.OpenConnection();
            DataTable tb = new DataTable();
            SqlCommand cmd = new SqlCommand("select distinct d.MaCB, d.MaLop, d.MaMon, mh.TenMon from Giang_Day d join " +
                                            "DS_Mon_hoc mh on d.MaMon = mh.MaMon where MaCB = @MaCb and d.MaMon = @MaMon", clsDatabase.con);
            cmd.Parameters.AddWithValue("@MaCb", mcb);
            cmd.Parameters.AddWithValue("@MaMon", mamon);
            cmd.ExecuteNonQuery();
            dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(tb);
            tb.Dispose();
            dataHP.DataSource = tb;
        }


       
        private void cboMM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuDSSV_Click(object sender, EventArgs e)
        {

        }

        private void dataHP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }
        private void dataDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataDSHP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
