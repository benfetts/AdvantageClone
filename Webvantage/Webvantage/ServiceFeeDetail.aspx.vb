Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting



Partial Public Class ServiceFeeDetail
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
    Private campaign As Integer = 0
    Private job As Integer = 0
    Private comp As Integer = 0
    Private func As String = ""
    Private funchead As String = ""
    Private consol As String = ""
    Private pp As String = ""
    Private emp As Integer = 0
    Private empdate As Integer = 0
    Private startperiod As String = ""
    Private endperiod As String = ""
    Private feeoption As String = ""
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing

#End Region

#Region " Page Functions "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Request.QueryString("display") <> "" Then
                display = Request.QueryString("display")
            End If
            If Request.QueryString("c") <> "" Then
                client = Request.QueryString("c")

                Me.PageTitle = "Service Fee Detail (" & client & ")"

            End If
            If Request.QueryString("d") <> "" Then
                division = Request.QueryString("d")
            End If
            If Request.QueryString("p") <> "" Then
                product = Request.QueryString("p")
            End If
            If Request.QueryString("fee") <> "" Then
                fee = Request.QueryString("fee")
            End If
            If Request.QueryString("start") <> "" Then
                startperiod = Request.QueryString("start")
            End If
            If Request.QueryString("end") <> "" Then
                endperiod = Request.QueryString("end")
            End If
            If Request.QueryString("feeoption") <> "" Then
                feeoption = Request.QueryString("feeoption")
            End If

            If Not Me.IsPostBack Then
                Me.PanelEmployee.Visible = False
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim count As Integer = 0
            Dim qs As New AdvantageFramework.Web.QueryString()
            With qs

                .Page = "ServiceFeeDetailPrint.aspx"
                .ClientCode = client
                .DivisionCode = division
                .ProductCode = product
                .Add("speriod", startperiod)
                .Add("eperiod", endperiod)
                .Add("feeoption", feeoption)
                .Add("display", display)
                .Add("fee", fee)
                .Add("camp", Me.CheckboxCampaign.Checked)
                .Add("job", Me.CheckboxJobComponent.Checked)
                .Add("func", Me.CheckboxFunction.Checked)
                .Add("funchead", Me.CheckboxFunctionHeading.Checked)
                .Add("consol", Me.CheckboxFunctionConsolidation.Checked)
                .Add("pp", Me.CheckboxPostPeriod.Checked)
                .Add("emp", Me.CheckboxEmployee.Checked)
                .Add("empdate", Me.CheckboxEmployeeDate.Checked)
                .Add("export", 1)

                For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
                    If gdi.Selected = True Then
                        If CheckboxCampaign.Checked = True Then
                            .CampaignCode = gdi.GetDataKeyValue("CampaignID")
                        End If
                        If CheckboxJobComponent.Checked = True Then
                            .JobNumber = gdi.GetDataKeyValue("JobNumber")
                            .JobComponentNumber = gdi.GetDataKeyValue("ComponentNumber")
                        End If
                        If CheckboxPostPeriod.Checked = True Then
                            .PostPeriod = gdi.GetDataKeyValue("PostPeriodCode")
                        End If
                        If CheckboxFunction.Checked = True Then
                            .FunctionCode = gdi.GetDataKeyValue("FunctionCode")
                        End If
                        If CheckboxFunctionHeading.Checked = True Then
                            .Add("fh", gdi.GetDataKeyValue("FunctionHeading"))
                        End If
                        If CheckboxFunctionConsolidation.Checked = True Then
                            .Add("cc", gdi.GetDataKeyValue("FunctionConsolidation"))
                        End If
                        count += 1
                    End If
                Next
                If count > 0 Then
                    .Add("empgrid", 1)
                Else
                    .Add("empgrid", 0)
                End If
            End With
            Me.RadToolBarButtonExport.Attributes.Add("onclick", "window.open('" & qs.ToString(True) & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")

            Dim qs2 As New AdvantageFramework.Web.QueryString()
            With qs2

                .Page = "ServiceFeeDetailPrint.aspx"
                .ClientCode = client
                .DivisionCode = division
                .ProductCode = product
                .Add("speriod", startperiod)
                .Add("eperiod", endperiod)
                .Add("feeoption", feeoption)
                .Add("display", display)
                .Add("fee", fee)
                .Add("camp", Me.CheckboxCampaign.Checked)
                .Add("job", Me.CheckboxJobComponent.Checked)
                .Add("func", Me.CheckboxFunction.Checked)
                .Add("funchead", Me.CheckboxFunctionHeading.Checked)
                .Add("consol", Me.CheckboxFunctionConsolidation.Checked)
                .Add("pp", Me.CheckboxPostPeriod.Checked)
                .Add("emp", Me.CheckboxEmployee.Checked)
                .Add("empdate", Me.CheckboxEmployeeDate.Checked)

                For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
                    If gdi.Selected = True Then
                        If CheckboxCampaign.Checked = True Then
                            .CampaignCode = gdi.GetDataKeyValue("CampaignID")
                        End If
                        If CheckboxJobComponent.Checked = True Then
                            .JobNumber = gdi.GetDataKeyValue("JobNumber")
                            .JobComponentNumber = gdi.GetDataKeyValue("ComponentNumber")
                        End If
                        If CheckboxPostPeriod.Checked = True Then
                            .PostPeriod = gdi.GetDataKeyValue("PostPeriodCode")
                        End If
                        If CheckboxFunction.Checked = True Then
                            .FunctionCode = gdi.GetDataKeyValue("FunctionCode")
                        End If
                        If CheckboxFunctionHeading.Checked = True Then
                            .Add("fh", gdi.GetDataKeyValue("FunctionHeading"))
                        End If
                        If CheckboxFunctionConsolidation.Checked = True Then
                            .Add("cc", gdi.GetDataKeyValue("FunctionConsolidation"))
                        End If
                        count += 1
                    End If
                Next
                If count > 0 Then
                    .Add("empgrid", 1)
                Else
                    .Add("empgrid", 0)
                End If

            End With

            Me.RadToolBarButtonPrint.Attributes.Add("onclick", "window.open('" & qs2.ToString(True) & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")

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
            If Me.CheckboxCampaign.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
            End If
            If Me.CheckboxJobComponent.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
            If Me.CheckboxFunction.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
            End If
            If Me.CheckboxFunctionHeading.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
            End If
            If Me.CheckboxFunctionConsolidation.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
            If Me.CheckboxPostPeriod.Checked = True Then
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
                If Me.CheckboxCampaign.Checked = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("campaign")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("campaign")
                        .Display = False
                    End With
                End If
                If Me.CheckboxJobComponent.Checked = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("jc")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("jc")
                        .Display = False
                    End With
                End If
                If Me.CheckboxFunction.Checked = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("func")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("func")
                        .Display = False
                    End With
                End If
                If Me.CheckboxFunctionHeading.Checked = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("funchead")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("funchead")
                        .Display = False
                    End With
                End If
                If Me.CheckboxFunctionConsolidation.Checked = True Then
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("consol")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFee.MasterTableView.GetColumn("consol")
                        .Display = False
                    End With
                End If
                If Me.CheckboxPostPeriod.Checked = True Then
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

    Private Sub RadGridServiceFee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridServiceFee.SelectedIndexChanged
        Try
            Me.PanelEmployee.Visible = True
            For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
                If gdi.Selected = True Then
                    If CheckboxCampaign.Checked = True Then
                        campaign = gdi.GetDataKeyValue("CampaignID")
                    End If
                    If CheckboxJobComponent.Checked = True Then
                        job = gdi.GetDataKeyValue("JobNumber")
                        comp = gdi.GetDataKeyValue("ComponentNumber")
                    End If
                    If CheckboxPostPeriod.Checked = True Then
                        campaign = gdi.GetDataKeyValue("PostPeriodCode")
                    End If
                    If CheckboxFunction.Checked = True Then
                        func = gdi.GetDataKeyValue("FunctionCode")
                    End If
                    If CheckboxFunctionHeading.Checked = True Then
                        funchead = gdi.GetDataKeyValue("FunctionHeading")
                    End If
                    If CheckboxFunctionConsolidation.Checked = True Then
                        consol = gdi.GetDataKeyValue("FunctionConsolidation")
                    End If
                End If
            Next
            RadGridServiceFeeEmp.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFee_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridServiceFee.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim di As GridDataItem = e.Item
                If Me.CheckboxJobComponent.Checked = True Then
                    Dim str3 As String = e.Item.Cells(7).Text
                    If e.Item.Cells(7).Text <> "0" And e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" Then
                        e.Item.Cells(7).Text = di.GetDataKeyValue("JobComponent").ToString.Replace("-", "/") & " - " & di.GetDataKeyValue("ComponentDescription")
                    ElseIf e.Item.Cells(7).Text = "0" Then
                        e.Item.Cells(7).Text = "Media Commissions"
                    End If
                End If
                If Me.CheckboxCampaign.Checked = True Then
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
                If Me.CheckboxEmployeeDate.Checked = True Then
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
            If Me.CheckboxCampaign.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
            End If
            If Me.CheckboxJobComponent.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
            End If
            _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
            If Me.CheckboxFunction.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
            End If
            If Me.CheckboxFunctionHeading.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
            End If
            If Me.CheckboxFunctionConsolidation.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
            End If
            If Me.CheckboxEmployee.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
            End If
            If Me.CheckboxEmployeeDate.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 1
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
            End If
            If Me.CheckboxPostPeriod.Checked = True Then
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 1
            Else
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0
            End If

            For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
                If gdi.Selected = True Then
                    If CheckboxCampaign.Checked = True Then
                        campaign = gdi.GetDataKeyValue("CampaignID")
                    End If
                    If CheckboxJobComponent.Checked = True Then
                        job = gdi.GetDataKeyValue("JobNumber")
                        comp = gdi.GetDataKeyValue("ComponentNumber")
                    End If
                    If CheckboxPostPeriod.Checked = True Then
                        pp = gdi.GetDataKeyValue("PostPeriodCode")
                    End If
                    If CheckboxFunction.Checked = True Then
                        func = gdi.GetDataKeyValue("FunctionCode")
                    End If
                    If CheckboxFunctionHeading.Checked = True Then
                        funchead = gdi.GetDataKeyValue("FunctionHeading")
                    End If
                    If CheckboxFunctionConsolidation.Checked = True Then
                        consol = gdi.GetDataKeyValue("FunctionConsolidation")
                    End If
                End If
            Next

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If display = "c" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client).ToList
                ElseIf display = "cdp" Then
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client And ServiceFee.DivisionCode = division And ServiceFee.ProductCode = product).ToList
                End If
                If Me.CheckboxCampaign.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.CampaignID = campaign).ToList
                End If
                If Me.CheckboxJobComponent.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.JobNumber = job And ServiceFee.ComponentNumber = comp).ToList
                End If
                If Me.CheckboxFunction.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionCode = func).ToList
                End If
                If Me.CheckboxFunctionHeading.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionHeading = funchead).ToList
                End If
                If Me.CheckboxFunctionConsolidation.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.FunctionConsolidation = consol).ToList
                End If
                If Me.CheckboxPostPeriod.Checked = True Then
                    sf = sf.Where(Function(ServiceFee) ServiceFee.PostPeriodCode = pp).ToList
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
                If Me.CheckboxEmployee.Checked = True Then
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("emp")
                        .Display = True
                    End With
                Else
                    With Me.RadGridServiceFeeEmp.MasterTableView.GetColumn("emp")
                        .Display = False
                    End With
                End If
                If Me.CheckboxEmployeeDate.Checked = True Then
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

