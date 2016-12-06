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
    public class CategoriesDL
    {
        #region singleton
        private static readonly CategoriesDL _instance = new CategoriesDL();

        public static CategoriesDL Instance
        {
            get { return CategoriesDL._instance; }
        }
        #endregion singleton

        #region metodos
        public List<CategoriesEL> ListCategories()
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            List<CategoriesEL> list = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_listarCategorias", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                dataReader = command.ExecuteReader();
                list = new List<CategoriesEL>();

                while (dataReader.Read())
                {
                    CategoriesEL cateEnt = new CategoriesEL();
                    cateEnt.idCategoria = Convert.ToInt16(dataReader["idCategoria"]);
                    cateEnt.descripcionCat = dataReader["descripcionCat"].ToString();
                    list.Add(cateEnt);
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
        #endregion metodos
    }
}
