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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://uxwing.com/wp-content/themes/uxwing/download/peoples-avatars/no-profile-picture-icon.png";

            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                if (!Seguridad.sessionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else if (!IsPostBack)
                {
                    Usuario user = (Usuario)Session["usuario"];

                    string nombre = user.Nombre;
                    lblUser.Text += nombre != null ? nombre : user.Email;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imgAvatar.ImageUrl = "~/images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                }
            }
            else if (Session["usuario"] != null && !IsPostBack)
            {
                Usuario user = (Usuario)Session["usuario"];

                string nombre = user.Nombre;
                lblUser.Text += nombre != null ? nombre : user.Email;


                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}