<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateContent.aspx.cs" Inherits="KR.CreateContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <title>Add Your Own Content</title>    
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
    <div style="margin:0px;font-size: xx-large;">Create Content</div>
    <div style="margin:0px;font-size: small;">Add your own Word List or Story!</div>
        <div style="max-width:95%;margin: auto;border: 0px solid; border-color:black; border-radius:10px 10px 10px 10px;width:100%">
        <div style="height:5px;"></div>
        <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" style="height: 300px; width: 98%; margin:auto;"></asp:TextBox>
        <asp:Button class="button button2" ID="cmdSave" runat="server" OnClick="cmdSave_Click" Text="Save"/>

    </div>
</center>

</asp:Content>