#End Region

#Region " Data Functions "



#End Region

#Region " Controls "

    Private Sub CheckboxCampaign_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxCampaign.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxFunction_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxFunction.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxFunctionConsolidation_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxFunctionConsolidation.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxFunctionHeading_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxFunctionHeading.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxJobComponent_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxJobComponent.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxPostPeriod_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxPostPeriod.CheckedChanged
        Try
            RadGridServiceFee.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxEmployee.CheckedChanged
        Try
            RadGridServiceFeeEmp.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxEmployeeDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxEmployeeDate.CheckedChanged
        Try
            RadGridServiceFeeEmp.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadToolbarServiceFee_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarServiceFee.ButtonClick
        Try
            Dim count As Integer = 0
            'Select Case e.Item.Value
            '    Case "Print"
            '        Dim qs As New AdvantageFramework.Web.QueryString()
            '        With qs

            '            .Page = "ServiceFeeDetailPrint.aspx"
            '            .ClCode = client
            '            .DivCode = division
            '            .PrdCode = product
            '            .Add("speriod", startperiod)
            '            .Add("eperiod", endperiod)
            '            .Add("feeoption", feeoption)
            '            .Add("display", display)
            '            .Add("fee", fee)
            '            .Add("camp", Me.CheckboxCampaign.Checked)
            '            .Add("job", Me.CheckboxJobComponent.Checked)
            '            .Add("func", Me.CheckboxFunction.Checked)
            '            .Add("funchead", Me.CheckboxFunctionHeading.Checked)
            '            .Add("consol", Me.CheckboxFunctionConsolidation.Checked)
            '            .Add("pp", Me.CheckboxPostPeriod.Checked)
            '            .Add("emp", Me.CheckboxEmployee.Checked)
            '            .Add("empdate", Me.CheckboxEmployeeDate.Checked)

            '            For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
            '                If gdi.Selected = True Then
            '                    If CheckboxCampaign.Checked = True Then
            '                        .CampaignCode = gdi.GetDataKeyValue("CampaignID")
            '                    End If
            '                    If CheckboxJobComponent.Checked = True Then
            '                        .JobNumber = gdi.GetDataKeyValue("JobNumber")
            '                        .JobComponentNbr = gdi.GetDataKeyValue("ComponentNumber")
            '                    End If
            '                    If CheckboxPostPeriod.Checked = True Then
            '                        .PostPeriod = gdi.GetDataKeyValue("PostPeriodCode")
            '                    End If
            '                    If CheckboxFunction.Checked = True Then
            '                        .FunctionCode = gdi.GetDataKeyValue("FunctionCode")
            '                    End If
            '                    If CheckboxFunctionHeading.Checked = True Then
            '                        .Add("fh", gdi.GetDataKeyValue("FunctionHeading"))
            '                    End If
            '                    If CheckboxFunctionConsolidation.Checked = True Then
            '                        .Add("cc", gdi.GetDataKeyValue("FunctionConsolidation"))
            '                    End If
            '                    count += 1
            '                End If
            '            Next
            '            If count > 0 Then
            '                .Add("empgrid", 1)
            '            Else
            '                .Add("empgrid", 0)
            '            End If

            '        End With
            '        Me.OpenWindow("Service Fee", qs.ToString(True))
            '        'Case "ExportExcel"
            '        '    Dim qs As New AdvantageFramework.Web.QueryString()
            '        '    With qs

            '        '        .Page = "ServiceFeeDetailPrint.aspx"
            '        '        .ClCode = client
            '        '        .DivCode = division
            '        '        .PrdCode = product
            '        '        .Add("speriod", startperiod)
            '        '        .Add("eperiod", endperiod)
            '        '        .Add("feeoption", feeoption)
            '        '        .Add("display", display)
            '        '        .Add("fee", fee)
            '        '        .Add("camp", Me.CheckboxCampaign.Checked)
            '        '        .Add("job", Me.CheckboxJobComponent.Checked)
            '        '        .Add("func", Me.CheckboxFunction.Checked)
            '        '        .Add("funchead", Me.CheckboxFunctionHeading.Checked)
            '        '        .Add("consol", Me.CheckboxFunctionConsolidation.Checked)
            '        '        .Add("pp", Me.CheckboxPostPeriod.Checked)
            '        '        .Add("emp", Me.CheckboxEmployee.Checked)
            '        '        .Add("empdate", Me.CheckboxEmployeeDate.Checked)
            '        '        .Add("export", 1)

            '        '        For Each gdi As Telerik.Web.UI.GridDataItem In RadGridServiceFee.MasterTableView.Items
            '        '            If gdi.Selected = True Then
            '        '                If CheckboxCampaign.Checked = True Then
            '        '                    .CampaignCode = gdi.GetDataKeyValue("CampaignID")
            '        '                End If
            '        '                If CheckboxJobComponent.Checked = True Then
            '        '                    .JobNumber = gdi.GetDataKeyValue("JobNumber")
            '        '                    .JobComponentNbr = gdi.GetDataKeyValue("ComponentNumber")
            '        '                End If
            '        '                If CheckboxPostPeriod.Checked = True Then
            '        '                    .PostPeriod = gdi.GetDataKeyValue("PostPeriodCode")
            '        '                End If
            '        '                If CheckboxFunction.Checked = True Then
            '        '                    .FunctionCode = gdi.GetDataKeyValue("FunctionCode")
            '        '                End If
            '        '                If CheckboxFunctionHeading.Checked = True Then
            '        '                    .Add("fh", gdi.GetDataKeyValue("FunctionHeading"))
            '        '                End If
            '        '                If CheckboxFunctionConsolidation.Checked = True Then
            '        '                    .Add("cc", gdi.GetDataKeyValue("FunctionConsolidation"))
            '        '                End If
            '        '            End If
            '        '        Next
            '        '    End With
            '        '    Me.OpenWindow("Service Fee", qs.ToString(True))
            'End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "



#End Region






End Class
