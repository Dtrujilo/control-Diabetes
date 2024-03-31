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
                <div class="is-flex justify-content-end">
                    <button type="button" onclick="agregarMedicamento()" class="button is-primary has-text-white mt-3">Agregar Medicamento</button>
                </div>
                <div class="form-group contenedor-medic mt-5" id="medicamentosRecetados">
                    <label class="col-4">Medicamento:</label>
                    <select class="custom-select mr-sm-2 form-control justify" name="medicamento" id="medicamento">
                        <option selected>Elija el medicamento a recetar:</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                    <div class="form-group row mt-2">
                        <div class="form-group col">
                            <label class="col">Medida:</label>
                            <input type="text" name="medida" id="medida" value="" class="col-12 form-control" />
                        </div>
                        <div class="form-group col">
                            <label class="col">Horario:</label>
                            <input type="time" name="horario" id="horario" value="" class="col-12 form-control" />
                        </div>
                    </div>
                </div>
                <br />
                <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false">
                    <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                    Guardar
                </button>
                <button id="btnupdate" type="button" runat="server" class="button is-warning has-text-white" visible="false">
                    <i class="fa fa-edit" style="margin-right: 0.5em;"></i>
                    Editar
                </button>
                <button id="btndelete" type="button" runat="server" class="button is-danger has-text-white" visible="false">
                    <i class="fa fa-trash" style="margin-right: 0.5em;"></i>
                    Eliminar
                </button>
                <button id="btnvolver" type="button" runat="server" class="button is-dark has-text-white" visible="true">
                    <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                    Volver
                </button>
            </div>
        </div>
    </div>

    <script>
        function agregarMedicamento() {
            var nuevoDiv = document.getElementById('medicamentosRecetados').cloneNode(true);

            nuevoDiv.querySelector('#medicamento').selectedIndex = 0;
            nuevoDiv.querySelector('#medida').value = '';
            nuevoDiv.querySelector('#horario').value = '';

            document.querySelector('.contenedor-medic').appendChild(nuevoDiv);
        }
    </script>

</asp:Content>
