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
    }
}
