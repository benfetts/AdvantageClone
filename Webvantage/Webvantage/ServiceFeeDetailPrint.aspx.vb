Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class ServiceFeeDetailPrint
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function

    Private client As String = ""
    Private division As String = ""
    Private product As String = ""
    Private display As String = ""
    Private fee As Integer = 0
    Private campaign As Boolean = False
    Private job As Boolean = False
    Private func As Boolean = False
    Private funchead As Boolean = False
    Private consol As Boolean = False
    Private pp As Boolean = False
    Private emp As Boolean = False
    Private empdate As Boolean = False
    Private startperiod As String = ""
    Private endperiod As String = ""
    Private feeoption As String = ""
    Private CampaignCode As String = ""
    Private JobNumber As Integer = 0
    Private ComponentNumber As Integer = 0
    Private FunctionCode As String = ""
    Private PostPeriod As String = ""
    Private Heading As String = ""
    Private ConsolidationCode As String = ""
    Private EmpGrid As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing

#End Region

#Region " Page Functions "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            Me.startperiod = qs.Get("speriod")
            Me.endperiod = qs.Get("eperiod")
            Me.client = qs.ClientCode
            Me.division = qs.DivisionCode
            Me.product = qs.ProductCode
            Me.feeoption = qs.Get("feeoption")
            Me.display = qs.Get("display")
            Me.job = qs.Get("job")
            Me.fee = qs.Get("fee")
            Me.campaign = qs.Get("camp")
            Me.func = qs.Get("func")
            Me.funchead = qs.Get("funchead")
            Me.consol = qs.Get("consol")
            Me.pp = qs.Get("pp")
            Me.emp = qs.Get("emp")
            Me.empdate = qs.Get("empdate")
            Me.EmpGrid = qs.Get("empgrid")

            Me.CampaignCode = qs.CampaignCode
            Me.JobNumber = qs.JobNumber
            Me.ComponentNumber = qs.JobComponentNumber
            Me.FunctionCode = qs.FunctionCode
            Me.PostPeriod = qs.PostPeriod
            Me.Heading = qs.Get("fh")
            Me.ConsolidationCode = qs.Get("cc")

            If Request.QueryString("export") = 1 Then
                Me.RadGridWrapper.Visible = True
            Else
                Me.RadGridWrapper.Visible = False
            End If

            If Me.EmpGrid = 0 Then
                Me.RadGridServiceFeeEmp.Visible = False
            End If

            If Not Me.IsPostBack Then
                RadGridWrapper.DataSource = New String() {" "}
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String
                str = "ServiceFee" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
                If Me.EmpGrid = 0 Then
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridServiceFee, str)
                    RadGridServiceFee.MasterTableView.ExportToExcel()
                Else
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridWrapper, str)
                    RadGridWrapper.MasterTableView.ExportToExcel()
                End If
                Me.CloseThisWindow()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RadGridServiceFee_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridServiceFee.NeedDataSource
        Try
            If _ParameterDictionary Is Nothing Then

                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

            End If

            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = startperiod
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = endperiod
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 1
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = feeoption

            If display = "c" Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
            ElseIf display = "cdp" Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1
            End If
            If fee = 1 Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
            End If
            If campaign = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
            End If
            If job = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
            If func = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
            End If
            If funchead = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
            End If
            If consol = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
            If pp = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0
            End If

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If display = "c" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client).ToList
                ElseIf display = "cdp" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client And ServiceFee.DivisionCode = division And ServiceFee.ProductCode = product).ToList
                End If

                Me.RadGridServiceFee.DataSource = sf

                If display = "cdp" Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("cd")
                        .Display = True
                    End With
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("cdp")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("cd")
                        .Display = False
                    End With
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("cdp")
                        .Display = False
                    End With
                End If

                If fee = 1 Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("fee")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("fee")
                        .Display = False
                    End With
                End If
                If campaign = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("campaign")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("campaign")
                        .Display = False
                    End With
                End If
                If job = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("jc")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("jc")
                        .Display = False
                    End With
                End If
                If func = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("func")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("func")
                        .Display = False
                    End With
                End If
                If funchead = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("funchead")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("funchead")
                        .Display = False
                    End With
                End If
                If consol = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("consol")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("consol")
                        .Display = False
                    End With
                End If
                If pp = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("pp")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("pp")
                        .Display = False
                    End With
                End If

            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFee_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridServiceFee.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim di As GridDataItem = e.Item
                If job = True Then
                    Dim str3 As String = e.Item.Cells(7).Text
                    If e.Item.Cells(7).Text <> "0" And e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" Then
                        e.Item.Cells(7).Text = di.GetDataKeyValue("JobComponent").ToString.Replace("-", "/") & " - " & di.GetDataKeyValue("ComponentDescription")
                    ElseIf e.Item.Cells(7).Text = "0" Then
                        e.Item.Cells(7).Text = "Media Commissions"
                    End If
                End If
                If campaign = True Then
                    If e.Item.Cells(6).Text = "&nbsp;" And di.GetDataKeyValue("JobNumber") = 0 Then
                        e.Item.Cells(6).Text = "Media Commissions"
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim fee As Decimal
                Dim actual As Decimal

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    If GrpFtr("column36").Text <> "" Then
                        fee = CDec(GrpFtr("column36").Text)
                    End If
                    If GrpFtr("column35").Text <> "" Then
                        actual = CDec(GrpFtr("column35").Text)
                    End If

                    If fee > 0 Then
                        GrpFtr("taskcolumn").Text = String.Format("{0:#,##0.00}", (fee - actual))
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFeeEmp_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridServiceFeeEmp.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                If empdate = True Then
                    If e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then
                        e.Item.Cells(13).Text = LoGlo.FormatDate(e.Item.Cells(13).Text)
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim fee As Decimal
                Dim actual As Decimal

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    If GrpFtr("column36").Text <> "" Then
                        fee = CDec(GrpFtr("column36").Text)
                    End If
                    If GrpFtr("column35").Text <> "" Then
                        actual = CDec(GrpFtr("column35").Text)
                    End If

                    If fee > 0 Then
                        GrpFtr("taskcolumn").Text = String.Format("{0:#,##0.00}", (fee - actual))
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFeeEmp_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridServiceFeeEmp.NeedDataSource
        Try
            If _ParameterDictionary Is Nothing Then

                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

            End If

            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = startperiod
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = endperiod
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 1
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = feeoption

            If display = "c" Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
            ElseIf display = "cdp" Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1
            End If
            If fee = 1 Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
            End If
            If campaign = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
            End If
            If job = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
            If func = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
            End If
            If funchead = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
            End If
            If consol = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
            End If
            If emp = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
            End If
            If empdate = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
            End If
            If pp = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0
            End If

            'For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
            '    If gdi.Selected = True Then
            '        If campaign = True Then
            '            campaign = gdi.GetDataKeyValue("CampaignID")
            '        End If
            '        If job = True Then
            '            job = gdi.GetDataKeyValue("JobNumber")
            '            comp = gdi.GetDataKeyValue("ComponentNumber")
            '        End If
            '        If pp = True Then
            '            campaign = gdi.GetDataKeyValue("PostPeriodCode")
            '        End If
            '        If func = True Then
            '            func = gdi.GetDataKeyValue("FunctionCode")
            '        End If
            '        If funchead = True Then
            '            funchead = gdi.GetDataKeyValue("FunctionHeading")
            '        End If
            '        If consol = True Then
            '            consol = gdi.GetDataKeyValue("FunctionConsolidation")
            '        End If
            '    End If
            'Next

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If display = "c" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client).ToList
                ElseIf display = "cdp" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client And ServiceFee.DivisionCode = division And ServiceFee.ProductCode = product).ToList
                End If
                If campaign = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.CampaignID = CampaignCode).ToList
                End If
                If job = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.JobNumber = JobNumber And ServiceFee.ComponentNumber = ComponentNumber).ToList
                End If
                If func = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionCode = FunctionCode).ToList
                End If
                If funchead = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionHeading = Heading).ToList
                End If
                If consol = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionConsolidation = ConsolidationCode).ToList
                End If
                If pp = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.PostPeriodCode = PostPeriod).ToList
                End If

                Me.RadGridServiceFeeEmp.DataSource = sf

                If display = "cdp" Then
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("cd")
                        .Display = True
                    End With
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("cdp")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("cd")
                        .Display = False
                    End With
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("cdp")
                        .Display = False
                    End With
                End If

                If fee = 1 Then
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("fee")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("fee")
                        .Display = False
                    End With
                End If
                'If Me.CheckboxCampaign.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("campaign")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("campaign")
                '        .Display = False
                '    End With
                'End If
                'If Me.CheckboxJobComponent.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("jc")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("jc")
                '        .Display = False
                '    End With
                'End If
                'If Me.CheckboxFunction.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("func")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("func")
                '        .Display = False
                '    End With
                'End If
                'If Me.CheckboxFunctionHeading.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("funchead")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("funchead")
                '        .Display = False
                '    End With
                'End If
                'If Me.CheckboxFunctionConsolidation.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("consol")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("consol")
                '        .Display = False
                '    End With
                'End If
                'If Me.CheckboxPostPeriod.Checked = True Then
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("pp")
                '        .Display = True
                '    End With
                'Else
                '    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("pp")
                '        .Display = False
                '    End With
                'End If
                If emp = True Then
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("emp")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("emp")
                        .Display = False
                    End With
                End If
                If empdate = True Then
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("empdate")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("empdate")
                        .Display = False
                    End With
                End If

            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Export
    Public Sub RadGridSerFee_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs)
        Try
            sender.DataSource = Me.RadGridServiceFee.DataSource
            If display = "cdp" Then
                With sender.MasterTableView.GetColumn("cd")
                    .Display = True
                End With
                With sender.MasterTableView.GetColumn("cdp")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("cd")
                    .Display = False
                End With
                With sender.MasterTableView.GetColumn("cdp")
                    .Display = False
                End With
            End If

            If fee = 1 Then
                With sender.MasterTableView.GetColumn("fee")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("fee")
                    .Display = False
                End With
            End If
            If campaign = True Then
                With sender.MasterTableView.GetColumn("campaign")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("campaign")
                    .Display = False
                End With
            End If
            If job = True Then
                With sender.MasterTableView.GetColumn("jc")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("jc")
                    .Display = False
                End With
            End If
            If func = True Then
                With sender.MasterTableView.GetColumn("func")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("func")
                    .Display = False
                End With
            End If
            If funchead = True Then
                With sender.MasterTableView.GetColumn("funchead")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("funchead")
                    .Display = False
                End With
            End If
            If consol = True Then
                With sender.MasterTableView.GetColumn("consol")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("consol")
                    .Display = False
                End With
            End If
            If pp = True Then
                With sender.MasterTableView.GetColumn("pp")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("pp")
                    .Display = False
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridSerFee_ItemDataBound(sender As Object, e As GridItemEventArgs)
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim di As GridDataItem = e.Item
                If job = True Then
                    Dim str3 As String = e.Item.Cells(7).Text
                    If e.Item.Cells(7).Text <> "0" And e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" Then
                        e.Item.Cells(7).Text = di.GetDataKeyValue("JobComponent").ToString.Replace("-", "/") & " - " & di.GetDataKeyValue("ComponentDescription")
                    ElseIf e.Item.Cells(7).Text = "0" Then
                        e.Item.Cells(7).Text = "Media Commissions"
                    End If
                End If
                If campaign = True Then
                    If e.Item.Cells(6).Text = "&nbsp;" And di.GetDataKeyValue("JobNumber") = 0 Then
                        e.Item.Cells(6).Text = "Media Commissions"
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim fee As Decimal
                Dim actual As Decimal

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    If GrpFtr("column36").Text <> "" Then
                        fee = CDec(GrpFtr("column36").Text)
                    End If
                    If GrpFtr("column35").Text <> "" Then
                        actual = CDec(GrpFtr("column35").Text)
                    End If

                    If fee > 0 Then
                        GrpFtr("taskcolumn").Text = String.Format("{0:#,##0.00}", (fee - actual))
                    End If

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridSerFeeEmp_ItemDataBound(sender As Object, e As GridItemEventArgs)
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                If empdate = True Then
                    If e.Item.Cells(13).Text <> "" And e.Item.Cells(13).Text <> "&nbsp;" Then
                        e.Item.Cells(13).Text = LoGlo.FormatDate(e.Item.Cells(13).Text)
                    End If
                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim fee As Decimal
                Dim actual As Decimal

                e.Item.Font.Bold = True

                Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then

                    If GrpFtr("column36").Text <> "" Then
                        fee = CDec(GrpFtr("column36").Text)
                    End If
                    If GrpFtr("column35").Text <> "" Then
                        actual = CDec(GrpFtr("column35").Text)
                    End If

                    If fee > 0 Then
                        GrpFtr("taskcolumn").Text = String.Format("{0:#,##0.00}", (fee - actual))
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RadGridSerFeeEmp_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs)
        Try
            sender.DataSource = Me.RadGridServiceFeeEmp.DataSource
            If display = "cdp" Then
                With sender.MasterTableView.GetColumn("cd")
                    .Display = True
                End With
                With sender.MasterTableView.GetColumn("cdp")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("cd")
                    .Display = False
                End With
                With sender.MasterTableView.GetColumn("cdp")
                    .Display = False
                End With
            End If

            'If fee = 1 Then
            '    With sender.MasterTableView.GetColumn("fee")
            '        .Display = True
            '    End With
            'Else
            '    With sender.MasterTableView.GetColumn("fee")
            '        .Display = False
            '    End With
            'End If
            If emp = True Then
                With sender.MasterTableView.GetColumn("emp")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("emp")
                    .Display = False
                End With
            End If
            If empdate = True Then
                With sender.MasterTableView.GetColumn("empdate")
                    .Display = True
                End With
            Else
                With sender.MasterTableView.GetColumn("empdate")
                    .Display = False
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

#End Region

#Region " Functions "



#End Region






    
End Class