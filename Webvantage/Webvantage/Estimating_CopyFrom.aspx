<%@ Page AutoEventWireup="false" CodeBehind="Estimating_CopyFrom.aspx.vb" Inherits="Webvantage.Estimating_CopyFrom"
    MasterPageFile="~/ChildPage.Master" Language="vb" Title="Copy from Quote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script type="text/javascript" src="Jscripts/EstimatingQuote.js"></script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript">
                function RadToolBarQuoteOnClientButtonClicking(sender, args) {
                    var comandName = args.get_item().get_commandName();                    
                    if (comandName == "Add") {
                        //////args.set_cancel(!confirm('Are you sure you want to clear all assignments?'));
                        var a = checkvalue('<%= Me.hfApproved.ClientID  %>');
                        if (a == '1') {
                            ////args.set_cancel(!confirm('This quote is approved. Are you sure you want to save the changes?'));
                            radToolBarConfirm(sender, args, "This quote is approved. Are you sure you want to save the changes?");
                            //return confirmSave2();
                        } else {
                            //realPostBack("Save", "Save");
                            return false;
                        }
                    }
                }
            </script>
        </telerik:RadScriptBlock>
    <telerik:RadSplitter ID="RadSplitterHeader" runat="server" Height="1000px"
        Orientation="Horizontal" Width="100%">
        <telerik:RadPane ID="RadPaneTop" runat="server" Height="400px" 
            Scrolling="none">
            <telerik:RadToolBar ID="RadToolBarQuote" runat="server" AutoPostBack="true" Width="100%" OnClientButtonClicking="RadToolBarQuoteOnClientButtonClicking" >
                <Items>
                    <telerik:RadToolBarButton IsSeparator="True" Value="Sep1" />
                    <telerik:RadToolBarButton Value="Add" ToolTip="Add Functions" SkinID="RadToolBarButtonAdd" TabIndex="1000" CommandName="Add" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" TabIndex="1001" />
                    <telerik:RadToolBarButton IsSeparator="True" Value="Sep2" />
                </Items>
            </telerik:RadToolBar>  
            <div>&nbsp;</div>
            <div>
                <asp:Label ID="lblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
                <asp:HiddenField ID="hfApproved" runat="server" />
            </div>
            <div style="display: inline-block;" id="divCDP" runat="server">
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlClient" runat="server" href="">Client:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtClientCode" runat="server" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlDivision" runat="server" href="">Division:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtDivisionCode" runat="server" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlProduct" runat="server" href="">Product:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtProductCode" runat="server" TabIndex="3" Text="" SkinID="TextBoxCodeSmall"
                            MaxLength="6" ></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                         &nbsp;
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
            </div>
            <div style="display: inline-block;">
                <div class="code-description-container">
                    <div class="code-description-label">
                       <asp:HyperLink ID="HlEstimate" runat="server" href="">Estimate:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimate" runat="server" CssClass="RequiredInput" TabIndex="3"
                            Text="" SkinID="TextBoxCodeSmall" ></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlEstimateComponent" runat="server" href="">Component:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtEstimateComponent" runat="server" CssClass="RequiredInput" TabIndex="4"
                            Text="" SkinID="TextBoxCodeSmall" ></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtEstimateComponentDescription" runat="server" TabIndex="-1" Text=""
                            SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:HyperLink ID="HlQuote" runat="server" href="">Quote:</asp:HyperLink>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TxtQuote" runat="server" CssClass="RequiredInput" TabIndex="4" Text=""
                             SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TxtQuoteDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        <asp:CheckBox ID="cbRecalculate" runat="server" Text="Recalculate?"  />
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        &nbsp;
                    </div>
                    <div class="code-description-code">
                        <asp:CheckBox ID="CheckBoxIncludeQuoteComments" runat="server" Text="Include Quote Comments"  />
                    </div>
                    <div class="code-description-description">
                        &nbsp;
                    </div>
                </div>
            </div>
            <%--<table border="0" cellpadding="0" cellspacing="0" width="100%">                
                <tr>
                    <td align="right" valign="top" width="50%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        
                                    </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="1" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        </span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="1" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        </span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="" runat="server" MaxLength="6" TabIndex="2" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top" width="50%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" TabIndex="3"
                                        Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="" runat="server" CssClass="RequiredInput" TabIndex="4"
                                        Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="" runat="server" TabIndex="-1" Text=""
                                        SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        </span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    &nbsp;
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    &nbsp;
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" width="23%">
                                    <span>
                                        <asp:HyperLink ID="HlJob" runat="server" Visible="false" href="">Job:</asp:HyperLink></span>
                                </td>
                                <td width="2%">
                                    &nbsp;
                                </td>
                                <td width="75%">
                                    <asp:TextBox ID="TxtJobNum" runat="server" CssClass="RequiredInput" MaxLength="6"
                                        TabIndex="3" Text="" SkinID="TextBoxCodeSmall" Visible="false"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:HyperLink ID="HlComponent" runat="server" Visible="false" href="">Component:</asp:HyperLink></span>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtJobCompNum" runat="server" CssClass="RequiredInput" MaxLength="6"
                                        TabIndex="4" Text="" SkinID="TextBoxCodeSmall" Visible="false"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <br />
                        <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" />
                        &nbsp;&nbsp;
                        <asp:Button ID="BtnCopy" runat="server" Text="Add Functions" CommandName="AddFunctions" />
                    </td>
                </tr>
            </table>--%>
        </telerik:RadPane>
        <telerik:RadSplitBar ID="RadSplitbarTopBottom" runat="server" CollapseMode="Forward" />
        <telerik:RadPane ID="RadPaneBottom" runat="server" Height="" Scrolling="Y">
            <telerik:RadGrid ID="RadGridCopyFromQuotes" runat="server" AllowMultiRowSelection="True"
                AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                Width="98%">
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings EnablePostBackOnRowClick="False">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                </ClientSettings>
                <MasterTableView DataKeyNames="FNC_CODE">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Function Code" UniqueName="colFNC_CODE">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function Description"
                            UniqueName="colFNC_DESC">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EST_FNC_COMMENT" HeaderText="Detail Comments"
                            UniqueName="colEST_FNC_COMMENT">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="EST_REV_SUP_BY_CDE" HeaderText="Supplied By"
                            UniqueName="colEST_REV_SUP_BY_CDE">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtEST_REV_SUP_BY_CDE" runat="server" 
                                    MaxLength="6" Text='<%#Eval("EST_REV_SUP_BY_CDE") %>' SkinID="TextBoxCodeSmall"></asp:TextBox>
                                <asp:HiddenField ID="HFSuppliedByNotes" runat="server" Value='<%#Eval("EST_REV_SUP_BY_NTE") %>' />
                                <asp:HiddenField ID="HFFncComment" runat="server" Value='<%#Eval("EST_FNC_COMMENT") %>' />
                                <asp:HiddenField ID="HFSeqNum" runat="server" Value='<%#Eval("SEQ_NBR") %>' />
                                <asp:HiddenField ID="HFFncType" runat="server" Value='<%#Eval("EST_FNC_TYPE") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="EST_REV_QUANTITY" HeaderText="Quantity/Hours"
                            UniqueName="colEST_REV_QUANTITY">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtEST_REV_QUANTITY" runat="server"  SkinID="TextBoxStandard"
                                    MaxLength="17" Text='<%#Eval("EST_REV_QUANTITY") %>' Width="100px" Style="text-align: right;"></asp:TextBox>
                                <asp:HiddenField ID="HFRate" runat="server" Value='<%#Eval("EST_REV_RATE") %>' />
                                <asp:HiddenField ID="HFTaxCode" runat="server" Value='<%#Eval("TAX_CODE") %>' />
                                <asp:HiddenField ID="HFTaxStatePct" runat="server" Value='<%#Eval("TAX_STATE_PCT") %>' />
                                <asp:HiddenField ID="HFTaxCountyPct" runat="server" Value='<%#Eval("TAX_COUNTY_PCT") %>' />
                                <asp:HiddenField ID="HFTaxCityPct" runat="server" Value='<%#Eval("TAX_CITY_PCT") %>' />
                                <asp:HiddenField ID="HFTaxComm" runat="server" Value='<%#Eval("TAX_COMM") %>' />
                                <asp:HiddenField ID="HFTaxCommOnly" runat="server" Value='<%#Eval("TAX_COMM_ONLY") %>' />
                                <asp:HiddenField ID="HFTaxResale" runat="server" Value='<%#Eval("TAX_RESALE") %>' />
                                <asp:HiddenField ID="HFNonResaleTax" runat="server" Value='<%#Eval("EXT_NONRESALE_TAX") %>' />
                                <asp:HiddenField ID="HFExtStateResale" runat="server" Value='<%#Eval("EXT_STATE_RESALE") %>' />
                                <asp:HiddenField ID="HFExtCountyResale" runat="server" Value='<%#Eval("EXT_COUNTY_RESALE") %>' />
                                <asp:HiddenField ID="HFExtCityResale" runat="server" Value='<%#Eval("EXT_CITY_RESALE") %>' />
                                <asp:HiddenField ID="HFCPMFlag" runat="server" Value='<%#Eval("EST_CPM_FLAG") %>' />
                                <asp:HiddenField ID="HFCommFlag" runat="server" Value='<%#Eval("EST_COMM_FLAG") %>' />
                                <asp:HiddenField ID="HFTaxFlag" runat="server" Value='<%#Eval("EST_TAX_FLAG") %>' />
                                <asp:HiddenField ID="HFNonbillFlag" runat="server" Value='<%#Eval("EST_NONBILL_FLAG") %>' />
                                <asp:HiddenField ID="HFFeeTime" runat="server" Value='<%#Eval("FEE_TIME") %>' />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="EST_REV_EXT_AMT" HeaderText="Amount" UniqueName="colEST_REV_EXT_AMT">
                            <HeaderStyle HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtEST_REV_EXT_AMT" runat="server"  SkinID="TextBoxStandard"
                                    MaxLength="17" Text='<%#Eval("EST_REV_EXT_AMT") %>' Width="100px" Style="text-align: right;"></asp:TextBox>
                                <asp:HiddenField ID="HFMarkupPct" runat="server" Value='<%#Eval("EST_REV_COMM_PCT") %>' />
                                <asp:HiddenField ID="HFMarkupAmt" runat="server" Value='<%#Eval("EXT_MARKUP_AMT") %>' />
                                <asp:HiddenField ID="HFLineTotal" runat="server" Value='<%#Eval("LINE_TOTAL") %>' />
                                <asp:HiddenField ID="HFContPct" runat="server" Value='<%#Eval("EST_REV_CONT_PCT") %>' />
                                <asp:HiddenField ID="HFContAmt" runat="server" Value='<%#Eval("EXT_CONTINGENCY") %>' />
                                <asp:HiddenField ID="HFCPU" runat="server" Value='<%#Eval("INCL_CPU") %>' />
                                <asp:HiddenField ID="HFMuCont" runat="server" Value='<%#Eval("EXT_MU_CONT") %>' />
                                <asp:HiddenField ID="HFExtStateCont" runat="server" Value='<%#Eval("EXT_STATE_CONT") %>' />
                                <asp:HiddenField ID="HFExtCountyCont" runat="server" Value='<%#Eval("EXT_COUNTY_CONT") %>' />
                                <asp:HiddenField ID="HFExtCityCont" runat="server" Value='<%#Eval("EXT_CITY_CONT") %>' />
                                <asp:HiddenField ID="HFNRCont" runat="server" Value='<%#Eval("EXT_NR_CONT") %>' />
                                <asp:HiddenField ID="HFLineTotalCont" runat="server" Value='<%#Eval("LINE_TOTAL_CONT") %>' />
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
        </telerik:RadPane>
    </telerik:RadSplitter>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
