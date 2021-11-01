<%@ Page AutoEventWireup="false" Codebehind="nontask.aspx.vb" Inherits="Webvantage.nontask" Language="vb"   %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type" />
    <link href="CSS/Common.min.css" rel="stylesheet" type="text/css" />
    <title>Webvantage</title>
</head>
    <body>
    <form id="frmTaskPop" runat="server">
            <asp:DataList ID="dlTask" runat="server" Width="100%">
                <ItemTemplate>
<table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%" >
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Information</td>
                        </tr>
                        <tr>
                            <td width="30%" align="right"  >
                               Client:</td>
                            <td width="70%" align="left">
                                <%# Eval("CLIENT")%>                            </td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Division:</td>
                            <td align="left">
                                <%# Eval("DIVISION")%>                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                               Product:</td>
                            <td align="left">
                                <%# Eval("PRODUCT")%>                                </td>
                        </tr>
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                &nbsp;&nbsp;Job Info</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Job:</td>
                            <td align="left">
                                <%# Eval("Job")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Job Comp:</td>
                            <td align="left">
                                <%# Eval("JobComp")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Account Executive:</td>
                            <td align="left">
                                <%# Eval("AE")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Start Date:</td>
                            <td align="left">
                                <%# Eval("JobStartDate")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Due Date:</td>
                            <td align="left">
                                <%# Eval("JobDueDate")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Traffic Status:</td>
                            <td align="left">
                                <%# Eval("TrafficStatus")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Traffic Comments:</td>
                            <td align="left">
                                <%# Eval("TrafficComments")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="2">
                                 &nbsp;&nbsp;Task Info</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Task:</td>
                            <td align="left">
                                <%# Eval("Task")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Phase:</td>
                            <td align="left">
                                <%# Eval("Phase")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Status:</td>
                            <td align="left">
                                <%# ShowTaskStatus(Eval("TaskStatus"))%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Hours Allowed:</td>
                            <td align="left">
                                <%# Eval("HoursAllowed")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Start Date:</td>
                            <td align="left">
                                <%# Eval("TaskStartDate")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Due Date:</td>
                            <td align="left">
                                <%# Eval("RevDueDate")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Time Due:</td>
                            <td align="left">
                                <%# Eval("RevDueTime")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right"  >
                               Original Due Date:</td>
                            <td align="left">
                                <%# Eval("DueDate")%>
                                &nbsp;</td>
                        </tr> 
                        <tr>
                            <td align="right"  >
                               Original Time Due:</td>
                            <td align="left">
                                <%# Eval("DueTime")%>
                                &nbsp;</td>
                        </tr>                       
                        <tr>
                            <td align="right"  >
                               Temp Complete Date:</td>
                            <td align="left">
                                <%# Eval("TempCompDate")%>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                               Comments:</td>
                            <td align="left"><%# replace(Eval("Comments"), vbcrlf, "<br />")%></td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                
                                                          </td>
                        </tr>
                    </table>    <br />            </ItemTemplate>
            </asp:DataList><div align="center">
            <asp:Button ID="butMarkCompleted" runat="server"  Text="Mark Completed" />&nbsp;&nbsp;&nbsp;
            <input  onclick="window.close()" type="button" value="Close"/></div><br />
   </form>
    </body>
        
</html>
