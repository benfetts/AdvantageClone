<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_QuickEdit.aspx.vb" Inherits="Webvantage.TrafficSchedule_QuickEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        .rtUL li:nth-child(odd) {background: white;}
        .rtUL li:nth-child(even) {
            background: #f5f5f5;
            }
        .rtUL li {
            border-bottom: 1px dashed #808080;
        }
        .rtUL li:first-child {
            border-top: 1px dashed #808080;
        }
        .rtUL li:last-child {
            border-bottom:none;
        }

    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockMain" runat="server">
        <script type="text/javascript">
            function CheckDropLocation(sender, args){
                var dropPosition = args.get_dropPosition();
                if (dropPosition == "over") {
                    args.set_cancel(true);
                }
            }
            function setTreeViewSize() {
                var treeView = $find('<%= RadTreeViewTasks.ClientID%>');
                if (treeView) {
                    treeView = treeView.get_element();
                    var windowHeight = $(window).height() - 100;
                    $(treeView).height(windowHeight);
                }
            }
            var scrollPosition;
            function onResponseEnd(sender, args) {
                setTreeViewSize();
                var tree = $find("<%= RadTreeViewTasks.ClientID %>");
                $($find("<%= RadTreeViewTasks.ClientID %>").get_element()).scrollTop(scrollPosition);
            }
            function onRequestStart(sender, args) {
                scrollPosition = $($find("<%= RadTreeViewTasks.ClientID %>").get_element()).scrollTop();
            }
            $(document).ready(function () {
                setTreeViewSize();
                $(window).resize(function () {
                    setTreeViewSize();
                });
            });

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="height:20px;"></div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <telerik:RadTreeView ID="RadTreeViewTasks" runat="server" EnableDragAndDrop="true" MultipleSelect="true" Width="100%"> 
            <NodeTemplate>
                <table cellspacing="3" cellpadding="0" border="0" style="width:100%;">
                    <tr>
                        <td style="width:40px; text-align: left;"><asp:Label ID="LabelLevel" runat="server" Text='<%# Eval("Level")%>' /></td>
                        <td style="width: 75px; text-align: left;"><asp:Label ID="LabelCode" runat="server" Text='<%# Eval("TaskCode")%>' /></td>
                        <td style="width:225px; text-align: left;"><asp:Label ID="LabelTaskDescription" runat="server" Text='<%# Eval("TaskDescription")%>' /></td>
                        <td><ul style="list-style-type: none; margin: 0; padding: 0; width: 40px;">
                                <li style="display: inline; width: 20px; background: transparent; border:none;"><asp:ImageButton runat="server" CommandName="MoveLeft" ID="ImageButtonMoveLeft" SkinID="ImageButtonPrevious" Visible="true" OnClick="ImageButtonMoveLeft_Click" /></li>
                                <li style="display: inline; width: 20px; background: transparent; border:none;"><asp:ImageButton runat="server" CommandName="MoveRight" ID="ImageButtonMoveRight" SkinID="ImageButtonNext" Visible="true" OnClick="ImageButtonMoveRight_Click" /></li>
                            </ul></td>
                        <td style="visibility: hidden;"><asp:TextBox ID="TextBoxJobOrder" runat="server" Visible="false" Width="30px" Text='<%# Eval("JobOrder") %>'  SkinID="TextBoxStandard"/></td>
                    </tr>
                </table>
            </NodeTemplate>
        </telerik:RadTreeView>
                </ContentTemplate>
            </asp:UpdatePanel>
    <div style="height:20px;"></div>

</asp:Content>
