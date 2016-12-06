using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DataLayer;

namespace BusinessLayer
{
    public class ProductsBL
    {
        #region Singleton
        private static readonly ProductsBL _instance = new ProductsBL();

        public static ProductsBL Instance
        {
            get { return ProductsBL._instance; }
        }
        #endregion Singleton

        #region Metodos
        public List<ProductsEL> ListProducts(Int16 idCategory)
        {
            try
            {
                return ProductsDL.Instance.ListProducts(idCategory);
            }
            catch (Exception e) { throw e; }
        }
        public ProductsEL CallProductId(Int16 idProduct)
        {
            try
            {
                return ProductsDL.Instance.CallProductId(idProduct);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean AddNewProducts(ProductsEL p)
        {
            try
            {
                return ProductsDL.Instance.AddProductos(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean EditProduct(ProductsEL p)
        {
            try
            {
                return ProductsDL.Instance.EditProduct(p);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Metodos
    }
}
