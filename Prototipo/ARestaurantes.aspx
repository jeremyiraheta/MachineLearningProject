<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ARestaurantes.aspx.cs" Inherits="Prototipo.ARestaurantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div style="padding: 55px 25% 37px">
        <h1>Agregar Restaurantes</h1>
        <br />
        <br />
        <table style="border:solid 2px;">
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
        <td><asp:TextBox ID="txtRname" runat="server" Width="100%"></asp:TextBox></td></tr>        
              
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label4" runat="server" Text="Referencia:"></asp:Label></td>
        <td>
            
            <asp:TextBox ID="txtReferencia" runat="server" Width="100%" TextMode="MultiLine" Height="59px"></asp:TextBox>
            
            </td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label6" runat="server" Text="Imagen de restaurante:"></asp:Label></td>
        <td>
            <asp:FileUpload ID="upload" runat="server" />
            </td></tr>
        </table>
        <div style="text-align: center; padding: 10px 10px 50px 10px;"><asp:Button ID="btnAdd" runat="server" Text="Agregar" OnClick="btnAdd_Click" />
            <br />
            <asp:Literal ID="output" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
