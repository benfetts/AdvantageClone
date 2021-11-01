Namespace Media.Presentation

    Public Class MediaPlanDetailLevelLineDataFillDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData
            Get
                MediaPlanDetailLevelLineData = _MediaPlanDetailLevelLineData
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlan = MediaPlan

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByRef MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailLevelLineDataFillDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog = Nothing

            MediaPlanDetailLevelLineDataFillDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineDataFillDialog(MediaPlan)

            ShowFormDialog = MediaPlanDetailLevelLineDataFillDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                MediaPlanDetailLevelLineData = MediaPlanDetailLevelLineDataFillDialog.MediaPlanDetailLevelLineData

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailLevelLineDataFillDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing

            If _MediaPlan IsNot Nothing Then

                PropertyGridForm_Data.SelectedObject = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                For Each BaseRow In PropertyGridForm_Data.Rows(0).ChildRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                    BaseRow.Visible = False

                Next

                For Each MediaPlanDetailField In _MediaPlan.MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                    Try

                        BaseRow = PropertyGridForm_Data.Rows(0).ChildRows.GetRowByFieldName(MediaPlanDetailField.FieldID)

                    Catch ex As Exception
                        BaseRow = Nothing
                    End Try

                    If BaseRow IsNot Nothing Then

                        PropertyGridForm_Data.MoveRow(BaseRow, PropertyGridForm_Data.Rows(0).ChildRows(MediaPlanDetailField.AreaIndex), True)

                        If MediaPlanDetailField.IsVisible Then

                            BaseRow.Visible = MediaPlanDetailField.IsVisible
                            BaseRow.Properties.Caption = MediaPlanDetailField.Caption

                        End If

                        If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n1"

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n1"

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n0"

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n0"

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n0"

                            If (_MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T") Then

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = 999999
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 6

                            Else

                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxValue = Integer.MaxValue
                                CType(BaseRow.Properties.RowEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput).MaxLength = 10

                            End If

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n2"

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "n2"

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "c2"

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "c2"
                            'BaseRow.Properties.ReadOnly = _MediaPlan.MediaPlanEstimate.CalculateDollars

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "c2"

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                            BaseRow.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric
                            BaseRow.Properties.Format.FormatString = "c2"

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                            BaseRow.Visible = False

                        ElseIf MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

                            BaseRow.Visible = True

                        End If

                    End If

                Next

                For Each BaseRow In PropertyGridForm_Data.Rows(0).ChildRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.BaseRow).ToList

                    If (BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString OrElse
                            BaseRow.Properties.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) = False Then

                        BaseRow.Visible = False

                    End If

                Next

            End If

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                _MediaPlanDetailLevelLineData = PropertyGridForm_Data.SelectedObject

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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

#End Region

#End Region

    End Class

End Namespace
