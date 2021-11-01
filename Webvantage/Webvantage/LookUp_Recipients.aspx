<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="LookUp_Recipients.aspx.vb" Inherits="Webvantage.LookUp_Recipients" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type='text/javascript'>

            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow

                var CallingWindowName = '<%= Me.OpenerRadWindowName %>';

                if (typeof oWnd.get_windowManager !== 'undefined' && !oWnd.BrowserWindow) {
                    var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                    // Get a reference to the first RadWindow's content
                    var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                    //Call the predefined function in Dialog1
                <%= Me.ControlsToSet %>
                    //Close the second RadWindow
                    oWnd.close();
                }
                else {
                    controlsToSet = '<%= Me.ControlsToSet %>';
                    oWnd.BrowserWindow.Close(controlsToSet);
                }
            };

            function returnAutoCompleteValue(emps) {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();

                if (typeof oWnd.get_windowManager !== 'undefined' && !oWnd.BrowserWindow) {
                    //get a reference to the second RadWindow
                    var CallingWindowName = '<%= Me.OpenerRadWindowName %>';
                    var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                    // Get a reference to the first RadWindow's content
                    var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                    //Call the predefined function in Dialog1 
                    //CallingWindowContent.SetAutoCompleteEntries(emps);
                    //alert("lookup: " + emps);
                    CallingWindowContent.ClientSetAutoCompleteEntries(emps);
                    //Close the second RadWindow
                    oWnd.close();
                }
                else {
                    oWnd.BrowserWindow.ClientSetAutoCompleteEntries(emps);

                    oWnd.Close();
                }
            };

            function cancelClick() {
                try {
                    //CloseThisWindow();
                } catch (e) {
                    console.log(e);
                }
                try {
                    var oWnd = GetRadWindow();
                    if (oWnd) {
                        oWnd.close();
                    }
                } catch (e) {
                    console.log(e);
                }
            }

            function AfterCheck(node) {
                //this function recursively checks child nodes when parent is checked
                UpdateAllChildren(node.Nodes, node.Checked);

                //this code unchecks the parent node if a child node is unchecked
                /*  */

                if (!node.Checked) {
                    while (node.Parent != null) {
                        node.Parent.UnCheck();
                        node = node.Parent;
                    };
                };
            };
            function UpdateAllChildren(nodes, checked) {
                var i;
                for (i = 0; i < nodes.get_count() ; i++) {
                    if (checked) {
                        nodes.getNode(i).check();
                    }
                    else {
                        nodes.getNode(i).set_checked(false);
                    };

                    if (nodes.getNode(i).get_nodes().get_count() > 0) {
                        UpdateAllChildren(nodes.getNode(i).get_nodes(), checked);
                    };
                };
            };
            function clientNodeChecked(sender, eventArgs) {
                var childNodes = eventArgs.get_node().get_nodes();
                var isChecked = eventArgs.get_node().get_checked();
                UpdateAllChildren(childNodes, isChecked);
            };
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <telerik:RadTreeView ID="RadTreeViewRecipients" runat="server" CheckBoxes="true" Style="min-height: 610px; width: 585px;" OnClientNodeChecked="clientNodeChecked">
            </telerik:RadTreeView>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="butAdd" runat="server" Text="Select" />
        &nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClientClick="cancelClick();" />
    </div>
</asp:Content>
