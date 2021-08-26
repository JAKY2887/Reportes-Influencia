<%@ Page Title="Reportes PI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutomatizacionPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="<%=this.ResolveUrl("~/Scripts/ProgressBar.js")%>"></script>
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-6">
                <h2>Reporte Final Plan Influencia.</h2>
                <%--        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>--%>
                <p class="lead">Selecciona un periodo.</p>

                &nbsp;&nbsp;&nbsp;


         <asp:DropDownList ClientIDMode="Static" ID="DropDownListMes" runat="server" Height="30px" Width="104px" BackColor="#EEEEEE" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">
         </asp:DropDownList>

                <br />
                <br />
                <input type="button" class="btn btn-primary btn-lg" id="Button3" runat="server" name="ButtonReport" onclick="Login();" value="Descargar &raquo;" />&nbsp;&nbsp;   
        <%--<div class="row">
            <iframe id="iframe" style="display: none;"></iframe>          
        </div>--%>
            </div>
            <div class="col-md-6">
                <h2>Reporte Preeliminar Plan Influencia.</h2>
                <%--        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>--%>
                <p class="lead">Periodo Actual.</p>

                &nbsp;&nbsp;&nbsp;


         <asp:DropDownList ClientIDMode="Static" ID="DropDownListActual" runat="server" Height="30px" Width="104px" BackColor="#EEEEEE" Font-Bold="True" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False">
         </asp:DropDownList>

                <br />
                <br />
                 <input type="button" class="btn btn-primary btn-lg" id="ButtonPrelim" runat="server" name="ButtonPrelim" onclick="Login();" value="Descargar &raquo;" />&nbsp;&nbsp;   

            </div>
        </div>
    </div>
</asp:Content>
