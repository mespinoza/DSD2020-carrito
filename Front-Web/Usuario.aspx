<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Front_Web.Usuario" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Login.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>

    <div id="logreg-forms">
        <form id="form2" runat="server" class="form-signin">
            <h1 class="h3 mb-3 font-weight-normal" style="text-align: center">Iniciar</h1>

            <label>Correo:</label>
            <asp:TextBox ID="txt_correo"  runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>
            <label>Contraseña:</label>
            <asp:TextBox TextMode="Password" ID="txt_contraseña" runat="server" Enabled="true" CssClass="form-control"></asp:TextBox>

            <br />
            <asp:Button CssClass="btn btn-success btn-block" ID="btn_ingresar" runat="server" OnClick="btn_ingresar_Click" Text="Ingresar" />

            <hr />
            <!-- <p>Don't have an account!</p>  -->
            <asp:Button  CssClass="btn btn-primary btn-block" ID="btn_registrarse" runat="server" Text="Registrarse" />
  
        </form>

 

    </div>

</body>

</html>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


</asp:Content>--%>
