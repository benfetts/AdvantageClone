<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Approval_Item_Detail.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Unbilled Function Detail" Inherits="Webvantage.BillingApproval_Approval_Item_Detail"
    Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <!-- RadToolTip Script -->
        <script type="text/javascript">
            function quickCopy(copyText) {
                copyText.select();
                document.execCommand("Copy");
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
        </script>
        <!-- Sum Script -->
        <script type="text/javascript">
            function SumItUp() {
                var x = 0;
                var y = 0;

                var myArray = new Array();
                //add array items, this calls the public server variable we build in rowdatabound
				<%= JSArray %>
    		    //sum it:
    		    for (x = 0; x < myArray.length; x++) {
    		        //multiply the value times one to trick js into always thinking the variable is a number
    		        y = y + (myArray[x] * 1);
    		    }
    		    //display the result
    		    var z = 0;
    		    z = (y * 1);

    		    //document.getElementById(textResult).value = z;
    		    document.getElementById("RadGridItemList_ctl01_ctl03_ctl00_TxtSUM_APPROVED_AMT").textContent = z;
    		}

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarBillingApproval" runat="server" AutoPostBack="true"
                Width="99%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonSave" SkinID="RadToolBarButtonSave"
                        Text="Save/Approve" Value="Save" ToolTip="Save items" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonUpdateFunctionApprovedAmount" Text="Update Function Approved Amount"
                        CheckOnClick="true" AllowSelfUnCheck="true" Value="Dummy" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarTemplateButtonMarkInstruction" Value="MarkInstruction">
                        <ItemTemplate>
                            <telerik:RadComboBox ID="DropMarkAllINSTR" runat="server" SkinID="RadComboBoxStandard" SelectedValue='<%#Eval("INSTR")%>'
                                Width="150">
                                <Items>
                                    <telerik:RadComboBoxItem Text="NA" Value="0"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Bill/Reconcile" Value="1"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Adjust" Value="2"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Transfer" Value="3"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="Hold" Value="4"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton ID="RadToolbarButtonMarkAll" Text="Mark All" Value="MarkAll"
                        ToolTip="Mark all items with the selected billing instruction" />
                    <telerik:RadToolBarButton ID="RadToolbarButtonMarkChecked" Text="Mark Checked" Value="MarkChecked"
                        ToolTip="Mark only checked items with the selected billing instruction" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolbarToggleButtonShowVersionColumns" CheckOnClick="true"
                        AllowSelfUnCheck="true" Text="Show Version" Value="ShowVersionColumns" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
            <div class="more-info">
                        <asp:Label ID="LblInfo" runat="server" Text="Function:"></asp:Label>&nbsp;
                        <asp:Label ID="LblFunction" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:HiddenField ID="HfGrouping" runat="server" Value="GRP_TEXT Availability Group By GROUPING_SEQ,GRP_TEXT" />
                    <telerik:RadGrid ID="RadGridItemList" runat="server" AllowMultiRowSelection="True"
                        AllowPaging="False" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
                        EnableAJAXLoadingTemplate="False" EnableOutsideScripts="true" GroupingEnabled="true"
                        EnableEmbeddedSkins="True" ShowFooter="True" Visible="True" Width="99%">
                        <ClientSettings>
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="True" />
                        </ClientSettings>
                        <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found" DataKeyNames="REC_ID, REC_DTL_ID"
                            Width="99%">
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                    <HeaderStyle HorizontalAlign="center" Width="5px" />
                                    <ItemStyle HorizontalAlign="center" Width="5px" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="NAME" HeaderText="Name" UniqueName="ColNAME">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ITEM_DATE" DataFormatString="{0:d}"
                                    HeaderText="Item Date" UniqueName="ColITEM_DATE">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="INV_NBR" HeaderText="Invoice/<br/>PO Nbr"
                                    UniqueName="ColINV_NBR">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="70" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblINV_NBR" runat="server" Text='<%#Eval("INV_NBR")%>' Visible='<%# Not Eval("HAS_AP_DOCUMENT")%>'></asp:Label>
                                        <asp:LinkButton ID="LbtnINV_NBR" runat="server" Text='<%#Eval("INV_NBR")%>' CommandName="ShowDoc"
                                            CommandArgument='<%#Eval("AP_DOCUMENT_ID")%>' Visible='<%#Eval("HAS_AP_DOCUMENT")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="VERSION_ID" HeaderText="Ver.<br/>ID" SortExpression="VERSION_ID"
                                    UniqueName="ColVERSION_ID">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblVERSION_ID" runat="server" Text='<%#Eval("VERSION_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="JOB_VER_DESC" HeaderText="Version<br />Description"
                                    UniqueName="ColJOB_VER_DESC">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="ITEM_COMMENTS" HeaderText="Comments" SortExpression="ITEM_COMMENTS"
                                    UniqueName="ColITEM_COMMENTS">
                                    <HeaderStyle width="200px" />
                                    <ItemStyle  />
                                    <FooterStyle />
                                    <ItemTemplate>
                                        <asp:Label ID="LblITEM_COMMENTS" runat="server" Text='<%#Eval("ITEM_COMMENTS")%>' ToolTip='<%#Eval("ITEM_COMMENTS")%>' visible="false"></asp:Label>
                                            <asp:TextBox ID="TextBoxComments" runat="server" CssClass="radgrid-textarea" Text='<%#Eval("ITEM_COMMENTS")%>' onclick="quickCopy(this);" TextMode="multiLine" Width="200" ReadOnly="true" SkinID="TextBoxStandard"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="LblITEM_COMMENTSFooter" runat="server" Text="Totals"></asp:Label>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="QTY_HRS" HeaderText="Qty/<br/>Hours" UniqueName="ColQTY_HRS">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblQTY_HRS" runat="server" Text='<%#FormatNumber(Eval("QTY_HRS"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                            <asp:Label ID="LblSUM_QTY_HRS" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="UNBILLED_NET" HeaderText="Net" UniqueName="ColUNBILLED_NET">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblUNBILLED_NET" runat="server" Text='<%#FormatNumber(Eval("UNBILLED_NET"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                            <asp:Label ID="LblSUM_UNBILLED_NET" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="UNBILLED_MU" HeaderText="Markup" UniqueName="ColUNBILLED_MU">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblUNBILLED_MU" runat="server" Text='<%#FormatNumber(Eval("UNBILLED_MU"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                            <asp:Label ID="LblSUM_UNBILLED_MU" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="UNBILLED_NR" HeaderText="Vendor<br/>Tax" UniqueName="ColVENDOR_TAX">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblVENDOR_TAX" runat="server" Text='<%#FormatNumber(Eval("UNBILLED_NR"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                            <asp:Label ID="LblSUM_VENDOR_TAX" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="UNBILLED_TAX" HeaderText="Resale<br/>Tax"
                                    UniqueName="ColUNBILLED_TAX">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblUNBILLED_TAX" runat="server" Text='<%#FormatNumber(Eval("UNBILLED_TAX"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                             <asp:Label ID="LblSUM_UNBILLED_TAX" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="TOTAL" HeaderText="Total" UniqueName="ColTOTAL">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="LblTOTAL" runat="server" Text='<%#FormatNumber(Eval("TOTAL"), 2, True, False, True)%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 6px 0px 0px;">
                                            <asp:Label ID="LblSUM_TOTAL" runat="server" Text="0.00"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Billing<br/>Instruction" UniqueName="colINSTR">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="150" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="middle" Width="150" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfINV_NBR" runat="server" Value='<%#Eval("INV_NBR")%>' />
                                        <asp:HiddenField ID="HfMAX_SEQ" runat="server" Value='<%#Eval("SEQ_NBR")%>' />
                                        <asp:HiddenField ID="HfTotal" runat="server" Value='<%#Eval("TOTAL")%>' />
                                        <asp:HiddenField ID="HfINSTR" runat="server" Value='<%#Eval("INSTR")%>' />
                                        <telerik:RadComboBox ID="DropINSTR" runat="server" SkinID="RadComboBoxStandard" AutoPostBack="True" OnSelectedIndexChanged="DropINSTR_SelectedIndexChanged" Width="150">
                                            <Items>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Net Approved<br/>Amount" UniqueName="ColAPPROVED_AMT">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="95" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="95" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="95" Font-Bold="true" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtAPPROVED_AMT" runat="server" Style="text-align: right;" Text='<%#Eval("APPROVED_AMT")%>' SkinID="TextBoxStandard"
                                            Width="95"></asp:TextBox>
                                        <asp:HiddenField ID="HiddenFieldUnbilledNet" runat="server" Value='<%#Eval("UNBILLED_NET")%>' />
                                        <asp:HiddenField ID="HfAPPROVED_AMT" runat="server" Value='<%#Eval("APPROVED_AMT")%>' />
                                        <asp:HiddenField ID="HfREC_TYPE" runat="server" Value='<%#Eval("REC_TYPE")%>' />
                                        <asp:HiddenField ID="HfREC_ID" runat="server" Value='<%#Eval("REC_ID")%>' />
                                        <asp:HiddenField ID="HfBA_ITEM_ID" runat="server" Value='<%#Eval("BA_ITEM_ID")%>' />
                                        <asp:HiddenField ID="HfSOURCE" runat="server" Value='<%#Eval("SOURCE")%>' />
                                        <asp:HiddenField ID="HfBAID" runat="server" Value='<%#Eval("BA_ID")%>' />
                                        <asp:HiddenField ID="HfIS_PREVIOUSLY_APPROVED" runat="server" Value='<%#Eval("IS_PREVIOUSLY_APPROVED")%>' />
                                        <asp:HiddenField ID="HfHAS_AP_DOCUMENT" runat="server" Value='<%#Eval("HAS_AP_DOCUMENT")%>' />
                                        <asp:HiddenField ID="HfAP_DOCUMENT_ID" runat="server" Value='<%#Eval("AP_DOCUMENT_ID")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div style="padding: 0px 12px 0px 0px;">
                                            <asp:Label ID="TxtSUM_APPROVED_AMT" runat="server" Text="0.00" SkinID="TextBoxCodeLarge" ></asp:Label>                        
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Approval Comments" UniqueName="colAPPR_COMMENTS">
                                    <HeaderStyle CssClass="radgrid-textarea-column" />
                                    <ItemStyle CssClass="radgrid-textarea-column" />
                                    <FooterStyle CssClass="radgrid-textarea-column" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfAPPROVAL_COMMENTS" runat="server" Value='<%#Eval("APPROVAL_COMMENTS")%>' />
                                        <asp:TextBox ID="TxtAPPR_COMMENTS" runat="server" Text='<%#Eval("APPROVAL_COMMENTS")%>' SkinID="TextBoxStandard"
                                            TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Client Comments" UniqueName="colCLIENT_COMMENTS" Visible="false">
                                    <HeaderStyle CssClass="radgrid-textarea-column" />
                                    <ItemStyle CssClass="radgrid-textarea-column" />
                                    <FooterStyle CssClass="radgrid-textarea-column" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfCLIENT_COMMENTS" runat="server" Value='<%#Eval("CLIENT_COMMENTS")%>' />
                                        <asp:TextBox ID="TxtCLIENT_COMMENTS" runat="server" Text='<%#Eval("CLIENT_COMMENTS")%>' SkinID="TextBoxStandard"
                                            TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="BA_ITEM_ID" Display="False" HeaderText="BA_ITEM_ID"
                                    UniqueName="ColBA_ITEM_ID">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REC_TYPE" Display="False" HeaderText="REC_TYPE"
                                    UniqueName="ColREC_TYPE">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REC_ID" Display="False" HeaderText="REC_ID" UniqueName="ColREC_ID">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REC_DTL_ID" Display="False" HeaderText="REC_DTL_ID" UniqueName="ColREC_DTL_ID">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                </telerik:GridBoundColumn>
                            </Columns>
                                <RowIndicatorColumn Visible="False">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                </ExpandCollapseColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Animation="None" RenderMode="Classic"
                        AutoTooltipify="false" Height="100px" ManualClose="false" Modal="false" OnAjaxUpdate="OnAjaxUpdate"
                        Position="BottomRight" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
                        Width="650px">
                    </telerik:RadToolTipManager>
        </div>
        
                </ContentTemplate>
            </asp:UpdatePanel>
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script>
            Telerik.Web.UI.RadToolTipManager.prototype.dispose = function () {
                this._moveUpdatePanel();
                this._disposeToolTips();

                if (this._pageLoadedHandler) {
                    var prm = Sys.WebForms.PageRequestManager.getInstance();

                    prm.remove_pageLoaded(this._pageLoadedHandler);
                    this._pageLoadedHandler = null;
                    this._updatePanelParent = null;
                }
                Telerik.Web.UI.RadToolTipManager.callBaseMethod(this, 'dispose');
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
