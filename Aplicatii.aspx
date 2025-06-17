<%@ Page Title="Detalii Aplicații Instalate" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aplicatii.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132.Aplicatii" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

            <div class="top-bar">
        <asp:Button ID="btnBack" runat="server" CssClass="styled-btn" Text="< Home" OnClick="btnBack_Click"  />

        <h2 class="header"><%: Title %></h2>
    </div>
    <br />
    <div style="text-align:center">
<asp:DropDownList ID="ddlDispozitive" CssClass="dropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDispozitive_SelectedIndexChanged">
</asp:DropDownList>

    <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate>
            <div class="list-item">
                Nume Aplicație: <%# Eval("NumeAplicatie") %><br />
                Versiune: <%# Eval("Versiune") %><br />
                Data Instalare: <%# Eval("DataInstalare", "{0:dd/MM/yyyy}") %>
            </div>
        </ItemTemplate>
    </asp:ListView>


       </div>
</asp:Content>
