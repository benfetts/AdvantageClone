<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="jobspecs_AddNew.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="" Inherits="Webvantage.jobspecs_AddNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockHeader" runat="server">
        <script type="text/javascript">

            $(document).ready(function () {
                $('#<%= txtComments.ClientID%>').keydown(function (e) {
                    
                });
            });
            
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <asp:Panel ID="pnlNewRevision" runat="server">
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Reason:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtReason" runat="server" TextMode="multiLine" Width="300px" MaxLength="70" SkinID="TextBoxStandard"
                    Rows="4" CssClass="RequiredInput"></asp:TextBox>
            </div>
        </div>

        <div class="code-description-container">
            <div class="code-description-label">
                Authorized by:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtAuthorizedBy" runat="server" Width="300px" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlQtyVendor" runat="server">
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:RadioButton ID="rbQty" runat="server" Text="Quantity" GroupName="QV" AutoPostBack="true" /><br />
                <asp:RadioButton ID="rbVen" runat="server" Text="Vendor" GroupName="QV" AutoPostBack="true" />
            </div>
        </div>
    </asp:Panel>
    <telerik:RadToolBar ID="RadToolBarVendor" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep1" />
            <telerik:RadToolBarButton Value="Save" ToolTip="Save" SkinID="RadToolBarButtonSave" TabIndex="1000" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Value="Cancel" ToolTip="Cancel" TabIndex="1001"  />
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep2" />
            <telerik:RadToolBarButton Text="Media Information" Value="MediaInformation"
                ToolTip="Media Information" TabIndex="1002"  />
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep3" />
            <telerik:RadToolBarButton Text="Media Delivery Information" Value="MediaDeliveryInformation"
                ToolTip="Media Delivery Information" TabIndex="1004"  />
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep4" />
            <telerik:RadToolBarButton Text="Media Specifications" Value="MediaSpecifications"
                ToolTip="Media Specifications" TabIndex="1005"  />
        </Items>
    </telerik:RadToolBar>
    <asp:Panel ID="pnlNewRowVendor1" runat="server">
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlVendor" runat="server" href="">Vendor:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtVendor" runat="server" CssClass="RequiredInput" TabIndex="7" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Close Date:
            </div>
            <div class="code-description-description">
                <telerik:RadDatePicker ID="RadDatePickerCloseDate" runat="server" TabIndex="8"
                    SkinID="RadDatePickerStandard">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Run Date:
            </div>
            <div class="code-description-description">
                <telerik:RadDatePicker ID="RadDatePickerRunDate" runat="server" TabIndex="9"
                    SkinID="RadDatePickerStandard">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Ext Date:
            </div>
            <div class="code-description-description">
                <telerik:RadDatePicker ID="RadDatePickerExtDate" runat="server" TabIndex="10"
                    SkinID="RadDatePickerStandard">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlADSize" runat="server" href="">Ad Size:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtADSize" runat="server" AutoPostBack="true" TabIndex="11" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Bleed Size:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtBleedSize" runat="server" MaxLength="40" TabIndex="12" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Trim Size:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtTrimSize" runat="server" MaxLength="40" TabIndex="13" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Live Area:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtLiveArea" runat="server" MaxLength="40" TabIndex="14" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Screen:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtScreen" runat="server" MaxLength="20" TabIndex="15" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Color:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtColor" runat="server" MaxLength="20" TabIndex="16" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlStatus" runat="server" href="">Status:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtStatus" runat="server" TabIndex="17" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlRegion" runat="server" href="">Region:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtRegion" runat="server" TabIndex="18" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Density:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtDensity" runat="server" MaxLength="25" TabIndex="19" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Film:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtFilm" runat="server" MaxLength="25" TabIndex="20" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Shipping Comments:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtShippingComments" runat="server" TextMode="MultiLine" Rows="4" TabIndex="21" SkinID="TextBoxStandard"
                    Width="300px"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Special Instructions:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtSpecialInstructions" runat="server" TextMode="MultiLine" Rows="4" TabIndex="22" SkinID="TextBoxStandard"
                    Width="300px"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNewRowVendor2" runat="server">        
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlVendor2" runat="server" href="">Vendor:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtVendor2" runat="server" CssClass="RequiredInput" TabIndex="2" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="hlADSize2" runat="server" href="">Ad Size:</asp:HyperLink>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtADSize2" runat="server" AutoPostBack="true" TabIndex="3" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Location of Sign:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtLocationSign" runat="server" TabIndex="4" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Overall Size:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtOverallSize" runat="server" TabIndex="5" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                Copy Area:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtCopyArea" runat="server" TabIndex="6" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNewRowQuantity" runat="server">
        <div class="code-description-container">
            <div>
                &nbsp;
            </div>
            <div class="code-description-label">
                Job Qty:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtJobQty" runat="server" CssClass="RequiredInput" MaxLength="10"  TabIndex="1" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlApproved" runat="server">
        <div style="margin-top: 10px;">
            <div class="form-layout">
                <ul>
                    <li>Approved By:</li>
                    <li><asp:TextBox ID="txtApprovedBy" runat="server" CssClass="RequiredInput" TabIndex="1" SkinID="TextBoxStandard"></asp:TextBox></li>
                </ul>
                <ul>
                    <li>Approval Date:</li>
                    <li><telerik:RadDatePicker ID="RadDatePickerApprovalDate" runat="server"
                            SkinID="RadDatePickerStandard" TabIndex="2">
                            <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar4" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker></li>
                </ul>
                <ul>
                    <li style="vertical-align: top;">Comment:</li>
                    <li><asp:TextBox ID="txtComments" Width="350px" runat="server" TextMode="MultiLine" Rows="4" TabIndex="3" SkinID="TextBoxStandard"></asp:TextBox></li>
                </ul>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlTextEdit" runat="server">
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:Label ID="lblField" runat="server" Width="98%"></asp:Label>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="txtField" Width="100%" runat="server" TextMode="MultiLine" Rows="25" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlJSNew" runat="server">
        <div class="code-description-container" style="text-align: center">
            <div class="code-description-label">
               &nbsp;
            </div>
            <div class="code-description-description">
                &nbsp;
            </div>
        </div>
        <div class="code-description-container" style="text-align: center">
            <div class="code-description-label">
                Select a template:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="ddJSTemplates" runat="server" Width="350" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlJSCopy" runat="server">
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlClientSource" runat="server" Text="Client:" href=""></asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="1" Text=""
                    SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlDivisionSource" runat="server" TabIndex="-1" Text="Division:"
                    href=""></asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="2" Text=""
                    SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1" Text="Product:"></asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="3" Text=""
                    SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1"
                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" Text="Job:" href=""></asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtJobNum" runat="server" MaxLength="6" TabIndex="4" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1"
                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
                <asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" Text="Component:" href=""></asp:HyperLink>
            </div>
            <div class="code-description-code">
                <asp:TextBox ID="TxtJobCompNum" runat="server" MaxLength="3" TabIndex="5" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1"
                    Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                <asp:HiddenField ID="hfContactCodeID" runat="server" />
            </div>
        </div>
        <div class="code-description-container">
            <div class="code-description-label">
            </div>
            <div class="code-description-description">
                <asp:Label ID="Label1" runat="server" CssClass="CssRequired" Text='' TabIndex="-1"></asp:Label>
            </div>
        </div>
    </asp:Panel>
    <div class="bottom-buttons">
        <asp:Button ID="btnNew" runat="server" Text="New" Visible="false" />
        <asp:Button ID="SaveButton" runat="server" Text="Save" />&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" />
        <asp:Button ID="btnCopyJS" runat="server" Text="Save" />
        <asp:Button ID="btnCopy" runat="server" Text="Copy" />&nbsp;
        <input id="CancelButton" runat="server" type="button" value="Cancel" visible="false" />
        <asp:Button ID="CancelButton2" runat="server" Text="Cancel" Visible="false" />
    </div>

</asp:Content>
