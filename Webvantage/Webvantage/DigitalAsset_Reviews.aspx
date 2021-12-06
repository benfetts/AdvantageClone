<%@ Page Title="Digital Asset Reviews" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="DigitalAsset_Reviews.aspx.vb" Inherits="Webvantage.DigitalAsset_Reviews" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">
        function setThumbnails() {
            var grid = $find("<%=RadGridDigitalAssetReviews.ClientID %>");
            var masterTable = grid.get_masterTableView();
            for (var row = 0; row < masterTable.get_dataItems().length; row++) {
                var cell = masterTable.getCellByColumnUniqueName(masterTable.get_dataItems()[row], "GridTemplateColumnViewDetails");
                if (cell) {
                    var img = $(cell).find("[id$=ImageButtonThumbnail]");
                    var hf = $(cell).find($("[id$=HiddenFieldReviewID]"));
                    console.log(img)
                    if (hf) {
                        var reviewId = 0;
                        if (isNaN(hf.val()) == false) {
                            reviewId = hf.val();
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: 'ConceptShare/GetReviewLatestAssetVersionThumbnail',
                                data: JSON.stringify({ "ReviewID": reviewId }),
                                success: function (result) {
                                    $(cell).find("[id$=ImageButtonThumbnail]").attr("src", result);
                                },
                                error: function (msg) {
                                    console.log(msg);
                                }
                            });
                        }
                    }
                }
            }
        }

        function RadToolBarOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName == "Delete") {
                ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                radToolBarConfirm(sender, args, "Are you sure you want to delete?");
            }
            if (commandName == "WvPermaLink") {
                <%=Me.WebvantageLink%>
                args.set_cancel(true);
            }
            if (commandName == "CpPermaLink") {
                <%=Me.ClientPortalLink%>
                args.set_cancel(true);
            }
        }

        $(document).ready(function () {

        });
    </script>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarDigitalAssetReviews" runat="server"  AutoPostBack="false" Width="100%" TabIndex="-1" OnClientButtonClicking="RadToolBarOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonAdd" CommandName="Add" Value="Add" TabIndex="-1" ToolTip="Add new proof" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" CommandName="Refresh" Value="Refresh" TabIndex="-1" ToolTip="Refresh view" />
                <telerik:RadToolBarButton IsSeparator="true" Value="RadToolBarSeparatorGetAssetsAndThumbnails" />
                <telerik:RadToolBarButton ImageUrl="~/Images/Icons/Grey/256/gearwheel.png"  CommandName="ConceptShareMaintenance" Value="ConceptShareMaintenance" TabIndex="-1" ToolTip="ConceptShare Maintenance" />
