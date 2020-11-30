<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="Front_Web.Despacho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--Bootstrap y Jquery-->
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap-theme.min.css">
    <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script type="text/javascript" src='https://maps.google.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyD3jSDrS6TT_P09guUL7njN4TCo6vPNjls'></script>
    <!--Complementos del Plugin-->
    <script src="dist/locationpicker.jquery.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .pac-container {
            z-index: 99999;
        }
    </style>

    <div class="row">
        <div class="col-md-12">
  
            <!--BEGIN TABS-->
            <div class="col-md-4">

                <button data-target="#us6-dialog" data-toggle="modal">
                    <span class="glyphicon glyphicon-map-marker"></span><span id="ubicacion">Seleccionar Ubicación</span>
                </button>
                <div id="us6-dialog" class="modal fade">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">Ubicación del Cliente</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-horizontal" style="width: 550px">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Dirección:</label>

                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TxtDireccion" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Radio:</label>

                                        <div class="col-sm-5">
                                            <asp:TextBox ID="TxtRadio" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="us3" style="width: 100%; height: 400px;"></div>
                                    <div class="clearfix">&nbsp;</div>
                                    <div class="m-t-small">
                                        <label class="p-r-small col-sm-1 control-label">Lat.:</label>

                                        <div class="col-sm-3">

                                            <asp:TextBox ID="TextLat" CssClass="form-control" runat="server"></asp:TextBox>

                                        </div>
                                        <label class="p-r-small col-sm-2 control-label">Long.:</label>

                                        <div class="col-sm-3">
                                            <asp:TextBox ID="TxtLon" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <script>
                                        $('#us3').locationpicker({
                                            location: {
                                                latitude: -12.206968,
                                                longitude: -77.015317
                                            },
                                            radius: 300,
                                            inputBinding: {
                                            latitudeInput: $('#<%=TextLat.ClientID%>'),
                                            longitudeInput: $('#<%=TxtLon.ClientID%>'),
                                            radiusInput: $('#<%=TxtRadio.ClientID%>'),
                                            locationNameInput: $('#<%=TxtDireccion.ClientID%>')

                                        },
                                        enableAutocomplete: true,
                                            onchanged: function (currentLocation, radius, isMarkerDropped) {
                                                // Uncomment line below to show alert on each Location Changed event
                                                //alert("Location changed. New location (" + currentLocation.latitude + ", " + currentLocation.longitude + ")");
                                            }
                                    });
                                        $('#us6-dialog').on('shown.bs.modal', function () {
                                            $('#us3').locationpicker('autosize');
                                        });
                                      </script>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>              
                                <asp:LinkButton ID="BtnUbicacion" runat="server" Text="  Seleccionar"  CssClass="btn btn-default" OnClick="BtnUbicacion_Click" />
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                <!-- /.modal -->
            </div>
            <div class="col-md-8">
                
                <div class="col-md-8">
                    <strong><asp:Label ID="LblDireccion" runat="server" Text="" Visible="false" ></asp:Label></strong>
                </div>
            </div>

        </div>
    </div>
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
                                                        <asp:TextBox ID="TxtCompra" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
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
                                                                <asp:BoundField DataField="IdPersonal" HeaderText="id_persona" />
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
