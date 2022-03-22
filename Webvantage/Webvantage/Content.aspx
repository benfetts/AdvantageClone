<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Content.aspx.vb" Inherits="Webvantage.ContentPage" %>
<%--<%@ Register Src="~/ProjectSchedule_Gantt.ascx" TagPrefix="Content" TagName="ProjectSchedule_Gantt" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="CSS/mfb/mfb.js"></script>
    <link type="text/css" href="CSS/mfb/mfb.min.css" rel="stylesheet" />
    <link href="CSS/ContentPage.min.css" rel="stylesheet" />
    <style type="text/css">
        .rtChk {
            width: 50px;
        }
        /* Hide scrollbar for Chrome, Safari and Opera */
        .content-main-full::-webkit-scrollbar {
            display: none !important;
        }
        /* Hide scrollbar for IE and Edge */
        .content-main-full {
            -ms-overflow-style: none !important;
        }
    </style>    
    <script type="text/javascript">

        var jobNumber = 0;
        var jobComponentNumber = 0;
        var currentContentArea = 0;

        jobNumber = <%=Me.JobNumber%>;
        jobComponentNumber = <%=Me.JobComponentNumber%>;
        currentContentArea = <%=Me.CurrentContentArea%>;

        function Refresh() {
            __doPostBack("Refresh", "");
        };
        function RefreshContent(newUrl){
            var iframe = $('#ctl00_ContentPlaceHolderMain_IFrameContent');
            if(newUrl){
                iframe.attr('src', newUrl);
            }
        };
        function CallContentFunction(functionName){
            var iFrame = $('#ctl00_ContentPlaceHolderMain_IFrameContent');
            var win = iFrame[0].contentWindow;
            var fn = win[functionName];
            if(typeof fn === 'function'){
                fn();
            }
        };
        function CurrentContentUrl(){
            return $('#ctl00_ContentPlaceHolderMain_IFrameContent').attr('src');
        };
        function setIFrameContentControls() {
            var values = document.getElementById("ctl00_ContentPlaceHolderMain_ContentPageHiddenFieldLookupPassthrough");
            var iFrame = document.getElementById("ctl00_ContentPlaceHolderMain_IFrameContent");
            if (values && iFrame) {
                var controlsToSet = "";
                controlsToSet = values.value;
                controlsToSet = controlsToSet.replace(/CallingWindowContent.document/gi, "iFrameDoc");
                var iFrameDoc = iFrame.contentWindow.document;
                if (iFrameDoc) {
                    eval(controlsToSet);
                };
            } else {
                ShowMessage("Problem loading lookup from PMD!");
            };  
        };
        function sayHi() {
            ShowMessage("Hello there!");
        };
        function callFunctionOnFramedPage(functionName) {
            var iFrame = document.getElementById("ctl00_ContentPlaceHolderMain_IFrameContent");
            if (iFrame) {
                var iFrameDoc = iFrame.contentWindow.document;
                if (iFrameDoc) {
                    //eval(functionName);
                    //alert(functionName);
                };
            } else {
                ShowMessage("Problem loading functon from PMD target!");
            };
        };
        function isJobMissingRequiredInfo() {
            window.setTimeout(function () {
                if (currentContentArea != 10) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: 'ProjectManagement/JobTemplate/JobComponentIsMissingRequiredField',
                        dataType: "json",
                        data: JSON.stringify({ "JobNumber": jobNumber, "JobComponentNumber": jobComponentNumber }),
                        success: function (result) {
                            var isMissingInfo = false;
                            try {
                                if (result) {
                                    isMissingInfo = result;
                                    if (isMissingInfo == true) {
                                        var edit = false;
                                        edit = confirm("Job is missing required info!\nWould you like to edit?");
                                        if(edit == true) {
                                            window.location.replace("Content.aspx?j=" + jobNumber + "&jc=" + jobComponentNumber + "&contaid=10");
                                        }
                                    }
                                }
                            } catch (e) {}
                        },
                        error: function (err) {
                            //alert("Error");
                            //alert(err);
                        }
                    });
                }
            }, 4000);
        }
        function copyWebvantagePermalinkToClipboard(){
            <%=Me.WebvantageLink%>
        }
        function copyClientPortalPermalinkToClipboard(){
            <%=Me.ClientPortalLink%>
        }
        function RefreshFromAAM() {
            __doPostBack("RefreshFromAAM", "RefreshFromAAM");
        }
        $(document).ready(function () {
            isJobMissingRequiredInfo();

             
            $('#floatie-button').on("mouseover",(function(args) {
                floatieClicked(args);
                console.log('hi');
            }));
            
          
        }); // end of document.ready


         function floatieClicked(args) {
                //$telerik.cancelRawEvent(event);
                var contextMenu = $find("<%= ContextMenuFloatie.ClientID %>");
                contextMenu.show(args);
         }

        function floatieHide(e) {
            if (e) {
                var relTarg = e.relatedTarget || e.toElement;
                if (relTarg) {
                    var contextMenu = $find("<%= ContextMenuFloatie.ClientID %>");
                    if (contextMenu) {
                        if ((!relTarg) || (!$telerik.isDescendantOrSelf(contextMenu.get_childListElement(), relTarg))) {
                            contextMenu.hide(e);
                            //$telerik.cancelRawEvent(event);
                        }
                    }
                }
            }
        }
        function floatieOnClientItemClicked(sender, args) {
            var item = args.get_item();
            var itemValue = item.get_value();
            if (itemValue != null) {
                //alert(itemValue)
                if (itemValue == "WebvantageLink") {
                    copyWebvantagePermalinkToClipboard();
                } else if (itemValue == "ClientPortalLink") {
                    copyClientPortalPermalinkToClipboard();
                } else {
                    __doPostBack("ContextMenuFloatie", itemValue)
                }
                sender.hide();
            }
        }


        function OnClientShowingHandler(sender, args) {
            var element = sender.get_contextMenuElement();
            var handler = function(e) {
            var relatedTarget = e.rawEvent.relatedTarget || e.rawEvent.toElement;
            if (!$telerik.isDescendantOrSelf(element, relatedTarget)) {
                sender.hide();
                $removeHandler(element, "mouseout", handler);
                return;
            }
        };    
        $addHandler(element, "mouseout", handler);}



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:HiddenField ID="ContentPageHiddenFieldLookupPassthrough" runat="server" Value="ContentPageHiddenFieldLookupPassthrough" />
    <div id="content-container" style="overflow: hidden;" onclick="floatieHide(this);" onmouseover="floatieHide(this);">
        <div id="DivLeftSideNavigation" runat="server" class="pmd-left-nav">
            <div id="floatie-button" title="Actions" class="pmd-floatie dark-highlight-bg pmd-show-menu"
                onclick="floatieClicked(this);" >
                <asp:Image ID="ImageFloatie" runat="server" ImageUrl="~/Images/Icons/White/256/more_horizontal.png" CssClass="icon-image" ToolTip="Actions" />
            </div>
            <div id="DivLeftFullMenu" runat="server">
                <div class="full-float-spacer"></div>
                <div id="DivShowShortMenu" runat="server" class="pmd-floatie dark-highlight-bg pmd-show-menu">
                    <asp:ImageButton ID="ImageButtonShowShortMenu" runat="server" ImageUrl="~/Images/Icons/White/256/navigate_left.png" CssClass="icon-image" ToolTip="Show abbreviated menu" TabIndex="-1" />
                </div>
                <telerik:RadTreeView ID="RadTreeViewContent" runat="server" Width="170" ShowLineImages="false" MultipleSelect="false" AllowNodeEditing="false" TabIndex="-1">
                </telerik:RadTreeView>
                <div style="">
                    <div style="width: 100%; text-align: left; margin: 4px 0px 0px 0px;">
                        <asp:ImageButton ID="ImageButtonSaveRadTreeViewContent" runat="server" SkinID="ImageButtonSave" ToolTip="Save" Visible="false" TabIndex="-1" />
                    </div>
                </div>
            </div>
            <div id="DivLeftShortMenu" runat="server" style="">
                <div id="DivShowFullMenu" runat="server" class="pmd-floatie dark-highlight-bg pmd-show-menu">
                    <asp:ImageButton ID="ImageButtonShowFullMenu" runat="server" ImageUrl="~/Images/Icons/White/256/navigate_right.png" CssClass="icon-image pmd-show-icon" ToolTip="Show full text menu" TabIndex="-1" />
                </div>
                <div class="short-menu-control-container">
                    <asp:Repeater ID="RepeaterShortMenu" runat="server">
                        <ItemTemplate>
                            <div id="DivShortMenuItem" runat="server" class="short-menu-item">
                                <asp:LinkButton ID="LinkButtonShortMenuItem" runat="server" CssClass="dark-highlight-color content-page-short-menu-text" CommandName="LoadContent" TabIndex="-1"
                                    CommandArgument='<%#Eval("ContentCode")%>' Text='<%#Eval("Name")%>'></asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:HiddenField ID="HiddenFieldSelectedShortMenuName" runat="server" />
            </div>
        </div>
        <div id="DivMainContent" runat="server" class="content-main-full" style="padding:0px 0px 0px 0px; overflow:hidden !important;">
            <asp:PlaceHolder ID="PlaceHolderContent" runat="server"></asp:PlaceHolder>
            <iframe id="IFrameContent" runat="server" src="Blank.aspx" visible="false" style="height: 100%; width: 100%; border: 0px; overflow: auto;"></iframe>
            <div id="ContentFrameLoading" class="rwLoading" style="width: 100%; height: 100%;"></div>
        </div>
    </div>
    <telerik:RadContextMenu runat="server" ID="ContextMenuFloatie" OnClientItemClicked="floatieOnClientItemClicked"
        EnableRoundedCorners="false" EnableShadows="true" ClickToOpen="true" OnClientShowing="OnClientShowingHandler" CssClass="unity-menu">
        <Targets>
            <telerik:ContextMenuElementTarget ElementID="floatie-button" />
        </Targets>
        <Items>

            <telerik:RadMenuItem Text="New Alert" Value="NewAlert" Visible="false"  />
            <telerik:RadMenuItem Text="New Assignment" Value="NewAssignment" Visible="false"  />

            <telerik:RadMenuItem IsSeparator="true" Value="SeparatorAlerts" Visible="false" />

            <telerik:RadMenuItem Text="Print" Value="Print" />

            <telerik:RadMenuItem Text="Send Alert" Value="SendAlert" />
            <telerik:RadMenuItem Text="Send Assignment" Value="SendAssignment" />
            <telerik:RadMenuItem Text="Send Email" Value="NewEmail" />

            <telerik:RadMenuItem IsSeparator="true" Value="SeparatorEmailProof" />
            <telerik:RadMenuItem Text="New Proof" Value="NewProof" />
            <telerik:RadMenuItem IsSeparator="true" Value="SeparatorProofPrint" />


            <telerik:RadMenuItem Text="Print/Send Options" Value="PrintSettings" />
            <telerik:RadMenuItem IsSeparator="true" Value="SeparatorPrint" />
            <telerik:RadMenuItem Text="Bookmark" Value="Bookmark" />
            <telerik:RadMenuItem Text="Webvantage Link" Value="WebvantageLink" />
            <telerik:RadMenuItem Text="Client Portal Link" Value="ClientPortalLink" />
            <telerik:RadMenuItem IsSeparator="true" Value="SeparatorLinkage" Visible="false" />
            <telerik:RadMenuItem Text="Edit Menu" Value="EditMenu" />
        </Items>
    </telerik:RadContextMenu>
    <script type="text/javascript">
        function hideLoading() {
            document.getElementById("ContentFrameLoading").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolderMain_IFrameContent").style.display = "block";
        };
        $(document).ready(function () {
            
        });
        $('body').on('click', 'div[id*=DivLeftShortMenu] a, div[id*=DivLeftShortMenu] input[type=image], div[id*=DivLeftFullMenu] span.rtIn, div[id*=DivLeftFullMenu] input[type=image]', function(e){
            var iframe = document.getElementById("ctl00_ContentPlaceHolderMain_IFrameContent");
            if(iframe.src.indexOf("<%= Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute %>Index") > -1){
                iframe.contentWindow.saveForm(false);
            }
        });
    </script>
</asp:Content>
