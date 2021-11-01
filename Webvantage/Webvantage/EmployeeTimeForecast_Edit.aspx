<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="EmployeeTimeForecast_Edit.aspx.vb" Inherits="Webvantage.EmployeeTimeForecast_Edit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentEmployeeTimeForecastOfficeDetails" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">    
    <style type="text/css">
        [id*="RadTreeListEmployeeTimeForecastOfficeDetails"] table {
            table-layout: auto !important;
        }             
        div.RadTreeList .rfdSkinnedButton {
            text-align: center !important;
            height: 30px !important;
        }
        div.RadTreeList .rtlEditForm {
            height: 600px !important;
            overflow-y: auto !important;
        }
        /*.bottom-buttons-etf {    
            margin-bottom: 20px;
            text-align: center !important;
            
        }*/
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function imposeMaxLength(Object, MaxLen) {
                return (Object.value.length <= MaxLen);
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptBlock ID="RadScriptBlockSub" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var CommandName = args.get_item().get_commandName();
                if (CommandName == "DeleteRevision") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                if (CommandName == "Unapprove") {
                    ////args.set_cancel(!confirm('Are you sure you want to unapprove this Forecast?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to unapprove this Forecast?");
                }
            }

            function RefreshPage() {
                location.assign(location.href);
                //__doPostBack('onclick#Refresh', 'Refresh');
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadScriptBlock ID="RadScriptBlockSub2" runat="server">
        <script type="text/javascript">
            (function ($) {
                $.fn.center = function () {
                    this.css("position", "absolute");
                    this.css("top", (($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop() + "px");
                    this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");
                    return this;
                }
            })($telerik.$);

            function treeListCreated(sender, args) {
                $telerik.$(".rtlEditForm", sender.get_element()).center();
            }
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
     <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastOffice" runat="server" AutoPostBack="true" Width="100%" OnClientButtonClicking="JsOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" CommandName="Save" ToolTip="Save Employee Time Forecast" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" TabIndex="-1" CommandName="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonJobComponents" runat="server"
                    Text="Job Components" Value="JobComponents" CommandName="JobComponents" ToolTip="Add/Remove Job Components" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonEmployees" runat="server"
                    Text="Employees" Value="Employees" CommandName="Employees" ToolTip="Add/Remove Employees" />
                <telerik:RadToolBarButton ID="RadToolBarButtonFourthSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonAlternateEmployees" runat="server"
                    Text="Alternate Employees" Value="AlternateEmployees"
                    CommandName="AlternateEmployees" ToolTip="Add/Remove Alternate Employees" />
                <telerik:RadToolBarButton ID="RadToolBarButtonFifthSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonIndirectCategories" runat="server"
                    Text="Indirect Categories" Value="IndirectCategories"
                    CommandName="IndirectCategories" ToolTip="Add\Remove Indirect Categories" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSixthSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCreateRevision" runat="server"
                    Text="Create Revision" Value="CreateRevision" CommandName="CreateRevision" ToolTip="Create new revision" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSeventhSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonDeleteRevision" runat="server"
                    Text="Delete Revision" Value="DeleteRevision" CommandName="DeleteRevision" ToolTip="Delete revision" />
                <telerik:RadToolBarButton ID="RadToolBarButtonEightSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonApprove" runat="server"
                    Text="Approve" Value="Approve" CommandName="Approve" ToolTip="Approve revision" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUnapprove" runat="server"
                    Text="Unapprove" Value="Unapprove" CommandName="Unapprove" Visible="false" ToolTip="Unapprove revision" />
                <telerik:RadToolBarButton ID="RadToolBarButtonNinthSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonTenthSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonExpandAll" runat="server"
                    Text="Expand All" Value="ExpandAll" CommandName="ExpandAll" ToolTip="Expand All" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCollapseAll" runat="server"
                    Text="Collapse All" Value="CollapseAll" CommandName="CollapseAll" ToolTip="Collapse All" />
                <telerik:RadToolBarButton ID="RadToolBarButtonEleventhSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonExpandOffice" runat="server"
                    Text="Expand Office Level" Value="ExpandOffice" CommandName="ExpandOffice" ToolTip="Expand Office Level" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCollapseOffice" runat="server"
                    Text="Collapse Office Level" Value="CollapseOffice" CommandName="CollapseOffice" ToolTip="Collapse Office Level" />
                <telerik:RadToolBarButton ID="RadToolBarButtonTwelethSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonExpandClient" runat="server"
                    Text="Expand Client Level" Value="ExpandClient" CommandName="ExpandClient" ToolTip="Expand Client Level" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCollapseClient" runat="server"
                    Text="Collapse Client Level" Value="CollapseClient" CommandName="CollapseClient" ToolTip="Collapse Client Level" />
                <telerik:RadToolBarButton ID="RadToolBarButtonThirteethSeparator" runat="server" IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
            </Items>
        </telerik:RadToolBar>
    </div>
   
    <div class="telerik-aqua-body">
         <div class="code-description-container" style="margin: 10px 0px 0px 0px;">
                <div class="code-description-label">
                    Description:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxDescription" runat="server" Text="" SkinID="TextBoxCodeSingleLineDescription" AutoPostBack="false">
                    </asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Comment:
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TextBoxComment" runat="server" Text="" SkinID="TextBoxCodeMultiLineDescription" TextMode="MultiLine"
                        AutoPostBack="false" onkeypress="return imposeMaxLength(this, 100);">
                    </asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Revision Number:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="DropDownListEmployeeTimeForecastOfficeDetailRevision" runat="server" SkinID="RadComboBoxStandard"
                        AutoPostBack="true" DataTextField="Number" DataValueField="ID">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Office:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelOffice" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Post Period:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelPostPeriod" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Assigned Employee:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelAssignedEmployee" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Created By:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelCreatedBy" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Modified By:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelModifiedBy" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Approved By:
                </div>
                <div class="code-description-description">
                    <asp:Label ID="LabelApprovedBy" runat="server" Text="">
                    </asp:Label>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-description">
                    <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" />
                </div>
            </div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <telerik:RadTreeList ID="RadTreeListEmployeeTimeForecastOfficeDetails" runat="server" AutoGenerateColumns="false" AllowMultiItemSelection="false" EnableViewState="true"
                    AllowPaging="false" AllowSorting="false" ShowTreeLines="false" ShowOuterBorders="false" GridLines="Horizontal"
                    ClientSettings-AllowPostBackOnItemClick="false" EditMode="PopUp" ClientSettings-AllowKeyboardNavigation="false" ClientSettings-KeyboardNavigationSettings-AllowSubmitOnEnter="false"
                    ParentDataKeyNames="ParentOfficeCode" DataKeyNames="OfficeCode">
                    <EditFormSettings CaptionDataField="JobAndJobComponentDescription" FormCaptionStyle-Wrap="False" EditColumn-ButtonType="PushButton" FormMainTableStyle-CellPadding="12" FormTableButtonRowStyle-BorderStyle="None" FormMainTableStyle-CellSpacing="-1" FormTableButtonRowStyle-HorizontalAlign="Center" FormTableButtonRowStyle-VerticalAlign="Middle" FormTableButtonRowStyle-Height="60px">
                        <PopUpSettings Modal="True" ShowCaptionInEditForm="False" Width="600" />
                    </EditFormSettings>
                    <ClientSettings>
                        <ClientEvents OnTreeListCreated="treeListCreated" />
                    </ClientSettings>
                </telerik:RadTreeList>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
   
</asp:Content>
