<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Batch.aspx.vb" Inherits="Webvantage.BillingApproval_Batch"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Approval Batch Entry/Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <!-- RadToolTip Script -->
        <script type="text/javascript">
            function DisplayDetails() {
                var divDetails = document.getElementById('divDetails');
                divDetails.style.display = "inline";
            }

            function CloseActiveToolTip() {
                setTimeout(function () {
                    var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                    var tooltip = controller.get_activeToolTip();
                    if (tooltip) tooltip.hide();
                }, 1000);
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentBABatch" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Animation="None" RenderMode="Classic"
        Height="75px" ManualClose="false" Modal="false" OnAjaxUpdate="OnAjaxUpdate" Position="BottomRight"
        RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true" Width="260px">
    </telerik:RadToolTipManager>
    <telerik:RadToolTipManager ID="RadToolTipManager2" runat="server" Animation="None" RenderMode="Classic"
        Height="75px" ManualClose="true" Modal="true" OnAjaxUpdate="OnAjaxUpdate2" Position="MiddleLeft"
        RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true" Width="560px">
    </telerik:RadToolTipManager>
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarBillingApprovalBatch" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton id="RadToolBarButtonSave" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" ToolTip="Save new batch" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonFinished"
                    Text="Finished" Value="Finish" CheckOnClick="true" AllowSelfUnCheck="true" ToolTip="Mark batch as finished" />
                <telerik:RadToolBarButton Text="Alert" Value="Alert" ToolTip="Alert" />
                <telerik:RadToolBarButton id="RadToolBarButtonDelete" SkinID="RadToolBarButtonDelete" CommandName="Delete" Value="Delete" ToolTip="Delete this batch" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonClear"
                    k Visible="false" Value="Back" ToolTip="" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton id="RadToolBarButtonImageStatus">
                    <ItemTemplate>
                        <asp:Image ID="ImageStatus" runat="server" AlternateText="" ImageUrl="~/Images/spacer.gif"
                            ToolTip="" Visible="false" />
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;&nbsp;Current Status:&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonCurrentStatus">
                    <ItemTemplate>
                        <asp:Label ID="LabelCurrentStatus" runat="server" Text=" - "></asp:Label>&nbsp;&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;&nbsp;Alert Status:&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton id="RadToolBarButtonAlertStatus">
                    <ItemTemplate>
                        <asp:Label ID="LabelAlertStatus" runat="server" Text=" - "></asp:Label>&nbsp;&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCreateApprovals" Text="Create Approvals" CommandName="CreateApprovals" Value="CreateApprovals"
                    DisplayType="textImage" CheckOnClick="true" AllowSelfUnCheck="true" Visible="false"
                    ToolTip="Select to automatically create Approvals for this Batch's Clients upon save" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
            </Items>
        </telerik:RadToolBar>
    </div>

    <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
        TitleText="Batch Information">
        <div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:Label ID="LblBatchIDTitle" runat="server" Text="Batch ID:"></asp:Label>
                </div>
                <div class="code-description-code">
                     <asp:Label ID="LblBatchID" runat="server" Text="[New]"></asp:Label>
               </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Batch Description:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtBatchDescription" runat="server" CssClass="RequiredInput" MaxLength="50" SkinID="TextBoxStandard"
                        TabIndex="1" Text="" Width="360px"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Batch Date:
                </div>
                <div class="code-description-code">
                    <telerik:RadDatePicker ID="RadDatePickerBatchDate" runat="server"
                        TabIndex="2" SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="" CssClass="RequiredInput">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="code-description-description">
                     <asp:Label ID="LblJobList" runat="server" Text="Job List" Visible="true" CssClass="underline" style="cursor:pointer;"></asp:Label>
               </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                         <asp:HyperLink ID="HlEmployee" runat="server" href="" TabIndex="-1" Text="Assigned Employee:"></asp:HyperLink>
               </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtEmployeeCode" runat="server" CssClass="RequiredInput" MaxLength="6"
                        TabIndex="3" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                     <asp:TextBox ID="TxtEmployeeDescription" runat="server" ReadOnly="true" TabIndex="-1"
                         Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
               </div>
            </div>
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelSelectionCriteria" runat="server"
        TitleText="Selection Criteria">
        <table border="0" cellspacing="2" cellpadding="0" style="margin: 8px;">
            <tr>
                <td>Date Cutoff:
                </td>
                <td>Period Cutoff:
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerDateCutoff" runat="server"
                        TabIndex="4" SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="" BackColor="#FFFFCC">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
                <td>
                    <telerik:RadComboBox ID="DropPostingPeriod" runat="server" TabIndex="5" Width="90" BackColor="#FFFFCC" SkinID="RadComboBoxStandard">
                        <Items>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table border="0" cellspacing="2" cellpadding="0" style="margin: 8px;">
                <tr>
                    <td>
                        <asp:RadioButton ID="RadioButtonManagerTypeAE" runat="server" Checked="true" GroupName="ManagerType"
                            AutoPostBack="true" />Account Executive:
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButtonManagerTypePM" runat="server" GroupName="ManagerType"
                            AutoPostBack="true" /><asp:Label ID="LabelProjectManagerTitle" runat="server" Text="Project Manager"></asp:Label>:
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:Literal ID="LitAEs" runat="server"></asp:Literal>
                        </div>
                        <telerik:RadListBox ID="LbAEs" runat="server" AutoPostBack="False" Height="127px"
                            SelectionMode="Multiple" TabIndex="6" Width="278px">
                        </telerik:RadListBox>
                    </td>
                    <td valign="top">
                        <div style="margin-left: 4px;">
                            <asp:Literal ID="LiteralProjectManagers" runat="server"></asp:Literal>
                        </div>
                        <telerik:RadListBox ID="RadListBoxProjectManagers" runat="server" AutoPostBack="False"
                            Height="127px" SelectionMode="Multiple" TabIndex="6" Width="278px">
                        </telerik:RadListBox>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelSelectionLevel" runat="server"
        TitleText="Selection Level">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="left" border="0" cellpadding="0" cellspacing="2" width="855" style="margin: 8px;">
                <tr>
                    <td>
                        <asp:RadioButtonList ID="RblSelectionLevel" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            RepeatLayout="Table" TabIndex="7">
                            <asp:ListItem Value="CDPC">All</asp:ListItem>
                            <asp:ListItem Value="CLIENT">Client</asp:ListItem>
                            <asp:ListItem Value="DIVISION">Division</asp:ListItem>
                            <asp:ListItem Value="PRODUCT">Product</asp:ListItem>
                            <asp:ListItem Value="CAMPAIGN">Campaign</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <table align="left" border="0" cellpadding="2" cellspacing="2" width="100%">
                            <tr>
                                <td>
                                    <asp:Literal ID="LitCDPCSelections" runat="server"></asp:Literal>
                                    <telerik:RadListBox ID="LbCDPCSelections" runat="server" AutoPostBack="False" Height="185px"
                                        SelectionMode="Multiple" TabIndex="8" Width="554">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelJobSelections" runat="server"
        TitleText="Job List">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="2" width="925" style="margin: 8px;">
                <tr>
                    <td valign="top">
                        <asp:Button ID="BtnSaveJobListTop" runat="server" Text="Save" ToolTip="Save checked jobs to batch" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <a name="JobList" id="JobList"></a>
                        <telerik:RadGrid ID="RadGridJobList" runat="server" AllowMultiRowSelection="False"
                            AllowSorting="True" AllowPaging="true" AutoGenerateColumns="False" EnableAJAX="False"
                            GridLines="None" PageSize="50">
                            <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                            <MasterTableView AllowMultiColumnSorting="True" NoMasterRecordsText="No records found">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="" UniqueName="ColSelect">
                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="20" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="20" />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="ChkAllJobs" runat="server" AutoPostBack="true" OnCheckedChanged="ChkAllJobs_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkJob" runat="server" />
                                            <asp:HiddenField ID="HfJOB_NUMBER" runat="server" Value='<%#Eval("JOB_NUMBER")%>' />
                                            <asp:HiddenField ID="HfJOB_COMPONENT_NBR" runat="server" Value='<%#Eval("JOB_COMPONENT_NBR")%>' />
                                            <asp:HiddenField ID="HfBA_BATCH_ID" runat="server" Value='<%#Eval("BA_BATCH_ID")%>' />
                                            <asp:HiddenField ID="HfMY_KEY" runat="server" Value='<%#Eval("MY_KEY")%>' />
                                            <asp:HiddenField ID="HfIS_ON_BATCH" runat="server" Value='<%#Eval("IS_ON_BATCH")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="" HeaderText="Saved" UniqueName="ColSAVED_TO_BATCH"
                                        SortExpression="IS_ON_BATCH">
                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="LbLSAVED_TO_BATCH" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="JOB_AND_COMPONENT" HeaderText="Job/Component"
                                        SortExpression="JOB_AND_COMPONENT" UniqueName="ColJOB_AND_COMPONENT">
                                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                        <ItemTemplate>
                                            <asp:Label ID="LblJOB_AND_COMPONENT" runat="server" Text='<%#Eval("JOB_AND_COMPONENT")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="CL_CODE" HeaderText="Client" UniqueName="ColCL_CODE">
                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="ColDIV_CODE">
                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="ColPRD_CODE">
                                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="75" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:Button ID="BtnSaveJobListBottom" runat="server" Text="Save" ToolTip="Save checked jobs to batch" />
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        <asp:HiddenField ID="HfSavedYesColor" runat="server" Value="#CEFFCE" />
        <asp:HiddenField ID="HfSavedNoColor" runat="server" Value="#FFCACA" />
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelIncludeOptions" runat="server"
        TitleText="Include Options">
            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <table align="left" border="0" cellpadding="0" cellspacing="2" width="855" style="margin: 8px;">
                <tr>
                    <td>&nbsp; <span>Include Jobs:</span>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;
                        <asp:RadioButton ID="RbOpenJobsWithoutUnbilledRecords" runat="server" 
                            Text="Open Jobs with Unbilled or Other Records" GroupName="IncludeJobs" />
                        <span>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Advance Billed, Approved
                            Estimate, Open PO's] </span>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;
                        <asp:RadioButton ID="RbOpenJobsWithUnbilledRecordsOnly" runat="server" 
                            Text="Open Jobs with Unbilled Records Only" GroupName="IncludeJobs" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;
                        <asp:RadioButton ID="RbAllOpenJobs" runat="server" Text="All Open Jobs"
                            GroupName="IncludeJobs" />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">&nbsp;
                    </td>
                </tr>
                <tr runat="server" id="TrIncludeDetail0">
                    <td>&nbsp; <span>Include in Detail:</span>
                    </td>
                </tr>
                <tr runat="server" id="TrIncludeDetail1">
                    <td>&nbsp;&nbsp;
                        <asp:CheckBox ID="ChkFeeTimeRecords" runat="server" Text="Fee Time Records" Enabled="true" />
                    </td>
                </tr>
                <tr runat="server" id="TrIncludeDetail2">
                    <td>&nbsp;&nbsp;
                        <asp:CheckBox ID="ChkNonBillableRecords" runat="server" Text="Non Billable Records"
                            Enabled="true" />
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </ew:CollapsablePanel>
    <asp:CheckBoxList ID="ChkBxLstMediaOptions" runat="server" Enabled="false" RepeatColumns="2"
        Visible="false" RepeatDirection="Horizontal" TabIndex="10">
        <asp:ListItem Value="Internet" Text="Internet"></asp:ListItem>
        <asp:ListItem Value="Magazine" Text="Magazine"></asp:ListItem>
        <asp:ListItem Value="Newspaper" Text="Newspaper"></asp:ListItem>
        <asp:ListItem Value="OutOfHome" Text="Out Of Home"></asp:ListItem>
        <asp:ListItem Value="Radio" Text="Radio"></asp:ListItem>
        <asp:ListItem Value="TV" Text="TV"></asp:ListItem>
    </asp:CheckBoxList>
</asp:Content>
