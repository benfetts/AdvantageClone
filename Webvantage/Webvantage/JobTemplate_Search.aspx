<%@ Page Title="Find Job Jacket" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobTemplate_Search.aspx.vb" Inherits="Webvantage.JobTemplate_Search" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            $(document).ready(function () {
                var jobNumberTextBox = $("#<%=txtJob.ClientID %>");
                var jobComponentNumberTextBox = $("#<%=txtComponent.ClientID %>");
                if (jobNumberTextBox && jobComponentNumberTextBox) {
                    jobNumberTextBox.focus();
                }
            }); // end of document.ready
        </script>   
    </telerik:RadScriptBlock>
    <div >
        <telerik:RadToolBar ID="RadToolbarJobSearch" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSearch" SkinID="RadToolBarButtonFind"
                    ToolTip="Search" Value="Search" CommandName="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNew" SkinID="RadToolBarButtonNew" ToolTip="New"
                    Value="New" CommandName="New" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonClear" SkinID="RadToolBarButtonClear" ToolTip="Clear"
                    Value="Clear" CommandName="Clear" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarDropDown Text="Print/Send">
                    <Buttons>
                        <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUpdateAE" Text="Update Account Executive" Value="UpdateAE" Enabled="True" ToolTip="Update Account Executive for Jobs" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUpdateAlertGroup" Text="Update Alert Group" Value="UpdateAlertGroup" Enabled="True" ToolTip="Update Alert Group for Jobs" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>
    <div class="wrapper">
        <div id="DivFilter" runat="server" class="two-col-leftcolumn">
            <div class="" style="">
                <div class="filter-card">
                    <div class="card-content" style="margin-bottom: 20px;">
                        <asp:Panel ID="PnlSearch" runat="server" DefaultButton="BtnSearch">
                            <div>
                                <div>
                                    <div id="TrOffice" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlOffice" runat="server" href="" TabIndex="-1">Office:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtOffice" runat="server" SkinID="TextBoxCodeLarge" MaxLength="4"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrClient" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1"><span>Client:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtClient" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrDivision" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1"><span>Division:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtDivision" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrProduct" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1"><span>Product:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtProduct" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrSalesClass" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlSalesClass" runat="server" href="" TabIndex="-1"><span>Sales Class:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtSalesClass" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrCampaign" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlCampaign" runat="server" href="" TabIndex="-1"><span>Campaign:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtCampaign" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                            <asp:HiddenField ID="hfCampaignID" runat="server" />
                                        </div>
                                    </div>
                                    <div id="TrJob" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlJob" runat="server" href="" TabIndex="-1"><span>Job:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtJob" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrComponent" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlComponent" runat="server" href="" TabIndex="-1"><span>Component:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtComponent" runat="server" SkinID="TextBoxCodeLarge" MaxLength="3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrAE" runat="server">
                                        <div>
                                            <asp:HyperLink ID="hlAE" runat="server" href="" TabIndex="-1"><span>AE:</span></asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="txtAE" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="TrClosed" runat="server">
                                        <div>
                                            <asp:CheckBox ID="cbClosedJobs" runat="server" Text='Show Closed/Archived Jobs?'
                                                AutoPostBack="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="display: none;">
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" Visible="true" TabIndex="-1" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <div id="DivGrid" runat="server" class="two-col-rightcolumn">
            <telerik:RadGrid ID="RadGridJobTemplateSearch" runat="server" AllowPaging="True" ShowFooter="true"
                AllowSorting="False" AutoGenerateColumns="False" GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                PageSize="15" EnableEmbeddedSkins="True" AllowMultiRowEdit="False" AllowMultiRowSelection="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                <ClientSettings AllowColumnsReorder="False">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                </ClientSettings>
                <GroupingSettings GroupByFieldsSeparator=" " />
                <MasterTableView HorizontalAlign="Left" DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColClientSelect">
                        </telerik:GridClientSelectColumn>
                        <telerik:GridTemplateColumn>
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="butDetail" runat="server" CommandName="Detail" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPrint">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="18px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="18px" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImgBtnPrint" runat="server" CommandName="Print" SkinID="ImageButtonPrintWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job" SortExpression="JOB_NUMBER">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobNum" runat="server" Text='<%#Eval("JOB_NUMBER").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Job Description" SortExpression="JOB_DESC">
                            <ItemTemplate>
                                <asp:Label ID="lblJobDesc" runat="server" Text='<%#Eval("JOB_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Component" SortExpression="JOB_COMPONENT_NBR">
                            <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" Width="70" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Component Description" SortExpression="JOB_COMP_DESC">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblJobCompDesc" runat="server" Text='<%#Eval("JOB_COMP_DESC").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="JOB_COMP_BUDGET_AM" HeaderText="Budget" UniqueName="Budget" Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                            <HeaderStyle HorizontalAlign="right" />
                            <ItemStyle HorizontalAlign="right" VerticalAlign="middle" />
                            <FooterStyle HorizontalAlign="right" VerticalAlign="middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Client" SortExpression="CL_CODE">
                            <HeaderStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("CL_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Division" SortExpression="DIV_CODE">
                            <HeaderStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblDivisionCode" runat="server" Text='<%#Eval("DIV_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Product" SortExpression="PRD_CODE">
                            <HeaderStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle Width="55" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblProductCode" runat="server" Text='<%#Eval("PRD_CODE").ToString%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                    <ExpandCollapseColumn Visible="False">
                        <HeaderStyle Width="19px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </div>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <asp:Button id="ButtonSearch" runat="server" Visible="false"/>
</asp:Content>
