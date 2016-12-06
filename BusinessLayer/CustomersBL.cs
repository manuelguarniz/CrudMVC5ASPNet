using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataLayer;

namespace BusinessLayer
{
    public class CustomersBL
    {
        #region Singleton
        private static readonly CustomersBL _instance = new CustomersBL();

        public static CustomersBL Instance
        {
            get { return CustomersBL._instance; }
        }
        #endregion Singleton

        #region Metodos
        /*CLIENTES ACTIVOS*/
        public List<CustomersEL> ListClientes(Int16 idCustomer)
        {
            try
            {
                return CustomerDL.Instance.ListCustomers(idCustomer);
            }
            catch (Exception e) { throw e; }
        }
        public CustomersEL SearchClientes(Int16 idCustomer)
        {
            try
            {
                return CustomerDL.Instance.SearchClientes(idCustomer);
            }
            catch (Exception e) { throw e; }
        }
        /*CLIENTES INACTIVOS*/
        public List<CustomersEL> ListClientesDown(Int16 idCustomer)
        {
            try
            {
                return CustomerDL.Instance.ListCustomersDown(idCustomer);
            }
            catch (Exception e) { throw e; }
        }
        public CustomersEL SearchClientesDown(Int16 idCustomer)
        {
            try
            {
                return CustomerDL.Instance.SearchClientesDown(idCustomer);
            }
            catch (Exception e) { throw e; }
        }
        /*MANTENEDOR*/
        public Boolean AddCustomer(CustomersEL c)
        {
            try
            {
                return CustomerDL.Instance.AddCustomer(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean EditCustomer(CustomersEL c)
        {
            try
            {
                return CustomerDL.Instance.EditCustomer(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean DeleteCustomer(int idCustomer)
        {
            try
            {
                return CustomerDL.Instance.DeleteCustomer(idCustomer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean ActiveCustomer(int idCustomer)
        {
            try
            {
                return CustomerDL.Instance.ActiveCustomer(idCustomer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Metodos
    }
}
