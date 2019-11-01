<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Locales.aspx.cs" Inherits="PRProject.Locales" %>
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
        <h1>Datos de Restaurante: 
            <asp:Literal ID="rest" runat="server"></asp:Literal>
        </h1>
        <br />
        <br />
        <table style="border-style: solid; border-color: inherit; border-width: 2px; width: 434px;">
            <tr>
                <td style="padding: 10px 20px 0px 20px; text-align:center;" colspan="2">
                    <asp:Image ID="img" runat="server" Height="300px" Width ="400px"/>
                    </td>
            </tr>

            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 25%">
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="100%"  ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="padding: 10px 20px 0px 20px;width:25%">
                    <asp:Label ID="Label5" runat="server" Text="Referencia:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtReferencia" runat="server" Width="100%" ReadOnly="True" Height="53px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="padding: 10px 20px 0px 20px;width: 25%">
                    <asp:Label ID="Label6" runat="server" Text="Rate:"></asp:Label></td>
                <td>
                    <asp:Label ID="lrate" runat="server" Text="0"></asp:Label>
                 </td>
            </tr>
        </table>
        </div>

    <div>
    </div>
    <div id="userlist" style="padding: 10px 5% 25px;" class="hidden" runat="server">
        <h1>Listado de Restaurantes
        </h1>
        <br />
        <br />
        <table style="border-style: solid; height: 100%; width: 90%;">
            <thead>
                <tr><td><b>Imagen</b></td><td style="width: 189px;"><b>Nombre</b></td><td style="width:200px"><b>Referencia</b></td><td style="width:10%"><b>Rate</b></td><td id="edicion" runat="server"><b>Edicion</b></td></tr>
            </thead>
            <tbody id="tbody" runat="server">

            </tbody>            
            </table>
        </div>
</asp:Content>
