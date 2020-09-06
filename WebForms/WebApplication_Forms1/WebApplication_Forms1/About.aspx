<%@ Page Title="Ссылки пользователя" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication_Forms1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ссылки пользователя</h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="0" ForeColor="#333333" AutoGenerateColumns="False" OnLoad="GridView1_Load" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="S_short" HeaderText="Короткая ссылка">
                    <ControlStyle BorderStyle="Solid" BorderWidth="4px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="S_long" HeaderText="Ссылка перехода" ItemStyle-CssClass="WrappedText">   
                    </asp:BoundField>
                    <asp:BoundField DataField="View_count" HeaderText="Количество переходов">
                    <ControlStyle BorderWidth="4px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label> &nbsp;</p>
</asp:Content>
