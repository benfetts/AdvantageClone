<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Test.aspx.vb" Inherits="Webvantage.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
      /*#full { background: #0f0; height: 100% }*/
      .highlight {
          font-weight:bold;
          color: red;
      }
    </style>
<%--    <script type="text/javascript" src="Scripts/jquery.signalR-2.4.2.min.js"></script>
    <script src="signalr/hubs"></script>
    <script type="text/javascript">
        $(function () {
            if ($.connection.hub && $.connection.hub.state === $.signalR.connectionState.disconnected) {
                $.connection.hub
                    .start({ waitForPageLoad: false }, function () {
                        console.log("test hub starting")
                    })
                    .done(function () {
                        console.log("test hub started")
                    });
            }
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    Move along...nothing to see here.
    
    <asp:Panel ID="panel2" runat="server">
        <div>
            <asp:TextBox ID="TextBoxDecryptQS" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabelDecryptQS" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="ButtonDecryptQS" runat="server" Text="DecryptQS" />
        </div>
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:Button ID="ButtonFixPermissions" runat="server" Text="Fix Permissions" />
        <fieldset>
            <legend>Add CS user to CS account</legend>
            <div>
                <div>
                    UserID:<asp:TextBox ID="TextBoxAddCSUserToCSAccount_UserID" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <div>
                    AccountID:<asp:TextBox ID="TextBoxAddCSUserToCSAccount_AccountID" runat="server" SkinID="TextBoxStandard"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="ButtonAddCSUserToCSAccount" runat="server" Text="Add" />
                </div>
            </div>
        </fieldset>
        <div style="background-color: rebeccapurple; height: 100%; display: none;">
            <div style="width: 50%; min-height: 100%; margin: 0px; padding: 0px !important; display: inline-block; float: left;">
                <div style="width: 100%">
                </div>
            </div>
            <div style="width: 50%; min-height: 100%; margin: 0px; padding: 0px !important; display: inline-block; float: right;">
                <div style="width: 100%; top: 0 !important; bottom: 200px; position: absolute; background-color: forestgreen;">
                    hello green
                </div>
                <div style="position: absolute; width: 100%; height: 200px; bottom: 0 !important; background-color: brown; clear: both;">
                    hellow brown
                </div>
            </div>
        </div>
        <telerik:RadNumericTextBox ID="RadNumericTextBox1" runat="server" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <div style="display: none;">
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <telerik:RadGrid ID="RadGridProjects" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <telerik:RadGrid ID="RadGridReviews" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <telerik:RadSplitter RenderMode="Lightweight" ID="RadSplitterAlertView" runat="server" Height="100%" Width="100%">
                <telerik:RadPane ID="RadPaneLeft" runat="server" Width="49%" Scrolling="Both">
                    Left Pane
                </telerik:RadPane>
                <telerik:RadSplitBar ID="RadSplitbarLeftRight" runat="server" CollapseMode="Forward">
                </telerik:RadSplitBar>
                <telerik:RadPane ID="RadPaneRight" runat="server" Width="50%" Scrolling="None">
                    <telerik:RadSplitter RenderMode="Lightweight" ID="Radsplitter3" runat="server" Height="80%" Width="80%" Orientation="Horizontal">
                        <telerik:RadPane ID="RadPaneRightTop" runat="server">
                            Top Pane
                        </telerik:RadPane>
                        <telerik:RadSplitBar ID="RadSplitBarRightTopBottom" runat="server" CollapseMode="Backward">
                        </telerik:RadSplitBar>
                        <telerik:RadPane ID="RadPaneRightBottom" runat="server">
                            Bottom Pane
                        </telerik:RadPane>
                    </telerik:RadSplitter>
                </telerik:RadPane>
            </telerik:RadSplitter>
            <telerik:RadGrid ID="RadGridUploadParameters" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <telerik:RadGrid ID="RadGridConceptShareRoles" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            CP Account permissions:
        <telerik:RadGrid ID="RadGridCsCpAccountPermissions" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            CP Project permissions:
        <telerik:RadGrid ID="RadGridCsCpProjectPermissions" runat="server" AutoGenerateColumns="true"></telerik:RadGrid>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <telerik:RadGrid ID="RadGridTimeZones" runat="server">
                <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
                <MasterTableView DataKeyNames="Id">
                    <Columns>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn" HeaderText="My Column">
                            <ItemTemplate>
                                <asp:Label ID="LabelMyLabel" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadGrid ID="RadGridAccounts" runat="server" AutoGenerateColumns="False">
                <MasterTableView CommandItemDisplay="Top">
                    <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowRefreshButton="false" />
                    <Columns>
                        <telerik:GridBoundColumn DataField="AccountId" HeaderText="AccountId">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Name">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Domain" HeaderText="Domain">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActiveUsers" HeaderText="ActiveUsers">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActualStorage" HeaderText="ActualStorage">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="CreatedDate" HeaderText="CreatedDate" DataFormatString="{0:d}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActiveUsers" HeaderText="ActiveUsers">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UserLimit" HeaderText="UserLimit">
                        </telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </asp:Panel>
</asp:Content>
