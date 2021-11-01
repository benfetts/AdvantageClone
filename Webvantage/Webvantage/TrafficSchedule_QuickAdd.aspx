<%@ Page Title="Task Templates" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficSchedule_QuickAdd.aspx.vb" Inherits="Webvantage.TrafficSchedule_QuickAdd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
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
    </script>
    <div>
        <style>
            #ctl00_ContentPlaceHolderMain_PnlStandardRush span {
                    margin: 8px 4px;
                    display: inline-block;
            }
        </style>
        <div>
            <div>
                <div style="width:60%;float:left;display:inline-block;margin:6px 0px 8px 0px;">
                    <asp:Panel ID="PnlStandardRush" runat="server" Visible="true">
                        <span style="margin: 6px 4px;">
                                                Job Due Date:&nbsp;&nbsp;<asp:Label ID="LblJobDueDate" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

                        </span>
                        <span style="margin: 6px 4px;">
                                                Today's Date:&nbsp;&nbsp;<asp:Label ID="LblTodaysDate" runat="server" Text=""></asp:Label><br />

                        </span>
                       <span style="margin: 6px 4px;">
                            Working Days:&nbsp;&nbsp;<asp:Label ID="LblWorkingDays" runat="server" Text=""></asp:Label>
                       </span>
                    </asp:Panel>
                    <div style="margin: 0px 0px 8px 0px;">
                        <asp:RadioButtonList ID="RblStandardRush" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Value="standard">Standard</asp:ListItem>
                            <asp:ListItem Value="rush">Rush</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div style="width: 40%; float: right;display:inline-block;text-align:right; margin-bottom: 10px;">
                    <div style="margin: 10px 15px 20px 0px;">
                        <telerik:RadComboBox ID="DropPreset" runat="server" AutoPostBack="true" Width="400" SkinID="RadComboBoxStandard">
                        </telerik:RadComboBox>
                    </div>
                    <div style="margin: 0px 15px 0px 0px;">
                    <asp:Button ID="BtnAddTasks" runat="server" Text="Add Tasks" />
                    <asp:Button ID="ButtonSaveAsTemplate" runat="server" Text="Save as Template" ToolTip="Save the current Schedule's tasks as a template" />
                    </div>
                </div>
            </div>           
        </div>       
    </div>
    <div style="float: left;">
         <telerik:RadGrid ID="RadGridQuickAdd" runat="server" AllowMultiRowSelection="True"
        AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
        EnableEmbeddedSkins="True" Width="99%">
        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
        <ClientSettings EnablePostBackOnRowClick="False">
            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
            <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
        </ClientSettings>
        <MasterTableView DataKeyNames="ROWID" TableLayout="auto">
            <Columns>
                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" />
                </telerik:GridClientSelectColumn>
                <telerik:GridBoundColumn DataField="TRF_PRESET_DESC" HeaderText="Preset" UniqueName="colTRF_PRESET_DESC">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PHASE_DESC" HeaderText="Phase" UniqueName="colPHASE_DESC">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FNC_CODE" HeaderText="Task Code" UniqueName="colFNC_CODE">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TRF_DESC" HeaderText="Task Description" UniqueName="colTRF_DESC">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_ORDER" HeaderText="Order" UniqueName="colTRF_PRESET_ORDER">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtTRF_PRESET_ORDER" runat="server" SkinID="TextBoxStandard"
                            MaxLength="4" Text='<%#Eval("TRF_PRESET_ORDER") %>' Width="70"></asp:TextBox>
                        <asp:HiddenField ID="HFPhaseID" runat="server" Value='<%#Eval("TRAFFIC_PHASE_ID") %>' />
                        <asp:HiddenField ID="HFRoleCode" runat="server" Value='<%#Eval("DEF_TRF_ROLE") %>' />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_DAYS" HeaderText="Days" UniqueName="colTRF_PRESET_DAYS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtTRF_PRESET_DAYS" runat="server" SkinID="TextBoxStandard"
                            MaxLength="3" Text='<%#Eval("TRF_PRESET_DAYS") %>' Width="70"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="TRF_PRESET_HRS" HeaderText="Hours" UniqueName="colTRF_PRESET_HRS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtTRF_PRESET_HRS" runat="server" SkinID="TextBoxStandard"
                            MaxLength="6" Text='<%#Eval("TRF_PRESET_HRS") %>' Width="80"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="RUSH_DAYS" HeaderText="<span class='rushheader'>Days</span>"
                    UniqueName="colRUSH_DAYS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtRUSH_DAYS" runat="server" SkinID="TextBoxStandard"
                            MaxLength="3" Text='<%#Eval("RUSH_DAYS") %>' Width="80"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="RUSH_HOURS" HeaderText="<span class='rushheader'>Hours</span>"
                    UniqueName="colRUSH_HOURS">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
                    <ItemTemplate>
                        <asp:TextBox ID="TxtRUSH_HOURS" runat="server" SkinID="TextBoxStandard"
                            MaxLength="6" Text='<%#Eval("RUSH_HOURS") %>' Width="80"></asp:TextBox>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn DataField="MILESTONE" HeaderText="M/S" UniqueName="colMILESTONE">
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" VerticalAlign="middle" />
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
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
    </div>
   
</asp:Content>
