<%@ Page AutoEventWireup="false" CodeBehind="ARStatements.aspx.vb" Inherits="Webvantage.ARStatements"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="AR Statements" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc1" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">  
    
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            var RadGridARClient;
            var isChecked = false;
            var isPrintChecked = false;
            var isOnAcctChecked = false;

            function GridCreated() {
                RadGridARClient = this;
            };

            function CheckAllEmail(hdrCheck) {
                var i;
                var grid = $find("<%=RadGridARClient.ClientID %>");
                var masterTable = grid.get_masterTableView();
                for (i = 0; i < masterTable.get_dataItems().length; i++) {
                    var checkbox = masterTable.get_dataItems()[i].findElement("chkEmailClient");
                    if (hdrCheck.checked == true) {
                        checkbox.checked = true;
                    }
                    else {
                        checkbox.checked = false;
                    };

                };
            };

            function CheckAllPrint(hdrCheck) {
                var i;
                var grid = $find("<%=RadGridARClient.ClientID %>");
                var masterTable = grid.get_masterTableView();
                for (i = 0; i < masterTable.get_dataItems().length; i++) {
                    var checkbox = masterTable.get_dataItems()[i].findElement("chkPrintClient");
                    if (hdrCheck.checked == true) {
                        checkbox.checked = true;
                    }
                    else {
                        checkbox.checked = false;
                    };
                };
            };

            //function CheckAllOnAcct() {
            //    isOnAcctChecked = !isOnAcctChecked;

            //    var checkboxes = RadGridARClient.MasterTableView.Control.getElementsByTagName("INPUT");
            //    var index;

            //    for (index = 0; index < checkboxes.length; index++) {
            //        if (checkboxes[index].id.indexOf("OnAcct") != -1) {
            //            if (isOnAcctChecked) {
            //                checkboxes[index].checked = true;
            //            }
            //            else {
            //                checkboxes[index].checked = false;
            //            };
            //        };
            //    };
            //};

            function CheckAllOnAcct(hdrCheck) {
                var i;
                var grid = $find("<%=RadGridARClient.ClientID %>");
                var masterTable = grid.get_masterTableView();
                for (i = 0; i < masterTable.get_dataItems().length; i++) {
                    var checkbox = masterTable.get_dataItems()[i].findElement("chkOnAcctClient");
                    if (hdrCheck.checked == true) {
                        checkbox.checked = true;
                    }
                    else {
                        checkbox.checked = false;
                    };
                };
            };
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13)) {
                    return false;
                    //evt.keyCode = 9;
                }
            }

            document.onkeypress = stopRKey;
        </script>
    </telerik:RadScriptBlock>
    <div id="ar-container" class="telerik-aqua-body style-fixes" style="margin-top: 5px!important;">
        <table class="table-spacing" border="0" align="left" cellspacing="2" cellpadding="3">
                <tr>
                    <td width="20">&nbsp;
                    </td>
                    <td align="left" width="90" valign="bottom">AR Type:
                    </td>
                    <td align="left" width="230" valign="bottom">Location ID:
                    </td>
                    <td align="left" width="95" valign="bottom">Posting Period:
                    </td>
                    <td align="left" width="100" valign="bottom">Aging Date:
                    </td>
                    <td align="left" width="230" valign="bottom">Reference:
                    </td>
                </tr>
                <tr>
                    <td width="20">&nbsp;
                    </td>
                    <td align="left" valign="top">
                        <telerik:RadComboBox ID="ddARType" runat="server" AutoPostBack="true" Width="100" SkinID="RadComboBoxStandard">
                            <Items>
                                <telerik:RadComboBoxItem Value="client" Text="Client"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="product" Text="Product"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td align="left" valign="top">
                        <telerik:RadComboBox ID="ddLocation" runat="server" Width="250" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left" valign="top">
                        <telerik:RadComboBox ID="ddPostingPeriod" runat="server" Width="95" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left" valign="top">
                        <telerik:RadDatePicker ID="RadDatePickerAgingDate" runat="server"
                            SkinID="RadDatePickerStandard">
                        </telerik:RadDatePicker>
                    </td>
                    <td align="left" valign="top">
                        <telerik:RadComboBox ID="ddCReportTemplate" runat="server" Width="320" SkinID="RadComboBoxStandard">
                            <Items>
                                <telerik:RadComboBoxItem Value="1" Text="001 Reference All Types"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="2" Text="002 Reference Job"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="3" Text="003 Reference All Types with Payment History"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="4" Text="004 Reference All Types Order Detail"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td width="20">&nbsp;
                    </td>
                    <td colspan="3" align="left" valign="top">Print Statement Comment in
                                    <asp:RadioButtonList ID="RblPrintHeaderFooter" runat="server" RepeatLayout="Flow"
                                        RepeatDirection="Horizontal">
                                        <Items>
                                            <asp:ListItem Text="Header" Value="h" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Footer" Value="f"></asp:ListItem>
                                        </Items>
                                    </asp:RadioButtonList>
                    </td>
                    <td colspan="2" align="left" valign="top">Age by Date:
                        <telerik:RadButton ID="RadButtonInvoiceDate" runat="server" ToggleType="Radio"
                            ButtonType="ToggleButton" Checked="true" GroupName="AgingType" AutoPostBack="false"
                            Text="Invoice Date" Font-Underline="false">
                        </telerik:RadButton>
                        <telerik:RadButton ID="RadButtonDueDate" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                            GroupName="AgingType" AutoPostBack="false" Text="Due Date" Font-Underline="false">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td width="20">&nbsp;
                    </td>
                    <td colspan="3" align="left" valign="top">Send Options:
                        <telerik:RadButton ID="RadButtonAll" runat="server" ToggleType="Radio"
                            ButtonType="ToggleButton" Checked="true" GroupName="Status" AutoPostBack="false"
                            Text="All" Font-Underline="false">
                        </telerik:RadButton>
                        <telerik:RadButton ID="RadButtonThirtyPlus" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                            GroupName="Status" AutoPostBack="false" Text="Only 30 +" Font-Underline="false">
                        </telerik:RadButton>
                        <telerik:RadButton ID="RadButtonSixtyPlus" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                            GroupName="Status" AutoPostBack="false" Text="Only 60 +" Font-Underline="false">
                        </telerik:RadButton>
                    </td>
                    <td colspan="2" align="left" valign="top">
                        <asp:CheckBox ID="CheckboxExcludeDescription" runat="server" Text="Exclude Reference and Description" />
                    </td>
                </tr>
            </table>
            <ew:CollapsablePanel ID="CollapsablePanelEmailOptions" runat="server" TitleText="Email Options">
                <div class="div-spacing">
                    <div>
                        Subject:
                    </div>
                    <div>
                        <asp:TextBox ID="txtCSubject" runat="server" Width="480px" SkinID="TextBoxStandard"></asp:TextBox>
                    </div>
                    <div>
                        Body:
                    </div>
                    <div>
                        <asp:TextBox ID="txtCBody" runat="server" TextMode="MultiLine" Width="480px" SkinID="TextBoxStandard"></asp:TextBox>
                    </div>
                    <div>
                        CC:
                    </div>
                    <div>
                        <asp:TextBox ID="txtCCopyEmail" runat="server" TextMode="MultiLine" Width="480px" SkinID="TextBoxStandard"></asp:TextBox>
                    </div>
                    <div>
                        <asp:CheckBox ID="cbAddcc" runat="server" Text="Check to Add CC" />
                    </div>
                </div>
                
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" TitleText="Filter">
                <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                    <tr>
                        <td Width="500">
                            <div>
                                Office: (filters invoices by office on statements)<asp:ImageButton ID="ImgBtnRefresh"
                                    Visible="false" runat="server" AlternateText="Refresh" ImageAlign="AbsMiddle"
                                    SkinID="ImageButtonRefresh" ToolTip="Refresh" />
                            </div>
                            <div>
                                <telerik:RadListBox ID="LbOffices" runat="server" AutoPostBack="true" SelectionMode="Multiple"
                                    Height="200" Width="500">
                                </telerik:RadListBox>
                            </div>
                        </td>
                        <td width="10">&nbsp;</td>
                        <td Width="500">
                            <div>
                                Account Executive:  (filters invoices by Default AE for statements)
                            </div>
                            <div>
                                <telerik:RadListBox ID="RadListBoxAccountExecutive" runat="server" AutoPostBack="true" SelectionMode="Multiple"
                                    Height="200" Width="500">
                                </telerik:RadListBox>
                            </div>
                        </td>
                    </tr>
                </table>
        
            </ew:CollapsablePanel>
            <ew:CollapsablePanel ID="CollapsablePanelGrid" runat="server" TitleText="Recipients">                
                <telerik:RadGrid ID="RadGridARClient" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" ItemStyle-VerticalAlign="Top"
                    EnableEmbeddedSkins="True" UseEmbeddedScripts="False" Width="100%" PageSize="250">                    
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" PageSizes="250,500,750,1000"></PagerStyle>       
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GridCreated" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="GridDataKey" Width="100%">
                            <PagerStyle PageSizes="250,500,750,1000" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="colViewClient">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnViewClient" runat="server" CommandName="ViewReport">View</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle VerticalAlign="Middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="GridDisplay" HeaderText="" UniqueName="colClient">
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ContactDisplay" HeaderText="Contact" UniqueName="colContactClient">
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                UniqueName="colChkEmailClient">
                                <HeaderTemplate>
                                    Email
                                    <input id="chkemail" type="checkbox" runat="server" onclick="javascript: CheckAllEmail(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmailClient" runat="server" Checked='<%#SetEmailCheckBox(Eval("EmailIt"), Eval("ContactEmail").ToString)%>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                UniqueName="colChkPrintClient">
                                <HeaderTemplate>
                                    Print
                                    <input id="CheckBoxAllPrint" type="checkbox" runat="server" onclick="javascript: CheckAllPrint(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPrintClient" runat="server" Checked='<%# SetCheckBox(Eval("PrintIt")) %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="" ItemStyle-HorizontalAlign="Center"
                                UniqueName="colChkOnAcctClient">
                                <HeaderTemplate>
                                    On Acct
                                    <input id="CheckBoxAllOnAcct" type="checkbox" runat="server" onclick="javascript: CheckAllOnAcct(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkOnAcctClient" runat="server" Checked='<%# SetCheckBox(Eval("IncludeOnAccount")) %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" VerticalAlign="Middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Address" UniqueName="colDropAddressClient">
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="ddCUseAddressClient" runat="server" Width="115" SkinID="RadComboBoxStandard" InputCssClass="no-border" SelectedIndex='<%# UseAddress(Eval("Address")).ToString()%>'>
                                        <Items>
                                            <telerik:RadComboBoxItem Value="1" Text="Contact"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Value="2" Text="Statement"></telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="LAST_EMAILED" HeaderText="Emailed Last" UniqueName="colEmailedClient">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="145" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="145" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="LAST_PRINTED" HeaderText="Printed Last" UniqueName="colPrintedClient">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="145" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="145" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <NoRecordsTemplate>
                            No data.
                        </NoRecordsTemplate>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <ItemStyle VerticalAlign="Top" />
                </telerik:RadGrid>   
            </ew:CollapsablePanel>
            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td align="center" valign="middle">
                        <uc1:reporttype ID="reporttype" runat="server" />
                        <br />
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="-1" /><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <asp:Label ID="lblSummary" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>
