<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Prototipo.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <center><div>
    <br />
    <br />
    Usuario<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    Password<br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>    
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Logear" OnClick="Button1_Click" /></div></center>
</asp:Content>
