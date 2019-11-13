<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="changepass.ascx.cs" Inherits="PRProject.changepass" %>
<asp:Label ID="Label1" runat="server" Text="Password actual"></asp:Label><br />
<asp:TextBox ID="txtoldpass" runat="server" TextMode="Password" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="#CC0000" ControlToValidate="txtoldpass"></asp:RequiredFieldValidator><br />
<asp:Label ID="Label2" runat="server" Text="Nuevo password"></asp:Label><br />
<asp:TextBox ID="txtnewpass" runat="server" TextMode="Password" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="#CC0000" ControlToValidate="txtnewpass"></asp:RequiredFieldValidator><br />
<asp:Label ID="Label3" runat="server" Text="Confirmar password"></asp:Label><br />
<asp:TextBox ID="txtnewpass2" runat="server" TextMode="Password" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="#CC0000" ControlToValidate="txtnewpass2"></asp:RequiredFieldValidator><br />
<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Deben coincidir" ControlToCompare="txtnewpass2" ControlToValidate="txtnewpass" ForeColor="#CC0000"></asp:CompareValidator>
