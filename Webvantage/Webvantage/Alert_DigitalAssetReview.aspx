<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_DigitalAssetReview.aspx.vb" Inherits="Webvantage.Alert_DigitalAssetReview" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<%@ Register Src="Alert_RecipientUC.ascx" TagName="AutoCompleteAlertRecipient" TagPrefix="custom" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script>
        function RadAutoCompleteBoxAssignToOnClientEntryAdded(sender, args) {
            if (args.get_entry() && args.get_entry().get_text().indexOf("#COMPLETED#") > -1) {
                var token = args.get_entry().get_token();
                $telerik.$(token).addClass("completed");
                var name = args.get_entry().get_text();
                name = name.replace("#COMPLETED#", "");
                $telerik.$(token).text(name);
                $telerik.$(token).val(name);
                //console.log("text?", $telerik.$(token).text(name));
                //console.log("val?", $telerik.$(token).val(name));
            }
        }
        function refreshFromProof() {
            __doPostBack("refreshFromProof", "refreshFromProof");
        }
        function dowloadAsset(assetId) {
            __doPostBack("DownloadAsset", assetId);
            //console.log("dowloadAsset", assetId);
        }
        function addExternalRecipients(recipientsString) {
            var autoComplete = $find("<%= RadAutoCompleteBoxExternalReviewers.ClientID %>");
            if (autoComplete && recipientsString) {
                var entries = autoComplete.get_entries();
                var newItems = new Array();
                newItems = recipientsString.split(",");
                for (var i = 0; i < newItems.length; i++) {
                    var singleItem = new Array();
                    singleItem = newItems[i].split("|");

                    var newEntry = autoComplete.createEntry(singleItem[0], singleItem[1]);
                    entries.add(newEntry);

                }
            }
        }
        function RadToolbarAlertDigitalAssetReviewOnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            if (commandName) {
                switch (commandName) {
                    case "MoreInformation":
                        args.set_cancel(true);
                        break;
                    case "ZenDeskHelp":
                        OpenFloatingWindow("Proofing Tool Help", "https://conceptshare.zendesk.com/hc/en-us/sections/200997188-Adding-Feedback-and-Markup", 768, 1024, 0, 0)
                        args.set_cancel(true);
                        break;
                    case "WvPermaLink":
                        <%=Me.WebvantageLink%>
                        args.set_cancel(true);
                        break;
                    case "CpPermaLink":
                        <%=Me.ClientPortalLink%>
                        args.set_cancel(true);
                        break;
                    case "PtWvPermaLink":
                        <%=Me.ProofingToolWebvantageLink%>
                        args.set_cancel(true);
                        break;
                    case "PtCpPermaLink":
                        <%=Me.ProofingToolWebvantageLink%>
                        args.set_cancel(true);
                        break;
                }
            }
        };
        $(document).ready(function () {
            //$("[id$=DivZipOptions]").hide();
            //$("[id$=CheckBoxProcessZip]").change(function () {
            //    $("[id$=DivZipOptions]").toggle(300);
            //});
        }); // end of document.ready

    </script>
    <style type="text/css">
        html .RadAutoCompleteBox .racToken.completed {
            /*background-image: none !important;*/
            /*
            background-color: #4CAF50 !important;
            color: white !important;
            font-weight: bold !important;

            */
            color: #4CAF50 !important;
            font-weight: bold !important;

        }
        .black-text {
            color: #000000 !important;
        }
        .comment-style {
            margin-left:20px; 
            font-size: small;
        }
        .draft-style {
            margin-left:20px; 
            font-size: small;
            font-style: italic !important;
        }
        .asset-container {
            display: inline-block !important; 
            margin: 8px !important; 
            padding: 2px !important; 
            text-align: center !important;
        }
        .selected-asset-container {
            border: 1px solid #cecece !important; 
        }

        .reviewer-container {
            border: 1px solid #cfcfcf;
            display: inline-block;
            min-width: 185px; 
            margin: 4px 2px 4px 0px;
            padding: 0px 0px 0px 0px;
            height: 46px; 
        }
        .reviewer-active {
            width: 6px !important;
            background-color: #4CAF50;
            height: 45px;
            position:relative;
            display: inline-block;
        }
        .reviewer-inactive {
            width: 6px !important;
            background-color: #FFFFFF;
            height: 45px;
            position:relative;
            display: inline-block;
            border-bottom: 1px solid #cfcfcf;
        }
        .reviewer-content-container {
            padding: 0px; 
            left:0px; 
            position: relative; 
            display:inline-block;
            border: 0px red solid;
            top: -22px;
        }
        .reviewer-container-external {
            border: 1px solid #cfcfcf;
            display: inline-block;
            min-width: 150px; 
            margin: 4px 2px 4px 0px;
            padding: 4px;
            height: 42px; 
        }
        .x-button {
            height: 18px;
            width: 18px;
            margin: 3px 0px 0px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentBody" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:UpdatePanel ID="UpdatePanelLeft" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>

        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarAlertDigitalAssetReview" runat="server" Width="100%" OnClientButtonClicking="RadToolbarAlertDigitalAssetReviewOnClientButtonClicking">
                <Items>
                    <telerik:RadToolBarButton Text="Proofing Tool" Value="ProofingTool" ToolTip="Open the markup/proofing tool" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Value="UploadAddAsset" ToolTip="Upload/add asset to review" Visible="True" />
                    <telerik:RadToolBarButton Text="" ImageUrl="Images/Icons/Grey/256/document_pulse.png" Value="FeedbackSummary" ToolTip="Get feedback summary for review as PDF" />
                    <telerik:RadToolBarButton Text="Clear Active" Value="ClearActiveFlag" CausesValidation="false" ToolTip="Clear all active flags" Visible="false" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="Save" Value="Save" ToolTip="Save" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Clear" Value="Clear" CausesValidation="false" ToolTip="Clear" Visible="false" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="Cancel" CausesValidation="false" Value="Cancel" ToolTip="Cancel" Visible="false" />
                    <telerik:RadToolBarButton Text="Approve" Value="Dismiss" ToolTip="Approve the Review" Visible="false" />
                    <telerik:RadToolBarButton IsSeparator="true" Value="TimeSeparator" Visible="false" />
                    <telerik:RadToolBarButton Text="Add Time" Value="AddTime" ToolTip="Click to add time" Visible="false" SkinID="RadToolBarButtonNewTime" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonStopwatchStart" Value="StartStopwatch" ToolTip="Click to start Stopwatch" Visible="false" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Routed?" Value="Routed" ToolTip="Automatically route reviewers" AllowSelfUnCheck="true" CheckOnClick="true" Checked="false" CausesValidation="false"/>
                    <telerik:RadToolBarButton Value="JobInformation" ImageUrl="Images/Icons/Grey/256/information.png" AllowSelfUnCheck="true" CheckOnClick="true" Checked="false" ToolTip="Display job information" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" CommandName="Refresh" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                    <telerik:RadToolBarSplitButton DropDownWidth="225">
                        <Buttons>
                            <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                            <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                            <telerik:RadToolBarButton Text="Proofing Tool WV Link" Value="PtWvPermaLink" CommandName="PtWvPermaLink" ToolTip="Create direct link to proofing tool for use in other systems" Visible="false" />
                            <telerik:RadToolBarButton Text="Proofing Tool CP Link" Value="PtCpPermaLink" CommandName="PtCpPermaLink" ToolTip="Create direct link for clients (Client Portal user) to proofing tool for use in other systems" Visible="false" />
                        </Buttons>
                    </telerik:RadToolBarSplitButton>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonQuestion" Text="" Value="ZenDeskHelp" CommandName="ZenDeskHelp" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonLabels">
                        <ItemTemplate>
                            <div style="display: inline-block; border: 0px solid green;">
                                <asp:Label ID="LabelDismissed" runat="server" Visible="false" CssClass="warning"></asp:Label>
                                <asp:Label ID="LabelCompleted" runat="server" Text="COMPLETED" Visible="false" CssClass="warning"></asp:Label>
                                <asp:Label ID="LabelApproved" runat="server" Visible="false" CssClass="warning"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
            <div id="DivJobInfo" runat="server" style="margin-bottom: 8px; border-bottom: 1px solid #cecece;">
                <div style="width: 49%; display: inline-block; vertical-align: top;">
                    <div id="DivOffice" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Office:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelOffice" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivClient" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Client:&nbsp;
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelClient" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivDivision" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Division:&nbsp;
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelDivision" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivProduct" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Product:&nbsp;
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelProduct" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="width: 49%; display: inline-block; vertical-align: top;">
                    <div id="DivJob" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Job:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelJob" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivJobComponent" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Component:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelJobComponent" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div id="DivLeft" style="width: 39%; display: inline-block; vertical-align: top; padding: 0px 4px 0px 0px; min-height: 500px; border: 0px solid red;">
                <div id="UserInput">
                    <div class="row-spacer">
                        <div class="row-spacer">
                            Review Name:<asp:RequiredFieldValidator ID="RequiredFieldValidatorReviewName" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxReviewName" CssClass="required"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBoxReviewName" runat="server" Width="96%" CssClass="RequiredInput" MaxLength="254" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row-spacer">
                        <div class="row-spacer">
                            Instructions:<asp:RequiredFieldValidator ID="RequiredFieldValidatorInstructions" runat="server" ErrorMessage="Required" ControlToValidate="TextBoxInstructions" CssClass="required"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <asp:TextBox ID="TextBoxInstructions" runat="server" Width="96%" TextMode="MultiLine" Height="75px" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 100%;">
                        <div class="row-spacer" style="display: inline-block; width: 50%;">
                            <div class="row-spacer">
                                Review Type:
                            </div>
                            <div>
                                <telerik:RadComboBox ID="RadComboBoxReviewType" runat="server" Width="100%" CausesValidation="false" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Approval" Value="1" />
                                        <telerik:RadComboBoxItem Text="Feedback" Value="2" />
                                    </Items>
                                </telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="row-spacer" style="display: inline-block; width: 49%; vertical-align: top;">
                            <div class="row-spacer">
                                Auto Approve Rule:
                            </div>
                            <div>
                                <asp:RadioButtonList ID="RadioButtonListAutoApproveRule" runat="server" RepeatDirection="Horizontal" CausesValidation="false" AutoPostBack="true">
                                    <asp:ListItem Text="Off" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Everyone Approves" Value="1"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%;">
                        <div class="row-spacer" style="display: inline-block; width: 50%;">
                            <div class="row-spacer">
                                Review Status:
                            </div>
                            <div>
                                <telerik:RadComboBox ID="RadComboBoxReviewStatus" runat="server" Width="100%" CausesValidation="false" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                            </div>
                        </div>
                        <div class="row-spacer" style="display: inline-block; width: 49%;">
                            <div class="row-spacer">
                                Priority:
                            </div>
                            <div>
                                <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" AutoPostBack="False" Width="100%" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%;">
                        <div class="row-spacer" style="display: inline-block; width: 50%;">
                            <div class="row-spacer">
                                Due Date:
                            </div>
                            <div>
                                <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarDueDate" RangeMinDate="2000-01-01" runat="server" RenderMode="Classic">
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </div>
                        </div>
                        <div class="row-spacer" style="display: inline-block; width: 49%;">
                            <div class="row-spacer">
                                Due Time:
                            </div>
                            <div>
                                <telerik:RadTimePicker ID="RadTimePickerDueTime" runat="server" AutoPostBack="false" TimeView-HeaderText="" ShowAnimation-Type="Slide" HideAnimation-Type="Slide">
                                    <TimeView ID="TimeViewDueTime" runat="server" StartTime="05:00:00" EndTime="22:31:00" Interval="00:30:00"
                                        Columns="6" HeaderText="Time Selector" ShowHeader="false">
                                        <HeaderTemplate>
                                            Time Selector
                                        </HeaderTemplate>
                                    </TimeView>
                                </telerik:RadTimePicker>
                            </div>
                        </div>
<%--                        <div class="row-spacer" style="display: block !important; width: 49%;">
                            <div class="row-spacer">
                                Routed?<asp:CheckBox runat="server" ID="CheckBoxIsRouted" AutoPostBack="True" CausesValidation="false" />
                            </div>
                        </div>--%>
                    </div>
                    <div id="DivReviewers" class="row-spacer">
                        <div id="DivAssignment" runat="server">
                            <div class="row-spacer" style="display: block !important;">
                                <div class="row-spacer">
                                    Workflow
                                </div>
                                <div>
                                    <telerik:RadComboBox ID="RadComboBoxReviewWorkflow" runat="server" Width="100%" AutoPostBack="True" CausesValidation="false" SkinID="RadComboBoxStandard"></telerik:RadComboBox>
                                </div>
                            </div>
                            <div style="width: 100%; vertical-align: top !important;">
                                <div style="width: 49%; display: inline-block; vertical-align: top !important;">
                                    <div class="row-spacer">
                                        <div class="row-spacer">
                                            State
                                        </div>
                                        <div>
                                            <telerik:RadListBox ID="RadListBoxState" runat="server" AutoPostBack="true" Width="100%" Height="150" CausesValidation="false"></telerik:RadListBox>
                                        </div>
                                    </div>
                                </div>
                                <div style="width: 49%; display: inline-block; vertical-align: top !important;">
                                    <div class="row-spacer">
                                        <div class="row-spacer">
                                            Assigned To
                                        </div>
                                        <div>
                                            <telerik:RadAutoCompleteBox ID="RadAutoCompleteBoxAssignTo" runat="server" Delimiter="," RenderMode="Classic" 
                                                Width="100%" AllowCustomEntry="false" Filter="Contains" InputType="Token" OnClientEntryAdded="RadAutoCompleteBoxAssignToOnClientEntryAdded" >
                                            </telerik:RadAutoCompleteBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="NonRoutedReviewersDiv" class="row-spacer">
                            <h4>Internal Reviewers&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonAlertAndEmailAllInternalReviewers" runat="server" Text="Email" ToolTip="Click this link to alert and email all internal reviewers"></asp:LinkButton>
                            </h4>
                            <div id="DivInternalReviewers" class="row-spacer" style="min-height: 00px; width: 100%; border-top: 0px solid #eeeeee; padding: 0px 0px 0px 0px;">
                                <telerik:RadListView ID="RadListViewReviewers" runat="server" RenderMode="Lightweight"
                                    ItemPlaceholderID="ReviewersContainer" DataKeyNames="ConceptShareUserID, EmployeeCode, IsEmployee, IsCurrentReviewer" Visible="true">
                                    <ItemTemplate>
                                        <div id="DivReviewerContainer" runat="server" class="reviewer-container" title='<%#Eval("EmailAddress")%>'>

                                            <div id="DivCurrentReviewer" runat="server" class="reviewer-current" title="Currently active">
                                            </div>
                                            <div class="reviewer-content-container">
                                                <dx:ASPxBinaryImage ID="ASPxBinaryImageReviewer" runat="server" Value='<%#Eval("Picture")%>'
                                                    CssClass="wv-employee-img-thumbnail" ViewStateMode="Enabled" StoreContentBytesInViewState="true"
                                                    EmptyImage-Url="~/Images/Icons/Grey/256/user.png" BinaryStorageMode="Session">
                                                </dx:ASPxBinaryImage>
                                                <div style="display: inline-block; height: 46px; vertical-align: top; margin-top: 0px;">
                                                    <div style="margin-top: -6px;">
                                                        <%#Eval("FullName")%>&nbsp;
                                                    <asp:ImageButton ID="ImageButtonRemoveReviewer" runat="server"
                                                        ImageUrl="~/Images/Icons/Grey/256/delete.png" CommandName="RemoveReviewer"
                                                        CommandArgument='<%#Eval("ConceptShareUserID")%>' ToolTip="Click to remove reviewer.  Existing feedback is not removed."
                                                        CssClass="x-button" />
                                                    </div>
                                                    <div style="vertical-align: top;">
                                                        <div style="font-size: small; display: inline-block; position: relative;">
                                                            <%#Eval("Status")%>
                                                        </div>
                                                        <div style="font-size: small; display: inline-block;">
                                                            <asp:ImageButton ID="ImageButtonEmail" runat="server"
                                                                ImageUrl="~/Images/Icons/Grey/256/mail.png" CommandName="EmailReviewer" CommandArgument='<%#Eval("ConceptShareUserID")%>'
                                                                ToolTip="Click to alert and email reviewer" Height="18" Width="18" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder ID="ReviewersContainer" runat="server"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <GroupSeparatorTemplate>
                                    </GroupSeparatorTemplate>
                                    <EmptyDataTemplate>
                                    </EmptyDataTemplate>
                                </telerik:RadListView>
                                <telerik:RadListView ID="RadListViewClientPortalReviewers" runat="server" RenderMode="Lightweight"
                                    ItemPlaceholderID="ReviewersContainer" DataKeyNames="ConceptShareUserID, EmployeeCode, IsEmployee, IsCurrentReviewer" Visible="true">
                                    <ItemTemplate>
                                        <div id="DivReviewerContainer" runat="server" class="reviewer-container" title='<%#Eval("EmailAddress")%>'>
                                            <div id="DivCurrentReviewer" runat="server" class="reviewer-current" title="Currently active">
                                            </div>
                                            <div class="reviewer-content-container">
                                                <div style="display: inline-block; height: 46px; vertical-align: top; margin-top: -18px;">
                                                    <div style="margin-top: -6px;">
                                                        <%#Eval("FullName")%>&nbsp;
                                                    <asp:ImageButton ID="ImageButtonRemoveReviewer" runat="server"
                                                        ImageUrl="~/Images/Icons/Grey/256/delete.png" CommandName="RemoveReviewer"
                                                        CommandArgument='<%#Eval("ConceptShareUserID")%>' ToolTip="Click to remove reviewer.  Existing feedback is not removed."
                                                        CssClass="x-button" />
                                                    </div>
                                                    <div style="vertical-align: top;">
                                                        <div style="font-size: small; display: inline-block; position: relative;">
                                                            <%#Eval("Status")%>
                                                        </div>
                                                        <div style="font-size: small; display: inline-block;">
                                                            <asp:ImageButton ID="ImageButtonEmail" runat="server"
                                                                ImageUrl="~/Images/Icons/Grey/256/mail.png" CommandName="EmailReviewer" CommandArgument='<%#Eval("ConceptShareUserID")%>'
                                                                ToolTip="Click to alert and email reviewer" Height="18" Width="18" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder ID="ReviewersContainer" runat="server"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <GroupSeparatorTemplate>
                                    </GroupSeparatorTemplate>
                                    <EmptyDataTemplate>
                                    </EmptyDataTemplate>
                                </telerik:RadListView>
                            </div>
                            <div id="DivRadAutoCompleteBoxReviewers" runat="server" style="border: 0px solid black; vertical-align: top;">
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="3">
                                            <custom:AutoCompleteAlertRecipient runat="server" ID="AutoCompleteAlertRecipientReviewers" Visible="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20px;">
                                            <asp:Button ID="ButtonSelectReviewer" runat="server" Text="Select" ToolTip="Open pop up to select reviewers" Width="150" />
                                        </td>
                                        <td>
                                            <asp:Button ID="ButtonReorderReviewers" runat="server" Text="Reorder" ToolTip="Open pop up to reorder reviewers" Width="150" Visible="false" />
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Button ID="ButtonAddReviewer" runat="server" Text="Save" ToolTip="Save reviewers you typed in" Width="150" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="DivExternalReviewers" runat="server" class="row-spacer">
                            <h4>External Reviewers&nbsp;&nbsp;<asp:LinkButton ID="LinkButtonEmailAllExternalUsers" runat="server" Text="Email" ToolTip="Click this link to email all external reviewers"></asp:LinkButton>
                                &nbsp;&nbsp;<asp:Image ID="ImageExternalReviewersHelp" runat="server" ImageAlign="TextTop" ImageUrl="~/Images/Icons/Grey/256/question.png" Height="16" Width="16" />
                            </h4>
                            <telerik:RadToolTip ID="RadToolTipCapsLock" runat="server" HideEvent="LeaveToolTip" Position="MiddleRight" RenderMode="Auto"
                                VisibleOnPageLoad="false" EnableShadow="false"
                                ShowEvent="OnMouseOver" TargetControlID="ImageExternalReviewersHelp">
                                <div style="">
                                    <div style="font-size: small;">
                                        Add external reviews with the format:
                                    </div>
                                    <div style="padding: 4px 0px 4px 0px; font-weight: bold;">
                                        Name:e-mail
                                    </div>
                                    <div style="font-size: small; font-style: italic;">
                                        (Person's name, colon, person's email address)
                                    </div>
                                    <div style="font-size: small; font-style: italic; padding: 1px 0px 0px 4px;">
                                        Example:<br />
                                        Jonathan Smith:jon.smith@domain.com
                                    </div>
                                </div>
                            </telerik:RadToolTip>
                            <div class="row-spacer" style="min-height: 00px; width: 100%; border: 0px solid #eeeeee; padding: 0px 0px 0px 0px;">
                                <telerik:RadListView ID="RadListViewExternalReviewers" runat="server" RenderMode="Lightweight"
                                    ItemPlaceholderID="ReviewersContainer" DataKeyNames="ConceptShareUserID, IsCurrentReviewer" Visible="true">
                                    <ClientSettings AllowItemsDragDrop="false">
                                        <ClientEvents></ClientEvents>
                                    </ClientSettings>
                                    <ItemTemplate>
                                        <div id="DivReviewerContainer" runat="server" class="reviewer-container" title='<%#Eval("EmailAddress")%>'>
                                            <div id="DivCurrentReviewer" runat="server" class="reviewer-current" title="Currently active">
                                            </div>
                                            <div style="display: inline-block; vertical-align: top; margin-top: 0px;">
                                                <div style="">
                                                    <%#Eval("FullName")%>&nbsp;<asp:ImageButton ID="ImageButtonRemoveReviewer" runat="server"
                                                        ImageUrl="~/Images/Icons/Grey/256/delete.png" CommandName="RemoveReviewer"
                                                        CommandArgument='<%#Eval("ConceptShareUserID")%>' ToolTip="Click to remove reviewer.  Existing feedback is not removed." Height="18" Width="18" />
                                                </div>
                                                <div style="vertical-align: top;">
                                                    <div style="font-size: small; display: inline-block;">
                                                        <%#Eval("Status")%>
                                                    </div>
                                                    <div style="font-size: small; display: inline-block;">
                                                        <asp:ImageButton ID="ImageButtonEmail" runat="server"
                                                            ImageUrl="~/Images/Icons/Grey/256/mail.png" CommandName="EmailReviewer" CommandArgument='<%#Eval("ConceptShareUserID")%>'
                                                            ToolTip="Click to alert and email reviewer" Height="18" Width="18" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <asp:PlaceHolder ID="ReviewersContainer" runat="server"></asp:PlaceHolder>
                                    </LayoutTemplate>
                                    <GroupSeparatorTemplate>
                                    </GroupSeparatorTemplate>
                                    <EmptyDataTemplate>
                                    </EmptyDataTemplate>
                                </telerik:RadListView>
                            </div>
                            <div id="DivExternalReviewersButton" runat="server" style="border: 0px solid black; vertical-align: top;">
                                <table style="width: 100%;">
                                    <tr>
                                        <td colspan="2">
                                            <telerik:RadAutoCompleteBox ID="RadAutoCompleteBoxExternalReviewers" runat="server" Delimiter=","
                                                Width="100%" AllowCustomEntry="true" Filter="StartsWith" InputType="Token">
                                            </telerik:RadAutoCompleteBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Button ID="ButtonSelectExternalReviewer" runat="server" Text="Select" ToolTip="Open pop up to add new external reviewers" Width="150" />
                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Button ID="ButtonSaveExternalReviewers" runat="server" Text="Save" ToolTip="Save external reviewers you typed in" Width="150" />
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="row-spacer">
                    <div style="min-height: 0px; width: 100%; border-top: 1px solid #eeeeee; padding: 0px 0px 0px 0px; margin: 0px 0px 0px 0px;">
                        <telerik:RadListView ID="RadListViewAssets" runat="server" RenderMode="Classic" ItemPlaceholderID="AssetsContainer" DataKeyNames="Id">
                            <ClientSettings AllowItemsDragDrop="false">
                                <ClientEvents></ClientEvents>
                            </ClientSettings>
                            <ItemTemplate>
                                <div id="DivAssetContainer" runat="server" class="asset-container">
                                    <div style="text-align: center !important; font-size: x-small !important;">
                                        <asp:Literal ID="LiteralAssetFilename" runat="server"></asp:Literal>
                                    </div>
                                    <div style="text-align: center !important;">
                                        <asp:ImageButton ID="ImageButtonAsset" runat="server" CommandName="SelectAsset" CommandArgument='<%#Eval("Id")%>' ToolTip="Click to load comments" />
                                    </div>
                                    <div style="display: none;">
                                        <%#Eval("Id")%>,
                                    </div>
                                    <div style="vertical-align: bottom; font-size: x-small !important; text-align: center;">
                                        <div style="display: inline-block; width: 20px; text-align: left; vertical-align: top;">
                                            v.<%#Eval("VersionNumber")%>
                                        </div>
                                        <div style="display: inline-block; width: 50px; text-align: right;">
                                            <asp:ImageButton ID="ImageButtonDownloadAsset" runat="server" ImageUrl="~/Images/Icons/Grey/256/arrow_down.png" ToolTip="Click to download asset" Height="12" Width="12" />
                                            <asp:ImageButton ID="ImageButtonRemoveAsset" runat="server" ImageUrl="~/Images/Icons/Grey/256/delete.png" CommandName="RemoveAsset" CommandArgument='<%#Eval("Id")%>' ToolTip="Click to remove asset" Height="12" Width="12" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <asp:PlaceHolder ID="AssetsContainer" runat="server"></asp:PlaceHolder>
                            </LayoutTemplate>
                            <GroupSeparatorTemplate>
                            </GroupSeparatorTemplate>
                            <EmptyDataTemplate>
                            </EmptyDataTemplate>
                        </telerik:RadListView>
                    </div>
                </div>
            </div>
            <div id="DivRight" style="width: 59%; display: inline-block; vertical-align: top; padding: 0px 0px 0px 4px; min-height: 500px;">
                <asp:Image ID="ImageMoreInformation" runat="server" ImageUrl="~/Images/Icons/Grey/256/information.png" CssClass="icon-image" ImageAlign="Top" Visible="false" />
                <telerik:RadToolTipManager ID="RadToolTipManagerMoreInformation" runat="server" Animation="None" RenderMode="Classic"
                    Height="75px" ManualClose="false" Modal="false" OnAjaxUpdate="MoreInformationOnAjaxUpdate" Position="BottomRight"
                    RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true" Width="260px">
                </telerik:RadToolTipManager>
                <div id="DivCommentsPanel" runat="server" style="display: block; clear: both; margin-top: -3px;">
                    <div class="row-spacer">
                        &nbsp;
                    </div>
                    <div>
                        <fieldset id="FieldsetDrafts" runat="server" style="margin: 0px 0px 10px 0px;">
                            <legend style="font-style: italic;">&nbsp;&nbsp;Draft Comments*&nbsp;&nbsp;</legend>
                            <ul>
                                <asp:ListView ID="ListViewDraftComments" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <div style="margin: 12px 0px 12px 0px; border-bottom: 0px solid #cecece;">
                                                <div style="font-style: italic;">
                                                    <%# Eval("Comment") %>
                                                </div>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ul>
                            <div style="margin: 8px; font-style: italic; font-size: small;">
                                *  Use proofing tool to edit/publish.
                            </div>
                        </fieldset>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 200px; vertical-align: top;">
                                    <div id="DivAssetInfo" runat="server" style="width: 100%; text-align: left; font-size: small;">
                                        <div style="cursor: pointer;">
                                            <asp:Image ID="ImageMarkupImage" runat="server" ToolTip="Click to open single comment in pop up" />
                                        </div>
                                        <div style="width: 188px; margin: 4px 0px 10px 0px;">
                                            <asp:Label ID="LabelAssetInfoFilename" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div style="width: 188px; font-size: smaller; text-align: left;">
                                            <div style="display: inline-block;">
                                                Version:
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:Label ID="LabelAssetInfoVersion" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div style="width: 188px; font-size: smaller; text-align: left; display: none;">
                                            <div style="display: inline-block;">
                                                Status:
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:Label ID="LabelAssetInfoStatus" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div style="width: 188px; font-size: smaller; text-align: left;">
                                            <div style="display: inline-block;">
                                                Created:
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:Label ID="LabelAssetInfoCreatedDate" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div style="width: 188px; font-size: smaller; text-align: left;">
                                            <div style="display: inline-block;">
                                                By:
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:Label ID="LabelAssetInfoCreatedBy" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td style="vertical-align: top;">
                                    <asp:CheckBox ID="CheckBoxExpandAllComments" runat="server" CausesValidation="false" AutoPostBack="true" Text="Expand all replies" />
                                    <telerik:RadGrid ID="RadGridReviewComments" runat="server" Visible="true" Width="100%" ShowHeader="false" ShowFooter="false">
                                        <ClientSettings EnablePostBackOnRowClick="true">
                                            <Selecting AllowRowSelect="true" />
                                        </ClientSettings>
                                        <MasterTableView AutoGenerateColumns="False" NoMasterRecordsText="No comments" ExpandCollapseColumn-Visible="false" HierarchyDefaultExpanded="false"
                                            DataKeyNames="Id, MarkupId, ProjectId, ReferenceId, ReferenceType, CreatedBy">
                                            <DetailTables>
                                                <telerik:GridTableView DataKeyNames="" Name="DetailTableReplies" Width="100%" AutoGenerateColumns="false">
                                                    <NoRecordsTemplate>
                                                        <div style="margin-left: 90px; font-style: italic; font-size: small;">
                                                            No replies
                                                        </div>
                                                    </NoRecordsTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnReply" Visible="True">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                            <FooterStyle HorizontalAlign="Left" />
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div id="DivComment" runat="server" style="margin-left: 90px; font-style: italic;">
                                                                    <div style="font-size: medium;">
                                                                        <%# Eval("Comment") %>
                                                                    </div>
                                                                    <div style="font-size: small;">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;<%# Eval("FullName") %> @ 
                                                                        <asp:Label ID="LabelCreatedDate" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </telerik:GridTableView>
                                            </DetailTables>
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnReplies">
                                                    <HeaderStyle Width="28" HorizontalAlign="Center" VerticalAlign="Top" />
                                                    <ItemStyle Width="28" />
                                                    <FooterStyle Width="28" />
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div id="DivTotalReplies" runat="server" style="display: block; text-align: center; width: 28px;" title='<%# "Total replies:  " & Eval("TotalReplies") %>'>
                                                            <div style="display: inline-block !important; width: 14px;">
                                                                <asp:ImageButton ID="ImageReplies" runat="server" ImageUrl="~/Images/Icons/Grey/256/user_message.png" Height="14" Width="14" CommandName="ExpandCollapse" />
                                                            </div>
                                                            <div style="display: inline-block !important;">
                                                                <asp:LinkButton ID="LinkButtonTotalRepliesNumber" runat="server" Text='<%# Eval("TotalReplies") %>' CommandName="ExpandCollapse"></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComment" Visible="True">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <FooterStyle HorizontalAlign="Left" />
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div id="DivComment" runat="server">
                                                            <div style="font-size: medium;">
                                                                <%# Eval("CommentData") %>
                                                            </div>
                                                            <div style="font-size: small;">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;<%# Eval("CreatedByName") %> @
                                                                <asp:Label ID="LabelDateCreated" runat="server" Text='<%# Eval("DateCreated") %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                    <div style="margin: 6px 0px 0px 0px;">
                                        <div>
                                            <asp:CheckBox ID="CheckBoxEmailLog" runat="server" CausesValidation="false" AutoPostBack="true" Text="Email Log" />
                                        </div>
                                        <div>
                                            <ul>
                                                <asp:ListView ID="ListViewEmailLog" runat="server" Visible="false">
                                                    <ItemTemplate>
                                                        <li>
                                                            <div style="font-size: 16px !important; margin: 6px 0px 6px 0px; border-bottom: 0px solid #cecece;">
                                                                <div style="">
                                                                    <%# Eval("Comment") %>
                                                                </div>
                                                                <div style="font-size:12px !important;margin: 0px 0px 0px 10px;">
                                                                    -&nbsp;&nbsp;<asp:Label ID="LabelUserInfo" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:ListView>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldShowTestData" runat="server" Value="0" />
            <div id="DivTest" style="display: none !important; width: 100%; height: 600px; overflow: scroll; max-width: 2900px" runat="server">
                <h4>TEST DATA</h4>
                <div id="DivTest_Reviewers" runat="server">
                    Reviewers:
                <telerik:RadGrid ID="RadGridTest_Reviewers" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_ReviewResponses" runat="server">
                    Review Responses:
                <telerik:RadGrid ID="RadGridTest_ReviewResponses" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_Threads" runat="server">
                    Threads:
                <telerik:RadGrid ID="RadGridTest_ReviewCommentThreads" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_Comments" runat="server">
                    Comments:
                <telerik:RadGrid ID="RadGridTest_ReviewCommentsTest" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_Assets" runat="server">
                    Assets:
                <telerik:RadGrid ID="RadGridTest_ReviewAssets" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_ReviewItems" runat="server">
                    Review Items:
                <telerik:RadGrid ID="RadGridTest_ReviewItems" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
                <div id="DivTest_ProjectFolderItems" runat="server">
                    Project Folder Items:
                <telerik:RadGrid ID="RadGridTest_ProjectFolderItems" runat="server" AutoGenerateColumns="true" Visible="true"></telerik:RadGrid>
                </div>
            </div>
        </div>
        <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
