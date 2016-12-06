using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ConectionDL
    {
        #region Singleton
        private static readonly ConectionDL _instance = new ConectionDL();
        public static ConectionDL Instance
        {
            get { return ConectionDL._instance; }
        }
        #endregion Singleton

        #region metodos
        public SqlConnection ConnectDataBase()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.;Initial Catalog=db_floristeria;User ID=sa;Password=12345678";
           
            return conn;
        }
        #endregion metodos
    }
}
