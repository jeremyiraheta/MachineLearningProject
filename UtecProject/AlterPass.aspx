<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AlterPass.aspx.cs" Inherits="PRProject.AlterPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <center><div>
    <br />
    <br />
    Password actual:<br />
    <asp:TextBox ID="txtOldPass" TextMode="Password" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtOldPass" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator> 
    <br />
    <br />
    Password Nuevo<br />
    <asp:TextBox ID="txtPass1" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPass1" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>  
    <br />Confirmar Password<br />
    <asp:TextBox ID="txtPass2" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPass2" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>   
        <br /><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPass2" ControlToCompare="txtPass1" ErrorMessage="Los password deben coincidir" ForeColor="Red"></asp:CompareValidator>
    <br />
    <br />
    <asp:Button ID="btnChange" runat="server" Text="Cambiar" OnClick="btnChange_Click" />
        <br />
        <br />
        <asp:Literal ID="output" runat="server"></asp:Literal>
        <br />
        <br />
        </div></center>
</asp:Content>
