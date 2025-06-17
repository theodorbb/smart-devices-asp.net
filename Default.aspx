<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <%--<form id="form1" runat="server">--%>
        <h1 class="header"> Lista de Dispozitive Smart Înregistrate</h1>



        <div class="dropdown">
            <asp:Label ID="FiltrareLabel" runat="server" Text="Selectează tipul dorit: "></asp:Label>
            <asp:DropDownList ID="DropDownListFilter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListFilter_SelectedIndexChanged">
                <asp:ListItem Text="Listă întreagă" Value="All" Selected="True" />
                <asp:ListItem Text="Smartwatch" Value="Smartwatch" />
                <asp:ListItem Text="Smartphone" Value="Smartphone" />
                <asp:ListItem Text="Home Automation" Value="Home Automation" />
                <asp:ListItem Text="Smart Light" Value="Smart Light" />
                <asp:ListItem Text="Entertainment" Value="Entertainment" />
                <asp:ListItem Text="Fitness Tracker" Value="Fitness Tracker" />
                <asp:ListItem Text="Smart Speaker" Value="Smart Speaker" />
                <asp:ListItem Text="Smart Display" Value="Smart Display" />
                <asp:ListItem Text="Home Security" Value="Home Security" />
                <asp:ListItem Text="Smart TV" Value="Smart TV" />
                <asp:ListItem Text="Laptop" Value="Laptop" />
                <asp:ListItem Text="Digital Camera" Value="Digital Camera" />
                <asp:ListItem Text="Drone" Value="Drone" />
                <asp:ListItem Text="Headphones" Value="Headphones" />
                <asp:ListItem Text="Networking Device" Value="Networking Device" />
                <asp:ListItem Text="Tablet" Value="Tablet" />
            </asp:DropDownList>
        </div>
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" OnRowUpdating="GridView1_RowUpdating" AutoGenerateColumns="False" DataKeyNames="DispozitivID" DataSourceID="SqlDataSource1" AutoGenerateEditButton="True">
            <Columns>
                <asp:BoundField DataField="DispozitivID" HeaderText="DispozitivID" SortExpression="DispozitivID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="Denumire" HeaderText="Denumire" SortExpression="Denumire" />
                <asp:BoundField DataField="Tip" HeaderText="Tip" SortExpression="Tip" />
                <asp:BoundField DataField="AnulLansarii" HeaderText="AnulLansarii" SortExpression="AnulLansarii" />
                <asp:BoundField DataField="Pret" HeaderText="Pret" SortExpression="Pret" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DispozitiveSmartConnectionString %>" 
            SelectCommand="SELECT DispozitivID, Denumire, Tip, AnulLansarii, Pret FROM Dispozitive WHERE (Tip LIKE '%' + @Tip + '%' OR @Tip = 'All')"
            UpdateCommand="UPDATE Dispozitive SET Denumire = @Denumire, Tip = @Tip, AnulLansarii = @AnulLansarii, Pret = @Pret WHERE DispozitivID = @DispozitivID">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownListFilter" Name="Tip" PropertyName="SelectedValue" Type="String" DefaultValue="" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Denumire" />
                <asp:Parameter Name="Tip" />
                <asp:Parameter Name="AnulLansarii" />
                <asp:Parameter Name="Pret" />
                <asp:Parameter Name="DispozitivID" />
            </UpdateParameters>
        </asp:SqlDataSource>


    <%--</form>--%>

</asp:Content>
