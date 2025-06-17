<%@ Page Title="Istoric Utilizare" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Istoric.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="top-bar">
        <asp:Button ID="btnBack" runat="server" CssClass="styled-btn" Text="< Home" OnClick="btnBack_Click"  />

        <h2 class="header"><%: Title %></h2>
    </div>

    <div style="text-align:center; padding:10px">
            <asp:TextBox ID="txtUserFilter" runat="server" Placeholder="Caută utilizator..." />
        <asp:Button ID="btnFilter" runat="server" Text="Filtrează" OnClick="btnFilter_Click"/>
        </div>

        <asp:GridView ID="GridViewIstoric" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceIstoric">
            <Columns>
                <asp:BoundField DataField="Utilizator" HeaderText="Utilizator" />
                <asp:BoundField DataField="Dispozitiv" HeaderText="Dispozitiv" />
                <asp:BoundField DataField="Data" HeaderText="Data Utilizării" />
                <asp:BoundField DataField="Durata" HeaderText="Durata utilizării (minute)" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSourceIstoric" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DispozitiveSmartConnectionString %>" 
            SelectCommand="EXEC sp_GetIstoricUtilizari @UserName"
        >
            <SelectParameters>
                <asp:ControlParameter ControlID="txtUserFilter" Name="UserName" PropertyName="Text" Type="String" DefaultValue="" />
            </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
