<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmDiagnosticoDiabetes.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmDiagnosticoDiabetes" %>

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
                        <label for="nombrepaciente">Nombre del paciente:</label>
                        <asp:TextBox ID="txtnombrepaciente" runat="server" type="text" class="form-control" placeholder="Escriba el nombre del paciente"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="glucosaAyuno">Nivel de glucosa en plasma en ayunas:</label>
                    <asp:TextBox ID="txtayunas" runat="server" type="number" class="form-control" placeholder="Ingrese el nivel de glucosa"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="glucosa2h">Nivel aleatoria de glucosa en plasma:</label>
                    <asp:TextBox ID="txtaleatorio" runat="server" type="number" class="form-control" placeholder="Ingrese el nivel de glucosa"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="hbA1c">Nivel de Hemoglobina A1c (%):</label>
                    <asp:TextBox ID="txthbA1c" runat="server" type="number" class="form-control" placeholder="Ingrese el nivel de HbA1c"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="glucosaAzar">Nivel de sobrecarga oral de glucosa:</label>
                    <asp:TextBox ID="txtsobrecargo" runat="server" type="number" class="form-control" placeholder="Ingrese el nivel de glucosa"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="glucosaAzar">Nivel de tolerancia oral a la glucosa:</label>
                    <asp:TextBox ID="txttolerancia" runat="server" type="number" class="form-control" placeholder="Ingrese el nivel de glucosa"></asp:TextBox>
                </div>
             
                <br />

                <button id="btncreate" type="button" runat="server" class="button is-primary has-text-white" visible="false" onserverclick="btncreate_ServerClick">
                    <i class="fa fa-save" style="margin-right: 0.5em;"></i>
                    Guardar
                </button>
               <%-- <button id="btnupdate" type="button" runat="server" class="button is-warning has-text-white" visible="false" onserverclick="btnupdate_ServerClick">
                    <i class="fa fa-edit" style="margin-right: 0.5em;"></i>
                    Editar
                </button>
                <button id="btndelete" type="button" runat="server" class="button is-danger has-text-white" visible="false" onserverclick="btndelete_ServerClick">
                    <i class="fa fa-trash" style="margin-right: 0.5em;"></i>
                    Eliminar
                </button>--%>
                <button id="btnvolver" type="button" runat="server" class="button is-dark has-text-white" visible="true" onserverclick="btnvolver_ServerClick">
                    <i class="fa fa-arrow-left" style="margin-right: 0.5em;"></i>
                    Volver
                </button>

            </div>
        </div>
    </div>

</asp:Content>
