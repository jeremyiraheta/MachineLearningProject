<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AMapa.aspx.cs" Inherits="Prototipo.AMapa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/p5.js"></script>
  <script src="js/p5.dom.js"></script>
  <script src="js/p5.sound.js"></script>
  <script src="js/sketch.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div style="text-align:center; padding-top:30px;" id="sketh"></div><p style="display:block;border: 2px solid; border-radius:30px; padding:20px; width:100px;height:100px;">Modificar puntos</p>
</asp:Content>