<%--                <telerik:RadToolBarButton SkinID="RadToolBarButtonExport" CommandName="GetAssetsAndThumbnails" Value="GetAssetsAndThumbnails" TabIndex="-1" ToolTip="Get Assets And Thumbnails from CS servers" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" CommandName="RefreshGetAssetsAndThumbnails" Value="RefreshGetAssetsAndThumbnails" TabIndex="-1" ToolTip="Refresh Get Assets and Thumbnails" />--%>
            </Items>
        </telerik:RadToolBar>
    </div>    
    <div class="telerik-aqua-body">
        <asp:UpdatePanel ID="UpdatePanelProofing" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div id="DivProofing" runat="server">
                    <div style="width: 100%; border-bottom: 1px solid #CCC; margin-bottom: 6px;">
                        <div style="display: inline-block;">
                            <span style="">Advantage Proofing</span>
                        </div>
                        <div style="display: inline-block; float: right;">
                            <asp:CheckBox ID="CheckBoxProofingShowCompleted" runat="server" Text="Show Completed" AutoPostBack="true" />
                        </div>
                    </div>
                  <telerik:RadGrid ID="RadGridProofs" runat="server" 
                      AllowPaging="True" 
                      AllowSorting="True" 
                      AutoGenerateColumns="False" 
                      GridLines="None" 
                      PageSize="25" 
                      EnableEmbeddedSkins="True" 
                      Width="100%">
                        <PagerStyle Mode="NextPrevAndNumeric" 
                            AlwaysVisible="true" 
                            Position="Bottom"></PagerStyle>
                        <MasterTableView 
                            DataKeyNames="AlertID, LatestDocumentID" 
                            Width="100%">
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails" HeaderAbbr="FIXED">
                                    <HeaderStyle CssClass="" Width="100px" />
                                    <ItemStyle CssClass="" Width="100px" />
                                    <FooterStyle CssClass=""  Width="100px"/>
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="ViewDetails" runat="server">
                                            <div id="DivIcon" runat="server" class="icon-background background-color-sidebar" style="cursor:pointer;">
                                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" CommandName="ViewDetails" 
                                                    ToolTip="View details" 
                                                    AlternateText="View details" 
                                                    SkinID="ImageButtonViewWhite" />
                                            </div>
                                            <div id="DivThumbnail" runat="server" style="cursor:pointer; width: 100px; height: 100px; overflow:hidden;">
                                                <telerik:RadBinaryImage ID="RadBinaryImageThumbnail" runat="server" AutoAdjustImageControlSize="true"/>
                                            </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Title" SortExpression="Title" HeaderText="" UniqueName="GridBoundColumnTitle">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RoutedText" SortExpression="RoutedText" HeaderText="Routed" UniqueName="GridBoundColumnRoutedText">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AlertTemplateName" SortExpression="AlertTemplateName" HeaderText="Workflow" 
                                    UniqueName="GridBoundColumnRoutedAlertTemplateName">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AlertStateName" SortExpression="AlertStateName" HeaderText="Current State" UniqueName="GridBoundColumnRoutedAlertStateName">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CompletedText" SortExpression="CompletedText" HeaderText="Completed" UniqueName="GridBoundColumnRoutedCompletedText">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalReviewers" 
                                    HeaderText="Total Reviewers" 
                                    SortExpression="TotalReviewers" 
                                    UniqueName="GridBoundColumnTotalReviewers">
                                    <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                    <ItemStyle Width="40px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="40px"  HorizontalAlign="Center"/>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalApproved" 
                                    HeaderText="Approved" 
                                    SortExpression="TotalApproved" 
                                    UniqueName="GridBoundColumnTotalApproved">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalDeferred" 
                                    HeaderText="Deferred" 
                                    SortExpression="TotalDeferred" 
                                    UniqueName="GridBoundColumnTotalDeferred">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalRejected" 
                                    HeaderText="Rejected" 
                                    SortExpression="TotalRejected" 
                                    UniqueName="GridBoundColumnTotalRejected">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalDocuments" 
                                    HeaderText="Assets" 
                                    SortExpression="TotalDocuments" 
                                    UniqueName="GridBoundColumnTotalDocuments">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalMarkups" 
                                    HeaderText="Markups" 
                                    SortExpression="TotalMarkups" 
                                    UniqueName="GridBoundColumnTotalMarkups">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    DataField="TotalComments" 
                                    HeaderText="Comments" 
                                    SortExpression="TotalComments" 
                                    UniqueName="GridBoundColumnTotalComments">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px"  HorizontalAlign="Center"/>
                                    <FooterStyle Width="50px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Last Internal Comment">
                                    <ItemStyle Width="100px"  HorizontalAlign="Center"/>
                                    <ItemTemplate>
                                        <%# If(String.IsNullOrWhiteSpace(Eval("InternalLastCommentFullName")) = False, Eval("InternalLastCommentFullName") & "<br />" & Eval("InternalLastCommentDate"), "")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Last External Comment">
                                    <ItemStyle Width="100px"  HorizontalAlign="Center"/>
                                    <ItemTemplate>
                                        <%# If(String.IsNullOrWhiteSpace(Eval("ExternalLastCommentFullName")) = False, Eval("ExternalLastCommentFullName") & "<br />" & Eval("ExternalLastCommentDate"), "")%>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn 
                                    DataField="StatusDisplay" 
                                    HeaderText="Status" 
                                    SortExpression="StatusDisplay" 
                                    UniqueName="GridBoundColumnStatusDisplay">
                                    <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                    <ItemStyle Width="60px" HorizontalAlign="Center" />
                                    <FooterStyle Width="60px" HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Created" DataFormatString="{0:d}" HeaderText="Created" SortExpression="Created" UniqueName="GridBoundColumnCreated">
                                    <HeaderStyle CssClass="radgrid-datetime-column" />
                                    <ItemStyle CssClass="radgrid-datetime-column" />
                                    <FooterStyle CssClass="radgrid-datetime-column" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProofingTool">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivProofingTool" runat="server" class="icon-background background-color-sidebar" title="Click to open proofing tool">
                                            <asp:LinkButton ID="LinkButtonProofingTool" runat="server" Text="Pr" ToolTip="Click to open proofing tool" CssClass="icon-text" CommandName="ProofingTool" CommandArgument='' />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" Display="False">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivDeleteReview" runat="server" class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row" CommandName="Delete" />
                                        </div>
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
                        <ClientSettings>
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="DivConceptShare" runat="server" style="margin-top: 20px;">
            <div style="width: 100%; border-bottom: 1px solid #CCC; margin-bottom: 6px;"><span style="">ConceptShare Reviews</span></div>
            <telerik:RadGrid ID="RadGridDigitalAssetReviews" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="None" PageSize="25" EnableEmbeddedSkins="True" Width="100%">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <MasterTableView DataKeyNames="Review.Id, Review.ProjectId, Review.ReviewType" Width="100%">
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails" HeaderAbbr="FIXED">
                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenFieldReviewID" runat="server" Value='<%#Eval("Review.Id")%>' />
                                <asp:ImageButton ID="ImageButtonThumbnail" runat="server" CommandName="ViewDetails" ToolTip="View details" AlternateText="View details" />
                                <div id="DivViewDetails" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonViewDetails" runat="server" CommandName="ViewDetails" ToolTip="View details" AlternateText="View details" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Review.Title" SortExpression="Title" HeaderText="Review Name" UniqueName="GridBoundColumnTitle">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Review.ReviewType" SortExpression="" HeaderText="Type" UniqueName="GridBoundColumnReviewType">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Review.CreatedByName" SortExpression="CreatedByName" HeaderText="Owner" UniqueName="GridBoundColumnCreatedByName">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="" DataFormatString="" HeaderText="Assigned To" SortExpression="" UniqueName="GridBoundColumnAssignedTo" Visible="false">
                            <HeaderStyle CssClass="radgrid-employee-name-column" />
                            <ItemStyle CssClass="radgrid-employee-name-column" />
                            <FooterStyle CssClass="radgrid-employee-name-column" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Review.StatusName" SortExpression="" HeaderText="Status" UniqueName="GridBoundColumnStatusName">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCompleted" HeaderText="Completed">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40" />
                            <ItemTemplate>
                                <asp:Label ID="LabelCompleted" runat="server" Text='<%#Eval("Completed")%>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Review.DateCreated" DataFormatString="{0:d}" HeaderText="Created" SortExpression="DateCreated" UniqueName="GridBoundColumnDateCreated">
                            <HeaderStyle CssClass="radgrid-datetime-column" />
                            <ItemStyle CssClass="radgrid-datetime-column" />
                            <FooterStyle CssClass="radgrid-datetime-column" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Review.DueDate" DataFormatString="{0:d}" HeaderText="Due" SortExpression="DueDate" UniqueName="GridBoundColumnDueDate">
                            <HeaderStyle CssClass="radgrid-datetime-column" />
                            <ItemStyle CssClass="radgrid-datetime-column" />
                            <FooterStyle CssClass="radgrid-datetime-column" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnReviewInfo" Display="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivAddComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonAddComments" runat="server" SkinID="ImageButtonCommentWhite" ToolTip="Click to add comment to this document" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProofingTool">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivProofingTool" runat="server" class="icon-background background-color-sidebar" title="Click to open proofing tool">
                                    <asp:LinkButton ID="LinkButtonProofingTool" runat="server" Text="Pr" ToolTip="Click to open proofing tool" CssClass="icon-text" CommandName="ProofingTool" CommandArgument='' />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnFeedbackSummary" Display="true">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivFeedbackSummary" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonFeedbackSummary" runat="server" ImageUrl="~/Images/Icons/White/256/document_pulse.png" CssClass="icon-image" ToolTip="Click to generate feedback summary for this review" CommandName="FeedbackSummary" CommandArgument='<%#Eval("Review.Id")%>' />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" Display="True">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivDeleteReview" runat="server" class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite" ToolTip="Click to delete this row" CommandName="Delete" />
                                </div>
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
                <ClientSettings>
                </ClientSettings>
            </telerik:RadGrid>
        </div>
   </div>   
</asp:Content>
