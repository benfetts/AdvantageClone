<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_JobVersionReportEdit.aspx.vb"
    Inherits="Webvantage.Reporting_JobVersionReportEdit" Title="User Defined Report"
    MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">

    <style type="text/css">       
        .RadComboBox_Metro .rcbInput {
            height: 32px !important;
            font-size: 13px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }
        .RadComboBox_Bootstrap .rcbInput {
            height: 32px !important;
            font-size: 13px !important;
            font-weight: 600 !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }
         .test {
            text-indent:5px;
        }

        .RadComboBoxDropDown_Metro {
            font-size: 13px !important;
        }

        .RadComboBoxDropDown_Bootstrap {
            font-size: 13px !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportTemplates" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportTemplates" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonAdd" runat="server" Text="Add" Value="Add"
                            CommandName="Add" ToolTip="Add Report Template" SkinID="RadToolBarButtonNew" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel" Value="Cancel"
                            CommandName="Cancel" ToolTip="Cancel" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">&nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">&nbsp;
            </td>
            <td>
                <table id="TableDescription" runat="server" width="100%" border="0" cellspacing="2" class="wv-form "
                    cellpadding="0">
                    <tr>
                        <td width="20%" style="padding-bottom: 3px; font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important; ">
                            <asp:Label ID="LabelReportType" runat="server" Text="Template Code:" 
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%" style="padding-bottom: 3px">
                            <telerik:RadComboBox ID="RadComboBoxTemplateType" runat="server" AutoPostBack="false" Width="97%">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" style="padding-bottom: 3px; font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                            <asp:Label ID="LabelDescription" runat="server" Text="Report Description: "  Width="100%"></asp:Label>
                        </td>
                        <td width="60%" style="padding-bottom: 3px; font-size: 14px !important;">
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="test" Text="" SkinID="TextBoxStandard" Height="31px" Font-Size="13px"
                                Width="96%">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" style="padding-bottom: 3px font-size: 14px; font-weight: 600; font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;">
                            <asp:Label ID="LabelReportCategory" runat="server" Text="Report Category: " 
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <telerik:RadComboBox ID="RadComboBoxReportCategory" runat="server" AutoPostBack="false" 
                                Width="97%" DataTextField="Description" DataValueField="ID">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
