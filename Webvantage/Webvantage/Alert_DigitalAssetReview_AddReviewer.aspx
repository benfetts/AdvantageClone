<%@ Page Title="Add Reviewer" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_DigitalAssetReview_AddReviewer.aspx.vb" Inherits="Webvantage.Alert_DigitalAssetReview_AddReviewer" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarAddReviewer" runat="server" AutoPostBack="True" Width="100%">
                <Items>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Value="Save" />
                    <telerik:RadToolBarButton Value="SelectAll" CommandName="SelectAll" Text="Select All" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" CausesValidation="false" Value="Cancel"/>
                </Items>
            </telerik:RadToolBar>
        </div>

        <div style="margin-top:15px;">
            <div id="DivAlertGroups" runat="server" style="margin-bottom: 4px; width: 95%;">
                <telerik:RadComboBox ID="RadComboBoxAlertGroups" runat="server" AllowCustomText="false" Filter="Contains" CausesValidation="false" AutoPostBack="true" Width="100%" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </div>
            <telerik:RadListBox ID="RadListBoxReviewers" runat="server" SelectionMode="Multiple" Width="95%" Height="600" CheckBoxes="false">
                <ItemTemplate>
                    <div style="height: 50px;">
                        <div style="display: inline-block; height: 50px;">
                            <dx:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server" Value='<%#Eval("Picture")%>' BinaryStorageMode="Session"
                                CssClass="wv-employee-img-thumbnail" ViewStateMode="Enabled" StoreContentBytesInViewState="true" EmptyImage-Url="~/Images/Icons/Grey/256/user.png"></dx:ASPxBinaryImage>
                        </div>
                        <div style="display: inline-block; height: 50px; vertical-align: middle; margin-top: 2px;">
                            <%#Eval("FullName")%>
                        </div>
                    </div>
                </ItemTemplate>
            </telerik:RadListBox>
        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
