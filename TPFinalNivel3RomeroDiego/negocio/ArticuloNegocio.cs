using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> mostrar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            
            try
            {
                datos.setearConsulta("select @Codigo, @Nombre, '" + art.Marca.Descripcion + "', '" + art.Categoria.Descripcion + "', @Precio, '" + art.Descripcion + "', @ImagenUrl, '" + art.Categoria.Id + "', '" + art.Marca.Id + "', '" + art.Id + "' from ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca and a.id = '" + art.Id + "'");
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Codigo", art.Codigo);                           
                datos.setearParametro("@Precio", art.Precio);                
                datos.setearParametro("@ImagenUrl", art.UrlImagen);
                datos.ejecutarAccion();

                lista.Add(art);

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
