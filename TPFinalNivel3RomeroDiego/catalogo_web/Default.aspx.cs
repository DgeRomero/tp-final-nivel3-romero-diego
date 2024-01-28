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
    public partial class Default : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            filtroAvanzado = cbxFiltroAvanzado.Checked;
            if (!IsPostBack)
            {
                ListadoNegocio negocio = new ListadoNegocio();
                ListaArticulos = negocio.listar();
                Session.Add("articulos", ListaArticulos);
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["articulos"];
            List<Articulo> listaFiltrada = lista.FindAll( x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
        }

        protected void cbxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = cbxFiltroAvanzado.Checked;
            txtFiltro.Enabled = !filtroAvanzado;
            //ddlCampo.Items.Add("");
            //ddlCampo.Items.Add("Nombre");
            //ddlCampo.Items.Add("Precio");
            //ddlCampo.Items.Add("Marca");
            //ddlCampo.Items.Add("Categoría");
            //ddlCampo.Items.Add("Código");
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoNegocio negocio = new ListadoNegocio();
                repRepetidor.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                repRepetidor.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}