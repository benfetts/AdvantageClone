Public Class Maintenance_ProjectScheduleTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Properties "



#End Region

#Region " Variables "



#End Region

#Region " Page "



#End Region

#Region " Controls "

    Private Sub CheckBoxShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridProjectScheduleTemplateMaintenance.Rebind()

    End Sub

    Private Sub ImageButtonExport_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExport.Click

        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Phases As IQueryable(Of AdvantageFramework.Database.Entities.Phase) = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Name")
        DataTable.Columns.Add("Is Inactive")

        Me.RadGridProjectScheduleTemplateMaintenance.AllowPaging = False

        Me.RadGridProjectScheduleTemplateMaintenance.Rebind()

        For Each GridDataItem In Me.RadGridProjectScheduleTemplateMaintenance.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Name

            If GridDataItem.DataItem.IsInactive Then

                NewDataRow(1) = "YES"

            Else

                NewDataRow(1) = "NO"

            End If

        Next

        DataView = New DataView(DataTable)

        GridView = New GridView

        GridView.DataSource = DataView
        GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("Phases.xls", GridView) <--- This doesn' work
        Me.DeliverGrid(DataTable, "Project_Schedule_Templates") '<--- This does, please don't change unless you test!!!!

        Me.RadGridProjectScheduleTemplateMaintenance.AllowPaging = True

        Me.RadGridProjectScheduleTemplateMaintenance.Rebind()

    End Sub

    Private Sub RadGridProjectScheduleTemplateMaintenance_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProjectScheduleTemplateMaintenance.ItemCommand

        Dim CurrentRow As Telerik.Web.UI.GridDataItem
        CurrentRow = e.Item

        If Not CurrentRow Is Nothing Then

            Dim TemplateId As Integer = 0

            TemplateId = CurrentRow.GetDataKeyValue("ID")

            Select Case e.CommandName

                Case "DeleteRow"

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Dim t As AdvantageFramework.Database.Entities.JobTrafficTemplate
                        t = AdvantageFramework.Database.Procedures.JobTrafficTemplate.LoadByJobTrafficTemplateID(DbContext, TemplateId)

                        If Not t Is Nothing Then

                            If AdvantageFramework.Database.Procedures.JobTrafficTemplate.Delete(DbContext, t) = True Then

                                Me.RadGridProjectScheduleTemplateMaintenance.Rebind()

                            End If

                        End If

                    End Using

                Case "SaveAll"

                Case "SaveRow"

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Dim t As AdvantageFramework.Database.Entities.JobTrafficTemplate
                        t = AdvantageFramework.Database.Procedures.JobTrafficTemplate.LoadByJobTrafficTemplateID(DbContext, TemplateId)

                        If Not t Is Nothing Then

                            t.Name = CType(CurrentRow.FindControl("TextBoxTemplateName"), TextBox).Text.Trim()
                            t.IsInactive = CType(CurrentRow.FindControl("CheckBoxInactive"), CheckBox).Checked

                            If AdvantageFramework.Database.Procedures.JobTrafficTemplate.Update(DbContext, t) = True Then

                                Me.RadGridProjectScheduleTemplateMaintenance.Rebind()

                            End If

                        End If

                    End Using

            End Select

        End If

    End Sub
    Private Sub RadGridProjectScheduleTemplateMaintenance_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectScheduleTemplateMaintenance.ItemDataBound

    End Sub
    Private Sub RadGridProjectScheduleTemplateMaintenance_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjectScheduleTemplateMaintenance.NeedDataSource

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficTemplate)

            If Me.CheckBoxShowInactive.Checked = True Then

                list = AdvantageFramework.Database.Procedures.JobTrafficTemplate.Load(DbContext).ToList()

            Else

                list = AdvantageFramework.Database.Procedures.JobTrafficTemplate.LoadAllActive(DbContext).ToList()

            End If

            If Not list Is Nothing Then

                Me.RadGridProjectScheduleTemplateMaintenance.DataSource = list

            End If

        End Using

    End Sub

#End Region

#Region " Methods "



#End Region


End Class