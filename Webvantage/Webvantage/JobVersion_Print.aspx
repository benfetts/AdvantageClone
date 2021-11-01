<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JobVersion_Print.aspx.vb"
    Inherits="Webvantage.JobVersion_Print" MasterPageFile="~/ChildPage.Master" Title="" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="ToolbarRadToolbar" runat="server" AutoPostBack="True" Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" ToolTip="Save Settings" Value="Save" />
            <telerik:RadToolBarButton IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;
                <asp:Label   ID="hdrID1" runat="server" Text="Version to Print"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right" style="width: 72px;">
                            Client:
                        </td>
                        <td style="">
                            <asp:Label   ID="lblClient" runat="server"></asp:Label>
                        </td>
                        <td align="right" style="width: 133px;">
                            Job:
                        </td>
                        <td style="">
                            <asp:Label   ID="lblJobNum" runat="server"></asp:Label>&nbsp;-&nbsp;
                            <asp:Label   ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 72px">
                            Division:
                        </td>
                        <td>
                            <asp:Label   ID="lblDivision" runat="server"></asp:Label>
                        </td>
                        <td align="right" style="width: 133px">
                            Job Component:
                        </td>
                        <td>
                            <asp:Label   ID="lblJobCompNum" runat="server"></asp:Label>&nbsp;-&nbsp;
                            <asp:Label   ID="LabelJobComponentDescription" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 72px">
                            Product:
                        </td>
                        <td>
                            <asp:Label   ID="lblProduct" runat="server"></asp:Label>
                        </td>
                        <td align="right" style="width: 133px">
                            <asp:Label   ID="lblversionheader" runat="server" Text="Version:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label   ID="lblversion" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Location
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<telerik:RadComboBox ID="dl_location" runat="server" Width="329px" DataTextField="LOC_NAME" SkinID="RadComboBoxStandard"
                                AutoPostBack="true" DataValueField="LOCATION_ID">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Output Format
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label1" runat="server" Text="Format:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<uc2:reporttype ID="Reporttype1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Print Options
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td style="width: 50px">
                        </td>
                        <td colspan="2">
                            <asp:CheckBox ID="cbOmitEmptyFields" runat="server" Text="Omit Empty Fields" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px">
                        </td>
                        <td class="sub-header sub-header-color" colspan="2">
                            <asp:Label   ID="lbJobOF" runat="server" Text="Report Title Placement:" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50px">
                        </td>
                        <td colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbReportLeft" runat="server" Text="Left"
                                GroupName="Report" />
                            &nbsp;<asp:RadioButton ID="rbReportRight" runat="server" Text="Right" GroupName="Report" />
                            &nbsp;<asp:RadioButton ID="rbReportCenter" runat="server" Text="Center" GroupName="Report" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label   ID="lbl_msg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
