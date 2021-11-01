<%@ Page Title="Alert Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_Settings.aspx.vb" Inherits="Webvantage.Alert_Settings" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script>
        function RadSliderScreenSplitOnClientValueChanged(sender, args) {
            var newValue = args.get_newValue();
            //alert(newValue);
        }
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="padding-top: 10px;width:99%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div>
                <div style="display: block !important;margin-bottom:15px" class="code-description-container">
                    <div class="code-description-description">
                        Default screen split %
                    </div>
                    <div class="code-description-label">
                        <div style="display: inline-block;">
                            <telerik:RadSlider RenderMode="Classic" ID="RadSliderScreenSplit" runat="server" MinimumValue="0" MaximumValue="100" AutoPostBack="true"
                                SmallChange="5" LargeChange="25" ItemType="Tick" Height="45px" Width="425px" 
                                AnimationDuration="400" CssClass="TicksSlider" ThumbsInteractionMode="Free">
                            </telerik:RadSlider>
                        </div>
                        <div style="display: inline-block;height: 50px;vertical-align:middle;font-size:xx-large;margin: 0px 0px 15px 10px;">
                            <asp:Label ID="LabelScreenSplit" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div style="display: none !important;" class="code-description-container">
                    <div class="code-description-description">
                        Close after re-assigning
                        <asp:CheckBox ID="CheckBoxCloseAfterReassigning" runat="server" AutoPostBack="true" ToolTip="Automatically close assignment after sending the assignment" />
                    </div>
                </div>
                <div style="display: none !important;" class="code-description-container">
                    <div class="code-description-description">
                        Close after adding comment
                        <asp:CheckBox ID="CheckBoxCloseAfterComment" runat="server" AutoPostBack="true" ToolTip="Automatically close the alert/assignment after adding a comment" />
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-description">
                        Show full comments
                        <asp:CheckBox ID="CheckBoxShowFullComments" runat="server" AutoPostBack="true" ToolTip="Check to show full comments instead of 'Read More' links" />    
                    </div>
                </div>
                <div style="display: none !important;" class="code-description-container">
                    <div class="code-description-description">
                        Default Information section to collapsed
                        <asp:CheckBox ID="CheckBoxDefaultInformationSectionToCollapsed" runat="server" AutoPostBack="true" ToolTip="Information section is collapsed when first opening and refreshing an alert/assignment" />
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
