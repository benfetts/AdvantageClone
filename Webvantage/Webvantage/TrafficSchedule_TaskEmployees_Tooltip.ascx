<%@ Control AutoEventWireup="false" Codebehind="TrafficSchedule_TaskEmployees_Tooltip.ascx.vb" Inherits="Webvantage.TrafficSchedule_TaskEmployees_Tooltip"
    Language="vb" %>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" Width="400px">
    <Columns>
        <asp:BoundField DataField="EMP_NAME" HeaderText="Employee" ReadOnly="True">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="<div align='right'>Hours Allowed</div>">
            <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" Width="100" />
            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Width="100" />
            <ItemTemplate>
            <div align="right"><%#Eval("HOURS_ALLOWED")%></div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<div align='right'>Completed</div>">
            <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" Width="100" />
            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Width="100" />
            <ItemTemplate>
                <div align="right">
                    <%#String.Format("{0:M/d/yyyy }", Eval("TEMP_COMP_DATE"))%>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField DataField="TEMP_COMP_DATE" DataFormatString="{0:M/d/yyyy }" HeaderText="Completed"
            ReadOnly="True" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right">
            <HeaderStyle HorizontalAlign="right" VerticalAlign="Middle" Width="80" />
            <ItemStyle HorizontalAlign="right" VerticalAlign="Middle" Width="80" />
        </asp:BoundField>--%>
    </Columns>
    <EmptyDataTemplate>
        No records found.
    </EmptyDataTemplate>
</asp:GridView>
<asp:Label   ID="LblMSG" runat="server" Text=""></asp:Label>
