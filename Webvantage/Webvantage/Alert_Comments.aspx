<%@ Page Title="Alert Comments" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Alert_Comments.aspx.vb" Inherits="Webvantage.Alert_Comments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <style>
            /*html, body, form {
                height: 100%;
                width: 100%;
                margin: 0px 0px 0px 0px;
                padding: 0px;
                border: none;
                overflow:hidden;
            }*/
            .container {
                width: 100%; 
                /*height: 520px;*/ 
                border: 0px solid red; 
                margin: 0 auto;
                display: block; 
                clear: both;
                bottom: 0;
           }
            .button-box {
                width: 99%; 
                display: block; 
                position: relative;
                border: 0px solid green; 
                padding:0px;
            }
            .comment-list-container {
                overflow-x: hidden;
                overflow-y: auto;
                width: 100%;
                display: block;
                clear: both;
                /*height: 470px;*/
                margin: 8px 0px 8px 0px;
            }
        </style>
        <script type="text/javascript">
            function scrollToBottom() {
                //window.setTimeout(function () {
                //    $("#comment-list-container").animate({ scrollTop: $('#comment-list-container').prop("scrollHeight") }, 1000);
                //}, 50);
            }
            $(document).ready(function () {
                //scrollToBottom();
            });
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="ButtonAdd" CssClass="button-box">
            <table style="width:100%;">
                <tr>
                    <td style="vertical-align: top; padding-left: 7px;">
                        <telerik:RadEditor ID="RadEditorComment" runat="server" Width="350" Height="60" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoadSOFpopup" StripFormattingOptions="MsWord"
                            ContentAreaCssFile="~/CSS/RadEditorContentArea.css" ToolsFile="~/RadEditorToolbars.xml" ToolbarMode="ShowOnFocus" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
                            EditModes="Design" EmptyMessage="Enter Comment">
                            <CssFiles>
                                <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                            </CssFiles>
                        </telerik:RadEditor>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div class="comment-list-container">
            <asp:DataList ID="DataListComments" runat="server" GridLines="None" RepeatColumns="1" RepeatLayout="Flow">
                <ItemTemplate>
                    <div class="card comment-card">
                       <div class="content-image-container">
                            <dx:ASPxBinaryImage ID="ASPxBinaryImageEmployee" runat="server" CssClass="comment-image comment-image-left" BinaryStorageMode="Session" EmptyImage-Url="~/Images/NoImage.png">
                            </dx:ASPxBinaryImage>
                        </div>
                        <div id="DivCommentContainer" runat="server">
                            <div class="comment-employee">
                                <asp:Label ID="LabelEmployee" runat="server" Text=""></asp:Label>
                            </div>
                            <div id="DivComment" runat="server">
                                <asp:Label ID="LabelComment" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="comment-date">
                                <asp:Label ID="LabelDate" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="margin: 6px; border: 0px solid #cecece; padding: 6px;">
                                <asp:PlaceHolder ID="PlaceHolderInternalLinks" runat="server"></asp:PlaceHolder>
                            </div>
                            <div style="margin: 6px; border: 0px solid #cecece; padding: 6px;">
                                <asp:PlaceHolder ID="PlaceHolderDocumentLinks" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <br />
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
