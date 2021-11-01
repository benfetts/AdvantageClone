Imports cCharting

Partial Public Class DataStream
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ShowData(ChartType.Cylinder3D)
        'If Not Me.IsPostBack Then
        Dim strChartType As String = Request.QueryString("ChartType")
        Select Case strChartType
            Case "Cylinder3D"
                ShowCylinder()
            Case "Bar3D_ClientAging"
                ShowBar3D_ClientAging()
            Case "MultiLine_BillingTrends"
                ShowMultiLine_BillingTrends()
            Case "MultiLine_TimeGraph"
                ShowMultiLine_TimeGraph()
            Case "Bar2D_TimeGraph"
                ShowBar2D_TimeGraph()
            Case Else

        End Select
        'End If
    End Sub
    <Flags()>Public Enum ChartType
        Bar3D = 1
        Pie3D = 2
        Line2D = 3
        Cylinder3D = 4
    End Enum



    Protected Sub ShowCylinder()
        'If Not String.IsNullOrEmpty(Request.QueryString("UpperLimit")) Then 
        Dim intUpperLimit As Integer = Request.QueryString("UpperLimit")
        Dim intLowerLimit As Integer = Request.QueryString("LowerLimit")
        Dim intDataValue As Integer = Request.QueryString("DataValue")
        Response.Write(cCharting.getFCXMLData_Cyl(intUpperLimit, intLowerLimit, intDataValue, 2, True))
    End Sub

    Protected Sub ShowBar3D_ARForecast()
        'pass in same params as control: UserCode/ID and ClientID (optional)
        Response.Write(cCharting.getFCXMLData_MultiColumn_ARForecast(Session("dsARForecast"), "", False))
    End Sub

    Protected Sub ShowBar3D_ClientAging()

    End Sub
    Protected Sub ShowMultiLine_BillingTrends()
        Response.Write(cCharting.getFCXMLData_MultiLine_BillingTrends(Session("dsBillingTrends")))
        Session("dsBillingTrends") = Nothing
    End Sub
    Protected Sub ShowMultiLine_TimeGraph()
        Response.Write(cCharting.getFCXMLData_MultiLine_TimeGraph(Session("dsTimeGraph")))
    End Sub
    Protected Sub ShowBar2D_TimeGraph()
        Response.Write(cCharting.getFCXMLData_Bar2D_TimeGraph(Session("dsTimeGraph")))
    End Sub




'not used
    Protected Sub ShowData(ByVal thisChartType As ChartType)
        Select Case thisChartType
            Case ChartType.Bar3D
            Case ChartType.Pie3D
            Case ChartType.Line2D
            Case ChartType.Cylinder3D
        End Select
    End Sub

    End Class