Imports Telerik.Web.UI
Imports Telerik.Charting
Imports System.Data.SqlClient

Public Class dtp_currentRatio_graph_print
    Inherits Webvantage.BaseChildPage

    Public ratio, assets, liabs As Double

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadHeader()
            LoadChart()
        End If
    End Sub

    Private DtGraphData As New DataTable
    Private Sub LoadChart()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim reader As SqlDataReader
        Dim startPP, endPP, Office As String
        Dim ratio As Double

        startPP = Session("PPBEGIN_CRG")
        endPP = Session("PPEND_CRG")
        Office = Session("OFFICE_CRG")

        If Office = "All" Then
            Office = ""
        End If

        Try
            reader = oDO.GetCurrentRatio(startPP, endPP, Office, Session("UserCode"))

            If reader.HasRows Then
                reader.Read()
                assets = reader.GetDouble(2)
                liabs = reader.GetDouble(3)
                ratio = reader.GetDouble(4)
            End If

        Catch
            Err.Raise(Err.Number, "Class:dt_currentratio_graph Routine:LoadChart", Err.Description)
        End Try

        Try

            cCharting.GetPieChart_CurrentRatio(RadHtmlChartCurrentRatio, assets, liabs, "Current Ratio: " & ratio.ToString("N2"))

        Catch ex As Exception

        End Try

        reader.Close()
    End Sub
    Public Function WriteXML() As String
        Return cCharting.getFCXMLData_CurrRatioPie(assets, liabs, "")
    End Function

    Private Sub LoadHeader()
        Dim startPP, endPP, Office As String
        Dim header_str As String

        startPP = Session("PPBEGIN_CRG")
        endPP = Session("PPEND_CRG")
        Office = Session("OFFICE_CRG")

        header_str = "Current Ratio &nbsp;&nbsp; Period Range: " & startPP & " to " & endPP
        Me.Label1.Text = header_str

        header_str = "Office: " & Office
        Me.lblType.Text = header_str

    End Sub

End Class