<%@ Page Title="Timesheet Maintenance" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_Timesheet.aspx.vb" Inherits="Webvantage.Maintenance_Timesheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div id="maintenance-timesheet" class="telerik-aqua-body" style="margin-top: 5px!important;">
            <h4>Week View</h4>
            <div class="code-description-container">
                <div class="code-description-label" style="font-size: 14px !important">
                    Days to display:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="RadComboBoxDaysToDisplay" runat="server" AutoPostBack="true" Width="75" SkinID="RadComboBoxStandard">
                        <Items>
<%--                            <telerik:RadComboBoxItem Value="1" Text="1" Visible="false"></telerik:RadComboBoxItem>--%>
                            <telerik:RadComboBoxItem Value="5" Text="5"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Selected="True" Value="7" Text="7"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </div>
            </div>
            <div id="DivStartWeekOn" runat="server" class="code-description-container">
                <div class="code-description-label" style="font-size: 14px !important">
                    Start Week on:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="RadComboBoxStartWeekOn" runat="server" AutoPostBack="true" Width="150" SkinID="RadComboBoxStandard">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div id="DivAgencyOverride" runat="server" class="code-description-container" title="Settings on this page will override any settings set by users.  Users cannot change.">
                <div class="code-description-label" style="font-size: 14px !important">
                    Override Users:
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="CheckBoxAgencyOverride" runat="server" AutoPostBack="true" /><span style="margin-left: 12px; font-style:italic; display:none !important;">Settings on this page will override any settings set by users.  Users cannot change.</span>
                </div>
            </div>
            <div id="DivClearUserSettings" runat="server" class="code-description-container" style="display:block !important;" title="All user settings are cleared.  Users can still change.">
                <div class="code-description-label" style="font-size: 14px !important">
                    Clear all user settings:
                </div>
                <div class="code-description-description">
                    <asp:Button ID="ButtonClearAllUserSettings" runat="server" Text="Clear" Width="120" /><span style="margin-left: 12px; font-style:italic; display:none !important;">All user settings are cleard.  Users can still change.</span>
                </div>
            </div>
            <div class="code-description-container" style="display: none !important;">
                <div class="code-description-label">
                    Show comments:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="RadComboBoxShowComments" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                        Width="120">
                        <Items>
                            <telerik:RadComboBoxItem Selected="True" Value="icon" Text="Icon"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="textbox" Text="Textbox"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="none" Text="None"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="code-description-container" id="TrDisablePagingOnMainGrid" runat="server">
                <div class="code-description-label">
                
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="CheckBoxDisablePagingOnMainGrid" runat="server" AutoPostBack="true" Text="Disable paging on main grid" />
                </div>
            </div>
            <div class="code-description-container" id="TrRepeatRowForAllDays" runat="server">
                <div class="code-description-label">
                
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="CheckBoxRepeatRowForAllDays" runat="server" AutoPostBack="true" Text="Repeat row for all days" />
                </div>
            </div>
            <div class="code-description-container" id="TrOnlyShowMyProgress" runat="server">
                <div class="code-description-label">
                    Progress bar:
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="CheckBoxOnlyShowMyProgress" runat="server" AutoPostBack="true" Text="Only show my hours" />
                </div>
            </div>
            <div  style="display: none !important;">
                <h4>Labels</h4>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Division:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxDivisionLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Product:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxProductLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Product Category:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxProductCategoryLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Job:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxJobLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Component:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxComponentLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Function/Category:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxFunctionCategoryLabel" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="30"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <asp:Button ID="ButtonSaveLabels" runat="server" Text="Save Labels" />
                </div>
            </div>
            <div id="TableAgencyOptions" runat="server">
                <h4>Time Entry Options</h4>
                <fieldset id="FieldsetStopwatchOptions" class="text-left ew-css" runat="server">
                    <legend>Stopwatch*</legend>
                    <table width="786" border="0" cellspacing="2" cellpadding="0" style="margin:0 36px;">
                        <tr>
                            <td>Minimum Time (in minutes)
                                                    <telerik:RadComboBox ID="RadComboBoxStopwatchMinimumTime" runat="server" Width="65" SkinID="RadComboBoxStandard">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="2 *" Value="2" />
                                                            <telerik:RadComboBoxItem Text="10" Value="10" />
                                                            <telerik:RadComboBoxItem Text="15" Value="15" />
                                                            <telerik:RadComboBoxItem Text="30" Value="30" />
                                                            <telerik:RadComboBoxItem Text="60" Value="60" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Round up to next&nbsp;
                                                    <telerik:RadComboBox ID="RadComboBoxStopwatchRoundToNextIncrement" runat="server" Width="65" SkinID="RadComboBoxStandard">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="0" Value="0" />
                                                            <telerik:RadComboBoxItem Text="10" Value="10" />
                                                            <telerik:RadComboBoxItem Text="15" Value="15" />
                                                            <telerik:RadComboBoxItem Text="30" Value="30" />
                                                            <telerik:RadComboBoxItem Text="60" Value="60" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                &nbsp;minute increment
                                                    <br />
                                <br />
                                <span style="font-style: italic;">* Stopwatch must run for approximately 1.8 minutes before any time is recorded.</span>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset id="FieldsetTimeEntryOptions" runat="server" class="ew-css">
                    <legend>All Time Entry</legend>
                    <table width="800" border="0" cellspacing="2" cellpadding="0" style="margin: 0 36px;">
                        <tr>
                            <td>Minimum Time (in minutes)
                                                    <telerik:RadComboBox ID="RadComboBoxAllTimeEntryMinimumTime" runat="server" Width="65" SkinID="RadComboBoxStandard">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="0" Value="0" />
                                                            <telerik:RadComboBoxItem Text="5" Value="5" />
                                                            <telerik:RadComboBoxItem Text="10" Value="10" />
                                                            <telerik:RadComboBoxItem Text="15" Value="15" />
                                                            <telerik:RadComboBoxItem Text="30" Value="30" />
                                                            <telerik:RadComboBoxItem Text="60" Value="60" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Round up to next&nbsp;
                                                    <telerik:RadComboBox ID="RadComboBoxAllTimeEntryRoundToNextIncrement" runat="server" Width="65" SkinID="RadComboBoxStandard">
                                                        <Items>
                                                            <telerik:RadComboBoxItem Text="0" Value="0" />
                                                            <telerik:RadComboBoxItem Text="5" Value="5" />
                                                            <telerik:RadComboBoxItem Text="10" Value="10" />
                                                            <telerik:RadComboBoxItem Text="15" Value="15" />
                                                            <telerik:RadComboBoxItem Text="30" Value="30" />
                                                            <telerik:RadComboBoxItem Text="60" Value="60" />
                                                        </Items>
                                                    </telerik:RadComboBox>
                                &nbsp;minute increment</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxCommentsRequiredWhenSubmittingForApproval" runat="server" Text="Require comments before submitting for approval" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxRequireTimeEntryByAssignment" runat="server" Text="Require Time Entry by Assignment" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset id="FieldsetSupervisorApprovalOptions" runat="server" class="ew-css">
                    <legend>Supervisor Approval Options</legend>
                    <table width="800" border="0" cellspacing="2" cellpadding="0" style="margin: 0 36px;">
                        <tr>
                            <td>
                                <asp:CheckBox 
                                    ID="CheckBoxRequiredHoursMetBeforeAllowSubmitForApproval" 
                                    runat="server" 
                                    Text="Required hours must be fulfilled before time can be submitted for approval"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:RadioButton ID="RadioButtonByDay" runat="server" GroupName="DayOrWeek" Text="By Day" />
                                <asp:RadioButton ID="RadioButtonByWeek" runat="server" GroupName="DayOrWeek" Text="By Week" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div class="bottom-buttons" >
                   <asp:Button ID="ButtonSaveTimeEntryOptions" runat="server" Text="Save Time Entry Options" />
                </div>
            </div>
        </div>        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
