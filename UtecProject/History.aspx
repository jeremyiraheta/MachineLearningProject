<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="PRProject.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <h4 style="text-align:center;"><asp:Literal ID="output" runat="server"></asp:Literal></h4>
    <div id="logs" style="padding: 10px 10% 25px;" runat="server">
        <h1>Actividad
        </h1>
        <br />
        <br />
        <table style="border-style: solid; height: 100%; width: 80%;">
            <thead>
                <tr><td style="width: 189px;"><b>Username</b></td><td><b>Tipo</b></td><td style="width:200px"><b>Tabla</b></td><td><b>Fecha</b></td></tr>
            </thead>
            <tbody id="tbody" runat="server">

            </tbody>            
            </table>
        </div>
</asp:Content>
