<%@ Page Title="Job Detail Analysis Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_JobDetailAnalysis.aspx.vb" Inherits="Webvantage.Reporting_JobDetailAnalysis" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentJobDetailAnalysis" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
        <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
            <telerik:RadToolBar ID="RadToolBarJobDetailAnalysis" runat="server" AutoPostBack="true"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonView" runat="server" SkinID="RadToolBarButtonPrint"
                        Text="View" Value="View" ToolTip="View Report" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelSelectVersion" runat="server"
            TitleText="Select Version">
            <telerik:RadListBox ID="RadListBoxVersion" runat="server" Width="100%" AutoPostBack="true"
                Height="200" SelectionMode="Single" AllowReorder="False" EnableDragAndDrop="false">
                <%--<Items>
                                        <telerik:RadListBoxItem Text="v001 - Act / Advance Bill History - Act Hrs/Net/MU/Re-Tax/Total"
                                            Value="V1" />
                                        <telerik:RadListBoxItem Text="v010 - Act / Advance Bill History - Actual Total Only"
                                            Value="V10" />
                                        <telerik:RadListBoxItem Text="v011 - Est/Act Cost, Billing, GP, Var, Open POs, Bill/Rec History"
                                            Value="V11" />
                                        <telerik:RadListBoxItem Text="v029 - Job Completion Report"
                                            Value="V29" />
                                        <telerik:RadListBoxItem Text="v030 - Production Job - Quote vs. Actual"
                                            Value="V30" />
                                    </Items>--%>
            </telerik:RadListBox>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelReportOptions" runat="server" 
                                TitleText="Report Options">
                                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                    <tr>
                                        <td align="left" valign="bottom" width="25%">
                                            Sort By:
                                        </td>
                                        <td align="left" valign="bottom" width="25%">
                                            Include:
                                        </td>
                                        <td align="left" valign="bottom" width="25%">
                                            Summary Options:
                                        </td>
                                        <td align="left" valign="bottom" width="25%">
                                            Other Options:
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" width="25%">                                            
                                            <asp:RadioButtonList ID="RadioButtonSortBy" runat="server" RepeatDirection="Vertical"
                                                RepeatLayout="Flow" AutoPostBack="true">
                                                <asp:ListItem Text="Client/Division/Product" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Account Executive" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<telerik:RadButton ID="RadButtonSortByClientDivisionProduct" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" Checked="true" GroupName="SortBy" AutoPostBack="false"
                                                Text="Client/Division/Product" Font-Underline="false">
                                            </telerik:RadButton>
                                            <br />
                                            <telerik:RadButton ID="RadButtonSortByAccountExecutive" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" GroupName="SortBy" AutoPostBack="false" Text="Account Executive"
                                                Font-Underline="false">
                                            </telerik:RadButton>--%>
                                        </td>
                                        <td align="left" valign="top" width="25%">                                           
                                            <asp:RadioButtonList ID="RadioButtonListInclude" runat="server" RepeatDirection="Vertical"
                                                RepeatLayout="Flow" AutoPostBack="true">
                                                <asp:ListItem Text="Open Jobs Only" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Open And Closed Jobs" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<telerik:RadButton ID="RadButtonIncludeOpenJobsOnly" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" Checked="true" GroupName="Include" AutoPostBack="false"
                                                Text="Open Jobs Only" Font-Underline="false">
                                            </telerik:RadButton>
                                            <br />
                                            <telerik:RadButton ID="RadButtonIncludeOpenAndClosedJobs" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" GroupName="Include" AutoPostBack="false" Text="Open And Closed Jobs"
                                                Font-Underline="false">
                                            </telerik:RadButton>--%>
                                        </td>
                                        <td align="left" valign="top" width="25%">                                           
                                            <asp:RadioButtonList ID="RadioButtonListSummary" runat="server" RepeatDirection="Vertical"
                                                RepeatLayout="Flow" AutoPostBack="true">
                                                <asp:ListItem Text="Summary By Function" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Detail By Function" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Summary by Job Comp" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<telerik:RadButton ID="RadButtonSummarySummaryByFunction" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" Checked="true" GroupName="Summary" AutoPostBack="false"
                                                Text="Summary By Function" Font-Underline="false">
                                            </telerik:RadButton>
                                            <br />
                                            <telerik:RadButton ID="RadButtonSummaryDetailByFunction" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" GroupName="Summary" AutoPostBack="false" Text="Detail By Function"
                                                Font-Underline="false">
                                            </telerik:RadButton>
                                            <br />
                                            <telerik:RadButton ID="RadButtonSummarybyJobComp" runat="server" ToggleType="Radio"
                                                ButtonType="ToggleButton" GroupName="Summary" AutoPostBack="false" Text="Summary by Job Comp"
                                                Font-Underline="false">
                                            </telerik:RadButton>--%>
                                        </td>
                                        <td align="left" valign="top" width="25%">
                                            <asp:CheckBox ID="CheckBoxOtherOptionsExcludeNonBillableHours" runat="server" AutoPostBack="false"
                                                Checked="false" Text="Exclude Non Billable Hours" /><br />
                                            <asp:CheckBox ID="CheckBoxSuppressZeroMUDown" runat="server" AutoPostBack="false"
                                                Checked="false" Text="Suppress Zero MU/Down" /><br />
                                            <asp:CheckBox ID="CheckBoxOtherOptionsSaveReportOptions" runat="server" AutoPostBack="false"
                                                Checked="false" Text="Save Report Options" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="bottom" width="25%" colspan="4">
                                            Month / Year Cutoff:  <telerik:RadComboBox ID="RadComboBoxDateCutoff" runat="server" Height="350" CssClass="RequiredInput"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectOffice" runat="server" 
                        TitleText="Select Office">
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom">
                                    <telerik:RadButton ID="RadButtonAllOffices" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                        Checked="true" GroupName="Office" AutoPostBack="true" Text="All Offices" Font-Underline="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonChooseOffices" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="false" GroupName="Office" AutoPostBack="true"
                                        Text="Choose Offices" Font-Underline="false">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxOffices" runat="server" Width="100%" AutoPostBack="false"
                                        Height="200" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                        DataValueField="Code" DataTextField="Name" Enabled="false">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
         </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectClient" runat="server"
                                    TitleText="Select Client" >
                                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                        <tr>
                                            <td align="left" valign="bottom">
                                                <telerik:RadButton ID="RadButtonAllClients" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Checked="true" GroupName="Client" AutoPostBack="true" Text="All Clients" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClients" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Clients" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClientDivision" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Client/Divisions" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseClientDivisionProduct" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" Checked="false" GroupName="Client" AutoPostBack="true"
                                                    Text="Choose Client/Division/Products" Font-Underline="false">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <telerik:RadListBox ID="RadListBoxClients" runat="server" Width="100%" AutoPostBack="true"
                                                    Height="425" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                                    DataValueField="Code" DataTextField="Name" Enabled="false">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectJobs" runat="server" 
                                    TitleText="Select Jobs" >
                                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                                        <tr>
                                            <td align="left" valign="bottom">
                                                <telerik:RadButton ID="RadButtonAllJobs" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Checked="true" GroupName="Job" AutoPostBack="true" Text="All Jobs" Font-Underline="false">
                                                </telerik:RadButton>
                                                <telerik:RadButton ID="RadButtonChooseJobs" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Checked="false" GroupName="Job" AutoPostBack="true" Text="Choose Jobs" Font-Underline="false">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <%--<telerik:RadButton ID="RadButtonOpenJobs" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Checked="true" GroupName="Radios" AutoPostBack="true" Text="Open Jobs" Enabled="false">
                                                </telerik:RadButton>
                                                &nbsp;&nbsp;&nbsp;
                                                <telerik:RadButton ID="RadButtonOpenClosedJobs" runat="server" ToggleType="Radio"
                                                    ButtonType="ToggleButton" GroupName="Radios" AutoPostBack="true" Text="Open/Closed Jobs"
                                                    Enabled="false">
                                                </telerik:RadButton>
                                                <br />
                                                <br />--%>
                                                <telerik:RadListBox ID="RadListBoxJobs" runat="server" Width="100%" AutoPostBack="false"
                                                    Height="425" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                                    DataValueField="Number" DataTextField="Description" Enabled="false">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectAccountExecutive" runat="server"
                        TitleText="Select Account Executive" >
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom">
                                    <telerik:RadButton ID="RadButtonAllAccountExecutives" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="true" GroupName="AccountExecutive" AutoPostBack="true"
                                        Text="All Account Executives" Font-Underline="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonChooseAccountExecutives" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="false" GroupName="AccountExecutive" AutoPostBack="true"
                                        Text="Choose Account Executives" Font-Underline="false">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxAccountExecutives" runat="server" Width="100%"
                                        AutoPostBack="false" Height="200" SelectionMode="Multiple" AllowReorder="False"
                                        EnableDragAndDrop="false" DataValueField="Code" DataTextField="Description" Enabled="false">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectSalesClass" runat="server" 
                        TitleText="Select Sales Class" >
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom">
                                    <telerik:RadButton ID="RadButtonAllSalesClasses" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="true" GroupName="SalesClasses" AutoPostBack="true"
                                        Text="All Sales Classes" Font-Underline="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonChooseSalesClasses" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="false" GroupName="SalesClasses" AutoPostBack="true"
                                        Text="Choose Sales Classes" Font-Underline="false">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxSalesClasses" runat="server" Width="100%" AutoPostBack="false"
                                        Height="200" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                        DataValueField="Code" DataTextField="Description" Enabled="false">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
    </div>
</asp:Content>
