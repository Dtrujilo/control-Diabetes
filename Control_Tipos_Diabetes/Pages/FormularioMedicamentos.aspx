<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="FormularioMedicamentos.aspx.cs" Inherits="Control_Tipos_Diabetes.Pages.FormularioMedicamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-header {
            background-color: #20c997; /* Color de fondo azul */
            color: #fff; /* Color del texto blanco */
            padding: 10px; /* Añadir relleno al encabezado */
            font-size: 20px; /* Tamaño de fuente */
            font-weight: bold; /* Negrita */
        }
    </style>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container my-4">
        <div class="card text-black" style="margin: 0 auto; max-width: 600px; background-color: #e6fffa">
            <div class="card-header">
                <h2 class="card-title text-white text-center" style="text-transform: uppercase; font-weight: 700;">Medicamentos Recetados</h2>
            </div>
            <div class="card-body">
                <button id="btnsave" type="button" runat="server" class="button is-primary has-text-white">
                    <i class="fa fa-regular fa-floppy-disk" style="margin-right: 0.5em;"></i>
                    Crear
                </button>
            </div>
            <br />
            <div class="container">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvusuarios" CssClass="table table-borderless table-hover table-sm">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones del administrador">
                                <ItemTemplate>
                                    <button id="btnread" type="button" runat="server" class="button form-control-sm is-info has-text-white">
                                        <i class="fa fa-eye" style="margin-right: 0.5em;"></i>
                                        Leer
                                    </button>
                                    <button id="btnupdate" type="button" runat="server" class="button form-control-sm is-warning has-text-white">
                                        <i class="fa fa-pencil-alt" style="margin-right: 0.5em;"></i>
                                        Editar
                                    </button>
                                    <button id="btndelete" type="button" runat="server" class="button form-control-sm is-danger has-text-white">
                                        <i class="fa fa-trash-alt" style="margin-right: 0.5em;"></i>
                                        Eliminar
                                    </button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
