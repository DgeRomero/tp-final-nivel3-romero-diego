using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace catalogo_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> listaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FavoritoNegocio negocio = new FavoritoNegocio();
            
            if ((Usuario)Session["usuario"] != null)
            {
                Usuario activo = (Usuario)Session["usuario"];
                if (!IsPostBack)
                {

                    listaFavoritos = negocio.listarFavoritos(activo);
                    repFavoritos.DataSource = listaFavoritos;
                    repFavoritos.DataBind();
                }
            }
            
        }
    }
}