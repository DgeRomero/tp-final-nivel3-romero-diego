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
    public partial class Formulario : System.Web.UI.Page
    {

        public bool confimarEliminacion { get; set; }
        public bool hayArticulo { get; set; }
        public string urlImagen { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            confimarEliminacion = false;
            hayArticulo = false;
            try
            {
                if (!IsPostBack)
                {
                    CategoriaNegocio cat = new CategoriaNegocio();
                    List<Categoria> categorias = cat.listar();
                    MarcaNegocio mar = new MarcaNegocio();
                    List<Marca> marcas = mar.listar();

                    ddlCategoria.DataSource = categorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : "";
                if (id != "" && !IsPostBack)
                {
                    hayArticulo = true;
                    ListadoNegocio negocio = new ListadoNegocio();
                    Articulo seleccionado = negocio.listar(id)[0];
                    Session.Add("seleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtImagen.Text = seleccionado.UrlImagen;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = (seleccionado.Precio).ToString();
                    txtCodigo.Text = seleccionado.Codigo;

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();

                    txtImagen_TextChanged(sender, e);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ListadoNegocio negocio = new ListadoNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.UrlImagen = txtImagen.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text); 
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }
                Response.Redirect("Listado.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
            
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confimarEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ListadoNegocio negocio = new ListadoNegocio();
                if (checkConfimarEliminacion.Checked)
                {
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("Listado.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}