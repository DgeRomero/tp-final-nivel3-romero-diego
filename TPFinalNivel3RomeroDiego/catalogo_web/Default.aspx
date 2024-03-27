<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="catalogo_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h1 class="mb-3">CATÁLOGO</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Buscar producto" ID="lblFiltroRapido" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtrar búsqueda" ID="cbxFiltroAvanzado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="cbxFiltroAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%if (cbxFiltroAvanzado.Checked)
                { %>
            
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar por:" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true" >
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                    </div>
                </div>
                
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" />
                        <asp:Button Text="Limpiar  filtro" ID="btnLimpiarFiltro" runat="server" OnClick="btnLimpiarFiltro_Click" CssClass="btn btn-outline-secondary"  />
                    </div>
                </div>
            </div>
            <% } %>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
                <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text">$<%#Eval("Precio", "{0:F2}") %></p>
                            <a href="Detalles.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                            <% if (negocio.Seguridad.sessionActiva(Session["usuario"]))
                               { %>
                            <asp:Button Text="Agregar Favorito" CssClass="btn btn-primary" runat="server" ID="btnFavorito" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" OnClick="btnFavorito_Click" />
                            <% } %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
