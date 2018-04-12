<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RetrieveCode.aspx.cs" Inherits="KR.RetrieveCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
            <title>Your Retrieval Code</title>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<center>            
    <div style="margin:0px;font-size: xx-large;">This is your Retrieval Code...</div>
    <div style="margin:0px;font-size: small;">Use this in the app to get the data you just entered here.<br />
    <div style="margin:0px;font-size: small;">NOTE: This IS case sensitive!<br />
    <div style="height:5px;"></div>
        <asp:TextBox style="text-align: center;" ID="txtCode" runat="server" Font-Size="XX-Large" ReadOnly="True">test</asp:TextBox>
    </div>
</center>
</asp:Content>
