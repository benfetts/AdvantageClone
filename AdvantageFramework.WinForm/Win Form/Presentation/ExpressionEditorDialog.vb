Namespace WinForm.Presentation

    Public Class ExpressionEditorDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DataTable As System.Data.DataTable = Nothing
        Private _ColumnName As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Expression As String
            Get
                Expression = TextBoxForm_Expression.Text
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DataTable As System.Data.DataTable, ByVal ColumnName As String, ByVal Expression As String)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DataTable = DataTable
            TextBoxForm_Expression.Text = Expression
            _ColumnName = ColumnName

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DataTable As System.Data.DataTable, ByVal ColumnName As String, ByRef Expression As String) As Windows.Forms.DialogResult

            'objects
            Dim ExpressionEditorDialog As AdvantageFramework.WinForm.Presentation.ExpressionEditorDialog = Nothing

            ExpressionEditorDialog = New AdvantageFramework.WinForm.Presentation.ExpressionEditorDialog(DataTable, ColumnName, Expression)

            ShowFormDialog = ExpressionEditorDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Expression = ExpressionEditorDialog.Expression

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExpressionEditorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim Columns As Generic.List(Of Object) = Nothing

            DataGridViewForm_Columns.OptionsView.ShowFooter = False
            DataGridViewForm_Columns.MultiSelect = False

            DataGridViewForm_Columns.SetStyle(Windows.Forms.ControlStyles.Selectable, False)

            Columns = New Generic.List(Of Object)

            Try

                For Each DataColumn In _DataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                    If DataColumn.ColumnName <> _ColumnName Then

                        Try

                            If DataColumn.ExtendedProperties.Contains("ShowInExpressionEditor") Then

                                If DataColumn.ExtendedProperties("ShowInExpressionEditor") Then

                                    Columns.Add(New With {.Name = DataColumn.ColumnName})

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                Next

            Catch ex As Exception
                Columns = New Generic.List(Of Object)
            End Try
            
            DataGridViewForm_Columns.DataSource = Columns

            Try

                DataGridViewForm_Statement.DataSource = _DataTable

                For Each GridColumn In DataGridViewForm_Statement.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    Try

                        DataColumn = _DataTable.Columns(GridColumn.FieldName)

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    Try

                        If DataColumn.ExtendedProperties.Contains("ShowInExpressionEditor") Then

                            GridColumn.OptionsColumn.ShowInExpressionEditor = DataColumn.ExtendedProperties("ShowInExpressionEditor")

                        Else

                            GridColumn.OptionsColumn.ShowInExpressionEditor = False

                        End If

                    Catch ex As Exception
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False
                    End Try

                Next

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ExpressionEditorDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            TextBoxForm_Expression.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If TextBoxForm_Expression.Text.Contains("/") = False Then

                GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

                GridColumn.UnboundExpression = TextBoxForm_Expression.Text

                DataGridViewForm_Statement.Columns.Add(GridColumn)

                If GridColumn.IsUnboundExpressionValid Then

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid expression.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The division operation is not allowed. Please remove it from your equation.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_CloseParenthesis_Click(sender As Object, e As EventArgs) Handles ButtonForm_CloseParenthesis.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, ")")

        End Sub
        Private Sub ButtonForm_Divide_Click(sender As Object, e As EventArgs) Handles ButtonForm_Divide.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "/")

        End Sub
        Private Sub ButtonForm_IFF_Click(sender As Object, e As EventArgs) Handles ButtonForm_IFF.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "IIF( , , )")

        End Sub
        Private Sub ButtonForm_Minus_Click(sender As Object, e As EventArgs) Handles ButtonForm_Minus.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "-")

        End Sub
        Private Sub ButtonForm_Multiply_Click(sender As Object, e As EventArgs) Handles ButtonForm_Multiply.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "*")

        End Sub
        Private Sub ButtonForm_OpenParenthesis_Click(sender As Object, e As EventArgs) Handles ButtonForm_OpenParenthesis.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "(")

        End Sub
        Private Sub ButtonForm_Plus_Click(sender As Object, e As EventArgs) Handles ButtonForm_Plus.Click

            TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, "+")

        End Sub
        Private Sub DataGridViewForm_Columns_RowDoubleClickEvent() Handles DataGridViewForm_Columns.RowDoubleClickEvent

            If DataGridViewForm_Columns.HasOnlyOneSelectedRow Then

                TextBoxForm_Expression.Text = TextBoxForm_Expression.Text.Insert(TextBoxForm_Expression.Text.Length, DataGridViewForm_Columns.GetFirstSelectedRowBookmarkValue(0))

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace