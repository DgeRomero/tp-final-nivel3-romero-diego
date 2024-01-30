<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="catalogo_web.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>LISTADO</h1>
    
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Buscar producto" ID="lblFiltroRapido" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltroListado" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltroListado_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtrar búsqueda" ID="cbxFiltroAvanzadoListado" runat="server"
                    AutoPostBack="true"
                    OnCheckedChanged="cbxFiltroAvanzadoListado_CheckedChanged" />
            </div>
        </div>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <%if (cbxFiltroAvanzadoListado.Checked)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar por:" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCampoListado" CssClass="form-control" OnSelectedIndexChanged="ddlCampoListado_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="" />
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Precio" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Código" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterioListado" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox ID="txtFiltroAvanzadoListado" CssClass="form-control" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" CssClass="btn btn-primary" ID="btnBuscarFiltro" runat="server" OnClick="btnBuscarFiltro_Click" />
                    </div>
                </div>
            </div>
            <% } %>
        </ContentTemplate>
    </asp:UpdatePanel>

     <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server" ID="dvgListaArticulos" DataKeyNames="id"
                CssClass="table table-bordered table-hover" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dvgListaArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dvgListaArticulos_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />                    
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />                    
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />                    
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" ItemStyle-CssClass="text-center" SelectText="🔥" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="Formulario.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
