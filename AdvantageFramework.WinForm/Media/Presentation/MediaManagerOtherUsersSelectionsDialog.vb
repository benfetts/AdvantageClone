Namespace Media.Presentation

    Public Class MediaManagerOtherUsersSelectionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OtherUserSelections As Generic.List(Of MediaManager.Classes.OtherUserSelection) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal OtherUserSelections As Generic.List(Of MediaManager.Classes.OtherUserSelection))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _OtherUserSelections = OtherUserSelections

        End Sub
        Private Sub ApplyGrouping()

            Try

                DataGridViewMediaManager_Selections.OptionsView.ShowGroupedColumns = True
                DataGridViewMediaManager_Selections.Columns(AdvantageFramework.MediaManager.Classes.OtherUserSelection.Properties.EmployeeName.ToString).GroupIndex = 0
                DataGridViewMediaManager_Selections.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OtherUsersSelections As Generic.List(Of MediaManager.Classes.OtherUserSelection)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerOtherUsersSelectionsDialog As AdvantageFramework.Media.Presentation.MediaManagerOtherUsersSelectionsDialog = Nothing

            MediaManagerOtherUsersSelectionsDialog = New AdvantageFramework.Media.Presentation.MediaManagerOtherUsersSelectionsDialog(OtherUsersSelections)

            ShowFormDialog = MediaManagerOtherUsersSelectionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerOtherUsersSelectionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewMediaManager_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewMediaManager_Selections.DataSource = _OtherUserSelections
            DataGridViewMediaManager_Selections.CurrentView.BestFitColumns()

            ApplyGrouping()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Delete_Click(sender As Object, e As EventArgs) Handles ButtonForm_Delete.Click

            Dim OtherUserSelection As AdvantageFramework.MediaManager.Classes.OtherUserSelection = Nothing
            Dim SQLResult As Integer = -1

            If DataGridViewMediaManager_Selections.CurrentView.RowCount > 0 Then

                OtherUserSelection = DirectCast(DataGridViewMediaManager_Selections.CurrentView.GetRow(DataGridViewMediaManager_Selections.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.OtherUserSelection)

                If OtherUserSelection IsNot Nothing Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Delete media manager selection for user '" & OtherUserSelection.EmployeeName & "'?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            SQLResult = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC dbo.advsp_media_manager_delete_other_user_selection {0}", OtherUserSelection.UserID)).FirstOrDefault

                            If SQLResult = 0 Then

                                AdvantageFramework.WinForm.MessageBox.Show("Cannot delete selection, user is currently logged in.")

                            Else

                                _OtherUserSelections = AdvantageFramework.MediaManager.LoadOtherUserSelections(Session).ToList

                                DataGridViewMediaManager_Selections.DataSource = _OtherUserSelections

                                ApplyGrouping()

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace