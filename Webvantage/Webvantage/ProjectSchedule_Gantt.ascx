<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ProjectSchedule_Gantt.ascx.vb" Inherits="Webvantage.ProjectSchedule_Gantt" %>
<script type="text/javascript" src="Scripts/pako.min.js"></script>
<div style="width:100%;padding:5px;overflow:hidden;color:black !important;">
    <telerik:RadGantt ID="RadGanttSchedule" runat="server" SelectedView="WeekView" AutoGenerateColumns="True" Width="100%" ShowCurrentTimeMarker="true" ListWidth="400" EnablePdfExport="true">
        <Columns>
        </Columns>
        <DataBindings>
            <TasksDataBindings
                IdField="ID" 
                StartField="Start" EndField="End"
                OrderIdField="OrderID"
                TitleField="Title" PercentCompleteField="PercentComplete" />
        </DataBindings>
    </telerik:RadGantt>
</div>