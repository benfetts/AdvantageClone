<%@ Page AutoEventWireup="false" CodeBehind="Timesheet_QuickAdd.aspx.vb" Inherits="Webvantage.Timesheet_QuickAdd"
    MasterPageFile="~/ChildPage.Master" Title="Add Time to Task" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBarTimesheetQuickAdd" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton Text="" Value="Save" CommandName="Save" SkinID="RadToolBarButtonSave"
                    ToolTip="Save">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Cancel" Value="Cancel" CommandName="Cancel" SkinID="RadToolBarButtonClear"
                    ToolTip="Cancel">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                <tr>
                    <td colspan="4">
                        <h4>
                            Task Details</h4>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;Client:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:HiddenField ID="HfClient" runat="server" />
                        <asp:TextBox ID="TextBoxClientCode" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxClientDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;<asp:Label ID="LabelDivisionAlias" runat="server"></asp:Label>:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxDivisionCode" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxDivisionDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;<asp:Label ID="LabelProductAlias" runat="server"></asp:Label>:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxProductCode" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxProductDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle" width="19%">
                        &nbsp;&nbsp;<asp:Label ID="LabelJobAlias" runat="server"></asp:Label>:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxJobNumber" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxJobDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;<asp:Label ID="LabelJobComponentAlias" runat="server"></asp:Label>:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxJobComponentNbr" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxJobComponentDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;Task:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxTaskCode" runat="server" TabIndex="4" Width="85" ReadOnly="true"></asp:TextBox>
                        <asp:TextBox ID="TextBoxTaskDescription" runat="server" TabIndex="-1" Width="261"
                            ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;&nbsp;Task Comment:
                    </td>
                    <td colspan="3" valign="middle">
                        <asp:TextBox ID="TextBoxTaskComment" runat="server" TabIndex="-1" Width="350" ReadOnly="true"
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h4>
                            Time Entry</h4>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;Date:
                    </td>
                    <td valign="middle" width="24%">
                        <telerik:RadDatePicker ID="RadDatePickerDate" runat="server" 
                              SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            </Calendar>
                        </telerik:RadDatePicker>
                    </td>
                    <td valign="middle" width="12%">
                        <asp:Label ID="LabelFunctionAlias" runat="server"></asp:Label>:
                    </td>
                    <td valign="middle" width="45%">
                        <telerik:RadComboBox ID="DropFunction" runat="server" Width="250px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr id="ProdCatRow" runat="server">
                    <td valign="middle">
                        &nbsp;
                    </td>
                    <td valign="middle" width="24%">
                        &nbsp;
                    </td>
                    <td valign="middle" width="12%">
                        <asp:Label ID="LabelProductCategoryAlias" runat="server"></asp:Label>:
                    </td>
                    <td valign="middle" width="45%">
                        <telerik:RadComboBox ID="DropProdCat" runat="server" Width="250px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;Hours:
                    </td>
                    <td valign="middle">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxHours" runat="server" Enabled="true" Width="40px" MinValue="0" MaxValue="24">
                            <IncrementSettings InterceptArrowKeys="false" InterceptMouseWheel="false" />
                            <NumberFormat DecimalDigits="2" />
                        </telerik:RadNumericTextBox>
                        <asp:ImageButton ID="ImageButtonStopwatch" runat="server" ImageAlign="Top" ToolTip="Click to start Stopwatch"
                            SkinID="ImageButtonStopwatchStart" />
                    </td>
                    <td valign="middle">
                        Department:
                    </td>
                    <td valign="middle">
                        <telerik:RadComboBox ID="DropDepartment" runat="server" Width="250px">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;&nbsp;Percent Complete:
                    </td>
                    <td valign="middle">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxPercentComplete" runat="server" Enabled="true" Width="40px" MinValue="0" MaxValue="100">
                            <IncrementSettings InterceptArrowKeys="false" InterceptMouseWheel="false" Step="1" />
                            <NumberFormat DecimalDigits="2" />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td valign="middle">
                        &nbsp;
                    </td>
                    <td valign="middle">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="bottom">
                        &nbsp;&nbsp;Time Comment:
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;&nbsp;<asp:TextBox ID="TxtComments" runat="server" Height="60px" TextMode="multiLine"
                            Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h4>
                            Mark Completed?<asp:CheckBox ID="ChkMarkCompleted" runat="server" Text="" /></h4>
                        <asp:HiddenField ID="HfAlreadyMarked" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="bottom">
                        &nbsp;&nbsp;Completed Comment:
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;&nbsp;<asp:TextBox ID="TxtCompletedComments" runat="server" Height="60px" TextMode="multiLine"
                            Width="450px"></asp:TextBox>
                    </td>
                </tr>
            </table>
    </div>

    
</asp:Content>
