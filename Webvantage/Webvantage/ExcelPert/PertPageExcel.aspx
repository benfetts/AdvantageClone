<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PertPageExcel.aspx.vb"
    Inherits="Webvantage.PertPageExcel" %>

<html>
<head>
    <title>Timeline Report</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252" />
    <meta name="ProgId" content="Excel.Sheet" />
    <meta name="Generator" content="Microsoft Excel 11" />
    <style type="text/css">


body
{
	color:black;
	font-family:Arial, sans-serif;
	background-color: Transparent;
}

td
{
	padding:0px;
	color:black;
	font-weight:400;
	font-style:4pt;
	text-decoration:none;
    font-family:Arial, sans-serif;
	text-align:general;
	vertical-align:bottom;
	border-right:1pt solid black;
	border-bottom:1pt solid black;
	white-space:nowrap;
	width:20px;
	padding 2px 2px 2px 2px;
	vertical-align:middle;
}

.r
{
	font-size: 10pt;
	font-weight:bold;
	white-space:nowrap;
	padding 2px 2px 2px 2px;
	/*width:50px;*/

}

.rred
{

	/*color: Red;*/
	font-size: 10pt;
	font-weight:bold;
	white-space:nowrap;
	padding 2px 2px 2px 2px;
	/*width:50px;*/
}

.rbold
{

	font-weight: bold;
	font-size: 10pt;
	font-weight:bold;
	white-space:nowrap;
	padding 2px 2px 2px 2px;
	/*width:50px;*/
}

.rblank
{
	background-color:#EEEEEE;

}

.rweekblank
{
    background-color: #AAA;
}

.rstatus
{
	color: white;
	background-color: black;
	font-size: 10pt;
	font-weight:bold;
	
	
}	

.rhead
{
	color: black;
	border: 0px solid black;
	font-size: 10pt;
	font-weight:bold;
	padding:0px 2px 0px 2px;
	text-align:center;
	
}	

.rday
{
	width:20px;
	text-align:center;
	font-size: 6pt;
}

.rweekday
{
	width:20px;
	text-align:center;
	font-size: 6pt;
	background-color: #AAA;
}

.rtask 
{
	background-color: #DDDDFF;
	text-align: center;
	font-size: 7pt;
}
.rdel 
{
	width: 2px;
	background-color:Black;
}

.rmonth
{
	text-align:center;
	font-size: 10pt;
	white-space:nowrap;
	font-weight:bold;
	padding-left:10px;
	
}
-->
</style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:Label   ID="PertLabel" runat="server" />
    </form>
</body>
</html>
