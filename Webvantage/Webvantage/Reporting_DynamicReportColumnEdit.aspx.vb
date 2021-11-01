Public Class Reporting_DynamicReportColumnEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected _DynamicReportTemplateID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReportColumnEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        'Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        'If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

        '    Try
        '        If Request.QueryString("From") = "reportJV" Then
        '            DynamicReportColumnsList = Session("DynamicReportColumnsListJV")
        '        Else
        '            DynamicReportColumnsList = Session("DRPT_ColumnsList")
        '        End If

        '        RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList
        '        RadGridDynamicReportColumns.DataBind()

        '    Catch ex As Exception

        '    End Try

        'Else

        '    If Me.Request.Form("__EVENTTARGET") <> RadToolBarDynamicReportColumnEdit.ID AndAlso _
        '            Me.Request.Form("__EVENTTARGET").Contains("CheckBoxIsVisible") = False AndAlso _
        '            Me.Request.Form("__EVENTTARGET").Contains("TextBoxHeaderText") = False Then

        '        Try

        '            If Request.QueryString("From") = "reportJV" Then
        '                DynamicReportColumnsList = Session("DynamicReportColumnsListJV")
        '            Else
        '                DynamicReportColumnsList = Session("DRPT_ColumnsList")
        '            End If

        '            If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

        '                RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

        '            Else

        '                RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

        '            End If

        '            RadGridDynamicReportColumns.DataBind()

        '        Catch ex As Exception

        '        End Try

        '    End If

        'End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub CheckBoxIsVisible_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim IsVisible As Boolean = True
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing

        Try

            If Request.QueryString("From") = "reportJV" Then
                DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
            ElseIf Request.QueryString("From") = "reportJS" Then
                DynamicReportColumnsList = Session("DRPT_ColumnsListJS")
            ElseIf Request.QueryString("From") = "reportMS" Then
                DynamicReportColumnsList = Session("DRPT_ColumnsListMS")
            ElseIf Request.QueryString("From") = "reportEU" Then
                DynamicReportColumnsList = Session("DRPT_ColumnsListEU")
            ElseIf Request.QueryString("From") = "reportSP" Then
                DynamicReportColumnsList = Session("DRPT_ColumnsListSP")
            Else
                DynamicReportColumnsList = Session("DRPT_ColumnsList")
            End If

            GridDataItem = CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)

            IsVisible = CType(GridDataItem.FindControl("CheckBoxIsVisible"), CheckBox).Checked

            Try

                DynamicReportColumn = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.FieldName = GridDataItem.GetDataKeyValue("FieldName")).Single

            Catch ex As Exception
                DynamicReportColumn = Nothing
            End Try

            If DynamicReportColumn IsNot Nothing Then

                DynamicReportColumn.IsVisible = IsVisible

            End If

        Catch ex As Exception

        End Try

    End Sub
    Protected Sub TextBoxHeaderText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim HeaderText As String = ""
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing

        Try

            If Request.QueryString("From") = "reportJV" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListJV")

            ElseIf Request.QueryString("From") = "reportJS" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListJS")

            ElseIf Request.QueryString("From") = "reportMS" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListMS")

            ElseIf Request.QueryString("From") = "reportEU" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListEU")

            ElseIf Request.QueryString("From") = "reportSP" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListSP")

            Else

                DynamicReportColumnsList = Session("DRPT_ColumnsList")

            End If

            GridDataItem = CType(CType(sender, TextBox).Parent.Parent, Telerik.Web.UI.GridDataItem)

            HeaderText = CType(GridDataItem.FindControl("TextBoxHeaderText"), TextBox).Text

            Try

                DynamicReportColumn = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.FieldName = GridDataItem.GetDataKeyValue("FieldName")).Single

            Catch ex As Exception
                DynamicReportColumn = Nothing
            End Try

            If DynamicReportColumn IsNot Nothing Then

                DynamicReportColumn.HeaderText = HeaderText

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadToolBarDynamicReportColumnEdit_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportColumnEdit.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Database.Classes.DynamicReportColumn = Nothing
        Dim CheckBoxIsVisible As CheckBox = Nothing
        Dim TextBoxHeaderText As System.Web.UI.WebControls.TextBox = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                If Request.QueryString("From") = "reportJV" Then
                    DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
                ElseIf Request.QueryString("From") = "reportJS" Then
                    DynamicReportColumnsList = Session("DRPT_ColumnsListJS")
                ElseIf Request.QueryString("From") = "reportMS" Then
                    DynamicReportColumnsList = Session("DRPT_ColumnsListMS")
                ElseIf Request.QueryString("From") = "reportEU" Then
                    DynamicReportColumnsList = Session("DRPT_ColumnsListEU")
                ElseIf Request.QueryString("From") = "reportSP" Then
                    DynamicReportColumnsList = Session("DRPT_ColumnsListSP")
                Else
                    DynamicReportColumnsList = Session("DRPT_ColumnsList")
                End If

                For Each GridDataItem In RadGridDynamicReportColumns.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    Try

                        DynamicReportColumn = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.FieldName = GridDataItem.GetDataKeyValue("FieldName")).Single

                    Catch ex As Exception
                        DynamicReportColumn = Nothing
                    End Try

                    If DynamicReportColumn IsNot Nothing Then

                        Try

                            CheckBoxIsVisible = GridDataItem.FindControl("CheckBoxIsVisible")

                        Catch ex As Exception
                            CheckBoxIsVisible = Nothing
                        End Try

                        If CheckBoxIsVisible IsNot Nothing Then

                            DynamicReportColumn.IsVisible = CheckBoxIsVisible.Checked

                        End If

                        Try

                            TextBoxHeaderText = GridDataItem.FindControl("TextBoxHeaderText")

                        Catch ex As Exception
                            TextBoxHeaderText = Nothing
                        End Try

                        If TextBoxHeaderText IsNot Nothing Then

                            DynamicReportColumn.HeaderText = TextBoxHeaderText.Text

                        End If

                    End If

                Next

                If Request.QueryString("From") = "reportJV" Then
                    Session("DRPT_ColumnsListJV") = DynamicReportColumnsList
                ElseIf Request.QueryString("From") = "reportJS" Then
                    Session("DRPT_ColumnsListJS") = DynamicReportColumnsList
                ElseIf Request.QueryString("From") = "reportMS" Then
                    Session("DRPT_ColumnsListMS") = DynamicReportColumnsList
                ElseIf Request.QueryString("From") = "reportEU" Then
                    Session("DRPT_ColumnsListEU") = DynamicReportColumnsList
                ElseIf Request.QueryString("From") = "reportSP" Then
                    Session("DRPT_ColumnsListSP") = DynamicReportColumnsList
                Else
                    Session("DRPT_ColumnsList") = DynamicReportColumnsList
                End If


                If _DynamicReportTemplateID <> 0 Then

                    If Request.QueryString("From") = "reportJV" Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobVersion.aspx?From=reportJV&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    ElseIf Request.QueryString("From") = "reportJS" Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobStatus.aspx?From=reportJS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    ElseIf Request.QueryString("From") = "reportMS" Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_MediaSpecification.aspx?From=reportMS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    ElseIf Request.QueryString("From") = "reportEU" Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_EmployeeUtilization.aspx?From=reportEU&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    ElseIf Request.QueryString("From") = "reportSP" Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_Sprint.aspx?From=reportEU&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), False, True)

                    End If

                ElseIf Request.QueryString("From") = "reportJV" Then

                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobVersion.aspx?From=reportJV"), True, True)

                ElseIf Request.QueryString("From") = "reportJS" Then

                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobStatus.aspx?From=reportJS"), True, True)

                ElseIf Request.QueryString("From") = "reportMS" Then

                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_MediaSpecification.aspx?From=reportMS"), True, True)

                ElseIf Request.QueryString("From") = "reportEU" Then

                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_EmployeeUtilization.aspx?From=reportEU"), True, True)

                ElseIf Request.QueryString("From") = "reportSP" Then

                    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_Sprint.aspx?From=reportSP"), True, True)

                Else

                    Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                End If

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

            Case RadToolBarButtonReset.Value

                Try
                    If Request.QueryString("From") = "reportJV" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJS")
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListMS")
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListEU")
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListSP")
                    Else
                        DynamicReportColumnsList = Session("DRPT_ColumnsList")
                    End If


                    For Each DynamicReportColumn In DynamicReportColumnsList

                        If DynamicReportColumn.OriginalText <> "" Then
                            DynamicReportColumn.HeaderText = DynamicReportColumn.OriginalText
                        Else
                            DynamicReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(DynamicReportColumn.FieldName)
                        End If
                        DynamicReportColumn.IsVisible = True

                    Next

                    If Request.QueryString("From") = "reportJV" Then
                        Session("DRPT_ColumnsListJV") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        Session("DRPT_ColumnsListJS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        Session("DRPT_ColumnsListMS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        Session("DRPT_ColumnsListEU") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        Session("DRPT_ColumnsListSP") = DynamicReportColumnsList
                    Else
                        Session("DRPT_ColumnsList") = DynamicReportColumnsList
                    End If

                    'If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

                    'Else

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

                    'End If

                    RadGridDynamicReportColumns.Rebind()

                Catch ex As Exception

                End Try

            Case RadToolBarButtonSelectAll.Value

                Try

                    If Request.QueryString("From") = "reportJV" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJS")
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListMS")
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListEU")
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListSP")
                    Else
                        DynamicReportColumnsList = Session("DRPT_ColumnsList")
                    End If

                    For Each DynamicReportColumn In DynamicReportColumnsList

                        DynamicReportColumn.IsVisible = True

                    Next

                    If Request.QueryString("From") = "reportJV" Then
                        Session("DRPT_ColumnsListJV") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        Session("DRPT_ColumnsListJS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        Session("DRPT_ColumnsListMS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        Session("DRPT_ColumnsListEU") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        Session("DRPT_ColumnsListSP") = DynamicReportColumnsList
                    Else
                        Session("DRPT_ColumnsList") = DynamicReportColumnsList
                    End If

                    'If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

                    'Else

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

                    'End If

                    RadGridDynamicReportColumns.Rebind()

                Catch ex As Exception

                End Try

            Case RadToolBarButtonDeselectAll.Value

                Try

                    If Request.QueryString("From") = "reportJV" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJV")
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListJS")
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListMS")
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListEU")
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        DynamicReportColumnsList = Session("DRPT_ColumnsListSP")
                    Else
                        DynamicReportColumnsList = Session("DRPT_ColumnsList")
                    End If

                    For Each DynamicReportColumn In DynamicReportColumnsList

                        DynamicReportColumn.IsVisible = False

                    Next

                    If Request.QueryString("From") = "reportJV" Then
                        Session("DRPT_ColumnsListJV") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportJS" Then
                        Session("DRPT_ColumnsListJS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportMS" Then
                        Session("DRPT_ColumnsListMS") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportEU" Then
                        Session("DRPT_ColumnsListEU") = DynamicReportColumnsList
                    ElseIf Request.QueryString("From") = "reportSP" Then
                        Session("DRPT_ColumnsListSP") = DynamicReportColumnsList
                    Else
                        Session("DRPT_ColumnsList") = DynamicReportColumnsList
                    End If

                    'If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

                    'Else

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

                    'End If

                    RadGridDynamicReportColumns.Rebind()

                Catch ex As Exception

                End Try

            Case RadToolBarButtonShowOnlyVisibleColumns.Value

                Try

                    'DynamicReportColumnsList = Session("DRPT_ColumnsList")

                    'If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

                    'Else

                    '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

                    'End If

                    If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

                        RadGridDynamicReportColumns.MasterTableView.FilterExpression = "IsVisible = True"

                    Else

                        RadGridDynamicReportColumns.MasterTableView.FilterExpression = ""

                    End If

                    RadGridDynamicReportColumns.Rebind()

                Catch ex As Exception

                End Try

        End Select

    End Sub
    Private Sub RadGridDynamicReportColumns_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDynamicReportColumns.ItemDataBound

        'Try

        '    If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

        '        If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

        '            If DirectCast(e.Item, Telerik.Web.UI.GridDataItem).DataItem IsNot Nothing AndAlso TypeOf DirectCast(e.Item, Telerik.Web.UI.GridDataItem).DataItem Is AdvantageFramework.Database.Classes.DynamicReportColumn Then

        '                If DirectCast(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).DataItem, AdvantageFramework.Database.Classes.DynamicReportColumn).IsVisible = False Then

        '                    DirectCast(e.Item, Telerik.Web.UI.GridDataItem).Visible = False

        '                End If

        '            End If

        '        End If

        '    End If

        'Catch ex As Exception

        'End Try

    End Sub
    Private Sub RadGridDynamicReportColumns_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDynamicReportColumns.NeedDataSource

        'objects
        Dim DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing

        Try

            If Request.QueryString("From") = "reportJV" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListJV")

            ElseIf Request.QueryString("From") = "reportJS" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListJS")

            ElseIf Request.QueryString("From") = "reportMS" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListMS")

            ElseIf Request.QueryString("From") = "reportEU" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListEU")

            ElseIf Request.QueryString("From") = "reportSP" Then

                DynamicReportColumnsList = Session("DRPT_ColumnsListSP")

            Else

                DynamicReportColumnsList = Session("DRPT_ColumnsList")

            End If

        Catch ex As Exception
            DynamicReportColumnsList = New Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)
        End Try

        RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

        'If RadToolBarButtonShowOnlyVisibleColumns.Checked Then

        '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList.Where(Function(RptColumn) RptColumn.IsVisible = True)

        'Else

        '    RadGridDynamicReportColumns.DataSource = DynamicReportColumnsList

        'End If

    End Sub

#End Region

#End Region

End Class
