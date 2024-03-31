<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster/MP.Master" AutoEventWireup="true" CodeBehind="CrudFrmHistorialMedico.aspx.cs" Inherits="Control_Tipos_Diabetes.CRUD.CrudFrmHistorialMedico" %>
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
        <div class="card text-black" style="margin: 0 auto; max-width: 800px; background-color: #e6fffa">
            <div class="card-header">
                <asp:Label runat="server" ID="lbltitulo" />
            </div>
            <div class="card-body">
                <div class="historial-medico container-sm">
                    <div class="row justify-content-center opciones">
                        <h5 class="col-8"></h5>
                        <div class="col text-center" style="font-weight: 700; font-size: 1.2rem">
                            <label class="col-5 encabezado">
                                Si
                            </label>
                            <label class="col-5 encabezado">
                                No
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha experimentado un aumento notable en la sed recientemente?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="AumentoSed" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="AumentoSed" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha notado usted que orina con más frecuencia de lo habitual?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="OrinaFrecuente" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="OrinaFrecuente" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Se siente usted constantemente cansado o fatigado?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="Fatiga" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="Fatiga" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha experimentado usted visión borrosa o dificultad para enfocar con claridad?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="VisionBorrosa" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="VisionBorrosa" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha notado que las heridas tardan más de lo normal en sanar?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="HeridasLentas" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="HeridasLentas" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha sido diagnosticado previamente con alguna enfermedad cardíaca?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="EnfermedadCardiaca" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="EnfermedadCardiaca" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Tiene usted un historial de presión arterial elevada?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="PresionAlta" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="PresionAlta" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha sido diagnosticado previamente con niveles altos de colesterol?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="ColesterolAlto" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="ColesterolAlto" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Tiene algún miembro de su familia cercana que haya sido diagnosticad con diabetes?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="FamiliarDiabetico" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="FamiliarDiabetico" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Práctica usted ejercicio regularmente?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="RealizaEjercicio" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="RealizaEjercicio" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-3 justify-content-center opciones">
                        <label class="col-8" for="FrecuenciaEjercicio">¿Con qué frecuencia realiza usted ejercicio físico?</label>
                        <div class="col">
                            <asp:TextBox ID="FrecuenciaEjercicio" runat="server" nombre="FrecuenciaEjercicio" type="text" class="form-control mb-2" placeholder="Ingrese un valor"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Consume usted alimentos que contienen azúcares con regularidad?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="ComeAzucares" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="ComeAzucares" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha notado algún cambio reciente en su apetito, ya sea un aumento o una disminución?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="CambioApetito" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="CambioApetito" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Ha sido diagnosticada previamente con diabetes gestacional durante el embarazo?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="DiabetesGestacional" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="DiabetesGestacional" value="0" class="form-check-input">
                            </label>
                        </div>
                    </div>
                    <div class="row mt-4 justify-content-center opciones">
                        <h5 class="col-8">¿Su bebé nacio un un peso superior al promedio o con sobrepeso?</h5>
                        <div class="col text-center">
                            <label class="col-5">
                                <input type="radio" name="BebeSobrepeso" value="1" class="form-check-input">
                            </label>
                            <label class="col-5">
                                <input type="radio" name="BebeSobrepeso" value="0" class="form-check-input">
                            </label>
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
    </div>
</asp:Content>
