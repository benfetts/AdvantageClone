Namespace Media.Presentation

    Public Class MediaPlanDetailLevelsAndLinesCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _MediaPlanDetailID As Integer = 0
        Private _SyncDetailSettings As Boolean = False
        Private _SalesClassType As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanID = MediaPlanID
            _MediaPlanDetailID = MediaPlanDetailID

        End Sub
        Private Sub LoadEstimates()

            'objects
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            StartDate = CDate(DateTimePickerForm_StartDate.Value.ToShortDateString)
            EndDate = CDate(DateTimePickerForm_EndDate.Value)

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If _SyncDetailSettings Then

                        DataGridViewForm_MediaPlanDetails.DataSource = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("SalesClass").Include("MediaPlan").
                                                                                                                              Where(Function(Entity) Entity.MediaPlanID = _MediaPlanID AndAlso Entity.ID <> _MediaPlanDetailID AndAlso
                                                                                                                                                     Entity.SalesClassType = _SalesClassType).ToList.
                                                                                                                              OrderByDescending(Function(Entity) Entity.MediaPlan.StartDate).
                                                                                                                              Select(Function(Entity) New With {.[MediaPlanID] = Entity.MediaPlanID,
                                                                                                                                                                .[MediaPlan] = Entity.MediaPlan.Description,
                                                                                                                                                                .[ID] = Entity.ID,
                                                                                                                                                                .[Estimate] = Entity.Name,
                                                                                                                                                                .[SalesClassType] = Entity.SalesClassType,
                                                                                                                                                                .[SalesClass] = If(Entity.SalesClass IsNot Nothing, Entity.SalesClass.ToString, Nothing),
                                                                                                                                                                .[StartDate] = Entity.MediaPlan.StartDate,
                                                                                                                                                                .[EndDate] = Entity.MediaPlan.EndDate}).ToList

                    Else

                        If CheckBoxForm_ShowEsitmatesForAllMediaTypes.Checked Then

                            DataGridViewForm_MediaPlanDetails.DataSource = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("SalesClass").Include("MediaPlan").
                                                                                                                                  Where(Function(Entity) Entity.ID <> _MediaPlanDetailID AndAlso Entity.MediaPlan.StartDate >= StartDate AndAlso
                                                                                                                                                         Entity.MediaPlan.StartDate <= EndDate).ToList.
                                                                                                                                  OrderByDescending(Function(Entity) Entity.MediaPlan.StartDate).
                                                                                                                                  Select(Function(Entity) New With {.[MediaPlanID] = Entity.MediaPlanID,
                                                                                                                                                                    .[MediaPlan] = Entity.MediaPlan.Description,
                                                                                                                                                                    .[ID] = Entity.ID,
                                                                                                                                                                    .[Estimate] = Entity.Name,
                                                                                                                                                                    .[SalesClassType] = Entity.SalesClassType,
                                                                                                                                                                    .[SalesClass] = If(Entity.SalesClass IsNot Nothing, Entity.SalesClass.ToString, Nothing),
                                                                                                                                                                    .[StartDate] = Entity.MediaPlan.StartDate,
                                                                                                                                                                    .[EndDate] = Entity.MediaPlan.EndDate}).ToList

                        Else

                            DataGridViewForm_MediaPlanDetails.DataSource = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("SalesClass").Include("MediaPlan").
                                                                                                                                  Where(Function(Entity) Entity.ID <> _MediaPlanDetailID AndAlso Entity.MediaPlan.StartDate >= StartDate AndAlso
                                                                                                                                                         Entity.MediaPlan.StartDate <= EndDate AndAlso Entity.SalesClassType = _SalesClassType).ToList.
                                                                                                                                  OrderByDescending(Function(Entity) Entity.MediaPlan.StartDate).
                                                                                                                                  Select(Function(Entity) New With {.[MediaPlanID] = Entity.MediaPlanID,
                                                                                                                                                                    .[MediaPlan] = Entity.MediaPlan.Description,
                                                                                                                                                                    .[ID] = Entity.ID,
                                                                                                                                                                    .[Estimate] = Entity.Name,
                                                                                                                                                                    .[SalesClassType] = Entity.SalesClassType,
                                                                                                                                                                    .[SalesClass] = If(Entity.SalesClass IsNot Nothing, Entity.SalesClass.ToString, Nothing),
                                                                                                                                                                    .[StartDate] = Entity.MediaPlan.StartDate,
                                                                                                                                                                    .[EndDate] = Entity.MediaPlan.EndDate}).ToList

                        End If

                    End If

                End Using

            Catch ex As Exception

            End Try

            DataGridViewForm_MediaPlanDetails.MakeColumnNotVisible("MediaPlanID")

            DataGridViewForm_MediaPlanDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadLevelAndLines()

            'objects
            Dim MediaPlanDetailID As Integer = 0
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            If DataGridViewForm_MediaPlanDetails.HasOnlyOneSelectedRow() Then

                Try

                    MediaPlanDetailID = DataGridViewForm_MediaPlanDetails.GetFirstSelectedRowBookmarkValue()

                Catch ex As Exception
                    MediaPlanDetailID = 0
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("MediaPlanDetailLevels").Include("MediaPlanDetailLevelLines").Include("MediaPlanDetailLevelLines.MediaPlanDetailLevel").SingleOrDefault(Function(Entity) Entity.ID = MediaPlanDetailID)

                    Catch ex As Exception
                        MediaPlanDetail = Nothing
                    End Try

                    If MediaPlanDetail IsNot Nothing Then

                        Try

                            DataTable = AdvantageFramework.MediaPlanning.BuildLevelLines(MediaPlanDetail)

                        Catch ex As Exception
                            DataTable = New System.Data.DataTable
                        End Try

                    End If

                End Using

            Else

                DataTable = New System.Data.DataTable

            End If

            DataGridViewForm_DetailsLevelLines.ClearGridCustomization()
            DataGridViewForm_DetailsLevelLines.ItemDescription = "Level/Line(s)"

            DataGridViewForm_DetailsLevelLines.DataSource = DataTable

            Try

                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString)
                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)
                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString)
                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)
                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString)
                DataGridViewForm_DetailsLevelLines.MakeColumnNotVisible(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString)

            Catch ex As Exception

            End Try

            DataGridViewForm_DetailsLevelLines.CurrentView.BestFitColumns()

            DataGridViewForm_DetailsLevelLines.SelectAll()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_MediaPlanDetails.HasOnlyOneSelectedRow() Then

                If DataGridViewForm_MediaPlanDetails.GetFirstSelectedRowCellValue("SalesClassType") <> _SalesClassType Then

                    CheckBoxForm_LevelsOnly.Checked = True
                    CheckBoxForm_LevelsOnly.Enabled = False

                Else

                    CheckBoxForm_LevelsOnly.Enabled = True

                End If

            Else

                CheckBoxForm_LevelsOnly.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailLevelsAndLinesCopyDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesCopyDialog = Nothing

            MediaPlanDetailLevelsAndLinesCopyDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesCopyDialog(MediaPlanID, MediaPlanDetailID)

            ShowFormDialog = MediaPlanDetailLevelsAndLinesCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailLevelsAndLinesCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaPlan As AdvantageFramework.Database.Entities.MediaPlan = Nothing

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_MediaPlanDetails.MultiSelect = False
            DataGridViewForm_MediaPlanDetails.ItemDescription = "Estimate(s)"
            DataGridViewForm_MediaPlanDetails.SetBookmarkColumnIndex(2)

            DataGridViewForm_DetailsLevelLines.MultiSelect = True

            DataGridViewForm_DetailsLevelLines.OptionsView.ShowFooter = False

            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowColumnMoving = True
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowSort = False
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowGroup = False
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowFilter = False
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_DetailsLevelLines.OptionsCustomization.AllowColumnResizing = True

            DataGridViewForm_DetailsLevelLines.ItemDescription = "Level/Line(s)"

            CheckBoxForm_IncludeData.Checked = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaPlan = AdvantageFramework.Database.Procedures.MediaPlan.LoadByMediaPlanID(DbContext, _MediaPlanID)

                    If MediaPlan IsNot Nothing Then

                        _SyncDetailSettings = MediaPlan.SyncDetailSettings

                        _SalesClassType = MediaPlan.MediaPlanDetails.Where(Function(DTL) DTL.ID = _MediaPlanDetailID).FirstOrDefault.SalesClassType

                        If _SyncDetailSettings Then

                            DateTimePickerForm_StartDate.Enabled = False
                            DateTimePickerForm_EndDate.Enabled = False
                            CheckBoxForm_ShowEsitmatesForAllMediaTypes.Enabled = False
                            CheckBoxForm_LevelsOnly.SecurityEnabled = False
                            ButtonForm_Filter.Enabled = False

                        Else

                            DateTimePickerForm_StartDate.Enabled = True
                            DateTimePickerForm_EndDate.Enabled = True
                            CheckBoxForm_ShowEsitmatesForAllMediaTypes.Enabled = True
                            CheckBoxForm_LevelsOnly.SecurityEnabled = True
                            ButtonForm_Filter.Enabled = True

                            DateTimePickerForm_StartDate.Value = CDate(MediaPlan.StartDate.ToShortDateString)
                            DateTimePickerForm_EndDate.Value = CDate(MediaPlan.EndDate.ToShortDateString)

                        End If

                    End If

                End Using

            Catch ex As Exception

            End Try

            Try

                LoadEstimates()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanDetailLevelsAndLinesCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            LoadLevelAndLines()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim Copied As Boolean = False

			If DataGridViewForm_MediaPlanDetails.HasOnlyOneSelectedRow Then

				Me.FormAction = WinForm.Presentation.FormActions.Loading
				Me.ShowWaitForm()
				Me.ShowWaitForm("Copying...")

				Try

					If _SyncDetailSettings Then

						Copied = AdvantageFramework.MediaPlanning.CopyMediaPlanDetailDetailLines(Me.Session, _MediaPlanID, _MediaPlanDetailID, DataGridViewForm_MediaPlanDetails.GetFirstSelectedRowBookmarkValue, DataGridViewForm_DetailsLevelLines.CurrentView.GetSelectedRows, CheckBoxForm_IncludeData.Checked)

					Else

						If CheckBoxForm_LevelsOnly.Checked Then

							Copied = AdvantageFramework.MediaPlanning.CopyMediaPlanDetailDetailLevels(Me.Session, _MediaPlanID, _MediaPlanDetailID, DataGridViewForm_MediaPlanDetails.GetFirstSelectedRowBookmarkValue)

						Else

							Copied = AdvantageFramework.MediaPlanning.CopyMediaPlanDetailDetailLevelAndLines(Me.Session, _MediaPlanID, _MediaPlanDetailID, DataGridViewForm_MediaPlanDetails.GetFirstSelectedRowBookmarkValue, DataGridViewForm_DetailsLevelLines.CurrentView.GetSelectedRows, CheckBoxForm_IncludeData.Checked)

						End If

					End If

					If Copied Then

						Me.DialogResult = Windows.Forms.DialogResult.OK
						Me.Close()

					Else

						AdvantageFramework.WinForm.MessageBox.Show("Failed copying detail level and lines. Please contact Software Support.")

					End If

				Catch ex As Exception

				End Try

				Me.FormAction = WinForm.Presentation.FormActions.None
				Me.CloseWaitForm()

			Else

				AdvantageFramework.WinForm.MessageBox.Show("Please select a media plan detail\lines.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_MediaPlanDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_MediaPlanDetails.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadLevelAndLines()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonForm_Filter_Click(sender As Object, e As EventArgs) Handles ButtonForm_Filter.Click

            If Me.FormShown Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()
                Me.ShowWaitForm("Loading...")

                Try

                    LoadEstimates()

                Catch ex As Exception

                End Try

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub CheckBoxForm_LevelsOnly_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_LevelsOnly.CheckedChanged

            If Me.FormShown Then

                CheckBoxForm_IncludeData.Enabled = Not CheckBoxForm_LevelsOnly.Checked
                DataGridViewForm_DetailsLevelLines.Enabled = Not CheckBoxForm_LevelsOnly.Checked

                If CheckBoxForm_LevelsOnly.Checked Then

                    DataGridViewForm_DetailsLevelLines.DeselectAll()

                    CheckBoxForm_IncludeData.Checked = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
