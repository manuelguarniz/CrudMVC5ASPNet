using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataLayer;

namespace BusinessLayer
{
    public class EmployeesBL
    {
        #region Singleton
        private static readonly EmployeesBL _instance = new EmployeesBL();
        public static EmployeesBL Instance
        {
            get { return EmployeesBL._instance; }
        }
        #endregion Singleton

        #region metodos
        public EmployeesEL VerifyUserAccess(String _User, String _Password)
        {
            try
            {
                EmployeesEL emplo = EmployeesDL.Instance.VerifyUserAccess(_User, _Password);
                if (emplo == null)
                {
                    throw new ApplicationException("Usuario o Password Erroneo");
                }
                else
                {
                    if (!emplo.activoEmp)
                    {
                        throw new Exception("Usuario ha sido dado de baja!");
                    }
                }
                return emplo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
