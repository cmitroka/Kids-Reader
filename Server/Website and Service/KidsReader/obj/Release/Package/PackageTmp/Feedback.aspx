<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Feedback</title>    
            <style>
            .button {
                background-color: black; /* Green */
                border: none;
                border-radius:10px;
                color: white;
                padding: 10px 32px;
                text-align: center;
                text-decoration: none;
                display: inline-block;
                font-size: 16px;
                margin: 4px 2px;
                -webkit-transition-duration: 0.4s; /* Safari */
                transition-duration: 0.4s;
                cursor: pointer;
            }
    .button2 {
        background-color: cornflowerblue; 
        color: white; 
        border: 2px solid cornflowerblue;
    }

    .button2:hover {
        background-color: white;
        color: cornflowerblue;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<center>





    <div style="margin:0px;font-size: xx-large;">Contact Us</div>
    <div style="margin:0px;font-size: small;">We need and want your feedback!&nbsp;Got 
    an idea that could make this app better - let us know!</div>



    <table style="text-align: left">
        <tr>
            <td>Name:</td>
            <td><asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox></td>
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
                Comment:</td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" Height="79px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
        <asp:Button class="button button2" ID="cmdSend" runat="server" onclick="cmdSend_Click" Text="Send" 
            />
        <asp:Button class="button button2" ID="cmdCancel" runat="server" Text="Cancel"
            onclick="cmdCancel_Click" />
    </center>
</asp:Content>
