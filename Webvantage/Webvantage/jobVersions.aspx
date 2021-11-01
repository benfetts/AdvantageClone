<%@ Page AutoEventWireup="false" CodeBehind="jobVersions.aspx.vb" Inherits="Webvantage.jobVersions"
    MasterPageFile="~/ChildPage.Master" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">

        function confirmBack() {
            window.close();
        }

        function confirmBackSave() {
            window.close();
            window.opener.focus();
        }

        function closewindow() { window.close(); }

        function JobVersionsNew(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'NewJobVer');
        }

        function RefreshFileGrid(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'Refresh');
        }
        function HidePopUpWindows(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'HidePopups');
        }
        function OpenNewVersion(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'OpenNewVersion');
        }
        function CancelPopUpWindows(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'Cancel');
        }

        function realPostBack(eventTarget, eventArgument) {
            __doPostBack(eventTarget, eventArgument);
        }
        //        function OnClientLoad(editor)
        //            {
        //                editor.GetContentArea().style.backgroundColor = "white";
        //                editor.GetContentArea().style.backgroundImage = "none";                
        //            }

        function checkLength(field, len) {
            if (field.value.length > len) // too long...trim it!
                field.value = field.value.substring(0, len);
        }


        function getFocus() { window.opener.focus(); }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarJobVersions" runat="server" AutoPostBack="True"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New" Value="New" ToolTip="New" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonCopy" Text="Copy" Value="Copy" Enabled="true"
                        ToolTip="Copy" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh"
                        ToolTip="Refresh" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <telerik:RadGrid ID="RadGridJobVersions" runat="server" AllowSorting="True" AutoGenerateColumns="False" Visible="True"
                EnableViewState="false" AllowPaging="false" EnableAJAX="false" GridLines="None" CssClass="grid-width"
                ShowFooter="false" ShowHeader="true" EnableEmbeddedSkins="True">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonViewDetails" runat="server" CommandName="ViewDetails" SkinID="ImageButtonViewWhite" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnVersionNumber" DataField="JOB_VER_SEQ_NBR" HeaderText="Number" SortExpression="JOB_VER_SEQ_NBR">
                            <HeaderStyle CssClass="radgrid-numeric-column" Width="50" />
                            <ItemStyle CssClass="radgrid-numeric-column" Width="50" />
                            <FooterStyle CssClass="radgrid-numeric-column" Width="50" />
                            <ItemTemplate>
                                <%# Eval("JOB_VER_SEQ_NBR").ToString().PadLeft(3, "0") %>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnTemplate" DataField="JV_TMPLT_DESC" HeaderText="Template" SortExpression="JV_TMPLT_DESC">
                            <HeaderStyle Width="250" />
                            <ItemStyle Width="250" />
                            <FooterStyle Width="250" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" DataField="JOB_VER_DESC" HeaderText="Description" SortExpression="JOB_VER_DESC"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
    </div>
    


</asp:Content>
