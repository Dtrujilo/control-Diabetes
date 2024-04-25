<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Control_Tipos_Diabetes.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Iniciar Sesión
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="shadow-none px-4 py-5 my-5 bg-light rounded w-25 position-absolute translate-middle top-50 start-50">
        <form runat="server">
            <div>
                <label for="txtUsername">Usuario:</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPassword">Contraseña:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
        </form>
    </div>
</asp:Content>
