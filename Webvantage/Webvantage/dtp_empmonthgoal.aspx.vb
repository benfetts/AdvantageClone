Imports cCharting
Imports System.Collections.Generic
Imports InfoSoftGlobal
Imports DevExpress.Web.ASPxGauges
Imports DevExpress.Web.ASPxGauges.Gauges.Linear
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.Web.ASPxGauges.Base

Public Class dtp_empmonthgoal
    Inherits Webvantage.BaseChildPage

    Private the_month As String = ""
    Private the_year As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            the_month = CType(Request.QueryString("month"), Integer)
        Catch ex As Exception
            the_month = Now.Month.ToString()
        End Try
        Try
            the_year = CType(Request.QueryString("year"), Integer)
        Catch ex As Exception
            the_year = Now.Year.ToString()
        End Try
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadGraph(the_month, the_year)
                End If
            End If
        Catch ex As Exception
            Me.ShowMessage("Problem: " & ex.Message.ToString())
        End Try

    End Sub

    Public intUpperLimit As Decimal = 0
    Public intLowerLimit As Decimal = 0
    Public intDataValue As Decimal = 0
    Private display As New DataTable
    Private Sub BuildDisplayTable()
        Dim dt As New DataTable
        dt.Columns.Clear()
        Dim TextColumn As New DataColumn
        With TextColumn
            .ColumnName = "Description"
            .DataType = GetType(String)
        End With
        Dim ValueColumn As New DataColumn
        With ValueColumn
            .ColumnName = "Value"
            .DataType = GetType(String)
        End With
        With dt.Columns
            .Add(TextColumn)
            .Add(ValueColumn)
        End With
        display = dt
        display.Rows.Clear()
    End Sub

    Private Sub AddRowToDisplayTable(ByVal Text As String, ByVal Value As String)
        Dim r As DataRow
        r = display.NewRow()
        r("Description") = Text
        If Value.Trim() <> "" Then
            If IsNumeric(Value.Trim()) Then
                r("Value") = FormatNumber(Value.Trim(), , , , False)
            Else
                r("Value") = Value
            End If
        End If
        Me.display.Rows.Add(r)
    End Sub
    Private Sub LoadGraph(ByVal Month As String, ByVal Year As String)
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim StartDate As Date
        Dim EndDate As Date
        Dim dt As New DataTable
        Dim strMonth As String

        If IsNumeric(Month) = False Then
            Month = Date.Today.Month
        End If
        If IsNumeric(Year) = False Then
            Year = Date.Today.Year
        End If

        strMonth = CDate(Month & "/" & "01" & "/" & Year).ToString("MMM")
        StartDate = CDate(Month & "/" & "01" & "/" & Year)
        EndDate = StartDate.AddDays(Date.DaysInMonth(StartDate.Year, StartDate.Month) - 1)

        dt = oDO.GetTimeGoalPieGraph(CStr(Session("EmpCode")), StartDate, EndDate)

        Me.BuildDisplayTable()

        If dt.Rows(0).Item(0) < 0.01 And dt.Rows(0).Item(1) < 0.01 Then
            dt = oDO.GetMontlyGoal(CStr(Session("EmpCode")))

            If dt.Rows(0).Item(0) < 0.01 Then
                Me.AddRowToDisplayTable("No Hours or Monthly goal", "")
            Else

                Me.AddRowToDisplayTable("Goal for " & strMonth & ", " & Year, dt.Rows(0).Item(0))
                Me.AddRowToDisplayTable("Billable Hours", "0.00")
                Me.AddRowToDisplayTable("Hours To Goal", dt.Rows(0).Item(0))

                intUpperLimit = dt.Rows(0).Item(0)
                intLowerLimit = 0.0
                intDataValue = 0.0

                dt.Rows(0).Item(0) = 0

            End If
        ElseIf dt.Rows(0).Item(0) < 0.01 Then
            dt = oDO.GetMontlyGoal(CStr(Session("EmpCode")))

            Me.AddRowToDisplayTable("Goal for " & strMonth & ", " & Year, dt.Rows(0).Item(0))
            Me.AddRowToDisplayTable("Billable Hours", "0.00")
            Me.AddRowToDisplayTable("Hours To Goal", dt.Rows(0).Item(0))

            intUpperLimit = dt.Rows(0).Item(0)
            intLowerLimit = 0.0
            intDataValue = 0.0

            dt.Rows(0).Item(0) = 0.0

        Else
            Me.AddRowToDisplayTable("Goal for " & strMonth & ", " & Year, dt.Rows(0).Item(0) + dt.Rows(0).Item(1))
            Me.AddRowToDisplayTable("Billable Hours", dt.Rows(0).Item(0))
            If dt.Rows(0).Item(0) + dt.Rows(0).Item(1) > 0 Then
                Me.AddRowToDisplayTable("Hours To Goal", dt.Rows(0).Item(1))
            End If

            intUpperLimit = dt.Rows(0).Item(0) + dt.Rows(0).Item(1)
            intLowerLimit = 0.0
            intDataValue = dt.Rows(0).Item(0)

        End If

        Me.RadGridDisplay.DataSource = Me.display
        Me.RadGridDisplay.DataBind()

        If intDataValue = 0.0 Then

            intUpperLimit = 160
            intLowerLimit = 0

        Else

            If intUpperLimit > 0 Then

                Dim MajorUnit As Decimal = intUpperLimit / 4
                Dim LastTo As Decimal = MajorUnit

                Me.RadRadialGaugeBillableHoursGoal.Scale.MajorUnit = MajorUnit

                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(0).From = 0
                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(0).To = LastTo

                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(1).From = LastTo
                LastTo = LastTo + MajorUnit
                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(1).To = LastTo

                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(2).From = LastTo
                LastTo = LastTo + MajorUnit
                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(2).To = LastTo

                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(3).From = LastTo
                LastTo = LastTo + MajorUnit
                Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges(3).To = LastTo


                '''' Can't set range color in code behind ?!?!!?@#$#$%%#@!!! WTF!!!!
                ''Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges.Clear()

                ''Dim LowestRange As Telerik.Web.UI.GaugeRange
                ''LowestRange.Color = System.Drawing.Color.Azure ' ColorTranslator.FromHtml("#F44336")
                ''LowestRange.From = 0
                ''LowestRange.To = LastTo
                ''Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges.Add(LowestRange)

                ''Dim LowRange As Telerik.Web.UI.GaugeRange
                ''LowRange.Color = System.Drawing.Color.DarkOrchid 'ColorTranslator.FromHtml("#FF9800")
                ''LowRange.From = LastTo
                ''LastTo = LastTo + MajorUnit
                ''LowRange.To = LastTo
                ''Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges.Add(LowRange)

                ''Dim MediumRange As Telerik.Web.UI.GaugeRange
                ''MediumRange.Color = System.Drawing.Color.GreenYellow 'ColorTranslator.FromHtml("#FFC107")
                ''MediumRange.From = LastTo
                ''LastTo = LastTo + MajorUnit
                ''MediumRange.To = LastTo
                ''Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges.Add(MediumRange)

                ''Dim HighRange As Telerik.Web.UI.GaugeRange
                ''HighRange.Color = System.Drawing.Color.Salmon 'ColorTranslator.FromHtml("#4CAF50")
                ''HighRange.From = LastTo
                ''HighRange.To = _UpperLimit
                ''Me.RadRadialGaugeBillableHoursGoal.Scale.Ranges.Add(HighRange)

            End If

        End If

        Me.RadRadialGaugeBillableHoursGoal.Scale.Max = intUpperLimit
        Me.RadRadialGaugeBillableHoursGoal.Scale.Min = intLowerLimit
        Me.RadRadialGaugeBillableHoursGoal.Pointer.Value = intDataValue

    End Sub

    Private Function GetGaugeScale(ByVal gaugeControl As ASPxGaugeControl, ByVal gaugeIndex As Integer, ByVal scaleIndex As Integer) As LinearScaleComponent
        Return (CType(gaugeControl.Gauges(gaugeIndex), ILinearGauge)).Scales(scaleIndex)
    End Function

End Class