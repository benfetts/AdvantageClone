<%@ Page AutoEventWireup="false" Codebehind="Estimating_AddNewComponent.aspx.vb" Inherits="Webvantage.Estimating_AddNewComponent"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="New Estimate Component" %>
    

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    
    
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

        <script type="text/javascript">
                 function FocusTB(tb){
                    var thisTextbox = document.getElementById(tb);
                    thisTextbox.focus() ;
            }
            function clearcomp() {
	            document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
	            document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            }
            function clearjob(){
    	        document.forms[0].<%=Me.TxtJobNum.ClientID %>.value = '';
	            document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
    	        document.forms[0].<%=Me.TxtJobDescription.ClientID %>.value = '';
	            document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            }
        </script>

    </telerik:RadScriptBlock>
    <div class="table-fixes">
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                <td >
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="LblMSG" runat="server" Text="&nbsp;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="PnlAddNewEstimate" runat="server" DefaultButton="BtnCreateEstimateComp"
                        Width="100%">
                        <table border="0" cellpadding="0" cellspacing="0" width="671">
                            <tr>
                                <td align="right" valign="middle" width="145">
                                    <span>
                                        <asp:HyperLink ID="HlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td width="64">
                                    <asp:TextBox ID="TxtClientCode" runat="server"  ReadOnly="true"
                                        MaxLength="6" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td width="6">
                                    &nbsp;
                                </td>
                                <td width="456">
                                    <asp:TextBox ID="TxtClientDescription" runat="server"  ReadOnly="true"
                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle" >
                                    <span>
                                        <asp:HyperLink ID="HlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td >
                                    <asp:TextBox ID="TxtDivisionCode" runat="server"   ReadOnly="true"
                                        MaxLength="6" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td >
                                    &nbsp;
                                </td>
                                <td >
                                    <asp:TextBox ID="TxtDivisionDescription" runat="server"  ReadOnly="true"
                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:HyperLink ID="HlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtProductCode" runat="server"   ReadOnly="true"
                                        MaxLength="6" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtProductDescription" runat="server"  ReadOnly="true" TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TrJob" runat="server">
                                <td align="right" valign="middle" width="145">
                                    <span>
                                        <asp:HyperLink ID="HlJob" runat="server" href="" TabIndex="-1">Job:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td width="64">
                                    <asp:TextBox ID="TxtJobNum" runat="server" 
                                        MaxLength="6" TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td width="6">
                                    &nbsp;
                                </td>
                                <td width="456">
                                    <asp:TextBox ID="TxtJobDescription" runat="server"  ReadOnly="true"
                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TrComponent" runat="server">
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:HyperLink ID="HlComponent" runat="server" href="" TabIndex="-1">Component:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtJobCompNum" runat="server" 
                                        MaxLength="3" TabIndex="5" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtJobCompDescription" runat="server"  ReadOnly="true"
                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="TrCampaign" runat="server">
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:HyperLink ID="hlCampaign" runat="server" href="" TabIndex="-1">Campaign:</asp:HyperLink>&nbsp;&nbsp;</span>
                                </td>
                                <td width="64">
                                    <asp:TextBox ID="TxtCampaign" runat="server"
                                        MaxLength="10" TabIndex="6" Text="" SkinID="TextBoxCodeSmall" AutoPostBack="True"></asp:TextBox>
                                    <asp:HiddenField runat="server" ID="HiddenFieldCampaignID" />
                                </td>
                                <td width="6">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtCampaignDescription" runat="server"  ReadOnly="true"
                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:HyperLink ID="HlSalesClass" runat="server" href="" TabIndex="-1">Sales Class:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtSalesClass" runat="server" ReadOnly="true" 
                                        MaxLength="10" TabIndex="6" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSalesClassDescription" runat="server" 
                                        ReadOnly="true" TabIndex="-1" Text="" Visible="false" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:Label   ID="lblEstimate" runat="server" Text="Est Number:"></asp:Label></span>&nbsp;&nbsp;</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEstimate" runat="server" ReadOnly="true" 
                                        MaxLength="60" TabIndex="6" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                            
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:Label   ID="lblEstimateDescription" runat="server" Text="Est Desc:"></asp:Label></span>&nbsp;&nbsp;</td>
                                <td colspan="3">
                                    <asp:TextBox ID="TxtEstimateDescription" runat="server" ReadOnly="true" 
                                        MaxLength="60" TabIndex="6" Text="" Width="410px"></asp:TextBox>
                                </td>
                            
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    <span>
                                        <asp:Label   ID="lblEstimateCompDescription" runat="server" Text="Est Comp Desc:"></asp:Label></span>&nbsp;&nbsp;</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtEstimateCompDescription" runat="server" CssClass="RequiredInput" 
                                        MaxLength="60" TabIndex="6" Text="" Width="410px"></asp:TextBox>
                                </td>
                            
                            </tr>
                            <tr style="display: none;">
                                <td align="right" valign="middle">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImgBtnGetPresetData_AddNew" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh descriptions and get default dates" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;                                
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td align="right" valign="middle">
                                    <span>Start Date:</span>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtStartDate" runat="server"  TabIndex="-1"
                                        Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Literal ID="LitStartCal" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td align="right" valign="middle">
                                    <span>Due Date:</span>&nbsp;&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtDueDate" runat="server"  TabIndex="-1" Text=""
                                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Literal ID="LitDueCal" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td valign="middle">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="3" valign="middle">
                                    <asp:Button ID="BtnCreateEstimateComp" runat="server" CausesValidation="False" Width="140"
                                        TabIndex="7" Text="Create Component" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" 
                                        TabIndex="8" Text="Cancel" /><br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="PnlDontAddNewSchedule" runat="server">
                        &nbsp;
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
                    <ew:CollapsablePanel ID="CollapsablePanelHeader" runat="server"
                        TitleText="Copy Source"  Collapsed="true">
                        <table width="100%">
                            <tr>
                                <td style="height: 23px">
                                <br />
                            
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 619px">
                                    <asp:Panel ID="PnlCopySource" runat="server" DefaultButton="BtnCreateEstimateComp"
                                        Width="95%">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td align="right" valign="middle" width="145">
                                                    <span>
                                                        <asp:HyperLink ID="HlClientSource" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                                <td width="64">
                                                    <asp:TextBox ID="TxtClientSource" runat="server" 
                                                        MaxLength="6" TabIndex="9" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                </td>
                                                <td width="6">
                                                    &nbsp;
                                                </td>
                                                <td width="456">
                                                    <asp:TextBox ID="TxtClientSourceDesc" runat="server"  ReadOnly="true"
                                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="middle" >
                                                    <span>
                                                        <asp:HyperLink ID="HlDivisionSource" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                                <td >
                                                    <asp:TextBox ID="TxtDivisionSource" runat="server" 
                                                        MaxLength="6" TabIndex="10" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                </td>
                                                <td >
                                                    &nbsp;
                                                </td>
                                                <td >
                                                    <asp:TextBox ID="TxtDivisionSourceDesc" runat="server"  ReadOnly="true"
                                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="middle">
                                                    <span>
                                                        <asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="TxtProductSource" runat="server" 
                                                        MaxLength="6" TabIndex="11" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtProductSourceDesc" runat="server"  ReadOnly="true" TabIndex="-1"
                                                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="middle" width="145">
                                                    <span>
                                                        <asp:HyperLink ID="HlJobType" runat="server" href="" TabIndex="-1">Job Type:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                                <td width="64">
                                                    <asp:TextBox ID="TxtJobTypeSource" runat="server" 
                                                        MaxLength="6" TabIndex="12" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                </td>
                                                <td width="6">
                                                    &nbsp;
                                                </td>
                                                <td width="456">
                                                    <asp:TextBox ID="TxtJobTypeSourceDesc" runat="server"  ReadOnly="true"
                                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" valign="middle">
                                                    <span>
                                                        <asp:HyperLink ID="HlEstimateSource" runat="server" href="" TabIndex="-1">Estimate:</asp:HyperLink></span>&nbsp;&nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="TxtEstimateSource" runat="server" 
                                                        MaxLength="6" TabIndex="13" Text="" SkinID="TextBoxCodeSmall" CssClass="RequiredInput"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TxtEstimateSourceDesc" runat="server"  ReadOnly="true"
                                                        TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <%--<td align="right" valign="middle">&nbsp;</td>--%>
                                                <td align="right" valign="middle" colspan="2">
                                                    <asp:CheckBox ID="cbRecalculate" runat="server" Text="Recalculate?" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>         
                                            <tr>
                                                <td align="right" valign="middle">
                                                    &nbsp;
                                                </td>
                                                <td align="left" colspan="3" valign="middle"><br />
                                                    <asp:Button ID="btnCompQuote" runat="server" CausesValidation="False" Width="160"
                                                        TabIndex="14" Text="Get Components/Quotes" />
                                                    &nbsp;&nbsp;<asp:Button ID="btnCopyComponent" runat="server" CausesValidation="False" Width="160"
                                                        TabIndex="15" Text="Copy Component" />
                                                        <br />
                                                        <br />
                                                </td>
                                            </tr>                                                         
                                        </table>
                                    </asp:Panel>                
                                </td>
                                <td valign="top" >
                                    <asp:Panel ID="pnlEstimateData" runat="server">
                                        <telerik:RadGrid ID="RadGridEstCompCopy" runat="server" AllowMultiRowSelection="True" AllowSorting="False"
                                                AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" 
                                                Width="75%" Title="Components/Quotes">
                                                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                                <ClientSettings  EnablePostBackOnRowClick="False">
                                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="ESTIMATE_NUMBER,EST_COMPONENT_NBR">
                                                    <Columns>
                                                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                            <HeaderStyle HorizontalAlign="center" />
                                                            <ItemStyle HorizontalAlign="center" />
                                                        </telerik:GridClientSelectColumn>
                                                        <telerik:GridBoundColumn DataField="EST_QUOTE_NBR" HeaderText="Quote" UniqueName="colEST_QUOTE_NBR">
                                                            <HeaderStyle HorizontalAlign="left" />
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="EST_QUOTE_DESC" HeaderText="Description" UniqueName="colEST_QUOTE_DESC">
                                                            <HeaderStyle HorizontalAlign="left" />
                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                        </telerik:GridBoundColumn> 
                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="colComp" Visible="false">                                                        
                                                            <ItemTemplate>
                                                                <asp:HiddenField id="hfEstimateComp" runat="server" Value='<%# Eval("EST_COMPONENT_NBR") %>'/>
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
                                    </asp:Panel>
                                </td>
                            </tr>                        
                        </table>                    
                    </ew:CollapsablePanel>    
                </td>
            
            </tr>
        </table>
    </div>
    
</asp:Content>
