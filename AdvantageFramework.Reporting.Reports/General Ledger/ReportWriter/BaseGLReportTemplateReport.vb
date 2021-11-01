Namespace GeneralLedger.ReportWriter

    Public Class BaseGLReportTemplateReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _RowsDataTable As System.Data.DataTable = Nothing
        'Private _ColumnsDataTable As System.Data.DataTable = Nothing
        Private WithEvents _XRTable As DevExpress.XtraReports.UI.XRTable = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            InitializeComponent()

            AddHandler PrintingSystem.AfterMarginsChange, AddressOf PrintingSystem_AfterMarginsChange
            AddHandler PrintingSystem.PageSettingsChanged, AddressOf PrintingSystem_PageSettingsChanged

        End Sub
        Private Sub PrintingSystem_PageSettingsChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            ChangeReportSettings(sender)

        End Sub
        Private Sub PrintingSystem_AfterMarginsChange(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.MarginsChangeEventArgs)

            ChangeReportSettings(sender)

        End Sub
        Private Sub ChangeReportSettings(ByVal sender As Object)

            'objects
            Dim PrintingSystemBase As DevExpress.XtraPrinting.PrintingSystemBase = Nothing
            Dim NewPageWidth As Integer = 0
            Dim XRTable As DevExpress.XtraReports.UI.XRTable = Nothing

            Try

                PrintingSystemBase = TryCast(sender, DevExpress.XtraPrinting.PrintingSystemBase)
            Catch ex As Exception
                PrintingSystemBase = Nothing
            End Try

            If PrintingSystemBase IsNot Nothing Then

                NewPageWidth = PrintingSystemBase.PageBounds.Width - PrintingSystemBase.PageMargins.Left - PrintingSystemBase.PageMargins.Right

                XrPanelPageHeader.WidthF = NewPageWidth

                XRTable = Me.FindControl("XRTableStatement", True)

                If XRTable IsNot Nothing Then

                    XRTable.Width = NewPageWidth

                End If

                XRTable = Me.FindControl("XRTableColumnHeadings", True)

                If XRTable IsNot Nothing Then

                    XRTable.Width = NewPageWidth

                End If

                Me.Margins.Top = PrintingSystemBase.PageMargins.Top
                Me.Margins.Bottom = PrintingSystemBase.PageMargins.Bottom
                Me.Margins.Left = PrintingSystemBase.PageMargins.Left
                Me.Margins.Right = PrintingSystemBase.PageMargins.Right
                Me.PaperKind = PrintingSystemBase.PageSettings.PaperKind
                Me.PaperName = PrintingSystemBase.PageSettings.PaperName
                Me.Landscape = PrintingSystemBase.PageSettings.Landscape

                Me.CreateDocument()

            End If

        End Sub
        Public Sub LoadReport(ByVal DataTable As System.Data.DataTable, ByVal RowsDataTable As System.Data.DataTable, ByVal ColumnsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable, ByVal PrintColumnHeadingsOnEveryPage As Boolean)

            'objects
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim XRTableCell As DevExpress.XtraReports.UI.XRTableCell = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim DataColumnsList As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing
            Dim IsLastRowInRowGroup As Boolean = False
            Dim XrRichText As DevExpress.XtraReports.UI.XRRichText = Nothing
            Dim RichEditDocumentServer As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
            Dim Document As DevExpress.XtraRichEdit.API.Native.Document = Nothing
            Dim CharacterProperties As DevExpress.XtraRichEdit.API.Native.CharacterProperties = Nothing
            Dim ParagraphProperties As DevExpress.XtraRichEdit.API.Native.ParagraphProperties = Nothing

            If PrintColumnHeadingsOnEveryPage Then

                LoadColumnHeadings(DataTable, ColumnsDataTable)

            Else

                If PageHeader IsNot Nothing Then

                    PageHeader.Visible = False

                End If

            End If

            RichEditDocumentServer = New DevExpress.XtraRichEdit.RichEditDocumentServer
            _XRTable = New DevExpress.XtraReports.UI.XRTable

            _XRTable.Name = "XRTableStatement"

            _XRTable.BeginInit()

            DataColumnsList = DataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.Sort.ToString AndAlso DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString AndAlso DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.ID.ToString).ToList

            For Each DataRow In DataTable.Select()

                IsLastRowInRowGroup = False

                Try

                    RowDataRow = RowsDataTable.Select(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.ID.ToString & " = " & DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString)).SingleOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                If RowDataRow IsNot Nothing Then

                    Try

                        If DataTable.Compute("MAX(" & AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.ID.ToString & ")", AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString & " = " & RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.ID.ToString)) = DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.ID.ToString) Then

                            IsLastRowInRowGroup = True

                        End If

                    Catch ex As Exception

                    End Try

                End If

                XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

                XRTableRow.HeightF = 20.0F

                For Each DataColumn In DataColumnsList

                    XrRichText = Nothing

                    XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

                    XRTableCell.Font = New System.Drawing.Font("Arial", 8)

                    Try

                        ColumnDataRow = ColumnsDataTable.Select(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Name.ToString & " = '" & DataColumn.ColumnName & "'").SingleOrDefault

                    Catch ex As Exception
                        ColumnDataRow = Nothing
                    End Try

                    If ColumnDataRow Is Nothing Then

                        XRTableCell.Width = CInt(Fix(250))

                    Else

                        XRTableCell.Width = CInt(Fix(150))

                    End If

                    If ColumnDataRow Is Nothing OrElse (ColumnDataRow IsNot Nothing AndAlso ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.IsVisible.ToString)) Then

                        XRTableCell.Text = DataRow(DataColumn.ColumnName).ToString

                        If DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString) >= 0 Then

                            If RowDataRow IsNot Nothing Then

                                If DataColumn.ColumnName = AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.Description.ToString Then

                                    If RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.IsBold.ToString) Then

                                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                    End If

                                Else

                                    XRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                                    If RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.IsBold.ToString) OrElse RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.UnderlineAmount.ToString) Then

                                        If RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.IsBold.ToString) AndAlso RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.UnderlineAmount.ToString) Then

                                            If IsLastRowInRowGroup Then

                                                If ColumnDataRow IsNot Nothing AndAlso ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentOfRow AndAlso
                                                        ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentVariance Then

                                                    XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                                                Else

                                                    XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                                End If

                                            Else

                                                XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                            End If

                                        ElseIf RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.IsBold.ToString) = False AndAlso RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.UnderlineAmount.ToString) Then

                                            If IsLastRowInRowGroup Then

                                                If ColumnDataRow IsNot Nothing AndAlso ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentOfRow AndAlso
                                                        ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentVariance Then

                                                    XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Underline)

                                                End If

                                            End If

                                        ElseIf RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.IsBold.ToString) AndAlso RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.UnderlineAmount.ToString) = False Then

                                            XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)

                                        End If

                                    End If

                                    If RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.DoubleUnderlineAmount.ToString) AndAlso IsLastRowInRowGroup Then

                                        If ColumnDataRow IsNot Nothing AndAlso ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentOfRow AndAlso
                                                ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) <> AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentVariance Then

                                            XrRichText = New DevExpress.XtraReports.UI.XRRichText()

                                            XRTableCell.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {XrRichText})

                                        End If

                                    End If

                                End If

								If IsNumeric(DataRow(DataColumn.ColumnName)) AndAlso ColumnDataRow IsNot Nothing Then

									If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.UseCurrencyFormat.ToString) Then

										If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                            XRTableCell.XlsxFormatString = "$#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "_);($#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & ")"

                                        Else

                                            XRTableCell.XlsxFormatString = "$#,##0_);($#,##0)"

                                        End If

                                        XRTableCell.Value = DataRow(DataColumn.ColumnName)

                                        XRTableCell.Text = FormatCurrency(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    Else

                                        If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                            XRTableCell.XlsxFormatString = "#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "_);(#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & ")"

                                        Else

                                            XRTableCell.XlsxFormatString = "#,##0_);(#,##0)"

                                        End If

                                        XRTableCell.Value = DataRow(DataColumn.ColumnName)

                                        XRTableCell.Text = FormatNumber(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    End If

								End If

								If XrRichText IsNot Nothing Then

                                    RichEditDocumentServer.Text = XRTableCell.Text

                                    RichEditDocumentServer.Document.SelectAll()

                                    Document = RichEditDocumentServer.Document

                                    Document.BeginUpdate()

                                    Document.SelectAll()

                                    CharacterProperties = Document.BeginUpdateCharacters(Document.Selection)

                                    CharacterProperties.Bold = XRTableCell.Font.Bold

                                    CharacterProperties.FontSize = XRTableCell.Font.Size
                                    CharacterProperties.FontName = XRTableCell.Font.Name
                                    CharacterProperties.Underline = DevExpress.XtraRichEdit.API.Native.UnderlineType.Double

                                    Document.EndUpdateCharacters(CharacterProperties)

                                    ParagraphProperties = Document.BeginUpdateParagraphs(Document.Range)

                                    ParagraphProperties.Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Right

                                    Document.EndUpdateParagraphs(ParagraphProperties)

                                    Document.EndUpdate()

                                    XrRichText.Rtf = RichEditDocumentServer.RtfText

                                End If

                            End If

                            If ColumnDataRow IsNot Nothing Then

                                If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.Blank Then

                                    XRTableCell.Text = ""

                                ElseIf ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentVariance Then

                                    If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                        If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                            XRTableCell.XlsxFormatString = "0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "%"

                                        Else

                                            XRTableCell.XlsxFormatString = "0%"

                                        End If

                                        XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                    End If

                                ElseIf ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Type.ToString) = AdvantageFramework.GeneralLedger.ReportWriter.ColumnTypes.PercentOfRow Then

                                    If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                        Try

                                            PercentOfRowColumnDataRow = PercentOfRowColumnDataTable.Select(AdvantageFramework.GeneralLedger.ReportWriter.PercentOfRowColumnFields.ColumnID.ToString & " = " & ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.ID.ToString) & " AND " & AdvantageFramework.GeneralLedger.ReportWriter.PercentOfRowColumnFields.RowID.ToString & " = " & RowDataRow(AdvantageFramework.GeneralLedger.ReportWriter.RowFields.ID.ToString)).SingleOrDefault

                                        Catch ex As Exception
                                            PercentOfRowColumnDataRow = Nothing
                                        End Try

                                        If PercentOfRowColumnDataRow IsNot Nothing Then

                                            If PercentOfRowColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.PercentOfRowColumnFields.PercentOfRowID.ToString) Is System.DBNull.Value Then

                                                XRTableCell.Text = ""

                                            Else

                                                If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                                    XRTableCell.XlsxFormatString = "0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "%"

                                                Else

                                                    XRTableCell.XlsxFormatString = "0%"

                                                End If

                                                XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                            End If

                                        Else

                                            If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                                XRTableCell.XlsxFormatString = "0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "%"

                                            Else

                                                XRTableCell.XlsxFormatString = "0%"

                                            End If

                                            XRTableCell.Text = FormatPercent(DataRow(DataColumn.ColumnName), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                        End If

                                    End If

                                Else

                                    If IsNumeric(DataRow(DataColumn.ColumnName)) Then

                                        If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.UseCurrencyFormat.ToString) Then

                                            If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                                XRTableCell.XlsxFormatString = "$#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "_);($#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & ")"

                                            Else

                                                XRTableCell.XlsxFormatString = "$#,##0_);($#,##0)"

                                            End If

                                            XRTableCell.Value = DataRow(DataColumn.ColumnName)

                                            XRTableCell.Text = FormatCurrency(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                        Else

                                            If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString) > 0 Then

                                                XRTableCell.XlsxFormatString = "#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & "_);(#,##0." & AdvantageFramework.StringUtilities.PadWithCharacter("", ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), "0", False) & ")"

                                            Else

                                                XRTableCell.XlsxFormatString = "#,##0_);(#,##0)"

                                            End If

                                            XRTableCell.Value = DataRow(DataColumn.ColumnName)

                                            XRTableCell.Text = FormatNumber(CDec(DataRow(DataColumn.ColumnName)), ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                        End If

                                    End If

                                End If

                            End If

                            If XRTableCell.Text = "" Then

                                XRTableCell.Text = "     "

                            End If

                        ElseIf DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString) = -2 AndAlso PrintColumnHeadingsOnEveryPage = False Then

                            XRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                            XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)
                            XRTableCell.Text = "     "

                            If ColumnDataRow IsNot Nothing Then

                                XRTableCell.Text = ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Description.ToString)

                                If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.UnderlineColumnHeader.ToString) Then

                                    XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                                End If

                            End If

                        Else

                            XRTableCell.Text = "     "

                        End If

                        If DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString) = -1 OrElse
                                DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString) = -2 OrElse
                                DataRow(AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString) = -3 Then

                            If PrintColumnHeadingsOnEveryPage = False Then

                                XRTableRow.Cells.Add(XRTableCell)

                            End If

                        Else

                            XRTableRow.Cells.Add(XRTableCell)

                        End If

                    End If

                Next

                _XRTable.Rows.Add(XRTableRow)

            Next

            _XRTable.Width = (Me.PageWidth - (Me.Margins.Left + Me.Margins.Right))

            _XRTable.EndInit()

            Bands(DevExpress.XtraReports.UI.BandKind.Detail).Controls.Add(_XRTable)

        End Sub
        Public Sub LoadColumnHeadings(ByVal DataTable As System.Data.DataTable, ByVal ColumnsDataTable As System.Data.DataTable)

            'objects
            Dim XRTable As DevExpress.XtraReports.UI.XRTable = Nothing
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim XRTableCell As DevExpress.XtraReports.UI.XRTableCell = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim DataColumnsList As Generic.List(Of System.Data.DataColumn) = Nothing

            DataColumnsList = DataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.Sort.ToString AndAlso DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.RowID.ToString AndAlso DC.ColumnName <> AdvantageFramework.GeneralLedger.ReportWriter.StatementFields.ID.ToString).ToList

            XRTable = New DevExpress.XtraReports.UI.XRTable

            XRTable.Name = "XRTableColumnHeadings"

            XRTable.BeginInit()

            For RowCounter = 1 To 3 Step 1

                XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

                XRTableRow.HeightF = 20.0F

                For Each DataColumn In DataColumnsList

                    XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

                    XRTableCell.Font = New System.Drawing.Font("Arial", 8)

                    Try

                        ColumnDataRow = ColumnsDataTable.Select(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Name.ToString & " = '" & DataColumn.ColumnName & "'").SingleOrDefault

                    Catch ex As Exception
                        ColumnDataRow = Nothing
                    End Try

                    If ColumnDataRow Is Nothing Then

                        XRTableCell.Width = CInt(Fix(250))

                    Else

                        XRTableCell.Width = CInt(Fix(150))

                    End If

                    If ColumnDataRow Is Nothing OrElse (ColumnDataRow IsNot Nothing AndAlso ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.IsVisible.ToString)) Then

                        XRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold)
                        XRTableCell.Text = "     "

                        If ColumnDataRow IsNot Nothing AndAlso RowCounter = 2 Then

                            XRTableCell.Text = ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.Description.ToString)

                            If ColumnDataRow(AdvantageFramework.GeneralLedger.ReportWriter.ColumnFields.UnderlineColumnHeader.ToString) Then

                                XRTableCell.Font = New System.Drawing.Font(XRTableCell.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                            End If

                        Else

                            XRTableCell.Text = "     "

                        End If

                        XRTableRow.Cells.Add(XRTableCell)

                    End If

                Next

                XRTable.Rows.Add(XRTableRow)

            Next

            XRTable.Width = (Me.PageWidth - (Me.Margins.Left + Me.Margins.Right))
            XrPanelPageHeader.WidthF = XRTable.Width

            XRTable.EndInit()

            XrPanelPageHeader.Controls.Add(XRTable)

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub _XRTable_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles _XRTable.BeforePrint

            Dim XRRichTextList As System.Collections.Generic.IEnumerable(Of DevExpress.XtraReports.UI.XRRichText) = Nothing

            XRRichTextList = TryCast(sender, DevExpress.XtraReports.UI.XRTable).AllControls(Of DevExpress.XtraReports.UI.XRRichText)().ToList()

            For Each XRRichText As DevExpress.XtraReports.UI.XRRichText In XRRichTextList

                XRRichText.LocationF = New Drawing.PointF(0, 0)
                XRRichText.SizeF = TryCast(XRRichText.Parent, DevExpress.XtraReports.UI.XRTableCell).SizeF
                XRRichText.ResetTextAlignment()

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace
