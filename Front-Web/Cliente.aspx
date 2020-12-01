<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="Front_Web.Cliente" %>
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
                                <span class="caption-subject bold uppercase">REGISTRO >></span>
                            </div>
                         <div class="inputs">
                                <div class="btn-group btn-group-circle">
                                    <asp:LinkButton ID="btnGuardar" runat="server" Text="Guardar" Visible="true" CssClass="btn btn-default" OnClick="btnGuardar_Click" />
                                    <asp:LinkButton ID="btncancelar" runat="server" Text="Cancelar" Visible="true" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </div>

                        <div class="portlet-body form">
                            <div class="form-body form-horizontal">
                                <!-- Begin one column window -->
                                <asp:Panel ID="Paneltabla" runat="server" Visible="true">
                                    <div class="row">
                                        <div class="col-md-12">
                                            
                                               <h3 class="form-section">Datos del Cliente:</h3>
                                                 <br />
                                             <div class="form-group col-md-12">
                                                <div class="col-md-6">
                                                    <label class="control-label col-md-4">Nombres:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtNombre" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 

                                            </div>
                                            <div class="form-group col-md-12">
                                                
                                                  <div class="col-md-6">
                                                    <label class="control-label col-md-4">Apellido Paterno:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtPaterno" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                               <div class="col-md-6">
                                                    <label class="control-label col-md-4">Apellido Materno:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtMaterno" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                                <div class="form-group col-md-12">
                                                <div class="col-md-6">
                                                    <label class="control-label col-md-4">DNI:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDni" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                  <div class="col-md-6">
                                                    <label class="control-label col-md-4">Correo Electronico:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtCorreo" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="form-group col-md-12">
                                                <div class="col-md-6">
                                                    <label class="control-label col-md-4">Dirección:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtDireccion" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                               <div class="col-md-6">
                                                    <label class="control-label col-md-4">Referencia:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtReferencia" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
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
