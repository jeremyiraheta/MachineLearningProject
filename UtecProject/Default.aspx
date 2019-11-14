<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="c1" runat="server">
    <div id="slider_wrap">
                <div id="slider">
                    <ul class="slides" runat="server" id="dishslider">
                     
                    </ul>
                </div>

                
            </div>
            <div id="content-wrap">
                <div id="carousel_wrap">
                    <div id="carousel" style="height: 333px;" runat="server">
                        
                    </div>
                    <div id="carousel_nav">
                        <div class="prev">Prev</div>
                        <div class="next">Next</div>
                    </div>
                </div>
                <div id="content">
                    <h3 class="archive_title">Ultimos Platos</h3>

                    <div class="posts" runat="server" id="lastsdishes">
                         
                    </div>

                    <div class="cleaner">&nbsp;</div>
                    <div class="navigation">
                        <span aria-current="page" class="page-numbers current">1</span>
                        <a class="page-numbers" href="#">2</a>
                        <a class="page-numbers" href="#">3</a>
                        <a class="page-numbers" href="#">4</a>
                        <a class="next page-numbers" href="#">Older  ?</a>
                    </div>
                    <div class="cleaner">&nbsp;</div>
                </div>
                
                <!-- / #sidebar -->
                <div class="cleaner">&nbsp;</div>
            </div>
</asp:Content>
