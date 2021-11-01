<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_List.aspx.vb" Inherits="Webvantage.Alert_ListPage" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">

            function RadToolbarAlertListOnClientButtonClicking(sender, args) {

                var comandName = args.get_item().get_commandName();

            }

        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div >
        <telerik:RadToolBar ID="RadToolbarAlertList" runat="server" AutoPostBack="true"
            OnClientButtonClicking="RadToolbarAlertListOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" CommandName="NewAlert" Value="NewAlert" ToolTip="New Alert" Text="New Alert" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" CommandName="NewAssignment" Value="NewAssignment" ToolTip="New Assignment" Text="New Assignment" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonRadComboBoxGroupBy">
                    <ItemTemplate>
                        &nbsp;&nbsp;Group/Filter:
                        <telerik:RadComboBox ID="RadComboBoxGroupBy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadComboBoxGroupBy_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="Level" Value="17" />
                                <telerik:RadComboBoxItem Text="None" Value="0" />
                                <telerik:RadComboBoxItem Text="Client" Value="3" />
                                <telerik:RadComboBoxItem Text="Division" Value="4" />
                                <telerik:RadComboBoxItem Text="Product" Value="5" />
                                <telerik:RadComboBoxItem Text="Category" Value="1" />
                                <telerik:RadComboBoxItem Text="State" Value="13" />
                                <telerik:RadComboBoxItem Text="Due Date" Value="14" />
                                <telerik:RadComboBoxItem Text="Priority" Value="15" />
                            </Items>
                        </telerik:RadComboBox>
                        &nbsp; &nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonRadComboBoxShow">
                    <ItemTemplate>
                        &nbsp;&nbsp;Show:
                       <telerik:RadComboBox ID="RadComboBoxShow" runat="server" AutoPostBack="true" Width="200" OnSelectedIndexChanged="RadComboBoxShow_SelectedIndexChanged">
                           <Items>
                               <telerik:RadComboBoxItem Text="All Alerts & Assignments" Value="0" />
                               <telerik:RadComboBoxItem Text="All Alerts" Value="1" />
                               <telerik:RadComboBoxItem Text="My Assignments" Value="2" />
                               <telerik:RadComboBoxItem Text="All Assignments" Value="3" />
                               <telerik:RadComboBoxItem Text="Unassigned" Value="4" />
                           </Items>
                       </telerik:RadComboBox>
                        &nbsp; &nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonCheckBoxIncludeCompletedAssignments">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxIncludeCompletedAssignments" runat="server" AutoPostBack="True" Text="Incl. Completed" OnCheckedChanged="ChkIncludeCompletedAssignments_CheckedChanged" />
                        &nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" CommandName="Bookmark" Value="Bookmark" ToolTip="Bookmark" Text="" Visible="false" />
           </Items>
        </telerik:RadToolBar>
    </div>
    <div ></div>
    <telerik:RadGrid ID="RadGridAlertList" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True">
        <MasterTableView DataKeyNames="AlertID, IsAssignment, AttachmentCount" NoDetailRecordsText="No Alerts">
            <Columns>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnAlertID" DataField="AlertID" HeaderText="Alert ID" Visible="False">
                    <HeaderStyle Width="20" HorizontalAlign="Center" />
                    <ItemStyle Width="20" HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" Groupable="False" HeaderAbbr="FIXED" SortExpression="AttachmentCount" UniqueName="GridTemplateColumnAttachmentCount">
                    <HeaderStyle CssClass="radgrid-icon-column" />
                    <ItemStyle CssClass="radgrid-icon-column" />
                    <FooterStyle CssClass="radgrid-icon-column" />
                    <ItemTemplate>
                        <div id="DivAttachments" runat="server" class="icon-background background-color-sidebar">
                            <asp:Image ID="ImageAttachmentCount" runat="server" ImageUrl="Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter" UniqueName="GridTemplateColumnSubject" DataField="Subject" HeaderText="Subject" SortExpression="Subject">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonSubject" runat="server" Text='<%# Eval("Subject")%>' CommandName="OpenAlert" CommandArgument='<%# Eval("AlertID")%>'></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnBy" DataField="LastUpdatedBy" HeaderText="By" SortExpression="LastUpdatedBy">
                </telerik:GridBoundColumn>
                <telerik:GridDateTimeColumn FilterControlAltText="Filter" UniqueName="GridDateTimeColumnLastUpdated" DataField="LastUpdated" HeaderText="Last Updated">
                    <HeaderStyle Width="140" HorizontalAlign="right" />
                    <ItemStyle Width="140" HorizontalAlign="right" />
                </telerik:GridDateTimeColumn>
                <telerik:GridDateTimeColumn FilterControlAltText="Filter" UniqueName="GridDateTimeColumnDue" DataField="Due" HeaderText="Due" DataFormatString="{0:d}" SortExpression="Due">
                    <HeaderStyle HorizontalAlign="right" />
                    <ItemStyle HorizontalAlign="right" />
                </telerik:GridDateTimeColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnState" DataField="State" HeaderText="State" SortExpression="State">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnPriority" DataField="PriorityAbbreviation" HeaderText="Priority" SortExpression="">
                    <HeaderStyle Width="30" HorizontalAlign="Center" />
                    <ItemStyle Width="30" HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter" UniqueName="GridTemplateColumnAssignedTo" DataField="CurrentlyAssignedTo" HeaderText="Assigned To" SortExpression="CurrentlyAssignedTo">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonAssignedTo" runat="server" Text='<%# Eval("CurrentlyAssignedTo")%>' CommandName="ReAssign" CommandArgument='<%# Eval("AlertID")%>'></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnType" DataField="Type" HeaderText="Type" SortExpression="">
                    <HeaderStyle Width="30" HorizontalAlign="Center" />
                    <ItemStyle Width="30" HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnCategory" DataField="Category" HeaderText="Category" SortExpression="Category">
                    <HeaderStyle Width="30" HorizontalAlign="Center" />
                    <ItemStyle Width="30" HorizontalAlign="Center" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnID" DataField="ID" HeaderText="ID" SortExpression="ID">
                    <HeaderStyle Width="10" HorizontalAlign="Right" />
                    <ItemStyle Width="10" HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
            </Columns>
            <DetailTables>
                <telerik:GridTableView Name="Comments" Caption="<div style='text-align:left !important; margin-top:12px !important;'>Comments</div>" HierarchyLoadMode="ServerOnDemand" NoDetailRecordsText="No Comments" AllowSorting="True">
                    <Columns>
                        <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnComment" DataField="Comment" HeaderText="Comment">
                        </telerik:GridBoundColumn>
                        <telerik:GridDateTimeColumn FilterControlAltText="Filter" UniqueName="GridDateTimeColumnGeneratedBy" DataField="GeneratedBy" HeaderText="Generated By">
                            <HeaderStyle Width="140" HorizontalAlign="right" />
                            <ItemStyle Width="140" HorizontalAlign="right" />
                        </telerik:GridDateTimeColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnGeneratedDate" DataField="GeneratedDate" HeaderText="Generated Date">
                            <HeaderStyle Width="140" HorizontalAlign="right" />
                            <ItemStyle Width="140" HorizontalAlign="right" />
                        </telerik:GridBoundColumn>
                    </Columns>
                </telerik:GridTableView>
                <telerik:GridTableView Name="Recipients" Caption="<div style='text-align:left !important; margin-top:12px !important;'>Recipients</div>" AutoGenerateColumns="False"
                    HierarchyLoadMode="ServerOnDemand" NoDetailRecordsText="No Recipients" AllowSorting="True">
                    <Columns>
                        <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnName" DataField="EmployeeName" HeaderText="Name">
                        </telerik:GridBoundColumn>
                    </Columns>
                </telerik:GridTableView>
                <telerik:GridTableView Name="Attachments" Caption="<div style='text-align:left !important; margin-top:12px !important;'>Attachments</div>" AutoGenerateColumns="False" HierarchyLoadMode="ServerOnDemand" NoDetailRecordsText="No Attachments" AllowSorting="True">
                    <Columns>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter" UniqueName="GridTemplateColumnFileName" DataField="RealFileName" HeaderText="Filename">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonAssignedTo" runat="server" Text='<%# Eval("RealFileName")%>' CommandName="Download" CommandArgument='<%# Eval("DocumentID")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnSize" DataField="FileSize" HeaderText="Size">
                            <HeaderStyle Width="55" HorizontalAlign="right" />
                            <ItemStyle Width="55" HorizontalAlign="right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn FilterControlAltText="Filter" UniqueName="GridBoundColumnAddedBy" DataField="UserName" HeaderText="Added By">
                            <HeaderStyle Width="140" HorizontalAlign="right" />
                            <ItemStyle Width="140" HorizontalAlign="right" />
                        </telerik:GridBoundColumn>
                        <telerik:GridDateTimeColumn FilterControlAltText="Filter" UniqueName="GridDateTimeColumnAdded" DataField="AddedDate" HeaderText="Added">
                            <HeaderStyle Width="140" HorizontalAlign="right" />
                            <ItemStyle Width="140" HorizontalAlign="right" />
                        </telerik:GridDateTimeColumn>
                    </Columns>
                </telerik:GridTableView>
            </DetailTables>
        </MasterTableView>
    </telerik:RadGrid>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
</asp:Content>
