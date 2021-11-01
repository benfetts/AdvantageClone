<%@ Page Title="Print/Send Project Schedule" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Print.aspx.vb" Inherits="Webvantage.TrafficSchedule_Print" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
    <telerik:RadToolBar ID="RadToolBarProjectSchedulePrintOptions" runat="server" AutoPostBack="True"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Id="RadToolBarButtonClear" runat="server" SkinID="RadToolBarButtonClear"
                    Text="Clear" Value="Clear" Hidden="False" />
                <telerik:RadToolBarButton runat="server" IsSeparator="true" Value="RadToolBarButtonClearSeparator" />
            </Items>
        </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
            <table width="100%" border="0" cellspacing="2" cellpadding="0">
                    <tr id="TrHeaderInfo" runat="server">
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="right" style="width: 72px;">
                                        <span>Client:</span>
                                    </td>
                                    <td style="">
                                        <asp:Label ID="LabelClient" runat="server"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 133px;">
                                        <span>Job:</span>
                                    </td>
                                    <td style="">
                                        <asp:Label ID="LabelJobNumber" runat="server"></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 72px">
                                        <span>Division:</span>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelDivision" runat="server"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 133px">
                                        <span>Job Component:</span>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelJobComponentNumber" runat="server"></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label ID="LabelJobComponentDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 72px">
                                        <span>Product:</span>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelProduct" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Output Format
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr id="TrSelectPageType" runat="server">
                                    <td width="100px">
                                        <span>View:</span>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonListSelect" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                            AutoPostBack="true">
                                            <asp:ListItem Text="Single" Value="single" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Multi" Value="multi"></asp:ListItem>
                                            <asp:ListItem Text="Worksheet" Value="worksheet"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr id="TrSelectReport" runat="server">
                                    <td width="100px" valign="top" align="right">
                                        <span>Report:</span>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxReportName" runat="server" AutoPostBack="true" Visible="false" SkinID="RadComboBoxStandard">
                                        </telerik:RadComboBox>
                                        <telerik:RadListBox ID="RadListBoxReportName" runat="server" AutoPostBack="true" Height="100px"
                                            Width="500px">
                                        </telerik:RadListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Location
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 45px" colspan="2">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" style="width: 100px;">
                                        <asp:Label ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                                    </td>
                                    <td>&nbsp;<telerik:RadComboBox ID="RadComboBoxLocation" runat="server" DataTextField="LOC_NAME" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                        DataValueField="LOCATION_ID" Width="329px">
                                    </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Print Options
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 45px" colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%">                        
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxCompletedTasks" runat="server" Text="Include Completed Tasks" AutoPostBack="true" Checked="true" />
                                        </td>
                                    </tr>
                                    <tr>
                        
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxMilestonesOnly1" runat="server" Text="Milestones Only" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxExcludeTaskComment" runat="server" Text="Exclude Task Comment" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxShowPhases" runat="server" Text="Exclude Phases" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxShowResources" runat="server" Text="Exclude Resources" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxExcludeMilestone" runat="server" Text="Exclude Milestone" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100px"></td>
                                        <td>&nbsp;<asp:CheckBox ID="CheckBoxExcludeTimeDue" runat="server" Text="Exclude Time Due" AutoPostBack="true" />
                                        </td>
                                    </tr>
                                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr class="sub-header sub-header-color" id="TrFilterHeader" runat="server">
                        <td colspan="2">&nbsp;&nbsp;&nbsp;Filter Options
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="300" align="left" valign="top">
                            <table border="0" cellpadding="2" cellspacing="0" width="280">
                                <tr id="TrOffice" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="HlOffice" runat="server" TabIndex="-1" href=""><span>Office:</span></asp:HyperLink>
                                        </span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtOffice" runat="server" Width="145px" TabIndex="1" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrClient" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="hlClient" runat="server" TabIndex="-1" href=""><span>Client:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtClient" runat="server" Width="145px" TabIndex="1" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrDivision" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="hlDivision" runat="server" TabIndex="-1" href=""><span>Division:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDivision" runat="server" Width="145px" TabIndex="2" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrProduct" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="hlProduct" runat="server" TabIndex="-1" href=""><span>Product:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProduct" runat="server" Width="145px" TabIndex="3" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrJobNumber" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="hlJob" runat="server" TabIndex="-1" href=""><span>Job:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJob" runat="server" Width="145px" TabIndex="4" MaxLength="6" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrJobComponentNbr" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="hlComponent" runat="server" TabIndex="-1" href=""><span>Component:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComponent" runat="server" Width="145px" MaxLength="6" TabIndex="5" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrSpacer0" runat="server">
                                    <td>&nbsp;
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr id="TrCampaign" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="HlCampaign" runat="server" TabIndex="-1" href=""><span>Campaign:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtCampaign" runat="server" MaxLength="6" TabIndex="6" Text="" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrManager" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="HlManager" runat="server" TabIndex="-1" href=""><span>Manager:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtManager" runat="server" MaxLength="6" TabIndex="7" Text="" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrAccountExecutive" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="HlAccountExecutive" runat="server" TabIndex="-1" href=""><span>Account Executive:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtAccountExecutive" runat="server" MaxLength="6" TabIndex="8" Text="" SkinID="TextBoxStandard"
                                            Width="145px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrTrafficStatus" runat="server">
                                    <td>
                                        <span>
                                            <asp:HyperLink ID="HlTrafficStatus" runat="server" TabIndex="-1" href=""><span>Traffic Status:</span></asp:HyperLink></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtTrafficStatusCode" runat="server" MaxLength="10" TabIndex="8" SkinID="TextBoxStandard"
                                            Text="" Width="145px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="TrStartEnd" runat="server">
                                    <td colspan="2">
                                        <span>Between Start/End</span>
                                    </td>
                                </tr>
                                <tr id="TrIncludeCompletedSchedules" runat="server">
                                    <td colspan="2">
                                        <asp:CheckBox ID="CheckBoxIncludeCompletedSchedules" runat="server" Checked="True" TabIndex="9"
                                            Text="" /><span>Exclude Completed Schedules</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="300" align="left" valign="top">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                <table border="0" cellpadding="2" cellspacing="0" width="280">
                                    <tr id="TrPhaseFilter" runat="server">
                                        <td width="162">
                                            <span>Phase:</span>
                                        </td>
                                        <td width="110">
                                            <telerik:RadComboBox ID="RadComboBoxPhaseFilter" runat="server" TabIndex="10" AppendDataBoundItems="true" SkinID="RadComboBoxStandard"
                                                Visible="true">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="[No Filter]" Value="no_filter"></telerik:RadComboBoxItem>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr id="TrRole" runat="server">
                                        <td>
                                            <span>
                                                <asp:HyperLink ID="HlRole" runat="server" TabIndex="-1" href=""><span>Role:</span></asp:HyperLink></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtRole" runat="server" MaxLength="6" TabIndex="11" Text="" Width="145px" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="TrTask" runat="server">
                                        <td>
                                            <span>
                                                <asp:HyperLink ID="HlTask" runat="server" TabIndex="-1" href=""><span>Task:</span></asp:HyperLink></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtTaskCode" runat="server" MaxLength="10" TabIndex="12" Text="" SkinID="TextBoxStandard"
                                                Width="145px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="TrEmployee" runat="server">
                                        <td>
                                            <span>
                                                <asp:HyperLink ID="HlEmployee" runat="server" TabIndex="-1" href="">Employee:</asp:HyperLink></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TxtEmployee" runat="server" MaxLength="6" TabIndex="13" Text="" SkinID="TextBoxStandard"
                                                Width="145px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="TrDateCutoff" runat="server">
                                        <td>
                                            <span>Date Cutoff:</span>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="RadDatePickerDateCutoff" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr id="TrOnlyPendingTasks" runat="server">
                                        <td colspan="2">
                                            <span>
                                                <asp:CheckBox ID="CheckBoxOnlyPendingTasks" runat="server" TabIndex="15" Text="" />Only
                                                Pending Tasks</span>
                                        </td>
                                    </tr>
                                    <tr id="TrExcludeProjectedTasks" runat="server">
                                        <td colspan="2">
                                            <span>
                                                <asp:CheckBox ID="CheckBoxExcludeProjectedTasks" runat="server" TabIndex="16" Text="" />Exclude
                                                Projected Tasks</span>
                                        </td>
                                    </tr>
                                    <tr id="TrIncludeCompletedTasks" runat="server">
                                        <td colspan="2">
                                            <span>
                                                <asp:CheckBox ID="CheckBoxIncludeCompletedTasks" runat="server" Checked="True" TabIndex="17"
                                                    Text="" />Include Completed Tasks</span>
                                        </td>
                                    </tr>
                                    <tr id="TrMilestonesOnly" runat="server">
                                        <td colspan="2">
                                            <span>
                                                <asp:CheckBox ID="CheckBoxMilestonesOnly2" runat="server" Checked="True" TabIndex="18"
                                                    Text="" />Only Milestones</span>
                                        </td>
                                    </tr>
                                    <tr id="TrSpacer1" runat="server">
                                        <td>&nbsp;
                                        </td>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="left">&nbsp;
                            <asp:Button ID="BtnView" runat="server" Text="View" Visible="false" />&nbsp;&nbsp;
                            <asp:Button ID="BtnClear" runat="server" Text="Clear" Visible="false" />
                            <asp:Button ID="BtnClose" runat="server" Text="Close" OnClientClick="CloseThisWindow();"
                                Visible="false" />
                        </td>
                    </tr>
                </table>
    </div>
    

    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">
            Telerik.Web.UI.RadListBox.prototype.saveClientState = function () {
                return "{" +
                            "\"isEnabled\":" + this._enabled +
                            ",\"logEntries\":" + this._logEntriesJson +
                           ",\"selectedIndices\":" + this._selectedIndicesJson +
                           ",\"checkedIndices\":" + this._checkedIndicesJson +
                           ",\"scrollPosition\":" + Math.round(this._scrollPosition) +
                       "}";
            }     
        </script>	
    </telerik:RadScriptBlock>

</asp:Content>
