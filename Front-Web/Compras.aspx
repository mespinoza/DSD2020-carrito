<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="Front_Web.Compras" %>
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
                                    <span class="caption-subject bold uppercase">PROCESO DE COMPRAS >></span>
                                </div>
                          <br />
                                <div class="inputs">
                                    <div class="btn-group btn-group-circle">
                                         <asp:LinkButton ID="LinkButton1" runat="server" Text="  Nuevo" Visible="true" CssClass="btn btn-default" />
                                        <asp:LinkButton ID="btndespachar" runat="server" Text="  Modificar" Visible="true" CssClass="btn btn-default" />
                                        <asp:LinkButton ID="btncancelar" runat="server" Text="  Cancelar" Visible="true" CssClass="btn btn-default" />
                                        
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
                                                        <label class="control-label col-md-4">Tipo Entrega:</label>
                                                        <div class="col-md-8">
                                                            <asp:DropDownList ID="DDLTipoEntrega" runat="server">
                                                                 <asp:ListItem Value="1">DELIVERY</asp:ListItem>
                                                              <asp:ListItem Value="2">PRESENCIAL</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                     <div class="col-md-4">
                                                     <label class="control-label col-md-4">CUPO:</label>
                                                        <div class="col-md-8">
                                                             <asp:TextBox ID="TxtCupo" runat="server" enabled="true" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                            
                                                </div>
                                      
                                                  
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <h3 class="form-section">Lista de Articulos</h3>
                                            <div class="form-horizontal">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GvArticulos" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover" Width="100%" >
                                                                <Columns>    
                                                         
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

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
