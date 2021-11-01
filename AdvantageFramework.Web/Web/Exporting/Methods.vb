Imports System.Web.UI
Imports System.IO
Imports System.Web.UI.WebControls
Imports System.Data

Namespace Web.Exporting

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub ToExcel(ByVal FileName As String, ByVal DataTable As DataTable)

            'objects
            Dim StringWriter As System.IO.StringWriter = Nothing
            Dim HtmlTextWriter As System.Web.UI.HtmlTextWriter = Nothing
            Dim Table As System.Web.UI.WebControls.Table = Nothing

            Try

                System.Web.HttpContext.Current.Response.Buffer = True
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", FileName.Replace(" ", "_")))
                System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel"

                StringWriter = New System.IO.StringWriter
                HtmlTextWriter = New System.Web.UI.HtmlTextWriter(StringWriter)
                Table = New System.Web.UI.WebControls.Table

                Table.GridLines = GridLines.Both

                If Not DataTable.Columns Is Nothing Then

                    Dim HeaderRow As New TableRow
                    Dim HeaderCell As TableCell
                    For Each col As DataColumn In DataTable.Columns

                        HeaderCell = New TableCell
                        HeaderCell.Text = "<strong>" & col.ColumnName & "</strong>"

                        HeaderRow.Cells.Add(HeaderCell)

                    Next

                    Table.Rows.Add(HeaderRow)

                    HeaderCell = Nothing

                End If

                If Not DataTable.Rows Is Nothing Then

                    Dim DataRow As TableRow
                    For Each row As DataRow In DataTable.Rows

                        DataRow = New TableRow

                        Dim DataCell As TableCell
                        For i As Integer = 0 To DataTable.Columns.Count - 1

                            DataCell = New TableCell

                            DataCell.Text = row(i)

                            DataRow.Cells.Add(DataCell)

                            DataCell = Nothing

                        Next

                        Table.Rows.Add(DataRow)

                        DataRow = Nothing

                    Next

                End If

                Table.RenderControl(HtmlTextWriter)

                System.Web.HttpContext.Current.Response.Write(StringWriter.ToString)
                System.Web.HttpContext.Current.Response.Flush()
                System.Web.HttpContext.Current.Response.End()
                System.Web.HttpContext.Current.Response.Clear()

            Catch ex As Exception

            Finally

                If HtmlTextWriter IsNot Nothing Then

                    HtmlTextWriter.Close()
                    HtmlTextWriter.Dispose()

                    HtmlTextWriter = Nothing

                End If

                If StringWriter IsNot Nothing Then

                    StringWriter.Close()
                    StringWriter.Dispose()

                    StringWriter = Nothing

                End If

                If Table IsNot Nothing Then

                    Table.Dispose()

                    Table = Nothing

                End If

            End Try

        End Sub

        Public Sub ToExcel(ByVal FileName As String, ByVal GridView As System.Web.UI.WebControls.GridView)

            'objects
            Dim StringWriter As System.IO.StringWriter = Nothing
            Dim HtmlTextWriter As System.Web.UI.HtmlTextWriter = Nothing
            Dim Table As System.Web.UI.WebControls.Table = Nothing

            Try

                System.Web.HttpContext.Current.Response.Buffer = True
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", FileName.Replace(" ", "_")))
                System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel"

                StringWriter = New System.IO.StringWriter
                HtmlTextWriter = New System.Web.UI.HtmlTextWriter(StringWriter)
                Table = New System.Web.UI.WebControls.Table

                Table.GridLines = GridView.GridLines

                If GridView.HeaderRow IsNot Nothing Then

                    PrepareControlForExport(GridView.HeaderRow)
                    Table.Rows.Add(GridView.HeaderRow)

                End If

                For Each GridViewRow In GridView.Rows.OfType(Of System.Web.UI.WebControls.GridViewRow)()

                    PrepareControlForExport(GridViewRow)
                    Table.Rows.Add(GridViewRow)

                Next

                If GridView.FooterRow IsNot Nothing Then

                    PrepareControlForExport(GridView.FooterRow)
                    Table.Rows.Add(GridView.FooterRow)

                End If

                Table.RenderControl(HtmlTextWriter)

                System.Web.HttpContext.Current.Response.Write(StringWriter.ToString)
                System.Web.HttpContext.Current.Response.Flush()
                System.Web.HttpContext.Current.Response.End()
                System.Web.HttpContext.Current.Response.Clear()

            Catch ex As Exception

            Finally

                If HtmlTextWriter IsNot Nothing Then

                    HtmlTextWriter.Close()
                    HtmlTextWriter.Dispose()

                    HtmlTextWriter = Nothing

                End If

                If StringWriter IsNot Nothing Then

                    StringWriter.Close()
                    StringWriter.Dispose()

                    StringWriter = Nothing

                End If

                If Table IsNot Nothing Then

                    Table.Dispose()

                    Table = Nothing

                End If

            End Try

        End Sub
        Private Sub PrepareControlForExport(ByVal Control As System.Web.UI.Control)

            'objects
            Dim ControlCounter As Integer = 0
            Dim CurrentControl As System.Web.UI.Control = Nothing

            Do While (ControlCounter < Control.Controls.Count)

                CurrentControl = Control.Controls(ControlCounter)

                If TypeOf CurrentControl Is System.Web.UI.WebControls.LinkButton Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.LinkButton).Text))

                ElseIf TypeOf CurrentControl Is System.Web.UI.WebControls.ImageButton Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.ImageButton).AlternateText))

                ElseIf TypeOf CurrentControl Is System.Web.UI.WebControls.HyperLink Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.HyperLink).Text))

                ElseIf TypeOf CurrentControl Is System.Web.UI.WebControls.DropDownList Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.DropDownList).SelectedItem.Text))

                ElseIf TypeOf CurrentControl Is System.Web.UI.WebControls.CheckBox Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.CheckBox).Checked.ToString))

                ElseIf TypeOf CurrentControl Is System.Web.UI.WebControls.TextBox Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, System.Web.UI.WebControls.TextBox).Text))

                ElseIf TypeOf CurrentControl Is Telerik.Web.UI.RadComboBox Then

                    Control.Controls.Remove(CurrentControl)
                    Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CurrentControl, Telerik.Web.UI.RadComboBox).SelectedItem.Text))

                ElseIf TypeOf CurrentControl Is Telerik.Web.UI.RadDatePicker Then

                    If CType(CurrentControl, Telerik.Web.UI.RadDatePicker).SelectedDate IsNot Nothing Then

                        Control.Controls.Remove(CurrentControl)
                        Control.Controls.AddAt(ControlCounter, New System.Web.UI.LiteralControl(CType(CType(CurrentControl, Telerik.Web.UI.RadDatePicker).SelectedDate, Date).ToShortDateString()))

                    End If

                End If

                If CurrentControl.HasControls Then

                    PrepareControlForExport(CurrentControl)

                End If

                ControlCounter += 1

            Loop

        End Sub

#End Region

    End Module

End Namespace