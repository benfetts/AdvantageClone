<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="JobStatus_Team.aspx.vb" Inherits="Webvantage.JobStatus_Team" %>

<%@ Register Src="Employee_Card.ascx" TagPrefix="Content" TagName="Employee_Card" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        .black-text {
            color: #000000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
                    <telerik:RadToolBar ID="RadToolBarTeam" runat="server" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton Group="Team" AllowSelfUnCheck="true" CheckOnClick="true" Text="Alert Group" Value="AlertGroup" Checked="true"></telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Group="Team" AllowSelfUnCheck="true" CheckOnClick="true" Text="Account Executive" Value="AccountExecutive"></telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Group="Team" AllowSelfUnCheck="true" CheckOnClick="true" Text="Manager" Value="Manager"></telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Group="Team" AllowSelfUnCheck="true" CheckOnClick="true" Text="Schedule Assignments" Value="ScheduleAssignments"></telerik:RadToolBarButton>
                            <telerik:RadToolBarButton Group="Team" AllowSelfUnCheck="true" CheckOnClick="true" Text="Task Assignments" Value="ScheduleTaskAssignments"></telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>
                </div>
                <div class="telerik-aqua-body">
                    <asp:MultiView ID="MultiViewEdit" runat="server">
                        <asp:View ID="ViewEditAlertGroupButtons" runat="server">
                            <div id="DivAlertGroup" style="margin: 15px 0px 15px 0px; font-size: 14px">
                                <telerik:RadComboBox ID="RadComboBoxAlertGroup" runat="server" Width="300px" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                <asp:ImageButton ID="ImageButtonSaveAlertGroup" runat="server" SkinID="ImageButtonSave" />
                            </div>
                        </asp:View>
                        <asp:View ID="ViewEditButtons" runat="server">
                            <div id="DivEdit" style="margin: 15px 0px 0px 15px; ">
                                <asp:ImageButton ID="ImageButtonEdit" runat="server" SkinID="ImageButtonEdit" />
                                <asp:ImageButton ID="ImageButtonCancel" runat="server" SkinID="ImageButtonCancel" />
                                <asp:Label ID="LabelInstructionsForDummies" runat="server" Text=""></asp:Label>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                    <asp:MultiView ID="MultiViewContent" runat="server">
                        <asp:View ID="ViewEditManagers" runat="server">
                            <div style="margin:20px 0px 0px 0px;">
                                <div style="display:inline-block;vertical-align:top;width:410px;">
                                    <telerik:RadListBox ID="RadListBoxEditManagersEmployees" runat="server" SelectionMode="Single" BorderStyle="None"
                                        AllowTransfer="false" AllowTransferOnDoubleClick="false" EnableDragAndDrop="true" Width="400" Height="700">
                                        <ItemTemplate>
                                            <div style="height: 50px;">
                                                <div style="display: inline-block; height: 50px;">
                                                    <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
                                                        ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png"></dx:ASPxBinaryImage>
                                                </div>
                                                <div style="display: inline-block;height:50px; vertical-align: middle;margin-top: 1px;">
                                                    <%#Eval("FullName")%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadListBox>
                                </div>
                                <div style="display: inline-block; vertical-align: top;">
                                    <div style="margin:-23px 0px 0px 0px;" class="card-container">
                                        <div id="DivScheduleManager" runat="server" style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonManagerSave" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png" Visible="false"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the manager" />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonManagerRemove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current manager" />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardManager" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="ViewEditAccountExecutive" runat="server">
                            <div style="margin: 20px 0px 0px 0px;">
                                <div style="display: inline-block; vertical-align: top; width: 410px;">
                                    <telerik:RadListBox ID="RadListBoxAccountExecutives" runat="server" SelectionMode="Single" BorderStyle="None"
                                        AllowTransfer="false" AllowTransferOnDoubleClick="false" EnableDragAndDrop="true" Width="400" Height="700">
                                        <ItemTemplate>
                                            <div style="height: 50px;">
                                                <div style="display: inline-block; height: 50px;">
                                                    <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
                                                        ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png"></dx:ASPxBinaryImage>
                                                </div>
                                                <div style="display: inline-block; height: 50px; vertical-align: middle; margin-top: 1px;">
                                                    <%#Eval("FullName")%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadListBox>
                                </div>
                                <div style="display: inline-block; vertical-align: top;">
                                    <div style="margin: -23px 0px 0px 0px;" class="card-container">
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAccountExecutiveSave" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png" Visible="false"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the account executive" />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px; display: none;">
                                                    <asp:ImageButton ID="ImageButtonAccountExecutiveRemove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current account executive" Visible="false" />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="EmployeeCardAccountExecutive" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="ViewEditScheduleAssignments" runat="server">
                            <div style="margin: 20px 0px 0px 0px;">
                                <div style="display: inline-block; vertical-align: top; width: 410px;">
                                    <telerik:RadListBox ID="RadListBoxEditScheduleAssignmentsEmployees" runat="server" SelectionMode="Single"
                                        AllowTransfer="false" AllowTransferOnDoubleClick="false" EnableDragAndDrop="true" Width="400" Height="700">
                                        <ItemTemplate>
                                            <div style="height: 50px;">
                                                <div style="display: inline-block; height: 50px;">
                                                    <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
                                                        ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png"></dx:ASPxBinaryImage>
                                                </div>
                                                <div style="display: inline-block; height: 50px; vertical-align: middle; margin-top: 1px;">
                                                    <%#Eval("FullName")%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:RadListBox>
                                </div>
                                <div style="display: inline-block;">
                                    <div style="margin: -23px 0px 0px 0px;" class="card-container">
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px;display:none !important;">
                                                    <asp:ImageButton ID="ImageButtonAssignment1Save" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the " />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAssignment1Remove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current " />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardAssignment1" runat="server" />
                                            </div>
                                        </div>
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px; display: none !important;">
                                                    <asp:ImageButton ID="ImageButtonAssignment2Save" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the " />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAssignment2Remove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current " />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardAssignment2" runat="server" />
                                            </div>
                                        </div>
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px; display: none !important;">
                                                    <asp:ImageButton ID="ImageButtonAssignment3Save" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the " />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAssignment3Remove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current " />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardAssignment3" runat="server" />
                                            </div>
                                        </div>
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px; display: none !important;">
                                                    <asp:ImageButton ID="ImageButtonAssignment4Save" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the " />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAssignment4Remove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current " />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardAssignment4" runat="server" />
                                            </div>
                                        </div>
                                        <div style="width: 380px; height: 200px; position: relative;">
                                            <div style="float: left; width: 48px;">
                                                <div style="margin: 15px 0px 0px 0px; display: none !important;">
                                                    <asp:ImageButton ID="ImageButtonAssignment5Save" runat="server" ImageUrl="~/Images/Icons/Grey/256/floppy_disk.png"
                                                        Height="48" Width="48" ToolTip="Drag an employee name from the list on the left onto this icon to set the employee as the " />
                                                </div>
                                                <div style="margin: 20px 0px 0px 0px;">
                                                    <asp:ImageButton ID="ImageButtonAssignment5Remove" runat="server" ImageUrl="~/Images/Icons/Grey/256/remove.png"
                                                        Height="48" Width="48" ToolTip="Remove current " />
                                                </div>
                                            </div>
                                            <div style="float: right;">
                                                <Content:Employee_Card ID="Employee_CardAssignment5" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="ViewEditScheduleTasks" runat="server">
                            <div style="margin: 10px 0px 0px 0px;">
                                <div id="DivTaskEmployeeFilter" runat="server">
                                    <div>
                                        <div style="display: inline-block; vertical-align: top; width: 410px; margin-bottom: 10px;">
                                        </div>
                                        <div style="display: inline-block; vertical-align: top; width: 410px; margin-bottom: 10px;">
                                            <div>
                                                Filter
                                                <asp:RadioButtonList ID="RadioButtonListTaskEmployeeFilter" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Text="By Role" Value="role" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Alert Group" Value="alert_group"></asp:ListItem>
                                                    <asp:ListItem Text="By Department" Value="department"></asp:ListItem>
                                                    <asp:ListItem Text="Show All" Value="all"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="DivTaskEmployeeFilterRadComboBox" runat="server">
                                        <div style="display: inline-block; vertical-align: top; width: 410px; margin-bottom: 10px;">
                                        </div>
                                        <div style="display: inline-block; vertical-align: top; width: 410px; margin-bottom: 10px;">
                                            <div>
                                                <telerik:RadComboBox ID="RadComboBoxTaskEmployeeFilter" runat="server" AutoPostBack="true" Width="400" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <div style="display: inline-block; vertical-align: top; width: 410px;">
                                        <telerik:RadListBox ID="RadListBoxEditScheduleTasksTaskList" runat="server" SelectionMode="Single" AutoPostBack="true"
                                            AllowTransfer="false" AllowTransferOnDoubleClick="false" EnableDragAndDrop="false" Width="400" Height="700">
                                            <ItemTemplate>
                                                <div style="height: 50px;">


                                                    <div class="team_task_employee_icon">
              
                                                        <div id="DivPriorityColor" runat="server" class="icon-background background-color-sidebar">
                                                            <asp:Image ID="ImagePriority" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/progress_bar.png" />
                                                        </div>

                                                    </div>

                                                    <div style="display: inline-block; vertical-align: top; margin: 6px 0px 0px 0px;">
                                                        <div id="DivDescription" runat="server">
                                                            <asp:Label ID="LabelDescription" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="DivStartDue" runat="server">
                                                            <asp:Label ID="LabelStartDue" runat="server"></asp:Label>
                                                        </div>
                                                    </div>


                                                </div>
                                            </ItemTemplate>
                                        </telerik:RadListBox>
                                    </div>
                                    <div style="display: inline-block; vertical-align: top; width: 410px;">
                                        <telerik:RadListBox ID="RadListBoxEditScheduleTasksEmployees" runat="server" SelectionMode="Multiple" CheckBoxes="false" AutoPostBack="true"
                                            AllowTransfer="false" AllowTransferOnDoubleClick="false" EnableDragAndDrop="false" Width="400" Height="700">
                                            <ItemTemplate>
                                                <div style="height: 50px;">
                                                    <div style="display: inline-block; height: 50px;">
                                                        <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' CssClass="wv-employee-img-thumbnail-lg" BinaryStorageMode="Session"
                                                            ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png"></dx:ASPxBinaryImage>
                                                    </div>
                                                    <div style="display: inline-block; height: 50px; vertical-align: middle; margin-top: 1px;">
                                                        <%#Eval("FullName")%>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:RadListBox>
                                    </div>
                                </div>
                            </div>
                        </asp:View>
                        <asp:View ID="ViewEmployeeCards" runat="server">
                            <div id="DivEmployeeCardsPlaceholder" class="card-container" style="margin-left: 15px">
                                <asp:PlaceHolder ID="PlaceHolderEmployees" runat="server"></asp:PlaceHolder>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
