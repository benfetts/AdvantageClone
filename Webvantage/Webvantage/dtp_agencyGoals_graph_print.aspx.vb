Imports System
Imports System.Text
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Xml
Imports microsoft.VisualBasic

Partial Public Class dtp_agencyGoals_graph_print
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub

    Private startPP, endPP, Office As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            LoadHeader()

            Dim s As String = ""
            If Webvantage.DesktopAgencyGoalsGraph.LoadChart(Me.RadHtmlChartAgencyGoals, startPP, endPP, Office, s) = False Then

                Me.ShowMessage(s)

            End If

        End If

    End Sub

    'Public Function WriteURL() As String
    '    Dim str As String = getFCXMLData_BarPie_agencyGoals(DtGraphData, "", False)
    '    Return str
    'End Function
    'Public Shared Function getFCXMLData_BarPie_agencyGoals(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
    '    Try
    '        Dim strFCXMLData As String
    '        Dim sbFCXMLData As StringBuilder = New StringBuilder
    '        Dim strColor(10) As String
    '        strColor(0) = "D00000" '"AFD8F8" 'Baby blue
    '        strColor(1) = "F6BD0F" 'gold
    '        strColor(2) = "A66EDD" 'purple
    '        strColor(3) = "8BBA00" 'green
    '        strColor(4) = "FF8000" 'orange
    '        strColor(5) = "AFD8F8" 'baby blue
    '        strColor(6) = "999999" 'gray
    '        strColor(7) = "005500" 'dark green
    '        strColor(8) = "AA0000" 'dark red
    '        strColor(9) = "0372AB" 'darker blue

    '        With sbFCXMLData
    '            'Initialize the XML String
    '            If LoGlo.UserCultureGet() = "fr-FR" Then
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
    '            ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
    '            Else
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='$' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & vbCrLf)
    '            End If
    '            .Append("<set name='Billing' value='" & DtForGraph.Rows(0).Item(1) & "' color='" & strColor(0 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Gross Income' value='" & DtForGraph.Rows(1).Item(1) & "' color='" & strColor(1 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Operating Expense' value='" & DtForGraph.Rows(2).Item(1) & "' color='" & strColor(2 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Payroll' value='" & DtForGraph.Rows(3).Item(1) & "' color='" & strColor(3 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Overhead' value='" & DtForGraph.Rows(4).Item(1) & "' color='" & strColor(4 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Net Profit' value='" & DtForGraph.Rows(5).Item(1) & "' color='" & strColor(5 Mod 10) & "'/>" & vbCrLf)

    '            .Append("</graph>")
    '        End With

    '        strFCXMLData = cleanString(sbFCXMLData.ToString())

    '        Return strFCXMLData

    '    Catch ex As Exception
    '        Return "getFCXMLData_BarPie_agencyGoals Error: " & ex.Message.ToString
    '        Exit Function
    '    End Try
    'End Function
    'Public Shared Function cleanString(ByVal str As String) As String
    '    str = str.Replace("&", " and ")
    '    str = str.Replace("n's", "ns")
    '    str = str.Replace("12:00:00 AM", "")
    '    Return str
    'End Function

    Private Sub LoadHeader()

        Dim header_str As String

        startPP = Session("PPBEGIN_AGLSG")
        endPP = Session("PPEND_AGLSG")
        Office = Session("OFFICE_AGLSG")

        header_str = "Agency Goals &nbsp;&nbsp;&nbsp;Period Range: " & startPP & " to " & endPP
        Me.Label1.Text = header_str

        header_str = "Office: " & Office
        Me.lblType.Text = header_str

    End Sub

End Class