<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dev01.aspx.cs" Inherits="KR.Dev01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
.btn-group .button {
    background-color: aliceblue; /* #4CAF50 Green */
    border: 1px solid green;
    color: cornflowerblue;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    cursor: pointer;
    float: left;
}
.btn-group .button:not(:last-child) {
    border-right: none; /* Prevent double borders */
}
.btn-group .button:hover {
    background-color: white;
}

    </style>
</head>
<body style="background: url('http://192.168.199.1/KidsReader/Images/SiteSpecific/background-light-blue-4.jpg'); background-repeat: no-repeat; background-size: 100%;">
    <form runat="server">
            <div>
                <table style="background: rgba(255,255,255,0.5); border-radius:10px;-moz-border-radius:10px;-webkit-border-radius:10px; width:100%">
                    <tr>
                        <td>
                                        <div style="color: cornflowerblue; font-size: 32px;">
Welcome to the Kids Reader Website!</div>
                            </td>
                        <td style="text-align: right;vertical-align: top;"><a href="AdminWeb.htm">
                        <asp:Image ID="Image1" runat="server" Height="48px" ImageUrl="~/Images/Other/CornerIcon.png" /></a></td>
                    </tr>
                </table>
            </div>
            <div style="background-image: url('/KidsReader/KidsReader/KidsReader/Images/SiteSpecific/skyblue.png'); color: #FF00FF; background-repeat: no-repeat;">
                <table class="auto-style1">
                    <tr>
                        <td>
                            <div class="btn-group">
  <button class="button">About</button>
  <button class="button">Create Content</button>
  <button class="button">Contact Us</button>
</div>

                        </td>
                    </tr>
                </table>
            </div>

            <div class="main">
                <img style="height: auto;width: auto; max-width: 1000%" src="Images/Other/Transparent.gif" />
            </div>
        </div>
    </form>
    <table style="background: white;border-radius:10px;-moz-border-radius:10px;-webkit-border-radius:10px; width:100%">
        <tr>
            <td>table with some content<br />table with some content<br />table with some content<br />table with some content<br />table with some content<br />table with some content<br /></td>
        </tr>
    </table>
</body>
</html>
