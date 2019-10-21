<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Prototipo.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div style="padding: 55px 25% 37px">
        <h1>Registro de usuario</h1>
        <br />
        <br />
        <table style="border:solid 2px;">
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label1" runat="server" Text="Nombre usuario:"></asp:Label></td>
        <td><asp:TextBox ID="txtUsername" runat="server" Width="100%"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label></td>
        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label2" runat="server" Text="Confirmar Password:"></asp:Label></td>
        <td><asp:TextBox ID="TextBox2" runat="server" Width="100%" TextMode="Password"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label3" runat="server" Text="Email"></asp:Label></td>
        <td><asp:TextBox ID="TextBox3" runat="server" Width="100%" TextMode="Email"></asp:TextBox></td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label4" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
        <td>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            </td></tr>        
        <tr><td style="padding:10px 20px 0px 20px"><asp:Label ID="Label6" runat="server" Text="Imagen de perfil:"></asp:Label></td>
        <td>
            <asp:Literal ID="imgname" runat="server"></asp:Literal>
            <asp:Button ID="btnSend" runat="server" Text="Subir" />
            </td></tr>
        </table>
        <div style="text-align: center; padding: 10px 10px 50px 10px;"><asp:Button ID="btnReg" runat="server" Text="Registrarme" /></div>
    </div>
</asp:Content>
