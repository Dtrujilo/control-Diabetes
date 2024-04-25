<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmCitas.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmCitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style>
        .form-group.with-separator {
            border-bottom: 1px solid #ccc;
            padding-bottom: 15px; /* Espacio adicional opcional */
            margin-bottom: 15px; /* Espacio adicional opcional */
        }

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
                <div class="form-group with-separator">
                    <div class="form-group">
                        <label for="fecha">Fecha de la cita:</label>
                        <asp:TextBox ID="txtfecha" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="nombre">Nombre del paciente:</label>
                    <asp:TextBox ID="txtnombre" runat="server" type="text" CssClass="form-control" placeholder="Escriba Nombre"></asp:TextBox>
                </div>
                
                <!-- Aquí puedes agregar más campos de historial médico utilizando checkboxes, inputs, select, etc. -->
                <h4>Motivo de la Cita</h4>
                <div class="form-group">
                    <asp:TextBox ID="txtmotivo" runat="server" type="text" CssClass="form-control" placeholder="Por favor, describa brevemente el motivo de su cita:"></asp:TextBox>
                </div>
                <br />
                <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false" onserverclick="btncreate_ServerClick" >
                    <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                    Guardar
                </button>
                <button id="btnupdate" type="button" runat="server" class="button is-warning has-text-white" visible="false" onserverclick="btnupdate_ServerClick" >
                    <i class="fa fa-edit" style="margin-right: 0.5em;"></i>
                    Editar
                </button>
                <button id="btndelete" type="button" runat="server" class="button is-danger has-text-white" visible="false" onserverclick="btndelete_ServerClick" >
                    <i class="fa fa-trash" style="margin-right: 0.5em;"></i>
                    Eliminar
                </button>
                <button id="btnvolver" type="button" runat="server" class="button is-dark has-text-white" visible="true" onserverclick="btnvolver_ServerClick" >
                    <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                    Volver
                </button>

            </div>
        </div>
    </div>

</asp:Content>
