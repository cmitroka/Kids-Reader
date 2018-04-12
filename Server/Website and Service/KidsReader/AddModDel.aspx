<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModDel.aspx.cs" Inherits="KR.AddModDel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        This will allow you to enter custom content using your PC, tablet, etc.</div>
        <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" style="height: 300px; width: 100%"></asp:TextBox>
        <asp:Button ID="cmdSave" runat="server" OnClick="cmdSave_Click" Text="Save" />
    </form>
</body>
</html>
