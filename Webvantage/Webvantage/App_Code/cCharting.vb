Imports System
Imports System.Text
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Xml
Imports Microsoft.VisualBasic
Imports System.Collections.Generic

<Serializable()> Public Class cCharting

    Public Shared count As Integer = -1
    Public Shared phaseNames(20) As String
    Public Shared strColor(20) As String

#Region " --- New Charts --- "

    Public Shared Sub GetColumnChart_JobStatistics(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, ByVal TrafficCode As String, ByVal IsCancelledCode As Boolean, Optional ByVal Caption As String = "")

        'objects
        Dim DataTable As System.Data.DataTable = Nothing
        Dim CreatedColumnSeres As Telerik.Web.UI.ColumnSeries = Nothing
        Dim CompletedColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim DueColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim InProgressColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim AdditionalColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
            RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
            RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

            RadHtmlChart.Legend.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartLegendAlign.Center
            RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom

            If Not String.IsNullOrWhiteSpace(Caption) Then

                RadHtmlChart.ChartTitle.Text = HttpContext.Current.Server.HtmlEncode(Caption)
                RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top
                RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center

            Else

                RadHtmlChart.ChartTitle.Appearance.Visible = False

            End If

            If DataSet IsNot Nothing Then

                DataTable = DataSet.Tables(0)

            End If

            If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                CreatedColumnSeres = New Telerik.Web.UI.ColumnSeries With {.Name = "Created"}
                CompletedColumnSeries = New Telerik.Web.UI.ColumnSeries With {.Name = "Completed"}
                DueColumnSeries = New Telerik.Web.UI.ColumnSeries With {.Name = "Due"}
                InProgressColumnSeries = New Telerik.Web.UI.ColumnSeries With {.Name = "In Progress"}

                RadHtmlChart.PlotArea.Series.Add(CreatedColumnSeres)
                RadHtmlChart.PlotArea.Series.Add(CompletedColumnSeries)
                RadHtmlChart.PlotArea.Series.Add(DueColumnSeries)
                RadHtmlChart.PlotArea.Series.Add(InProgressColumnSeries)

                If TrafficCode <> "none" Then

                    AdditionalColumnSeries = New Telerik.Web.UI.ColumnSeries

                    If IsCancelledCode = True Then

                        AdditionalColumnSeries.Name = "Cancelled"

                    Else

                        AdditionalColumnSeries.Name = TrafficCode

                    End If

                    RadHtmlChart.PlotArea.Series.Add(AdditionalColumnSeries)

                End If

                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                    RadHtmlChart.PlotArea.XAxis.Items.Add(HttpContext.Current.Server.HtmlEncode(DataRow(1)))

                    CreatedColumnSeres.SeriesItems.Add(CDec(DataRow(2)), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Blue, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    CompletedColumnSeries.SeriesItems.Add(CDec(DataRow(3)), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Green, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    DueColumnSeries.SeriesItems.Add(CDec(DataRow(5)), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Yellow, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                    InProgressColumnSeries.SeriesItems.Add(CDec(DataRow(6)), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Red, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                    If AdditionalColumnSeries IsNot Nothing Then

                        AdditionalColumnSeries.SeriesItems.Add(CDec(DataRow(4)), Colors.LoadColor(AdvantageFramework.Web.Presentation.Colors.Color.Gray, AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))

                    End If

                Next

                For Each ColumnSeries In RadHtmlChart.PlotArea.Series.OfType(Of Telerik.Web.UI.ColumnSeries)()

                    ColumnSeries.TooltipsAppearance.ClientTemplate = "#=series.name#, #=category#, #=value#"

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub GetPieChart_CurrentRatio(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal AssetAmount As Decimal, ByVal LiabAmount As Decimal, Optional ByVal Caption As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()

            RadHtmlChart.Legend.Appearance.Visible = False
            RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Bottom
            RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center

            If Not String.IsNullOrEmpty(Caption) Then

                RadHtmlChart.ChartTitle.Appearance.Visible = True
                RadHtmlChart.ChartTitle.Text = Caption

            Else

                RadHtmlChart.ChartTitle.Appearance.Visible = False
                RadHtmlChart.ChartTitle.Text = ""

            End If

            PieSeries = New Telerik.Web.UI.PieSeries

            PieSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= kendo.format(\'{0:N2}\', value) #"
            PieSeries.LabelsAppearance.Visible = False

            RadHtmlChart.PlotArea.Series.Add(PieSeries)

            PieSeries.SeriesItems.Add(New Telerik.Web.UI.PieSeriesItem With {.Y = AssetAmount, .Name = "Assets", .Exploded = False, .BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(1))})
            PieSeries.SeriesItems.Add(New Telerik.Web.UI.PieSeriesItem With {.Y = LiabAmount, .Name = "Liabilities", .Exploded = True, .BackgroundColor = Drawing.ColorTranslator.FromHtml(StandardColors(4))})

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub GetBarChart_TimeGraph(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "")

        'objects
        Dim BarSeries As Telerik.Web.UI.BarSeries = Nothing
        Dim Hours As Decimal? = Nothing
        Dim ColorList As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            ColorList = {AdvantageFramework.Web.Presentation.Colors.Color.Blue,
                         AdvantageFramework.Web.Presentation.Colors.Color.Teal,
                         AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                         AdvantageFramework.Web.Presentation.Colors.Color.Cyan,
                         AdvantageFramework.Web.Presentation.Colors.Color.Green,
                         AdvantageFramework.Web.Presentation.Colors.Color.Red}

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            If Not [String].IsNullOrWhiteSpace(Caption) Then

                RadHtmlChart.ChartTitle.Text = Caption
                RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
                RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Bottom
                RadHtmlChart.ChartTitle.Appearance.Visible = True

            Else

                RadHtmlChart.ChartTitle.Appearance.Visible = False

            End If

            RadHtmlChart.PlotArea.XAxis.Name = "Day"
            RadHtmlChart.PlotArea.XAxis.TitleAppearance.Position = Telerik.Web.UI.HtmlChart.AxisTitlePosition.Center
            RadHtmlChart.PlotArea.XAxis.TitleAppearance.Text = "Day"
            RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False

            RadHtmlChart.PlotArea.YAxis.Name = "Hours"
            RadHtmlChart.PlotArea.YAxis.TitleAppearance.Position = Telerik.Web.UI.HtmlChart.AxisTitlePosition.Center
            RadHtmlChart.PlotArea.YAxis.TitleAppearance.Text = "Hours"
            RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False

            If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                BarSeries = New Telerik.Web.UI.BarSeries
                BarSeries.Name = "EmployeeHours"
                RadHtmlChart.PlotArea.Series.Add(BarSeries)

                Colors = New AdvantageFramework.Web.Presentation.Colors

                For i As Integer = 0 To DataTable.Rows.Count - 1

                    Try

                        Hours = CType(DataTable.Rows(i)("Hours"), Decimal)

                    Catch ex As Exception

                        Hours = 0

                    End Try

                    If Hours <> 0 Then

                        BarSeries.SeriesItems.Add(Hours, Colors.LoadColor(ColorList(i Mod 10), AdvantageFramework.Web.Presentation.Colors.ColorFamily.Base))
                        BarSeries.TooltipsAppearance.ClientTemplate = "#= category #, #= value #"

                        RadHtmlChart.PlotArea.XAxis.Items.Add(CType(DataTable.Rows(i)("DayDisplay"), Date).DayOfWeek.ToString().Substring(0, 3))

                    End If

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub GetChart_ClientAging(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataTable As DataTable, Optional ByVal Caption As String = "", Optional ByVal IsPieChart As Boolean = False,
                                           Optional ByVal ClientCode As String = "", Optional ByVal OfficeCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "",
                                           Optional ByVal ShowMyClientAging As Boolean = False, Optional ByVal Category As String = "")

        'objects
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim ColumnSeries As Telerik.Web.UI.ColumnSeries = Nothing
        Dim CategorySeriesItem As Telerik.Web.UI.CategorySeriesItem = Nothing
        Dim SeriesClickUrl As String = ""
        Dim FromDO As String = Nothing
        Dim ColorList As AdvantageFramework.Web.Presentation.Colors.Color() = Nothing
        Dim DatasourceDataTable As System.Data.DataTable = Nothing
        Dim DataRow As System.Data.DataRow = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            If Not [String].IsNullOrWhiteSpace(Caption) Then

                RadHtmlChart.ChartTitle.Text = Caption
                RadHtmlChart.ChartTitle.Appearance.Visible = True
                RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top
                RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center

            Else

                RadHtmlChart.ChartTitle.Appearance.Visible = False

            End If

            If ShowMyClientAging = True Then

                FromDO = "mca"

            End If

            RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
            RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
            RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False
            RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N0}"

            RadHtmlChart.Legend.Appearance.Visible = False

            'Colors = New AdvantageFramework.Web.Presentation.Colors

            ColorList = {AdvantageFramework.Web.Presentation.Colors.Color.Blue,
                         AdvantageFramework.Web.Presentation.Colors.Color.Orange,
                         AdvantageFramework.Web.Presentation.Colors.Color.Green,
                         AdvantageFramework.Web.Presentation.Colors.Color.Red,
                         AdvantageFramework.Web.Presentation.Colors.Color.Yellow,
                         AdvantageFramework.Web.Presentation.Colors.Color.Gray}

            DatasourceDataTable = New DataTable

            DatasourceDataTable.Columns.Add("SeriesClickUrl", GetType(String))
            DatasourceDataTable.Columns.Add("Value", GetType(Decimal))
            DatasourceDataTable.Columns.Add("Color", GetType(String))

            If IsPieChart Then

                'not coded... see getFCXMLData_BarPie_ClientAging for original code

            Else

                ColumnSeries = New Telerik.Web.UI.ColumnSeries

                ColumnSeries.DataFieldY = "Value"
                ColumnSeries.ColorField = "Color"
                ColumnSeries.LabelsAppearance.DataFormatString = "{0:N0}"
                ColumnSeries.TooltipsAppearance.ClientTemplate = "#= category #: #= kendo.format(\'{0:N0}\', value) #"

                RadHtmlChart.PlotArea.Series.Add(ColumnSeries)

                RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45

                For I = 0 To 5

                    If DataTable.Rows(0).Item(I) <> 0 Then

                        DataRow = DatasourceDataTable.NewRow

                        DataRow("Value") = DataTable.Rows(0).Item(I)
                        DataRow("SeriesClickUrl") = "ClientAging_Invoices.aspx?Group=" & I.ToString & "&client=" & ClientCode & "&office=" & OfficeCode & "&division=" & DivisionCode & "&product=" & ProductCode & "&from=" & FromDO & "&cat=" & Category
                        DataRow("Color") = Colors.LoadNextHexColorString()

                        DatasourceDataTable.Rows.Add(DataRow)

                        RadHtmlChart.PlotArea.XAxis.Items.Add(DataTable.Columns(I).ColumnName)

                    End If

                Next

            End If

            RadHtmlChart.DataSource = DatasourceDataTable
            RadHtmlChart.DataBind()

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub GetLineChart_BillingTrends(ByVal RadHtmlChart As Telerik.Web.UI.RadHtmlChart, ByVal DataSet As System.Data.DataSet, Optional ByVal Caption As String = "")

        'objects
        Dim LineSeries As Telerik.Web.UI.LineSeries = Nothing

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChart.PlotArea.Series.Clear()
            RadHtmlChart.PlotArea.XAxis.Items.Clear()

            If DataSet.Tables(0).Rows.Count > 0 Then

                If Not [String].IsNullOrWhiteSpace(Caption) Then

                    RadHtmlChart.ChartTitle.Appearance.Visible = True
                    RadHtmlChart.ChartTitle.Text = Caption
                    RadHtmlChart.ChartTitle.Appearance.Align = Telerik.Web.UI.HtmlChart.ChartTitleAlign.Center
                    RadHtmlChart.ChartTitle.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartTitlePosition.Top

                Else

                    RadHtmlChart.ChartTitle.Appearance.Visible = False

                End If

                RadHtmlChart.PlotArea.XAxis.Name = "Month"
                RadHtmlChart.PlotArea.XAxis.MinorGridLines.Visible = False
                RadHtmlChart.PlotArea.XAxis.MajorGridLines.Visible = False
                RadHtmlChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = -45

                RadHtmlChart.PlotArea.YAxis.Name = "Amount"
                RadHtmlChart.PlotArea.YAxis.MinorGridLines.Visible = False
                RadHtmlChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:N0}"

                RadHtmlChart.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom
                RadHtmlChart.Legend.Appearance.Visible = True

                For CurMonth = 1 To 12

                    RadHtmlChart.PlotArea.XAxis.Items.Add(String.Format("{0:MMM}", Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurMonth)))

                Next

                If DataSet.Tables(0).Rows.Count > 0 Then

                    For Each DataRow In DataSet.Tables(0).Rows.OfType(Of System.Data.DataRow)()

                        LineSeries = New Telerik.Web.UI.LineSeries

                        LineSeries.Name = DataRow(0)
                        LineSeries.TooltipsAppearance.ClientTemplate = "#= series.name #, #= category #, #= kendo.format(\'{0:N0}\', value) #"
                        LineSeries.LabelsAppearance.Visible = False

                        For Counter = 1 To 12

                            LineSeries.SeriesItems.Add(DataRow(Counter), Drawing.ColorTranslator.FromHtml(StandardColors(1)))

                        Next

                        RadHtmlChart.PlotArea.Series.Add(LineSeries)

                    Next

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region " Write Data XML"

    Public Enum ChartType
        Bar2D
        Column3D
        Line
        MSLine
        Angular
        Cylinder
        Gantt
        LinearGuage
        Area
        Column3DLineDY
    End Enum

    Public Shared Function AddChart(ByVal Chart As ChartType, ByVal Data As String, ByVal Height As Integer, ByVal Width As Integer) As String

        Dim FlashFile As String = ""
        Dim s As String = ""

        Select Case Chart
            Case ChartType.Bar2D
                FlashFile = "FC_2_3_Bar2D"
            Case ChartType.Column3D
                FlashFile = "FC_2_3_Column3D"
            Case ChartType.Line
                FlashFile = "FC_2_3_Line"
            Case ChartType.MSLine
                FlashFile = "FC_2_3_MSLine"
            Case ChartType.Angular
                FlashFile = "FI2_Angular"
            Case ChartType.Cylinder
                FlashFile = "FI2_Cylinder"
            Case ChartType.Gantt
                FlashFile = "FI2_Gantt"
            Case ChartType.LinearGuage
                FlashFile = "HLinearGauge"
            Case ChartType.Area
                FlashFile = "MSArea"
            Case ChartType.Column3DLineDY
                FlashFile = "MSColumn3DLineDY"
        End Select

        If FlashFile <> "" Then

            Try

                Dim UrlScheme As String = HttpContext.Current.Request.Url.Scheme
                Dim sb As New System.Text.StringBuilder

                sb.Append("<object classid=""clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"" codebase=""" & HttpContext.Current.Request.Url.Scheme &
                          "://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"" enableviewstate=""false"" height=""" &
                          Height & """ width=""" & Width & """>")
                sb.Append("<param name=""movie"" value=""Flash/" & FlashFile & ".swf?chartWidth=" & Width & "&chartHeight=" & Height & """ />")
                sb.Append("<param name=""quality"" value=""high"" />")
                sb.Append("<param name=""wmode"" value=""transparent"" />")
                sb.Append("<param name=""FlashVars"" value=""&dataXML=" & Data & """ />")
                sb.Append("<embed flashvars=""&dataXML=" & Data & """")
                sb.Append(" height=""" & Height & """ pluginspage=""" & HttpContext.Current.Request.Url.Scheme & """://get.adobe.com/flashplayer/"" quality=""high""")
                sb.Append(" src=""Flash/" & FlashFile & ".swf"" type=""application/x-shockwave-flash"" width=""" & Width & """")
                sb.Append(" wmode=""transparent""> ")
                sb.Append("</embed>")
                sb.Append("</object>")

                s = sb.ToString()

            Catch ex As Exception

                s = ex.Message.ToString()

            End Try
        Else

            s = "No chart selected"

        End If

        Return s

    End Function

    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")
    'sb.Append("")

    Public Shared Function getFCXMLData_MultiLine_TimeGraph(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "") As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            If dsForGraph.Tables(0).Rows.Count > 0 Then
                With sbFCXMLData
                    'Initialize the XML String
                    .Append("<graph caption='" & strCaption & "' xAxisName='Day' yAxisName='Hours' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' animation='1' numdivlines='3' numVdivlines='0' lineThickness='2' rotateNames='1' showLegend='1' formatNumber='1' numberPrefix='' numberSuffix=' hrs.'>" & Environment.NewLine())
                    .Append("    <categories>" & Environment.NewLine())
                    .Append("      <category name='Sun' />" & Environment.NewLine())
                    .Append("      <category name='Mon' />" & Environment.NewLine())
                    .Append("      <category name='Tue' />" & Environment.NewLine())
                    .Append("      <category name='Wed' />" & Environment.NewLine())
                    .Append("      <category name='Thu' />" & Environment.NewLine())
                    .Append("      <category name='Fri' />" & Environment.NewLine())
                    .Append("      <category name='Sat' />" & Environment.NewLine())
                    .Append("   </categories>" & Environment.NewLine())

                    'Now iterate through each data row
                    Dim i As Integer = 0
                    For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                        Dim j As Integer = 0
                        .Append("<dataset seriesname='This Week' color='" & strColor(i Mod 10) & "' showValue='0' alpha='100' showAnchors='1'>")
                        If dsForGraph.Tables(0).Rows(i)("Sun") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Sun") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Mon") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Mon") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Tue") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Tue") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Wed") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Wed") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Thu") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Thu") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Fri") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Fri") & "' />" & Environment.NewLine())
                        End If
                        If dsForGraph.Tables(0).Rows(i)("Sat") <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)("Sat") & "' />" & Environment.NewLine())
                        End If
                        .Append("   </dataset>" & Environment.NewLine())
                    Next
                    'End the XML data by adding the closing </graph> element
                    sbFCXMLData.Append("</graph>")
                End With

                strFCXMLData = cleanString(sbFCXMLData.ToString())

                Return strFCXMLData
            Else
                Return ""
            End If

        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try

    End Function
    Public Shared Function getFCXMLData_Bar2D_TimeGraph(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "") As String

        '
        ' use new chart = GetBarChart_TimeGraph
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            If DtForGraph.Rows.Count > 0 Then
                With sbFCXMLData
                    'Initialize the XML String
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='2' numberSuffix='' xAxisName='Day' yAxisName='Hours' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & Environment.NewLine())
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='2' numberSuffix='' xAxisName='Day' yAxisName='Hours' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & Environment.NewLine())
                    Else
                        .Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='2' numberSuffix='' xAxisName='Day' yAxisName='Hours'>" & Environment.NewLine())
                    End If
                    'Now iterate through each data row
                    Dim i As Integer = 0
                    Dim j As Integer = 0
                    For i = 0 To 6
                        Select Case i
                            Case 0
                                If DtForGraph.Rows(0)("Sun") <> 0 Then
                                    .Append("<set name='Sun' value='" & DtForGraph.Rows(0)("Sun") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 1
                                If DtForGraph.Rows(0)("Mon") <> 0 Then
                                    .Append("<set name='Mon' value='" & DtForGraph.Rows(0)("Mon") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 2
                                If DtForGraph.Rows(0)("Tue") <> 0 Then
                                    .Append("<set name='Tue' value='" & DtForGraph.Rows(0)("Tue") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 3
                                If DtForGraph.Rows(0)("Wed") <> 0 Then
                                    .Append("<set name='Wed' value='" & DtForGraph.Rows(0)("Wed") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 4
                                If DtForGraph.Rows(0)("Thu") <> 0 Then
                                    .Append("<set name='Thu' value='" & DtForGraph.Rows(0)("Thu") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 5
                                If DtForGraph.Rows(0)("Fri") <> 0 Then
                                    .Append("<set name='Fri' value='" & DtForGraph.Rows(0)("Fri") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 6
                                If DtForGraph.Rows(0)("Sat") <> 0 Then
                                    .Append("<set name='Sat' value='" & DtForGraph.Rows(0)("Sat") & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                        End Select
                    Next
                    'End the XML data by adding the closing </graph> element
                    .Append("</graph>")
                End With

                strFCXMLData = cleanString(sbFCXMLData.ToString())

                Return strFCXMLData
            Else
                Return ""
            End If

        Catch ex As Exception
            Return "getFCXMLData_Bar2D Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_MultiLine_BillingTrends(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "") As String

        '
        ' use new chart = GetLineChart_BillingTrends()
        '

        Try
            Dim c As Globalization.CultureInfo = LoGlo.GetCultureInfo
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            If dsForGraph.Tables(0).Rows.Count > 0 Then
                With sbFCXMLData
                    'Initialize the XML String
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' xAxisName='Month' yAxisName='Amount' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' animation='1' numdivlines='3' numVdivlines='0' lineThickness='2' rotateNames='1' showLegend='1' formatNumber='1' numberPrefix=' ' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & Environment.NewLine())
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' xAxisName='Month' yAxisName='Amount' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' animation='1' numdivlines='3' numVdivlines='0' lineThickness='2' rotateNames='1' showLegend='1' formatNumber='1' numberPrefix=' ' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & Environment.NewLine())
                    Else
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' xAxisName='Month' yAxisName='Amount' hovercapbg='FFECAA' hovercapborder='F47E00' formatNumberScale='0' decimalPrecision='0' showvalues='0' animation='1' numdivlines='3' numVdivlines='0' lineThickness='2' rotateNames='1' showLegend='1' formatNumber='1' numberPrefix=' '>" & Environment.NewLine())
                    End If
                    .Append("    <categories>" & Environment.NewLine())
                    For w As Integer = 1 To 12
                        .Append("      <category name='" & String.Format(c, "{0:MMM}", New DateTime(Now.Date.Year, w, 1)) & "' />" & Environment.NewLine())
                    Next
                    .Append("   </categories>" & Environment.NewLine())
                    '.Append("      <category name='Jan' />" & Environment.NewLine())
                    '.Append("      <category name='Feb' />" & Environment.NewLine())
                    '.Append("      <category name='Mar' />" & Environment.NewLine())
                    '.Append("      <category name='Apr' />" & Environment.NewLine())
                    '.Append("      <category name='May' />" & Environment.NewLine())
                    '.Append("      <category name='Jun' />" & Environment.NewLine())
                    '.Append("      <category name='Jul' />" & Environment.NewLine())
                    '.Append("      <category name='Aug' />" & Environment.NewLine())
                    '.Append("      <category name='Sep' />" & Environment.NewLine())
                    '.Append("      <category name='Oct' />" & Environment.NewLine())
                    '.Append("      <category name='Nov' />" & Environment.NewLine())
                    '.Append("      <category name='Dec' />" & Environment.NewLine())

                    'Now iterate through each data row
                    Dim i As Integer = 0
                    If dsForGraph.Tables(0).Rows.Count = 1 Then
                        For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                            Dim j As Integer = 0
                            .Append("<dataset seriesname='" & dsForGraph.Tables(0).Rows(i)(0) & "' color='" & strColor(i Mod 10) & "' showValue='0' alpha='100' showAnchors='1'>")
                            'If dsForGraph.Tables(0).Rows(i)(1) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(1) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(2) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(2) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(3) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(3) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(4) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(4) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(5) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(5) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(6) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(6) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(7) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(7) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(8) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(8) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(9) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(9) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(10) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(10) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(11) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(11) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(12) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(12) & "' />" & Environment.NewLine())
                            'End If
                            .Append("   </dataset>" & Environment.NewLine())
                        Next
                    Else
                        For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                            Dim j As Integer = 0
                            .Append("<dataset seriesname='" & dsForGraph.Tables(0).Rows(i)(0) & "' color='" & strColor(i Mod 10) & "' showValue='0' alpha='100' showAnchors='1'>")
                            'If dsForGraph.Tables(0).Rows(i)(1) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(1) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(2) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(2) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(3) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(3) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(4) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(4) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(5) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(5) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(6) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(6) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(7) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(7) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(8) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(8) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(9) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(9) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(10) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(10) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(11) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(11) & "' />" & Environment.NewLine())
                            'End If
                            'If dsForGraph.Tables(0).Rows(i)(12) <> 0 Then
                            .Append("      <set value='" & dsForGraph.Tables(0).Rows(i)(12) & "' />" & Environment.NewLine())
                            'End If
                            .Append("   </dataset>" & Environment.NewLine())
                        Next
                    End If
                    'End the XML data by adding the closing </graph> element
                    sbFCXMLData.Append("</graph>")
                End With

                strFCXMLData = cleanString(sbFCXMLData.ToString())

                Return strFCXMLData
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_MultiColumn3D_JobStatistics(ByVal dsForGraph As DataSet, ByVal TrafficCode As String, ByVal IsCancelledCode As Boolean, Optional ByVal strCaption As String = "") As String

        '
        ' use new chart = GetColumnChart_JobStatistics()
        '

        Dim strFCXMLData As String
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim dt As New DataTable
        Dim i As Integer = 0
        Try
            If Not dsForGraph Is Nothing Then
                dt = dsForGraph.Tables(0)
            End If
            If dt.Rows.Count > 0 Then
                With sbFCXMLData
                    'Open chart:
                    .Append("<chart caption='" & strCaption & "' XAxisName='' palette='2' animation='1' formatNumberScale='0' numberPrefix='' showValues='1' numDivLines='4' legendPosition='BOTTOM'>")

                    'Add Clients:
                    .Append("<categories>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<category label='" & dt.Rows(i)(1).ToString.Replace("'", "") & "' />")
                    Next
                    .Append("</categories>")

                    'Add columns:
                    ''Created:
                    .Append("<dataset seriesName='Created'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(2) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Completed:
                    .Append("<dataset seriesName='Completed'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(3) & "' />")
                    Next
                    .Append("</dataset>")
                    ''Due:
                    .Append("<dataset seriesName='Due'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(5) & "' />")
                    Next
                    .Append("</dataset>")
                    ''In Progress:
                    .Append("<dataset seriesName='In Progress'>")
                    i = 0
                    For i = 0 To dt.Rows.Count - 1
                        .Append("<set value='" & dt.Rows(i)(6) & "' />")
                    Next
                    .Append("</dataset>")

                    ''Cancelled/Custom
                    If TrafficCode <> "none" Then
                        If IsCancelledCode = True Then
                            .Append("<dataset seriesName='Cancelled'>")
                        Else
                            .Append("<dataset seriesName='" & TrafficCode & "'>")
                        End If
                        i = 0
                        For i = 0 To dt.Rows.Count - 1
                            .Append("<set value='" & dt.Rows(i)(4) & "' />")
                        Next
                        .Append("</dataset>")
                    End If

                    'Close chart:
                    .Append("<styles>")
                    .Append("<definition>")
                    .Append("<style type='font' name='CaptionFont' color='666666' size='10' />")
                    .Append("<style type='font' name='SubCaptionFont' bold='0' />")
                    .Append("</definition>")
                    .Append("<application>")
                    .Append("<apply toObject='caption' styles='CaptionFont' /> ")
                    .Append("<apply toObject='SubCaption' styles='SubCaptionFont' />")
                    .Append("</application>")
                    .Append("</styles>")
                    .Append("</chart>")
                End With
            Else
                With sbFCXMLData
                    .Append("<chart></chart>")
                End With
            End If
            Return cleanString(sbFCXMLData.ToString())
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function getFCXMLData_JobGantt_TrafficTimeLine(ByVal drForGraph As SqlClient.SqlDataReader, ByVal startDate() As Date, ByVal endDate() As Date, ByVal startD As Date, ByVal endD As Date) As String
        Try
            Dim strFCXMLData As String = ""
            Dim strProcess As String = ""
            Dim strTasks As String = ""
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim strJobDesc As String
            Dim x, JobNbr, CompNbr As Integer
            Dim processID As Integer
            Dim JobProcessID As Integer = 100
            Dim JobHdr As String
            Dim JobNbrStr, CompNbrStr As String
            Dim strCaption As String
            Dim sTrfDesc As String = ""
            Dim sTrfDescTmp As String = ""
            Dim endDatefromDB As Date
            Dim startDatefromDB As Date
            Dim cmp_name As String

            If drForGraph.HasRows = True Then
                strProcess = "<processes positionInGrid='right' align='left' headerText='' fontColor='000000' fontSize='10' isBold='1' isAnimated='1' bgColor='CEE5F6' headerbgColor='CEE5F6' headerFontColor='FFFFF' headerFontSize='12' bgAlpha='0' >" & Environment.NewLine()
                strTasks = "<tasks>" & Environment.NewLine()

                Do While drForGraph.Read()

                    'String out ' from name, causes problems
                    cmp_name = drForGraph.GetString(1)
                    cmp_name = cmp_name.Replace("'", "")

                    strCaption = drForGraph.GetString(0) & " - " & cmp_name

                    If sTrfDescTmp <> drForGraph.GetString(2) Then
                        sTrfDesc = drForGraph.GetString(2)
                        processID += 1
                        strProcess = strProcess & " <process Name='" & sTrfDesc & "' id='" & processID & "' isBold='1' fontSize='12'/> "
                        sTrfDescTmp = sTrfDesc
                    End If

                    If strJobDesc <> drForGraph.GetString(5) Then
                        JobProcessID += 1
                        JobNbr = drForGraph.GetInt32(3)
                        CompNbr = drForGraph.GetInt16(4)
                        JobNbrStr = String.Format("{0:00000#}", JobNbr)
                        CompNbrStr = String.Format("{0:0#}", CompNbr)
                        JobHdr = "     " & JobNbrStr & " - " & CompNbrStr & "   " & drForGraph.GetString(5)

                        strProcess = strProcess & "<process Name='" & JobHdr & "' id='" & JobProcessID & "'/>" & Environment.NewLine()
                    End If

                    ' If end date > than chart end date, reset so doesn't go off chart
                    endDatefromDB = drForGraph.GetDateTime(9)
                    If endD < endDatefromDB Then
                        endDatefromDB = endD
                    End If

                    startDatefromDB = drForGraph.GetDateTime(8)
                    If startD > startDatefromDB Then
                        startDatefromDB = startD
                    End If

                    'strTasks = strTasks & "<task name='" & drForGraph.GetString(7) & "' hoverText='" & drForGraph.GetString(7) & "' processId='" & JobProcessID & "' start='" & drForGraph.GetDateTime(8).ToShortDateString & "' end='" & drForGraph.GetDateTime(9).ToShortDateString & "' id='Srvy' color='" & ganttColors(drForGraph.GetString(7)) & "' alpha='60' height='25' showBorder='1' />" & Environment.newline()
                    strTasks = strTasks & "<task name='" & drForGraph.GetString(7) & "' hoverText='" & drForGraph.GetString(7) & "' processId='" & JobProcessID & "' start='" & startDatefromDB.ToShortDateString & "' end='" & endDatefromDB.ToShortDateString & "' id='Srvy' color='" & ganttColors(drForGraph.GetString(7)) & "' alpha='60' height='25' showBorder='1' />" & Environment.NewLine()
                    strJobDesc = drForGraph.GetString(5)
                Loop

                strTasks = strTasks & "</tasks>" & Environment.NewLine()
                strProcess = strProcess & "</processes>" & Environment.NewLine()
                drForGraph.Close()
            End If

            If startDate.Length > 0 Then

                With sbFCXMLData

                    'Initialize the XML String
                    .Append(" <chart dateFormat='mm/dd/yyyy' showTaskNames='0' ganttWidthPercent='70' gridBorderAlpha='100' canvasBorderColor='6788BE' canvasBorderThickness='0' hoverCapBgColor='FFFFFF' hoverCapBorderColor='333333' extendcategoryBg='0' ganttLineColor='CEE5F6' ganttLineAlpha='100' ganttLineThickness='10' baseFontColor='333333' gridBorderColor='CEE5F6'>" & Environment.NewLine())
                    .Append(" <categories bgColor='CEE5F6' fontColor='000000' isBold='1' verticalPadding='25' fontSize='14'>" & Environment.NewLine())

                    .Append("      <category start='" & startD.ToShortDateString & "' end='" & endD.ToShortDateString & "' name='" & strCaption & "' />" & Environment.NewLine())

                    'If startD.Year <> endD.Year Then
                    '    .Append("      <category start='" & startD.ToShortDateString & "' end='12/31" & startD.Year.ToString()& "' name='" & strCaption & " ( " & startD.Year.ToString()& "' />" & Environment.newline())
                    '    .Append("      <category start='1/1" & endD.Year.ToString()& "' end='" & endD.ToShortDateString & "' name='" & strCaption & " ( " & endD.Year.ToString()& "' />" & Environment.newline())
                    'Else
                    '    .Append("      <category start='" & startD.ToShortDateString & "' end='" & endD.ToShortDateString & "' name='" & strCaption & " ( " & startD.Year.ToString()& " )" & "' />" & Environment.newline())
                    'End If

                    .Append("   </categories>" & Environment.NewLine())
                    .Append("    <categories bgColor='CEE5F6' bgAlpha='0' fontColor='000000' align='center' fontSize='10' isBold='1'>" & Environment.NewLine())

                    'Now iterate through each data row
                    For x = 0 To startDate.Length - 2
                        If startDate(x).ToShortDateString <> "1/1/0001" Then
                            .Append("      <category start='" & startDate(x).ToShortDateString & "' end='" & endDate(x).ToShortDateString & "' name='" & getMonthName(startDate(x).Date.Month) & "' />" & Environment.NewLine())
                        End If
                    Next

                    .Append("   </categories>" & Environment.NewLine())

                    'End the XML data by adding the closing </chart> element
                    sbFCXMLData.Append(strProcess & strTasks)
                    sbFCXMLData.Append("</chart>")
                End With

                strFCXMLData = cleanString(sbFCXMLData.ToString())
                Return strFCXMLData
            Else
                Return ""
            End If

        Catch ex As Exception
            Return "getFCXMLData_JobGantt Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_MultiColumn_ARForecast(ByVal dsForGraph As DataSet, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            If dsForGraph.Tables(0).Rows.Count > 0 Then
                With sbFCXMLData
                    'Initialize the XML String
                    If isPie = False Then
                        .Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & Environment.NewLine())
                    Else
                        .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & Environment.NewLine())
                    End If

                    'Now iterate through each data row
                    Dim i As Integer = 0
                    Dim j As Integer = 0
                    For i = 0 To 4

                        Select Case i
                            Case 0
                                If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                                    .Append("<set name='0 to 30' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 1
                                If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                                    .Append("<set name='31 to 60' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 2
                                If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                                    .Append("<set name='61 to 90' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 3
                                If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                                    .Append("<set name='91 to 120' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                            Case 4
                                If dsForGraph.Tables(0).Rows(0).Item(i) <> 0 Then
                                    .Append("<set name='121+' value='" & dsForGraph.Tables(0).Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                                End If
                        End Select
                    Next
                    'End the XML data by adding the closing </graph> element
                    .Append("</graph>")
                End With

                strFCXMLData = cleanString(sbFCXMLData.ToString())

                Return strFCXMLData
            Else
                Return ""
            End If

        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_BarPie_ClientAging(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False,
                                                           Optional ByVal client As String = "", Optional ByVal office As String = "", Optional ByVal division As String = "", Optional ByVal product As String = "",
                                                           Optional ByVal ShowMyClientAging As Boolean = False, Optional ByVal cat As String = "") As String

        '
        ' use new chart = GetChart_ClientAging()
        '

        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            'If DtForGraph.Rows.Count > 0 Then
            With sbFCXMLData
                'Initialize the XML String
                If isPie = False Then
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<chart  labelDisplay='Rotate' slantLabels='1' bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='' numberSuffix='' toolTipSepChar=';' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & Environment.NewLine())
                    ElseIf LoGlo.UserCultureGet <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<chart  labelDisplay='Rotate' slantLabels='1' bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='' numberSuffix='' toolTipSepChar=';' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & Environment.NewLine())
                    Else
                        .Append("<chart  labelDisplay='Rotate' slantLabels='1' bgcolor='FFFFFF' caption='" & strCaption & "' formatNumberScale='0' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='' numberSuffix='' toolTipSepChar=';'>" & Environment.NewLine())
                    End If
                Else
                    If LoGlo.UserCultureGet() = "fr-FR" Then
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & Environment.NewLine())
                    ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & Environment.NewLine())
                    Else
                        .Append("<graph  labelDisplay='Rotate' slantLabels='1' caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & Environment.NewLine())
                    End If
                End If

                Dim fromDO As String = ""
                If ShowMyClientAging = True Then fromDO = "mca"

                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To 5
                    Select Case i
                        Case 0
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(0).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D0%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                        Case 1
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(1).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D1%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                        Case 2
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(2).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D2%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                        Case 3
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(3).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D3%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                        Case 4
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(4).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D4%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                        Case 5
                            If DtForGraph.Rows(0).Item(i) <> 0 Then
                                .Append("<set name='" & DtForGraph.Columns(5).ColumnName & "' value='" & DtForGraph.Rows(0).Item(i) & "' color='" & strColor(i Mod 10) & "'  link=%22JavaScript:OpenRadWindow('','ClientAging_Invoices.aspx%3FGroup%3D5%26client%3D" & client & "%26office%3D" & office & "%26division%3D" & division & "%26product%3D" & product & "%26from%3D" & fromDO & "%26cat%3D" & cat & "', '800','1200');%22/>" & Environment.NewLine())
                            End If
                    End Select
                Next

                If isPie = False Then
                    .Append("</chart>")
                Else
                    .Append("</graph>")
                End If
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData
        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Overloads Shared Function getFCXMLData_BarPie(ByVal dsForGraph As DataSet, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            With sbFCXMLData
                'Initialize the XML String
                If isPie = False Then
                    sbFCXMLData.Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='0' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & Environment.NewLine())
                Else
                    sbFCXMLData.Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & Environment.NewLine())
                End If

                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To dsForGraph.Tables(0).Rows.Count - 1
                    If dsForGraph.Tables(0).Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set name='" & dsForGraph.Tables(0).Rows(i).Item(strNameField).ToString() & "' value='" & dsForGraph.Tables(0).Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</graph>")
            End With

            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Overloads Shared Function getFCXMLData_BarPie(ByVal strConn As String, ByVal strSQL As String, ByVal strNameField As String, ByVal strValueField As String, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim myConn As SqlConnection = New SqlConnection(strConn)
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder
            Dim myAdapter As SqlDataAdapter = New SqlDataAdapter(strSQL, myConn)
            Dim myDS As DataSet = New DataSet
            With myAdapter
                .SelectCommand.CommandText = strSQL
                .Fill(myDS, "Report")
            End With

            LoadColors()

            With sbFCXMLData
                'Initialize the XML String
                If isPie = False Then
                    sbFCXMLData.Append("<graph bgcolor='FFFFFF' caption='" & strCaption & "' shownames='0' rotateNames='0' showvalues='1' decimalPrecision='0' numberPrefix='$' numberSuffix=''>" & Environment.NewLine())
                Else
                    sbFCXMLData.Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='0' numberPrefix='' numberSuffix=' Hrs.' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & Environment.NewLine())
                End If

                'Now iterate through each data row
                Dim i As Integer = 0
                Dim j As Integer = 0
                For i = 0 To myDS.Tables("Report").Rows.Count - 1
                    If myDS.Tables("Report").Rows(i).Item(strValueField) <> 0 Then
                        sbFCXMLData.Append("<set name='" & myDS.Tables("Report").Rows(i).Item(strNameField).ToString() & "' value='" & myDS.Tables("Report").Rows(i).Item(strValueField) & "' color='" & strColor(i Mod 10) & "'/>" & Environment.NewLine())
                    End If
                Next

                'End the XML data by adding the closing </graph> element
                sbFCXMLData.Append("</graph>")
            End With


            strFCXMLData = cleanString(sbFCXMLData.ToString())

            Return strFCXMLData

        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_CurrRatioPie(ByVal AssetAmount As Decimal, ByVal LiabAmount As Decimal, Optional ByVal StrCaption As String = "") As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            With sbFCXMLData
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    .Append("<graph bgcolor='FFFFFF' caption='" & StrCaption & "' shownames='0' rotateNames='0' showvalues='0' decimalPrecision='2' numberPrefix='' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='15' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & Environment.NewLine())
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    .Append("<graph bgcolor='FFFFFF' caption='" & StrCaption & "' shownames='0' rotateNames='0' showvalues='0' decimalPrecision='2' numberPrefix='' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='15' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & Environment.NewLine())
                Else
                    .Append("<graph bgcolor='FFFFFF' caption='" & StrCaption & "' shownames='0' rotateNames='0' showvalues='0' decimalPrecision='2' numberPrefix='$' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='15'>" & Environment.NewLine())
                End If
                .Append("<set name='Assets' value='" & AssetAmount & "' color='8BBA00' toolText='  Assets,  " & FormatNumber(AssetAmount, 2, True, False, True) & "  '/>" & Environment.NewLine())
                .Append("<set name='Liabilities' value='" & LiabAmount & "' color='CB0000' isSliced='1' toolText='  Liabilities,  " & FormatNumber(LiabAmount, 2, True, False, True) & "  '/>" & Environment.NewLine())
                .Append("</graph>")
            End With
            strFCXMLData = cleanString(sbFCXMLData.ToString())
            Return strFCXMLData
        Catch ex As Exception
            Return "getFCXMLData_BarPie Error: " & ex.Message.ToString
            Exit Function
        End Try
    End Function
    Public Shared Function getFCXMLData_Cyl(ByVal intUpperLimit As Integer, ByVal intLowerLimit As Integer,
                                            ByVal dblValue As Double, ByVal intDecPrecision As Integer, Optional ByVal boolShowValue As Boolean = False, Optional ByVal strBGColor As String = "FFFFFF",
                                            Optional ByVal strFontColor As String = "000000", Optional ByVal strCylColor As String = "FF5904",
                                            Optional ByVal strNumberSuffix As String = "") As String
        Dim strFCXMLData As String = String.Empty
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim strShowvalue As String = String.Empty
        If boolShowValue = True Then
            strShowvalue = "1"
        Else
            strShowvalue = "0"
        End If

        With sbFCXMLData
            .Append("<chart showValue='" & strShowvalue & "' bgColor='" & strBGColor & "' upperLimit='" & intUpperLimit.ToString() & "' lowerLimit='" & intLowerLimit & "' cylColor='" & strCylColor & "' baseFontColor='" & strFontColor & "' numberSuffix=' " & strNumberSuffix & "' decimalPrecision='" & intDecPrecision.ToString() & "' showborder='0'>")
            If dblValue <> 0 Then
                .Append("<value>" & dblValue & "</value>")
            End If
            .Append("</chart>")
        End With
        Return cleanString(sbFCXMLData.ToString())
    End Function
    Public Shared Function getFCXMLData_Thermo(ByVal intUpperLimit As Integer, ByVal intLowerLimit As Integer,
                                            ByVal dblValue As Double, ByVal intDecPrecision As Integer, Optional ByVal boolShowValue As Boolean = True, Optional ByVal strBGColor As String = "FFFFFF",
                                            Optional ByVal strFontColor As String = "000000", Optional ByVal strCylColor As String = "FF5904",
                                            Optional ByVal strNumberSuffix As String = "") As String
        Dim strFCXMLData As String = String.Empty
        Dim sbFCXMLData As StringBuilder = New StringBuilder
        Dim strShowvalue As String = String.Empty
        If boolShowValue = True Then
            strShowvalue = "1"
        Else
            strShowvalue = "0"
        End If

        With sbFCXMLData
            .Append("<chart showValue='" & strShowvalue & "' bgColor='" & strBGColor & "' upperLimit='" & intUpperLimit.ToString() & "' lowerLimit='" & intLowerLimit & "' cylColor='" & strCylColor & "' baseFontColor='" & strFontColor & "' numberSuffix=' " & strNumberSuffix & "' decimalPrecision='" & intDecPrecision.ToString() & "'>")
            If dblValue <> 0 Then
                .Append("<value>" & dblValue & "</value>")
            End If
            .Append("</chart>")
        End With
        Return cleanString(sbFCXMLData.ToString())
    End Function
    Public Shared Function getFCXMLData_RepositoryUsage() As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            Dim d As New DocumentRepository("", True)
            Dim RepositoryMax As Long = d.RepositoryMax
            Dim RepositoryUsed As Long = d.RepositoryUsed
            Dim OverRepositoryLmt As Boolean = d.IsOverRepositoryLimitSet

            If RepositoryMax = 0 Then
                With sbFCXMLData
                    .Append("<graph bgcolor='FFFFFF' caption='Repository Usage' shownames='1' rotateNames='0' showvalues='0' decimalPrecision='0' numberPrefix='' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='20'>" & Environment.NewLine())
                    .Append("<set name='No Data' value='0' color='FF00FF' toolText='0'/>" & Environment.NewLine())
                    .Append("</graph>")
                End With
            ElseIf RepositoryUsed >= RepositoryMax And OverRepositoryLmt = True Then
                With sbFCXMLData
                    .Append("<graph bgcolor='FFFFFF' caption='Repository Usage' shownames='0' rotateNames='0' showvalues='0' decimalPrecision='0' numberPrefix='' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='20'>" & Environment.NewLine())
                    .Append("<set name='Over limit!' value='10000' color='0000FF' toolText='Over limit!'/>" & Environment.NewLine())
                    .Append("</graph>")
                End With
            ElseIf RepositoryMax < 0 Then
                With sbFCXMLData
                    .Append("<graph bgcolor='FFFFFF' caption='Repository Usage' shownames='0' rotateNames='0' showvalues='0' decimalPrecision='0' numberPrefix='' numberSuffix='' animation='1' formatNumberScale='0' pieSliceDepth='20'>" & Environment.NewLine())
                    .Append("<set name='No limit on repository' value='10000' color='FF00FF' toolText='No limit on repository'/>" & Environment.NewLine())
                    .Append("</graph>")
                End With
            Else
                Dim Unused As Long = 0
                Dim Used As Long = 0
                Used = RepositoryUsed / d.MB
                Unused = (RepositoryMax - RepositoryUsed) / d.MB
                With sbFCXMLData
                    .Append("<graph bgcolor='FFFFFF' caption='Repository Usage' shownames='1' rotateNames='0' showvalues='1' decimalPrecision='2' numberPrefix='' numberSuffix=' MB' animation='1' formatNumberScale='0' pieSliceDepth='20'>" & Environment.NewLine())
                    .Append("<set name='Free space' value='" & Unused & "' color='FF00FF' toolText='  Free space,  " & FormatNumber(Unused, 2, True, False, True) & " MB  '/>" & Environment.NewLine())
                    .Append("<set name='Used space' value='" & Used & "' color='0000FF' isSliced='1' toolText='  Used space,  " & FormatNumber(Used, 2, True, False, True) & " MB  '/>" & Environment.NewLine())
                    .Append("</graph>")
                End With
            End If
            strFCXMLData = cleanString(sbFCXMLData.ToString())
            Return strFCXMLData
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function getFCXMLData_BarPie_agencyGoals(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
        Try
            Dim strFCXMLData As String
            Dim sbFCXMLData As StringBuilder = New StringBuilder

            LoadColors()

            With sbFCXMLData
                'Initialize the XML String
                If LoGlo.UserCultureGet() = "fr-FR" Then
                    .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
                ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
                    .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
                Else
                    .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='$' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & vbCrLf)
                End If
                .Append("<set name='Billing' value='" & DtForGraph.Rows(0).Item(1) & "' color='" & strColor(0 Mod 10) & "'/>" & vbCrLf)
                .Append("<set name='Gross Income' value='" & DtForGraph.Rows(1).Item(1) & "' color='" & strColor(1 Mod 10) & "'/>" & vbCrLf)
                .Append("<set name='Operating Expense' value='" & DtForGraph.Rows(2).Item(1) & "' color='" & strColor(2 Mod 10) & "'/>" & vbCrLf)
                .Append("<set name='Payroll' value='" & DtForGraph.Rows(3).Item(1) & "' color='" & strColor(3 Mod 10) & "'/>" & vbCrLf)
                .Append("<set name='Overhead' value='" & DtForGraph.Rows(4).Item(1) & "' color='" & strColor(4 Mod 10) & "'/>" & vbCrLf)
                .Append("<set name='Net Profit' value='" & DtForGraph.Rows(5).Item(1) & "' color='" & strColor(5 Mod 10) & "'/>" & vbCrLf)

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
    Public Shared Function ganttColors(ByVal phase As String)
        Try

            LoadColors()

            Dim index As Integer
            Dim colorGantt As String

            index = phaseNames.IndexOf(phaseNames, phase)
            If index = -1 Then
                count = count + 1
                index = count
                phaseNames(count) = phase
                colorGantt = strColor(index).ToString
            Else
                colorGantt = strColor(index).ToString
            End If
            Return colorGantt
        Catch ex As Exception
            Return "getFCXMLData_JobGanttColor Error: " & ex.Message.ToString
        End Try
    End Function

    Private Shared Sub LoadColors()

        strColor(0) = "2196F3" 'blue
        strColor(1) = "FFC107" 'gold
        strColor(2) = "673AB7" 'purple
        strColor(3) = "8BC34A" 'green
        strColor(4) = "FF9800" 'orange
        strColor(5) = "00BCD4" 'baby blue
        strColor(6) = "9E9E9E" 'gray
        strColor(7) = "4CAF50" 'dark green
        strColor(8) = "F44336" 'dark red
        strColor(9) = "3F51B5" 'darker blue

        strColor(10) = "607D8B" 'slate grey dark
        strColor(11) = "E91E63" 'deep pink
        strColor(12) = "9C27B0" 'light salmon
        strColor(13) = "CDDC39" 'maroon
        strColor(14) = "FFEB3B" 'tomato
        strColor(15) = "FF5722" 'burlywood
        strColor(16) = "993300" 'burnt sienna
        strColor(17) = "37474F" 'chocolate
        strColor(18) = "DD2C00" 'orange red
        strColor(19) = "1DE9B6" 'turquoise blue

        strColor(20) = "2A579A" 'turquoise blue

    End Sub

    Public Shared Function getMonthName(ByVal month As Integer)
        If month = 1 Then
            Return "JAN"
        End If
        If month = 2 Then
            Return "FEB"
        End If
        If month = 3 Then
            Return "MAR"
        End If
        If month = 4 Then
            Return "APR"
        End If
        If month = 5 Then
            Return "MAY"
        End If
        If month = 6 Then
            Return "JUN"
        End If
        If month = 7 Then
            Return "JUL"
        End If
        If month = 8 Then
            Return "AUG"
        End If
        If month = 9 Then
            Return "SEP"
        End If
        If month = 10 Then
            Return "OCT"
        End If
        If month = 11 Then
            Return "NOV"
        End If
        If month = 12 Then
            Return "DEC"
        End If

    End Function

#End Region

End Class
