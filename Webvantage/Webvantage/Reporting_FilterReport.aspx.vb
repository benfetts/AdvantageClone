Public Class Reporting_FilterReport
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _FilterType As Integer = 1
    Private _DynamicReportTemplateID As Integer = 0
    Private _DynamicReportType As Integer = 0

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub LoadQueryStringValues()

        Try

            If Request.QueryString("Type") IsNot Nothing Then

                _FilterType = CType(Request.QueryString("Type"), Integer)

            End If

        Catch ex As Exception
            _FilterType = 1
        End Try

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("DRPT_Type") IsNot Nothing Then

                _DynamicReportType = CType(Request.QueryString("DRPT_Type"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportType = 0
        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_FilterReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
        Dim ObjectType As System.Type = Nothing
        Dim FilterControlColumn As DevExpress.Web.FilterControlColumn = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ColumnIndex As Integer = 0

        LoadQueryStringValues()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _FilterType = 1 Then

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, Session("UserDefinedReportID"))

                    If UserDefinedReport IsNot Nothing Then

                        ObjectType = AdvantageFramework.Reporting.LoadUserDefinedReportObjectType(UserDefinedReport.AdvancedReportWriterType)

                    End If

                    If Session("UDR_FilterReport_FilterString") IsNot Nothing Then

                        ASPxFilterControl.FilterExpression = Session("UDR_FilterReport_FilterString")

                    End If

                ElseIf _FilterType = 2 Then

                    Try

                        If Request.QueryString("From") = "reportJV" Then

                            DataTable = Session("DynamicReportDataTable")

                            For ColumnIndex = 0 To DataTable.Columns.Count - 1

                                FilterControlColumn = New DevExpress.Web.FilterControlColumn

                                FilterControlColumn.PropertyName = DataTable.Columns(ColumnIndex).ColumnName
                                FilterControlColumn.DisplayName = DataTable.Columns(ColumnIndex).ColumnName

                                If DataTable.Columns(ColumnIndex).DataType = GetType(String) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Integer) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Integer)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Short) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Short)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Long) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Long)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Decimal) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Decimal)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Double) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Double)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Boolean) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Boolean)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Date) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Date)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(DateTime) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of DateTime)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                                Else

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                                End If

                                ASPxFilterControl.Columns.Add(FilterControlColumn)

                            Next

                            If Session("JV_FilterReport_FilterString") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("JV_FilterReport_FilterString")

                            End If

                        ElseIf Request.QueryString("From") = "reportJS" Then

                            DataTable = Session("DynamicReportDataTable")

                            For ColumnIndex = 0 To DataTable.Columns.Count - 1

                                FilterControlColumn = New DevExpress.Web.FilterControlColumn

                                FilterControlColumn.PropertyName = DataTable.Columns(ColumnIndex).ColumnName
                                FilterControlColumn.DisplayName = DataTable.Columns(ColumnIndex).ColumnName

                                If DataTable.Columns(ColumnIndex).DataType = GetType(String) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Integer) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Integer)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Short) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Short)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Long) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Long)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Decimal) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Decimal)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Double) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Double)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Boolean) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Boolean)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Date) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Date)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(DateTime) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of DateTime)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                                Else

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                                End If

                                ASPxFilterControl.Columns.Add(FilterControlColumn)

                            Next

                            If Session("JS_FilterReport_FilterString") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("JS_FilterReport_FilterString")

                            End If

                        ElseIf Request.QueryString("From") = "reportMS" Then

                            DataTable = Session("DynamicReportDataTable")

                            For ColumnIndex = 0 To DataTable.Columns.Count - 1

                                FilterControlColumn = New DevExpress.Web.FilterControlColumn

                                FilterControlColumn.PropertyName = DataTable.Columns(ColumnIndex).ColumnName
                                FilterControlColumn.DisplayName = DataTable.Columns(ColumnIndex).ColumnName

                                If DataTable.Columns(ColumnIndex).DataType = GetType(String) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Integer) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Integer)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Short) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Short)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Long) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Long)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Decimal) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Decimal)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Double) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Double)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Boolean) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Boolean)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Date) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Date)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(DateTime) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of DateTime)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                                Else

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                                End If

                                ASPxFilterControl.Columns.Add(FilterControlColumn)

                            Next

                            If Session("MS_FilterReport_FilterString") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("MS_FilterReport_FilterString")

                            End If

                        ElseIf Request.QueryString("From") = "reportEU" Then

                            DataTable = Session("DynamicReportDataTable")

                            For ColumnIndex = 0 To DataTable.Columns.Count - 1

                                FilterControlColumn = New DevExpress.Web.FilterControlColumn

                                FilterControlColumn.PropertyName = DataTable.Columns(ColumnIndex).ColumnName
                                FilterControlColumn.DisplayName = DataTable.Columns(ColumnIndex).ColumnName

                                If DataTable.Columns(ColumnIndex).DataType = GetType(String) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Integer) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Integer)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Short) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Short)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Long) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Long)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Decimal) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Decimal)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Double) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Double)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Boolean) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Boolean)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Date) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Date)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(DateTime) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of DateTime)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                                Else

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                                End If

                                ASPxFilterControl.Columns.Add(FilterControlColumn)

                            Next

                            If Session("EU_FilterReport_FilterString") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("EU_FilterReport_FilterString")

                            End If

                        ElseIf Request.QueryString("From") = "reportSP" Then

                            DataTable = Session("DynamicReportDataTable")

                            For ColumnIndex = 0 To DataTable.Columns.Count - 1

                                FilterControlColumn = New DevExpress.Web.FilterControlColumn

                                FilterControlColumn.PropertyName = DataTable.Columns(ColumnIndex).ColumnName
                                FilterControlColumn.DisplayName = DataTable.Columns(ColumnIndex).ColumnName

                                If DataTable.Columns(ColumnIndex).DataType = GetType(String) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Integer) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Integer)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Short) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Short)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(Long) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Long)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Decimal) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Decimal)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Double) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Double)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Boolean) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Boolean)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                                ElseIf DataTable.Columns(ColumnIndex).DataType = GetType(Date) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of Date)) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(DateTime) OrElse
                                        DataTable.Columns(ColumnIndex).DataType = GetType(System.Nullable(Of DateTime)) Then

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                                Else

                                    FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                                End If

                                ASPxFilterControl.Columns.Add(FilterControlColumn)

                            Next

                            If Session("SP_FilterReport_FilterString") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("SP_FilterReport_FilterString")

                            End If

                        Else

                            ObjectType = AdvantageFramework.Reporting.LoadDynamicReportObjectType(_DynamicReportType)

                            If Session("DRPT_ActiveFilter") IsNot Nothing Then

                                ASPxFilterControl.FilterExpression = Session("DRPT_ActiveFilter")

                            End If

                        End If

                    Catch ex As Exception
                        ObjectType = Nothing
                    End Try

                End If

            End Using

            If ObjectType IsNot Nothing Then

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    If PropertyDescriptor.Attributes.OfType(Of System.Xml.Serialization.XmlIgnoreAttribute).Any = False Then

                        FilterControlColumn = New DevExpress.Web.FilterControlColumn

                        FilterControlColumn.PropertyName = PropertyDescriptor.Name
                        FilterControlColumn.DisplayName = PropertyDescriptor.Name

                        If PropertyDescriptor.PropertyType = GetType(String) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.String

                        ElseIf PropertyDescriptor.PropertyType = GetType(Integer) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Integer)) OrElse _
                                PropertyDescriptor.PropertyType = GetType(Short) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Short)) OrElse _
                                PropertyDescriptor.PropertyType = GetType(Long) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Long)) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Integer

                        ElseIf PropertyDescriptor.PropertyType = GetType(Decimal) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Decimal)) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Decimal

                        ElseIf PropertyDescriptor.PropertyType = GetType(Double) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Double)) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Double

                        ElseIf PropertyDescriptor.PropertyType = GetType(Boolean) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Boolean)) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Boolean

                        ElseIf PropertyDescriptor.PropertyType = GetType(Date) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of Date)) OrElse _
                                PropertyDescriptor.PropertyType = GetType(DateTime) OrElse _
                                PropertyDescriptor.PropertyType = GetType(System.Nullable(Of DateTime)) Then

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.DateTime

                        Else

                            FilterControlColumn.ColumnType = DevExpress.Web.FilterControlColumnType.Default

                        End If

                        ASPxFilterControl.Columns.Add(FilterControlColumn)

                    End If

                Next

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarContentFilterReport_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarContentFilterReport.ButtonClick

        Select Case e.Item.Value

            Case RadToolBarButtonCancel.Value

                If _FilterType = 1 Then

                    MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                ElseIf _FilterType = 2 Then

                    Me.CloseThisWindow()

                End If

            Case RadToolBarButtonOK.Value

                If _FilterType = 1 Then

                    Session("UDR_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                    MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined) & "")

                ElseIf _FilterType = 2 Then

                    If _DynamicReportTemplateID <> 0 Then

                        If Request.QueryString("From") = "reportJV" Then

                            Session("JV_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobVersion.aspx?From=reportJV&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                        ElseIf Request.QueryString("From") = "reportJS" Then

                            Session("JS_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobStatus.aspx?From=reportJS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                        ElseIf Request.QueryString("From") = "reportMS" Then

                            Session("MS_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_MediaSpecification.aspx?From=reportMS&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                        ElseIf Request.QueryString("From") = "reportEU" Then

                            Session("EU_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_EmployeeUtilization.aspx?From=reportEU&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                        ElseIf Request.QueryString("From") = "reportSP" Then

                            Session("SP_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_Sprint.aspx?From=reportSP&DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)
                        Else

                            Session("DRPT_ActiveFilter") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), False, True)

                        End If

                    Else

                        If Request.QueryString("From") = "reportJV" Then

                            Session("JV_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobVersion.aspx?From=reportJV"), True, True)

                        ElseIf Request.QueryString("From") = "reportJS" Then

                            Session("JS_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_JobStatus.aspx?From=reportJS"), True, True)

                        ElseIf Request.QueryString("From") = "reportMS" Then

                            Session("MS_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_MediaSpecification.aspx?From=reportMS"), True, True)

                        ElseIf Request.QueryString("From") = "reportEU" Then

                            Session("EU_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_EmployeeUtilization.aspx?From=reportEU"), True, True)

                        ElseIf Request.QueryString("From") = "reportSP" Then

                            Session("SP_FilterReport_FilterString") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_Sprint.aspx?From=reportSP"), True, True)

                        Else

                            Session("DRPT_ActiveFilter") = ASPxFilterControl.FilterExpression

                            Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                        End If


                    End If

                End If

        End Select

    End Sub

#End Region

#End Region

End Class