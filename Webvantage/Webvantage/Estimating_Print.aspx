<%@ Page AutoEventWireup="false" CodeBehind="Estimating_Print.aspx.vb" Inherits="Webvantage.Estimating_Print"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Print Estimate" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc2" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function showhide(id) {
            if (document.getElementById) {
                obj = document.getElementById(id);
                if (obj.style.display == "none") {
                    obj.style.display = "";
                } else {
                    obj.style.display = "none";
                }
            }
        }
        function disableobject(id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                obj3 = document.getElementById(id3);
                obj4 = document.getElementById(id4);
                obj5 = document.getElementById(id5);
                obj6 = document.getElementById(id6);
                obj7 = document.getElementById(id7);
                obj8 = document.getElementById(id8);
                obj9 = document.getElementById(id9);
                obj10 = document.getElementById(id10);
                obj11 = document.getElementById(id11);
                obj12 = document.getElementById(id12);
                obj13 = document.getElementById(id13);
                obj14 = document.getElementById(id14);
                if (obj.checked) {
                    obj2.disabled = true;
                    obj3.disabled = true;
                    obj4.disabled = true;
                    obj5.disabled = true;
                    obj6.disabled = true;
                    obj7.disabled = true;
                    obj8.disabled = true;
                    obj9.disabled = true;
                    obj10.disabled = true;
                    obj11.disabled = true;
                    obj12.disabled = true;
                    obj13.disabled = true;
                    obj14.disabled = true;
                } else {
                    obj2.disabled = false;
                    obj3.disabled = false;
                    obj4.disabled = false;
                    obj5.disabled = false;
                    obj6.disabled = false;
                    obj7.disabled = false;
                    obj8.disabled = false;
                    obj9.disabled = false;
                    obj10.disabled = false;
                    obj11.disabled = false;
                    obj12.disabled = false;
                    obj13.disabled = false;
                    obj14.disabled = false;
                }

            }
        }
        function enableobject(id1, id2, id3, id4, id5, id6, id7, id8, id9, id10, id11, id12, id13, id14) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                obj3 = document.getElementById(id3);
                obj4 = document.getElementById(id4);
                obj5 = document.getElementById(id5);
                obj6 = document.getElementById(id6);
                obj7 = document.getElementById(id7);
                obj8 = document.getElementById(id8);
                obj9 = document.getElementById(id9);
                obj10 = document.getElementById(id10);
                obj11 = document.getElementById(id11);
                obj12 = document.getElementById(id12);
                obj13 = document.getElementById(id13);
                obj14 = document.getElementById(id14);
                if (obj.checked) {
                    obj2.disabled = false;
                    obj3.disabled = false;
                    obj4.disabled = false;
                    obj5.disabled = false;
                    obj6.disabled = false;
                    obj7.disabled = false;
                    obj8.disabled = false;
                    obj9.disabled = false;
                    obj10.disabled = false;
                    obj11.disabled = false;
                    obj12.disabled = false;
                    obj13.disabled = false;
                    obj14.disabled = false;
                } else {
                    obj2.disabled = true;
                    obj3.disabled = true;
                    obj4.disabled = true;
                    obj5.disabled = true;
                    obj6.disabled = true;
                    obj7.disabled = true;
                    obj8.disabled = true;
                    obj9.disabled = true;
                    obj10.disabled = true;
                    obj11.disabled = true;
                    obj12.disabled = true;
                    obj13.disabled = true;
                    obj14.disabled = true;
                }

            }
        }
        function enableobjectIO(id1, id2, id3, id4, id5, id6, id7, id8) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                obj3 = document.getElementById(id3);
                obj4 = document.getElementById(id4);
                obj5 = document.getElementById(id5);
                obj6 = document.getElementById(id6);
                obj7 = document.getElementById(id7);
                obj8 = document.getElementById(id8);
                if (obj.checked) {
                    obj2.disabled = false;
                    obj3.disabled = false;
                    obj4.disabled = false;
                    obj5.disabled = false;
                    obj6.disabled = false;
                    obj7.disabled = false;
                    obj8.disabled = false;
                } else {
                    obj2.disabled = true;
                    obj3.disabled = true;
                    obj4.disabled = true;
                    obj5.disabled = true;
                    obj6.disabled = false;
                    obj7.disabled = false;
                    obj8.disabled = false;
                }

            }
        }
        function enableobjectCont(id1, id2) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                if (obj.checked) {
                    obj2.disabled = false;
                } else {
                    obj2.disabled = true;
                }

            }
        }
        function enableobjectFH(id1, id2) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                if (obj.checked) {
                    obj2.disabled = true;
                } else {
                    obj2.disabled = false;
                }

            }
        }
        function disableobjectRate(id1, id2) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                if (obj.checked) {
                    obj2.disabled = true;
                } else {
                    obj2.disabled = false;
                }

            }
        }
        function enableobjectRate(id1, id2, id3) {
            if (document.getElementById) {
                obj = document.getElementById(id1);
                obj2 = document.getElementById(id2);
                obj3 = document.getElementById(id3);
                if (obj.checked) {
                    if (obj3.checked) {
                        obj2.disabled = true;
                    } else {
                        obj2.disabled = false;
                    }
                } else {
                    obj2.disabled = true;
                }

            }
        }
    </script>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <div id="DivToolbar" runat="server" style="width: 100%;">
                    <telerik:RadToolBar ID="RadToolbarEstimatingPrint" runat="server" AutoPostBack="True"
                        Width="100%">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                            <telerik:RadToolBarButton Value="Save" ToolTip="Save Settings" SkinID="RadToolBarButtonSave" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
                </div>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Estimate to Print
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="top" width="50%">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblClient" runat="server">Client:</asp:Label>
                                        </span>
                                    </td>
                                    <td width="2%">
                                        &nbsp;
                                    </td>
                                    <td width="70%">
                                        <asp:Label   ID="LabelClientCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelClientDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <span>
                                            <asp:Label   ID="lblDivision" runat="server">Division:</asp:Label></span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label   ID="LabelDivisionCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelDivisionDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <span>
                                            <asp:Label   ID="lblProduct" runat="server">Product:</asp:Label></span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label   ID="LabelProductCode" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelProductDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top" width="50%">
                            <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblEstimate" runat="server">Estimate:</asp:Label></span>
                                    </td>
                                    <td width="2%">
                                        &nbsp;
                                    </td>
                                    <td width="70%">
                                        <asp:Label   ID="LabelEstimateNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelEstimateDescription" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hfCreateDate" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblEstimateComponent" runat="server">Component:</asp:Label></span>
                                    </td>
                                    <td width="2%">
                                        &nbsp;
                                    </td>
                                    <td width="70%">
                                        <asp:Label   ID="LabelEstimateComponentNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelEstimateComponentDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblJob" runat="server">Job:</asp:Label></span>
                                    </td>
                                    <td width="2%">
                                        &nbsp;
                                    </td>
                                    <td width="70%">
                                        <asp:Label   ID="LabelJobNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <span>
                                            <asp:Label   ID="lblComponent" runat="server">Component:</asp:Label></span>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label   ID="LabelJobComponentNumber" runat="server" Text=""></asp:Label>&nbsp;-&nbsp;
                                        <asp:Label   ID="LabelJobComponentDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="3" align="center">
                                        <br />
                                        <telerik:RadGrid ID="RadGridEstQuote" runat="server" AllowMultiRowSelection="True"
                                            AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                                            Width="75%" Title="Components/Quotes">
                                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                            <ClientSettings EnablePostBackOnRowClick="False">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                            </ClientSettings>
                                            <MasterTableView DataKeyNames="EstimateNumber,EstimateComponentNumber,QuoteNumber">
                                                <Columns>
                                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                        <HeaderStyle HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="center" />
                                                    </telerik:GridClientSelectColumn>
                                                    <telerik:GridBoundColumn DataField="QuoteNumber" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                                                        <HeaderStyle HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridBoundColumn DataField="QuoteDesc" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                                                        <HeaderStyle HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hfEstimateComp" runat="server" Value='<%# Eval("EstimateComponentNumber")%>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <ExpandCollapseColumn Visible="False">
                                                    <HeaderStyle Width="19px" />
                                                </ExpandCollapseColumn>
                                                <RowIndicatorColumn Visible="False">
                                                    <HeaderStyle Width="20px" />
                                                </RowIndicatorColumn>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Output Format
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" height="5px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label2" runat="server" Text="Report Format:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<telerik:RadComboBox ID="ddReportFormat" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard"
                                Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem Text="001 - One Quote per Page" Value=""></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="002 - Side by Side Quote" Value="002"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="003 - Revision Comparison" Value="003"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="004 - Revision Comparison w/Variance" Value="004">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="005 - Revision Comparison w/Var, No Actual" Value="005">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="006 - Revision Comparison, No Actual" Value="006">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="007 - Revision Comparison, Prev/Last Revisions" Value="007">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="008 - Campaign Estimate Totals by Estimate Component"
                                        Value="008"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="009 - Campaign Estimate by Function Heading" Value="009">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="300 - SSX - Campaign Estimate" Value="SS1"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="301 - SSX - Estimate" Value="SS2"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="302 - Quarry - Campaign Estimate" Value="QUR"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="303 - All Components, Subtotal Components" Value="Mars">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="304 - Original/Final Comparison w/Var, No Actual"
                                        Value="304"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="305 - Original/Final Comparison, No Actual" Value="305">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="306 - Infinity Estimate" Value="Infinity">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="307 - BWD Estimate Form" Value="BWD">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="308 - BWD Client Estimate Form" Value="BWD2">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="309 - TPN Custom Estimate Form" Value="TPN">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="310 - TPN Custom Estimate Form 2" Value="TPN2">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="311 - Tap Campaign Estimate" Value="TAP">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="312 - Tap Campaign Estimate (Job) " Value="TAP2">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="313 - Revision Comparison w/Var, Prev/Last Revisions" Value="313">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="314 - Side by Side Quote with Function Comments" Value="314">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="315 - GYKA Estimate" Value="315">
                                    </telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td style="width: 105px;" align="right">
                            <asp:Label   ID="Label5" runat="server" Text="Address Options:"></asp:Label>
                        </td>
                        <td rowspan="3" align="left" valign="top">
                            <asp:RadioButtonList ID="rbCDPAddress" runat="server">
                                <asp:ListItem Value="Client" Selected="True">Client Address</asp:ListItem>
                                <asp:ListItem Value="Division">Division Address</asp:ListItem>
                                <asp:ListItem Value="Product">Product Address</asp:ListItem>
                                <asp:ListItem Value="Contact">Client Contact Address</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label7" runat="server" Text="Signature Format:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<telerik:RadComboBox ID="ddSignature" runat="server" AutoPostBack="true" Width="350px" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="None" Value="0"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="001 - Standard Signature" Value="1"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="002 - Agency, 2 Client Signatures" Value="2"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="003 - Agency Name, Client Authorization" Value="3">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="004 - Agency, 5 Client Signatures" Value="4"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="005 - Standard Signature with Client PO Line" Value="5">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="006 - Agency, 2 Client w/Titles" Value="6" Visible="false">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="007 - Agency and Client Signature" Value="7">
                                    </telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="008 - Manager, AE, and Client Signature" Value="8">
                                    </telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td style="width: 105px;" align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            &nbsp;
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<asp:CheckBox ID="CheckBoxExcludeSignatures" runat="server" Text="Exclude Employee Signatures" />
                        </td>
                        <td style="width: 105px;" align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label1" runat="server" Text="Report Title:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<asp:TextBox ID="txtReportTitle" runat="server" MaxLength="30" Width="388px" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                        <td style="width: 105px;" align="right">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="5px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Location
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<telerik:RadComboBox ID="dl_location" runat="server" Width="329px" DataTextField="LOC_NAME" SkinID="RadComboBoxStandard"
                                DataValueField="LOCATION_ID">
                            </telerik:RadComboBox>
                        </td>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label6" runat="server" Text="File Format:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<telerik:RadComboBox ID="ddlFormat" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                            <%--<uc2:reporttype ID="Reporttype2" runat="server" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <asp:Panel ID="pnlExclude" runat="server" Visible="false">
            <tr>
                <td class="sub-header sub-header-color">
                    &nbsp;&nbsp;&nbsp;Print Options
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxEmp" runat="server" Text="Exclude Employee Time Functions"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxVen" runat="server" Text="Exclude Vendor Functions"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxIO" runat="server" Text="Exclude Income Only Functions"
                                    Width="336px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="PanelOtherOptions" runat="server" Visible="false">
            <tr>
                <td class="sub-header sub-header-color">
                    &nbsp;&nbsp;&nbsp;Print Options
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxCampaignSummary" runat="server" Text="Include Campaign Summary"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxVendor" runat="server" Text="Show Vendor Description"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxFunctionComment" runat="server"
                                    Text="Include Function Comment" Width="336px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <asp:Panel ID="pnlOptions" runat="server">
            <tr>
                <td class="sub-header sub-header-color">
                    &nbsp;&nbsp;&nbsp;Print Options
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td style="width: 50px">
                                &nbsp;
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbUsePrintedDate" runat="server"
                                    Text="Use Printed Date" />
                                <asp:Panel ID="pnlDate" runat="server">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date:&nbsp;&nbsp;
                                    <telerik:RadDatePicker ID="RadDatePickerPrintedDate" runat="server" 
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
                                </asp:Panel>
                            </td>
                        </tr>
                        <asp:Panel ID="PnlCheck" runat="server">
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td class="sub-header sub-header-color" colspan="2">
                                <asp:Label   ID="lblEstGroupOptions" runat="server" Text="Estimate Grouping Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbCombineComps" runat="server" Text="Combine Estimate components"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td class="sub-header sub-header-color" colspan="2">
                                <asp:Label   ID="lblFunctionOptions" runat="server" Text="Function Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                <table width="95%">
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbOverride" runat="server" Text="Override product consolidation setting" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionCode" runat="server" Text="Function Code"
                                                GroupName="Function" /><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbConsolidationCode" runat="server"
                                                Text="Consolidation Code" GroupName="Function" /><br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbTotalOnly" runat="server" Text="Total Only"
                                                GroupName="Function" />
                                        </td>
                                        <td align="left" valign="top" style="width: 876px">
                                            <asp:RadioButton ID="rbRate" runat="server" Text="Rate" GroupName="Function" /><br />
                                            <asp:RadioButton ID="rbNone" runat="server" Text="None" GroupName="Function" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td class="sub-header sub-header-color" colspan="2">
                                <asp:Label   ID="lblTaxOptions" runat="server" Text="Tax Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowTax" runat="server" Text="Show Tax Separately" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIndicateTax" runat="server" Text="Indicate Taxable Functions" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblCommMarkup" runat="server" Text="Comm/Markup Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowComm" runat="server" Text="Show Comm/MU Separately"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIndicateCommMU" runat="server"
                                    Text="Indicate Comm/MU Functions" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td class="sub-header sub-header-color" colspan="2">
                                <asp:Label   ID="Label4" runat="server" Text="Contingency Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCont" runat="server" Text="Include Contingency"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbShowCont" runat="server" Text="Show Contingency Separately" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblAddressOptions" runat="server" Text="Address Block Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintClientName" runat="server"
                                    Text="Print Client Name" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintDivisionName" runat="server"
                                    Text="Print Division Name" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbPrintProductName" runat="server"
                                    Text="Print Product Name" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblComment" runat="server" Text="Comment Options:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateComment" runat="server"
                                    Text="Estimate Comment" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateCompComment" runat="server"
                                    Text="Estimate Component Comment" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbQuoteComment" runat="server" Text="Quote Comment"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbRevisionComment" runat="server"
                                    Text="Revision Comment" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbFunctionComment" runat="server"
                                    Text="Function Comment" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSuppliedByNotes" runat="server"
                                    Text="Supplied By Notes" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbDefaultFooterComment" runat="server"
                                    Text="Default Footer Comment" Width="336px" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDefauldFooterComment" SkinID="TextBoxStandard"
                                    runat="server" TextMode="MultiLine" Width="500px" Height="50px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblOther" runat="server" Text="Other:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbHideCompDesc" runat="server" Text="Hide Component Description"
                                    Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbHideRevision" runat="server" Text="Hide Revision Info"
                                    Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbClientReference" runat="server"
                                    Text="Client Reference" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbAEName" runat="server" Text="AE Name"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSalesClass" runat="server" Text="Sales Class"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbJobDueDate" runat="server" Text="Job Due Date"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbAdNumber" runat="server" Text="Ad Number"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEstimateQuantity" runat="server"
                                    Text="Estimate Quantity" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSuppresZero" runat="server" Text="Suppress Zero Functions"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeNonBillable" runat="server"
                                    Text="Include Nonbillable Actuals" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeQtyHrs" runat="server" Text="Include Qty/Hrs"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeRate" runat="server" Text="Include Rate"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbSubtotalsOnly" runat="server" Text="Subtotals Only"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCPU" runat="server" Text="Include Cost Per Unit"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncludeCPM" runat="server" Text="Include Cost Per Thousand"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbExcludeEmpSig" runat="server" Text="Exclude Employee Signature"
                                    Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeEmpTime" runat="server"
                                    Text="Exclude Employee Time Functions" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeVendor" runat="server"
                                    Text="Exclude Vendor Functions" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeIO" runat="server"
                                    Text="Exclude Income Only Functions" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CheckBoxExcludeNonBillableFunctions" runat="server"
                                    Text="Exclude NonBillable Functions" Width="336px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblGroupby" runat="server" Text="Group By:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbNoneGroupby" runat="server"
                                    Text="None" GroupName="FunctionGroupBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionType" runat="server"
                                    Text="Function Type" GroupName="FunctionGroupBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionHeading" runat="server"
                                    Text="Function Heading" GroupName="FunctionGroupBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionHeadingTO" runat="server"
                                    Text="Function Heading Total Only" GroupName="FunctionGroupBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbInsideOutside" runat="server"
                                    Text="Inside/Outside" GroupName="FunctionGroupBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbPhase" runat="server" Text="Phase"
                                    GroupName="FunctionGroupBy" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="lblInsideDesc" runat="server" Text="Inside Desc:"></asp:Label>&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtInsideDesc" runat="server" SkinID="TextBoxStandard"></asp:TextBox><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="lblOutsideDesc" runat="server" Text="Outside Desc:"></asp:Label>
                                <asp:TextBox ID="txtOutsideDesc" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2" class="sub-header sub-header-color">
                                <asp:Label   ID="lblSortBy" runat="server" Text="Sort By:" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50px">
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionCodeSort" runat="server"
                                    Text="Function Code" GroupName="FunctionSortBy" /><br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbFunctionOrderSort" runat="server"
                                    Text="Function Order" GroupName="FunctionSortBy" />
                            </td>
                        </tr>
                        </asp:Panel>
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
                <asp:Label   ID="lbl_msg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
