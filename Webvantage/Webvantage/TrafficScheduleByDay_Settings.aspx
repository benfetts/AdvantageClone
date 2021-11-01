<%@ Page Title="Schedule By Day Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficScheduleByDay_Settings.aspx.vb" Inherits="Webvantage.TrafficScheduleByDay_Settings" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
            .rlbItem
            {
                text-align: left !important;
                
            }
    </style>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <table align="center" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color">
                           Selection Options
                        </td>
                        <td align="center" class="sub-header sub-header-color">
                           Display Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:Label   ID="lblMessage" runat="server" CssClass="warning"></asp:Label>
                            <asp:Panel ID="PanelOptions" runat="server">
                            <asp:RadioButtonList ID="rblOffices" runat="server" Width="200px" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Offices</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Offices</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lbOffices" runat="server" Height="50px" AutoPostBack="True" Width="300px">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <div style="width: 450px; margin-left: auto; margin-right: auto; text-align:center; margin-bottom:15px;">
                                <label>Select By:</label>
                                <asp:RadioButtonList ID="RadioButtonListSelectBy" runat="server" OnSelectedIndexChanged="RadioButtonListSelectBy_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow"  >
                                <asp:ListItem Selected="True" Value="Client">Client</asp:ListItem>
                                <asp:ListItem Value="Division">Division</asp:ListItem>
                                <asp:ListItem Value="Product">Product</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <asp:RadioButtonList ID="rdlClients" runat="server" Width="200px" AutoPostBack="true" >
                                <asp:ListItem Selected="True" Value="all">All Clients</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Clients</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstClients" runat="server" AutoPostBack="false" Width="450px" Height="200px" DataTextField="description" DataValueField="code" SelectionMode="Multiple" EnableLoadOnDemand="false">
                            </telerik:RadListBox>
                            <br />
                            <hr size="1" width="100%" />
                            <asp:RadioButtonList ID="rdlAE" runat="server" Width="400" AutoPostBack="True">
                                <asp:ListItem Selected="True" Value="all">All Account Executives</asp:ListItem>
                                <asp:ListItem Value="Choose">Choose Account Executives</asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <telerik:RadListBox ID="lstAEs" runat="server" Height="50px" SelectionMode="Multiple" Width="300px">
                            </telerik:RadListBox>
                            <hr size="1" width="100%" />
                            </asp:Panel>
                            <asp:CheckBox ID="chkClosedJobs" runat="server" Text="Include Closed Jobs" /><br />
                            <hr size="1" width="100%" />
                            <asp:CheckBox ID="chkCompleted" runat="server" Text="Include Completed Tasks" /><br />
                            <hr size="1" width="100%" />
                            <table>
                                <tr>
                                    <td height="30px" align="center" valign="top">
                                        <asp:Label   ID="lblManager" runat="server"></asp:Label>&nbsp;&nbsp;
                                        <telerik:RadComboBox ID="ddManager" runat="server">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <asp:CheckBox ID="chkManager" runat="server" Text="Manager" /><br />
                            <asp:CheckBox ID="chkProjectDate" runat="server" Text="Job Start Date" /><br />
                            <asp:CheckBox ID="chkClientCode" runat="server" Text="Client Code" /><br />
                            <asp:CheckBox ID="chkClientDesc" runat="server" Text="Client Description" /><br />
                            <asp:CheckBox ID="chkDivisionCode" runat="server" Text="Division Code" /><br />
                            <asp:CheckBox ID="chkDivisionDesc" runat="server" Text="Division Description" /><br />
                            <asp:CheckBox ID="chkProductCode" runat="server" Text="Product Code" /><br />
                            <asp:CheckBox ID="chkProductDesc" runat="server" Text="Product Description" /><br />
                            <asp:CheckBox ID="chkJobCompNum" runat="server" Text="Job Component" /><br />
                            <asp:CheckBox ID="chkJobCompDesc" runat="server" Text="Job Comp Description" /><br />
                            <asp:CheckBox ID="chkClientReference" runat="server" Text="Client Reference" /><br />
                            <asp:CheckBox ID="chkAccountExecutive" runat="server" Text="Account Executive" /><br />
                            <asp:CheckBox ID="chkJobType" runat="server" Text="Job Type" /><br />
                            <asp:CheckBox ID="chkJobTypeDesc" runat="server" Text="Job Type Description" /><br />
                            <asp:CheckBox ID="chkTrafficStatus" runat="server" Text="Traffic Status" /><br />
                            <asp:CheckBox ID="chkComments" runat="server" Text="Traffic Comments" /><br />
                            <asp:CheckBox ID="CheckBoxPhase" runat="server" Text="Phase" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Report Title
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <br />
                            <asp:TextBox ID="txtReportTitle" runat="server" Width="400" SkinID="TextBoxStandard">Schedule by Days</asp:TextBox><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Day Column Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" valign="top">
                            <br />
                            <table border="0" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td>
                                        <span>Employee:</span>&nbsp;
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddEmpoyeeOption" runat="server" Width="275">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="1" Text="Emp Code"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2" Text="First Initial, Last Name"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span>Tasks:</span>&nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="ddTaskOption" runat="server" Width="400">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="1" Text="Task Code (or First 10 Characters of Task Description)">
                                                </telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2" Text="Task Code (or First 30 Characters of Task Description)">
                                                </telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="3" Text="Task Description"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Date Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" valign="top">
                            <br />
                            <table border="0" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td align="right">
                                        <span>Starting Date:</span>&nbsp;
                                    </td>
                                    <td align="left">
                                        <telerik:RadDatePicker ID="RadDatePickerStartingDate" runat="server" 
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
                                <tr>
                                    <td align="right">
                                        <span>Days:</span>&nbsp;
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddDays" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="1" Text="1"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="2" Text="2"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="3" Text="3"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="4" Text="4"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="5" Text="5"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="6" Text="6"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="7" Text="7"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="8" Text="8"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="9" Text="9"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="10" Text="10"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="11" Text="11"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="12" Text="12"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="13" Text="13"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="14" Text="14"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="15" Text="15"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="16" Text="16"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="17" Text="17"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="18" Text="18"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="19" Text="19"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="20" Text="20"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="21" Text="21"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="22" Text="22"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="23" Text="23"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="24" Text="24"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="25" Text="25"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="26" Text="26"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="27" Text="27"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="28" Text="28"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="29" Text="29"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="30" Text="30"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:CheckBox ID="chkWeekends" runat="server" Text="Exclude Weekends" /><br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="sub-header sub-header-color">
                           Sort&nbsp;Options
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 95px">
                            <br />
                            <table border="0">
                                <tr>
                                    <td align="right" style="height: 1px">
                                        <span>Date Column Sort:</span>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddColSort" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Selected="True" Value="emp" Text="Employee"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="task" Text="Task"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 1px">
                                        <span>Primary Sort:</span>
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="ddSort1" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Selected="True" Value="Client Code" Text="Client Code">
                                                </telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Division Code" Text="Division Code"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Product Code" Text="Product Code"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Job Number" Text="Job Number/Job Comp"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Job Description" Text="Job Description"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Client Division Product" Text="Client Division Product">
                                                </telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadComboBox ID="ddSort1Direction" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="ASC" Text="Ascending"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="DESC" Text="Descending"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="height: 21px">
                                        <span>Secondary Sort:</span>
                                    </td>
                                    <td align="left" style="height: 21px">
                                        <telerik:RadComboBox ID="ddSort2" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Selected="True" Value="Client Code" Text="Client Code">
                                                </telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Division Code" Text="Division Code"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Product Code" Text="Product Code"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Job Number" Text="Job Number/Job Comp"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Job Description" Text="Job Description"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="Client Division Product" Text="Client Division Product">
                                                </telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                        <telerik:RadComboBox ID="ddSort2Direction" runat="server">
                                            <Items>
                                                <telerik:RadComboBoxItem Value="ASC" Text="Ascending"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Value="DESC" Text="Descending"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:CheckBox ID="chkSaveSettings" runat="server" Text="Save My Options" /><br />
                            <br />
                            <asp:Button ID="butView" runat="server" Text="View" /><br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
