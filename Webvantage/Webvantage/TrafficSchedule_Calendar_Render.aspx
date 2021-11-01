<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_Calendar_Render.aspx.vb"
    Inherits="Webvantage.TrafficSchedule_Calendar_Render" %>

<html>
<head>
    <title>Project Schedule Calendar Report</title>
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
	        font-size:16pt;
	        font-weight:700;
	        border:none;
	        border-bottom:1.5pt solid black;

        }	
        .header2
        {
	        font-weight:700;
	        border-right:none;
	        border-bottom:0.5pt solid black;
	        border-right:1pt solid black;
	        border-left:none;
        }

        .monthCell
        {
	        font-weight:700;
	        text-align:center;
	        border:1pt solid black;
	        border-top:1.5pt solid black;
	        border-left:none;
	        width:80px;
        }

        .headerCell
        {
            font-weight:700;
   	        border:0.5pt solid black;
	        border-right:none;
	        font-style:italic;
	        text-align:center;
        }

        .headerCellStart
        {
            font-weight:700;
   	        border:0.5pt solid black;
	        font-style:italic;
	        text-align:center;
        }

        .headerCellEnd
        {
            font-weight:700;
   	        border:0.5pt solid black;
	        border-right:1pt solid black;
	        font-style:italic;
	        text-align:center;
        }

        .headerCalendar1
        {
	        font-weight:700;
	        border:none;
            text-align:left;
            page-break-before:always;
        }	

        .headerCalendar2
        {
	        font-weight:700;
	        border:none;
	        border-bottom:1.5pt solid black;
            text-align:center;
        }
	
        .dateCell
        {
	        border:0.5pt solid black;
	        border-right:none;
	        text-align:left;
	        vertical-align:top;
	        width:300px;
	        font-size:8pt;	
        }

        .dateCellFill
        {
	        border:0.5pt solid black;
	        border-right:none;
	        font-weight:bold;
	        text-align:center;
	        background:#99CCFF;
	        width:300px;	
	        font-size:8pt;	
        }

        .dateCellFillTask
        {
	        border:0.5pt solid black;
	        border-right:none;
	        font-weight:bold;
	        text-align:center;
	        background:#FFFF7F;
	        width:300px;	
	        font-size:8pt;		
        }

	
        .dateCellEnd
        {
	        border:0.5pt solid black;
	        border-right:1pt solid black;
	        text-align:left;
	        vertical-align:top;
	        width:300px;	
	        font-size:8pt;	
        }

        .dateCellEnd2
        {
	        border:0.5pt solid black;
	        border-right:0.5pt solid black;
	        text-align:left;
	        vertical-align:top;
	        width:300px;	
	        font-size:8pt;	
        }

        .dateCellEndFill
        {
	        background:#99CCFF;
	        border:0.5pt solid black;
	        border-right:1pt solid black;
	        text-align:center;
	        width:300px;	
	        font-size:8pt;	
        }

        .phaseCell
        {
	        font-size:10pt;
	        font-weight:700;
	        border:.5pt solid black;
	        border-right:1pt solid black;
	        border-top:none;
	        background:silver;
        }

        .taskCell
        {
	        font-size:10pt;
	        border:none;
	        border-bottom:.5pt solid windowtext;
	        border-left:.5pt solid windowtext;
        }	

        .taskCellEnd
        {
	        font-size:10pt;
	        border:none;
	        border-bottom:.5pt solid windowtext;
	        border-left:.5pt solid windowtext;
	        border-right:1pt solid black;
        }	

        .footer
        {
	        font-size:10pt;
	        border:none;
	        border-top:1pt solid windowtext;
	        height:200px;
	        vertical-align:top;
	        white-space:normal;
        }		
        -->
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:Panel ID="PanelCalendar" runat="server" />
    </form>
</body>
</html>
