<%@ Page Title="Reportes PI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutomatizacionPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%=this.ResolveUrl("~/Scripts/ProgressBar.js")%>"></script>
    <div class="jumbotron">
        <h2>Reportes Plan Influencia.</h2>
        <%--        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>--%>
        <p class="lead">Selecciona un periodo.</p>


        &nbsp;&nbsp;&nbsp;


         <asp:DropDownList ClientIDMode="Static" ID="DropDownListMes" runat="server" Height="30px" Width="104px" BackColor="#EEEEEE" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">
<%--             <asp:ListItem Text="202101" Value="202101"> </asp:ListItem>
             <asp:ListItem Text="202102" Value="202102"></asp:ListItem>
             <asp:ListItem Text="202103" Value="202103"></asp:ListItem>
             <asp:ListItem Text="202104" Value="202104"> </asp:ListItem>
             <asp:ListItem Text="202105" Value="202105"></asp:ListItem>
             <asp:ListItem Text="202106" Value="202106"></asp:ListItem>
             <asp:ListItem Text="202107" Value="202107"> </asp:ListItem>--%>
             <%--  <asp:ListItem Text="202108" Value="202108"></asp:ListItem>
                                    <asp:ListItem Text="202109" Value="202109"></asp:ListItem>
                                    <asp:ListItem Text="202110" Value="202110"> </asp:ListItem>
                                    <asp:ListItem Text="202111" Value="202111"></asp:ListItem>
                                    <asp:ListItem Text="202112" Value="202112"></asp:ListItem>--%>
         </asp:DropDownList>

        <br />
        <br />     
        <input type="button" class="btn btn-primary btn-lg" id="Button3" runat="server" name="ButtonReport" onclick="Login();" value="Descargar &raquo;" />&nbsp;&nbsp;   
        <div class="row">
            <iframe id="iframe" style="display: none;"></iframe>          
        </div>
    </div>
</asp:Content>
