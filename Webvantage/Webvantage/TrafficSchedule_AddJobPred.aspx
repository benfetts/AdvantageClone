<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_AddJobPred.aspx.vb" Inherits="Webvantage.TrafficSchedule_AddJobPred"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="New Project Schedule" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <style type="text/css">       
        .RadComboBox_Metro .rcbInput {
            height: 32px !important;
            font-size: 13px !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }
        .RadComboBox_Bootstrap .rcbInput {
            height: 32px !important;
            font-size: 13px !important;
            font-family: 'Open Sans', 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif !important;
        }

        .RadComboBoxDropDown_Metro {
            font-size: 13px !important;
        }

        .RadComboBoxDropDown_Bootstrap {
            font-size: 13px !important;
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
    <telerik:RadToolBar ID="RadToolbarJobPredessors" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton ID="RadToolbarButtonAdd" Text="Add Job Predecessors" Value="Add" ToolTip="Add Job Predecessors" />
        </Items>
    </telerik:RadToolBar>
    <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">        
        <tr>
            <td>
                <table align="center" border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td width="20px" style="padding-bottom: 5px">
                            <asp:Label ID="Label6" runat="server" Width="20px">Client:&nbsp;&nbsp;</asp:Label>
                        </td>
                        <td style="padding-bottom: 5px">
                            <telerik:RadComboBox ID="ClientDropDownList" runat="server" AutoPostBack="true" Width="400px" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-bottom: 5px">
                            <asp:Label ID="Label1" runat="server">Division:&nbsp;&nbsp;</asp:Label>
                        </td>
                        <td style="padding-bottom: 5px">
                            <telerik:RadComboBox ID="DivisionDropDownList" runat="server" AutoPostBack="true" Width="400px" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-bottom: 5px">
                            <asp:Label ID="Label2" runat="server">Product:&nbsp;&nbsp;</asp:Label>
                        </td>
                        <td style="padding-bottom: 5px">
                            <telerik:RadComboBox ID="ProductDropDownList" runat="server" AutoPostBack="true" Width="400px" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
       
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="center" valign="middle">                
                <telerik:RadGrid ID="RadGridJobs" runat="server" AllowMultiRowSelection="True"
                    AllowPaging="False" AllowFilteringByColumn="true" AllowSorting="False" AutoGenerateColumns="False"
                    EnableAJAX="False" GridLines="None" EnableEmbeddedSkins="True" 
                    GroupingSettings-CaseSensitive="false" Width="100%">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px">
                    </PagerStyle>
                    <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                    <ClientSettings EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                        <ClientEvents OnRowSelecting="CancelNonInputSelect" OnRowDeselecting="CancelNonInputSelect" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="JobNumber,Number" TableLayout="auto">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                <HeaderStyle HorizontalAlign="center" Width="10px" />
                                <ItemStyle HorizontalAlign="center" Width="10px" />
                            </telerik:GridClientSelectColumn>
                            <telerik:GridBoundColumn DataField="Client" HeaderText="Client" UniqueName="ColClient"
                                FilterControlWidth="91%" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false" AllowFiltering="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job Number" UniqueName="ColJOB_NUMBER"
                                FilterControlWidth="75" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250" DataType="System.Int32">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobDesc" HeaderText="Job Description" UniqueName="ColJOB_DESC"
                                FilterControlWidth="175" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Number" HeaderText="Component Number" UniqueName="ColJOB_COMPONENT_NBR"
                                FilterControlWidth="75" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Component Description" UniqueName="ColJOB_COMP_DESC"
                                FilterControlWidth="175" CurrentFilterFunction="Contains" AutoPostBackOnFilter="false"
                                ShowFilterIcon="True" FilterDelay="1250">
                                <HeaderStyle HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                            </telerik:GridBoundColumn>
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
