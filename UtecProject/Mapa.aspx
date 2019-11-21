<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="PRProject.Mapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/p5.js"></script>
  <script src="js/p5.dom.js"></script>
  <script src="js/p5.sound.js"></script>
  <script src="js/sketch.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <h4 style="text-align:center;"><asp:Literal ID="output" runat="server"></asp:Literal></h4>
    <div style="text-align:center; padding-top:30px;" id="sketh"></div>
    <div id="edit" runat="server"></div>
    <div class="rounded" style="margin-left:30%;margin-right;margin-top:50px;display:table;">
        <table>
            <thead><tr>
                <td style="width:200px"><b>Nombre</b></td><td><b>X</b></td><td><b>Y</b></td><td style="width:100px"><b>Edicion</b></td>
                   </tr></thead>
            <tbody>
                <asp:Literal ID="table" runat="server"></asp:Literal>
            </tbody>
        </table>        
    </div>
</asp:Content>
