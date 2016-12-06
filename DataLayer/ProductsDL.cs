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
    public class ProductsDL
    {
        #region singleton
        private static readonly ProductsDL _instance = new ProductsDL();

        public static ProductsDL Instance
        {
            get { return ProductsDL._instance; }
        }
        #endregion singleton

        #region metodos
        public List<ProductsEL> ListProducts(Int16 idCategory)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            List<ProductsEL> list = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_ListarProductosCategorias", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmsintId", idCategory);

                conn.Open();

                dataReader = command.ExecuteReader();
                list = new List<ProductsEL>();

                while (dataReader.Read())
                {
                    ProductsEL prodEnt = new ProductsEL();
                    prodEnt.idProducto = Convert.ToInt16(dataReader["idProducto"]);
                    prodEnt.descripcionProducto = dataReader["descripcionProducto"].ToString();
                    prodEnt.detalleProducto = dataReader["detalleProducto"].ToString();
                    prodEnt.tiempoElab = dataReader["tiempoElab"].ToString();
                    prodEnt.incrementoxProduccion = Convert.ToDouble(dataReader["incrementoxProduccion"]);
                    prodEnt.disponibilidad = Convert.ToBoolean(dataReader["disponibilidad"]);
                        CategoriesEL cateEnt = new CategoriesEL();
                        cateEnt.idCategoria = Convert.ToInt16(dataReader["idCategoria"]);
                        cateEnt.descripcionCat = dataReader["descripcionCat"].ToString();
                    prodEnt.Categoria = cateEnt;
                    prodEnt.imagen = dataReader["imagen"].ToString();
                    list.Add(prodEnt);
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

        public ProductsEL CallProductId(Int16 idProduct)
        {
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            ProductsEL prodEnt = null;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_BuscarProductos", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdProduc", idProduct);

                conn.Open();

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    prodEnt = new ProductsEL();
                    prodEnt.idProducto = Convert.ToInt16(dataReader["idProducto"]);
                    prodEnt.descripcionProducto = dataReader["descripcionProducto"].ToString();
                    prodEnt.detalleProducto = dataReader["detalleProducto"].ToString();
                    prodEnt.tiempoElab = dataReader["tiempoElab"].ToString();
                    prodEnt.incrementoxProduccion = Convert.ToDouble(dataReader["incrementoxProduccion"]);
                    prodEnt.disponibilidad = Convert.ToBoolean(dataReader["disponibilidad"]);
                    CategoriesEL cateEnt = new CategoriesEL();
                    cateEnt.idCategoria = Convert.ToInt16(dataReader["idCategoria"]);
                    cateEnt.descripcionCat = dataReader["descripcionCat"].ToString();
                    prodEnt.Categoria = cateEnt;
                    prodEnt.imagen = dataReader["imagen"].ToString();
                }

            }
            catch (Exception e) { throw e; }
            finally
            {
                command.Connection.Close();
                conn.Close();
            }

            return prodEnt;
        }
        public Boolean AddProductos(ProductsEL p)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_IngresarProductos", conn);
                
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmstrDescipcion", p.descripcionProducto);
                command.Parameters.AddWithValue("@prmstrDetalleProducto", p.detalleProducto);
                command.Parameters.AddWithValue("@prmstrTiempoElaboracion", p.tiempoElab);
                command.Parameters.AddWithValue("@prmnumIncremento", p.incrementoxProduccion);
                command.Parameters.AddWithValue("@prmboolDisponibilidad", p.disponibilidad);
                command.Parameters.AddWithValue("@prmnumCantidad", p.cantidadDisponible);
                command.Parameters.AddWithValue("@prmintIdCate", p.Categoria.idCategoria);
                command.Parameters.AddWithValue("@prmstrImagen", p.imagen);
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
        public Boolean EditProduct(ProductsEL p)
        {
            SqlCommand command = null;
            Boolean funcCommand = false;
            SqlConnection conn = null;
            try
            {
                conn = ConectionDL.Instance.ConnectDataBase();
                command = new SqlCommand("sp_EditarProductos", conn);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@prmintIdProd", p.idProducto);
                command.Parameters.AddWithValue("@prmstrDescipcion", p.descripcionProducto);
                command.Parameters.AddWithValue("@prmstrDetalleProducto", p.detalleProducto);
                command.Parameters.AddWithValue("@prmstrTiempoElaboracion", p.tiempoElab);
                command.Parameters.AddWithValue("@prmnumIncremento", p.incrementoxProduccion);
                command.Parameters.AddWithValue("@prmboolDisponibilidad", p.disponibilidad);
                command.Parameters.AddWithValue("@prmnumCantidad", p.cantidadDisponible);
                command.Parameters.AddWithValue("@prmintIdCate", p.Categoria.idCategoria);
                command.Parameters.AddWithValue("@prmstrImagen", p.imagen);
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
