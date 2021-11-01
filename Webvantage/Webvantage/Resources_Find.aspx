<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Resources_Find.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Resource Finder" Inherits="Webvantage.Resources_Find" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        var grid;
        function GridCreated() {
            grid = this;
        }

        function RowSelected() {
            if (grid.MasterTableView.SelectedRows.length == grid.MasterTableView.Rows.length) {
                setCheckBox(true);
            }
        }

        function RowDeselected() {
            if (grid.MasterTableView.SelectedRows.length < grid.MasterTableView.Rows.length) {
                setCheckBox(false);
            }
        }

        function setCheckBox(toCheck) {
            var checkBoxID = document.getElementById("hf1").value;
            var checkBox = document.getElementById(checkBoxID);
            checkBox.checked = toCheck;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div class="code-description-container">
            <div id="TrResourceTypes" runat="server" class="code-description-label">
                Resource Type:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropResourceType" runat="server" AutoPostBack="true" Width="250">
                </telerik:RadComboBox>
            </div>
        </div>
        <div id="TrAdNumbers" runat="server" class="code-description-container">
            <div class="code-description-label">
                Ad Number:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="DropAdNumbers" runat="server" AutoPostBack="true" Width="250">
                </telerik:RadComboBox>
            </div>
        </div>
        <div id="TrBtnApply" runat="server" style="text-align:center;margin:10px 0px 10px 0px;">
            <asp:Button ID="BtnApply" runat="server" Text="Apply" />
            &nbsp;&nbsp;
            <asp:Button ID="BtnClose" runat="server" Text="Close" />
        </div>
        <ew:CollapsablePanel ID="CollapsablePanelApplyToSelected" runat="server" TitleText="Available Resources"
            Collapsed="true">
            <telerik:RadGrid ID="RadGridResourcesForApplySelected" runat="server" AllowMultiRowSelection="False"
                AllowPaging="False" AllowSorting="True" AutoGenerateColumns="False" EnableAJAX="False"
                EnableOutsideScripts="true" GroupingEnabled="false" ShowFooter="false" Visible="True"
                Width="99%">
                <ClientSettings EnablePostBackOnRowClick="true">
                    <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                </ClientSettings>
                <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                    AllowMultiColumnSorting="true" DataKeyNames="RESOURCE_CODE">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="RESOURCE_CODE" HeaderText="Resource Code" UniqueName="ColRESOURCE_CODE">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RESOURCE_DESC" HeaderText="Description" UniqueName="ColRESOURCE_DESCRIPTION">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="PRIORITY" HeaderText="Priority" UniqueName="ColPRIORITY">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="40px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="40px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LAST_JOB_AND_COMPONENT" HeaderText="Last Job/Comp"
                            UniqueName="ColLAST_JOB_AND_COMPONENT">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="50px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LAST_AD_NUMBER" HeaderText="Last Ad Number" UniqueName="ColLAST_AD_NUMBER">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LAST_DATE" HeaderText="Last Date" UniqueName="ColLAST_DATE"
                            DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LAST_START_TIME" HeaderText="Last Start" UniqueName="ColLAST_START_TIME"
                            DataFormatString="{0:t}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="LAST_END_TIME" HeaderText="Last End" UniqueName="ColLAST_END_TIME"
                            DataFormatString="{0:t}">
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
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelAvailableResources" runat="server" TitleText="Events">
            <telerik:RadGrid ID="RadGridAvailableResources" runat="server" AllowMultiRowSelection="True"
                AllowPaging="False" AllowSorting="true" AutoGenerateColumns="False" EnableAJAX="False"
                EnableOutsideScripts="true" GroupingEnabled="true" ShowFooter="False" Visible="True">
                <ClientSettings>
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />

                </ClientSettings>
                <MasterTableView GroupsDefaultExpanded="true" NoMasterRecordsText="No records found"
                    AllowMultiColumnSorting="true" HierarchyLoadMode="ServerBind" HierarchyDefaultExpanded="False"
                    DataKeyNames="EVENT_ID">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect1">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="10px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10px" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="EVENT_ID" HeaderText="ID" UniqueName="ColTEST"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EVENT_LABEL" HeaderText="Event Description" UniqueName="ColEVENT_LABEL">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="120px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="120px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EVENT_DATE" HeaderText="Event Date" UniqueName="ColEVENT_DATE"
                            DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="START_TIME" HeaderText="Start Time" UniqueName="ColSTART_TIME"
                            DataFormatString="{0:t}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="END_TIME" HeaderText="End Time" UniqueName="ColEND_TIME"
                            DataFormatString="{0:t}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="80px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CURRENT_RESOURCE_CODE" HeaderText="Current<br />Resource"
                            UniqueName="ColCURRENT_RESOURCE_CODE" Display="false">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="20px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn DataField="FIRST_CHOICE" HeaderText="Recommended<br />Resource"
                            UniqueName="ColResources">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="80px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="80px" />
                            <ItemTemplate>
                                <asp:HiddenField ID="HfEVENT_ID" runat="server" Value='<%#Eval("EVENT_ID")%>' />
                                <asp:HiddenField ID="HfFIRST_CHOICE" runat="server" Value='<%#Eval("FIRST_CHOICE")%>' />
                                <asp:TextBox ID="TxtRESOURCE_CODE" runat="server" MaxLength="10" Text='<%# Eval("FIRST_CHOICE") %>'
                                    SkinID="TextBoxCodeSmall" ReadOnly="true" Visible="false"></asp:TextBox>
                                <asp:Label ID="LblRESOURCE_CODE_REC" runat="server" Text='<%# Eval("FIRST_CHOICE") %>'></asp:Label>
                                <telerik:RadComboBox ID="DropResources" runat="server" Visible="false">
                                </telerik:RadComboBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="" HeaderText="&nbsp;" UniqueName="ColResourcesSelect"
                            Visible="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnSelectResource" runat="server" ImageUrl="~/Images/Icons/White/256/truck2.png" CssClass="icon-image"
                                        CommandName="ResourceSelect" CommandArgument='<%#Eval("EVENT_ID")%>' />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
            <asp:HiddenField ID="hf1" runat="server" />
        </ew:CollapsablePanel>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
