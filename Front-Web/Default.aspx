﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Front_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div><h4>Usuario:  <asp:Label ID="lblUsuario" runat="server" Font-Bold="True"></asp:Label>           
        </h4>  
    </div>
    
    <div class="jumbotron">
        <h1>VENTAS ONLINE</h1>
        <p class="lead">Articulos Informaticos</p>
        
        <p><a href="Usuario" class="btn btn-primary btn-lg">Comprar  &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Ofertas del Mes</h2>
            <img src="Imagenes/1.jpeg" />
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Ver Mas &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Articulos mas Vendidos</h2>
            <img src="Imagenes/2.jpeg" />
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Ver Mas&raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Articulos Nuevos</h2>
            <img src="Imagenes/3.jpeg" />
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Ver Mas &raquo;</a>
            </p>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <h3 class="form-section">Articulos Ofertas COMPRE YAAAA!!!!!</h3>
            <div class="form-horizontal">
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GvArticulos" runat="server" AutoGenerateSelectButton="true" AutoGenerateColumns="true" class="table table-striped table-bordered table-hover" Width="100%">
                                <Columns>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
