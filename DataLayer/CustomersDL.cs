using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class CustomerDL
    {
        #region singleton
        private static readonly CustomerDL _instance = new CustomerDL();

        public static CustomerDL Instance
        {
            get { return CustomerDL._instance; }
        }
        #endregion singleton

        #region metodos
        /*LISTAR CLIENTES ACTIVOS*/
        public List<CustomersEL> ListCustomers(Int16 idCustomer)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            List<CustomersEL> list = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_BuscarClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCliente", idCustomer);

                conn.Open();

                dataReader = command.ExecuteReader();
                list = new List<CustomersEL>();

                while (dataReader.Read())
                {
                    CustomersEL cusEnt = new CustomersEL();
                    cusEnt.idCliente = Convert.ToInt16(dataReader["idCliente"]);
                    cusEnt.nombreCli = dataReader["nombreCli"].ToString();
                    cusEnt.apellidoCli = dataReader["apellidoCli"].ToString();
                    cusEnt.telefonoCli = dataReader["telefonoCli"].ToString();
                    cusEnt.dniCli = dataReader["dniCli"].ToString();
                    cusEnt.correoCli = dataReader["correoCli"].ToString();
                    cusEnt.usuarioCli = dataReader["usuarioCli"].ToString();
                    cusEnt.passwordCli = dataReader["passwordCli"].ToString();
                    cusEnt.activoCli = Convert.ToBoolean(dataReader["activoCli"]);
                    list.Add(cusEnt);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }

            return list;
        }
        public CustomersEL SearchClientes(Int16 idCustomer)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            CustomersEL cusEnt = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_BuscarClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCliente", idCustomer);

                conn.Open();

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    cusEnt = new CustomersEL();
                    cusEnt.idCliente = Convert.ToInt16(dataReader["idCliente"]);
                    cusEnt.nombreCli = dataReader["nombreCli"].ToString();
                    cusEnt.apellidoCli = dataReader["apellidoCli"].ToString();
                    cusEnt.telefonoCli = dataReader["telefonoCli"].ToString();
                    cusEnt.dniCli = dataReader["dniCli"].ToString();
                    cusEnt.correoCli = dataReader["correoCli"].ToString();
                    cusEnt.usuarioCli = dataReader["usuarioCli"].ToString();
                    cusEnt.passwordCli = dataReader["passwordCli"].ToString();
                    cusEnt.activoCli = Convert.ToBoolean(dataReader["activoCli"]);
                    
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }

            return cusEnt;
        }
        /*LISTAR CLIENTES INACTIVOS*/
        public List<CustomersEL> ListCustomersDown(Int16 idCustomer)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            List<CustomersEL> list = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_VerEliminadosClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCliente", idCustomer);

                conn.Open();

                dataReader = command.ExecuteReader();
                list = new List<CustomersEL>();

                while (dataReader.Read())
                {
                    CustomersEL cusEnt = new CustomersEL();
                    cusEnt.idCliente = Convert.ToInt16(dataReader["idCliente"]);
                    cusEnt.nombreCli = dataReader["nombreCli"].ToString();
                    cusEnt.apellidoCli = dataReader["apellidoCli"].ToString();
                    cusEnt.telefonoCli = dataReader["telefonoCli"].ToString();
                    cusEnt.dniCli = dataReader["dniCli"].ToString();
                    cusEnt.correoCli = dataReader["correoCli"].ToString();
                    cusEnt.usuarioCli = dataReader["usuarioCli"].ToString();
                    cusEnt.passwordCli = dataReader["passwordCli"].ToString();
                    cusEnt.activoCli = Convert.ToBoolean(dataReader["activoCli"]);
                    list.Add(cusEnt);
                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }

            return list;
        }
        public CustomersEL SearchClientesDown(Int16 idCustomer)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            CustomersEL cusEnt = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_VerEliminadosClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCliente", idCustomer);

                conn.Open();

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    cusEnt = new CustomersEL();
                    cusEnt.idCliente = Convert.ToInt16(dataReader["idCliente"]);
                    cusEnt.nombreCli = dataReader["nombreCli"].ToString();
                    cusEnt.apellidoCli = dataReader["apellidoCli"].ToString();
                    cusEnt.telefonoCli = dataReader["telefonoCli"].ToString();
                    cusEnt.dniCli = dataReader["dniCli"].ToString();
                    cusEnt.correoCli = dataReader["correoCli"].ToString();
                    cusEnt.usuarioCli = dataReader["usuarioCli"].ToString();
                    cusEnt.passwordCli = dataReader["passwordCli"].ToString();
                    cusEnt.activoCli = Convert.ToBoolean(dataReader["activoCli"]);

                }
            }
            catch (Exception e) { throw e; }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }

            return cusEnt;
        }
        /*MANTENEDOR*/
        public Boolean AddCustomer(CustomersEL c)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_AgregarClientes", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmstrNombreCli", c.nombreCli);
                command.Parameters.AddWithValue("@prmstrApellidoCli", c.apellidoCli);
                command.Parameters.AddWithValue("@prmstrTelefonoCli", c.telefonoCli);
                command.Parameters.AddWithValue("@prmstrDniCli", c.dniCli);
                command.Parameters.AddWithValue("@prmstrCorreoCli", c.correoCli);
                command.Parameters.AddWithValue("@pdmstrUsuarioCli", c.usuarioCli);
                command.Parameters.AddWithValue("@prmstrPasswordCli", c.passwordCli);
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    funcCommand = true;
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
            return funcCommand;
        }
        public Boolean EditCustomer(CustomersEL c)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_EditarClientes", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCli", c.idCliente);
                command.Parameters.AddWithValue("@prmstrNombreCli", c.nombreCli);
                command.Parameters.AddWithValue("@prmstrApellidoCli", c.apellidoCli);
                command.Parameters.AddWithValue("@prmstrTelefonoCli", c.telefonoCli);
                command.Parameters.AddWithValue("@prmstrDniCli", c.dniCli);
                command.Parameters.AddWithValue("@prmstrCorreoCli", c.correoCli);
                command.Parameters.AddWithValue("@pdmstrUsuarioCli", c.usuarioCli);
                command.Parameters.AddWithValue("@prmstrPasswordCli", c.passwordCli);
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    funcCommand = true;
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
            return funcCommand;
        }
        public Boolean DeleteCustomer(int idCustomer)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_EliminarClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCli", idCustomer);
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    funcCommand = true;
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
            return funcCommand;
        }
        public Boolean ActiveCustomer(int idCustomer)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_ActivarClientes", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdCli", idCustomer);
                conn.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    funcCommand = true;
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
            return funcCommand;
        }
        #endregion metodos
    }
}
