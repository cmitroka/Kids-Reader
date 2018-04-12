<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportError.aspx.cs" Inherits="ReportError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Report a Bug</h2>
<hr />
<center>
        We know, sometimes thing don&#39;t act the way you&#39;d expect.&nbsp; More than likely, this is a bug - and we have no idea it exists.&nbsp; Please, PLEASE let us know so we can fix it before getting blasted with negative reviews.</p>
    <table>
        <tr>
            <td>
        Name:</td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Device:</td>
            <td>
                <asp:DropDownList ID="ddDevice" runat="server" Width="200px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Apple Phone</asp:ListItem>
                    <asp:ListItem>Android Phone</asp:ListItem>
                    <asp:ListItem>Apple Tablet</asp:ListItem>
                    <asp:ListItem>Android Tablet</asp:ListItem>
                    <asp:ListItem>Something Else</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Comment:</td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" Height="79px" 
            TextMode="MultiLine"  Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
    &nbsp;<p>
        <asp:Button ID="cmdSend" runat="server" onclick="cmdSend_Click" Text="Send" 
            Width="117px" />
        <asp:Button ID="cmdCancel" runat="server" Text="Cancel" Width="124px" 
            onclick="cmdCancel_Click" />
</p>
    </center>
</asp:Content>
