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
    public partial class Listado : System.Web.UI.Page
    {
        public bool filtroAvanzadoListado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Necesitas ser Admin para ver esto...");
                Response.Redirect("Error.aspx", false);
            }

            filtroAvanzadoListado = cbxFiltroAvanzadoListado.Checked;
            if (!IsPostBack)
            {
                ListadoNegocio negocio = new ListadoNegocio();
                Session.Add("articulos", negocio.listar());
                dvgListaArticulos.DataSource = Session["articulos"];
                dvgListaArticulos.DataBind();
            }
            
        }

        protected void txtFiltroListado_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["articulos"];
            List<Articulo> listaFiltrada = lista.FindAll( x => x.Nombre.ToUpper().Contains(txtFiltroListado.Text.ToUpper()));
            dvgListaArticulos.DataSource = listaFiltrada;
            dvgListaArticulos.DataBind();
        }

        protected void cbxFiltroAvanzadoListado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzadoListado = cbxFiltroAvanzadoListado.Checked;
            txtFiltroListado.Enabled = !filtroAvanzadoListado;
        }

        protected void ddlCampoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterioListado.Items.Clear();
            if(ddlCampoListado.SelectedIndex.ToString() == "Precio")
            {
                ddlCriterioListado.Items.Add("Igual a");
                ddlCriterioListado.Items.Add("Menor a");
                ddlCriterioListado.Items.Add("Mayor a");
            }
            else
            {
                ddlCriterioListado.Items.Add("Contiene");
                ddlCriterioListado.Items.Add("Comienza con");
                ddlCriterioListado.Items.Add("Termina con");
            }
        }

        protected void btnBuscarFiltro_Click(object sender, EventArgs e)
        {
            ListadoNegocio negocio = new ListadoNegocio();
            dvgListaArticulos.DataSource = negocio.filtrar(ddlCampoListado.SelectedItem.ToString(), 
                ddlCriterioListado.SelectedItem.ToString(),
                txtFiltroAvanzadoListado.Text);
            dvgListaArticulos.DataBind();
        }

        protected void dvgListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dvgListaArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id);
        }

        protected void dvgListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvgListaArticulos.DataSource = Session["articulos"];
            dvgListaArticulos.PageIndex = e.NewPageIndex;
            dvgListaArticulos.DataBind();
        }
    }
}