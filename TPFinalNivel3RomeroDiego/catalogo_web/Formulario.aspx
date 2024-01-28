<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="catalogo_web.Formulario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-2">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-2">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-2">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-2">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" />
                <a href="Listado.aspx">Cancelar</a>
            </div>
            <div class="mb-2">
                <asp:UpdatePanel ID="updatepanel" runat="server">
                <ContentTemplate>
                    <% if (hayArticulo)
                        { %>
                    <div class="mb-2">
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                    </div>
                    <% } %>
                    <% if (confimarEliminacion)
                        { %>
                    <div class="mb-2">
                        <asp:CheckBox Text="Confimar eliminación" ID="checkConfimarEliminacion" runat="server" />
                        <asp:Button ID="btnConfirmaEliminar" runat="server" CssClass="btn btn-outline-danger" Text="Eliminar" OnClick="btnConfirmaEliminar_Click" />
                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-2">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div class="mb-2">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <label for="txtImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged"></asp:TextBox>
                        <div class="mb-2 mt-2 text-center">
                            <asp:Image ImageUrl="https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg"
                                runat="server" ID="imgArticulo" Width="60%" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
