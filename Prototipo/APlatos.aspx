<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="APlatos.aspx.cs" Inherits="Prototipo.APlatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div style="padding: 55px 25% 37px">
        <h1>Agregar platillo</h1>
        <br />
        <br />
        <table style="border:solid 2px;">
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
        <td><asp:TextBox ID="txtDname" runat="server" Width="100%"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label5" runat="server" Text="Restaurante:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddRestaurantes" Width="100%" runat="server">
            </asp:DropDownList>
            </td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label2" runat="server" Text="Categoria:"></asp:Label></td>
        <td>
            <asp:DropDownList ID="ddCategorias" Width="100%" runat="server">
            </asp:DropDownList>
            </td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label3" runat="server" Text="Precio: "></asp:Label></td>
        <td><asp:TextBox ID="txtPrice" runat="server" Width="100%" TextMode="Number"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label4" runat="server" Text="Descripcion:"></asp:Label></td>
        <td>
            
            <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" TextMode="MultiLine" Height="59px"></asp:TextBox>
            
            </td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label6" runat="server" Text="Imagen de platillo:"></asp:Label></td>
        <td>
            <asp:Literal ID="imgname" runat="server"></asp:Literal>
            <asp:Button ID="btnSend" runat="server" Text="Subir" />
            </td></tr>
        </table>
        <div style="text-align: center; padding: 10px 10px 50px 10px;"><asp:Button ID="btnAdd" runat="server" Text="Agregar" /></div>
    </div>
</asp:Content>
