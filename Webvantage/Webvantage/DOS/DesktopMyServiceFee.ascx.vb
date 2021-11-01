Imports System
Imports System.Text
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Webvantage.MiscFN
Imports Telerik.Web.UI
Imports System.Collections.Generic

Partial Public Class DesktopMyServiceFee
    Inherits Webvantage.BaseDesktopObject

    Dim agy_setting As Int16
    Dim oSQL As SqlHelper
    Dim SQL_STRING As String
    Dim dr As SqlDataReader
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing
    Private _ServiceFeeComplex As AdvantageFramework.Reporting.Database.Classes.ServiceFee
    Private client As String = ""
    Private division As String = ""
    Private product As String = ""


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            'Check Agency Maintenance Setting
            agy_setting = getAgencySetting()

            If agy_setting <> 1 Then
                'Do not display data
                ddPPBegin.Visible = False
                Label3.Visible = False
                ddPPEnd.Visible = False
                Exit Sub

            Else
                LoadDropDowns()
                GetCurrentPP()
                Me.RadioButtonClient.Checked = True
                Me.RadGridServiceFeeCDP.Visible = False
                Me.RadGridServiceFeeClient.Visible = True
                RadioButtonEmployeeDefault.Checked = True
            End If
        End If

        Chartload()

    End Sub

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDO.GetAgencySetting("AGENCY_GOALS_ON")
        Return AgySetting
    End Function

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddPPBegin
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddPPEnd
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        Session("OFFICE_AGLSG") = ""

    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_AGLSG") = firstPeriod
        Session("PPEND_AGLSG") = currentPeriod

    End Function

    Private DtGraphData As New DataTable
    Private Sub Chartload()
        Try
            If ddPPBegin.SelectedValue <= ddPPEnd.SelectedValue Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = ddPPBegin.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = ddPPEnd.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 2
                If RadioButtonEmployeeDefault.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "def"
                ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "time"
                ElseIf RadioButtonJobComponent.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "job"
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ""
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                If Me.RadioButtonClient.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
                ElseIf Me.RadioButtonCDP.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0

                If Me.RadioButtonClient.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeClient.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                        End If
                    Next
                End If

                If Me.RadioButtonCDP.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeCDP.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                            division = gridDataItem.GetDataKeyValue("DivisionCode")
                            product = gridDataItem.GetDataKeyValue("ProductCode")
                        End If
                    Next
                End If

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.RadioButtonClient.Checked = True And client <> "" Then
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client).ToList.FirstOrDefault
                    ElseIf Me.RadioButtonCDP.Checked = True And client <> "" And division <> "" And product <> "" Then
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = client And ServiceFee.DivisionCode = division And ServiceFee.ProductCode = product).ToList.FirstOrDefault
                    Else
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.Hours <> 0 Or ServiceFee.Amount <> 0 Or ServiceFee.FeeAmount <> 0).ToList.FirstOrDefault
                    End If

                    If Me.CheckboxFeeType.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                    End If

                End Using

                CreateChart()

            Else

                Me.ShowMessage("Please select a starting post period that is before the ending post period.")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CreateChart()

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim Level As String = ""
        Dim IsFeeType As Short = 0
        Dim FeeOption As String = ""
        Dim SeriesClickURL As String = ""

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Dim IsFee As Short = 0

        Try

            RadHtmlChartMyServiceFees.PlotArea.Series.Clear()
            RadHtmlChartMyServiceFees.PlotArea.XAxis.Items.Clear()

            RadHtmlChartMyServiceFees.Legend.Appearance.Visible = False
            RadHtmlChartMyServiceFees.PlotArea.XAxis.MinorGridLines.Visible = False
            RadHtmlChartMyServiceFees.PlotArea.XAxis.MajorGridLines.Visible = False
            RadHtmlChartMyServiceFees.PlotArea.YAxis.MinorGridLines.Visible = False

            RadHtmlChartMyServiceFees.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(_ServiceFeeComplex.ClientDescription)
            RadHtmlChartMyServiceFees.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top
            RadHtmlChartMyServiceFees.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center

            If Me.RadioButtonClient.Checked = True Then

                Level = "c"

            Else

                Level = "cdp"

            End If

            If Me.CheckboxFeeType.Checked = True Then

                IsFee = 1

            End If

            If RadioButtonEmployeeDefault.Checked = True Then

                FeeOption = "def"

            ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then

                FeeOption = "time"

            ElseIf RadioButtonJobComponent.Checked = True Then

                FeeOption = "job"

            Else

                FeeOption = ""

            End If

            ColumnSeries = New Telerik.Web.UI.ColumnSeries
            ColumnSeries.Name = "Service Fees"
            ColumnSeries.LabelsAppearance.Visible = False
            ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

            Colors = New AdvantageFramework.Web.Presentation.Colors

            If _ServiceFeeComplex IsNot Nothing Then

                ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.FeeAmount.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                'ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.Hours.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Orange, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.Amount.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Blue, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                SeriesClickURL = "ServiceFeeDetail.aspx?display=" & Level & "&fee=" & IsFee & "&c=" & _ServiceFeeComplex.ClientCode & "&d=" & _ServiceFeeComplex.DivisionCode & "&p=" & _ServiceFeeComplex.ProductCode & "&start=" & Me.ddPPBegin.SelectedValue & "&end=" & Me.ddPPEnd.SelectedValue & "&FeeOption=" & FeeOption

            End If

            RadHtmlChartMyServiceFees.PlotArea.XAxis.Items.Add("Fee Billed")
            'RadHtmlChartMyServiceFees.PlotArea.XAxis.Items.Add("Actual Hours")
            RadHtmlChartMyServiceFees.PlotArea.XAxis.Items.Add("Actual Amount")

            RadHtmlChartMyServiceFees.PlotArea.Series.Add(ColumnSeries)

            RadHtmlChartMyServiceFees.PlotArea.XAxis.LabelsAppearance.Visible = True

            RadHtmlChartMyServiceFees.Attributes("SERIES_CLICK_URL") = SeriesClickURL

        Catch ex As Exception

        End Try

    End Sub

    Public Function WriteURL() As String
        Dim str As String = getFCXMLData_BarPie_agencyGoals(DtGraphData, "", False)
        Return str
    End Function

    Public Function getFCXMLData_BarPie_agencyGoals(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strColor(10) As String
            strColor(0) = "D00000" '"AFD8F8" 'Baby blue
            strColor(1) = "F6BD0F" 'gold
            strColor(2) = "A66EDD" 'purple
            strColor(3) = "8BBA00" 'green
            strColor(4) = "FF8000" 'orange
            strColor(5) = "AFD8F8" 'baby blue
            strColor(6) = "999999" 'gray
            strColor(7) = "005500" 'dark green
            strColor(8) = "AA0000" 'dark red
            strColor(9) = "0372AB" 'darker blue

            Dim c As String = ""
            Dim fee As Integer = 0
            Dim camp As Integer = 0
            Dim jc As Integer = 0
            Dim func As Integer = 0
            Dim funchead As Integer = 0
            Dim consol As Integer = 0
            Dim pp As Integer = 0
            Dim emp As Integer = 0
            Dim empdate As Integer = 0
            Dim feeoption As String = ""

            If Me.RadioButtonClient.Checked = True Then
                c = "c"
            Else
                c = "cdp"
            End If
            If Me.CheckboxFeeType.Checked = True Then
                fee = 1
            End If
            'If Me.CheckboxCampaign.Checked = True Then
            '    camp = 1
            'End If
            'If Me.CheckboxJobComponent.Checked = True Then
            '    jc = 1
            'End If
            'If Me.CheckboxFunction.Checked = True Then
            '    func = 1
            'End If
            'If Me.CheckboxFunctionHeading.Checked = True Then
            '    funchead = 1
            'End If
            'If Me.CheckboxFunctionConsolidation.Checked = True Then
            '    consol = 1
            'End If
            'If Me.CheckboxPostPeriod.Checked = True Then
            '    pp = 1
            'End If
            'If Me.CheckboxEmployee.Checked = True Then
            '    emp = 1
            'End If
            'If Me.CheckboxEmployeeDate.Checked = True Then
            '    empdate = 1
            'End If
            If RadioButtonEmployeeDefault.Checked = True Then
                feeoption = "def"
            ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                feeoption = "time"
            ElseIf RadioButtonJobComponent.Checked = True Then
                feeoption = "job"
            Else
                feeoption = ""
            End If

            Dim i As Integer = 0
            With sbFCXMLData
                'Initialize the XML String
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    .Append("<graph caption='" & _ServiceFeeComplex.ClientDescription.Replace("'", "") & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    .Append("<graph caption='" & _ServiceFeeComplex.ClientDescription.Replace("'", "") & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    .Append("<graph caption='" & _ServiceFeeComplex.ClientDescription.Replace("'", "") & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' >" & vbCrLf)
                End If
                'For Each ServiceFee In _ServiceFeeComplex
                If Me.RadioButtonClient.Checked = True Then
                    .Append("<set name='Fee Billed' value='" & _ServiceFeeComplex.FeeAmount & "' color='" & strColor(0 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                    .Append("<set name='Actual Hours' value='" & _ServiceFeeComplex.Hours & "' color='" & strColor(1 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                    .Append("<set name='Actual Amount' value='" & _ServiceFeeComplex.Amount & "' color='" & strColor(2 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                ElseIf Me.RadioButtonCDP.Checked = True Then
                    .Append("<set name='Fee Billed' value='" & _ServiceFeeComplex.FeeAmount & "' color='" & strColor(0 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                    .Append("<set name='Actual Hours' value='" & _ServiceFeeComplex.Hours & "' color='" & strColor(1 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                    .Append("<set name='Actual Amount' value='" & _ServiceFeeComplex.Amount & "' color='" & strColor(2 Mod 10) & "' link=%22JavaScript:OpenRadWindow('','ServiceFeeDetail.aspx%3Fdisplay%3D" & c & "%26fee%3D" & fee & "%26c%3D" & _ServiceFeeComplex.ClientCode & "%26d%3D" & _ServiceFeeComplex.DivisionCode & "%26p%3D" & _ServiceFeeComplex.ProductCode & "%26start%3D" & Me.ddPPBegin.SelectedValue & "%26end%3D" & Me.ddPPEnd.SelectedValue & "%26feeoption%3D" & feeoption & "', '800','1200');%22/>" & vbCrLf)
                End If

                i += 1
                'Next
                .Append("</graph>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_BarPie_agencyGoals Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function

    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function

    'Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
    '    Dim image As String

    '    image = butRefresh.ImageUrl
    '    If image <> "~/Images/lock16.png" Then
    '        LoadChart()
    '    End If

    'End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub RadioButtonClient_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClient.CheckedChanged
        Try
            If RadioButtonClient.Checked = True Then
                Me.RadGridServiceFeeCDP.Visible = False
                Me.RadGridServiceFeeClient.Visible = True
                Chartload()
                Me.RadGridServiceFeeClient.Rebind()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonCDP_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCDP.CheckedChanged
        Try
            If RadioButtonCDP.Checked = True Then
                Me.RadGridServiceFeeCDP.Visible = True
                Me.RadGridServiceFeeClient.Visible = False
                Chartload()
                Me.RadGridServiceFeeCDP.Rebind()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckboxFeeType_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxFeeType.CheckedChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonEmployeeDefault_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEmployeeDefault.CheckedChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonEmployeeTimeEntry_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEmployeeTimeEntry.CheckedChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonJobComponent_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonJobComponent.CheckedChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonNone_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNone.CheckedChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridServiceFeeClient_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridServiceFeeClient.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case Telerik.Web.UI.GridItemType.Footer
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
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridServiceFeeClient_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridServiceFeeClient.PageIndexChanged
        'Try
        '    Chartload()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub RadGridServiceFeeClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridServiceFeeClient.SelectedIndexChanged
        Try
            Chartload()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridServiceFeeClient_PageSizeChanged1(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridServiceFeeClient.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridServiceFeeClient.ID, e.NewPageSize)
        Chartload()
    End Sub

    Private Sub RadGridServiceFeeCDP_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridServiceFeeCDP.PageIndexChanged
        'Try
        '    Chartload()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub RadGridServiceFeeCDP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridServiceFeeCDP.SelectedIndexChanged
        Try
            Chartload()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridServiceFeeCDP_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridServiceFeeCDP.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridServiceFeeCDP.ID, e.NewPageSize)
        Chartload()
    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        Try
            Chartload()
            Me.RadGridServiceFeeCDP.Rebind()
            Me.RadGridServiceFeeClient.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImageButtonExportExcel_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExportExcel.Click
        'Chartload()
        Chartload()
        Dim str As String = ""
        If Me.RadioButtonClient.Checked = True Then
            str = "ServiceFee" & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridServiceFeeClient, str)
            RadGridServiceFeeClient.MasterTableView.ExportToExcel()
        End If
        If Me.RadioButtonCDP.Checked = True Then
            str = "ServiceFee" & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridServiceFeeCDP, str)
            RadGridServiceFeeCDP.MasterTableView.ExportToExcel()
        End If

    End Sub

    Private Sub ImageButtonPrint_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonPrint.Click
        If Me.RadioButtonClient.Checked = True Then
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeClient.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("ClientCode")
                End If
            Next
        End If

        If Me.RadioButtonCDP.Checked = True Then
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeCDP.MasterTableView.Items
                If gridDataItem.Selected = True Then
                    client = gridDataItem.GetDataKeyValue("ClientCode")
                    division = gridDataItem.GetDataKeyValue("DivisionCode")
                    product = gridDataItem.GetDataKeyValue("ProductCode")
                End If
            Next
        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "dtp_servicefee.aspx"
            .ClientCode = client
            .DivisionCode = division
            .ProductCode = product
            .Add("speriod", Me.ddPPBegin.SelectedValue)
            .Add("eperiod", Me.ddPPEnd.SelectedValue)
            If RadioButtonEmployeeDefault.Checked = True Then
                .Add("sfeetype", "def")
            ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                .Add("sfeetype", "time")
            ElseIf RadioButtonJobComponent.Checked = True Then
                .Add("sfeetype", "job")
            Else
                .Add("sfeetype", "")
            End If
            If Me.RadioButtonClient.Checked = True Then
                .Add("ctype", "c")
            ElseIf Me.RadioButtonCDP.Checked = True Then
                .Add("ctype", "cdp")
            End If
            .Add("feetype", Me.CheckboxFeeType.Checked)
            .Add("my", 1)
        End With

        Me.OpenFloatingWindow("Service Fee", qs.ToString(True))

        Chartload()

    End Sub

    Private Sub ImageButtonRefresh_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefresh.Click

        Chartload()
        Me.RadGridServiceFeeCDP.Rebind()
        Me.RadGridServiceFeeClient.Rebind()

    End Sub

    Private Sub RadGridServiceFeeClient_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridServiceFeeClient.NeedDataSource
        Try
            If ddPPBegin.SelectedValue <= ddPPEnd.SelectedValue Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = ddPPBegin.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = ddPPEnd.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 2
                If RadioButtonEmployeeDefault.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "def"
                ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "time"
                ElseIf RadioButtonJobComponent.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "job"
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ""
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                If Me.RadioButtonClient.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
                ElseIf Me.RadioButtonCDP.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0

                If Me.RadioButtonClient.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeClient.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                        End If
                    Next
                End If

                If Me.RadioButtonCDP.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeCDP.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                            division = gridDataItem.GetDataKeyValue("DivisionCode")
                            product = gridDataItem.GetDataKeyValue("ProductCode")
                        End If
                    Next
                End If

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.CheckboxFeeType.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                    End If
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.Hours <> 0 Or ServiceFee.Amount <> 0 Or ServiceFee.FeeAmount <> 0).ToList

                    Me.RadGridServiceFeeClient.DataSource = sf

                    If Me.CheckboxFeeType.Checked = True Then
                        With Me.RadGridServiceFeeClient.MasterTableView.GetColumn("fee")
                            .Display = True
                        End With
                    Else
                        With Me.RadGridServiceFeeClient.MasterTableView.GetColumn("fee")
                            .Display = False
                        End With
                    End If

                End Using

            Else

                Me.ShowMessage("Please select a starting post period that is before the ending post period.")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFeeCDP_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridServiceFeeCDP.NeedDataSource
        Try
            If ddPPBegin.SelectedValue <= ddPPEnd.SelectedValue Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = ddPPBegin.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = ddPPEnd.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 2
                If RadioButtonEmployeeDefault.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "def"
                ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "time"
                ElseIf RadioButtonJobComponent.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "job"
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ""
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                If Me.RadioButtonClient.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
                ElseIf Me.RadioButtonCDP.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 1
                End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeCampaign.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeJobNumber.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeSalesClass.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionCode.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFunctionHeading.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeConsolidation.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeEmployee.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDate.ToString) = 0
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludePostPeriod.ToString) = 0

                If Me.RadioButtonClient.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeClient.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                        End If
                    Next
                End If

                If Me.RadioButtonCDP.Checked = True Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeCDP.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            client = gridDataItem.GetDataKeyValue("ClientCode")
                            division = gridDataItem.GetDataKeyValue("DivisionCode")
                            product = gridDataItem.GetDataKeyValue("ProductCode")
                        End If
                    Next
                End If

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Me.CheckboxFeeType.Checked = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                    End If
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.Hours <> 0 Or ServiceFee.Amount <> 0 Or ServiceFee.FeeAmount <> 0).ToList

                    Me.RadGridServiceFeeCDP.DataSource = sf

                    If Me.CheckboxFeeType.Checked = True Then
                        With Me.RadGridServiceFeeCDP.MasterTableView.GetColumn("fee")
                            .Display = True
                        End With
                    Else
                        With Me.RadGridServiceFeeCDP.MasterTableView.GetColumn("fee")
                            .Display = False
                        End With
                    End If

                End Using


            Else

                Me.ShowMessage("Please select a starting post period that is before the ending post period.")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_MyServiceFees
                .UserCode = Session("UserCode")
                .Name = "Service Fees (My)"
                .Description = "Service Fees (My)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
