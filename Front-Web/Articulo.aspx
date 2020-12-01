<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articulo.aspx.cs" Inherits="Front_Web.Articulo" %>

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
                                <span class="caption-subject bold uppercase">MANTENIMIENTO ARTICULOS >></span>
                            </div>
                            <br />
                            <div class="inputs"> 

                                <div class="btn-group btn-group-circle">
                                    <asp:LinkButton ID="BtnNuevo" runat="server" Text="  Nuevo" Visible="true" CssClass="btn btn-default" OnClick="BtnNuevo_Click" />
                                    <asp:LinkButton ID="BtnGrabar" runat="server" Text="  Grabar" Visible="false" CssClass="btn btn-default"  OnClick="BtnGrabar_Click"/>
                                    <asp:LinkButton ID="btncancelar" runat="server" Text="  Cancelar" Visible="false" CssClass="btn btn-default"  OnClick="btncancelar_Click"/>

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
                                                    <label class="control-label col-md-4">Descripción:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TxtDescripcion" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Categoria:</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="DDLCategoria" runat="server">
                                                            <asp:ListItem Value="1">GAMERS</asp:ListItem>
                                                            <asp:ListItem Value="2">OFERTA</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Stock:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="TxtStock" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="form-group">

                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Precio:</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtPRecio" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="control-label col-md-4">Estado:</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                                            <asp:ListItem Value="1">ACTIVO</asp:ListItem>
                                                            <asp:ListItem Value="0">DESACTIVO</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <br />
                                <div class="row ">
                                    <div class="col-md-12">
                                        <h3 class="form-section">Articulos Registrados</h3>
                                        <div class="form-horizontal">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="GvArticulos" runat="server" AutoGenerateSelectButton="false" AutoGenerateColumns="true" class="table table-striped table-bordered table-hover" Width="100%">
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
                    <asp:AsyncPostBackTrigger ControlID="BtnNuevo" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btncancelar" EventName="Click" />
                     <asp:AsyncPostBackTrigger ControlID="BtnGrabar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
