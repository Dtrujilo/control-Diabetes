<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmTipoDiabetes.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmTipoDiabetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

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
    <div class="container mt-5">
        <div class="card" style="max-width: 600px; margin: 0 auto; background-color: #e6fffa;">
            <div class="card-header">
                <asp:Label runat="server" ID="lbltitulo" />
            </div>
            <div class="card-body">
                <div class="form-group">
                    <label for="nombre">Tipo de Diabetes:</label>
                    <asp:TextBox ID="txttipodiabetes" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"></asp:TextBox>
                </div>
                <br />
                <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false" onserverclick="btncreate_ServerClick">
                    <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                    Guardar
                </button>
                <button id="btnupdate" type="button" runat="server" class="button is-warning has-text-white" visible="false" onserverclick="btnupdate_ServerClick">
                    <i class="fa fa-edit" style="margin-right: 0.5em;"></i>
                    Editar
                </button>
                <button id="btndelete" type="button" runat="server" class="button is-danger has-text-white" visible="false" onserverclick="btndelete_ServerClick">
                    <i class="fa fa-trash" style="margin-right: 0.5em;"></i>
                    Eliminar
                </button>
                <button id="btnvolver" type="button" runat="server" class="button is-dark has-text-white" visible="true" onserverclick="btnvolver_ServerClick">
                    <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                    Volver
                </button>

            </div>
        </div>
    </div>

</asp:Content>
