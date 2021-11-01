<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Approval_Detail.aspx.vb"
    Inherits="Webvantage.BillingApproval_Approval_Detail" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Billing Approval Entry/Edit" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="ContentApprovalDetail" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function DefaultDescription(tbClientName, tbApprovalDescription) {
                var tb1 = document.getElementById(tbClientName);
                var tb2 = document.getElementById(tbApprovalDescription);

                if (tb2.value == "") {
                    tb2.value = tb1.value;
                }
            }

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
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
            }
            

        function lookupComplete(control) {
            var element = $('#' + control);
            if (element) {
                if (element.prop('Lookup') !== '') {
                    element.change();
                }
            }
        }
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarBillingApproval" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    CommandName="Save" ToolTip="Save approval" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Value="Delete"
                    CommandName="Delete" ToolTip="Delete approval" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Text="Print" Value="Print"
                    CommandName="Print" ToolTip="Print" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server" TitleText="Approval Information">
        <asp:Label ID="LblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
        <asp:HiddenField ID="HfBatchID" runat="server" />
        <div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlClient" runat="server" href="">Client:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtClientCode" runat="server" CssClass="RequiredInput" MaxLength="6"
                        TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientDescription" runat="server" CssClass="RequiredInput" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Batch ID:
                </div>
                <div class="code-description-code" style="padding-top: 4px;">
                    <asp:Label ID="LblBatchID" runat="server"></asp:Label>
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LblBatchDescription" runat="server"></asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Billing Approval ID:
                </div>
                <div class="code-description-code" style="padding-top: 4px;">
                    <asp:Label ID="LblApprovalID" runat="server"></asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Description:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtBA_CL_DESC" runat="server" MaxLength="50" TabIndex="-1" Text=""
                        Width="360px"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Date:
                </div>
                <div class="code-description-code">
                    <telerik:RadDatePicker ID="RadDatePickerDate" runat="server"
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
                </div>
            </div>
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelOptional" runat="server" Collapsed="true" TitleText="Optional Information">
        <div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Date Sent:
                </div>
                <div class="code-description-code">
                    <telerik:RadDatePicker ID="RadDatePickerDateSent" runat="server"
                        SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
                <div class="code-description-label">
                    Date Approved:
                </div>
                <div class="code-description-code">
                    <telerik:RadDatePicker ID="RadDatePickerDateApproved" runat="server"
                        SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Client PO:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientPO" runat="server" MaxLength="40" TabIndex="5" Text=""
                        TextMode="SingleLine" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlClientContact" runat="server" href="" Text="Client Contact:"></asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtClientContactCode"
                        runat="server" MaxLength="6" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientContactDescription" runat="server" ReadOnly="true"
                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:HiddenField ID="HfContactCodeID" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </ew:CollapsablePanel>
    <ew:CollapsablePanel ID="CollapsablePanelDetails" runat="server" TitleText="Details">
        <div class="code-description-container">
            <div class="code-description-label">
                Job Filter:
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtFilterJobs" runat="server" MaxLength="15" Width="100"></asp:TextBox>

            </div>
            <div class="code-description-code">
                <asp:ImageButton ID="ImgBtnFilterJobs" runat="server" SkinID="ImageButtonRefresh"
                    ToolTip="Filter jobs" />
            </div>
        </div>
        <telerik:RadGrid ID="RadGridApprovalJobList" runat="server" AllowPaging="False" AllowSorting="True" EnableViewState="false"
            EnableEmbeddedSkins="True" AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
            Visible="True" Width="100%">
            <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR,APPROVAL_STATUS" NoMasterRecordsText="No records found">
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="" UniqueName="ColLOCKED">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                        <ItemTemplate>
                            <div id="DivLocked" runat="server" class="icon-background standard-red">
                                <asp:Image ID="ImageLocked" runat="server" ImageUrl="~/Images/Icons/White/256/lock.png" CssClass="icon-image" ToolTip="Locked" />
                            </div>
                            <asp:HiddenField ID="HfLocked" runat="server" Value='<%#Eval("IS_LOCKED")%>' />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="" UniqueName="ColVIEW">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImgBtnViewApproval" runat="server" AlternateText="View details"
                                    CommandArgument="" CommandName="ViewJobComponent" SkinID="ImageButtonViewWhite"
                                    ToolTip="View details" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="JOB_AND_COMPONENT" HeaderText="Job/Component"
                        UniqueName="ColJOB_AND_COMPONENT">
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="middle" />
                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DIV_CODE" HeaderText="Division" UniqueName="ColDIV_CODE">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="PRD_CODE" HeaderText="Product" UniqueName="ColPRD_CODE">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="APPROVAL_STATUS" Display="False" HeaderText="Approval Status"
                        UniqueName="ColAPPROVAL_STATUS">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ADJUSTED_STATUS" HeaderText="Adjusted Status"
                        UniqueName="ColADJUSTED_STATUS">
                        <HeaderStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                        <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="80px" />
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </ew:CollapsablePanel>
        <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>
    
    
</asp:Content>
