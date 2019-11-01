<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="PRProject.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div style="padding: 55px 25% 37px">
        <h1>Registro de usuario</h1>
        <br />
        <br />
        <table style="border: solid 2px;">
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" Width="90%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUsername" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                    
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Minimo 5 letras, no use letras raras" ForeColor="Red" ControlToValidate="txtUsername" ValidationExpression="^(?=.{5,50}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?&lt;![_.])$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="90%">
                        </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtPassword" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                    </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label2" runat="server" Text="Confirmar Password:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPassword2" runat="server" Width="90%" TextMode="Password"></asp:TextBox><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtPassword" ErrorMessage="Los password deben coincidir" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="90%" TextMode="Email"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtEmail" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                    </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label7" runat="server" Text="Nombres:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="90%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label8" runat="server" Text="Apellidos:"></asp:Label></td>

                <td>
                    <asp:TextBox ID="txtApellidos" runat="server" Width="90%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellidos" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>                    
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label4" runat="server" Text="Fecha Nacimiento:"></asp:Label></td>
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
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px">
                    <asp:Label ID="Label6" runat="server" Text="Imagen de perfil:"></asp:Label></td>
                <td>
                    <asp:FileUpload ID="upload" runat="server" />
                </td>
            </tr>
        </table>
        <div style="text-align: center; padding: 10px 10px 50px 10px;">
            <asp:Button ID="btnReg" runat="server" Text="Registrarme" OnClick="btnReg_Click" />
            <br />
            <asp:Literal ID="output" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
