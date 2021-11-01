<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Approval_JobComponent.aspx.vb" Inherits="Webvantage.BillingApproval_Approval_JobComponent" 
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Approval By Job Component" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script src="Jscripts/BillingApproval.js" type="text/javascript"></script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <!-- RadToolTip Script -->
        <script type="text/javascript">            

            function RadGridComponentListMainColumnHeaderMenu(ev) {
                var gridRadGridProjectViewpointMain = $find("<%= RadGridComponentList.ClientID %>");
                gridRadGridProjectViewpointMain.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 10, 10);
            }

            function DisplayDetails() {
                var divDetails = document.getElementById('divDetails');
                divDetails.style.display = "inline";
            };
            function CloseActiveToolTip() {
                setTimeout(function () {
                    var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                    var tooltip = controller.get_activeToolTip();
                    if (tooltip) tooltip.hide();
                }, 1000);
            };
        </script>
        <!-- Sum Scripts -->
        <script type="text/javascript">
            function LoGloFormatNumber(textbox) {
                var tb = document.getElementById(textbox)
                var s = tb.value;
                s = Number.parseLocale(s);
                if (isNaN(s) == false) {
                    tb.value = String.localeFormat("{0:n}", s);
                }
                else {
                    tb.value = '';
                };
            };
            function SumItUp(textResult) {
                //alert('SumItUp');
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var myArray = new Array();
                //add array items, this calls the public server variable we build in rowdatabound
                <%= JSArray %>
                //sum it:
                for (x = 0; x < myArray.length; x++) {
                    temp = Number.parseLocale(myArray[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    };
                    //multiply the value times one to trick js into always thinking the variable is a number
                    y = y + (s * 1);
                };
                //display the result
                var z = 0;
                z = (y * 1);

                document.getElementById(textResult).value = z;
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl03_ctl00_TxtSUM_APPROVED_AMT').value = String.localeFormat("{0:n}", z);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl03_ctl00_LabelSUM_APPROVED_AMT').textContent = String.localeFormat("{0:n}", z);
            };
            function SumItUpNet() {
                //alert('SumItUpNet');
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var myArrayNet = new Array();
                //add array items, this calls the public server variable we build in rowdatabound
                <%= JSArrayNet %>
                //sum it:
                //alert(myArrayNet.length);
                for (x = 0; x < myArrayNet.length; x++) {
                    temp = Number.parseLocale(myArrayNet[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    //multiply the value times one to trick js into always thinking the variable is a number
                    y = y + (s * 1);
                }
                //display the result
                var z = 0;
                z = (y * 1);

                document.getElementById("ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl03_ctl00_LabelSUM_APPR_NET").textContent = String.localeFormat("{0:n}", z);
            }
            function SumItUpMarkup() {
                //alert('SumItUpMarkup');
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var myArrayMarkupAmt = new Array();
                //add array items, this calls the public server variable we build in rowdatabound
                <%= JSArrayMarkupAmt %>
                //sum it:
                for (x = 0; x < myArrayMarkupAmt.length; x++) {
                    temp = Number.parseLocale(myArrayMarkupAmt[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    }
                    //multiply the value times one to trick js into always thinking the variable is a number
                    y = y + (s * 1);
                }
                //display the result
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl03_ctl00_TxtSUM_APPR_MARKUP_AMT').textContent = String.localeFormat("{0:n}", z);
            }
            function SumItUpTax() {
                //alert('SumItUpTax');
                var x = 0;
                var y = 0;
                var s = 0;
                var temp = '';
                var myArrayTaxAmt = new Array();
                //add array items, this calls the public server variable we build in rowdatabound
                <%= JSArrayTaxAmt %>
                //sum it:
                for (x = 0; x < myArrayTaxAmt.length; x++) {
                    temp = Number.parseLocale(myArrayTaxAmt[x]);
                    if (isNaN(temp) == false) {
                        s = temp;
                    }
                    else {
                        s = 0;
                    };
                    //multiply the value times one to trick js into always thinking the variable is a number
                    y = y + (s * 1);
                };
                //display the result
                var z = 0;
                z = (y * 1);
                document.getElementById('ctl00_ContentPlaceHolderMain_RadGridComponentList_ctl00_ctl03_ctl00_TxtSUM_APPR_TAX_AMT').textContent = String.localeFormat("{0:n}", z);
            };
        </script>
        <!-- Hide/Show Advancedd Bill Options Script -->
        <script type="text/javascript">
            //advance bill yes
            function showAB() {
                if (document.getElementById) {
                    obj = document.getElementById('ctl00_ContentPlaceHolderMain_RowInstructions1');
                    obj.style.display = "";
                    obj2 = document.getElementById('ctl00_ContentPlaceHolderMain_RowInstructions2');
                    obj2.style.display = "";
                    obj3 = document.getElementById('ctl00_ContentPlaceHolderMain_RowHoldJC');
                    obj3.style.display = "none";
                };
            };
            //advance bill no
            function hideAB() {
                if (document.getElementById) {
                    obj = document.getElementById('ctl00_ContentPlaceHolderMain_RowInstructions1');
                    obj.style.display = "none";
                    obj2 = document.getElementById('ctl00_ContentPlaceHolderMain_RowInstructions2');
                    obj2.style.display = "none";
                    obj3 = document.getElementById('ctl00_ContentPlaceHolderMain_RowHoldJC');
                    obj3.style.display = "";
                };
            };

        </script>
        <!-- Bill Hold Script -->
        <script type="text/javascript">
            function confirmBillHold(rb) {
                //                var rb = document.getElementById(rb);
                //                if (document.forms[0].ctl00$ContentPlaceHolderMain$RblHoldJobComp[0].checked){
                //                }
                //                else
                //                {
                //                radalert("It wasn't selected");
                //                
                //                }

                //                if (confirm("Are you sure you want to reset item and function level approvals to 0.00\nand place the job on hold?")) 
                //                {
                //                    realPostBack("HoldJob","HoldJob");
                //                }
                //                else
                //                {
                //                    return false;
                //                }  
            };
        </script>
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteRow") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete selected user row(s)?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete selected user row(s)?");
                };
                if (comandName == "DeleteApproval") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete the approval?\n\nWarning:\nThis action will delete all item, function, and job level approval information entered.'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete the approval?\n\nWarning:\nThis action will delete all item, function, and job level approval information entered.");
                };
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="ContentBAJC" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarBillingApprovalJobComponent" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="Save/Approve" Value="Save"
                        ToolTip="Save approval" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                   <%-- <telerik:RadToolBarButton Text="Details" Value="EnableDetails" EnableViewState="true"
                        Group="EnableDetails" CheckOnClick="true" AllowSelfUnCheck="true" Checked="true"
                        ToolTip="Enable details grid" />
                    <telerik:RadToolBarButton IsSeparator="true" />--%>
                    <telerik:RadToolBarButton Text="Delete Approval" Value="DeleteApproval"
                        CommandName="DeleteApproval" ToolTip="Delete approval" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <%--<telerik:RadToolBarButton Text="Rate Details" Value="EnableQtyRate" EnableViewState="true"
                        CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" ToolTip="Enable rate details" />
                    <telerik:RadToolBarButton IsSeparator="true" />--%>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                        ToolTip="Refresh" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonPrevious" Value="MovePrevious"
                        ToolTip="Previous" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNext" Text="" Value="MoveNext"
                        ToolTip="Next" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonLabelJob">
                        <ItemTemplate>
                            <asp:Label ID="LabelJob" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Status:&nbsp;&nbsp;"></asp:Label>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Value="RadToolBarButtonLblStatus">
                        <ItemTemplate>
                            <asp:Label ID="LblStatus" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="View Rollup" Value="ViewRollup"
                        ToolTip="View Rollup" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
            <ew:CollapsablePanel ID="CollapsablePanelComponentInfo" runat="server" TitleText="Job Component Information">
            <asp:HiddenField ID="HfBA_BATCH_ID" runat="server" />
            <asp:HiddenField ID="HfBA_ID" runat="server" />
            <asp:HiddenField ID="HfBA_HDR_ID" runat="server" />
            <asp:HiddenField ID="HfJOB_NUMBER" runat="server" />
            <asp:HiddenField ID="HfJOB_COMPONENT_NBR" runat="server" />
            <asp:HiddenField ID="HfAccountExecutiveCode" runat="server" />
            <asp:HiddenField ID="HfCampaignCode" runat="server" />
            <asp:HiddenField ID="HfCampaignIdentifier" runat="server" />
            <asp:HiddenField ID="HfIsAdvancedBilling" runat="server" />
            <asp:HiddenField ID="HfBillType" runat="server" />
            <asp:HiddenField ID="HfShowDetailLevel" runat="server" />
            <div>
                <div style="display: inline-block;vertical-align:top;">
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblClient" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblDivision" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblProduct" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container" id="TrCampaign" runat="server">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblCampaign" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="display: inline-block;vertical-align:top;">
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblJob" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblComponent" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Account Executive:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LblAccountExecutive" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container" id="TrContact" runat="server">
                        <div class="code-description-label">
                            Contact:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LabelContact" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Billing Approval ID:
                            </div>
                            <div class="code-description-description">
                                <asp:Label ID="LblApprovalID" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Description:
                            </div>
                            <div class="code-description-description">
                                <asp:Label ID="LblApprovalDescription" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div id="TrInvoice" runat="server">
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Invoice Number:
                            </div>
                            <div class="code-description-description">
                                <asp:Label ID="LblInvoiceNumber" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="code-description-container">
                            <div class="code-description-label">
                                Date:
                            </div>
                            <div class="code-description-description">
                                <asp:Label ID="LblInvoiceDate" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="code-description-container" id="TrClientPO" runat="server">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LabelClientPO" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container" id="TRJobProcessControl" runat="server">
                        <div class="code-description-label">
                            Process Control:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="LabelProcessControl" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
      </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelApprovalInfo" runat="server" TitleText="Approval Information">
            <div class="code-description-container">
                <div class="code-description-label">
                    Advance Bill:
                </div>
                <div class="code-description-description">
                    <asp:RadioButton ID="RbAdvanceBillYes" runat="server" Checked="true" GroupName="RblAdvanceBill"
                        TabIndex="1" Text="Yes" />
                    <asp:RadioButton ID="RbAdvancedBillNo" runat="server" GroupName="RblAdvanceBill"
                        TabIndex="2" Text="No" />
                </div>
            </div>
            <div class="code-description-container" id="RowHoldJC" runat="server" style="display: none;">
                <div class="code-description-label">
                    Hold Job/Component?
                </div>
                <div class="code-description-description">
                    <asp:RadioButton ID="RbHoldJobCompYes" runat="server" GroupName="RblHoldJobComp"
                        TabIndex="3" Text="Yes" />
                    <asp:RadioButton ID="RbHoldJobCompNo" runat="server" Checked="true" GroupName="RblHoldJobComp"
                        TabIndex="4" Text="No" />&nbsp;&nbsp;
                        <asp:Label ID="LblJobComponentIsOnHold" runat="server" Text="[Job is currently on hold]"
                            Visible="false"></asp:Label>
                </div>
            </div>
            <div class="code-description-container" id="RowInstructions1" runat="server">
                <div class="code-description-label">
                    Instructions:
                </div>
                <div class="code-description-description">
                    <asp:RadioButton ID="RbToQuotePercent" runat="server" GroupName="RblABOptions" TabIndex="5"
                        Text="To Quote %" />
                    <asp:TextBox ID="TxtToQuotePercent" runat="server" MaxLength="5" TabIndex="6" Width="46px" SkinID="TextBoxStandard"></asp:TextBox>
                    <asp:LinkButton ID="LinkButtonToQuotePercent" runat="server" Text="Set" Tooltip="Set approval amount based on quote percent"></asp:LinkButton>
                    <asp:CheckBox ID="ChkToQuotePercentExludeNonBillable" runat="server" Text="Exclude Non Billable"
                        ToolTip="This will zero out non billable amounts" />
                </div>
            </div>
            <div class="code-description-container" id="RowInstructions2" runat="server">
                <div class="code-description-label">
                </div>
                <div class="code-description-description">
                    <asp:RadioButton ID="RbManualOnApprovalAmt" runat="server" AutoPostBack="true" GroupName="RblABOptions"
                        TabIndex="7" Text="Manual based on Approval Amount" />
                </div>
            </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelComments" runat="server" TitleText="Comments">
            <table border="0" cellpadding="2" cellspacing="2" width="810">
                <tr>
                    <td width="40">&nbsp;
                    </td>
                    <td width="380">&nbsp;
                         <span>Approval Comments:</span>
                   </td>
                    <td width="10">&nbsp;
                    </td>
                    <td width="380">&nbsp;
                         <span>Client Comments:</span>
                   </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCommentsApproval" runat="server" Height="75px" TabIndex="8" Text="" SkinID="TextBoxStandard"
                            TextMode="MultiLine" Width="380px"></asp:TextBox>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCommentsClient" runat="server" Height="75px" TabIndex="9" Text="" SkinID="TextBoxStandard"
                            TextMode="MultiLine" Width="380px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelDetails" runat="server" TitleText="Details">
            <div class="code-description-container">
                <div class="code-description-label">
                    Approved Total
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtApprovalAmount" runat="server" Style="text-align: right;" TabIndex="10" SkinID="TextBoxStandard"
                        Width="145px"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Unbilled Advance
                </div>
                <div class="code-description-description">
                    <asp:Label ID="lblAB_UNBILLED" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Advance Billed
                </div>
                <div class="code-description-description">
                    <asp:Label ID="lblAB_BILLED" runat="server" Text=""></asp:Label>
                </div>
                <div class="code-description-label">
                    Flat Income Recognized
                </div>
                <div class="code-description-code">
                    <asp:Label ID="lbl_INCOME_REC" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Reconciled/Billed
                </div>
                <div class="code-description-description">
                    <asp:Label ID="lblRECONCILED_TOTAL" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Actual Less Billed
                </div>
                <div class="code-description-description">
                    <asp:Label ID="lblACTUAL_LESS_BILLED" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelFunctions" runat="server" TitleText="Functions">
            <div>
                <asp:Button ID="ButtonNewUserRow" runat="server" Text="New Row" ToolTip="Manually add row" />
                <asp:Button ID="ButtonDeleteUserRow" runat="server" Text="Delete Row" ToolTip="Delete unsaved manually added rows" />
                <%--&nbsp;
               <asp:CheckBox ID="ChkHideColumnsDetails" runat="server" AutoPostBack="true" Checked="true" Text="Hide Details" ToolTip="Hide the non-billable, bill hold, and Open PO columns" />
                &nbsp;
                <asp:CheckBox ID="ChkHideColumnsComments" runat="server" AutoPostBack="true" Text="Hide Comments" ToolTip="Hide the comment columns" />--%>
                &nbsp;Group By:&nbsp;
                <telerik:RadComboBox ID="DropGroupBy" runat="server" AutoPostBack="True" TabIndex="-1" SkinID="RadComboBoxStandard">
                    <Items>
                        <telerik:RadComboBoxItem Text="Function Code" Value="FunctionCode"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Text="Function Type" Value="FunctionType"></telerik:RadComboBoxItem>
                        <telerik:RadComboBoxItem Text="Function Heading" Value="FunctionHeading"></telerik:RadComboBoxItem>
                    </Items>
                </telerik:RadComboBox>
                <asp:LinkButton ID="LBtnExpandCollapse" runat="server" Text="Collapse All"></asp:LinkButton>
            </div>
            <div style="margin: 10px 0px 20px 0px;">
                <asp:ImageButton ID="ImgBtnClearAmounts" runat="server" AlternateText="Clear approved amounts" SkinID="ImageButtonClear" ToolTip="Clear approved amounts" />
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                Approve Through:
                <telerik:RadDatePicker ID="RadDatePickerApproveThroughDate" runat="server"
                    SkinID="RadDatePickerStandard">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
                <asp:CheckBoxList ID="CheckBoxListApproveThroughTypes" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Employee" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Income Only" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Vendor" Value="3"></asp:ListItem>
                </asp:CheckBoxList>
                &nbsp;
                <asp:LinkButton ID="LinkButtonFilterByTempCutoff" runat="server" Text="Apply" ToolTip="Click to apply the Approve Through date to the selected function type"></asp:LinkButton>
            </div>
            <telerik:RadGrid ID="RadGridComponentList" runat="server" AllowPaging="False" AllowSorting="false"
                AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                EnableEmbeddedSkins="True" EnableOutsideScripts="true" ShowFooter="True" EnableHeaderContextMenu="true"
                Visible="True" Height="500">
                <MasterTableView DataKeyNames="INDEX" NoMasterRecordsText="No records found" Width="100%" TableLayout="Fixed">
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="&#160;" UniqueName="ColDelete" HeaderAbbr="FIXED">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="25px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <HeaderTemplate>
                                <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                    ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridComponentListMainColumnHeaderMenu(event);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkDelete" runat="server" Enabled='<%# Eval("IS_USER_ADDED") %>'
                                    Visible='<%# Eval("IS_USER_ROW") %>' />
                                <asp:Image ID="ImgDeleteSpacer" runat="server" ImageUrl="~/Images/spacer.gif" Visible='<%# Not Eval("IS_USER_ROW") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Function Code" UniqueName="ColFNC_CODE" HeaderAbbr="FIXED">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="70px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top"  />
                            <ItemTemplate>
                                <asp:LinkButton ID="LBtnFNC_CODE" runat="server" Text='<%#Eval("FNC_CODE")%>' CommandName="ViewItemDetail"></asp:LinkButton>
                                <asp:TextBox ID="TxtFNC_CODE" runat="server" MaxLength="6" Text='<%# Eval("FNC_CODE") %>' SkinID="TextBoxStandard"
                                    Width="65"></asp:TextBox>
                                <div class="icon-background background-color-sidebar" style="display: none;">
                                    <asp:ImageButton ID="ImgBtnFNC_CODE" runat="server" AlternateText="Look up the function code"
                                        SkinID="ImageButtonFind" ToolTip="Look up the function code" />
                                </div>
                                <asp:HiddenField ID="HfFNC_TYPE" runat="server" Value='<%# Eval("FNC_TYPE") %>' />
                                <asp:HiddenField ID="HfFNC_CODE" runat="server" Value='<%# Eval("FNC_CODE") %>' />
                                <asp:HiddenField ID="HfBA_DTL_ID" runat="server" Value='<%# Eval("BA_DTL_ID") %>' />
                                <asp:HiddenField ID="HfIS_USER_ADDED" runat="server" Value='<%# Eval("IS_USER_ADDED") %>' />
                                <asp:HiddenField ID="HfITEM_EXISTS" runat="server" Value='<%# Eval("ITEM_EXISTS") %>' />
                                <asp:HiddenField ID="HfQUOTE_AMT" runat="server" Value='<%# Eval("QUOTE_AMT") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description"  HeaderAbbr="FIXED"
                            UniqueName="colFNC_DESCRIPTION">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="184px"  />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtFNC_DESCRIPTION" runat="server" Width="180" MaxLength="30" Text='<%# Eval("FNC_DESCRIPTION") %>' SkinID="TextBoxStandard"></asp:TextBox>
                                <asp:HiddenField ID="HfFNC_DESCRIPTION" runat="server" Value='<%# Eval("FNC_DESCRIPTION") %>' />
                                <asp:HiddenField ID="HfDFLT_DESCRIPTION" runat="server" Value='<%# Eval("DEFAULT_DESCRIPTION") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="QUOTE_QTY_HRS" HeaderText="Quote Qty/Hrs" UniqueName="ColQUOTE_QTY_HRS"  HeaderAbbr="FIXED"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="85px"   />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QUOTE_NET" HeaderText="Quote Net Amount" UniqueName="colQUOTE_NET"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="85px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QUOTE_AMT" HeaderText="Quote Amount" UniqueName="ColQUOTE_AMT"  HeaderAbbr="FIXED"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="85px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_QTY_HRS" HeaderText="Actual Qty/Hrs" DataFormatString="{0:#,##0.00}"  HeaderAbbr="FIXED"
                            UniqueName="ColACTUAL_QTY_HRS">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="75px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"   />
                        </telerik:GridBoundColumn> 
                        <telerik:GridBoundColumn DataField="ACTUALS" HeaderText="Actual Billable Amount"  HeaderAbbr="FIXED"
                            DataFormatString="{0:#,##0.00}" UniqueName="ColACTUALS_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NON_BILL_FEE" HeaderText="Non-Billable/Fee" UniqueName="ColNON_BILL_FEE"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BILL_HOLD" HeaderText="Bill Hold" UniqueName="ColBILL_HOLD"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="75px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OPEN_PO" HeaderText="Open PO" UniqueName="ColOPEN_PO"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BILLED_REC" HeaderText="Billed" UniqueName="ColBILLED_REC" HeaderAbbr="FIXED"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"   />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UNBILLED" HeaderText="Unbilled / Recognized" UniqueName="ColUNBILLED" HeaderAbbr="FIXED"
                            DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="100px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Quantity" UniqueName="ColQUANTITY">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="95px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtQUANTITY" runat="server" MaxLength="7" Style="text-align: right;"
                                     SkinID="TextBoxCodeSmall"  Text='<%#Eval("QUANTITY")%>' ToolTip="Quantity"></asp:TextBox>
                                <asp:HiddenField ID="HfQUANTITY" runat="server" Value='<%# Eval("QUANTITY") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Rate" UniqueName="ColRATE">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="95px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtRATE" runat="server" MaxLength="7" ReadOnly="False" Style="text-align: right;"
                                     SkinID="TextBoxCodeSmall"  Text='<%#Eval("RATE")%>' ToolTip="Rate"></asp:TextBox>
                                <asp:HiddenField ID="HfRATE" runat="server" Value='<%# Eval("RATE") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Net Approved Amount" UniqueName="ColNET_QUOTE_UNBILLED_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="130px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_NET" runat="server" MaxLength="15" onfocus="this.select();"
                                     SkinID="TextBoxCodeLarge"  Style="text-align: right;" Text='<%# Eval("APPR_NET") %>' ToolTip="Net Approved Amount"></asp:TextBox>
                                <asp:HiddenField ID="HfQUOTE_NET" runat="server" Value='<%# Eval("QUOTE_NET") %>' />
                                <asp:HiddenField ID="HfUNBILLED_NET" runat="server" Value='<%# Eval("UNBILLED_NET") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="DivNetApprovedAmount" runat="server">
                                    <asp:Label ID="LabelSUM_APPR_NET" runat="server" Text="0.00"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Markup Percent" UniqueName="ColAPPR_MARKUP_PCT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="95px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"  />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_MARKUP_PCT" runat="server" MaxLength="6" Style="text-align: right;"
                                    SkinID="TextBoxCodeSmall"  Text='<%#Eval("APPR_MARKUP_PCT")%>' ToolTip="Markup Percent"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Markup Amount" UniqueName="ColAPPR_MARKUP_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="130px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Font-Bold="true" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_MARKUP_AMT" runat="server" MaxLength="7" ReadOnly="False"
                                    SkinID="TextBoxCodeLarge" Style="text-align: right;" Text='<%#Eval("APPR_MARKUP_AMT")%>' ToolTip="Markup Amount"></asp:TextBox>
                                <asp:HiddenField ID="HfAPPR_MARKUP_AMT" runat="server" Value='<%# Eval("APPR_MARKUP_AMT") %>' />
                                <asp:HiddenField ID="HfQUOTE_MARKUP" runat="server" Value='<%# Eval("QUOTE_MARKUP") %>' />
                                <asp:HiddenField ID="HfUNBILLED_MARKUP" runat="server" Value='<%# Eval("UNBILLED_MARKUP") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="DivMarkupAmount" runat="server">
                                    <asp:Label ID="TxtSUM_APPR_MARKUP_AMT" runat="server" Text="0.00"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Extended Amount" UniqueName="ColEXTENDED_AMT" HeaderAbbr="FIXED">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="130px"  />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top"   Font-Bold="true" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtEXTENDED_AMT" runat="server" MaxLength="7" ReadOnly="true"
                                    SkinID="TextBoxCodeLarge" Style="text-align: right;" Text='' ToolTip="Extended Amount"></asp:TextBox>                                
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="DivExtendedAmount" runat="server">
                                    <asp:Label ID="TxtSUM_EXTENDED_AMT" runat="server" Text="0.00"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tax Code" UniqueName="ColAPPR_TAX_CODE">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="95px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top"  />
                            <ItemTemplate>
                                <asp:Label ID="LabelAPPR_TAX_CODE" runat="server" Text='<%#Eval("APPR_TAX_CODE")%>'></asp:Label>
                                <asp:TextBox ID="TextBoxAPPR_TAX_CODE" runat="server" Text='<%#Eval("APPR_TAX_CODE")%>' SkinID="TextBoxCodeSmall" style="display:none !important;"></asp:TextBox>
                                <div class="icon-background background-color-sidebar" style="display: none;">
                                    <asp:ImageButton ID="ImageButtonAPPR_TAX_CODE" runat="server" AlternateText="Look up the tax code"
                                        SkinID="ImageButtonFind" ToolTip="Look up the tax code" />
                                </div>
                                <asp:HiddenField ID="HfAPPR_MARKUP_PCT" runat="server" Value='<%# Eval("APPR_MARKUP_PCT") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_COMM" runat="server" Value='<%# Eval("APPR_TAX_COMM") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_COMM_ONLY" runat="server" Value='<%# Eval("APPR_TAX_COMM_ONLY") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_RESALE" runat="server" Value='<%# Eval("APPR_TAX_RESALE") %>' />
                                <asp:HiddenField ID="HfAPPR_RESALE_TAX" runat="server" Value='<%# Eval("APPR_RESALE_TAX") %>' />
                                <asp:HiddenField ID="HfAPPR_VENDOR_TAX" runat="server" Value='<%# Eval("APPR_VENDOR_TAX") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_STATE_PCT" runat="server" Value='<%# Eval("APPR_TAX_STATE_PCT") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_COUNTY_PCT" runat="server" Value='<%# Eval("APPR_TAX_COUNTY_PCT") %>' />
                                <asp:HiddenField ID="HfAPPR_TAX_CITY_PCT" runat="server" Value='<%# Eval("APPR_TAX_CITY_PCT") %>' />
                                <asp:HiddenField ID="HfQUOTE_RESALE_TAX" runat="server" Value='<%# Eval("QUOTE_RESALE_TAX") %>' />
                                <asp:HiddenField ID="HfQUOTE_VENDOR_TAX" runat="server" Value='<%# Eval("QUOTE_VENDOR_TAX") %>' />
                                <asp:HiddenField ID="HfUNBILLED_RESALE_TAX" runat="server" Value='<%# Eval("UNBILLED_RESALE_TAX") %>' />
                                <asp:HiddenField ID="HfUNBILLED_VENDOR_TAX" runat="server" Value='<%# Eval("UNBILLED_VENDOR_TAX") %>' />
                                <asp:HiddenField ID="HfIS_USER_ROW" runat="server" Value='<%# Eval("IS_USER_ROW") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Tax Amount" UniqueName="ColAPPR_TAX_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="130px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"   />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Font-Bold="true" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_TAX_AMT" runat="server" MaxLength="7" ReadOnly="True" Style="text-align: right;" SkinID="TextBoxCodeLarge" Text='0.00' ToolTip="Tax Amount"></asp:TextBox>
                                <asp:HiddenField ID="HfAPPR_TAX_AMT" runat="server" Value='0.00' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <div id="DivTaxAmount" runat="server">
                                    <asp:Label ID="TxtSUM_APPR_TAX_AMT" runat="server" Text="0.00" ToolTip="Total Tax Amount"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Approved Amount" UniqueName="ColAPPROVED_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="130px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"  />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Font-Bold="true" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPROVED_AMT" runat="server" MaxLength="15" onfocus="this.select();" ReadOnly="true"
                                     SkinID="TextBoxCodeLarge"  Style="text-align: right;" Text='<%#Eval("APPROVED_AMT")%>' ToolTip="Approved Amount excluding Resale Tax"></asp:TextBox>
                                <asp:HiddenField ID="HfAPPROVED_AMT" runat="server" Value='<%# Eval("APPROVED_AMT") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="TxtSUM_APPROVED_AMT" runat="server" Width="75" Style="text-align: right;" ToolTip="Sum of Approved Amount excluding Resale Tax" SkinID="TextBoxStandard"></asp:TextBox>
                                <div id="DivApprovedAmount" runat="server">
                                    <asp:Label ID="LabelSUM_APPROVED_AMT" runat="server" Text="0.00" ToolTip="Total Approved Amount excluding Resale Tax"></asp:Label>
                                </div>
                            </FooterTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Approval Comments" UniqueName="colAPPR_COMMENTS">
                            <HeaderStyle CssClass="radgrid-textarea-column" VerticalAlign="Bottom" Width="175px"  />
                            <ItemStyle CssClass="radgrid-textarea-column"  />
                            <FooterStyle CssClass="radgrid-textarea-column"  />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_COMMENTS" runat="server" Text='<%#Eval("APPR_COMMENTS")%>' SkinID="TextBoxStandard"
                                    TextMode="multiLine" ToolTip="Approval Comments" CssClass="radgrid-textarea" Width="165px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Client Comments" UniqueName="colCLIENT_COMMENTS">
                            <HeaderStyle CssClass="radgrid-textarea-column" VerticalAlign="Bottom" Width="175px"  />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtCLIENT_COMMENTS" runat="server" Text='<%#Eval("CLIENT_COMMENTS")%>'  SkinID="TextBoxStandard"
                                    TextMode="multiLine" ToolTip="Client Comments" CssClass="radgrid-textarea" Width="165px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="colCOMMENT_POPUP" HeaderText="" HeaderAbbr="FIXED">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="70px"  />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnCOMMENT_POPUP" runat="server" AlternateText="Show comments" ToolTip="Show comments"
                                        CommandArgument='<%#Eval("BA_DTL_ID")%>' CommandName="ShowComments" SkinID="ImageButtonCommentWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="colITEM_EXISTS" HeaderAbbr="FIXED" Visible="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background standard-green" style='<%# If(Eval("ITEM_EXISTS") = True, "display:block;", "display:none;")%>'>
                                    <asp:Image ID="ImgITEM_EXISTS" runat="server" AlternateText="This function has item level records" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="This function has item level records" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="colROW_TYPE" HeaderAbbr="FIXED" Display="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <asp:HiddenField ID="HfROW_TYPE" runat="server" Value='<%# Eval("ROW_TYPE") %>' />
                                <div id="DivRowType" runat="server" class="icon-background standard-red" style='<%# If(Eval("ROW_TYPE") = "1", "display:block;", "display:none;")%>'>
                                    <asp:Image ID="ImgROW_TYPE" runat="server" AlternateText="This function is non billable"
                                        ImageUrl="~/Images/Icons/White/256/signal_flag.png" CssClass="icon-image" ToolTip="This function is non billable"
                                        Visible="false" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="IS_USER_ROW" HeaderText="IS_USER_ROW" UniqueName="ColTESTING_COLUMN"
                            Visible="False">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridTemplateColumn UniqueName="GridTemplateColumnValues" HeaderText="For Testing" Visible="false">
                            <ItemTemplate>
                                <div style="width:1000px;font-size:small;">
                                    APPR_TAX_CODE:  <%# Eval("APPR_TAX_CODE") %>,&nbsp;&nbsp;
                                    APPR_MARKUP_PCT:  <%# Eval("APPR_MARKUP_PCT") %>,&nbsp;&nbsp;
                                    APPR_TAX_COMM:  <%# Eval("APPR_TAX_COMM") %>,&nbsp;&nbsp;
                                    APPR_TAX_COMM_ONLY:  <%# Eval("APPR_TAX_COMM_ONLY") %>,&nbsp;&nbsp;
                                    APPR_TAX_RESALE:  <%# Eval("APPR_TAX_RESALE") %>,&nbsp;&nbsp;
                                    APPR_RESALE_TAX:  <%# Eval("APPR_RESALE_TAX") %>,&nbsp;&nbsp;
                                    APPR_VENDOR_TAX:  <%# Eval("APPR_VENDOR_TAX") %>,&nbsp;&nbsp;
                                    APPR_TAX_STATE_PCT:  <%# Eval("APPR_TAX_STATE_PCT") %>,&nbsp;&nbsp;
                                    APPR_TAX_COUNTY_PCT:  <%# Eval("APPR_TAX_COUNTY_PCT") %>,&nbsp;&nbsp;
                                    APPR_TAX_CITY_PCT:  <%# Eval("APPR_TAX_CITY_PCT") %>,&nbsp;&nbsp;
                                    QUOTE_RESALE_TAX:  <%# Eval("QUOTE_RESALE_TAX") %>,&nbsp;&nbsp;
                                    QUOTE_VENDOR_TAX:  <%# Eval("QUOTE_VENDOR_TAX") %>,&nbsp;&nbsp;
                                    UNBILLED_RESALE_TAX:  <%# Eval("UNBILLED_RESALE_TAX") %>,&nbsp;&nbsp;
                                    UNBILLED_VENDOR_TAX:  <%# Eval("UNBILLED_VENDOR_TAX") %>,&nbsp;&nbsp;
                                    APPROVED_AMT:  <%# Eval("APPROVED_AMT") %>,&nbsp;&nbsp;
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>--%>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                </MasterTableView>
                <ClientSettings>
                    <Scrolling AllowScroll="true" SaveScrollPosition="false" UseStaticHeaders="true" />
                    <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                </ClientSettings>
            </telerik:RadGrid>
        </ew:CollapsablePanel>
        <asp:HiddenField ID="HfIsReadOnly" runat="server" />
        <asp:HiddenField ID="HfJobOnOtherBatch" runat="server" />
        <asp:HiddenField ID="HfCanDelete" runat="server" Value="1" />
        <asp:HiddenField ID="HfApprStatus" runat="server" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Visible="false"></asp:GridView>
        <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
        </div>
        
</asp:Content>
