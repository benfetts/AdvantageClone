Namespace Media.Presentation

    Public Class MediaPlanEstimateGRPBudgetAllocateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _Caption As String = Nothing
        Protected _TotalGRP As Decimal = 0
        Protected _PlanEstimateGRPBudgetAllocateSpotLengthPercents As Generic.List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent)

#End Region

#Region " Properties "

        Public ReadOnly Property TotalGRP As Decimal
            Get
                TotalGRP = _TotalGRP
            End Get
        End Property
        Public ReadOnly Property PlanEstimateGRPBudgetAllocateSpotLengthPercents As Generic.List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent)
            Get
                PlanEstimateGRPBudgetAllocateSpotLengthPercents = _PlanEstimateGRPBudgetAllocateSpotLengthPercents
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(Caption As String, TotalGRP As Decimal, PlanEstimateGRPBudgetAllocateSpotLengthPercents As Generic.List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Caption = Caption
            _TotalGRP = TotalGRP
            _PlanEstimateGRPBudgetAllocateSpotLengthPercents = PlanEstimateGRPBudgetAllocateSpotLengthPercents

        End Sub
        Private Function IsGridValid() As Boolean

            IsGridValid = _PlanEstimateGRPBudgetAllocateSpotLengthPercents.Count = 0 OrElse (Me.DataGridViewForm_LengthPercents.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent).Sum(Function(P) P.Percent) = 100.0)

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Caption As String, ByRef TotalGRP As Decimal,
                                              ByRef PlanEstimateGRPBudgetAllocateSpotLengthPercents As Generic.List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanEstimateGRPBudgetAllocateDialog As AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetAllocateDialog = Nothing

            MediaPlanEstimateGRPBudgetAllocateDialog = New AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetAllocateDialog(Caption, TotalGRP, PlanEstimateGRPBudgetAllocateSpotLengthPercents)

            ShowFormDialog = MediaPlanEstimateGRPBudgetAllocateDialog.ShowDialog()

            TotalGRP = MediaPlanEstimateGRPBudgetAllocateDialog.TotalGRP

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEstimateGRPBudgetAllocateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub MediaPlanEstimateGRPBudgetAllocateDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            Me.Text = _Caption
            Me.NumericInputForm_Input.SetRequired(True)

            DataGridViewForm_LengthPercents.DataSource = _PlanEstimateGRPBudgetAllocateSpotLengthPercents
            DataGridViewForm_LengthPercents.CurrentView.BestFitColumns()

            If DataGridViewForm_LengthPercents.CurrentView.Columns(AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent.Properties.SpotLength.ToString) IsNot Nothing Then

                DataGridViewForm_LengthPercents.CurrentView.Columns(AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent.Properties.SpotLength.ToString).OptionsColumn.AllowFocus = False

            End If

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                If IsGridValid() Then

                    _TotalGRP = Me.NumericInputForm_Input.GetValue
                    _PlanEstimateGRPBudgetAllocateSpotLengthPercents = Me.DataGridViewForm_LengthPercents.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent).ToList

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Percent totals must equal 100.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub DataGridViewForm_GRPBudget_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_LengthPercents.ShowingEditorEvent

            If DataGridViewForm_LengthPercents.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent.Properties.SpotLength.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
