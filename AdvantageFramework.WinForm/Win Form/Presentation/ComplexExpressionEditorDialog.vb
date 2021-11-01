Namespace WinForm.Presentation

    Public Class ComplexExpressionEditorDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ExpressionTypes
            [Boolean] = 5
            [DateTime] = 3
            [Decimal] = 2
            [Integer] = 1
            [String] = 4
        End Enum

#End Region

#Region " Variables "

        Private _GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        Private _GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
        Private _EnumProperty As [Enum] = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property GridColumn As DevExpress.XtraGrid.Columns.GridColumn
            Get
                GridColumn = _GridColumn
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Title As String, ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal EnumProperty As [Enum])

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Title
            _GridView = GridView
            _GridColumn = GridColumn
            _EnumProperty = EnumProperty

        End Sub
        Private Sub EnableOrDisableActions()

            If ComboBoxForm_Type.GetSelectedValue = ExpressionTypes.Decimal Then

                RadioButtonForm_Default.Enabled = True
                RadioButtonForm_Currency.Enabled = True
                RadioButtonForm_Percent.Enabled = True
                NumericInputForm_NumberOfDecimalPlaces.Enabled = True

            Else

                RadioButtonForm_Default.Enabled = False
                RadioButtonForm_Default.Checked = True
                RadioButtonForm_Currency.Enabled = False
                RadioButtonForm_Percent.Enabled = False
                NumericInputForm_NumberOfDecimalPlaces.Enabled = False
                NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal Title As String, ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn, Optional ByVal EnumProperty As [Enum] = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ComplexExpressionEditorDialog As ComplexExpressionEditorDialog = Nothing

            ComplexExpressionEditorDialog = New ComplexExpressionEditorDialog(Title, GridView, GridColumn, EnumProperty)

            ShowFormDialog = ComplexExpressionEditorDialog.ShowDialog

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                GridColumn = ComplexExpressionEditorDialog.GridColumn

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ComplexExpressionEditorDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ComboBoxForm_Type.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(ExpressionTypes), False)
            ComboBoxForm_Type.SetRequired(True)

            If _EnumProperty IsNot Nothing Then

                TextBoxForm_Caption.SetPropertySettings(_EnumProperty, "")

            End If

            Me.FormAction = FormActions.Loading

            Try

                If _GridColumn IsNot Nothing Then

                    TextBoxForm_Caption.Text = _GridColumn.Caption
                    ComboBoxForm_Type.SelectedValue = CStr(_GridColumn.UnboundType)
                    ComboBoxForm_Type.Enabled = False
                    TextBoxForm_Expression.Text = _GridColumn.UnboundExpression

                    If IsNothing(_GridColumn.DisplayFormat) = False AndAlso String.IsNullOrEmpty(_GridColumn.DisplayFormat.FormatString) = False Then

                        If _GridColumn.DisplayFormat.FormatString.ToUpper.StartsWith("C") Then

                            RadioButtonForm_Currency.Checked = True

                            If IsNumeric(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString)) Then

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString))

                            Else

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

                            End If

                        ElseIf _GridColumn.DisplayFormat.FormatString.ToUpper.StartsWith("P") Then

                            RadioButtonForm_Percent.Checked = True

                            If IsNumeric(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString)) Then

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString))

                            Else

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

                            End If

                        Else

                            RadioButtonForm_Default.Checked = True

                            If IsNumeric(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString)) Then

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_GridColumn.DisplayFormat.FormatString))

                            Else

                                NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

                            End If

                        End If

                    Else

                        RadioButtonForm_Default.Checked = True

                        NumericInputForm_NumberOfDecimalPlaces.EditValue = 0

                    End If

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = FormActions.None

        End Sub
        Private Sub ComplexExpressionEditorDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim FieldName As String = ""
            Dim ColumnCounter As Integer = 1
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If _GridColumn Is Nothing Then

                _GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

                FieldName = "UnboundColumn" & ColumnCounter

                Do While True

                    Try

                        GridColumn = _GridView.Columns(FieldName)

                    Catch ex As Exception
                        GridColumn = Nothing
                    End Try

                    If GridColumn Is Nothing Then

                        Exit Do

                    Else

                        ColumnCounter += 1
                        FieldName = "UnboundColumn" & ColumnCounter

                    End If

                Loop

                _GridColumn.FieldName = FieldName
                _GridColumn.ShowUnboundExpressionMenu = True

            End If

            _GridColumn.Caption = TextBoxForm_Caption.Text
            _GridColumn.UnboundType = ComboBoxForm_Type.SelectedValue
            _GridColumn.UnboundExpression = TextBoxForm_Expression.Text
            _GridColumn.OptionsColumn.ReadOnly = True

            If _GridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal Then

                If RadioButtonForm_Currency.Checked Then

                    _GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    _GridColumn.DisplayFormat.FormatString = "c" & NumericInputForm_NumberOfDecimalPlaces.EditValue

                ElseIf RadioButtonForm_Percent.Checked Then

                    _GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    _GridColumn.DisplayFormat.FormatString = "p" & NumericInputForm_NumberOfDecimalPlaces.EditValue

                Else

                    _GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    _GridColumn.DisplayFormat.FormatString = "n" & NumericInputForm_NumberOfDecimalPlaces.EditValue

                End If

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_ExpressionEdit_Click(sender As Object, e As EventArgs) Handles ButtonForm_ExpressionEdit.Click

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            GridColumn.Caption = TextBoxForm_Caption.Text
            GridColumn.UnboundType = ComboBoxForm_Type.SelectedValue
            GridColumn.UnboundExpression = TextBoxForm_Expression.Text

            _GridView.Columns.Add(GridColumn)

            _GridView.ShowUnboundExpressionEditor(GridColumn)

            TextBoxForm_Expression.Text = GridColumn.UnboundExpression

            _GridView.Columns.Remove(GridColumn)

        End Sub
        Private Sub ComboBoxForm_Type_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Type.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace