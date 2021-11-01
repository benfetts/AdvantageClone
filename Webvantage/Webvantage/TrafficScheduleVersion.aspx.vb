Public Class TrafficScheduleVersion
    Inherits Webvantage.BaseChildPage


#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0

#End Region

#Region " Properties "

#End Region

#Region " Page "

    Private Sub TrafficScheduleVersion_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNumber = qs.JobComponentNumber

    End Sub
    Private Sub TrafficScheduleVersion_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            'Using MyObjectContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            '    Try

            '        Using MySqlCommand = MyObjectContext.CreateCommand()

            '            MySqlCommand.CommandType = CommandType.StoredProcedure
            '            MySqlCommand.CommandText = "usp_wv_TrafficScheduleVersion_InsertOriginal"

            '            MySqlCommand.Parameters.AddWithValue("@JOB_NUMBER", Me._JobNumber)
            '            MySqlCommand.Parameters.AddWithValue("@JOB_COMPONENT_NBR", Me._JobComponentNumber)
            '            MySqlCommand.Parameters.AddWithValue("@USER_CODE", Me._Session.UserCode)

            '            MySqlCommand.Connection.Open()

            '            Try

            '                MySqlCommand.ExecuteNonQuery()

            '            Catch ex As Exception

            '            Finally

            '                MySqlCommand.Connection.Close()

            '            End Try

            '        End Using

            '    Catch ex As Exception

            '    End Try

            'End Using

            'Me.BindGrid()

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub RadGridJobTrafficVersions_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobTrafficVersions.ItemCommand

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Dim row As Telerik.Web.UI.GridDataItem = e.Item

            If Me._JobNumber > 0 And Me._JobComponentNumber > 0 And IsNumeric(row.GetDataKeyValue("ID")) = True Then

                Select Case e.CommandName

                    Case "OpenEdit"

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        qs.JobNumber = Me._JobNumber
                        qs.JobComponentNumber = Me._JobComponentNumber
                        qs.TrafficScheduleVersionID = CType(row.GetDataKeyValue("ID"), Integer)
                        qs.Page = "TrafficScheduleVersion_New.aspx"

                        Me.OpenLookUp(qs.ToString(True))

                    Case "Apply"

                        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            If AdvantageFramework.Database.Procedures.JobTrafficVersion.Apply(DbContext, CType(row.GetDataKeyValue("ID"), Integer), Me._JobNumber, Me._JobComponentNumber, "", Me._Session.UserCode) = True Then

                                If Me.CurrentQuerystring.IsJobDashboard = True Then
                                    Me.CloseThisWindowAndRefreshCaller("Content.aspx")
                                Else
                                    Me.RefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
                                End If

                            End If

                        End Using

                    Case "Delete"

                        Using MyObjectContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            If AdvantageFramework.Database.Procedures.JobTrafficVersion.Delete(MyObjectContext, CType(row.GetDataKeyValue("ID"), Integer)) = True Then

                                'Me.BindGrid()
                                Me.RadGridJobTrafficVersions.Rebind()

                            End If

                        End Using

                End Select

            End If
        End If
    End Sub
    Private Sub RadGridJobTrafficVersions_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobTrafficVersions.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then

            Dim ApplyJobTrafficVersionLinkButton As System.Web.UI.WebControls.LinkButton
            ApplyJobTrafficVersionLinkButton = CType(e.Item.FindControl("LinkButtonApplyJobTrafficVersion"), LinkButton)

            If Not ApplyJobTrafficVersionLinkButton Is Nothing Then

                ApplyJobTrafficVersionLinkButton.Attributes("onclick") = "return confirm('Are you sure you want to make this version the current schedule?\n\nThe existing schedule will be deleted and replaced with the selected version!\n\nIf you have made changes to the current schedule, you may want to save it as a new version first.')"

            End If

            Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton
            DeleteImageButton = CType(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If Not DeleteImageButton Is Nothing Then

                DeleteImageButton.Attributes("onclick") = "return confirm('Are you sure you want to delete this Version?')"

            End If

        End If

    End Sub
    Private Sub RadGridJobTrafficVersions_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobTrafficVersions.NeedDataSource

        If Me._JobNumber > 0 And Me._JobComponentNumber > 0 Then

            Dim s As String = e.RebindReason.ToString()

            Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficVersion)

                list = AdvantageFramework.Database.Procedures.JobTrafficVersion.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber, False).ToList()
                Me.RadGridJobTrafficVersions.DataSource = list

            End Using

        End If

    End Sub

    Private Sub RadToolbarJobTrafficVersions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobTrafficVersions.ButtonClick
        Select Case e.Item.Value
            Case "New"
                If Me._JobNumber > 0 And Me._JobComponentNumber > 0 Then

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.Page = "TrafficScheduleVersion_New.aspx"

                    Me.OpenLookUp(qs.ToString(True))

                End If

        End Select
    End Sub

#End Region

#Region " Methods "

    'Private Sub BindGrid()

    '    If Me._JobNumber > 0 And Me._JobComponentNumber > 0 Then

    '        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

    '            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficVersion)

    '            list = AdvantageFramework.Database.Procedures.JobTrafficVersion.LoadByJobNumberAndJobComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber).ToList()
    '            Me.RadGridJobTrafficVersions.DataSource = list
    '            Me.RadGridJobTrafficVersions.DataBind()

    '        End Using

    '    End If

    'End Sub


#End Region

End Class
