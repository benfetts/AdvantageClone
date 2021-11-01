Public Class TrafficScheduleVersion_New
    Inherits Webvantage.BaseChildPage

#Region " Constants "

#End Region

#Region " Enum "

    Private Enum FormMode
        [New]
        [Edit]
    End Enum

#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _VersionId As Integer = 0
    Private _FormMode As FormMode = FormMode.New

#End Region

#Region " Properties "

#End Region

#Region " Page "

    Private Sub TrafficScheduleVersion_New_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNumber = qs.JobComponentNumber
        Me._VersionId = qs.TrafficScheduleVersionID

        If Me._VersionId > 0 Then

            Me._FormMode = FormMode.Edit
            Me.HiddenFieldLoadedVersionId.Value = Me._VersionId

        End If

    End Sub
    Private Sub TrafficScheduleVersion_New_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.TrLastApplied.Visible = False

            If Me._FormMode = FormMode.Edit Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Dim EditVersion As AdvantageFramework.Database.Entities.JobTrafficVersion = Nothing
                    EditVersion = AdvantageFramework.Database.Procedures.JobTrafficVersion.LoadByVersionID(DbContext, Me._VersionId)

                    If Not EditVersion Is Nothing Then

                        Me.HiddenFieldLoadedVersionId.Value = EditVersion.ID
                        Me.TextBoxVersionName.Text = EditVersion.VersionName
                        Me.TextBoxVersionDescription.Text = EditVersion.VersionComment
                        Me.LabelCreatedDate.Text = LoGlo.FormatDate(EditVersion.VersionCreatedDate) & " by " & EditVersion.VersionCreatedByUserCode
                        Me.TextBoxCreatedComment.Text = EditVersion.VersionCreatedComment
                        Me.TextBoxCreatedComment.Enabled = False

                    End If

                    AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.JobTrafficVersion.Properties.VersionName, Me.TextBoxVersionName)
                    AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.JobTrafficVersion.Properties.VersionName, Me.TextBoxCopyVersionName)

                    'quick test
                    Try

                        Dim MyDatatable As DataTable
                        MyDatatable = New System.Data.DataTable

                        Using MySqlCommand = DbContext.CreateCommand()

                            MySqlCommand.CommandType = CommandType.Text
                            MySqlCommand.CommandText = "SELECT TOP 1 * FROM JOB_TRAFFIC_VER_LOG WITH(NOLOCK) WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND VERSION_ID = @VERSION_ID AND LAST_APPLIED_COMMENT NOT LIKE 'CREATED%' ORDER BY LAST_APPLIED_DATE DESC;"

                            MySqlCommand.Parameters.AddWithValue("@JOB_NUMBER", Me._JobNumber)
                            MySqlCommand.Parameters.AddWithValue("@JOB_COMPONENT_NBR", Me._JobComponentNumber)
                            MySqlCommand.Parameters.AddWithValue("@VERSION_ID", Me._VersionId)

                            MySqlCommand.Connection.Open()

                            Try

                                MyDatatable.Load(MySqlCommand.ExecuteReader)

                            Catch ex As Exception

                            Finally

                                MySqlCommand.Connection.Close()

                            End Try

                        End Using

                        If Not MyDatatable Is Nothing AndAlso MyDatatable.Rows.Count > 0 Then

                            Me.TrLastApplied.Visible = True
                            Me.LabelLastApplied.Text = MyDatatable.Rows(0)("LAST_APPLIED_BY_USER_CODE").ToString() & " on " &
                                                CType(MyDatatable.Rows(0)("LAST_APPLIED_DATE"), DateTime).ToShortDateString() & " " & CType(MyDatatable.Rows(0)("LAST_APPLIED_DATE"), DateTime).ToShortTimeString()
                            Me.LabelLastApplied.ToolTip = MyDatatable.Rows(0)("LAST_APPLIED_COMMENT").ToString()

                        End If

                    Catch ex As Exception

                        Me.TrLastApplied.Visible = False

                    End Try

                End Using

                Me.RadToolbarJobTrafficVersion.FindItemByValue("copy").Visible = True
                Me.RadToolbarJobTrafficVersion.FindItemByValue("RadToolBarSeparatorCopy").Visible = True

            Else

                Me.RadToolbarJobTrafficVersion.FindItemByValue("copy").Visible = False
                Me.RadToolbarJobTrafficVersion.FindItemByValue("RadToolBarSeparatorCopy").Visible = False

            End If

            Me.DivCopy.Visible = False 'Me._FormMode = FormMode.Edit

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub ButtonCancelCopy_Click(sender As Object, e As EventArgs) Handles ButtonCancelCopy.Click

        Me.SetNoCopy()

    End Sub
    Private Sub ButtonSaveCopy_Click(sender As Object, e As EventArgs) Handles ButtonSaveCopy.Click

        Me.Copy()

    End Sub
    Private Sub RadToolbarJobTrafficVersion_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobTrafficVersion.ButtonClick
        Select Case e.Item.Value
            Case "save"

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    If Me._FormMode = FormMode.New Then

                        Dim NewVersion As AdvantageFramework.Database.Entities.JobTrafficVersion = Nothing
                        NewVersion = New AdvantageFramework.Database.Entities.JobTrafficVersion

                        NewVersion.DbContext = DbContext
                        NewVersion.VersionCreatedByUserCode = Me._Session.UserCode
                        NewVersion.VersionSequenceNumber = 0
                        NewVersion.VersionName = Me.TextBoxVersionName.Text
                        NewVersion.VersionComment = Me.TextBoxVersionDescription.Text
                        NewVersion.VersionCreatedComment = Me.TextBoxCreatedComment.Text
                        NewVersion.JobNumber = Me._JobNumber
                        NewVersion.JobComponentNumber = Me._JobComponentNumber
                        NewVersion.VersionIsActive = True

                        If AdvantageFramework.Database.Procedures.JobTrafficVersion.Insert(DbContext, NewVersion) = True Then

                            Me.CloseThisWindowAndRefreshCaller("TrafficScheduleVersion.aspx")

                        End If

                    ElseIf Me._FormMode = FormMode.Edit Then

                        Dim UpdateVersion As AdvantageFramework.Database.Entities.JobTrafficVersion = Nothing
                        UpdateVersion = AdvantageFramework.Database.Procedures.JobTrafficVersion.LoadByVersionID(DbContext, Me._VersionId)

                        If Not UpdateVersion Is Nothing Then

                            UpdateVersion.VersionName = Me.TextBoxVersionName.Text
                            UpdateVersion.VersionComment = Me.TextBoxVersionDescription.Text
                            UpdateVersion.VersionIsActive = True

                            AdvantageFramework.Database.Procedures.JobTrafficVersion.Update(DbContext, UpdateVersion)

                            Me.CloseThisWindowAndRefreshCaller("TrafficScheduleVersion.aspx")

                        End If

                    End If

                End Using

            Case "copy"

                If Me.DivCopy.Visible = False Then

                    Me.TextBoxCopyVersionName.Text = Me.TextBoxVersionName.Text
                    Me.TextBoxCopyVersionDescription.Text = Me.TextBoxVersionDescription.Text
                    Me.TextBoxCopyCreatedComment.Text = Me.TextBoxCreatedComment.Text
                    Me.DivCopy.Visible = True

                    Me.TextBoxVersionName.Enabled = False
                    Me.TextBoxVersionDescription.Enabled = False
                    Me.TextBoxCreatedComment.Enabled = False
                    Me.RadToolbarJobTrafficVersion.FindItemByValue("copy").Enabled = False

                Else

                    Me.SetNoCopy()

                End If

        End Select
    End Sub

#End Region

#Region " Methods "

    Private Sub Copy()

        Using MyObjectContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Try

                Dim NewVersionId As Integer = 0

                NewVersionId = AdvantageFramework.Database.Procedures.JobTrafficVersion.Copy(MyObjectContext, Me._Session.UserCode,
                                                                                             Me.TextBoxCopyVersionName.Text,
                                                                                             Me.TextBoxCopyVersionDescription.Text, Me.TextBoxCopyCreatedComment.Text, Me._VersionId)

                If NewVersionId > 0 Then

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.TrafficScheduleVersionID = NewVersionId
                    qs.Page = "TrafficScheduleVersion_New.aspx"

                    MiscFN.ResponseRedirect(qs.ToString(True), True)

                End If

            Catch ex As Exception

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End Try

        End Using

    End Sub
    Private Sub SetNoCopy()

        Me.TextBoxCopyVersionName.Text = ""
        Me.TextBoxCopyVersionDescription.Text = ""
        Me.TextBoxCopyCreatedComment.Text = ""
        Me.DivCopy.Visible = False

        Me.TextBoxVersionName.Enabled = True
        Me.TextBoxVersionDescription.Enabled = True

        If Me._FormMode = FormMode.New Then

            Me.TextBoxCreatedComment.Enabled = True

        End If

        Me.RadToolbarJobTrafficVersion.FindItemByValue("copy").Enabled = True

    End Sub

#End Region

End Class
