﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="GestionarPublicidad.aspx.vb" Inherits="Vista.GestorPublicidad" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- <script type="text/javascript" src="JS/ClienteValid.js"></script>-->

    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%= imgPreview.ClientId %>').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
                }
            }
            $("#fuImagen").change(function () {
                readURL(this);
            });
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid fondoGris">
        <br />
        <div id="alertvalid" runat="server" name="alertvalid" class="alert alert-danger  text-center" visible="false">
            <label runat="server" id="textovalid" class="text-danger"></label>
        </div>
        <div id="success" runat="server" name="success" class="alert alert-success  text-center" visible="false">
            <label id="lblsuccessmodUser" class="text-success"></label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary class">
                    <div class="panel-heading text-center">
                        <asp:Label ID="lblPanelModUser" runat="server" Text="Gestor Publicidad" Font-Size="24px" CssClass="TituloPanel"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />



        </div>


        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-sm" AllowPaging="True" Width="770px">
            <Columns>
                <asp:ButtonField CommandName="Select" ShowHeader="True" Text='<span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>'>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="Delete" ShowHeader="True" Text='<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>'>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="35px" />
                </asp:ButtonField>

                <asp:BoundField DataField="AlternateText" HeaderText="Título">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="350px" />
                </asp:BoundField>
                <asp:BoundField DataField="NavigateUrl" HeaderText="URL">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="350px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

        <asp:Button class="btn btn-primary mt-1" ID="btnNuevo" runat="server" Text="Nuevo" formnovalidate />

        <div class="form-group row mt-3">
            <div class="col-sm-8">
                <asp:Label runat="server" for="txtTitle">Texto:</asp:Label>
                <asp:TextBox ID="txtTitle" runat="server" class="form-control" Required="true" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-sm-8">
                <asp:Label runat="server" for="txtURL">URL:</asp:Label>
                <asp:TextBox ID="txtURL" runat="server" class="form-control" Required="true" MaxLength="150"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row mt-3">
            <div class="col-sm-8">
                <asp:Label runat="server" for="imgPreview">Imagen:</asp:Label><br />
                <asp:Image ID="imgPreview" runat="server" Width="200" accept="image/*" /><br />
                <asp:FileUpload ID="fuImagen" runat="server" onchange="readURL(this)" />
            </div>
        </div>

        <div class="form-group row mt-5">
            <div class="col-md-4">
                <asp:Button class="btn btn-primary" ID="btnGuardar" runat="server" Text="Guardar" />
            </div>
        </div>





    </div>



</asp:Content>




