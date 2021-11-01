<%@ Page AutoEventWireup="false" CodeBehind="JobTemplate.aspx.vb" Inherits="Webvantage.JobTemplatePage" ValidateRequest="false"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Job Jacket" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">

            function OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, DialogCallback, param) {

                if (WindowURL.includes("LookUp_AdNumber.aspx")) {
                    //OpenRadWindowLookup(WindowURL, OpenerWindowName, WindowHeight, WindowWidth)
                    OpenRadWindowLookup(WindowURL, "", WindowHeight, WindowWidth);
                    return;
                }

                if (WindowURL.includes("popContacts.aspx")) {
                    DialogCallback = RefreshPage;
                }

                try {
                    var oWindow;
                    var qs = -1;
                    if (typeof WindowURL === 'undefined') {
                        ShowMessage('No page to navigate');
                        return false;
                    }
                    if (typeof WindowTitle === 'undefined') {
                        WindowTitle = '';
                    }
                    if (typeof WindowHeight === 'undefined') {
                        WindowHeight = 0;
                    }
                    if (typeof WindowWidth === 'undefined') {
                        WindowWidth = 0;
                    }
                    if (typeof IsModal === 'undefined') {
                        IsModal = false;
                    }
                    if (WindowURL.indexOf("Alert_New.aspx") > -1) {
                        if (WindowURL.indexOf("assn=1") > -1) {
                            var newURL = WindowURL;
                            qs = WindowURL.indexOf("?");
                            if (qs && qs > -1) {
                                try {
                                    newURL = "Desktop_NewAssignment" + WindowURL.substr(qs, WindowURL.length);
                                } catch (e) {
                                    newURL = "Desktop_NewAssignment";
                                }
                            } else {
                                newURL = "Desktop_NewAssignment";
                            }
                            if (newURL) {
                                WindowURL = newURL;
                            }
                            WindowTitle = "Assignment";
                        } else if (WindowURL.indexOf("eml=1") > -1) {
                            WindowTitle = "Email";
                        } else {
                            WindowTitle = "Alert";
                        }
                    }
                    if (typeof window.document.GetRadWindow === 'function') {
                        oWindow = window.document.GetRadWindow();
                        if (oWindow) {
                            oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
                        }
                    }
                    else {
                        //Use the Window Manager on the Parent page:
                        oWindow = GetRadWindow();
                        if (oWindow) {
                            if (oWindow.BrowserWindow) {
                                if (oWindow.get_name) {
                                    oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
                                }
                                else {
                                    oWindow.BrowserWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, DialogCallback, param);
                                }
                            } else {
                                oWindow.OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, DialogCallback, param);
                            }
                        };
                    }
                } catch (err) {
                    ShowMessage("Error ChildPage OpenRadWindow\n" + err);
                };
            };


            function go() {
                var a = window.open('', '', 'width=800,height=600');
                a.document.open("text/html");
                a.document.write(document.getElementById('MainJobTemplate').innerHTML);
                a.document.close();
                a.print();
            }
            function checkLength(field, len) {
                if (field.value.length > len) // too long...trim it!
                    field.value = field.value.substring(0, len);
            }
            function setBlkplt() {

            }
            function OpenNewVersion(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'OpenNewVersion');
            }
            function CancelPopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Cancel');
            }
            function JobSpecs(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'JobSpecs');
            }
            function JobSpecsCopy(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'JobSpecsCopy');
            }
            function JobVersions(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'JobVersions');
            }
            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }
            function checkLength(field, len) {
                if (field.value.length > len) // too long...trim it!
                    field.value = field.value.substring(0, len);
            }
            function OpenCreativeBrief(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'OpenCreativeBrief');
            }
            function Comments(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Comments');
            }
        </script>
    </telerik:RadScriptBlock>
    <asp:Literal ID="LitTemplateCSS" runat="server"></asp:Literal>
    <asp:HiddenField ID="HfOldCDP_CONTACT_ID" runat="server" Value="" />
    <asp:HiddenField ID="HfNewCDP_CONTACT_ID" runat="server" Value="" />
    <asp:HiddenField ID="HiddenFieldJobNumber" runat="server" Value='<%=Me.JobNumber%>' />
    <asp:HiddenField ID="HiddenFieldJobComponentNumber" runat="server" Value='<%=Me.JobComponentNbr%>' />

    <asp:Panel ID="PnlContainer" runat="server" HorizontalAlign="center" Width="100%">
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript">

                var j = 0;
                var jc = 0;
                var c = '';

                j = <%= Me.JobNumber %>
                    jc = <%= Me.JobComponentNbr %>

                    function RadToolbarJobTemplateOnClientButtonClicking(sender, args) {
                        var comandName = args.get_item().get_commandName();
                        if (comandName == "New") {
                            OpenRadWindow('', 'JobTemplate_New.aspx', 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "Search") {
                            OpenRadWindow('', 'JobTemplate_Search.aspx', 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "po") {
                            OpenRadWindow('', 'purchaseOrderbyJobCompPopup.aspx?j=' + j + '&jc=' + jc, 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "Events") {
                            OpenRadWindow('', 'Event_View.aspx?j=' + j + '&jc=' + jc + '&cli=' + c, 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "NewJobAlert") {
                            OpenRadWindow('', 'Alert_New.aspx?caller=jobtemplate&f=1&jt=1&j=' + j + '&jc=' + jc, 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "NewAlertAssignment") {
                            OpenRadWindow('', 'Alert_New.aspx?caller=jobtemplate&assn=1&f=1&jt=1&j=' + j + '&jc=' + jc, 0, 0, false);
                            args.set_cancel(true);
                        }
                        if (comandName == "WvPermaLink") {
                        <%=Me.WebvantageLink%>
                            args.set_cancel(true);
                        }
                        if (comandName == "CpPermaLink") {
                        <%=Me.ClientPortalLink%>
                            args.set_cancel(true);
                        }
                    }
            </script>
        </telerik:RadScriptBlock>
        <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
            <telerik:RadToolBar ID="RadToolbarJobTemplateTop" runat="server" AutoPostBack="False" Width="100%" OnClientButtonClicking="RadToolbarJobTemplateOnClientButtonClicking">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton id="RadToolbarButtonRadComboBoxJobTemplateTop">
                        <ItemTemplate>
                            Template:
                            <telerik:RadComboBox ID="RadComboBoxJobTemplateTop" runat="server" Width="200" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSaveJT" SkinID="RadToolBarButtonSave" Text="" Value="Save" ToolTip="Save this Job" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSearchJT" SkinID="RadToolBarButtonFind"
                        CommandName="Search" Text="" Value="Search" ToolTip="Job Search" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonNewJT" Text="New Job"
                        Value="New" ToolTip="New Job" CommandName="New" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonNewCompJT"
                        Text="New Component" Value="NewComp" ToolTip="New Component" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonPrint"
                        Text="Print/Send" Value="PrintSendOptions" ToolTip="Print/Send" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarDropDown Text="Modules">
                        <Buttons>
                            <telerik:RadToolBarButton ID="RadToolBarButtonAlert" Text="Alerts" Value="Alerts" ToolTip="Alerts" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonNewAlert" CommandName="NewJobAlert" Text="New Alert" Value="NewJobAlert" ToolTip="New Alert" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonNewAlertAssignment" CommandName="NewAlertAssignment" Text="New Assignment" Value="NewAlertAssignment" ToolTip="New Assignment" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonDocs" CommandName="Docs" Text="Documents" Value="Docs" ToolTip="Documents" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonCreativeBrief" Text="Creative Brief" Value="CB" ToolTip="Creative Brief" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonJobSpecs" Text="Specifications" Value="JobSpecs" ToolTip="Specifications" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonJobVersion" Text="Job Versions" Value="JobVersions" Enabled="true" ToolTip="Job Versions" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonEstimate" Text="Estimate" Value="Estimate" ToolTip="Estimate" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonSchedule" Text="Schedule" Value="Schedule" ToolTip="Project Schedule" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonQvA" Text="QvA" Value="qva" ToolTip="QvA" />
                            <telerik:RadToolBarButton ID="RadToolBarButtonPO" CommandName="po" Text="Purchase Orders" Value="po" ToolTip="Purchase Orders" />
                            <telerik:RadToolBarButton ID="RadToolbarButtonEvent" CommandName="Events" Text="" Value="Events" ToolTip="Events" />
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarDropDown Text="Print/Send2">
                        <Buttons>
                            <telerik:RadToolBarButton Text="Print" Value="Print" ToolTip="Print" />
                            <telerik:RadToolBarButton Text="Send Alert" Value="SendAlert" ToolTip="Send Alert" />
                            <telerik:RadToolBarButton Text="Send Assignment" Value="SendAssignment" ToolTip="Send Assignment" />
                            <telerik:RadToolBarButton Text="Send Email" Value="SendEmail" ToolTip="Send Email" />
                            <telerik:RadToolBarButton Text="Options" Value="PrintSendOptions" ToolTip="Print/Send Options" />
                        </Buttons>
                    </telerik:RadToolBarDropDown>
                    <telerik:RadToolBarButton IsSeparator="true" Value="PrintAndModuleSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonSpellCheck" ImageUrl="Images/spellcheck.png" Visible="false" Enabled="false"
                        Value="startSpell" Text=" " ToolTip="Spell Check" />
                    <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonRefreshJT" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonBack" SkinID="RadToolBarButtonClear" Text="Back"
                        Value="Back" ToolTip="Back" Visible="false" />
                    <telerik:RadToolBarButton IsSeparator="true" Visible="false" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" Visible="false" />
                    <telerik:RadToolBarSplitButton Visible="false" DropDownWidth="125">
                        <Buttons>
                            <telerik:RadToolBarButton Text="WV Link" Value="WvPermaLink" CommandName="WvPermaLink" ToolTip="Create Webvantage link for use in other systems" Visible="True" />
                            <telerik:RadToolBarButton Text="CP Link" Value="CpPermaLink" CommandName="CpPermaLink" ToolTip="Create Client Portal link for use in other systems" Visible="True" />
                        </Buttons>
                    </telerik:RadToolBarSplitButton>
                </Items>
            </telerik:RadToolBar>
        </div>
        <div class="telerik-aqua-body">
            <div style="text-align: center;">
                <asp:Label ID="lblMSG" runat="server" CssClass="required"></asp:Label>
            </div>
            <div style="text-align: right;">
                <asp:Label ID="LblNonBillable" runat="server" CssClass="RUSH" Text="NON-BILLABLE&nbsp;&nbsp;<br />"
                    Visible="false" Font-Size="X-Large" Font-Bold="True"></asp:Label>
                <asp:Label ID="LblClosed" runat="server" CssClass="RUSH" Text="CLOSED&nbsp;&nbsp;"
                    Visible="false" Font-Size="X-Large" Font-Bold="True"></asp:Label>
            </div>
            <div id="MainJobTemplate" style="width: 100%;">
                <style>
                    .drop-down-list {
                        width: 404px !important;
                    }
                </style>
                <asp:PlaceHolder ID="PlaceHolderMain" runat="server"></asp:PlaceHolder>
            </div>
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
        </div>

    </asp:Panel>
    <div>
        <asp:GridView ID="GridViewFormData" runat="server" AutoGenerateColumns="True" Visible="false">
        </asp:GridView>
        <asp:GridView ID="GridViewUserData" runat="server" AutoGenerateColumns="True" Visible="false">
        </asp:GridView>
        <asp:GridView ID="GridViewChanges" runat="server" AutoGenerateColumns="True" Visible="false">
        </asp:GridView>
    </div>
</asp:Content>
