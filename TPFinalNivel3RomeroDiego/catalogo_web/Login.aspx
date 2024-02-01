<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="catalogo_web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validar{
            color: red;
            font-size: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <h2>Login</h2>
            <div class="mb-3">
                <label for="txtMail" class="form-label">Email</label>
                <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Debe ingresar un Email válido" 
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" 
                    ControlToValidate="txtMail" CssClass="validar" runat="server" />
   
            </div>
            <div class="mb-2">
                <label for="txtNombre" class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe ingresar la contraseña" CssClass="validar" ControlToValidate="txtPassword" runat="server" />
            </div>
                                    
            <div class="mb-2">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary mx-md-5 m-2" OnClick="btnLogin_Click" Text="Ingresar" />
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
