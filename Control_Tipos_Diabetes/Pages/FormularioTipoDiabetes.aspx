<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="FormularioTipoDiabetes.aspx.cs" Inherits="Control_Tipos_Diabetes.Pages.FormularioTipoDiabetes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Tipo de Diabetes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .card-header {
            background-color: #20c997; /* Color de fondo azul */
            color: #fff; /* Color del texto blanco */
            padding: 10px; /* Añadir relleno al encabezado */
            font-size: 20px; /* Tamaño de fuente */
            font-weight: bold; /* Negrita */
        }

        .filter {
            position: relative;
            display: inline-block;
            text-align: right;
            margin-right: 10px;
            cursor: pointer;
        }

        .options {
            position: absolute;
            background-color: #f9f9f9;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
            min-width: 100px;
            right: 0;
        }

        .option {
            padding: 12px 16px;
            text-decoration: none;
            display: block;
            cursor: pointer;
        }

            .option:hover {
                background-color: #f1f1f1;
            }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container mt-5">
        <div class="card" style="max-width: 800px; margin: 0 auto; background-color: #e6fffa;">
            <div class="card-header">
                Listado Tipos de Diabetes
            </div>
            <div class="card-body">
                <button id="btnsave" type="button" runat="server" class="button is-primary has-text-white" onserverclick="btnsave_ServerClick">
                    <i class="fa fa-regular fa-floppy-disk" style="margin-right: 0.5em;"></i>
                    Crear
                </button>
            </div>
            <div class="container row">
                <div class="col align-self-start">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm" placeholder="Buscar por nombre"></asp:TextBox>
                </div>

                <div class="col align-self-end">
                    <asp:Button Text="Buscar" runat="server" ID="btnSearch" CssClass="btn btn-primary btn-sm" OnClick="btnSearch_Click" />
                </div>
            </div>


            <div class="filter">
                <i class="fa-solid fa-filter" onclick="toggleOptions(event)"></i>
                <div class="options" style="display: none;">
                    <ul>
                        <li>
                            <asp:Button Text="Ordenar por tipo" runat="server" CssClass="button is-white" OnClick="Unnamed_Click" /></li>
                        <li>
                            <asp:Button Text="Ordenar por ID" ID="btnordenarID"  runat="server" CssClass="button is-white" OnClick="btnordenarID_Click" /></li>
                    </ul>

                </div>
            </div>
    

            <div class="container">
                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gvusuarios" CssClass="table table-borderless table-hover table-sm"
                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvusuarios_PageIndexChanging">
                        <Columns>

                            <asp:TemplateField HeaderText="Opciones del administrador">
                                <ItemTemplate>
                                    <button id="btnread" type="button" runat="server" class="button form-control-sm is-info has-text-white"
                                        onserverclick="btnread_ServerClick">
                                        <i class="fa fa-eye" style="margin-right: 0.5em;"></i>
                                        Leer
                                    </button>
                                    <button id="btnupdate" type="button" runat="server" class="button form-control-sm is-warning has-text-white"
                                        onserverclick="btnupdate_ServerClick">
                                        <i class="fa fa-pencil-alt" style="margin-right: 0.5em;"></i>
                                        Editar
                                    </button>
                                    <button id="btndelete" type="button" runat="server" class="button form-control-sm is-danger has-text-white"
                                        onserverclick="btndelete_ServerClick">
                                        <i class="fa fa-trash-alt" style="margin-right: 0.5em;"></i>
                                        Eliminar
                                    </button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NextPrevious" NextPageText="Siguiente" PreviousPageText="Anterior" />
                    </asp:GridView>
                </div>
            </div>


        </div>
    </div>
    <script>
        function toggleOptions(event) {
            const optionsDiv = event.currentTarget.nextElementSibling;
            if (optionsDiv.style.display === "none") {
                optionsDiv.style.display = "block";
            } else {
                optionsDiv.style.display = "none";
            }
        }
    </script>

</asp:Content>
