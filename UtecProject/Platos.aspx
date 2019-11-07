<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="PRProject.Platos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hidden{
            display:none;
        }    
        .image-upload img
        {
            width: 30px;
            cursor: pointer;
        }    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <h4 style="text-align:center;"><asp:Literal ID="output" runat="server"></asp:Literal></h4>
    <div id="portrait" class="hidden" style="padding: 55px 25% 37px;" runat="server">
        <h1>Datos de Platillo: 
            <asp:Literal ID="cdish" runat="server"></asp:Literal>
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
                    <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="100%"  ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label2" runat="server" Text="Restaurante:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddRestaurantes" runat="server" Height="16px" Width="188px" Enabled="False">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label3" runat="server" Text="Tipo:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddTipos" runat="server" Height="16px" Width="188px" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label4" runat="server" Text="Precio($):"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPrecio" runat="server" Width="100%" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label5" runat="server" Text="Descripcion:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="100%" ReadOnly="True" Height="53px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
             <tr>
                <td style="padding: 10px 20px 0px 20px;width: 125px">
                    <asp:Label ID="Label6" runat="server" Text="Rate:"></asp:Label></td>
                <td>
                    <div class="txt-center">  
        <div class="rating">
            <input id="star5" name="star" type="radio" value="5" class="radio-btn hide" runat="server" />
            <label for="star5" >☆</label>
            <input id="star4" name="star" type="radio" value="4" class="radio-btn hide" runat="server" />
            <label for="star4" >☆</label>
            <input id="star3" name="star" type="radio" value="3" class="radio-btn hide" runat="server" />
            <label for="star3" >☆</label>
            <input id="star2" name="star" type="radio" value="2" class="radio-btn hide" runat="server" />
            <label for="star2" >☆</label>
            <input id="star1" name="star" type="radio" value="1" class="radio-btn hide" runat="server" />
            <label for="star1" >☆</label>
            <div class="clear"></div>
        </div>    
</div>
                 </td>
            </tr>
        </table>
        <div id="editcontrols" style="text-align:center;" runat="server">

        </div>
        <br />
        <div id="divcomments" runat="server">

        </div>
        <div id="commentform" class="hidden" runat="server">
        <div id="respond" class="wp-block-calendar">
            <h3 id="reply-title" class="comment-reply-title">Agregar Comentario</h3>
            <asp:TextBox ID="txtComment" runat="server" Height="64px" TextMode="MultiLine" Width="398px"></asp:TextBox>
            <br />
            <asp:Button ID="btnComment" runat="server" Text="Comentar" OnClick="btnComment_Click" />
            </div>
        </div></div>
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
