Namespace Web.Presentation.Controls

    Public Class TemplateColumn
        Implements System.Web.UI.ITemplate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            Number
            Currency
        End Enum
        Public Enum [ParentControl]
            RadGrid
            RadTreeList
        End Enum

#End Region

#Region " Variables "

        Protected _RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Protected _Type As TemplateColumn.Type = TemplateColumn.Type.Number
        Protected _ParentControl As TemplateColumn.ParentControl = TemplateColumn.ParentControl.RadGrid
        Protected _ColumnName As String = ""
        Protected _IsReadOnly As Boolean = False
        Protected _MaxValue As Decimal = 0
        Protected _MinValue As Decimal = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(ByVal ColumnName As String, ByVal [Type] As TemplateColumn.Type, ByVal [ParentControl] As TemplateColumn.ParentControl, _
                       ByVal IsReadOnly As Boolean, ByVal MaxValue As Decimal, ByVal MinValue As Decimal)

            MyBase.New()

            _ColumnName = ColumnName
            _Type = [Type]
            _ParentControl = [ParentControl]
            _IsReadOnly = IsReadOnly
            _MaxValue = MaxValue
            _MinValue = MinValue

        End Sub
        Public Sub InstantiateIn(ByVal Container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            _RadNumericTextBox = New Telerik.Web.UI.RadNumericTextBox

            _RadNumericTextBox.ID = "RadNumericTextBox" & _ColumnName
            _RadNumericTextBox.EnabledStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Right
            _RadNumericTextBox.Width = System.Web.UI.WebControls.Unit.Percentage(100)
            _RadNumericTextBox.NumberFormat.KeepTrailingZerosOnFocus = True
            _RadNumericTextBox.AutoPostBack = False
            _RadNumericTextBox.ReadOnly = _IsReadOnly

            If _MaxValue <> 0 Then

                _RadNumericTextBox.MaxValue = _MaxValue

            End If

            If _MinValue <> 0 Then

                _RadNumericTextBox.MinValue = _MinValue

            End If

            FormatRadNumbericTextBox(_Type, _RadNumericTextBox)

            AddHandler _RadNumericTextBox.DataBinding, AddressOf _RadNumericTextBox_DataBinding

            Container.Controls.Add(_RadNumericTextBox)

        End Sub
        Private Sub _RadNumericTextBox_DataBinding(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
            Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim TreeListDataItem As Telerik.Web.UI.TreeListDataItem = Nothing

            RadNumericTextBox = DirectCast(sender, Telerik.Web.UI.RadNumericTextBox)

            If _ParentControl = TemplateColumn.ParentControl.RadGrid Then

                GridDataItem = DirectCast(RadNumericTextBox.NamingContainer, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing AndAlso GridDataItem.DataItem IsNot Nothing Then

                    If TypeOf GridDataItem.DataItem Is System.Data.DataRowView Then

                        If RadNumericTextBox.Value Is Nothing Then

                            RadNumericTextBox.Value = 0

                        End If

                        If IsDBNull(DirectCast(GridDataItem.DataItem, System.Data.DataRowView)(_ColumnName)) Then

                            RadNumericTextBox.Value = 0

                        Else

                            Try

                                RadNumericTextBox.Value = Double.Parse(DirectCast(GridDataItem.DataItem, System.Data.DataRowView)(_ColumnName))

                            Catch ex As Exception
                                RadNumericTextBox.Value = 0
                            End Try

                        End If

                    End If

                End If

            ElseIf _ParentControl = TemplateColumn.ParentControl.RadTreeList Then

                TreeListDataItem = DirectCast(RadNumericTextBox.NamingContainer, Telerik.Web.UI.TreeListDataItem)

                If TreeListDataItem IsNot Nothing AndAlso TreeListDataItem.DataItem IsNot Nothing Then

                    If TypeOf TreeListDataItem.DataItem Is System.Data.DataRowView Then

                        If RadNumericTextBox.Value Is Nothing Then

                            RadNumericTextBox.Value = 0

                        End If

                        If DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView).DataView.Table.Columns.Contains(_ColumnName) Then

                            If IsDBNull(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(_ColumnName)) Then

                                RadNumericTextBox.Value = 0

                            Else

                                Try

                                    RadNumericTextBox.Value = Double.Parse(DirectCast(TreeListDataItem.DataItem, System.Data.DataRowView)(_ColumnName))

                                Catch ex As Exception
                                    RadNumericTextBox.Value = 0
                                End Try

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Public Shared Sub FormatRadNumbericTextBox(ByVal TemplateColumnType As TemplateColumn.Type, ByRef RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox)

            Try

                If TemplateColumnType = Type.Number Then

                    RadNumericTextBox.NumberFormat.DecimalDigits = 2
                    RadNumericTextBox.Type = Telerik.Web.UI.NumericType.Number

                ElseIf TemplateColumnType = Type.Currency Then

                    RadNumericTextBox.NumberFormat.DecimalDigits = 2
                    RadNumericTextBox.Type = Telerik.Web.UI.NumericType.Currency
                    'RadNumericTextBox.NumberFormat.GroupSeparator = ","
                    RadNumericTextBox.NumberFormat.GroupSizes = 3

                End If

            Catch ex As Exception

            End Try
           
        End Sub

#End Region

    End Class

End Namespace