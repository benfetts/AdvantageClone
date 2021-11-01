<%@ Page Title="Client Aging Invoices" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" ValidateRequest="false"
    CodeBehind="ClientAging_Invoices.aspx.vb" Inherits="Webvantage.ClientAging_Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHead" runat="server">
        <script type="text/javascript">

            function updateCollectionNotes(sender) {
                var dataItem = findRelatedGridItem(sender);
                if (dataItem) {
                    $.ajax({
                        type: 'POST',
                        url: 'ClientAging_Invoices.aspx/UpdateCollectionNotes',
                        data: JSON.stringify({ "InvoiceNumber": dataItem.getDataKeyValue('InvoiceNo'), "SequenceNumber": dataItem.getDataKeyValue('InvoiceSeq'), "Notes": $(sender).val() }),
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (response) {

                        },
                        error: function (response) {
                            ShowMessage('There was a problem saving collection notes.');
                        }
                    });
                };
            };

            function findRelatedGridItem(sender) {
                var dataItems = $find('<%= RadGridCA.ClientID %>').get_masterTableView().get_dataItems();
                for (var i = 0; i < dataItems.length; i++) {
                    var dataItem = dataItems[i];
                    if ($(dataItem.get_element()).prop('id') === $(sender).closest('tr').prop('id')) {
                        return dataItem;
                    };
                };
                return;
            };

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table border="0" cellpadding="2" cellspacing="2" width="100%">
        <tr>
            <td align="left" valign="top">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
                <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="cbShowProducts" runat="server" Text="Show Products" AutoPostBack="true" />
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <telerik:RadGrid ID="RadGridCA" runat="server" AutoGenerateColumns="False" GridLines="None"
                    EnableEmbeddedSkins="True" Width="99%" AllowSorting="true" >
                    <MasterTableView DataKeyNames="ClientCode,ClientName,DivisionCode,ProductCode,InvoiceNo,InvoiceSeq,ManualInvoice" ClientDataKeyNames="InvoiceNo,InvoiceSeq">
                        <Columns>
                            <telerik:GridBoundColumn DataField="OfficeName" HeaderText="Office" UniqueName="column1"
                                ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OfficeCode" HeaderText="" UniqueName="column2"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ClientName" HeaderText="Client" UniqueName="column3"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="left"
                                ItemStyle-VerticalAlign="middle" ItemStyle-Width="10px" UniqueName="column20">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImgBtnClientContacts" runat="server" CommandArgument='<%#Eval("ClientCode")%>'
                                            CommandName="SetClientContacts" SkinID="ImageButtonClientContactWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="ClientCode" HeaderText="" UniqueName="column4"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DivisionName" HeaderText="Division" UniqueName="column16"
                                Display="false" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DivisionCode" HeaderText="" UniqueName="column17"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product" UniqueName="column18"
                                Display="false" ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ProductCode" HeaderText="" UniqueName="column19"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceDate" HeaderText="Invoice Date" UniqueName="column5"
                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueDate" HeaderText="Due Date" UniqueName="column12"
                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Right">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceNo" HeaderText="Invoice Number" UniqueName="column6"
                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="50px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceSeq" HeaderText="Invoice Seq" UniqueName="column7"
                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Right" ItemStyle-Width="10px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceAmt" HeaderText="Invoice Amount" UniqueName="column8"
                                ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Type" HeaderText="Type" UniqueName="column9"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SalesClassName" HeaderText="Sales Class" UniqueName="column10"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ARDescription" HeaderText="Reference" UniqueName="column11"
                                ItemStyle-HorizontalAlign="Left">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="Collection" HeaderText="Collection Notes" UniqueName="colNotesInput">
                                <ItemStyle HorizontalAlign="Left" CssClass="radgrid-textarea-column" />
                                <HeaderStyle CssClass="radgrid-textarea-column" />
                                <FooterStyle CssClass="radgrid-textarea-column" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxCollection" runat="server" TextMode="MultiLine" Text='<%# Eval("Collection") %>' onblur="updateCollectionNotes(this);" CssClass="radgrid-textarea"  SkinID="TextBoxStandard"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="JobNumber" HeaderText="" UniqueName="column13"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobDesc" HeaderText="" UniqueName="column23"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobCompNumber" HeaderText="" UniqueName="column14"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobCompDesc" HeaderText="" UniqueName="column15"
                                Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocuments">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar" id="DivDocuments" runat="server">
                                        <asp:ImageButton ID="ImageButtonDocuments" runat="server" CommandName="Documents" ToolTip="Invoice Documents" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
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
            </td>
        </tr>
    </table>
</asp:Content>
