<%@ Page AutoEventWireup="false" Codebehind="NoAccess.aspx.vb" Inherits="Webvantage.NoAccess"
    Language="vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Access Denied</title>
    <style type="text/css">
        body {
            height:100%;
	        margin-left: 0px;
	        margin-top: 0px;
	        margin-right: 0px;
	        margin-bottom: 0px;
        }
        html, body, form, #wrapper{
        height:100%;
        margin: 0;
        padding: 0;
        border: none;
        }
        #wrapper {
            margin: 0 auto;
            height:100%;
            width:100%;
        }
        table.full-height {
            height:100%;
            width:100%;
        }
        .largerText {font-size: large}

</style>
    <link href="CSS/Common.min.css" rel="stylesheet" type="text/css" />
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" />
</head>
<body>
    <form id="form1" runat="server">
        <table id="wrapper" align="center" border="0" cellpadding="0" cellspacing="0" class="full-height"
            height="100%" width="100%">
            <tr>
                <td align="center"  valign="middle">
                    <h2>
                        <p>
                            <img src="Images/NoAccess.png" /></p>
                    </h2>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
