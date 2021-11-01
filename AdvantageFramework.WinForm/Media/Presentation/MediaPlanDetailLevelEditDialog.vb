Namespace Media.Presentation

    Public Class MediaPlanDetailLevelEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _Description As String = ""
        Private _TagType As Integer = 0
		Private _MappingType As Integer = 0
		Private _OrderNumber As Integer = 0

#End Region

#Region " Properties "

		Private ReadOnly Property Description As String
            Get
                Description = _Description
            End Get
        End Property
        Private ReadOnly Property TagType As Integer
            Get
                TagType = _TagType
            End Get
        End Property
        Private ReadOnly Property MappingType As Integer
            Get
                MappingType = _MappingType
            End Get
        End Property

#End Region

#Region " Methods "

		Private Sub New(FormAction As AdvantageFramework.WinForm.Presentation.FormActions, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
						 Description As String, TagType As Integer, MappingType As Integer, OrderNumber As Integer)

			' This call is required by the designer.
			InitializeComponent()

			Me.FormAction = FormAction
			_MediaPlan = MediaPlan
			_Description = Description
			_TagType = TagType
			_MappingType = MappingType
			_OrderNumber = OrderNumber

		End Sub

#Region "  Show Form Methods "

		Public Shared Function ShowFormDialog(FormAction As AdvantageFramework.WinForm.Presentation.FormActions, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
											  ByRef Description As String, ByRef TagType As Integer, ByRef MappingType As Integer, OrderNumber As Integer) As System.Windows.Forms.DialogResult

			'objects
			Dim MediaPlanDetailLevelEditDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelEditDialog = Nothing

			MediaPlanDetailLevelEditDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelEditDialog(FormAction, MediaPlan, Description, TagType, MappingType, OrderNumber)

			ShowFormDialog = MediaPlanDetailLevelEditDialog.ShowDialog()

			If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

				Description = MediaPlanDetailLevelEditDialog.Description
				TagType = MediaPlanDetailLevelEditDialog.TagType
				MappingType = MediaPlanDetailLevelEditDialog.MappingType

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub MediaPlanDetailLevelEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim TagTypes As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute) = Nothing
            Dim MappingTypes As Generic.List(Of AdvantageFramework.MediaPlanning.Attributes.EstimateTypeAttribute) = Nothing

            Try

                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Description)
                ComboBoxForm_TagType.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType)
                ComboBoxForm_MappingType.SetPropertySettings(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType)

                TagTypes = AdvantageFramework.MediaPlanning.LoadTagTypes
                MappingTypes = AdvantageFramework.MediaPlanning.LoadMappingTypes

                If _MediaPlan.MediaPlanEstimate.AllowCampaignLevel = False Then

                    TagTypes = TagTypes.Where(Function(Entity) Entity.Value <> AdvantageFramework.MediaPlanning.TagTypes.Campaign).ToList
                    MappingTypes = MappingTypes.Where(Function(Entity) Entity.Value <> AdvantageFramework.MediaPlanning.MappingTypes.Campaign).ToList

                End If

                If _MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                    TagTypes = TagTypes.Where(Function(Entity) Entity.Value <> AdvantageFramework.MediaPlanning.TagTypes.StartDate AndAlso
                                                               Entity.Value <> AdvantageFramework.MediaPlanning.TagTypes.EndDate).ToList

                End If

                Select Case _MediaPlan.MediaPlanEstimate.SalesClassType

                    Case "I"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.Internet = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.Internet = True).ToList

                    Case "M"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.Magazine = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.Magazine = True).ToList

                    Case "N"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.Newspaper = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.Newspaper = True).ToList

                    Case "O"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.OutOfHome = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.OutOfHome = True).ToList

                    Case "R"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.Radio = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.Radio = True).ToList

                    Case "T"

                        ComboBoxForm_TagType.DataSource = TagTypes.Where(Function(Entity) Entity.Television = True).ToList
                        ComboBoxForm_MappingType.DataSource = MappingTypes.Where(Function(Entity) Entity.Television = True).ToList

                    Case Else

                        ComboBoxForm_TagType.DataSource = TagTypes
                        ComboBoxForm_MappingType.DataSource = MappingTypes

                End Select

                TextBoxForm_Description.Text = _Description
                ComboBoxForm_TagType.SelectedValue = _TagType
                ComboBoxForm_MappingType.SelectedValue = _MappingType

                If ComboBoxForm_TagType.SelectedValue <> _TagType Then

                    ComboBoxForm_TagType.AddComboItemToExistingDataSource(AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.MediaPlanning.TagTypes), _TagType), _TagType, True)

                End If

                If ComboBoxForm_MappingType.SelectedValue <> _MappingType Then

                    ComboBoxForm_MappingType.AddComboItemToExistingDataSource(AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.MediaPlanning.MappingTypes), _MappingType), _MappingType, True)

                End If

                If Me.FormAction = WinForm.Presentation.FormActions.Adding Then

                    Me.Text = "Add " & Me.Text

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                Else

                    Me.Text = "Edit " & Me.Text

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                    ComboBoxForm_TagType.ReadOnly = True

                    If ComboBoxForm_TagType.HasASelectedValue AndAlso (ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.AdSize OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.Daypart OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.InternetType OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.Market OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.JobComponent OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.Campaign OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.MediaChannel OrElse
                            ComboBoxForm_TagType.SelectedValue = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic) Then

                        ComboBoxForm_MappingType.ReadOnly = True

                    End If

                    If _MediaPlan.SyncDetailSettings Then

                        If _MediaPlan.HasMediaOrder Then

                            ComboBoxForm_MappingType.ReadOnly = True

                        End If

                    Else

                        If _MediaPlan.MediaPlanEstimate.HasMediaOrder Then

                            ComboBoxForm_MappingType.ReadOnly = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = String.Empty
            Dim HasDuplicateTagType As Boolean = False
            Dim HasDuplicateMappingType As Boolean = False
            Dim Message As String = Nothing

            TextBoxForm_Description.Text = TextBoxForm_Description.Text.Trim

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            ElseIf Me.Validator Then

                If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.MediaPlanning.DataColumns), False).Any(Function(DataColumnName) DataColumnName.ToUpper = TextBoxForm_Description.Text.ToUpper) = False Then

                    If ComboBoxForm_TagType.GetSelectedValue <> AdvantageFramework.MediaPlanning.TagTypes.Default AndAlso
                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                            _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.TagType = ComboBoxForm_TagType.GetSelectedValue) Then

                        HasDuplicateTagType = True

                    End If

                    If HasDuplicateTagType = False Then

                        If ComboBoxForm_MappingType.GetSelectedValue <> AdvantageFramework.MediaPlanning.MappingTypes.None AndAlso
                                _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                                _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.MappingType = ComboBoxForm_MappingType.GetSelectedValue) Then

                            HasDuplicateMappingType = True

                        End If

                        If HasDuplicateMappingType = False Then

                            If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Any(Function(DC) DC.ColumnName.ToUpper = TextBoxForm_Description.Text.ToUpper) = False Then

                                _Description = TextBoxForm_Description.GetText
                                _TagType = ComboBoxForm_TagType.GetSelectedValue
                                _MappingType = ComboBoxForm_MappingType.GetSelectedValue

                                Me.ClearChanged()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Please enter a unique description.")

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a mapping type that has not been used.")

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a tag type that has not been used.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("This description is used internally. Please enter a different description.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Message As String = Nothing

            TextBoxForm_Description.Text = TextBoxForm_Description.Text.Trim

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            ElseIf Me.Validator Then

                If AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.MediaPlanning.DataColumns), False).Any(Function(DataColumnName) DataColumnName.ToUpper = TextBoxForm_Description.Text.ToUpper) = False Then

					If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Any(Function(DC) DC.ColumnName.ToUpper = TextBoxForm_Description.Text.ToUpper AndAlso
																																	   DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) <> _OrderNumber) = False Then

						_Description = TextBoxForm_Description.GetText
						_TagType = ComboBoxForm_TagType.GetSelectedValue
						_MappingType = ComboBoxForm_MappingType.GetSelectedValue

						Me.ClearChanged()

						Me.DialogResult = Windows.Forms.DialogResult.OK
						Me.Close()

					Else

						AdvantageFramework.WinForm.MessageBox.Show("Please enter a unique description.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("This description is used internally. Please enter a different description.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_TagType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_TagType.SelectedValueChanged

            'objects
            Dim DisableMappingType As Boolean = True

            If ComboBoxForm_TagType.HasASelectedValue Then

                Select Case ComboBoxForm_TagType.SelectedValue

                    Case AdvantageFramework.MediaPlanning.TagTypes.AdSize

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.AdSizeDescription)

                    Case AdvantageFramework.MediaPlanning.TagTypes.Market

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.Market)

                    Case AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.MarketOrderLine)

                    Case AdvantageFramework.MediaPlanning.TagTypes.InternetType

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.InternetType)

                    Case AdvantageFramework.MediaPlanning.TagTypes.Daypart

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.Daypart)

                    Case AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.OutOfHomeType)

                    Case AdvantageFramework.MediaPlanning.TagTypes.AdNumber

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.AdNumber)

                    Case AdvantageFramework.MediaPlanning.TagTypes.JobComponent

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.JobComponent)

                    Case AdvantageFramework.MediaPlanning.TagTypes.Campaign

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.Campaign)

                    Case AdvantageFramework.MediaPlanning.TagTypes.MediaChannel

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.MediaChannel)

                    Case AdvantageFramework.MediaPlanning.TagTypes.MediaTactic

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.MediaTactic)

                    Case AdvantageFramework.MediaPlanning.TagTypes.Default

                        ComboBoxForm_MappingType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.MappingTypes.[None])
                        DisableMappingType = False

                    Case Else

                        DisableMappingType = False

                End Select

                ComboBoxForm_MappingType.ReadOnly = DisableMappingType

            End If

        End Sub
        Private Sub ComboBoxForm_MappingType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_MappingType.SelectedValueChanged

            If ComboBoxForm_MappingType.HasASelectedValue Then

                Select Case ComboBoxForm_MappingType.SelectedValue

                    Case AdvantageFramework.MediaPlanning.MappingTypes.InternetType

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.InternetType)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.OutOfHomeType

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.AdNumber

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.AdNumber)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.Market

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.Market)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.MarketOrderLine

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.MarketOrderLine)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.Daypart

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.Daypart)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.JobComponent

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.JobComponent)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.Campaign

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.Campaign)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.MediaChannel

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.MediaChannel)

                    Case AdvantageFramework.MediaPlanning.MappingTypes.MediaTactic

                        ComboBoxForm_TagType.SelectedValue = CInt(AdvantageFramework.MediaPlanning.TagTypes.MediaTactic)

                End Select

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
