using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TranChiThe_B2003923
{
    class TaiKhoan
    {
        private string MaCB;
        private string Password;

        public TaiKhoan()
        {

        }

        public TaiKhoan(string Macb)
        {
            this.MaCB = Macb;
        }

        public string Can_Bo
        {
            get { return MaCB; }
            set { MaCB = value; }
        }

        public TaiKhoan(string tk, string mk)
        {
            this.MaCB = tk;
            this.Password = mk;
        }

        public string Can_Bo_User
        {
            get { return MaCB; }
            set { MaCB = value; }
        }
        public string Can_Bo_Pwd
        {
            get { return Password; }
            set { Password = value; }
        }
    }
}
