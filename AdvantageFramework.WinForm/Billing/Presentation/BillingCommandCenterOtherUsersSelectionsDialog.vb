Namespace Billing.Presentation

    Public Class BillingCommandCenterOtherUsersSelectionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OtherUsersProductionSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersProductionSelection) = Nothing
        Private _OtherUsersMediaSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersMediaSelection) = Nothing
        Private _SelectMediaTab As Boolean = False
        Private _BillingCommandCenterIDForCurrentUser As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal OtherUsersProductionSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersProductionSelection),
                        ByVal OtherUsersMediaSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersMediaSelection),
                        ByVal SelectMediaTab As Boolean,
                        ByVal BillingCommandCenterIDForCurrentUser As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _OtherUsersProductionSelections = OtherUsersProductionSelections
            _OtherUsersMediaSelections = OtherUsersMediaSelections
            _SelectMediaTab = SelectMediaTab
            _BillingCommandCenterIDForCurrentUser = BillingCommandCenterIDForCurrentUser

        End Sub
        Private Sub ApplyGrouping()

            Try

                DataGridViewProduction_Selections.OptionsView.ShowGroupedColumns = True
                DataGridViewProduction_Selections.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection.Properties.EmployeeName).GroupIndex = 0
                DataGridViewProduction_Selections.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection.Properties.BatchName).GroupIndex = 1
                DataGridViewProduction_Selections.CurrentView.ExpandAllGroups()

                DataGridViewMedia_Selections.OptionsView.ShowGroupedColumns = True
                DataGridViewMedia_Selections.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection.Properties.EmployeeName).GroupIndex = 0
                DataGridViewMedia_Selections.Columns(AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection.Properties.BatchName).GroupIndex = 1
                DataGridViewMedia_Selections.CurrentView.ExpandAllGroups()

            Catch ex As Exception

            End Try

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal OtherUsersProductionSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersProductionSelection),
                                              ByVal OtherUsersMediaSelections As Generic.List(Of BillingCommandCenter.Database.Classes.OtherUsersMediaSelection),
                                              ByVal SelectMediaTab As Boolean,
                                              ByVal BillingCommandCenterIDForCurrentUser As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterOtherUsersSelectionsDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterOtherUsersSelectionsDialog = Nothing

            BillingCommandCenterOtherUsersSelectionsDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterOtherUsersSelectionsDialog(OtherUsersProductionSelections, OtherUsersMediaSelections, SelectMediaTab, BillingCommandCenterIDForCurrentUser)

            ShowFormDialog = BillingCommandCenterOtherUsersSelectionsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterOtherUsersSelectionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewProduction_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewProduction_Selections.DataSource = _OtherUsersProductionSelections
            DataGridViewProduction_Selections.CurrentView.BestFitColumns()

            DataGridViewMedia_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewMedia_Selections.DataSource = _OtherUsersMediaSelections
            DataGridViewMedia_Selections.CurrentView.BestFitColumns()

            ApplyGrouping()

        End Sub
        Private Sub BillingCommandCenterOtherUsersSelectionsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _SelectMediaTab Then

                TabControlForm_BillingSelections.SelectedTab = TabItemBillingSelections_MediaTab

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Delete_Click(sender As Object, e As EventArgs) Handles ButtonForm_Delete.Click

            Dim OtherUsersProductionSelection As BillingCommandCenter.Database.Classes.OtherUsersProductionSelection = Nothing
            Dim OtherUsersMediaSelection As BillingCommandCenter.Database.Classes.OtherUsersMediaSelection = Nothing
            Dim BillingUser As String = Nothing
            Dim BillingCommandCenterID As Nullable(Of Integer) = Nothing
            Dim BatchName As String = Nothing
            Dim Message As String = Nothing
            Dim ContinueDelete As Boolean = True
            Dim BillingUserCode As String = Nothing
            Dim IsUserLoggedIn As Boolean = False

            If TabControlForm_BillingSelections.SelectedTab.Equals(TabItemBillingSelections_ProductionTab) AndAlso DataGridViewProduction_Selections.CurrentView.RowCount > 0 Then

                OtherUsersProductionSelection = DirectCast(DataGridViewProduction_Selections.CurrentView.GetRow(DataGridViewProduction_Selections.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection)
                BillingUser = OtherUsersProductionSelection.BillingUserRaw
                BillingCommandCenterID = OtherUsersProductionSelection.BillingCommandCenterID
                BatchName = OtherUsersProductionSelection.BatchName
                BillingUserCode = OtherUsersProductionSelection.BillingUser

            ElseIf TabControlForm_BillingSelections.SelectedTab.Equals(TabItemBillingSelections_MediaTab) AndAlso DataGridViewMedia_Selections.CurrentView.RowCount > 0 Then

                OtherUsersMediaSelection = DirectCast(DataGridViewMedia_Selections.CurrentView.GetRow(DataGridViewMedia_Selections.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection)
                BillingUser = OtherUsersMediaSelection.BillingUserRaw
                BillingCommandCenterID = OtherUsersMediaSelection.BillingCommandCenterID
                BatchName = OtherUsersMediaSelection.BatchName
                BillingUserCode = OtherUsersMediaSelection.BillingUser

            End If

            If BillingUser IsNot Nothing AndAlso BillingCommandCenterID.HasValue Then

                Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        IsUserLoggedIn = BCCDbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT dbo.[advfn_is_user_logged_in]('{0}')", BillingUserCode)).FirstOrDefault

                        If IsUserLoggedIn Then

                            AdvantageFramework.WinForm.MessageBox.Show("Cannot delete selection, user is currently logged in.")

                        Else

                            If AdvantageFramework.BillingCommandCenter.OkayToDeleteBatch(BCCDbContext, DataContext, BillingCommandCenterID, BillingUser, BatchName, Message) Then

                                If Message IsNot Nothing AndAlso AdvantageFramework.WinForm.MessageBox.Show(Message,
                                                    AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, , Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2) = WinForm.MessageBox.DialogResults.No Then

                                    ContinueDelete = False

                                End If

                                If ContinueDelete Then

                                    Me.ShowWaitForm("Deleting...")

                                    AdvantageFramework.BillingCommandCenter.DeleteMediaSelection(Session, BillingCommandCenterID, BillingUser)

                                    AdvantageFramework.BillingCommandCenter.DeleteProductionSelection(Session, BillingCommandCenterID, BillingUser)

                                    If AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Delete(BCCDbContext, BillingCommandCenterID) Then

                                        DataGridViewProduction_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetOtherUsersProductionSelection(BCCDbContext, _BillingCommandCenterIDForCurrentUser).ToList

                                        DataGridViewMedia_Selections.DataSource = AdvantageFramework.BillingCommandCenter.GetOtherUsersMediaSelection(BCCDbContext, _BillingCommandCenterIDForCurrentUser).ToList

                                    Else

                                        AdvantageFramework.WinForm.MessageBox.Show("Failed to delete batch.")

                                    End If

                                    Me.CloseWaitForm()

                                End If

                            End If

                        End If

                    End Using

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace