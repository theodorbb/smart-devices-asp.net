<%@ Page Title="Listă utilizatori" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Utilizatori.aspx.cs" Inherits="UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="top-bar">
        <%--<asp:Button ID="btnBack" runat="server" CssClass="styled-btn" Text="< Home" OnClick="btnBack_Click" AutoPostBack="True"/>--%>
        <h2 class="header"><%: Title %></h2>
        <asp:Button ID="Button1" runat="server" Text="Adaugă Utilizator Nou" CssClass="btn btn-primary" OnClientClick="$('#addUserModal').modal('show'); return false;" />

    </div>
    <br />


    <div>
        <asp:GridView ID="GridViewUtilizatori" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceUtilizatori" CssClass="table table-hover">
            <Columns>
                <asp:BoundField DataField="Nume" HeaderText="Utilizator" SortExpression="Nume" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="TotalMinute" HeaderText="Total Minute Petrecute" SortExpression="TotalMinute" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="modal fade" id="addUserModal" tabindex="-1" role="dialog" aria-labelledby="addUserModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="addUserModalLabel">Adaugă un nou utilizator</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="txtNume" runat="server" CssClass="form-control" Placeholder="Nume" />
                    <asp:RequiredFieldValidator ID="rfvNume" runat="server" ControlToValidate="txtNume" ErrorMessage="Numele este obligatoriu" CssClass="text-danger" Display="Dynamic" />
                    <br />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Emailul este obligatoriu" CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$" ErrorMessage="Email invalid" CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSaveUser" runat="server" Text="Salvează" CssClass="btn btn-success" OnClick="btnSaveUser_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Închide</button>
                </div>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSourceUtilizatori" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DispozitiveSmartConnectionString %>" 
        SelectCommand="SELECT U.UserID, U.Nume, U.Email, ISNULL(dbo.fn_GetTotalUsageMinutes(U.UserID), 0) AS TotalMinute FROM Utilizatori U">
    </asp:SqlDataSource>
</asp:Content>
