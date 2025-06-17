<%@ Page Title="Vizualizare Setari" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Setari.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class="top-bar">
        <asp:Button ID="btnBack" runat="server" CssClass="styled-btn" Text="< Home" OnClick="btnBack_Click"  />

        <h2 class="header"><%: Title %></h2>
    </div>
    <asp:DropDownList ID="ddlDevices" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDevices_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:GridView ID="gvSettings" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NumeSetare" HeaderText="Nume Setare" SortExpression="SettingName" />
            <asp:BoundField DataField="ValoareSetare" HeaderText="Valoare Setare" SortExpression="Value" />
        </Columns>
    </asp:GridView>
</asp:Content>
