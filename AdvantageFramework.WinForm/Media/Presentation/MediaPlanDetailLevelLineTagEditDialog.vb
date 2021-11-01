Namespace Media.Presentation

	Public Class MediaPlanDetailLevelLineTagEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
		Private _MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
		Private _MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
		Private _TagType As AdvantageFramework.MediaPlanning.TagTypes = MediaPlanning.TagTypes.Market
        Private _HasAccessToMaintenanceModule As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel, ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine)

			' This call is required by the designer.
			InitializeComponent()

			_MediaPlan = MediaPlan
			_MediaPlanDetailLevel = MediaPlanDetailLevel
			_MediaPlanDetailLevelLine = MediaPlanDetailLevelLine

		End Sub
		Private Sub EnableOrDisableActions()

			DataGridViewForm_Tags.Enabled = RadioButtonForm_ByValue.Checked
            'CheckBoxForm_ChangeDescription.Enabled = RadioButtonForm_ByValue.Checked

            ButtonForm_Add.Visible = _HasAccessToMaintenanceModule AndAlso RadioButtonForm_ByValue.Checked

        End Sub
        Private Sub CloseDialog()

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            Try

                DataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = _MediaPlanDetailLevelLine.RowIndex)

            Catch ex As Exception
                DataRow = Nothing
            End Try

            If DataRow IsNot Nothing Then

                DataRow(_MediaPlanDetailLevel.Description) = _MediaPlanDetailLevelLine.Description

            End If

            For Each MPDLLD In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = _MediaPlanDetailLevelLine.RowIndex).ToList

                MPDLLD.ModifiedByUserCode = Me.Session.UserCode
                MPDLLD.ModifiedDate = Now

            Next

            Me.ClearChanged()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel, ByVal MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) As Windows.Forms.DialogResult

			'objects
			Dim MediaPlanDetailLevelLineTagEditDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagEditDialog = Nothing

			MediaPlanDetailLevelLineTagEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagEditDialog(MediaPlan, MediaPlanDetailLevel, MediaPlanDetailLevelLine)

			ShowFormDialog = MediaPlanDetailLevelLineTagEditDialog.ShowDialog()

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaPlanDetailLevelLineTagEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim FilterString As String = ""
			Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing

			Me.ShowUnsavedChangesOnFormClosing = False

			DataGridViewForm_Tags.MultiSelect = False
			DataGridViewForm_Tags.OptionsView.ShowFooter = False

			'CheckBoxForm_ChangeDescription.Checked = True

			Me.FormAction = WinForm.Presentation.FormActions.Loading

			Try

				If _MediaPlan IsNot Nothing Then

					If _MediaPlanDetailLevelLine IsNot Nothing Then

						Try

							If _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

								MediaPlanDetailLevelLineTag = _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault()

							End If

						Catch ex As Exception
							MediaPlanDetailLevelLineTag = Nothing
						End Try

						_TagType = _MediaPlanDetailLevel.TagType

                        If _TagType = AdvantageFramework.MediaPlanning.TagTypes.Market Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(_MediaPlan.DbContext)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.MarketCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_MarketTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(_MediaPlan.DbContext)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.MarketCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_MarketOrderLineTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(_MediaPlan.DbContext, Me.Session)).Where(Function(ECore) ECore.VendorCategory <> "P" AndAlso ECore.VendorCategory <> "Z")

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.VendorCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_VendorTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(_MediaPlan.DbContext)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.MediaType & "|" & MediaPlanDetailLevelLineTag.SizeCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_AdSizeTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            _HasAccessToMaintenanceModule = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_AdSize)

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.InternetType Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.InternetType.LoadAllActive(_MediaPlan.DbContext)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.InternetTypeCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_InternetTypeTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.Daypart.LoadAllActive(_MediaPlan.DbContext).Include("DaypartType")

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.DaypartID)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_DaypartTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.OutOfHomeType.LoadAllActive(_MediaPlan.DbContext)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.OutOfHomeTypeCode)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_OutOfHomeTypeTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdNumber Then

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.Ad.LoadAllActiveByClientCodeAndNotExpired(_MediaPlan.DbContext, _MediaPlan.ClientCode)

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.AdNumber)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_AdNumberTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            _HasAccessToMaintenanceModule = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AdNumber)

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.JobComponent Then

                            DataGridViewForm_Tags.ItemDescription = "Job/Component(s)"

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpenByClientCode(_MediaPlan.DbContext, _MediaPlan.ClientCode).ToList.Select(Function(JobComponent) New With {.ID = JobComponent.JobNumber & "|" & JobComponent.JobComponentNumber,
                                                                                                                                                                                                                                               .JobNumber = JobComponent.JobNumber,
                                                                                                                                                                                                                                               .JobDescription = JobComponent.JobDescription,
                                                                                                                                                                                                                                               .Number = JobComponent.JobComponentNumber,
                                                                                                                                                                                                                                               .Description = JobComponent.JobComponentDescription})

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.JobNumber & "|" & MediaPlanDetailLevelLineTag.JobComponentNumber)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_JobComponentTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            DataGridViewForm_Tags.MakeColumnNotVisible("ID")

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Campaign Then

                            DataGridViewForm_Tags.ItemDescription = "Campaign(s)"

                            DataGridViewForm_Tags.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.Load(_MediaPlan.DbContext).Where(Function(Entity) ((Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode = _MediaPlan.DivisionCode AndAlso Entity.ProductCode = _MediaPlan.ProductCode) OrElse
                                                                                                                                                                                  (Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode = _MediaPlan.DivisionCode AndAlso Entity.ProductCode Is Nothing) OrElse
                                                                                                                                                                                  (Entity.ClientCode = _MediaPlan.ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)) AndAlso
                                                                                                                                                                                 (Entity.IsClosed Is Nothing OrElse Entity.IsClosed = 0)).ToList
                                                                Where Entity.CampaignType = 2 AndAlso
                                                                      ((Entity.StartDate.HasValue = False OrElse Entity.EndDate.HasValue = False) OrElse
                                                                       (_MediaPlan.StartDate >= Entity.StartDate.GetValueOrDefault(_MediaPlan.StartDate) AndAlso _MediaPlan.StartDate <= Entity.EndDate.GetValueOrDefault(_MediaPlan.EndDate)) OrElse
                                                                       (_MediaPlan.EndDate >= Entity.StartDate.GetValueOrDefault(_MediaPlan.StartDate) AndAlso _MediaPlan.EndDate <= Entity.EndDate.GetValueOrDefault(_MediaPlan.EndDate)))
                                                                Select Entity.ID,
                                                                       Entity.Code,
                                                                       Entity.Name).ToList.Select(Function(Campaign) New With {.ID = Campaign.ID,
                                                                                                                               .Code = Campaign.Code,
                                                                                                                               .Name = Campaign.Name}).ToList

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.CampaignID)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_CampaignTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            DataGridViewForm_Tags.MakeColumnNotVisible("ID")

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaChannel Then

                            DataGridViewForm_Tags.ItemDescription = "Media Channel(s)"

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.MediaChannel.Load(_MediaPlan.DbContext).Where(Function(Entity) Entity.IsInactive = False).ToList

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.MediaChannelID)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_MediaChannelTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            DataGridViewForm_Tags.MakeColumnNotVisible("ID")

                        ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic Then

                            DataGridViewForm_Tags.ItemDescription = "Media Tactic(s)"

                            DataGridViewForm_Tags.DataSource = AdvantageFramework.Database.Procedures.MediaTactic.Load(_MediaPlan.DbContext).Where(Function(Entity) Entity.IsInactive = False).ToList

                            If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                DataGridViewForm_Tags.SelectRow(MediaPlanDetailLevelLineTag.MediaTacticID)

                            End If

                            Try

                                FilterString = _MediaPlan.MediaPlanEstimate.Filter_MediaTacticTagType

                            Catch ex As Exception
                                FilterString = ""
                            End Try

                            DataGridViewForm_Tags.MakeColumnNotVisible("ID")

                        End If

						RadioButtonForm_None.Checked = False
						RadioButtonForm_ByValue.Checked = True

                        DataGridViewForm_Tags.CurrentView.BestFitColumns()

						If String.IsNullOrEmpty(FilterString) = False Then

							DataGridViewForm_Tags.CurrentView.AFActiveFilterString = FilterString

						Else

							If _TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor Then

								DataGridViewForm_Tags.CurrentView.AFActiveFilterString = "[VendorCategory] = '" & _MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code & "'"

							ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize Then

								DataGridViewForm_Tags.CurrentView.AFActiveFilterString = "[MediaType] = '" & _MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code & "'"

							ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart Then

								Try

									If _MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Television).Code Then

										DataGridViewForm_Tags.CurrentView.AFActiveFilterString = "[DaypartType] = 'Local TV'"

									ElseIf _MediaPlan.MediaPlanEstimate.SalesClassTypeEnumObject.Code = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.SalesClassMediaType.Radio).Code Then

										DataGridViewForm_Tags.CurrentView.AFActiveFilterString = "[DaypartType] = 'Local Radio'"

									End If

								Catch ex As Exception

								End Try

							End If

						End If

						EnableOrDisableActions()

					Else

						AdvantageFramework.WinForm.MessageBox.Show("The detail level line you are trying to edit does not exist anymore.")
						Me.Close()

					End If

				Else

					AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
					Me.Close()

				End If

			Catch ex As Exception

			End Try

			Me.FormAction = WinForm.Presentation.FormActions.None

		End Sub
		Private Sub MediaPlanDetailLevelLineTagEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

			DataGridViewForm_Tags.FocusToFindPanel(False)

		End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim AdSizeID As String = ""
            Dim AdSizeCode As String = ""
            Dim MediaType As String = ""
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim ErrorMessage As String = Nothing
            Dim JobComponentID As String = ""
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If Me.Validator Then

                If RadioButtonForm_None.Checked OrElse DataGridViewForm_Tags.HasOnlyOneSelectedRow Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Adding...")

                    Try

                        If _MediaPlanDetailLevelLine IsNot Nothing Then

                            Try

                                If _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag = _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault()

                                End If

                            Catch ex As Exception
                                MediaPlanDetailLevelLineTag = Nothing
                            End Try

                            If RadioButtonForm_None.Checked Then

                                _MediaPlanDetailLevelLine.Description = ""

                                If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                    _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)
                                    _MediaPlan.MediaPlanEstimate.GetEntity().MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                                    End If

                                End If

                            Else

                                If MediaPlanDetailLevelLineTag Is Nothing Then

                                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                    MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext

                                    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(_MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                End If

                                If _TagType = AdvantageFramework.MediaPlanning.TagTypes.Market Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.MarketCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.MarketCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.MarketCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.MarketCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.VendorCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.VendorCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    '_MediaPlanDetailLevelLine.PackageName = String.Empty
                                    '_MediaPlanDetailLevelLine.PackageParent = False

                                    'End If

                                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaPlanDetailLevelLineTag.VendorCode)

                                    End Using

                                    If Vendor IsNot Nothing Then

                                        MediaPlanDetailLevelLineTag.VendorCommission = Vendor.Commission
                                        MediaPlanDetailLevelLineTag.VendorMarkup = Vendor.Markup

                                    End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize Then

                                    AdSizeID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    If AdSizeID.Split("|").Length = 2 Then

                                        MediaType = AdSizeID.Split("|")(0)
                                        AdSizeCode = AdSizeID.Split("|")(1)

                                    End If

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.MediaType = MediaType
                                        MediaPlanDetailLevelLineTag.SizeCode = AdSizeCode

                                    Else

                                        MediaPlanDetailLevelLineTag.MediaType = MediaType
                                        MediaPlanDetailLevelLineTag.SizeCode = AdSizeCode

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(3)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.InternetType Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.InternetTypeCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.InternetTypeCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.DaypartID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.DaypartID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(2)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.OutOfHomeTypeCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.OutOfHomeTypeCode = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdNumber Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.AdNumber = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.AdNumber = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.JobComponent Then

                                    JobComponentID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    If JobComponentID.Split("|").Length = 2 Then

                                        Try

                                            JobNumber = CInt(JobComponentID.Split("|")(0))
                                            JobComponentNumber = CShort(JobComponentID.Split("|")(1))

                                        Catch ex As Exception
                                            JobNumber = 0
                                            JobComponentNumber = 0
                                        End Try

                                    End If

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.JobNumber = JobNumber
                                        MediaPlanDetailLevelLineTag.JobComponentNumber = JobComponentNumber

                                    Else

                                        MediaPlanDetailLevelLineTag.JobNumber = JobNumber
                                        MediaPlanDetailLevelLineTag.JobComponentNumber = JobComponentNumber

                                    End If

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1) & " - " & DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(2) & "/" & DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(3) & " - " & DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(4)

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Campaign Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.CampaignID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.CampaignID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(2)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaChannel Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.MediaChannelID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.MediaChannelID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic Then

                                    If MediaPlanDetailLevelLineTag.IsEntityBeingAdded() = False Then

                                        MediaPlanDetailLevelLineTag.MediaTacticID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    Else

                                        MediaPlanDetailLevelLineTag.MediaTacticID = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue

                                    End If

                                    'If CheckBoxForm_ChangeDescription.Checked Then

                                    _MediaPlanDetailLevelLine.Description = DataGridViewForm_Tags.GetFirstSelectedRowBookmarkValue(1)

                                    'End If

                                End If

                            End If

                            'If String.IsNullOrWhiteSpace(_MediaPlanDetailLevelLine.Description) = False Then

                            '    If _MediaPlanDetailLevelLine.Description.Length > 100 Then

                            '        _MediaPlanDetailLevelLine.Description = _MediaPlanDetailLevelLine.Description.Substring(0, 100)

                            '    End If

                            'End If

                            CloseDialog()

                        Else

                            Throw New Exception("Failed saving detail level line. Please contact Software support.")

                        End If

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select one item.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		Private Sub RadioButtonForm_None_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonForm_None.CheckedChanged

			If Me.FormShown Then

				If RadioButtonForm_None.Checked Then

					EnableOrDisableActions()

				End If

			End If

		End Sub
		Private Sub RadioButtonForm_ByValue_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonForm_ByValue.CheckedChanged

			If Me.FormShown Then

				If RadioButtonForm_ByValue.Checked Then

					EnableOrDisableActions()

				End If

			End If

		End Sub
		Private Sub DataGridViewForm_Tags_ColumnFilterChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Tags.ColumnFilterChangedEvent

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If _TagType = AdvantageFramework.MediaPlanning.TagTypes.Market Then

                    _MediaPlan.MediaPlanEstimate.Filter_MarketTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine Then

                    _MediaPlan.MediaPlanEstimate.Filter_MarketOrderLineTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor Then

                    _MediaPlan.MediaPlanEstimate.Filter_VendorTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize Then

                    _MediaPlan.MediaPlanEstimate.Filter_AdSizeTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.InternetType Then

                    _MediaPlan.MediaPlanEstimate.Filter_InternetTypeTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart Then

                    _MediaPlan.MediaPlanEstimate.Filter_DaypartTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType Then

                    _MediaPlan.MediaPlanEstimate.Filter_OutOfHomeTypeTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdNumber Then

                    _MediaPlan.MediaPlanEstimate.Filter_AdNumberTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.JobComponent Then

                    _MediaPlan.MediaPlanEstimate.Filter_JobComponentTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.Campaign Then

                    _MediaPlan.MediaPlanEstimate.Filter_CampaignTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaChannel Then

                    _MediaPlan.MediaPlanEstimate.Filter_MediaChannelTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic Then

                    _MediaPlan.MediaPlanEstimate.Filter_MediaTacticTagType = DataGridViewForm_Tags.CurrentView.AFActiveFilterString

                End If

			End If

		End Sub
		Private Sub DataGridViewForm_Tags_RowDoubleClickEvent() Handles DataGridViewForm_Tags.RowDoubleClickEvent

			ButtonForm_OK.PerformClick()

		End Sub
        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim Code As String = Nothing
            Dim Description As String = Nothing

            If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagAddDialog.ShowFormDialog(_TagType, _MediaPlan.ClientCode, _MediaPlan.MediaPlanEstimate.SalesClassType, Code, Description) = Windows.Forms.DialogResult.OK Then

                Try

                    If _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                        MediaPlanDetailLevelLineTag = _MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault()

                    End If

                Catch ex As Exception
                    MediaPlanDetailLevelLineTag = Nothing
                End Try

                If MediaPlanDetailLevelLineTag Is Nothing Then

                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                    MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext

                    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(_MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                End If

                If _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdSize Then

                    MediaPlanDetailLevelLineTag.MediaType = _MediaPlan.MediaPlanEstimate.SalesClassType
                    MediaPlanDetailLevelLineTag.SizeCode = Code

                    _MediaPlanDetailLevelLine.Description = Description

                ElseIf _TagType = AdvantageFramework.MediaPlanning.TagTypes.AdNumber Then

                    MediaPlanDetailLevelLineTag.AdNumber = Code

                    _MediaPlanDetailLevelLine.Description = Description

                End If

                CloseDialog()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace