<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rating.ascx.cs" Inherits="PRProject.rating" %>
 <div class="rating">
            <asp:RadioButton ID="star1" runat="server" AutoPostBack="True" CssClass="radio-btn hide" OnCheckedChanged="star1_CheckedChanged" Text="1" GroupName="g1" />
            <label for="star1" >☆</label>
            <asp:RadioButton ID="star2" runat="server" AutoPostBack="True" CssClass="radio-btn hide" OnCheckedChanged="star2_CheckedChanged" Text="2" GroupName="g1" />
            <label for="star2" >☆</label>
            <asp:RadioButton ID="star3" runat="server" AutoPostBack="True" CssClass="radio-btn hide" OnCheckedChanged="star3_CheckedChanged" Text="3" GroupName="g1" />
            <label for="star3" >☆</label>
            <asp:RadioButton ID="star4" runat="server" AutoPostBack="True" CssClass="radio-btn hide" OnCheckedChanged="star4_CheckedChanged" Text="4" GroupName="g1" />
            <label for="star4" >☆</label>
            <asp:RadioButton ID="star5" runat="server" AutoPostBack="True" CssClass="radio-btn hide" OnCheckedChanged="star5_CheckedChanged" Text="5" GroupName="g1" />
            <label for="star5" >☆</label>
            <div class="clear"></div>
        </div>