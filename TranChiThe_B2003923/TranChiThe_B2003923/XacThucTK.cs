using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TranChiThe_B2003923
{
    class XacThucTK
    {
        public XacThucTK()
        {

        }
        SqlDataReader dataReader;
        public List<TaiKhoan> TaiKhoans(string s)
        {
            clsDatabase.OpenConnection();
            List<TaiKhoan> taikhoan = new List<TaiKhoan>();
            SqlCommand sqlcmd = new SqlCommand(s, clsDatabase.con);
            dataReader = sqlcmd.ExecuteReader();

            while (dataReader.Read())
            {
                taikhoan.Add(new TaiKhoan(dataReader.GetString(0), dataReader.GetString(1)));
            }
            clsDatabase.CloseConnection();
            return taikhoan;
        }
    }
}
