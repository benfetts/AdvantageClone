<%@ Page AutoEventWireup="false" CodeBehind="mediavendorinfo.aspx.vb" Inherits="Webvantage.mediavendorinfo"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                var windows = oWnd.get_windowManager().get_windows();
                for (var i = 0; i < windows.length; i++)
                {
                    //alert(windows[i].get_name() + ": " + windows[i].get_navigateUrl() + "\n");
                    var s;
                    s = windows[i].get_navigateUrl()
                    var arCurr = new Array();
                    arCurr = s.split('.');
                    s = arCurr[0];
                    //alert(s);
                    if (s == 'jobspecs_AddNew') {
                        CallingWindow = windows[i]
                    }
                }
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1                
                <%= Me.ControlsToSet %>
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Panel runat="server" ID="apnlMediaInfo" Width="100%">
        <asp:Panel runat="server" ID="apnlMediaInfoMag" Width="100%">
            <asp:DataList ID="dlMediaInfoMag" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="4">
                                &nbsp;&nbsp;Media Info
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Circulation:
                            </td>
                            <td width="45%" align="left">
                                <asp:Label   runat="server" ID="lblCirculation" Text='<%# Eval("DAILY_CIRC")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Cycles:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCycles" Text='<%# Eval("CYCLE")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Issues:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblIssues" Text='<%# Eval("ISSUES")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Publishing Frequency:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPubFrequency" Text='<%# Eval("PUB_FREQ")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Editions:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblEditions" Text='<%# Eval("EDITIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <asp:Panel runat="server" ID="apnlMediaInfoNews" Width="100%">
            <asp:DataList ID="dlMediaInfoNews" runat="server" Width="100%">
                <ItemTemplate>
                    <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                        cellspacing="0" width="100%">
                        <tr>
                            <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="4">
                                &nbsp;&nbsp;Media Info
                            </td>
                        </tr>
                        <tr>
                            <td width="30%" align="right" valign="top">
                               Sunday Circulation:
                            </td>
                            <td width="45%" align="left">
                                <asp:Label   runat="server" ID="lblCirculation" Text='<%# Eval("SUNDAY_CIRC")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Daily Circulation:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblCycles" Text='<%# Eval("DAILY_CIRC")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Publishing Frequency:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblPubFrequency" Text='<%# Eval("PUB_FREQ")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                               Editions:
                            </td>
                            <td align="left">
                                <asp:Label   runat="server" ID="lblEditions" Text='<%# Eval("EDITIONS")%>'>
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlDelivery" Width="100%">
        <asp:DataList ID="dlDelivery" runat="server" Width="100%">
            <ItemTemplate>
                <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
                    cellspacing="0" width="100%">
                    <tr>
                        <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="4">
                            &nbsp;&nbsp;Media Delivery
                        </td>
                    </tr>
                    <tr>
                        <td width="30%" align="right" valign="top">
                           Shipping Address:
                        </td>
                        <td width="45%" align="left">
                            <asp:Label   runat="server" ID="lblShippingAddress" Text='<%# Eval("SHIP_ADDR1")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           General Info:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblGeneralInfo" Text='<%# Eval("DLVRY_GEN_INFO")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Accepted Media:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblAcceptedMedia" Text='<%# Eval("ACCEPTED_MEDIA")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           E-File Info:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblEFile" Text='<%# Eval("EFILE_INFO")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           Preferred Material:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblPreMaterial" Text='<%# Eval("PREF_MATL")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           FTP User Name:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblFTPUserName" Text='<%# Eval("FTP_USER")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           FTP Password:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblFTPPassword" Text='<%# Eval("FTP_PW")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                           FTP Directory:
                        </td>
                        <td align="left">
                            <asp:Label   runat="server" ID="lblFTPDirectory" Text='<%# Eval("FTP_DIR")%>'>
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel runat="server" ID="apnlSpecs" Width="100%">
        <table id="Table1" align="center" border="0" bordercolor="black" cellpadding="2"
            cellspacing="0" width="100%">
            <tr>
                <td align="middle" class="sub-header sub-header-color ContentHeaderText" colspan="4">
                    &nbsp;&nbsp;Media Specs
                </td>
            </tr>
            <tr>
                <td width="45%" align="left">
                    <asp:GridView ID="gvSpecs" runat="server">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div align="center">
        <asp:Button ID="btnInsert" runat="server" Text="Insert Defaults" />&nbsp;
        <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="CloseThisWindow()" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Close" /></div>
</asp:Content>