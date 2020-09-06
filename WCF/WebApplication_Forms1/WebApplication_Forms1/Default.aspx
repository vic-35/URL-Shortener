<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication_Forms1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <p class="lead">Сервис коротких ссылок</p>
    </div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />

            <asp:Table ID="Table1" runat="server" Width="100%">
                <asp:TableRow runat="server" Width="100%">
                    <asp:TableCell runat="server" Width="100%"></asp:TableCell>
                    <asp:TableCell runat="server"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">    </asp:TableCell>
                    <asp:TableCell runat="server"> </asp:TableCell>
                </asp:TableRow>
            </asp:Table>

            <table style=" width: 100%;">
                <tr>
                    <td style="width: 80%">
                       <asp:TextBox ID="TextBox1" runat="server" CssClass="wide" ></asp:TextBox> 
                        </td>
                    <td style="width: 20%; text-align: right;"><asp:Button ID="Button1" runat="server" Text="Создать ссылку" OnClick="Button1_Click" />&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" CssClass="wide"></asp:TextBox>
                    </td>
                    <td>

                    </td>
                </tr>

            </table>


        

        </ContentTemplate>

        


    </asp:UpdatePanel>



</asp:Content>
