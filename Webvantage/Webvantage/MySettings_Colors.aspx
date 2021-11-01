<%@ Page Title="Simple Layout Colors" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MySettings_Colors.aspx.vb" Inherits="Webvantage.MySettings_Colors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="padding: 8px;">
        <div style="margin-bottom: 10px;display:none;">
            <h4>
                Color Combos
            </h4>
            <div style="margin-top: 4px;">
                <telerik:RadComboBox ID="RadComboBoxColorCombos" runat="server">
                    <ItemTemplate>
                        <div style="width:200px; height:75px;display:block;">
                            <div style='width: 150px; height: 75px; background-color: <%# DataBinder.Eval(Container, "PrimaryColor")%>'></div>
                            <div style='width: 50px; height: 75px; float: left; background-color: <%# DataBinder.Eval(Container, "SecondaryColor")%>'></div>
                        </div>
                    </ItemTemplate>
                </telerik:RadComboBox>
            </div>
        </div>
        <div style="margin-bottom: 10px;">
            <h4>
                Workspace color
            </h4>
            <div style="margin-top: 4px;">
                <telerik:RadColorPicker ID="RadColorPickerBackground" runat="server">
                </telerik:RadColorPicker>
            </div>
        </div>
        <div style="margin-bottom: 10px;">
            <h4>
                Sidebar color
            </h4>
            <div style="margin-top:4px;">
                <telerik:RadColorPicker ID="RadColorPickerSideBar" runat="server">
                </telerik:RadColorPicker>
            </div>
        </div>
        <div style="margin-bottom: 10px;">
            <h4>
                Icon Style
            </h4>
            <div style="margin-top: 4px;">
                <asp:RadioButtonList ID="RadioButtonListIconStyle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="White" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Dark Grey" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div style="margin-bottom: 10px;">
            <h4>Left Side bar:
            </h4>
            <div style="margin-top: 4px;">
                <asp:CheckBox ID="CheckBoxShowNewMenu" runat="server" Text="Show Aqua Menu" /><asp:CheckBox ID="CheckBoxShowApplicationsMenu" runat="server" Text="Show Modules Menu" />
            </div>
        </div>
        <div>
            <div style="float:left;">
               <asp:Button ID="ButtonSave" runat="server" Text="Save" />
            </div>
            <div style="float: left;margin-left:5px;">
                <asp:Button ID="ButtonGoToMySettings" runat="server" Text="Go to My Settings" />
            </div>
        </div>
    </div>
</asp:Content>
