<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PRProject.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden{
            display:none;
        }        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <h4 style="text-align:center;"><asp:Literal ID="output" runat="server"></asp:Literal></h4>
    <div id="portrait" class="hidden" style="padding: 55px 25% 37px;" runat="server">
        <h1>Datos de Usuario: 
            <asp:Literal ID="username" runat="server"></asp:Literal>
        </h1>
        <br />
        <br />
        <table style="border-style: solid; border-color: inherit; border-width: 2px; width: 434px;">
            <tr>
                <td style="padding: 10px 20px 0px 20px; text-align:center;" colspan="2">
                   <div id="image-upload">
                        <label for="file-input">
                        <asp:Image ID="img" runat="server" Height="300px" Width ="400px"/>
                            <asp:FileUpload ID="upload" runat="server" Enabled="False" CssClass="hidden" />
                        </label>
                    </div>
                    </td>
            </tr>

            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label1" runat="server" Text="Permisos:"></asp:Label></td>
                <td>
                    <asp:CheckBox ID="chkAdmin" runat="server" Text="Administrador" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="100%"  ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label3" runat="server" Text="Apellido:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label4" runat="server" Text="Correo:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label5" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtBirth" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label6" runat="server" Text="Visitas:"></asp:Label></td>
                <td>
                    <asp:Label ID="lcount" runat="server" Text="0"></asp:Label>
                 </td>
            </tr>            
        </table>
         <div id="editcontrols" style="text-align:center;" runat="server">

        </div>
        </div>

    <div>
    </div>
    <div id="userlist" style="padding: 10px 10% 25px;" class="hidden" runat="server">
        <h1>Listado de usuarios
        </h1>
        <br />
        <br />
        <table style="border-style: solid; height: 100%; width: 80%;">
            <thead>
                <tr><td style="width: 189px;"><b>Username</b></td><td><b>Tipo</b></td><td style="width:200px"><b>Correo</b></td><td><b>Edicion</b></td></tr>
            </thead>
            <tbody id="tbody" runat="server">

            </tbody>            
            </table>
        </div>
</asp:Content>
