<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmMedicamentos.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmMedicamentos" %>

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
                <asp:Label runat="server" ID="lbltitulo" />
            </div>
            <div class="card-body">
                <div class="form-group mt-2">
                    <label class="col-4">Nombre del Medicamento:</label>
                    <asp:TextBox ID="txtnombreMedicamento" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Nombre del Medicamento"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label class="col-4">Medida:</label>
                    <asp:TextBox ID="txtMedida" runat="server" type="text" CssClass="form-control" placeholder="Medida a Recetar"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label class="col-4">Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" type="text" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label class="col">Tipo de Diabetes:</label>
                    <asp:TextBox ID="txtTipoDiabetes" runat="server" type="text" CssClass="form-control" placeholder="Escriba el Tipo de Diabetes"/>
                </div>
            </div>
            <br />
            <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false" onserverclick="btncreate_ServerClick">
                <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                Guardar
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

    <script>
        //function agregarMedicamento() {
        //    var nuevoDiv = document.getElementById('medicamentosRecetados').cloneNode(true);

        //    nuevoDiv.querySelector('#medicamento').selectedIndex = 0;
        //    nuevoDiv.querySelector('#medida').value = '';
        //    nuevoDiv.querySelector('#horario').value = '';

        //    document.querySelector('.contenedor-medic').appendChild(nuevoDiv);
        //}
    </script>
</asp:Content>
