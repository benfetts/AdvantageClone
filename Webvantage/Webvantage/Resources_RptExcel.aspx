<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources_RptExcel.aspx.vb"
    Inherits="Webvantage.Resources_RptExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
	        color:black;
	        font-family:Arial, sans-serif;
	        background-color: Transparent;
        }
        table, tr, td {

            border-style:solid;
            border-width:1px;
            border-color:#C6C3C6;
            border-collapse:collapse;

        }

        td
        {
	        padding:0px;
	        color:black;
	        font-size:11pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
            font-family:Arial, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        border:none;
	        white-space:nowrap;
        }
        .header1
        {
	        font-size:14pt;
	        font-weight:700;
	        border-right:none;
	        border-left:none;
	        border-bottom:1.5pt solid black;
        }	
        .header2
        {
	        font-weight:700;
	        border-right:none;
	        border-left:none;
            border-top:none;
	        border-bottom:1.5pt solid black;
        }
        .hide
        {
            display:none;
        }
        .blank
        {
	        /*border-right: 0px;
	        border-bottom: none;
	        border-right:none;
	        border-left:none;
            color:Black;
            background-color: Black;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" ShowHeader="false">
    </asp:GridView>
    <asp:HiddenField ID="HfHeader1" runat="server" Value="font-size:14pt;font-weight:700;border-right:.5pt;border-bottom:1.5pt solid black;border-left:none;border-top:1.5pt" />
    <asp:HiddenField ID="HfHeader2" runat="server" Value="font-weight:700;border-right:.5pt;border-bottom:1.5pt solid black;border-left:none;" />
    <asp:HiddenField ID="HfDataCellsWidth" runat="server" value="50"/>
    <asp:HiddenField ID="HfDateTimeCellsWidth" runat="server" Value="80" />
    </form>
</body>
</html>
