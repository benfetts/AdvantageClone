Namespace Media.Presentation

	Public Class MediaPlanMasterPlanSetupForm

#Region " Constants "



#End Region

#Region " Enum "

		Private Enum Columns
			[Client]
			[Plan]
			[Estimate]
			[MediaType]
			[SalesClass]
			[EntryDate]
			[Dollars]
			[BillAmount]
			[GrossBudgetAmount]
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
		Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_MasterPlans.DataSource = AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.Load(DbContext).ToList

            End Using

            DataGridViewLeftSection_MasterPlans.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                MediaPlanMasterPlanRightSide_MasterPlan.ClearControl()

                MediaPlanMasterPlanRightSide_MasterPlan.Enabled = DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow

                If MediaPlanMasterPlanRightSide_MasterPlan.Enabled Then

                    MediaPlanMasterPlanRightSide_MasterPlan.Enabled = MediaPlanMasterPlanRightSide_MasterPlan.LoadControl(DataGridViewLeftSection_MasterPlans.GetFirstSelectedRowBookmarkValue)

                End If

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            MediaPlanMasterPlanRightSide_MasterPlan.Enabled = (DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            ButtonItemActions_Add.Enabled = True
            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_MasterPlans.HasASelectedRow()
            ButtonItemActions_Print.Enabled = DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow()
            ButtonItemActions_Refresh.Enabled = True

            ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow()
            ButtonItemPrintingOptions_GroupByMediaTypes.Enabled = DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow()
            ButtonItemPrintingOptions_ShowHiatusDates.Enabled = DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow()

            RibbonBarOptions_Dashboard.Visible = (MediaPlanMasterPlanRightSide_MasterPlan.TabControlControl_MasterPlanDetails.SelectedTab Is MediaPlanMasterPlanRightSide_MasterPlan.TabItemMasterPlanDetails_DashboardTab AndAlso MediaPlanMasterPlanRightSide_MasterPlan.Enabled)

            ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = MediaPlanMasterPlanRightSide_MasterPlan.AddColumnsHeadersToAllEstimatesEnabled

            If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

                ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = False

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        MediaPlanMasterPlanRightSide_MasterPlan.TextBoxTopSection_Comment.CheckSpelling()

                        IsOkay = False

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = MediaPlanMasterPlanRightSide_MasterPlan.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.CloseWaitForm()
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    MediaPlanMasterPlanRightSide_MasterPlan.TextBoxTopSection_Comment.CheckSpelling()

                    Me.ShowWaitForm("Saving...")
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                    Try

                        If MediaPlanMasterPlanRightSide_MasterPlan.Save() Then

                            Me.ClearChanged()

                            LoadGrid()

                        End If

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_MasterPlans.FocusToFindPanel(False)

                        DataGridViewLeftSection_MasterPlans.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a master plan to save.")

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaPlanMasterPlanSetupForm As AdvantageFramework.Media.Presentation.MediaPlanMasterPlanSetupForm = Nothing

            MediaPlanMasterPlanSetupForm = New AdvantageFramework.Media.Presentation.MediaPlanMasterPlanSetupForm

            MediaPlanMasterPlanSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanMasterPlanSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_Save.Image = My.Resources.SaveImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Print.Image = My.Resources.PrintImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage

            ButtonItemDashboard_Edit.Image = My.Resources.EditImage

            ButtonItemPrintingOptions_ShowHiatusDates.Image = My.Resources.SetHiatusImage
            ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Image = My.Resources.ShowAllColumnsImage
            ButtonItemPrintingOptions_GroupByMediaTypes.Image = My.Resources.MediaImage

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanMasterPlanSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewLeftSection_MasterPlans.FocusToFindPanel(True)

        End Sub
        Private Sub MediaPlanMasterPlanSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaPlanMasterPlanSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim MediaPlanMasterPlanID As Integer = 0

            If AdvantageFramework.Media.Presentation.MediaPlanMasterPlanAddDialog.ShowFormDialog(MediaPlanMasterPlanID) = System.Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrid()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If MediaPlanMasterPlanID <> 0 Then

                    DataGridViewLeftSection_MasterPlans.SelectRow(MediaPlanMasterPlanID)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim MediaPlanMasterPlanID As Integer = 0

            Save()

            Try

                MediaPlanMasterPlanID = DataGridViewLeftSection_MasterPlans.GetFirstSelectedRowBookmarkValue

            Catch ex As Exception
                MediaPlanMasterPlanID = 0
            End Try

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadGrid()

                EnableOrDisableActions()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            If MediaPlanMasterPlanID > 0 Then

                DataGridViewLeftSection_MasterPlans.SelectRow(MediaPlanMasterPlanID)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim MediaPlanMasterPlanID As Integer = 0
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim AllowDelete As Boolean = False

            If DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this master plan?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        MediaPlanMasterPlanID = DataGridViewLeftSection_MasterPlans.GetFirstSelectedRowBookmarkValue

                    Catch ex As Exception
                        MediaPlanMasterPlanID = 0
                    End Try

                    If MediaPlanMasterPlanID <> 0 Then

                        Me.FormAction = WinForm.Presentation.FormActions.Deleting
                        Me.ShowWaitForm("Deleting...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.DeleteByMediaPlanMasterPlanID(DbContext, MediaPlanMasterPlanID)

                            End Using

                        Catch ex As Exception

						End Try

						Me.FormAction = WinForm.Presentation.FormActions.Loading
						Me.ShowWaitForm("Loading...")

						Try

							LoadGrid()

							EnableOrDisableActions()

						Catch ex As Exception

						End Try

						If DataGridViewLeftSection_MasterPlans.HasRows = False Then

							MediaPlanMasterPlanRightSide_MasterPlan.ClearControl()

						End If

						Me.FormAction = WinForm.Presentation.FormActions.None
						Me.CloseWaitForm()

					End If

				End If

			End If

		End Sub
		Private Sub ButtonItemActions_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

			'objects
			Dim AddColumnsHeadersToAllEstimates As Boolean = False
			Dim MediaPlanMasterPlanID As Integer = 0
			Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing

			If DataGridViewLeftSection_MasterPlans.HasOnlyOneSelectedRow Then

				Try

					MediaPlanMasterPlanID = DataGridViewLeftSection_MasterPlans.GetFirstSelectedRowBookmarkValue

				Catch ex As Exception
					MediaPlanMasterPlanID = 0
				End Try

				If MediaPlanMasterPlanID <> 0 Then

					If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

						AddColumnsHeadersToAllEstimates = True

					Else

						AddColumnsHeadersToAllEstimates = ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked

					End If

					AdvantageFramework.Media.Presentation.PrintMasterPlan(Me.DefaultLookAndFeel.LookAndFeel, Me.Session, MediaPlanMasterPlanID, ButtonItemPrintingOptions_ShowHiatusDates.Checked, AddColumnsHeadersToAllEstimates, ButtonItemPrintingOptions_GroupByMediaTypes.Checked)

				End If

			End If

		End Sub
		Private Sub DataGridViewLeftSection_MasterPlans_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_MasterPlans.LeavingRowEvent

			If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

				e.Allow = CheckForUnsavedChanges()

			End If

		End Sub
		Private Sub DataGridViewLeftSection_MasterPlans_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_MasterPlans.SelectionChangedEvent

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				Me.ShowWaitForm()

				Try

					LoadSelectedItemDetails()

				Catch ex As Exception

				End Try

				Me.CloseWaitForm()

				EnableOrDisableActions()

			End If

		End Sub
		Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				If CheckForUnsavedChanges() Then

					Me.ShowWaitForm()

					Try

						LoadSelectedItemDetails()

					Catch ex As Exception

					End Try

					Me.CloseWaitForm()

					EnableOrDisableActions()

				End If

			End If

		End Sub
		Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

			MediaPlanMasterPlanRightSide_MasterPlan.EditDashboard()

		End Sub
		Private Sub MediaPlanMasterPlanRightSide_MasterPlan_EnableOrDisableActionsEvent() Handles MediaPlanMasterPlanRightSide_MasterPlan.EnableOrDisableActionsEvent

			EnableOrDisableActions()

		End Sub
		Private Sub MediaPlanMasterPlanRightSide_MasterPlan_EnableOrDisableAddColumnHeadersEvent() Handles MediaPlanMasterPlanRightSide_MasterPlan.EnableOrDisableAddColumnHeadersEvent

			ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = MediaPlanMasterPlanRightSide_MasterPlan.AddColumnsHeadersToAllEstimatesEnabled

			If ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Enabled = False Then

				ButtonItemPrintingOptions_AddColumnsHeadersToAllEstimates.Checked = False

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
