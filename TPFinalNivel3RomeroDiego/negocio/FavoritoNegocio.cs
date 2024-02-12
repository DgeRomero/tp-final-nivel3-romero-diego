using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class FavoritoNegocio
    {
        public void agregarFavorito(Articulo art, Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo)values(@idUser, @idArticulo)");
                datos.setearParametro("@idUser", user.Id);
                datos.setearParametro("@idArticulo", art.Id);
                datos.ejecutarAccion();

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

        public int traerFav(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            Favorito fav = new Favorito();
            try
            {
                datos.setearConsulta("Select IdArticulo from Favoritos where idUser = @user");
                datos.setearParametro("@user", user.Id);
                datos.ejecutarLectura();

                if(datos.Lector.Read())
                    fav.IdArticulo = (int)datos.Lector["IdArticulo"];
                
                return fav.IdArticulo;
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

        public List<Articulo> listarFavoritos(Usuario user)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select Codigo, Nombre, M.Descripcion Marca, c.Descripcion Categoria,  Precio, A.Descripcion, ImagenUrl, a.IdCategoria, a.IdMarca, a.Id, F.Id idFavorito, F.IdArticulo, F.IdUser from ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F where a.Id = F.IdArticulo and C.Id = A.IdCategoria and M.Id = A.IdMarca and F.idUser = @user");
                datos.setearParametro("@user", user.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //Favorito fav = new Favorito();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];

                    lista.Add(aux);
                }
                
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
