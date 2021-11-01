<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="JobForecast_AddJobComponents.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Add Job Forecast Job Components" Inherits="Webvantage.JobForecast_AddJobComponents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
        <script type="text/javascript">
            function RadListBoxOnClientDeleting(sender, args) {
                ////args.set_cancel(!confirm('<%= ConfirmDeleteMessage()%>'));
                radToolBarConfirm(sender, args, "<%= ConfirmDeleteMessage()%>");
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            width="100%">
            <tr >
                <td align="left"  valign="middle"
                    colspan="2">
                    <%--&nbsp;&nbsp;Job Forecast Job Components--%>
                </td>
            </tr>
            <tr>
                <td runat="server" id="TdRadToolBarJobForecastJobComponent" align="left" valign="top"
                    colspan="2">
                    <telerik:RadToolBar ID="RadToolBarJobForecastJobComponent"  runat="server" AutoPostBack="true" Width="100%">
                        <Items>
                            <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true"/>
                            <telerik:RadToolBarButton ID="RadToolBarButtonDone" runat="server"
                                Text="Done" Value="Done" ToolTip="Finished add\remove job components" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true"/>
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
            <tr>
                <td width="1%">
                    &nbsp;
                </td>
                <td>
                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td align="left" valign="bottom" width="20%">
                               Office
                            </td>
                            <td align="left" valign="bottom" width="20%">
                               Client
                            </td>
                            <td align="left" valign="bottom" width="20%">
                               Division
                            </td>
                            <td align="left" valign="bottom" width="20%">
                               Product
                            </td>
                            <td align="left" valign="bottom" width="20%">
                               A/E
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="bottom">
                                <telerik:RadComboBox ID="DropDownListOffice" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom">
                                <telerik:RadComboBox ID="DropDownListClient" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom">
                                <telerik:RadComboBox ID="DropDownListDivision" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom">
                                <telerik:RadComboBox ID="DropDownListProduct" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                            <td align="left" valign="bottom">
                                <telerik:RadComboBox ID="DropDownListAccountExecutive" runat="server" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard"
                                    DataTextField="Name" DataValueField="Code" >
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                    <table width="99%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td align="left" valign="bottom" width="50%">
                               Available Job Components
                            </td>
                            <td align="left" valign="bottom" width="50%">
                               Current Job Components
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxAvailableJobComponents" runat="server" Width="100%"
                                    AutoPostBack="false" Height="425" SelectionMode="Multiple" AllowTransfer="true"
                                    TransferToID="RadListBoxCurrentJobComponents" AutoPostBackOnTransfer="true"
                                    AllowReorder="False" EnableDragAndDrop="false" DataValueField="ID" DataTextField="Description">
                                    <ButtonSettings TransferButtons="TransferAllFrom,TransferFrom" AreaWidth="40px" />
                                </telerik:RadListBox>
                            </td>
                            <td align="left" valign="top">
                                <telerik:RadListBox ID="RadListBoxCurrentJobComponents" runat="server" Width="100%"
                                    AutoPostBack="false" Height="425" SelectionMode="Multiple" AllowReorder="false"
                                    AutoPostBackOnTransfer="false" AutoPostBackOnDelete="true" EnableDragAndDrop="false" DataValueField="ID" DataTextField="Description"
                                    AllowDelete="true" AllowTransfer="false" OnClientDeleting="RadListBoxOnClientDeleting">
                                    <ButtonSettings ShowDelete="true" ShowTransfer="false" ShowTransferAll="false" AreaWidth="40px"  />
                                  </telerik:RadListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <asp:Label ID="LabelAddRemoveJobsNote" runat="server" Text="* Adding and removing job components applies to all revisions on the forecast." Visible="false" />
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
