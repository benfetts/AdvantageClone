<%@ Page AutoEventWireup="false" CodeBehind="Security_SelectReport.aspx.vb" Inherits="Webvantage.Security_SelectReport"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Select Report" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentSecuritySelectReport" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <div  style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
     <telerik:RadToolBar ID="RadToolBarSecurityReport" runat="server" AutoPostBack="true"
                        Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonView" runat="server" SkinID="RadToolBarButtonView"
                                Text="View" Value="View" CommandName="View" ToolTip="View Report" />
                            <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                                IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <div  style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">

                    </div>
                    <td runat="server" id="TdRadToolBarSecurityReport" align="left" valign="top"
                        colspan="2">
               
                    </td>
                </tr>
                <tr>
                    <td width="1%">
                        &nbsp;
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="1%">
                        &nbsp;
                    </td>
                    <td>
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td width="10%">
                                    Report:
                                </td>
                                <td width="90%">
                                    <telerik:RadComboBox ID="RadComboBoxReport" runat="server" AutoPostBack="true" Width="100%"
                                        DataTextField="Name" DataValueField="Value">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="1%">
                        &nbsp;
                    </td>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="1%">
                        &nbsp;
                    </td>
                    <td>
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td width="25%">
                                    <telerik:RadButton ID="RadButtonAll" runat="server" AutoPostBack="true" ButtonType="ToggleButton"
                                        ToggleType="Radio" Checked="true" GroupName="Selection" Font-Underline="false"
                                        Text="All">
                                    </telerik:RadButton>
                                </td>
                                <td width="25%">
                                    <telerik:RadButton ID="RadButtonSelect" runat="server" AutoPostBack="true" ButtonType="ToggleButton"
                                        ToggleType="Radio" Checked="false" GroupName="Selection" Font-Underline="false"
                                        Text="Select">
                                    </telerik:RadButton>
                                </td>
                                <td width="25%">
                                    &nbsp;
                                </td>
                                <td width="25%">
                                    <asp:CheckBox ID="CheckBoxShowOnlyAccessibleModules" runat="server" AutoPostBack="false"
                                        Checked="false" Text="Show Only Accessible Modules" Visible="false" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="1%">
                        &nbsp;
                    </td>
                    <td>
                       <telerik:RadListBox ID="RadListBoxUsers" runat="server" Width="100%" AutoPostBack="false"
                            Height="400" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                            DataValueField="ID" DataTextField="Name" Enabled="false" Visible="false">
                        </telerik:RadListBox>
                       <telerik:RadListBox ID="RadListBoxEmployees" runat="server" Width="100%" AutoPostBack="false"
                            Height="400" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                            DataValueField="Code" DataTextField="Name" Enabled="false" Visible="false">
                        </telerik:RadListBox>
                       <telerik:RadListBox ID="RadListBoxGroups" runat="server" Width="100%" AutoPostBack="false"
                            Height="400" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                            DataValueField="Code" DataTextField="Name" Enabled="false" Visible="false">
                        </telerik:RadListBox>
                    </td>
                </tr>
            </table>
    </div>
    
    <br />
</asp:Content>
