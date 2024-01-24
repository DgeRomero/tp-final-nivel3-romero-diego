using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class Detalles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCategoria.Enabled = false;
            txtId.Enabled = false;
            txtNombre.Enabled = false;
            txtCodigo.Enabled = false;
            txtMarca.Enabled = false;
            txtPrecio.Enabled = false;
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if( id != "" && !IsPostBack)
                {
                    ListadoNegocio negocio = new ListadoNegocio();
                    Articulo seleccionado = (negocio.listar(id))[0];

                    Session.Add("ArticuloSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtMarca.Text = (seleccionado.Marca).ToString();
                    txtCategoria.Text = (seleccionado.Categoria).ToString();
                    txtPrecio.Text = "$ " + seleccionado.Precio;
                    imgProducto.ImageUrl = seleccionado.UrlImagen;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
                throw;
            }
        }
    }
}