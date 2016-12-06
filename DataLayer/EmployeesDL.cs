using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class EmployeesDL
    {
        #region Singleton
        private static readonly EmployeesDL _instance = new EmployeesDL();
        public static EmployeesDL Instance
        {
            get { return EmployeesDL._instance; }
        }
        #endregion Singleton

        #region metodos
        public EmployeesEL VerifyUserAccess(String _User, String _Password)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            EmployeesEL emploEl = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_VerificarAcceso", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmstrUsuario", _User);
                command.Parameters.AddWithValue("@prmstrPassword", _Password);
                conn.Open();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    emploEl = new EmployeesEL();
                    emploEl.idEmpleado = Convert.ToInt16(dataReader["idEmpleado"]);
                    emploEl.nombreEmp = dataReader["nombreEmp"].ToString();
                    emploEl.apellidosEmp = dataReader["apellidosEmp"].ToString();
                    emploEl.telefonoEmp = dataReader["telefonoEmp"].ToString();
                    emploEl.dniEmp = dataReader["dniEmp"].ToString();
                    emploEl.correoEmp = dataReader["correoEmp"].ToString();
                    emploEl.activoEmp = Convert.ToBoolean(dataReader["activoEmp"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }
            return emploEl;
        }

        #endregion metodos
    }
}
