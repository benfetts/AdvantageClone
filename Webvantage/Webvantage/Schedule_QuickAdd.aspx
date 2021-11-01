<%@ Page Title="Add Project Schedule" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Schedule_QuickAdd.aspx.vb" Inherits="Webvantage.Schedule_QuickAdd" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <style type="text/css">
        input[id*='FilterTextBox_ColTRF_PRESET_ORDER'] {
            text-align:right;
        }
    </style>
     <script type="text/javascript">
         function SelectTextBoxContent(id) {
             document.getElementById(id).focus();
             document.getElementById(id).select();
         }
    </script>
    <script type="text/javascript">
        function CancelNonInputSelect(sender, args) {

            var e = args.get_domEvent();
            //IE - srcElement, Others - target  
            var targetElement = e.srcElement || e.target;


            //this condition is needed if multi row selection is enabled for the grid  
            if (typeof (targetElement) != "undefined") {
                //is the clicked element an input checkbox? <input type="checkbox"...>  
                if (targetElement.tagName.toLowerCase() != "input" &&
                                    (!targetElement.type || targetElement.type.toLowerCase() != "checkbox"))// && currentClickEvent)  
                {

                    //cancel the event  
                    args.set_cancel(true);
                }
            }
            else
                args.set_cancel(true);
        }
        function CheckTheRow(ControlClientId) {
            document.getElementById(ControlClientId).checked = true;
        }

    </script>
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td >
                <asp:Button ID="BtnAddTasks" runat="server"  Text="Add Tasks" />&nbsp;&nbsp;
                <asp:CheckBox ID="ChkBlankTasks" runat="server" Text="Add Blank Tasks" AutoPostBack="true" />
            </td>
            <td align="right" valign="middle">
                &nbsp;
            </td>
        </tr>
        <tr runat="server" id="TrPresetInfo">
            <td align="left" colspan="2" valign="top">
                <telerik:RadComboBox ID="DropPreset" runat="server" AutoPostBack="true" >
                </telerik:RadComboBox>
                <asp:RadioButtonList ID="RblStandardRush" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                    RepeatLayout="Flow">
                    <asp:ListItem Value="standard">Standard</asp:ListItem>
                    <asp:ListItem Value="rush">Rush</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" valign="middle">
                <table id="TblBlankTasks" runat="server" width="762" border="0" cellspacing="0" cellpadding="2">
                    <tr>
                        <td width="60" class="sub-header sub-header-color">
                           Row Qty
                        </td>
                        <td width="278" class="sub-header sub-header-color">
                           Task Description
                        </td>
                        <td width="44" align="right" valign="middle" class="sub-header sub-header-color">
                           Order
                        </td>
                        <td width="62" align="right" valign="middle" class="sub-header sub-header-color">
                           Days
                        </td>
                        <td width="70" align="right" valign="middle" class="sub-header sub-header-color">
                           Hours
                        </td>
                        <td width="35" align="center" valign="middle" class="sub-header sub-header-color">
                           M/S
                        </td>
                    </tr>                    
                    <tr>
                        <td style="padding-top: 5px">
                            <asp:TextBox ID="TxtBlankROW_QTY" runat="server"  MaxLength="2" SkinID="TextBoxStandard"
                                Style="text-align: right; padding-top: 5px" Text="" Width="100"></asp:TextBox>
                        </td>
                        <td style="padding-top: 5px">
                            <asp:TextBox ID="TxtBlankTASK_DESCRIPTION" runat="server"  Width="180" SkinID="TextBoxStandard"
                                MaxLength="40" Text='<%# Eval("TRF_DESC") %>' Style="min-width: 175px; padding-top: 5px"></asp:TextBox>
                        </td>
                        <td align="right" valign="middle" style="padding-top: 5px">
                            <asp:TextBox ID="TxtBlankTRF_PRESET_ORDER" runat="server"  MaxLength="4" SkinID="TextBoxStandard"
                                Text='<%#Eval("TRF_PRESET_ORDER") %>' Width="80" Style="text-align: right; padding-top: 5px"></asp:TextBox>
                        </td>
                        <td align="right" valign="middle" style="padding-top: 5px">
                            <asp:TextBox ID="TxtBlankTRF_PRESET_DAYS" runat="server"  MaxLength="3" SkinID="TextBoxStandard"
                                Text='<%#Eval("TRF_PRESET_DAYS") %>' Width="100" Style="text-align: right; padding-top: 5px"></asp:TextBox>
                        </td>
                        <td align="right" valign="middle" style="padding-top: 5px">
                            <asp:TextBox ID="TxtBlankTRF_PRESET_HRS" runat="server"  MaxLength="6" SkinID="TextBoxStandard"
                                Text='<%#Eval("TRF_PRESET_HRS") %>' Width="100" Style="text-align: right; padding-top: 5px"></asp:TextBox>
                        </td>
                        <td align="center" valign="middle" style="padding-top: 5px">
                            <asp:CheckBox ID="ChkBlankMILESTONE" runat="server" />
                        </td>
                    </tr>
                </table>
                <telerik:RadGrid ID="RadGridQuickAdd" runat="server" AllowMultiRowSelection="True"
                    PageSize="25" AllowPaging="True" AllowFilteringByColumn="true" AllowSorting="True"
                    AutoGenerateColumns="False" EnableAJAX="False" GridLines="None" EnableEmbeddedSkins="True"
                    GroupingSettings-CaseSensitive="false" Width="100%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom">
                    </PagerStyle>
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                        <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ROWID" TableLayout="auto" AllowFilteringByColumn="true">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" Width="10px" />
                                <ItemStyle HorizontalAlign="center" Width="10px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn DataField="" HeaderText="Row Qty" UniqueName="ColROW_QTY"
                                AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="center" Width="32px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="32px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtROW_QTY" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="2" Style="text-align: right" Text="" Width="80"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Task Code" UniqueName="ColFNC_CODE"
                                FilterControlWidth="120" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TRF_DESC" HeaderText="Task Description" UniqueName="ColTRF_DESC"
                                FilterControlWidth="200" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="TRF_PRESET_ORDER" HeaderText="Order" UniqueName="ColTRF_PRESET_ORDER"
                                FilterControlWidth="60" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" SortExpression="TRF_PRESET_ORDER">
                                <HeaderStyle HorizontalAlign="center" Width="32px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="32px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtTRF_PRESET_ORDER" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="4" Text='<%#Eval("TRF_PRESET_ORDER") %>' Width="80" Style="text-align: right"></asp:TextBox>
                                    <asp:HiddenField ID="HFPhaseID" runat="server" Value='<%#Eval("TRAFFIC_PHASE_ID") %>' />
                                    <asp:HiddenField ID="HFRoleCode" runat="server" Value='<%#Eval("DEF_TRF_ROLE") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="TRF_PRESET_DAYS" HeaderText="Days" UniqueName="ColTRF_PRESET_DAYS"
                                AllowFiltering="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" DataType="System.Int32">
                                <HeaderStyle HorizontalAlign="center" Width="32px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="32px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtTRF_PRESET_DAYS" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="3" Text='<%#Eval("TRF_PRESET_DAYS") %>' Width="100" Style="text-align: right"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="TRF_PRESET_HRS" HeaderText="Hours" UniqueName="ColTRF_PRESET_HRS"
                                AllowFiltering="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="center" Width="32px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="32px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TxtTRF_PRESET_HRS" runat="server"  SkinID="TextBoxStandard"
                                        MaxLength="6" Text='<%#Eval("TRF_PRESET_HRS") %>' Width="100" Style="text-align: right"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="MILESTONE" HeaderText="M/S" UniqueName="ColMILESTONE"
                                AllowFiltering="false" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="center" Width="10px" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="middle" Width="10px" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkMILESTONE" runat="server" />
                                    <asp:HiddenField ID="HfEstimateFunction" runat="server" Value='<%#Eval("EST_FNC_CODE") %>' />
                                    <asp:HiddenField ID="HfDEFAULT_EMP" runat="server" Value='<%#Eval("DEFAULT_EMP") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>

</asp:Content>
