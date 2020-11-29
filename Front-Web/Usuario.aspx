<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Front_Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-12">
            <!--BEGIN TABS-->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="portlet light bordered">
                        <div class="portlet-title tabbable-line">
                            <div class="caption font-green-sharp">
                                <i class="icon-share font-green-sharp"></i>
                                <br />
                                <span class="caption-subject bold uppercase">INGRESO >></span>
                            </div>
                            <br />
                            <div class="inputs">
                                <div class="btn-group btn-group-circle">
                                    <asp:LinkButton ID="btndespachar" runat="server" Text="  Procesar" Visible="false" CssClass="btn btn-default" />
                                    <asp:LinkButton ID="btncancelar" runat="server" Text="  Cancelar" Visible="false" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="portlet-body form">
                            <div class="form-body form-horizontal">
                                <!-- Begin one column window -->
                                <asp:Panel ID="Paneltabla" runat="server" Visible="true">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Correo:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox3" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Clave:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox4" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>


                                            </div>
                                                    <br />
                                               <h3 class="form-section">Datos Personales</h3>
                                                 <br />
                                            <div class="form-group">
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Nombre:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox1" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="col-md-4">
                                                    <label class="control-label col-md-4">Apellido Materno:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox2" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                               <div class="col-md-4">
                                                    <label class="control-label col-md-4">Apellido Paterno:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox5" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                                      <div class="form-group">
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Dni:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox6" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="col-md-4">
                                                    <label class="control-label col-md-4">Correo:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox7" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                               <div class="col-md-4">
                                                    <label class="control-label col-md-4">Referencia:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TextBox8" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <br />
          

                            </div>

                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
