<%@ Page AutoEventWireup="false" CodeBehind="purchaseorder_bk.aspx.vb" Inherits="Webvantage.purchaseorder_bk"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Purchase Order" %>

<%@ Register Src="purchaseorder_memo_nav.ascx" TagName="purchaseorder_memo_nav" TagPrefix="uc2" %>
<%@ Register Src="purchaseordernav.ascx" TagName="purchaseordernav" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script language="javascript" type="text/javascript">

            function populatePOdate() {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000)
                    year += 1900
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10)
                    month = month
                var daym = mydate.getDate()
                if (daym < 10)
                    daym = "0" + daym

                document.forms[0].ctl00_ContentPlaceHolderMain_PO_DATE.value = month + "/" + daym + "/" + year
            }

            function populatePODuedate() {
                var mydate = new Date()
                var year = mydate.getYear()
                if (year < 1000)
                    year += 1900
                var day = mydate.getDay()
                var month = mydate.getMonth() + 1
                if (month < 10)
                    month = month
                var daym = mydate.getDate()
                if (daym < 10)
                    daym = "0" + daym

                document.forms[0].ctl00_ContentPlaceHolderMain_PO_DUE_DATE.value = month + "/" + daym + "/" + year
            }

            function PopupVendorContacts() {
                var url = "LookUp_Vendor.aspx?form=purchaseorder&type=vendor_contacts&str=" + document.forms[0].ctl00_ContentPlaceHolderMain_VN_CODE.value + "&control=" + "<%= VC_CODE.ClientID %>" + "&control2=" + "<%= VC_NAME.ClientID %>" + "&control3=" + "<%= VC_EMAIL.ClientID %>"
                OpenRadWindowLookup(url);
                return false;
            } 

        </script>
        <script language="javascript" type="text/javascript">
            function JobSpecs(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'JobSpecs');
            }
            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }        
        </script>
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
    <telerik:RadToolTipManager ID="RadToolTipManagerPO" runat="server" Animation="None" RenderMode="Lightweight"
        Height="100px" ManualClose="false" Modal="false" OnAjaxUpdate="OnAjaxUpdate"
        Position="BottomRight" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
        Width="200px">
    </telerik:RadToolTipManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td>
                <uc1:purchaseordernav ID="Purchaseordernav1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="middle">
                <asp:Label   ID="lbl_voidflag" runat="server" Font-Size="Medium" ForeColor="Red" Text="VOID"
                    Visible="False"></asp:Label>
                <asp:Image ID="img_lock" runat="server" AlternateText="Locked Purchase Order." ImageUrl="images/lock.png"
                    Visible="False"  />
                <asp:Label   ID="lbl_completeflag" runat="server" Font-Size="Medium" ForeColor="Red"
                    Text="COMPLETE" Visible="False"></asp:Label>
                <asp:Label   ID="lbl_cbe" runat="server" ForeColor="Red" Text="Cannot be Edited" Visible="False"></asp:Label></div>
                <asp:Label   ID="lbl_Approval" runat="server" Font-Size="Medium" ForeColor="Red" Text=""
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="right" style="width: 280px;">
                <asp:Image ID="img_postat" runat="server" ImageUrl="images/add2.png" Visible="False" />
                <span>
                    <asp:LinkButton ID="LbPONumber" runat="server">PO Number:</asp:LinkButton></span>&nbsp;&nbsp;
            </td>
            <td style="width: 109px">
                <asp:TextBox ID="PO_PAD" runat="server" BackColor="#F5F5F5"  ReadOnly="True"
                    Width="93px">-1</asp:TextBox>
            </td>
            <td style="width: 461px">
                <asp:TextBox ID="PO_DESCRIPTION" runat="server" CssClass="RequiredInput" MaxLength="40"
                    TabIndex="1" Width="300px"></asp:TextBox><span style="color: #ff0000"></span>
                <%--<asp:RequiredFieldValidator ID="rqd_descrip" runat="server" ControlToValidate="PO_DESCRIPTION"
                    Display="None" ErrorMessage="Order Description is Required">(X)</asp:RequiredFieldValidator>--%>
            </td>
            <td align="center" style="width: 82px;" valign="middle">
                Rev:
            </td>
            <td style="width: 135px;" valign="middle">
                <asp:Label   ID="lbl_Rev" runat="server" Text="0"></asp:Label>
            </td>
            <td align="right" style="width: 577px;">
                &nbsp; <span><a href="javascript:;" onclick="populatePOdate()" style="font-size: 11px;
                    color: Black">Order Date:</a></span> &nbsp;
            </td>
            <td style="width: 605px;">
                <telerik:RadDatePicker ID="RadDatePickerPO_DATE" runat="server" MinDate="1950-01-01"
                    DatePopupButton-ToolTip="Show calendar" MaxDate="2050-01-01" Width="130px">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Lightweight">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="LightSalmon">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="rqd_issue_dt" runat="server" ControlToValidate="RadDatePickerPO_DATE"
                    Display="None" ErrorMessage="Order Date is Required">(X)</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:HyperLink ID="hl_issuer" runat="server" href="">Issued By:</asp:HyperLink>&nbsp;&nbsp;
                <asp:LinkButton ID="lbtn_issue_by" runat="server" CausesValidation="False" Visible="False">(me)</asp:LinkButton>
            </td>
            <td style="width: 109px;">
                <asp:TextBox ID="EMP_CODE" runat="server" BackColor="Transparent" CausesValidation="True"
                    MaxLength="6" TabIndex="2" Width="93px"></asp:TextBox>
            </td>
            <td style="width: 461px;">
                <asp:TextBox ID="ISSUED_BY_EMP" runat="server" CssClass="RequiredInput" ReadOnly="True"
                    Width="300px"></asp:TextBox><span style="color: #ff0000"></span>
            </td>
            <td colspan="2">
                <span style="color: #ff0000"></span>
                <%--<asp:RequiredFieldValidator ID="rqd_emp_code" runat="server" ControlToValidate="EMP_CODE"
                    Display="None" ErrorMessage="Issued By is Required">(X)</asp:RequiredFieldValidator>--%>
            </td>
            <td align="right" style="width: 577px">
                <span><a href="javascript:;" onclick="populatePODuedate()" style="font-size: 11px;
                    color: Black">Due Date:</a></span> &nbsp;
            </td>
            <td colspan="" style="width: 605px;">
                <telerik:RadDatePicker ID="RadDatePickerPO_DUE_DATE" runat="server" MinDate="1950-01-01"
                    DatePopupButton-ToolTip="Show calendar" MaxDate="2050-01-01" Width="130px">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Lightweight">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="LightSalmon">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:HyperLink ID="hl_vendor" runat="server" href="">Issued To:</asp:HyperLink>&nbsp;&nbsp;
            </td>
            <td style="width: 109px">
                <asp:TextBox ID="VN_CODE" runat="server" BackColor="Transparent" CausesValidation="True"
                    MaxLength="6" TabIndex="3" Width="93px"></asp:TextBox>
            </td>
            <td style="width: 461px">
                <asp:TextBox ID="VN_NAME" runat="server" CssClass="RequiredInput" ReadOnly="True"
                    Width="300px"></asp:TextBox><span style="color: #ff0000"></span>
            </td>
            <td colspan="2" style="width: 135px;">
                <%--<asp:RequiredFieldValidator ID="rqd_vn_code" runat="server" ControlToValidate="VN_CODE"
                    Display="None" ErrorMessage="Issued To is Required">(X)</asp:RequiredFieldValidator>--%>
            </td>
            <td style="width: 577px">
            </td>
            <td style="width: 605px;">
                <asp:CheckBox ID="PO_WORK_COMPLETE" runat="server" Text="Work Complete" TextAlign="Left" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="images/add2.png" Visible="False" />
                <span>Address 1:</span>&nbsp;&nbsp;
            </td>
            <td colspan="2" style="width: 378px">
                <asp:TextBox ID="ADDRESS1" runat="server" BackColor="#F5F5F5" ReadOnly="True" Width="405px"></asp:TextBox>
            </td>
            <td align="right" colspan="3">
            </td>
            <td style="width: 605px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:Image ID="Image2" runat="server" ImageUrl="images/add2.png" Visible="False" />
                <span>Address 2:</span>&nbsp;&nbsp;
            </td>
            <td colspan="2" style="width: 378px">
                <asp:TextBox ID="ADDRESS2" runat="server" BackColor="#F5F5F5" ReadOnly="True" Width="405px"></asp:TextBox>
            </td>
            <td align="right" colspan="3">
                <asp:HyperLink ID="hlContacts" runat="server" href="" >Contact Code:</asp:HyperLink>
                &nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:TextBox ID="VC_CODE" runat="server" BackColor="Transparent" CausesValidation="True"
                    MaxLength="6" TabIndex="6" Width="65px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:Image ID="Image3" runat="server" ImageUrl="images/add2.png" Visible="False" />
                <span>Address 3:</span>&nbsp;&nbsp;
            </td>
            <td colspan="2" style="width: 378px;">
                <asp:TextBox ID="ADDRESS3" runat="server" BackColor="#F5F5F5" ReadOnly="True" Width="405px"></asp:TextBox>
            </td>
            <td align="right" colspan="3">
               Name:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:TextBox ID="VC_NAME" runat="server" BackColor="#F5F5F5" ReadOnly="True" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
                <asp:Image ID="Image4" runat="server" ImageUrl="images/add2.png" Visible="False" />
                <span>City/St/Zip:</span>&nbsp;&nbsp;
            </td>
            <td colspan="2" style="width: 378px;">
                <asp:TextBox ID="CITYSTATEZIP" runat="server" BackColor="#F5F5F5" ReadOnly="True"
                    Width="405px"></asp:TextBox>
            </td>
            <td align="right" colspan="3">
               Email Address:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:TextBox ID="VC_EMAIL" runat="server" BackColor="#F5F5F5" ReadOnly="True" Width="240px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
            </td>
            <td colspan="2" style="width: 378px">
            </td>
            <td align="right" colspan="3">
               Employee Limit:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:TextBox ID="PO_LIMIT" runat="server" BackColor="#F5F5F5" MaxLength="15" ReadOnly="True"
                    Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
            </td>
            <td colspan="2" style="width: 378px">
            </td>
            <td align="right" colspan="3">
               PO Total:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:TextBox ID="PO_TOTAL" runat="server" BackColor="Transparent" ReadOnly="True"
                    Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
            </td>
            <td colspan="2" style="width: 378px">
            </td>
            <td align="right" colspan="3">
              Modified By:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:Label   ID="Label_ModifiedBy" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 280px;">
            </td>
            <td colspan="2" style="width: 378px">
            </td>
            <td align="right" colspan="3">
              Modified Date:&nbsp;&nbsp;
            </td>
            <td style="width: 605px;">
                <asp:Label  ID="Label_ModifiedDate" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" rowspan="4" valign="top">
                &nbsp;
                <asp:LinkButton ID="lbtn_refresh" runat="server" Visible="False" Width="58px">Refresh</asp:LinkButton>
                <br />
            </td>
            <td colspan="4" rowspan="4">
                <table cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td style="width: 336px;">
                            &nbsp;
                            <asp:LinkButton ID="lbtn_set_contact" runat="server" CausesValidation="False" Visible="False">Use default</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <telerik:RadGrid ID="radGridPO" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                    MasterTableView-EditMode="InPlace" PageSize="12">
                    <PagerStyle Mode="NextPrevAndNumeric" NextPageText="&amp;gt;" PrevPageText="&amp;lt;" />
                    <MasterTableView HorizontalAlign="Left">
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibtn_po" runat="server" AlternateText="Purchase Order" CausesValidation="false"
                                        CommandName="Select" ImageUrl='~/Images/view-trans.png' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Line Nbr">
                                <ItemTemplate>
                                    <asp:Label   ID="lblLineNumber" runat="server" Text='<%#Eval("LINE_NUMBER").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label   ID="lblLineDescription" runat="server" Text='<%#Eval("LINE_DESC").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="C/D/P">
                                <ItemTemplate>
                                    <asp:Label   ID="lblClient" runat="server" Text='<%#Eval("CL_CODE").ToString()& " / " & Eval("DIV_CODE").ToString()& " / " & Eval("PRD_CODE").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Job/Comp Nbr">
                                <ItemTemplate>
                                    <asp:Label   ID="lblJobNumber" runat="server" Text='<%#Eval("JOB_NUMBER").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Comp Number" Visible="false">
                                <ItemTemplate>
                                    <asp:Label   ID="lblCompNumber" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Function Code">
                                <ItemTemplate>
                                    <asp:Label   ID="lblFunctionCode" runat="server" Text='<%#Eval("FNC_CODE").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Function Description">
                                <ItemTemplate>
                                    <asp:Label   ID="lblFunctionDescription" runat="server" Text='<%#Eval("FNC_DESCRIPTION").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="GL Account" UniqueName="GLAccount">
                                <ItemTemplate>
                                    <asp:Label   ID="lblGLAccount" runat="server" Text='<%#Eval("GLACODE").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:Label   ID="lblPOQuantity" runat="server" Text='<%#Eval("PO_QTY").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label   ID="lblPORate" runat="server" Text='<%#Eval("PO_RATE").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Extended Amt">
                                <ItemTemplate>
                                    <asp:Label   ID="lblExtendedAmount" runat="server" Text='<%#Eval("PO_EXT_AMOUNT").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Markup Pct">
                                <ItemTemplate>
                                    <asp:Label   ID="lblMarkupPct" runat="server" Text='<%#Eval("PO_COMM_PCT").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Markup Amt">
                                <ItemTemplate>
                                    <asp:Label   ID="lblMarkupAmount" runat="server" Text='<%#Eval("EXT_MARKUP_AMT").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Line Total">
                                <ItemTemplate>
                                    <asp:Label   ID="lblLineTotal" runat="server" Text='<%#Eval("LINE_TOTAL").ToString()%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Estimate/ Budget(Net)">
                                <ItemTemplate>
                                    <asp:Label   ID="lblEstimate" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="PO Used(Net)">
                                <ItemTemplate>
                                    <asp:Label   ID="lblPOUsed" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Balance(Net)">
                                <ItemTemplate>
                                    <asp:Label   ID="lblBalance" runat="server" Text=''></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="CPM">
                                <ItemTemplate>
                                    <asp:Image ID="img_cpm" runat="server" AlternateText="CPM Calculation." ImageAlign="middle"
                                        ImageUrl="~/Images/check.png" Visible='<%#Eval("USE_CPM")%>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="AP"
                                ItemStyle-HorizontalAlign="Center" UniqueName="colAP">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckAP" runat="server" Checked='<%#Eval("ATTACHED_TO_AP")%>' Enabled="false" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Complete"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckComplete" runat="server" Checked='<%#Eval("PO_COMPLETE")%>' Enabled="false" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="sel_del_edit" runat="server" CausesValidation="false" CommandName="Edit"
                                        ImageUrl="images/delete.png" Visible='<%#Eval("CAN_DELETE_FLG")%>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                Confirm<br>
                                                Delete?
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="delete_line" runat="server" AlternateText="Remove row from Order."
                                                    CausesValidation="false" CommandName="Update" ImageUrl="images/delete.png" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibtn_cancel_delete" runat="server" AlternateText="Cancel." CausesValidation="false"
                                                    CommandName="Cancel" ImageUrl="images/exit.png" />
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                    <AlternatingItemStyle VerticalAlign="Top" />
                    <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                    <ClientSettings AllowColumnsReorder="True">
                        <Scrolling AllowScroll="True" ScrollHeight="100%" />
                    </ClientSettings>
                    <GroupingSettings GroupByFieldsSeparator=" " />
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <asp:TextBox ID="PO_NUMBER" runat="server" BackColor="Transparent" BorderStyle="None"
        ForeColor="Transparent" ReadOnly="True" Visible="False" Width="93px">-1</asp:TextBox>
    <asp:TextBox ID="PO_REVISION" runat="server" BackColor="Transparent" MaxLength="6"
        Visible="False" Width="25px">0</asp:TextBox>
    <asp:Label   ID="lbl_pagemode" runat="server" ForeColor="Transparent" Text="read" Visible="False"></asp:Label>
</asp:Content>