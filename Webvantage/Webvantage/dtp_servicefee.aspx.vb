Imports System.Collections.Generic
Imports System.Text

Public Class dtp_servicefee
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PageMode

        ServiceFee = 1
        MyServiceFee = 2

    End Enum

#End Region

#Region " Variables "

    Public CurrentPageMode As PageMode = PageMode.ServiceFee

    Private StartPeriod As String = ""
    Private EndPeriod As String = ""
    Private ServiceFeeType As String = ""
    Private ClientType As String = ""
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private FeeType As Boolean = False
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing
    Private _ServiceFeeComplex As AdvantageFramework.Reporting.Database.Classes.ServiceFee

#End Region

#Region " Properties "



#End Region

    Private IsMy As Boolean = False

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me.StartPeriod = qs.Get("speriod")
        Me.EndPeriod = qs.Get("eperiod")
        Me.Client = qs.ClientCode
        Me.Division = qs.DivisionCode
        Me.Product = qs.ProductCode
        Me.ServiceFeeType = qs.Get("sfeetype")
        Me.ClientType = qs.Get("ctype")
        Me.FeeType = qs.Get("feetype")

        If Me.ClientType = "c" Then
            Me.RadGridServiceFeeClient.Visible = True
            Me.RadGridServiceFeeCDP.Visible = False
        End If
        If Me.ClientType = "cdp" Then
            Me.RadGridServiceFeeClient.Visible = False
            Me.RadGridServiceFeeCDP.Visible = True
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Request.QueryString("my") Is Nothing Then
                If CType(Request.QueryString("my"), Integer) = 1 Then
                    IsMy = True
                Else
                    IsMy = False
                End If
            End If
        Catch ex As Exception
            IsMy = False
        End Try
        If IsMy = True Then
            Me.Page.Title = "My Service Fees"
            Me.lblTitle.Text = "My Service Fees"
        Else
            Me.Page.Title = "Service Fees"
            Me.lblTitle.Text = "Service Fees"
        End If
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    Chartload()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private DtGraphData As New DataTable
    Private Sub Chartload()
        Try
            If StartPeriod <= EndPeriod Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.StartingPostPeriodCode.ToString) = StartPeriod
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.EndingPostPeriodCode.ToString) = EndPeriod
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.UsedID.ToString) = _Session.UserCode
                If IsMy = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 2
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.DesktopObject.ToString) = 1
                End If

                'If RadioButtonEmployeeDefault.Checked = True Then
                '    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "def"
                'ElseIf RadioButtonEmployeeTimeEntry.Checked = True Then
                '    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "time"
                'ElseIf RadioButtonJobComponent.Checked = True Then
                '    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = "job"
                'Else
                '    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ""
                'End If
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.ServiceFeeType.ToString) = ServiceFeeType
                _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                If ClientType = "c" Then
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeClient.ToString) = 1
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeDivision.ToString) = 0
                    _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeProduct.ToString) = 0
                ElseIf ClientType = "cdp" Then
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

                'Client = gridDataItem.GetDataKeyValue("ClientCode")
                'Division = gridDataItem.GetDataKeyValue("DivisionCode")
                'Product = gridDataItem.GetDataKeyValue("ProductCode")     
                If ClientType = "c" Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeClient.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            Client = gridDataItem.GetDataKeyValue("ClientCode")
                        End If
                    Next
                End If
                If ClientType = "cdp" Then
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridServiceFeeCDP.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            Client = gridDataItem.GetDataKeyValue("ClientCode")
                            Division = gridDataItem.GetDataKeyValue("DivisionCode")
                            Product = gridDataItem.GetDataKeyValue("ProductCode")
                        End If
                    Next
                End If

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ClientType = "c" And Client <> "" Then
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = Client).ToList.FirstOrDefault
                    ElseIf ClientType = "cdp" And Client <> "" And Division <> "" And Product <> "" Then
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.ClientCode = Client And ServiceFee.DivisionCode = Division And ServiceFee.ProductCode = Product).ToList.FirstOrDefault
                    Else
                        _ServiceFeeComplex = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.Hours <> 0 Or ServiceFee.Amount <> 0 Or ServiceFee.FeeAmount <> 0).ToList.FirstOrDefault
                    End If

                    If FeeType = True Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 1
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ServiceFeeParameters.IncludeFeeType.ToString) = 0
                    End If
                    sf = AdvantageFramework.Reporting.Database.Procedures.ServiceFeeComplexType.Load(ReportingDbContext, _ParameterDictionary).ToList.Where(Function(ServiceFee) ServiceFee.Hours <> 0 Or ServiceFee.Amount <> 0 Or ServiceFee.FeeAmount <> 0).ToList

                    Me.RadGridServiceFeeClient.DataSource = sf
                    Me.RadGridServiceFeeClient.DataBind()
                    Me.RadGridServiceFeeCDP.DataSource = sf
                    Me.RadGridServiceFeeCDP.DataBind()

                    If FeeType = True Then
                        With Me.RadGridServiceFeeClient.MasterTableView.GetColumn("fee")
                            .Display = True
                        End With
                        With Me.RadGridServiceFeeCDP.MasterTableView.GetColumn("fee")
                            .Display = True
                        End With
                    Else
                        With Me.RadGridServiceFeeClient.MasterTableView.GetColumn("fee")
                            .Display = False
                        End With
                        With Me.RadGridServiceFeeCDP.MasterTableView.GetColumn("fee")
                            .Display = False
                        End With
                    End If

                End Using

                CreateChart()

            Else

                Me.ShowMessage("Please select a starting post period that is before the ending post period.")

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function CreateChart() As String

        'objects
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChartServiceFees.PlotArea.Series.Clear()
            RadHtmlChartServiceFees.PlotArea.XAxis.Items.Clear()

            RadHtmlChartServiceFees.Legend.Appearance.Visible = False
            RadHtmlChartServiceFees.PlotArea.XAxis.MinorGridLines.Visible = False
            RadHtmlChartServiceFees.PlotArea.XAxis.MajorGridLines.Visible = False
            RadHtmlChartServiceFees.PlotArea.YAxis.MinorGridLines.Visible = False

            RadHtmlChartServiceFees.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(_ServiceFeeComplex.ClientDescription)
            RadHtmlChartServiceFees.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top
            RadHtmlChartServiceFees.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center

            ColumnSeries = New Telerik.Web.UI.ColumnSeries
            ColumnSeries.Name = "Service Fees"
            ColumnSeries.LabelsAppearance.Visible = False
            ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"

            Colors = New AdvantageFramework.Web.Presentation.Colors

            If _ServiceFeeComplex IsNot Nothing Then

                ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.FeeAmount.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                'ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.Hours.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Orange, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                ColumnSeries.SeriesItems.Add(_ServiceFeeComplex.Amount.GetValueOrDefault(0), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Blue, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

            End If

            RadHtmlChartServiceFees.PlotArea.XAxis.Items.Add("Fee Billed")
            'RadHtmlChartServiceFees.PlotArea.XAxis.Items.Add("Actual Hours")
            RadHtmlChartServiceFees.PlotArea.XAxis.Items.Add("Actual Amount")

            RadHtmlChartServiceFees.PlotArea.Series.Add(ColumnSeries)

            RadHtmlChartServiceFees.PlotArea.XAxis.LabelsAppearance.Visible = True

        Catch ex As Exception

        End Try

    End Function



    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function

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

    Private Sub RadGridServiceFeeClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridServiceFeeClient.SelectedIndexChanged
        Try

            Chartload()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridServiceFeeCDP_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridServiceFeeCDP.PageIndexChanged
        Try
            Chartload()
        Catch ex As Exception

        End Try
    End Sub
End Class
