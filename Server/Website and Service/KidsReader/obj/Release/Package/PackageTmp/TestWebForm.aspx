<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWebForm.aspx.cs" Inherits="App.TestWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="MobileOptimized" content="width" />
    <meta name="HandheldFriendly" content="true" />
    <link href="~/Styles/SiteMin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="page">
            <div class="header">
                <table style="width: 100%;">
                    <tr>
                        <td style="text-align: left;vertical-align: top;"><h1 style="color: white;">Template Site</h1></td>
                        <td style="text-align: right;vertical-align: top;"><a href="AdminWeb.htm">
                        <asp:Image ID="Image1" runat="server" Height="48px" ImageUrl="~/Images/Other/CornerIcon.png" /></a></td>
                    </tr>
                </table>
            </div>
            <div class="menu">
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu"
                    EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" />
                        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About" />
                        <%--                        <asp:MenuItem NavigateUrl="~/FileArchive.aspx" Text="Download"/>--%>
                        <asp:MenuItem Text="Contact">
                            <asp:MenuItem Text="Questions/Comments" NavigateUrl="~/Feedback.aspx"></asp:MenuItem>
                            <asp:MenuItem Text="Report a Bug" NavigateUrl="~/ReportError.aspx"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>

            <div class="main">
                <h2>App Name</h2>
                <hr />
                    <img style="height: auto;width: auto; max-width: 100%" alt="" src="Images/Other/AppDetails.jpg" />
                <br />
                App Description<br />
                <table border="0" style="height: auto;width: auto; max-width: 100%" >
                    <tr>
                        <td>
                            <img alt="" src="Images/Other/AndroidLogo.jpg" class="centeredimage" width="100" /></td>
                        <td>
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Other/IOSLogo.jpg" CssClass="centeredimage" Width="80px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img style="height: auto;width: auto; max-width: 100%" alt="" src="Images/Other/AndroidPhone.jpg" />
                        </td>
                        <td>
                            <img style="height: auto;width: auto; max-width: 100%" alt="" src="Images/Other/IOSPhone.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td>QR CODE<br />
                            <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Blue">View in the Google Play Store</asp:HyperLink>
                        </td>
                        <td>QR CODE<br />
                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue">View in the Apple App Store</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
