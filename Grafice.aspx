<%@ Page Title="Grafice pentru utilizarea dispozitivelor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Grafice.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132.Contact" %>
<%@ Register assembly="ZedGraph.Web" namespace="ZedGraph.Web" tagprefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top-bar">
        <asp:Button ID="btnBack" runat="server" CssClass="styled-btn" Text="< Home" OnClick="btnBack_Click" />
        <h2 class="header"><%: Title %></h2>
    </div>
    <br />
    <div style="text-align:center">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
            <asp:ListItem Text=" Bare" Value="Bare"></asp:ListItem>
            <asp:ListItem Text=" Linie" Value="Linie"></asp:ListItem>
            <asp:ListItem Text=" Pie" Value="Pie"></asp:ListItem>
        </asp:RadioButtonList>

        <br /><br />
        <cc1:ZedGraphWeb ID="ZedGraphWeb1" runat="server" Height="500" Width="800"></cc1:ZedGraphWeb>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>
