<%@ Page AutoEventWireup="false" CodeBehind="Alert_View.aspx.vb" Inherits="Webvantage.Alert_View" ValidateRequest="false"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            var defaultInfoSectionCollapsed = false;
            defaultInfoSectionCollapsed = <%=DefaultInfoSectionCollapsed.ToString.ToLower%>;
            function SelectAll(id) {
                var frm = document.forms[0];
                for (i = 0; i < frm.elements.length; i++) {
                    if (frm.elements[i].type == "checkbox") {
                        frm.elements[i].checked = document.getElementById(id).checked;
                    }
                }
            }
            function RefreshAlertRecipients() {
                __doPostBack("RefreshAlertRecipients", "");
            }
            function ClientSetAutoCompleteEntries(str) {
                var autoCompleteBox = $find("<%=AutoCompleteRecipients.ClientID%>");
                if (autoCompleteBox) {
                    var entries = new Array();
                    entries = str.split("|");
                    for (var i = 0; i < entries.length; i++) {
                        var emp = new Array();
                        emp = entries[i].split(",");
                        if (emp[0] != "") {
                            var entry = new Telerik.Web.UI.AutoCompleteBoxEntry();
                            entry.set_value(emp[0]);
                            entry.set_text(emp[1]);
                            autoCompleteBox.get_entries().add(entry);
                        }
                    }
                }
            }
            function RadToolbarOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                if (commandName == "WvPermaLink") {
                    <%=Me.WebvantageLink%>
                    args.set_cancel(true);
                }
                if (commandName == "CpPermaLink") {
                    <%=Me.ClientPortalLink%>
                    args.set_cancel(true);
                }
            }
            $(window).resize(function () {
                try{
                    $find('<%= RadEditorDescription.ClientID %>').repaint();
                } catch (err) {

                }
            });
            function OnClientRequesting(sender, eventArgs) {
                var context = eventArgs.get_context();
                context["AlertID"] = <%= Me.AutoCompleteAlertID %>;
            }
            function RefreshPage(radWindowCaller) {
                console.log("RefreshPage Old Alert View called!");
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            //function RefreshWindow(radWindowCaller) {
            //    alert("RefreshWindow Old Alert View called!");
            //    __doPostBack('onclick#Refresh', 'Refresh');
            //};

            $(document).ready(function () {
                //if (defaultInfoSectionCollapsed === true) {
                //    $("[id$=CollapsableInformation]").hide();
                //}
                //$("[id$=InformationLabel]").click(function () {
                //    $("[id$=CollapsableInformation]").toggle(300);
                //});
                var s = window.location.search;
                if (s && s.indexOf("&tabLoaded=1") == -1) {
                    isInTab();
                }
            }); // end of document.ready

        </script>        
    </telerik:RadScriptBlock>
    <style>
        html  {
            overflow: hidden !important;
        }       
        .attachment {
            min-width: 175px; 
            border: 1px solid #cecece; 
            padding: 2px; 
            display: inline-block; 
            margin: 4px; 
            height: 55px; 
            clear: both;
        }
        .attachment-type-button {
            display: inline-block; 
            min-width: 30px; 
            color: #FFFFFF !important; 
            background-color: #808080;
            height: 25px; 
            vertical-align: middle; 
            text-align: center; 
            font-weight: bold; 
            margin: 0px 6px 0px 0px;
            cursor:pointer;
            padding: 6px 4px 0px 4px;
            font-size: 14px !important;
       }
        .attachment-action-button {
            display: inline-block; 
            width: 30px; 
            background-color: #cfcfcf; 
            color: #FFFFFF !important;
            height: 25px; 
            vertical-align: middle; 
            text-align: center; 
            font-weight: bold; 
            margin: 0px 6px 0px 0px;
            cursor:pointer;
            font-size: 14px !important;
              padding: 6px 0px 0px 0px;
      }
        a.proof-hq-link {
            color: #FFFFFF !important;
            font-weight: bold; 
            text-decoration: none !important;
            padding: 6px 0px 0px 0px;
     }
        a.proof-hq-link-delete {
            color: #F44336 !important;
            font-weight: bold; 
            text-decoration: none !important;
            padding: 6px 0px 0px 0px;
     }
        .attachment-label {
            white-space: nowrap; 
            width: 180px; 
            overflow: hidden; 
            text-overflow: ellipsis; 
            font-size: 14px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain" EnableViewState="true">
     <telerik:RadWindow ID="RadWindowAlertComment" runat="server" Behaviors="Maximize,Move,Resize"
        Height="700" DestroyOnClose="false" 
        EnableShadow="false" Width="1140" ReloadOnShow="false" IconUrl="~/Images/blank.ico"
        Title="Comments" VisibleStatusbar="false" VisibleOnPageLoad="false" KeepInScreenBounds="true">
        <ContentTemplate>            
            <div style="padding-left: 2px; padding-top: 1px; padding-bottom: 3px;">
                <telerik:RadEditor ID="RadEditorComment" runat="server" Width="1100" Height="550" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                    ContentAreaCssFile="~/CSS/RadEditorContentArea.css" ToolsFile="~/RadEditorToolbars.xml"
                    EditModes="Design" ContentAreaMode="Div">
                </telerik:RadEditor> 
            </div>
            <div class="centered">               
                 <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center"><br />
                             <asp:Button ID="ButtonCommentSave" runat="server" Text="Ok" Visible="True" TabIndex="881" />&nbsp;&nbsp;
                             <asp:Button ID="ButtonCommentSendAssignment" runat="server" Text="Send Assignment" Visible="True" TabIndex="882" />&nbsp;&nbsp;
                             <asp:Button ID="ButtonCommentCancel" runat="server" Text="Cancel" Visible="True"
                                    TabIndex="883" />
                             <asp:CheckBox ID="CheckBoxCloseAlertAfterComment" runat="server" Text="Close Alert"  Visible="false"
                                    TabIndex="884" />
                             <asp:HiddenField ID="HiddenFieldSendAssignmentClicked" runat="server" Value="0" />
                             <asp:HiddenField ID="HiddenFieldAddComment" runat="server" Value="0" />
                        </td>
                    </tr>
                </table>
            </div>            
        </ContentTemplate>
    </telerik:RadWindow>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarAlertView" runat="server" Width="100%" OnClientButtonClicking="RadToolbarOnClientButtonClicking">
        <Items>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSend" Text="Alert Recipients" Value="AlertRecipients" ToolTip="Alert Recipients" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Value="Save" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Client Contacts" Value="ClientContacts" SkinID="RadToolBarButtonClientContact" ToolTip="Open client contact pop up" />
            <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
            <telerik:RadToolBarButton Text="Add Comment" Value="AddComment" ToolTip="Add a comment to the Alert" Visible="false" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonUpload" Text="Add Attachment" Value="AddAttachment" ToolTip="Add attachment(s) to the Alert" Visible="true" />
            <telerik:RadToolBarButton IsSeparator="true" Value="ApproveDenySeparator" />
            <telerik:RadToolBarButton Text="Approve" Value="Approve" ToolTip="Approve" />
            <telerik:RadToolBarButton Text="Deny" Value="Deny" ToolTip="Deny" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print this Alert" SkinID="RadToolBarButtonPrint" />
            <telerik:RadToolBarSplitButton Text="Copy" EnableDefaultButton="false" Value="RadToolBarSplitButtonCopy" DropDownWidth="200">
                <Buttons>
                    <telerik:RadToolBarButton Text="To new Assignment" Value="CopyAsAssignment" ToolTip="Copy to a new Assignment" />
                    <telerik:RadToolBarButton Text="To new Alert" Value="CopyAsStandardAlert" ToolTip="Copy to a new Alert" />
                </Buttons>
            </telerik:RadToolBarSplitButton>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Dismiss" Value="Dismiss" ToolTip="Dismiss the Alert" />
            <telerik:RadToolBarButton Text="Complete" Value="Complete" ToolTip="Complete the Assignment" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Text="Add Time" Value="AddTime" ToolTip="Click to add time" Visible="false" SkinID="RadToolBarButtonNewTime" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonStopwatchStart" Value="StartStopwatch" ToolTip="Click to start Stopwatch" Visible="false" />
            <telerik:RadToolBarButton IsSeparator="true" Value="TimeSeparator" Visible="false" />
            <telerik:RadToolBarButton Text="Show Full Comments" Value="ShowFullComments" CheckOnClick="true" AllowSelfUnCheck="true" ToolTip="Check to show full comments instead of 'Read More' links" Visible="false" />
            <telerik:RadToolBarButton Text="All Comments" Value="ViewComments" TabIndex="-1" ToolTip="View all comments for this Job/Component" />
            <telerik:RadToolBarButton CheckOnClick="true" AllowSelfUnCheck="true" Checked="false" Text="Auto Close Alert" Value="CloseAlert" TabIndex="-1" ToolTip="Auto close alert/assignment after adding a comment or re-assigning" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" CommandName="Settings" Value="Settings"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
            <telerik:RadToolBarSplitButton DropDownWidth="125">
                <Buttons>
                    <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                    <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                </Buttons>
            </telerik:RadToolBarSplitButton>
            <telerik:RadToolBarButton Value="RadToolBarButtonLabels">
                <ItemTemplate>
                    <div style="display: inline-block; border: 0px solid green;">
                        <asp:Label ID="LabelApproved" runat="server" Visible="false" CssClass="warning"></asp:Label>
                        <asp:Label ID="LabelDismissed" runat="server" Visible="false" CssClass="warning"></asp:Label>
                        <asp:Label ID="LabelCompleted" runat="server" Text="COMPLETED" Visible="false" CssClass="warning"></asp:Label>
                    </div>
                </ItemTemplate>
            </telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    </div>
    
    <div class="telerik-aqua-body">
        <div id="DivHeaderBar" style="width:100% !important; padding: 0px 8px 0px 8px; border: 0px solid red;display:block; ">
                <div style="display: inline-block; width: 70px; border: 0px solid blue;">
                    <div style="display: inline-block !important;">
                        ID:&nbsp;&nbsp;<asp:Label ID="LabelAlertID" runat="server"></asp:Label>
                    </div>
                </div>
                <div style="display: inline-block; right:0; float:right; text-align: right; border: 0px solid purple;padding: 0px 20px 0px 0px;">
                    Generated:&nbsp;&nbsp;<asp:Label ID="LabelGenerated" runat="server"></asp:Label>
                </div>
            </div>
            <div id="DivAlertInfo" runat="server" style="width: 100%; padding: 10px 0px 10px 5px; display: block;">
                <div style="position: relative; width: 49%; display: inline-block; vertical-align: top;">
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
                <div style="position: relative; width: 50%; display: inline-block; vertical-align: top;">
                    <div id="DivCampaign" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Campaign:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelCampaign" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivJob" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Job:
                        </div>
                        <div style="display: inline-block;">
                            <asp:LinkButton ID="LBtnJob" runat="server" Visible="true"></asp:LinkButton>
                        </div>
                    </div>
                    <div id="DivJobComponent" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Component:
                        </div>
                        <div style="display: inline-block;">
                            <asp:LinkButton ID="LBtnJobComponent" runat="server" Visible="true"></asp:LinkButton>
                        </div>
                    </div>
                    <div id="DivEstimateNumber" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Estimate:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelEstimateNumber" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivEstimateComponent" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Estimate Component:
                        </div>
                        <div style="display: inline-block;">
                            <asp:Label ID="LabelEstComponentNbr" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div id="DivTask" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            Task:
                        </div>
                        <div style="display: inline-block;">
                            <asp:LinkButton ID="LinkButtonTask" runat="server"></asp:LinkButton>
                        </div>
                    </div>
                    <div id="DivATBRevision" runat="server" class="row-spacer">
                        <div style="display: inline-block;">
                            ATB:
                        </div>
                        <div style="display: inline-block;">
                            <asp:LinkButton ID="LinkButton_ATB" runat="server" Visible="true"></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <telerik:RadSplitter RenderMode="Classic" ID="RadSplitterAlertView" runat="server" Height="800px" Width="100%">
                <telerik:RadPane ID="RadPaneLeft" runat="server" Width="49%" Scrolling="Both">
                    <div id="DivMain" style="margin: 15px 0px 10px 0px;">
                        <div id="DivInfo" style="">
                            <div id="DivEditableAlertInfo" style="margin: 0px 0px 0px 6px;">
                                <div id="DivCategoryPriority" style="display: block; clear: both;">
                                    <div class="row-spacer" style="position: relative; display: inline-block; vertical-align: top;">
                                        <div>
                                            <div style="display: inline-block; text-align: right; text-indent: 3px;">
                                                Category:
                                            </div>
                                            <div style="display: inline-block;">
                                                <telerik:RadComboBox ID="RadComboBoxCategory" runat="server" AutoPostBack="False" Width="200px">
                                                </telerik:RadComboBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-spacer" style="position: relative; display: inline-block; vertical-align: top;margin-left:4px;">
                                        <div>
                                            <div style="display: inline-block;">
                                                Priority*:
                                            </div>
                                            <div style="display: inline-block;">
                                                <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" AutoPostBack="False" Width="200px">
                                                    <Items>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="DivDueDateTimeDue" runat="server" style="display: block; clear: both;">
                                    <div style="display: inline-block; vertical-align: top;">
                                        <div class="row-spacer">
                                            <div style="display: inline-block;">
                                                Start Date:
                                            </div>
                                            <div style="display: inline-block;">
                                                <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                                    <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                    </DateInput>
                                                    <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    </Calendar>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: inline-block; vertical-align: top;">
                                        <div class="row-spacer">
                                            <div style="display: inline-block;">
                                                Due Date:
                                            </div>
                                            <div style="display: inline-block;">
                                                <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" SkinID="RadDatePickerStandard">
                                                    <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                    </DateInput>
                                                    <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                    </Calendar>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="display: inline-block; vertical-align: top;">
                                        <div class="row-spacer">
                                            <div style="display: inline-block;">
                                                Time Due:
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:TextBox ID="TxtTimeDue" runat="server" MaxLength="10" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                    <div id="DivVersionBuild" runat="server" style="display: block; clear: both;">
                                        <div style="width: 50%; float: left; vertical-align: top;">
                                            <div class="row-spacer">
                                                <div class="row-spacer">
                                                    Version:
                                                </div>
                                                <div>
                                                    <telerik:RadComboBox ID="RadComboBoxVersion" runat="server" AutoPostBack="true" Width="200">
                                                    </telerik:RadComboBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="width: 50%; float: right; vertical-align: top;">
                                            <div class="row-spacer">
                                                <div class="row-spacer">
                                                    Build:
                                                </div>
                                                <div>
                                                    <telerik:RadComboBox ID="RadComboBoxBuild" runat="server" Width="200">
                                                    </telerik:RadComboBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                                <div class="row-spacer">
                                    <div class="row-spacer">
                                        Subject:
                                    </div>
                                    <div>
                                        <telerik:RadTextBox ID="TxtSubject" runat="server" Width="99%" MaxLength="254"></telerik:RadTextBox>
                                        <asp:Label ID="LabelSubject" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row-spacer">
                                    <div class="row-spacer">
                                        Description:
                                    </div>
                                    <div>
                                        <telerik:RadEditor ID="RadEditorDescription" runat="server" Width="99%" Height="320" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                            ContentAreaCssFile="~/CSS/RadEditorContentArea.css" ToolsFile="~/RadEditorToolbars.xml" ToolbarMode="ShowOnFocus"
                                            EditModes="Design">
                                                <CssFiles>
                                                    <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                                                </CssFiles>
                                        </telerik:RadEditor>
                                        <script type="text/javascript">
                                        Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                                            return false;
                                        }
                                        </script>
                                        <div class="permalink-text" style="margin: 6px; border: 0px solid #cecece; padding: 6px; display:none !important;">
                                            <asp:PlaceHolder ID="PlaceHolderDescriptionInternalLinks" runat="server" Visible="false"></asp:PlaceHolder>
                                        </div>
                                        <asp:Label ID="LabelDescription" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 6px 0px 0px 0px; display: none !important;">
                                    <asp:Button ID="BtnUpdateAlert" runat="server" Text="Update" Width="250" />
                                </div>
                            </div>
                        </div>
                
                        <div id="DivAttachments" style="padding: 8px; display: block; clear: both;" runat="server">
                            <div id="DivAttachmentsGrid" style="padding: 8px; border: 0px solid #eeeeee; margin-bottom: 10px !important; display: block; clear: both;">
                                <h3 style="margin-bottom: 4px !important; margin-top: 0px !important;">
                                    <asp:Label ID="LabelCurrentAttachments" runat="server" Text="Current Attachments"></asp:Label>
                                    <asp:ImageButton ID="ImageButtonAddAttachment" runat="server" SkinID="ImageButtonAdd" Visible="False" />
                                </h3>
                                <div style="">
                                    <telerik:RadListView ID="RadListViewAttachments" runat="server" RenderMode="Classic" ItemPlaceholderID="AttachmentsContainer" DataKeyNames="DOCUMENT_ID, ATTACHMENT_ID">
                                        <ClientSettings AllowItemsDragDrop="false">
                                            <ClientEvents></ClientEvents>
                                        </ClientSettings>
                                        <ItemTemplate>
                                            <div id="DivAttachment" runat="server" class="attachment">
                                                <div style="margin: 4px 0px 0px 2px; min-width:170px;">
                                                    <div style="display: inline-block;">
                                                        <div id="DivFileType" runat="server" class="attachment-type-button">
                                                            <asp:Label ID="LabelFileType" runat="server" Text="F"></asp:Label>
                                                        </div>                                                
                                                    </div>
                                                    <div style="display: inline-block;margin: 0px 0px 0px 0px">
                                                        <div id="DivCommentLink" runat="server" class="attachment-action-button" title="Click to view comments">
                                                            C
                                                        </div>
                                                        <div id="DivHistoryLink" runat="server" class="attachment-action-button" title="Click to view history">
                                                            H
                                                        </div>
                                                        <div id="DivProofHQLink" runat="server" class="attachment-action-button" title="Click for ProofHQ">
                                                            <asp:LinkButton ID="LinkButtonProofHQ" runat="server" Text="P" CssClass="proof-hq-link"></asp:LinkButton>
                                                        </div>
                                                        <div id="DivDigitallySignLink" runat="server" class="attachment-action-button" title="Click to digitally sign this PDF">
                                                            <asp:LinkButton ID="LinkButtonDigitallySign" runat="server" Text="S" CssClass="proof-hq-link" CommandName="SignDocument" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                                        </div>
                                                        <div id="DivDelete" runat="server" class="attachment-action-button" title="Click to delete">
                                                            <asp:LinkButton ID="LinkButtonDelete" runat="server" Text="X" CssClass="proof-hq-link-delete" CommandName="DeleteRow" CommandArgument='<%# Eval("DOCUMENT_ID")%>'></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="DivFilename" runat="server" class="attachment-label" title='<%# Eval("FILENAME")%>'>
                                                    <%# Eval("FILENAME")%>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <LayoutTemplate>
                                            <asp:PlaceHolder ID="AttachmentsContainer" runat="server"></asp:PlaceHolder>
                                        </LayoutTemplate>
                                        <GroupSeparatorTemplate>
                                        </GroupSeparatorTemplate>
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </telerik:RadListView>
                                </div>
                            </div>
                        </div>
                        <div id="DivApproval" runat="server" style="padding: 8px; border: 1px solid #eeeeee;">
                            <div>
                                Optionally add a comment in the text box below then click the &quot;Approve&quot;or&quot;Deny&quot;.
                            </div>
                            <div>
                                <telerik:RadEditor ID="ApprovalRadEditor" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                    ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" EditModes="Design" ToolbarMode="ShowOnFocus">
                                </telerik:RadEditor>
                            </div>
                            <div>
                                <asp:TextBox ID="TxtCommentApproval" runat="server" Height="250" TextMode="multiLine" Width="99%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </telerik:RadPane>
                <telerik:RadSplitBar ID="RadSplitbarLeftRight" runat="server" CollapseMode="Forward">
                </telerik:RadSplitBar>
                <telerik:RadPane ID="RadPaneRight" runat="server" Width="50%" Scrolling="None">
                    <telerik:RadSplitter RenderMode="Classic" ID="Radsplitter3" runat="server" Height="80%" Width="80%" Orientation="Horizontal">
                        <telerik:RadPane ID="RadPaneRightTop" runat="server">
                            <div id="DivComments" style="padding: 8px; width: 95%; position: relative; border: 0px solid #eeeeee;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                    <div style="margin-bottom: 4px !important; margin-top: 0px !important;">
                                        <div style="display:inline-block; font-weight:bold; font-size: 20px;">
                                            <asp:Label ID="LabelCommentsLegend" runat="server" Text="Comments"></asp:Label>
                                        </div>
                                        <div style="display: inline-block;padding-bottom: 4px;">
                                            <asp:CheckBox ID="CheckBoxHideSystemComments" runat="server" Text="Hide system comments" AutoPostBack="true" />
                                        </div>
                                    </div>
                                    <div style="width: 100%; vertical-align: top; clear: both; position: relative;">
                                        <div style="width: 80%; display: inline-block; vertical-align: top; clear: both; position: relative;">
                                            <telerik:RadTextBox runat="server" ID="RadTextBoxStandardComment" Width="100%" EmptyMessage="Enter comment" TextMode="MultiLine" Height="50" Resize="Horizontal"></telerik:RadTextBox>
                                        </div>
                                        <div style="display: inline-block; vertical-align: top; margin-left: 8px; clear: both; position: relative;">
                                            <asp:ImageButton ID="ImageButtonAddStandardComment" runat="server" SkinID="ImageButtonAdd" />
                                            <asp:ImageButton ID="ImageButtonCommentPopUpStandardComment" runat="server" ToolTip="Open comment pop up window"
                                                ImageUrl="~/Images/Icons/Grey/256/window_size.png" CssClass="icon-image" Visible="true" />
                                        </div>
                                    </div>
                                    <div style="width: 100%; border-top: 0px solid #cecece; border-left: 0px solid #cecece; border-right: 0px solid #cecece; clear: both; position: relative;margin: 10px 0px 40px 0px;">
                                        <telerik:RadListView ID="RadListViewComments" runat="server" RenderMode="Classic" DataKeyNames="CommentID">
                                            <ClientSettings AllowItemsDragDrop="false">
                                                <ClientEvents></ClientEvents>
                                            </ClientSettings>
                                            <ItemTemplate>
                                                <div style="width: 100%; margin-bottom: 10px; border-bottom: 1px solid #cecece;">
                                                    <div style="font-size: small; padding-bottom: 10px;">
                                                        <%# DataBinder.Eval(Container.DataItem, "EmployeeFullName") %> - <%# DataBinder.Eval(Container.DataItem, "GeneratedDate") %>
                                                    </div>
                                                    <div>
                                                        <div id="DivEmployeePicture" runat="server" style="position: relative; display: inline-block; width: 60px; border: 0px solid blue; vertical-align: top;">
                                                            <asp:Image ID="ImageEmployeePicture" runat="server" CssClass="wv-employee-img-thumbnail-lg comment-image-right" />
                                                        </div>
                                                        <div style="position: relative; display: inline-block; border: 0px solid red; display: inline-block; vertical-align: top; width: 85%;">
                                                            <asp:Literal ID="LiteralComment" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'></asp:Literal>
                                                            <asp:HyperLink ID="HyperLinkComment" NavigateUrl="#" Text="<br />Read more." CssClass="italics" runat="server"></asp:HyperLink>
                                                            <div class="permalink-text" style="margin: 1px; border: 0px solid #cecece; padding: 2px;">
                                                                <asp:PlaceHolder ID="PlaceHolderInternalLinks" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                            <div style="margin: 1px; border: 0px solid #cecece; padding: 2px;">
                                                                <asp:PlaceHolder ID="PlaceHolderDocumentLinks" runat="server"></asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:RadListView>
                                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                            </div>
                        </telerik:RadPane>
                        <telerik:RadSplitBar ID="RadSplitBarRightTopBottom" runat="server" CollapseMode="Backward">
                        </telerik:RadSplitBar>
                        <telerik:RadPane ID="RadPaneRightBottom" runat="server">
                            <div id="DivAssignmentRecipients" style="padding: 0px; width: 95%; position: relative; margin-bottom: 10px;">
                                <div id="DivAssignment" runat="server" style="vertical-align: top; display: block;">
                                    <div style="padding: 8px; border: 0px solid #eeeeee; width: 99%; position: relative; margin: 10px 0px 10px 8px;">
                                        <h3 style="margin-bottom: 4px !important; margin-top: 0px !important;">Assignment</h3>
                                        <div style="width: 99%;">
                                            <div style="">
                                                Workflow Template:&nbsp;&nbsp;<asp:Label ID="LabelAlertAssignmentTemplateName" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="HiddenFieldAlertAssignmentTemplateID" runat="server" Value="0" />
                                            </div>
                                        </div>
                                        <div style="width: 99%;">
                                            <div style="width: 49%; display: inline-block; position: relative; vertical-align: top;">
                                                <div>
                                                    <div class="row-spacer">
                                                        State:
                                                    </div>
                                                    <div>
                                                        <telerik:RadListBox ID="RadListBoxAlertAssignmentState" runat="server" AutoPostBack="true" 
                                                            CausesValidation="false" CheckBoxes="false" Width="100%" Height="178">
                                                        </telerik:RadListBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div style="width: 49%; display: inline-block; position: relative; vertical-align: top;">
                                                <div>
                                                    <div class="row-spacer">
                                                        Assign To:
                                                    </div>
                                                    <div>
                                                        <telerik:RadComboBox ID="RadComboBoxAssignTo" runat="server" AutoPostBack="False"
                                                            Width="100%" EnableLoadOnDemand="True"
                                                            ShowMoreResultsBox="true" ItemsPerRequest="7"
                                                            EnableVirtualScrolling="true">
                                                        </telerik:RadComboBox>
                                                    </div>
                                                    <div>
                                                        <asp:CheckBox ID="CheckBoxShowAllAssignmentEmployees" runat="server" Text="Show all employees" AutoPostBack="true" />
                                                    </div>
                                                    <div style="display: none !important;">
                                                        <asp:CheckBox ID="CheckBoxEmailAssignmentOrigintorOverride_DontEmailMe" runat="server"
                                                            AutoPostBack="True" Text="Don't email me" />
                                                    </div>
                                                </div>
                                                <div style="margin-top: 4px;">
                                                    <div class="row-spacer">Comment:</div>
                                                    <%--<telerik:RadTextBox runat="server" ID="RadTextBoxAssignmentComment" Width="100%" EmptyMessage="Enter assignment comment" TextMode="MultiLine" CssClass="alert-view-assignment-comment" Resize="Horizontal"></telerik:RadTextBox>--%>
                                                    <telerik:RadEditor ID="RadEditorAssignmentComment" runat="server" Width="99%" Height="86" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                                        ContentAreaCssFile="~/CSS/RadEditorContentAreaNoTools.css" ToolsFile="~/RadEditorToolbarsNoTools.xml"
                                                        EditModes="Design" EmptyMessage="Enter assignment comment">
                                                            <CssFiles>
                                                                <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                                                            </CssFiles>
                                                    </telerik:RadEditor>
                                                </div>
                                                <div style="margin: 10px 0px 0px 0px; width: 100%; text-align: center;">
                                                    <asp:Button ID="ButtonSendAssignment" runat="server" CausesValidation="False" Text="Send Assignment" ToolTip="Send assignment to selected employee" />
                                                    <asp:ImageButton ID="ImageButtonCommentPopUpSendAssignment" runat="server" ToolTip="Open comment pop up window" ImageUrl="~/Images/Icons/Grey/256/window_size.png" CssClass="icon-image" Visible="True" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="DivRecipients" style="vertical-align: top; display: block;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                        <div id="DivWorkItemAssignees" runat="server" style="padding: 8px; border: 0px solid #eeeeee; width: 99%; position: relative; margin: 10px 0px 10px 8px;">
                                            <h3 style="margin-bottom: 4px !important; margin-top: 0px !important;">Assignees
                                            </h3>
                                            <div>
                                                <telerik:RadGrid ID="RadGridWorkItemAssignees" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%"
                                                    GridLines="None" EnableEmbeddedSkins="True">
                                                    <mastertableview autogeneratecolumns="False" nomasterrecordstext="No assignees">
                                                        <RowIndicatorColumn Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="EmployeeCode" DataType="System.String" HeaderText="Code"
                                                                ReadOnly="True" SortExpression="EmployeeCode" UniqueName="GridBoundColumnEmployeeCode">
                                                                <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                                <FooterStyle HorizontalAlign="Left" Width="30px" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="EmployeeFullName" DataType="System.String" HeaderText="Name"
                                                                ReadOnly="True" SortExpression="EmployeeFullName" UniqueName="GridBoundColumnEmployeeFullName">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <FooterStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </mastertableview>
                                                </telerik:RadGrid>
                                            </div>
                                        </div>
                                        <div style="padding: 8px; border: 0px solid #eeeeee; width: 99%; position: relative; margin: 10px 0px 10px 8px;">
                                            <h3 style="margin-bottom: 4px !important; margin-top: 0px !important;">
                                                <asp:Label ID="LabelRecipients" runat="server" Text="Recipients"></asp:Label>
                                            </h3>
                                            <div>
                                                <telerik:RadGrid ID="RadGridRecipients" runat="server" ShowFooter="false" AutoGenerateColumns="False" Width="100%"
                                                    GridLines="None" EnableEmbeddedSkins="True">
                                                    <MasterTableView AutoGenerateColumns="False" NoMasterRecordsText="No Employee recipients." DataKeyNames="empCode,AlertRecipientID,IS_CONTACT,CURRENT_RCPT">
                                                        <RowIndicatorColumn Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSelect">
                                                                <HeaderStyle HorizontalAlign="Center" Width="16px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="16px" />
                                                                <FooterStyle HorizontalAlign="Center" Width="16px" />
                                                                <HeaderTemplate>
                                                                    <asp:CheckBox ID="cbSelectAll" runat="server" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbSelectRecp" runat="server" Checked='<%# SetCheckBoxRecp(Eval("CURRENT_RCPT")) %>' AutoPostBack="False" />
                                                                    <asp:HiddenField ID="hfEmail" runat="server" Value='<%# Eval("Email") %>' />
                                                                    <asp:HiddenField ID="HiddenFieldEmpCode" runat="server" Value='<%# Eval("empCode") %>' />
                                                                    <asp:HiddenField ID="HiddenFieldIsContact" runat="server" Value='<%# Eval("IS_CONTACT") %>' />
                                                                    <asp:HiddenField ID="HiddenFieldAlertRptID" runat="server" Value='<%# Eval("AlertRecipientID") %>' />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="EmpCode" DataType="System.String" HeaderText="Code"
                                                                ReadOnly="True" SortExpression="EmpCode" UniqueName="GridBoundColumnEmpCode">
                                                                <HeaderStyle HorizontalAlign="Left" Width="30px" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30px" />
                                                                <FooterStyle HorizontalAlign="Left" Width="30px" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="UserName" DataType="System.String" HeaderText="Name"
                                                                ReadOnly="True" SortExpression="UserName" UniqueName="GridBoundColumnUserName">
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <FooterStyle HorizontalAlign="Left" />
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAssignTo" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" Width="18px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="18px" />
                                                                <FooterStyle HorizontalAlign="Center" Width="18px" />
                                                                <HeaderTemplate>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButtonAssignTo" runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridBoundColumn DataField="Email" DataType="System.String" HeaderText="Email"
                                                                Visible="false" ReadOnly="True" SortExpression="Email" UniqueName="ColHours">
                                                                <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                <FooterStyle HorizontalAlign="Left" Width="200px" />
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </div>
                                        </div>
                                        <div style="padding: 8px; border: 0px solid #eeeeee; width: 99%; position: relative; margin: 10px 0px 10px 8px;">
                                            <h3 style="margin-bottom: 4px !important; margin-top: 0px !important;">
                                                <asp:Label ID="LabelAddRecipients" runat="server" Text="Add Recipients"></asp:Label>
                                            </h3>
                                            <div style="">
                                                <telerik:RadAutoCompleteBox ID="AutoCompleteRecipients" runat="server" Delimiter="," OnClientRequesting="OnClientRequesting"
                                                    Width="100%" AllowCustomEntry="false" Filter="StartsWith" InputType="Token">
                                                    <WebServiceSettings Method="LoadAutoComplete" Path="Alert_View.aspx" />
                                                </telerik:RadAutoCompleteBox>
                                            </div>
                                            <div style="margin-top: 8px; margin-bottom: 8px; overflow: hidden;">
                                                <div style="">
                                                    <asp:Button ID="BtnSelectRecipients" runat="server" CausesValidation="False" Text="Select" Width="85" UseSubmitBehavior="False" ToolTip="Open pop up to select recipients" />
                                                    <asp:Button ID="ButtonSaveRecipients" runat="server" CausesValidation="False" Text="Save" Width="85" UseSubmitBehavior="False" ToolTip="Save recipient changes/additions" />
                                                </div>
                                            </div>
                                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                                </div>
                            </div>
                        </telerik:RadPane>
                    </telerik:RadSplitter>
                </telerik:RadPane>
            </telerik:RadSplitter>
            <asp:HiddenField ID="HiddenFieldAlertId" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldAlertTypeId" runat="server" Value="6" />
            <asp:HiddenField ID="HiddenFieldAlertCategoryId" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldAlertLevel" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldAlertEmpCode" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldJobNumber" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldJobComponentNbr" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldTaskSeqNbr" runat="server" Value="-1" />
            <asp:HiddenField ID="HiddenFieldJobCompDescription" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldClientCode" runat="server" Value="" />
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>
    
</asp:Content>
