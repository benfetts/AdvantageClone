Namespace GeneralLedger.ReportWriter.Presentation

    Public Class BaseGLReportTemplateReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _RowsDataTable As System.Data.DataTable = Nothing
        'Private _ColumnsDataTable As System.Data.DataTable = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            InitializeComponent()

        End Sub
        Public Sub LoadReport(ByVal DataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal ColumnsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable)

            'objects
            Dim XRTable As DevExpress.XtraReports.UI.XRTable = Nothing
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim XRTableCell As DevExpress.XtraReports.UI.XRTableCell = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim DataColumnsList As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing

            XRTable = New DevExpress.XtraReports.UI.XRTable

            XRTable.BeginInit()

            DataColumnsList = DataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> StatementFields.RowID.ToString AndAlso DC.ColumnName <> StatementFields.ID.ToString).ToList

            For Each DataRow In DataTable.Select()

                Try

                    RowDataRow = RowsDataTable.Select(RowFields.ID.ToString & " = " & DataRow(StatementFields.RowID.ToString)).SingleOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

                XRTableRow.HeightF = 20.0F

                For Each DataColumn In DataColumnsList

                    XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

                    XRTableCell.Font = New System.Drawing.Font("Arial", 8)

                    Try

                        ColumnDataRow = ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & DataColumn.ColumnName & "'").SingleOrDefault

                    Catch ex As Exception
                        ColumnDataRow = Nothing
                    End Try

                    If ColumnDataRow Is Nothing Then

                        XRTableCell.Width = CInt(Fix(250))

                    Else

                        XRTableCell.Width = CInt(Fix(150))

                    End If

                    XRTableCell.Text = DataRow(DataColumn.ColumnName).ToString

                    If DataRow(StatementFields.RowID.ToString) >= 0 Then

                        If RowDataRow IsNot Nothing Then

                            If DataColumn.ColumnName = StatementFields.Description.ToString Then

                                If RowDataRow(RowFields.IsBold.ToString) Then

                                    XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                End If

                            Else

                                XRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                                If RowDataRow(RowFields.IsBold.ToString) OrElse RowDataRow(RowFields.UnderlineAmount.ToString) Then

                                    If RowDataRow(RowFields.IsBold.ToString) AndAlso RowDataRow(RowFields.UnderlineAmount.ToString) Then

                                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                                    ElseIf RowDataRow(RowFields.IsBold.ToString) = False AndAlso RowDataRow(RowFields.UnderlineAmount.ToString) Then

                                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Underline)

                                    ElseIf RowDataRow(RowFields.IsBold.ToString) AndAlso RowDataRow(RowFields.UnderlineAmount.ToString) = False Then

                                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                    End If

                                End If

                            End If

                            If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                If RowDataRow(RowFields.UseCurrencyFormat.ToString) Then

                                    XRTableCell.Text = FormatCurrency(CDec(DataRow(DataColumn.ColumnName)), RowDataRow(RowFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                Else

                                    XRTableCell.Text = FormatNumber(CDec(DataRow(DataColumn.ColumnName)), RowDataRow(RowFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                End If

                            End If

                        End If

                        If ColumnDataRow IsNot Nothing Then

                            If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Blank Then

                                XRTableCell.Text = ""

                            ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                                If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                    XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                End If

                            ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow Then

                                If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                    Try

                                        PercentOfRowColumnDataRow = PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & ColumnDataRow(ColumnFields.ID.ToString) & " AND " & PercentOfRowColumnFields.RowID.ToString & " = " & RowDataRow(RowFields.ID.ToString)).SingleOrDefault

                                    Catch ex As Exception
                                        PercentOfRowColumnDataRow = Nothing
                                    End Try

                                    If PercentOfRowColumnDataRow IsNot Nothing Then

                                        If PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) Is System.DBNull.Value Then

                                            XRTableCell.Text = ""

                                        Else

                                            XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                        End If

                                    Else

                                        XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    End If

                                End If

                            Else

                                If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                    If ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString) Then

                                        XRTableCell.Text = FormatCurrency(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    Else

                                        XRTableCell.Text = FormatNumber(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    End If

                                End If

                            End If

                        End If

                        If XRTableCell.Text = "" Then

                            XRTableCell.Text = "     "

                        End If

                    ElseIf DataRow(StatementFields.RowID.ToString) = -2 Then

                        XRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)
                        XRTableCell.Text = "     "

                        If ColumnDataRow IsNot Nothing Then

                            XRTableCell.Text = ColumnDataRow(ColumnFields.Description.ToString)

                            If ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString) Then

                                XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                            End If

                        End If

                    Else

                        XRTableCell.Text = "     "

                    End If

                    XRTableRow.Cells.Add(XRTableCell)

                Next

                XRTable.Rows.Add(XRTableRow)

            Next

            XRTable.Width = (Me.PageWidth - (Me.Margins.Left + Me.Margins.Right))

            XRTable.EndInit()

            Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(XRTable)

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
