<%@ Page AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="Webvantage.Dashboard"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function SpecsEst(radWindowCaller) {
                __doPostBack('onclick#SpecsEst', 'SpecsEst');
            }
            function SpecsComp(radWindowCaller) {
                __doPostBack('onclick#SpecsComp', 'SpecsComp');
            }
            function OnClientClose(oWnd) {
                //__doPostBack('onclick#Refresh','Refresh');
            }
        </script>
        <script type="text/javascript">
            function DisplayDetails() {
                var divDetails = document.getElementById('divDetails');
                divDetails.style.display = "inline";
            }
            function CloseActiveToolTip() {
                setTimeout(function () {
                    var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                    var tooltip = controller.get_ActiveToolTip();
                    if (tooltip) tooltip.hide();
                }, 1000);
            }
            function confirmRows() {
                ShowMessage("No rows were selected for deletion.")
            }
        </script>
        <script type="text/javascript">
            function showhide(id) {
                if (document.getElementById) {
                    obj = document.getElementById(id);
                    if (obj.style.display == "none") {
                        obj.style.display = "";
                    } else {
                        obj.style.display = "none";
                    }
                }
            }
            function enableobject(type, id1, id2, estcomp, client, division, product, sales, job) {
                if (document.getElementById) {
                    obj = document.getElementById(id1);
                    obj2 = document.getElementById(id2);
                    objclient = document.getElementById(client).value;
                    objdivision = document.getElementById(division).value;
                    objproduct = document.getElementById(product).value;
                    if (obj.value == '') {
                        obj2.disabled = false;
                        if (type == 'joblink') {
                            var url = 'LookUp.aspx?form=estimatejc&type=jobestimate&client=' + objclient + '&division=' + objdivision + '&product=' + objproduct;
                            obj2.setAttribute("onclick", "window.open(url)");
                        }
                        var a = 1;
                    } else {
                        obj2.disabled = true;
                        obj2.onclick = '';
                    }

                }
            }
            function checkPanelContent() {
                $('.place-holder').each(function () {
                    if ($(this).html().trim() === '') {
                        $(this).html('<span>No data to display.</span>');
                    }
                })
            }
            $(document).ready(function () {
                checkPanelContent();
            });
        </script>
    </telerik:RadScriptBlock>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">                    
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="left">
                                            <telerik:RadToolBar ID="RadToolbarDash" runat="server" AutoPostBack="True" Width="1145px" OnClientButtonClicking="JsOnClientButtonClicking">
                                                <Items>
                                                    <telerik:RadToolBarButton Text="Productivity" CommandName="Productivity" ToolTip="Productivity" Value="Productivity" Group="Dash"
                                                         AllowSelfUnCheck="true" CheckOnClick="true" />
                                                    <telerik:RadToolBarButton Text="Realization" CommandName="Realization" ToolTip="Realization" Value="Realization" Group="Dash" 
                                                         AllowSelfUnCheck="true" CheckOnClick="true" />
                                                    <telerik:RadToolBarButton IsSeparator="true" />
                                                </Items>
                                            </telerik:RadToolBar>                                            
                                            <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
                                                <script type="text/javascript">
                                                    function JsOnClientButtonClicking(sender, args) {
                                                        var comandName = args.get_item().get_value();
                                                        if (comandName == "Data") {
                                                            ////args.set_cancel(!confirm('Are you sure you want to update the data?'));
                                                            radToolBarConfirm(sender, args, "Are you sure you want to update the data?");
                                                        }
                                                    }
                                                </script>
                                            </telerik:RadCodeBlock>
                                        </td>
                                        <asp:Label   ID="lblUpdate" runat="server"></asp:Label>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="telerik-aqua-body">
            <div style="white-space: nowrap; margin: 0 auto; text-align: center; margin-top: 10px;">
                        <div>
                            <div style="display:inline-block; vertical-align: top; text-align: left;">
                                <div>
                                    <fieldset>
                                        <legend><strong>Office</strong></legend>
                                        <div style="white-space: nowrap;">
                                            <div style="display:inline-block; vertical-align: top;">
                                                <telerik:RadGrid ID="RadGridOffice" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    EnableEmbeddedSkins="True" Width="250px" AllowMultiRowSelection="true">
                                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <MasterTableView DataKeyNames="OFFICE_CODE,OFFICE_NAME">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="OFFICE_NAME" HeaderText="Office" UniqueName="column2">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="OFFICE_CODE" HeaderText="" UniqueName="column3"
                                                                Visible="false">
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                        <RowIndicatorColumn Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <EditFormSettings>
                                                            <PopUpSettings ScrollBars="None" />
                                                        </EditFormSettings>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </div>
                                            <div style="display: inline-block; vertical-align: top;">
                                                <div id="graphOffice" style="text-align: center; z-index: 3; width: 600px;" class="place-holder">
                                                    <telerik:RadHtmlChart ID="RadHtmlChartOffice" runat="server">
                                                    </telerik:RadHtmlChart>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div style="margin-top: 10px;">
                                    <fieldset>
                                        <legend><strong>Department</strong></legend>
                                        <div style="white-space: nowrap;">
                                            <div style="display:inline-block; vertical-align: top;">
                                                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None"
                                                    EnableEmbeddedSkins="True" Width="250px"  AllowMultiRowSelection="true">
                                                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="true">
                                                        <Selecting AllowRowSelect="True" />
                                                    </ClientSettings>
                                                    <MasterTableView DataKeyNames="DP_TM_CODE, DP_TM_DESC">
                                                        <Columns>
                                                            <telerik:GridBoundColumn DataField="DP_TM_DESC" HeaderText="Department" UniqueName="column2">
                                                            </telerik:GridBoundColumn>
                                                            <telerik:GridBoundColumn DataField="DP_TM_CODE" HeaderText="" UniqueName="column3"
                                                                Visible="false">
                                                            </telerik:GridBoundColumn>
                                                        </Columns>
                                                        <RowIndicatorColumn Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </RowIndicatorColumn>
                                                        <ExpandCollapseColumn Resizable="False" Visible="False">
                                                            <HeaderStyle Width="20px" />
                                                        </ExpandCollapseColumn>
                                                        <EditFormSettings>
                                                            <PopUpSettings ScrollBars="None" />
                                                        </EditFormSettings>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </div>
                                            <div style="display:inline-block; vertical-align: top;">
                                                <div id="Div1" style="text-align: center; width: 600px;" class="place-holder">
                                                    <telerik:RadHtmlChart ID="RadHtmlChartDepartmentTeamChart" runat="server">
                                                    </telerik:RadHtmlChart>
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                            <div style="display: inline-block; text-align: left;">
                                <fieldset>
                                    <legend><strong>Employee</strong></legend>
                                    <div style="text-align: center;">
                                        <div>
                                            <telerik:RadComboBox ID="ddEmps" runat="server" AutoPostBack="true" Visible="false" SkinID="RadComboBoxStandard">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div>
                                            <telerik:RadListBox ID="RadListEmps" runat="server" Width="300px" Height="100px"
                                                SelectionMode="Single" AllowReorder="False" AutoPostBack="True" Visible="false">
                                            </telerik:RadListBox>
                                            <telerik:RadComboBox ID="RadComboEmps" runat="server" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                EnableLoadOnDemand="true" AutoPostBack="true" SkinID="RadComboBoxEmployee">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" Value="" />
                                                    <telerik:RadComboBoxItem Text="All Employees" Value="All" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </div>
                                        <div style="margin-top: 10px;">
                                            <asp:CheckBox ID="cbEmp" runat="server" Text="Include Terminated Employees" AutoPostBack="True" /><br />
                                            <asp:RadioButton ID="rbDateEntered" runat="server" Text="Display Billed Hours based on Date Entered"
                                                GroupName="Billed" Checked="true" AutoPostBack="True" /><br />
                                            <asp:RadioButton ID="rbPeriodBilled" runat="server" Text="Display Billed Hours based on Period Billed"
                                                GroupName="Billed" AutoPostBack="True" />
                                        </div>
                                    </div>
                    
                                </fieldset>
                            </div>
                        </div>
                    </div>
        </div>
        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
