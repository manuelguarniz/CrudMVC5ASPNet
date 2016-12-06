using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataLayer;

namespace BusinessLayer
{
    public class CategoriesBL
    {
        #region Singleton
        private static readonly CategoriesBL _instance = new CategoriesBL();

        public static CategoriesBL Instance
        {
            get { return CategoriesBL._instance; }
        }
        #endregion Singleton

        #region Metodos
        public List<CategoriesEL> ListCategories()
        {
            try
            {
                return CategoriesDL.Instance.ListCategories();
            }
            catch (Exception e) { throw e; }
        }
        #endregion Metodos
    }
}
