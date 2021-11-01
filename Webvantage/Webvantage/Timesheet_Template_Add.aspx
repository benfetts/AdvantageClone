<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Timesheet_Template_Add.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="New Template Item" Inherits="Webvantage.Timesheet_Template_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function sz(t) {
            //try {
            a = t.value.split('\n');
            b = 1;
            for (x = 0; x < a.length; x++) {
                if (a[x].length >= t.cols) b += Math.floor(a[x].length / t.cols);
            }
            b += a.length;
            if (b > t.rows) t.rows = b;
        }
        //} 
        //catch (err) { 

        //}
    </script>
</telerik:RadScriptBlock>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="margin-left: 25px;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <asp:Literal ID="LitScript" runat="server"></asp:Literal>
            <table style="width: 550px; border: 0; padding: 2px;">
                <tr>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlClient" runat="server" href="" TabIndex="-1" Target="_blank" Text="Client"></asp:HyperLink>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlDivision" runat="server" href="" TabIndex="-1" Target="_blank"
                            Text="Division"></asp:HyperLink>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlProduct" runat="server" href="" TabIndex="-1" Target="_blank"
                            Text="Product"></asp:HyperLink>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlJob" runat="server" href="" TabIndex="-1" Target="_blank" Text="Job"></asp:HyperLink>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlJobComp" runat="server" href="" TabIndex="-1" Target="_blank"
                            Text="Job Comp"></asp:HyperLink>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlFuncCat" runat="server" href="" TabIndex="-1" Target="_blank"
                            Text="Function/Category"></asp:HyperLink>
                    </td>
                    <td id="TdProductCategoryLabel" runat="server" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:HyperLink ID="hlProdCat" runat="server" href="" TabIndex="-1" Target="_blank" Text="Product Category"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtClient" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtDivision" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtProduct" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtJob" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtJobComp" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:TextBox ID="txtFuncCat" runat="server" CssClass="RequiredInput" MaxLength="10"
                            TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                    <td id="TdProductCategoryInput" runat="server" align="left" valign="top">
                        <asp:TextBox ID="txtProdCat" runat="server" MaxLength="10" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 550px; border: 0; padding: 2px;">
                <tr style="display: none !important;">
                    <td colspan="2" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px; display: none !important;">
                        Department:
                    </td>
                </tr>
                <tr style="display: none !important;">
                    <td colspan="2" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px; display: none !important;">
                        <telerik:RadComboBox ID="RadComboBoxDepartment" runat="server">
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        Default Comment:
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        Hours:
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <telerik:RadTextBox ID="RadTextBoxDefaultComment" runat="server" TextMode="MultiLine"
                            Height="80px" Width="480px">
                        </telerik:RadTextBox>
                    </td>
                    <td style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <telerik:RadNumericTextBox ID="RadNumericTextBoxHours" runat="server" AllowOutOfRangeAutoCorrect="true"
                            MaxValue="24" MinValue="0" Width="40" Style="text-align: right;">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step=".25" />
                            <NumberFormat DecimalDigits="2" />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="2" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        Apply To Days:
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="2" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <asp:CheckBoxList ID="CheckBoxListDays" runat="server" RepeatDirection="Horizontal"
                            RepeatLayout="Flow" Visible="true">
                            <asp:ListItem Text="Sun" Value="Sun"></asp:ListItem>
                            <asp:ListItem Text="Mon" Value="Mon"></asp:ListItem>
                            <asp:ListItem Text="Tue" Value="Tue"></asp:ListItem>
                            <asp:ListItem Text="Wed" Value="Wed"></asp:ListItem>
                            <asp:ListItem Text="Thu" Value="Thu"></asp:ListItem>
                            <asp:ListItem Text="Fri" Value="Fri"></asp:ListItem>
                            <asp:ListItem Text="Sat" Value="Sat"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: left; vertical-align: top; padding: 2px; margin: 2px;">
                        <div style="text-align: right; margin-top: 30px;">
                            <div class="k-button-group">
                                <asp:Button ID="ButtonCancel" runat="server" Text="Close" />&nbsp;
                                <asp:Button ID="ButtonClear" runat="server" Text="Clear"  />&nbsp;
                                <asp:Button ID="ButtonSave" runat="server" Text="Save"  />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
