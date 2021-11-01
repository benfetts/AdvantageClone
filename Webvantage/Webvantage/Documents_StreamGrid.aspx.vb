Imports Aspose.Cells

Public Class Documents_StreamGrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Session("EXPORT_GRID") Is Nothing Then

                Dim FileName As String = "ExcelDocument"
                Dim dt As New DataTable
                Dim extension As String = ""

                If Session("EXPORT_GRID_FILENAME") IsNot Nothing Then

                    FileName = Session("EXPORT_GRID_FILENAME").ToString()

                End If

                FileName &= AdvantageFramework.StringUtilities.GUID_Date()
                If Not Session("directtimereport") Is Nothing Then
                    If Session("directtimereport") = "XLS" Then
                        FileName &= ".xls"
                        extension = ".xls"
                    ElseIf Session("directtimereport") = "XLSX" Then
                        FileName &= ".xlsx"
                        extension = ".xlsx"
                    ElseIf Session("directtimereport") = "CSV" Then
                        FileName &= ".csv"
                        extension = ".csv"
                    Else
                        FileName &= ".xls"
                        extension = ".xls"
                    End If
                    Session("directtimereport") = Nothing
                Else
                    FileName &= ".xls"
                    extension = ".xls"
                End If

                dt = Session("EXPORT_GRID")

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    Dim ColumnCount As Integer = 0
                    Dim ColumnCounter As Integer = 0
                    Dim RowCounter As Integer = 0

                    Dim Worksheet As Aspose.Cells.Worksheet = Nothing
                    Dim Workbook As Aspose.Cells.Workbook = Nothing
                    Dim XlsSaveOptions As Aspose.Cells.XlsSaveOptions = Nothing
                    Dim License As Aspose.Cells.License = Nothing
                    Dim style As Style

                    License = New Aspose.Cells.License
                    Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)

                    If extension = ".xls" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)
                    ElseIf extension = ".xlsx" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Xlsx)
                    ElseIf extension = ".csv" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.CSV)
                    Else
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)
                    End If


                    If extension = ".xls" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)
                    ElseIf extension = ".xlsx" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Xlsx)
                    ElseIf extension = ".csv" Then
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.CSV)
                    Else
                        Workbook = New Aspose.Cells.Workbook(Aspose.Cells.FileFormatType.Excel97To2003)
                    End If


                    License.SetLicense("Aspose.Total.lic")

                    If Workbook.Worksheets.Count = 0 Then Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

                    Worksheet = Workbook.Worksheets(0)

                    If extension = ".xls" Then
                        XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)
                    ElseIf extension = ".xlsx" Then
                        XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Xlsx)
                    ElseIf extension = ".csv" Then
                        XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.CSV)
                    Else
                        XlsSaveOptions = New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)
                    End If


                    ColumnCount = dt.Columns.Count
                    For Each column As DataColumn In dt.Columns

                        Worksheet.Cells(0, ColumnCounter).HtmlString = String.Format("<b>{0}</b>", column.ColumnName)
                        ColumnCounter += 1

                    Next

                    For Each row As DataRow In dt.Rows

                        RowCounter += 1

                        For i As Integer = 0 To ColumnCount - 1
                            Dim d As String = row.Table.Columns(i).DataType.ToString
                            If d = "System.Decimal" Then
                                style = Worksheet.Cells(RowCounter, i).GetStyle()
                                style.Number = 4
                                Worksheet.Cells(RowCounter, i).SetStyle(style)
                                Worksheet.Cells(RowCounter, i).PutValue(row(i))
                            ElseIf d = "System.Int16" Or d = "System.Int32" Then
                                style = Worksheet.Cells(RowCounter, i).GetStyle()
                                style.Number = 1
                                Worksheet.Cells(RowCounter, i).SetStyle(style)
                                Worksheet.Cells(RowCounter, i).PutValue(row(i))
                            ElseIf d = "System.DateTime" Then
                                style = Worksheet.Cells(RowCounter, i).GetStyle()
                                style.Number = 14
                                Worksheet.Cells(RowCounter, i).SetStyle(style)
                                Worksheet.Cells(RowCounter, i).PutValue(row(i))
                            Else
                                If row(i).ToString = "emptygrayline" Then
                                    style = Worksheet.Cells(RowCounter, i).GetStyle()
                                    style.BackgroundColor = System.Drawing.Color.Gray
                                    style.Pattern = BackgroundType.Gray25
                                    Worksheet.Cells(RowCounter, i).SetStyle(style)
                                    'Worksheet.Cells(RowCounter, i).PutValue(row(i))
                                ElseIf row(i).ToString.Contains("boldfont") Then
                                    style = Worksheet.Cells(RowCounter, i).GetStyle()
                                    style.Font.IsBold = True
                                    Worksheet.Cells(RowCounter, i).SetStyle(style)
                                    Worksheet.Cells(RowCounter, i).PutValue(row(i).ToString.Replace("boldfont", ""))
                                Else
                                    'Worksheet.Cells(RowCounter, i).HtmlString = (row(i)).ToString
                                    Worksheet.Cells(RowCounter, i).PutValue(row(i).ToString.Replace("12:00:00 AM", ""))
                                End If
                            End If

                        Next

                    Next

                    Worksheet.AutoFitColumns()


                    Try

                        Dim MemoryStream As System.IO.MemoryStream = Nothing

                        MemoryStream = New IO.MemoryStream

                        Workbook.Save(MemoryStream, XlsSaveOptions)

                        HttpContext.Current.Response.Clear()
                        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
                        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & FileName.Replace(",", ""))
                        HttpContext.Current.Response.BinaryWrite(MemoryStream.ToArray())
                        HttpContext.Current.ApplicationInstance.CompleteRequest()
                        'HttpContext.Current.Response.Flush()
                        'HttpContext.Current.Response.End()
                        Try

                            HttpContext.Current.Response.End()

                        Catch ex As Exception

                        End Try

                    Catch ex As Exception

                    End Try

                    If License IsNot Nothing Then

                        License = Nothing

                    End If

                End If

                ResetSessionVariables()

                Try

                    dt.Dispose()

                Catch ex As Exception
                End Try

            Else

                ResetSessionVariables()

            End If
        Catch ex As Exception

            ResetSessionVariables()

        End Try

    End Sub

    Private Sub ResetSessionVariables()

        Session("EXPORT_GRID") = Nothing
        Session("EXPORT_GRID_FILENAME") = Nothing

    End Sub
End Class
