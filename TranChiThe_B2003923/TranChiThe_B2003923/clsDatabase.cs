using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TranChiThe_B2003923
{
    class clsDatabase
    {
        public static SqlConnection con;
        private static clsDatabase sl;
        private static SqlDataAdapter dataAdapter;
        //private static SqlCommand cmd;
        //private static DataTable table = new DataTable();
        //private static SqlCommandBuilder cmd;


        public static bool OpenConnection()

        {
            try
            {
                con = new SqlConnection(@"Server=.\SQLEXPRESS;Database = Quan_Ly_SinhVien; Integrated Security = SSPI; uid=sa; pwd=sa;");
                con.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
