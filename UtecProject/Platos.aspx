<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="PRProject.Platos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden{
            display:none;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <asp:Literal ID="output" runat="server"></asp:Literal>
    <div id="portrait" class="hidden" style="padding: 55px 25% 37px;" runat="server">
        <h1>Datos de Platillo: 
            <asp:Literal ID="cdish" runat="server"></asp:Literal>
        </h1>
        <br />
        <br />
        <table style="border-style: solid; border-color: inherit; border-width: 2px; width: 434px;">
            <tr>
                <td style="padding: 10px 20px 0px 20px; text-align:center;" colspan="2">
                    <asp:Image ID="img" runat="server" />
                    </td>
            </tr>

            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="100%"  ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label2" runat="server" Text="Restaurante:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddRestaurantes" runat="server" Height="16px" Width="188px">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label3" runat="server" Text="Tipo:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddTipos" runat="server" Height="16px" Width="188px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label4" runat="server" Text="Precio:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label5" runat="server" Text="Descripcion:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" ReadOnly="True" Height="53px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label6" runat="server" Text="Rate:"></asp:Label></td>
                <td>
                    <asp:Label ID="lrate" runat="server" Text="0"></asp:Label>
                 </td>
            </tr>
        </table>
        </div>

    <div>
    </div>
    <div id="userlist" style="padding: 10px 5% 25px;" class="shidden" runat="server">
        <h1>Listado de Platillos
        </h1>
        <br />
        <br />
        <table style="border-style: solid; height: 100%; width: 90%;">
            <thead>
                <tr><td><b>Imagen</b></td><td style="width: 189px;"><b>Nombre</b></td><td style="width:80px"><b>Tipo</b></td><td style="width:150px"><b>Restaurante</b></td><td><b>Precio</b></td><td id="edition" runat="server"><b>Edicion</b></td></tr>
            </thead>
            <tbody id="tbody" runat="server">

            </tbody>            
            </table>
        </div>
</asp:Content>
