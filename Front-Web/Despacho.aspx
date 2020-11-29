<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="Front_Web.Despacho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         
        <!--BEGIN TABS-->
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
                                    <span class="caption-subject bold uppercase">DESPACHO >></span>
                                </div>
                          <br />
                                <div class="inputs">
                                    <div class="btn-group btn-group-circle">
                                        <asp:LinkButton ID="btndespachar" runat="server" Text="  Procesar" Visible="false" CssClass="btn btn-default" OnClick="btndespachar_Click" />
                                        <asp:LinkButton ID="btncancelar" runat="server" Text="  Cancelar" Visible="false" CssClass="btn btn-default" OnClick="btncancelar_Click" />
                                    </div>
                                </div>
                            </div>
                            <br />
                              <br />
                            <div class="portlet-body form">
                                <div class="form-body form-horizontal">
                                    <!-- Begin one column window -->
                                    <asp:Panel ID="Paneltabla" runat="server" Visible="false">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <div class="col-md-4">
                                                        <label class="control-label col-md-4">ID Compra:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TxtCompra" runat="server" enabled="false" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                          </div>
                                               
                                                     <div class="col-md-4">
                                                        <label class="control-label col-md-4">Fecha:</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox ID="TxtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                            
                                                </div>
                                                  
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <br />
                                    <div class="row ">
                                        <div class="col-md-12">
                                            <h3 class="form-section">Compras Registrados</h3>
                                            <div class="form-horizontal">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="GvCompras" runat="server" AutoGenerateSelectButton="True" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover TablaFiltro" Width="100%" OnSelectedIndexChanged="GvCompras_SelectedIndexChanged">
                                                                <Columns>    
                                                                    <asp:BoundField DataField="IdCompra" HeaderText="id_compra" />
                                                                    <asp:BoundField DataField="Descripcion" HeaderText="descripcion" />
                                                                     <asp:BoundField DataField="IdCliente" HeaderText="id_cliente" />
                                                                     <asp:BoundField DataField="IdPersona" HeaderText="id_persona" />
                                                                     <asp:BoundField DataField="IdTipoEstado" HeaderText="id_tipo_estado" />
                                                                      <asp:BoundField DataField="IdTipoEntrega" HeaderText="id_tipo_entrega" />
                                                                     <asp:BoundField DataField="DescuentoTotal" HeaderText="descuento_total" />
                                                                     <asp:BoundField DataField="SumaTotal" HeaderText="sum_total" />
                                                                     <asp:BoundField DataField="FechaEntrega" HeaderText="fecha_entrega" />
                                                                     <asp:BoundField DataField="Estado" HeaderText="estado" />
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
                        <asp:AsyncPostBackTrigger ControlID="GvCompras" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btndespachar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
 
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
  
</asp:Content>
