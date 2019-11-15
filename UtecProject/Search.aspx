<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="PRProject.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div id="userlist" style="padding: 10px 5% 25px;" class="hidden" runat="server">
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
