<%@ Page AutoEventWireup="false" CodeBehind="ProjectHoursUsed_Settings.aspx.vb" Inherits="Webvantage.ProjectHoursUsed_Settings" Title="Project Hours"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain"
    EnableViewState="true">
    <style type="text/css">
            .rlbItem
            {
                text-align: left !important;
                
            }
    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
      <table id="Table2" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right" height="430" style="width: 480px" valign="top">
                    <table id="Table1" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color"> <asp:Label   ID="lbl_msg" runat="server" CssClass="warning"></asp:Label>
                                Client Options</td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButtonList ID="optCDP" runat="server" AutoPostBack="True" 
                                     RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="a">All</asp:ListItem>
                                    <asp:ListItem Value="c">Client</asp:ListItem>
                                    <asp:ListItem Value="d">Division</asp:ListItem>
                                    <asp:ListItem Value="p">Product</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <asp:Panel ID="pnlClient" runat="server" HorizontalAlign="Center" Width="">
                                    <telerik:RadListBox ID="lstClient" runat="server" Width="300px" Height="200px"   
                                         SelectionMode="Multiple" AutoPostBack="true" ></telerik:RadListBox>
                                </asp:Panel>
                                <asp:Panel ID="pnlDivision" runat="server" HorizontalAlign="Center" Width="">
                                    <telerik:RadListBox ID="lstDivision" runat="server" Width="300px" Height="200px"   
                                         SelectionMode="Multiple" AutoPostBack="true"></telerik:RadListBox>
                                </asp:Panel>
                                <asp:Panel ID="pnlProduct" runat="server" HorizontalAlign="Center" Width="">
                                    <telerik:RadListBox ID="lstProduct" runat="server"  Width="300px" Height="200px" 
                                         SelectionMode="Multiple" AutoPostBack="true"></telerik:RadListBox>
                                </asp:Panel>
                                <br />
                            </td>
                        </tr>
                    </table>    
                    <br />            
                    <table id="Table3" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color" colspan="2">
                                <font color="black"></font>Job Options</td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:RadioButtonList ID="rblJobs" runat="server" AutoPostBack="True" 
                                     RepeatColumns="2" Width="256px">
                                    <asp:ListItem Selected="True" Value="all">All Job</asp:ListItem>
                                    <asp:ListItem Value="Choose">Choose Jobs</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <telerik:RadListBox ID="lbJobs" runat="server" Width="300px"  
                                    Height="75px" SelectionMode="Multiple" ></telerik:RadListBox><br />
                                <br />
                            </td>
                        </tr>
                    </table>                
                    <br />
                    <table id="Table5" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color">
                                Status Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButtonList ID="rdlStatus" runat="server" AutoPostBack="True" 
                                     RepeatColumns="2" Width="224px">
                                    <asp:ListItem Selected="True" Value="all">All Status</asp:ListItem>
                                    <asp:ListItem Value="Choose">Choose Status</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <telerik:RadListBox ID="lbStatus" runat="server" Width="300px"  
                                    Height="75px"></telerik:RadListBox><br />
                            </td>
                        </tr>
                    </table>
                    <br />  
                    <table id="Table7" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color">
                                Filter Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <br />
                                <asp:Label   ID="lblManager" runat="server"  ></asp:Label>&nbsp;&nbsp;<telerik:RadComboBox
                                    ID="ddManager" runat="server" >
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <br />
                                <asp:CheckBox ID="cbIncludeOpenJobOnly" runat="server"  
                                    Text="Include Open Jobs Only" /><br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" rowspan="3" style="width: 182px" valign="top">
                    <table id="Table6" cellpadding="2" cellspacing="0"  width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color">
                                Display Options</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkJob" runat="server" Text="Job Number" />
                                <br />
                                <asp:CheckBox ID="chkJobDesc" runat="server" Text="Job Description" />
                                <br />
                                <asp:CheckBox ID="chkComponent" runat="server" Text="Component" />
                                <br />
                                <asp:CheckBox ID="chkJobCompDesc" runat="server" Text="Component Description" />
                                <br />
                                <asp:CheckBox ID="chkClient" runat="server" Text="Client Code" />
                                <br />
                                <asp:CheckBox ID="chkClientName" runat="server" Text="Client Name" />
                                <br />
                                <asp:CheckBox ID="chkDivision" runat="server" Text="Division Code" />
                                <br />
                                <asp:CheckBox ID="chkDivisionName" runat="server" Text="Division Name" />
                                <br />
                                <asp:CheckBox ID="chkProduct" runat="server" Text="Product Code" />
                                <br />
                                <asp:CheckBox ID="chkProductName" runat="server" Text="Product Name" />
                                <br />
                                <asp:CheckBox ID="chkCampaign" runat="server" Text="Campaign Code" />
                                <br />
                                <asp:CheckBox ID="chkCampaignName" runat="server" Text="Campaign Name" />
                                <br />
                                <asp:CheckBox ID="chkEmp" runat="server" Checked="true" Text="Employee Assigned/Resource Name" Enabled="false"/>
                                <br />                            
                                <asp:CheckBox ID="chkHoursPosted" runat="server" Checked="True" Text="Hours Posted" Enabled="false" />
                                <br />
                                <asp:CheckBox ID="chkHoursAssigned" runat="server" Enabled="true" Text="Hours Assigned" />
                                <br />
                                <asp:CheckBox ID="chkTotalHoursPosted" runat="server" Text="Total Hours Posted" />
                                <br />
                                <hr size="1" width="100%">
                            </td>
                        </tr>
                    </table>                
                    <asp:CheckBox ID="CheckBoxGroup" runat="server" Text="Group By Job/Component" AutoPostBack="true" />
                    <br />
                    <asp:CheckBox ID="CheckBoxGroupCampaign" runat="server" Text="Group By Campaign" AutoPostBack="true" />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <table id="Table4" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color">
                                Date Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table id="Table8" align="center" border="0" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td align="right" >
                                            Start Date:</td>
                                        <td align="left" style="height: 37px">
                                            &nbsp;
                                            <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" >
                                            End Date:</td>
                                        <td align="left" >
                                            &nbsp;
                                            <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" 
                                                  SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="End Date">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table id="Table11" align="center" cellpadding="2" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td align="center" class="sub-header sub-header-color">
                                 Sort Options
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:RadioButton ID="rbNone" runat="server" Checked="True" GroupName="SortOptions" Text="Client/Division/Product" />
                                <br />
                                <asp:RadioButton ID="rbJC" runat="server" GroupName="SortOptions" Text="Job/Component" />
                                <br />
                                <asp:RadioButton ID="rbEmp" runat="server" GroupName="SortOptions" Text="Employee" />
                                <br />
                                <asp:RadioButton ID="rbCDPC" runat="server" GroupName="SortOptions" Text="Client/Division/Product/Campaign" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" valign="top">
                    &nbsp;<uc1:reporttype ID="reporttype" runat="server" Visible="false" />
                    &nbsp; &nbsp;<br />
                    <br />
                    <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" />&nbsp;<br />
                    <br />
                    <asp:Button ID="butView" runat="server"  Text="View" /><br /><br />
                </td>
            </tr>
            <asp:DataGrid ID="gridReport" runat="server" CellPadding="0" GridLines="None" Width="99%">
                <HeaderStyle CssClass="SubHeaderStyle" />
                <AlternatingItemStyle  />
                <ItemStyle  />
            </asp:DataGrid>
        </table>
    </div>
  
</asp:Content>
