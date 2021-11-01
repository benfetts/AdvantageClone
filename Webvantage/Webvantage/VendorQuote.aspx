<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VendorQuote.aspx.vb" Inherits="Webvantage.VendorQuote" MasterPageFile="~/ChildPage.Master"
    Title="Vendor Quote Requests" %>

<asp:Content ID="ContentQuote" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function MultiplyPerc(text1, text2, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var z = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                if (isNaN(x) == false && isNaN(y) == false) {
                    z = (x * 1) * ((y * 1) / 100)
                    //z = z.toFixed(2)
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }

            function Divide(text1, text2, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var z = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                if (isNaN(x) == false && isNaN(y) == false) {
                    z = (x * 1) / (y * 1)
                    //z = z.toFixed(2)
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }

            function Multiply(text1, text2, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                var z = 0;
                if (isNaN(x) == false && isNaN(y) == false) {
                    z = (x * 1) * (y * 1)
                    //z = z.toFixed(2)
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }
            function CalcRateOverrideEst(text1, text2, text3) //t1 = qty,t2 = rate,t3 = amt
            {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text3).value;
                var r = document.getElementById(text2).value;
                var z = 0.000;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                if (isNaN(x) == false && isNaN(y) == false && ((x * 1.000) > 0.000)) {
                    z = (y * 1.00) / (x * 1.00)
                    //z = z.toFixed(3)
                    document.getElementById(text2).value = String.localeFormat("{0:n}", z);
                }
                else {
                    //document.getElementById(text2).value = '99999';
                }
            }
            function CalcTaxAmount(text1, text2, taxstate, taxcity, taxcounty, taxcomm, taxcommonly, markup) //t1 = extamt,t2 = taxamt
            {
                var x = document.getElementById(text1).value;
                var w = document.getElementById(markup).value;
                var j = document.getElementById(taxstate).value;
                var k = document.getElementById(taxcity).value;
                var l = document.getElementById(taxcounty).value;
                var m = document.getElementById(taxcomm).value;
                var n = document.getElementById(taxcommonly).value;
                var z = 0;
                var y = 0;

                x = Number.parseLocale(x);
                w = Number.parseLocale(w);
                j = Number.parseLocale(j);
                k = Number.parseLocale(k);
                l = Number.parseLocale(l);
                m = Number.parseLocale(m);
                n = Number.parseLocale(n);
                if (isNaN(x) == false && x > 0) {
                    if (n != 1) {
                        z = ((x * 1) * ((j * 1) / 100)) + ((x * 1) * ((k * 1) / 100)) + ((x * 1) * ((l * 1) / 100))
                    }
                    if (m == 1 && w > 0) {
                        y = ((w * 1) * ((j * 1) / 100)) + ((w * 1) * ((k * 1) / 100)) + ((w * 1) * ((l * 1) / 100))
                    }
                    z = z + y
                    //z = z.toFixed(2)
                    document.getElementById(text2).value = String.localeFormat("{0:n}", z);

                }
                else {
                    document.getElementById(text2).value = String.localeFormat("{0:n}", 0);
                }
            }

            function AddTotal(text1, text2, text3, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var w = document.getElementById(text3).value;
                var z = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                w = Number.parseLocale(w);
                if (isNaN(x) == false && isNaN(y) == false && isNaN(w) == false) {
                    z = (x * 1) + (y * 1) + (w * 1)
                    //z = z.toFixed(2)
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }
            function CalcPerc(text1, text2, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var z = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                if (isNaN(x) == false && isNaN(y) == false && y != 0) {
                    z = ((x * 1) / (y * 1)) * 100
                    //z = z.toFixed(2)
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }
            function AddGrossIncome(text1, text2, text3, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var w = document.getElementById(text3).value;
                var z = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                w = Number.parseLocale(w);
                if (isNaN(x) == false && isNaN(y) == false) {
                    if (w == 'E') {
                        z = (x * 1) + (y * 1)
                        //z = z.toFixed(2)
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                    }
                    if (w == 'I') {
                        z = (x * 1) + (y * 1)
                        //z = z.toFixed(2)
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                    }
                    if (w == 'V') {
                        z = (y * 1)
                        //z = z.toFixed(2)
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                    }
                    if (w == 'C') {
                        z = '0.00'
                        //z = z.toFixed(2)
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                    }
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }
            function CalcContAmount(text1, text2, textresult, hfresult, taxstate, taxcity, taxcounty, markup, taxcomm, taxcommonly) //t1 = extamt,t2 = taxamt
            {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var m = document.getElementById(markup).value;
                var n = document.getElementById(taxcomm).value;
                var o = document.getElementById(taxcommonly).value;
                var j = document.getElementById(taxstate).value;
                var k = document.getElementById(taxcity).value;
                var l = document.getElementById(taxcounty).value;
                var z = 0;
                var b = 0;
                var u = 0;
                var p = 0;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                m = Number.parseLocale(m);
                n = Number.parseLocale(n);
                o = Number.parseLocale(o);
                j = Number.parseLocale(j);
                k = Number.parseLocale(k);
                l = Number.parseLocale(l);
                if (isNaN(x) == false && isNaN(y) == false) {
                    z = (x * 1) * ((y * 1) / 100)
                    u = (x * 1) * ((y * 1) / 100)
                    p = ((m * 1) * ((y * 1) / 100))
                    if (n == 1 && o == 1) {
                        b = ((p * 1) * ((j * 1) / 100)) + ((p * 1) * ((k * 1) / 100)) + ((p * 1) * ((l * 1) / 100))
                    } else if (n == 1) {
                        b = (((z + p) * 1) * ((j * 1) / 100)) + (((z + p) * 1) * ((k * 1) / 100)) + (((z + p) * 1) * ((l * 1) / 100))
                    } else {
                        b = ((z * 1) * ((j * 1) / 100)) + ((z * 1) * ((k * 1) / 100)) + ((z * 1) * ((l * 1) / 100))
                    }
                    z = z + p + b
                    //z = z.toFixed(2)
                    document.getElementById(textresult).value = String.localeFormat("{0:n}", z);
                    document.getElementById(hfresult).value = String.localeFormat("{0:n}", u);

                }
                else {
                    document.getElementById(text2).value = String.localeFormat("{0:n}", 0);
                }
            }
        </script>
        <script type="text/javascript">
            var RadGridVendors;
            var isChecked = false;
            var isPrintChecked = false;

            function GridCreated() {
                RadGridVendors = this;
            }

            function CancelNonInputSelect(sender, args) {

                var e = args.get_domEvent();
                //IE - srcElement, Others - target  
                var targetElement = e.srcElement || e.target;


                //this condition is needed if multi row selection is enabled for the grid  
                if (typeof (targetElement) != "undefined") {
                    //is the clicked element an input checkbox? <input type="checkbox"...>  
                    if (targetElement.tagName.toLowerCase() != "input" &&
                                    (!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
                    {

                        //cancel the event  
                        args.set_cancel(true);
                    }
                }
                else
                    args.set_cancel(true);
            }
            function CheckAllEmail() {
                isChecked = !isChecked;

                var checkboxes = RadGridVendors.MasterTableView.Control.getElementsByTagName("INPUT");
                var index;

                for (index = 0; index < checkboxes.length; index++) {
                    if (checkboxes[index].id.indexOf("Email") != -1) {
                        if (isChecked) {
                            checkboxes[index].checked = true;
                        }
                        else {
                            checkboxes[index].checked = false;
                        }
                    }
                }
            }

            function CheckAllPrint() {
                isPrintChecked = !isPrintChecked;

                var checkboxes = RadGridVendors.MasterTableView.Control.getElementsByTagName("INPUT");
                var index;

                for (index = 0; index < checkboxes.length; index++) {
                    if (checkboxes[index].id.indexOf("Print") != -1) {
                        if (isPrintChecked) {
                            checkboxes[index].checked = true;
                        }
                        else {
                            checkboxes[index].checked = false;
                        }
                    }
                }
            }

            function confirmSave() {
                if (confirm("This quote is approved. Are you sure you want to save the changes?")) {
                    realPostBack("Save", "Save");
                    //return false;
                } else {
                    return false;
                }
            }
            function confirmBack() {
                if (confirm("Did you save all new data?")) {
                    window.close();
                    window.opener.focus();
                    //return false;
                }
            }
            function confirmRows() {
                ShowMessage("No rows were selected for deletion.")
            }

        </script>
        <script type="text/javascript">
            function confirmDelete() {
                if (confirm("Are you sure you want to delete?")) {
                    realPostBack("DelRevision", "DelRevision");
                    //return false;
                }
            }
            function confirmDeleteCApproval() {
                if (confirm("Are you sure you want to delete this Client Approval?")) {
                    realPostBack("ClientApprove", "ClientApprove");
                    //return false;
                } else {
                    return false;
                }
            }
            function confirmDeleteIApproval() {
                if (confirm("Are you sure you want to delete this Internal Approval?")) {
                    realPostBack("InternalApprove", "InternalApprove");
                    //return false;
                } else {
                    return false;
                }
            }
            function confirmSave() {
                if (confirm("This quote is approved. Are you sure you want to save the changes?")) {
                    realPostBack("Save", "Save");
                    //return false;
                } else {
                    return false;
                }
            }
            function confirmSaveEG() {
                if (confirm("This quote is approved. Are you sure you want to create an event?")) {
                    realPostBack("EventGenerator", "EventGenerator");
                    //return false;
                } else {
                    return false;
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptBlock ID="RadScriptBlock4" runat="server">
        <script type="text/javascript">
            function RadToolbarVendorQuoteJsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "DeleteRows") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                };
            };
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarVendorQuote" runat="server" AutoPostBack="True"
                OnClientButtonClicking="RadToolbarVendorQuoteJsOnClientButtonClicking" Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                        ToolTip="Save this Vendor Quote Request" CausesValidation="true" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" Text="Email/Print Setup" Value="Setup"
                        ToolTip="Email/Print Setup" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Submit" Value="Submit"
                        ToolTip="Submit Vendor Quote Requests" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ImageUrl="Images/spellcheck.png" Text=" " Value="Spell" Visible="false" Enabled="false"
                        ToolTip="Spell Check" />
                    <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Back" Value="Back" ToolTip="Back" Visible="false" />
                    <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                </Items>
            </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <ew:CollapsablePanel ID="CollapsableHead" runat="server" TitleText="Vendor Quote Request">
            <div class="code-description-container">
                <div class="code-description-label">
                    RFQ:
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtRFQ" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeLarge" ReadOnly="true"></asp:TextBox>
                    <asp:HiddenField ID="hfVendorQteNum" runat="server" />
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtRFQDescription" runat="server" ReadOnly="false"
                        TabIndex="1" Text="" SkinID="TextBoxCodeSingleLineDescription" MaxLength="60" CssClass="RequiredInput"></asp:TextBox>
                </div>
            </div>
            <div>
                <div class="code-description-container" style="display: inline-block;">
                    <div class="code-description-label">
                        Request Date:
                    </div>
                    <div class="code-description-code">
                        <telerik:RadDatePicker ID="RadDatePickerRequestDate" runat="server"
                            SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="code-description-container" style="display: inline-block;">
                    <div class="code-description-label">
                        Due Date:
                    </div>
                    <div class="code-description-code">
                        <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server"
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
            <div class="code-description-container">
                <div class="code-description-label" style="vertical-align: top;">
                    Description of Project:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtDescriptionOfProject" runat="server" TabIndex="4" Text="" TextMode="MultiLine" SkinID="TextBoxCodeMultiLine" MaxLength="32000"></asp:TextBox>
                </div>
                <div style="vertical-align: top;display:inline-block;position:relative;margin-left:110px;">
                    <asp:ImageButton ID="ImgBtnComments" runat="server" TabIndex="-1" SkinID="ImageButtonInsert" ToolTip="Insert Comments" ImageAlign="Top" />
                </div>
            </div>
        </ew:CollapsablePanel>
        <telerik:RadTabStrip ID="RadTabStrip" runat="server" AutoPostBack="True" CausesValidation="False"
            Width="100%">
            <Tabs>
                <telerik:RadTab ID="Tab1" runat="server" Text="Vendors" Value="0" Selected="true">
                </telerik:RadTab>
                <telerik:RadTab ID="Tab2" runat="server" Text="Versions" Value="1">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <asp:Panel ID="pnlVersions" runat="server">
            <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
                <script type="text/javascript">
                    function RadToolbarVersionsJsOnClientButtonClicking(sender, args) {
                        var comandName = args.get_item().get_commandName();
                        if (comandName == "DeleteQuote") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        }
                        if (comandName == "DeleteFunction") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        }
                    }
                </script>
            </telerik:RadScriptBlock>
            <div class="no-float-menu" style="margin-top: 6px; margin-bottom: 6px;">
                <telerik:RadToolBar ID="RadToolbarVersions" runat="server" AutoPostBack="False" Width="100%"
                    OnClientButtonClicking="RadToolbarVersionsJsOnClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton
                            Text="Add Quote" Value="AddQuote"
                            ToolTip="Add Quote to Vendor Request" />
                        <telerik:RadToolBarButton Text="Delete Quote" Value="DeleteQuote"
                            ToolTip="Delete Quote" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Add Function" Value="AddFunction"
                            ToolTip="Add Function" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Delete Function" Value="DeleteFunction"
                            Hidden="False" ToolTip="Delete Function" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </div>
       
            <telerik:RadGrid ID="RadGridVersions" runat="server" AutoGenerateColumns="False"
                GridLines="None" AllowMultiRowSelection="true" EnableEmbeddedSkins="True"
                AllowAutomaticInserts="true" Width="75%">
                <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                    <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                </ClientSettings>
                <MasterTableView DataKeyNames="EST_QUOTE_NBR, EST_REV_NBR, EST_QUOTE_DESC" HierarchyDefaultExpanded="True">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Version" SortExpression="EST_QUOTE_NBR"
                            UniqueName="EST_QUOTE_NBR" ItemStyle-Width="100px">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Description" SortExpression="EST_QUOTE_DESC"
                            UniqueName="EST_QUOTE_DESC">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_REV_NBR" HeaderText="" SortExpression="EST_REV_NBR"
                            UniqueName="EST_REV_NBR" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Comments" UniqueName="colVN_QTE_SPECS">
                            <HeaderStyle VerticalAlign="bottom" Width="600px" />
                            <ItemStyle VerticalAlign="middle" Width="600px" />
                            <FooterStyle VerticalAlign="middle" Width="600px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtVN_QTE_SPECS" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("VN_QTE_SPECS")%>' TextMode="multiLine" Width="600px" Height="50px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("EST_QUOTE_NBR")%>' CommandName="ShowComments" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <PopUpSettings ScrollBars="None" />
                    </EditFormSettings>
                    <DetailTables>
                        <telerik:GridTableView BorderWidth="1" AllowPaging="False" AllowSorting="True" DataKeyNames="EST_QUOTE_NBR,EST_REV_NBR,EST_FNC_CODE"
                            Width="100%" Name="Emp" NoDetailRecordsText="No records to display.">
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="EST_FNC_CODE" HeaderText="Function" UniqueName="column1"
                                    ItemStyle-Width="50px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Description" UniqueName="column2"
                                    ItemStyle-Width="200px">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Comments" UniqueName="colEST_FNC_COMMENT">
                                    <HeaderStyle CssClass="radgrid-textarea-column" />
                                    <ItemStyle CssClass="radgrid-textarea-column" />
                                    <FooterStyle CssClass="radgrid-textarea-column" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtEST_FNC_COMMENT" runat="server" SkinID="TextBoxStandard"
                                            Text='<%#Eval("FNC_NOTES")%>' TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colComments">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("EST_FNC_CODE")%>' CommandName="ShowCommentsFunction" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Version" SortExpression="EST_QUOTE_NBR"
                                    UniqueName="EST_QUOTE_NBR" ItemStyle-Width="100px" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EST_REV_NBR" HeaderText="" SortExpression="EST_REV_NBR"
                                    UniqueName="EST_REV_NBR" Visible="false">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </telerik:GridTableView>
                    </DetailTables>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
        <asp:Panel ID="pnlVendors" runat="server">
            <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                <script type="text/javascript">
                    function RadToolbarVendorsJsOnClientButtonClicking(sender, args) {
                        var comandName = args.get_item().get_commandName();
                        if (comandName == "DeleteVendor") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                        }
                    }
                </script>
            </telerik:RadScriptBlock>
            <div class="no-float-menu" style="margin-top: 6px; margin-bottom: 6px;">
                <telerik:RadToolBar ID="RadToolbarVendors" runat="server" AutoPostBack="False" Width="100%"
                    OnClientButtonClicking="RadToolbarVendorsJsOnClientButtonClicking">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Add Vendor" Value="AddVendor"
                            ToolTip="Add Vendor" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Delete Vendor" Value="DeleteVendor"
                            Hidden="False" ToolTip="Delete Vendor" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Insert into Estimate/Quote"
                            Value="InsertEst" Hidden="False" ToolTip="Insert approved items into the Estimate/Quote" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Add Vendor Contact" Value="AddContact"
                            Hidden="False" ToolTip="Add Vendor Contact" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Text="Edit Vendor Contact" Value="EditContact"
                            Hidden="False" ToolTip="Edit Vendor Contact" />
                    </Items>
                </telerik:RadToolBar>
            </div>
        
            <telerik:RadGrid ID="RadGridVendors" runat="server" AutoGenerateColumns="False" GridLines="None"
                EnableEmbeddedSkins="True" AllowMultiRowSelection="true" EnableAJAX="false">
                <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                    <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                    <ClientEvents OnGridCreated="GridCreated" />
                </ClientSettings>
                <MasterTableView DataKeyNames="VN_CODE, EMAIL_ADDRESS">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn UniqueName="colViewClient">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnViewClient" runat="server" CommandName="ViewReport" CommandArgument='<%#Eval("VN_CODE")%>'>View</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Middle" Width="20px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center"
                            UniqueName="colChkEmailClient">
                            <HeaderTemplate>
                                <a href="#" onclick="javascript:CheckAllEmail();">Email</a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEmailClient" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="20px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center"
                            UniqueName="colChkPrintClient">
                            <HeaderTemplate>
                                <a href="#" onclick="javascript:CheckAllPrint();">Print</a>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkPrintClient" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" Width="20px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="VN_CODE" HeaderText="" SortExpression="VN_CODE"
                            UniqueName="VN_CODE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Vendor" SortExpression="VN_NAME"
                            UniqueName="VN_NAME" ItemStyle-Width="150px">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="left"
                            ItemStyle-VerticalAlign="middle" ItemStyle-Width="10px" UniqueName="colCLI_CONTACT_IMGBTN">
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnClientContacts" runat="server" CommandArgument='<%#Eval("VN_CODE")%>'
                                        CommandName="SetClientContacts" SkinID="ImageButtonClientContactWhite" />
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="bottom" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="VN_CONT_CODE" HeaderText="" SortExpression="VN_CONT_CODE"
                            UniqueName="VN_CONT_CODE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="VC_FNAME" HeaderText="Contact" UniqueName="colVC_FNAME">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtVC_FNAME" runat="server" SkinID="TextBoxStandard"
                                    Style="text-align: left;" Text='<%# Eval("VC_FNAME") %>' Width="145px" MaxLength="10"
                                    ReadOnly="true"></asp:TextBox>
                                <asp:HiddenField ID="hfVN_CONT_CODE" runat="server" Value='<%# Eval("VN_CONT_CODE") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="VC_MI" HeaderText="" SortExpression="VC_MI" UniqueName="VC_MI"
                            Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VC_LNAME" HeaderText="" SortExpression="VC_LNAME"
                            UniqueName="VC_LNAME" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EMAIL_ADDRESS" HeaderText="Email" SortExpression="EMAIL_ADDRESS"
                            UniqueName="EMAIL_ADDRESS" ItemStyle-Width="150px">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Address" UniqueName="colVC_ADDRESS1">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtVC_ADDRESS1" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("VC_ADDRESS1")%>' TextMode="multiLine" CssClass="radgrid-textarea"
                                    ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="VC_ADDRESS2" HeaderText="" SortExpression="VC_ADDRESS2"
                            UniqueName="VC_ADDRESS2" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VC_CITY" HeaderText="" SortExpression="VC_CITY"
                            UniqueName="VC_CITY" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VC_STATE" HeaderText="" SortExpression="VC_STATE"
                            UniqueName="VC_STATE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VC_ZIP" HeaderText="" SortExpression="VC_ZIP"
                            UniqueName="VC_ZIP" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VC_TELEPHONE" HeaderText="Phone" SortExpression="VC_TELEPHONE"
                            UniqueName="VC_TELEPHONE" ItemStyle-Width="120px">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Comments" UniqueName="colVN_NOTES">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtVN_NOTES" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("VN_NOTES")%>' TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("VN_CODE")%>' CommandName="ShowComments" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="DISPATCH_DATE" HeaderText="Submitted" UniqueName="colDISPATCH_DATE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtDISPATCH_DATE" runat="server" SkinID="TextBoxStandard"
                                    Style="text-align: right;" Text='<%# Eval("DISPATCH_DATE") %>' Width="80px" MaxLength="10"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="REPLY_DATE" HeaderText="Replied" UniqueName="colREPLY_DATE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtREPLY_DATE" runat="server" SkinID="TextBoxStandard"
                                    Style="text-align: right;" Text='<%# Eval("REPLY_DATE") %>' Width="80px" MaxLength="10"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <PopUpSettings ScrollBars="None" />
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadGrid ID="RadGridVendorReplies" runat="server" AutoGenerateColumns="False"
                GridLines="None" AllowMultiRowSelection="true" EnableEmbeddedSkins="True">
                <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                    <Scrolling AllowScroll="false" SaveScrollPosition="true" UseStaticHeaders="False" />
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                </ClientSettings>
                <MasterTableView DataKeyNames="VN_CODE,EST_QUOTE_NBR,EST_FNC_CODE,EST_REV_NBR">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Vendor" SortExpression="VN_NAME"
                            UniqueName="VN_NAME">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Version" SortExpression="EST_QUOTE_NBR"
                            UniqueName="colEST_QUOTE_NBR" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Version" SortExpression="EST_QUOTE_DESC"
                            UniqueName="EST_QUOTE_DESC">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function" SortExpression="FNC_DESCRIPTION"
                            UniqueName="FNC_DESCRIPTION">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VN_CODE" HeaderText="" SortExpression="VN_CODE"
                            UniqueName="colVN_CODE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="QTY" HeaderText="Qty" UniqueName="colQTY">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtQTY" runat="server" Style="text-align: right;" SkinID="TextBoxStandard"
                                    MaxLength="12" Text='<%# Eval("QTY") %>' Width="80px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="REPLY_RATE" HeaderText="Rate" UniqueName="colREPLY_RATE">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtREPLY_RATE" runat="server" SkinID="TextBoxStandard"
                                    Style="text-align: right;" MaxLength="12" Text='<%# Eval("REPLY_RATE") %>' Width="80px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="REPLY_AMT" HeaderText="Amount" UniqueName="colREPLY_AMT">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Bottom" Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="60px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtREPLY_AMT" runat="server" SkinID="TextBoxStandard"
                                    Style="text-align: right;" MaxLength="12" Text='<%# Eval("REPLY_AMT") %>' Width="80px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Reply Notes" UniqueName="colREPLY_NOTES">
                            <HeaderStyle VerticalAlign="bottom" Width="200px" />
                            <ItemStyle VerticalAlign="middle" Width="200px" />
                            <FooterStyle VerticalAlign="middle" Width="200px" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtREPLY_NOTES" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("REPLY_NOTES")%>' TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Approved" UniqueName="colAPPROVED_FLAG">
                            <HeaderStyle VerticalAlign="bottom" Width="50px" />
                            <ItemStyle VerticalAlign="middle" Width="50px" />
                            <FooterStyle VerticalAlign="middle" Width="50px" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbAPPROVED_FLAG" runat="server" Checked='<%#Eval("APPROVED_FLAG")%>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Approved By" UniqueName="colAPPROVED_BY">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPROVED_BY" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("APPROVED_BY")%>' Width="100px"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Approval Notes" UniqueName="colAPPROVAL_NOTES">
                            <HeaderStyle CssClass="radgrid-textarea-column" />
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <FooterStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPROVAL_NOTES" runat="server" SkinID="TextBoxStandard"
                                    Text='<%#Eval("APPROVAL_NOTES")%>' TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("VN_CODE")%>' CommandName="ShowComments" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="EST_FNC_CODE" HeaderText="" SortExpression="EST_FNC_CODE"
                            UniqueName="colEST_FNC_CODE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_REV_NBR" HeaderText="" SortExpression="EST_REV_NBR"
                            UniqueName="colEST_REV_NBR" Display="false">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <EditFormSettings>
                        <PopUpSettings ScrollBars="None" />
                    </EditFormSettings>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
    </div>
    
</asp:Content>
