Imports System.Collections.Generic
Imports System.Drawing

Public Class DesktopBillableHoursGoal
    Inherits Webvantage.BaseDesktopObject

    Protected Friend _Month As String = ""
    Protected Friend _Year As String = ""
    Private _UpperLimit As Decimal = 0
    Private _LowerLimit As Decimal = 0
    Private _DataValue As Decimal = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Me.IsPostBack Then

            If Me.ddMonth.Items.Count = 0 Then

                LoadDropDowns()

            End If

            MiscFN.RadComboBoxSetIndex(Me.ddMonth, Date.Today.Month.ToString(), False)
            MiscFN.RadComboBoxSetIndex(Me.ddYear, Date.Today.Year.ToString(), False)

            Me._Month = Date.Today.Month
            Me._Year = Date.Today.Year

        Else

            Try

                Me._Month = Me.ddMonth.SelectedValue.ToString()
                Me._Year = Me.ddYear.SelectedValue.ToString()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub BuildDisplayTable(ByVal dt As DataTable)
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
    End Sub
    Private Sub AddRowToDisplayTable(ByRef dt As DataTable, ByVal Text As String, ByVal Value As String)
        Dim r As DataRow
        r = dt.NewRow()
        r("Description") = Text
        If Value.Trim() <> "" Then
            If IsNumeric(Value.Trim()) Then
                r("Value") = FormatNumber(Value.Trim(), , , , False)
            Else
                r("Value") = Value
            End If
        End If
        dt.Rows.Add(r)
    End Sub

    Private Sub LoadDropDowns()
        Me.ddMonth.Items.Clear()

        Dim i As Integer
        For i = 1 To 12

            Dim newMonth = New Date(2000, i, 1)
            Me.ddMonth.Items.Add(New Telerik.Web.UI.RadComboBoxItem(Format(newMonth, "MMM"), i))

        Next

        With Me.ddYear

            .Items.Clear()
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem(Date.Now.Year.ToString(), Date.Now.Year.ToString()))
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem(Date.Now.AddYears(-1).Year.ToString(), Date.Now.AddYears(-1).Year.ToString()))
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem(Date.Now.AddYears(-2).Year.ToString(), Date.Now.AddYears(-2).Year.ToString()))
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem(Date.Now.AddYears(-3).Year.ToString(), Date.Now.AddYears(-3).Year.ToString()))
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem(Date.Now.AddYears(-4).Year.ToString(), Date.Now.AddYears(-4).Year.ToString()))

        End With

    End Sub
    Private Sub setDefaultMonth()

        Me.ddMonth.SelectedIndex = -1
        Me.ddMonth.Items(Date.Now.Month - 1).Selected() = True

    End Sub

    Protected Sub butrefresh_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butrefresh.Click

        Me.RadGridDisplay.Rebind()

    End Sub
    Private Sub RadGridDisplay_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDisplay.NeedDataSource

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim StartDate As Date
        Dim EndDate As Date
        Dim dt As New DataTable
        Dim _Month As String

        _Month = CDate(Me._Month & "/" & "01" & "/" & Me._Year).ToString("MMM")

        StartDate = CDate(Me._Month & "/" & "01" & "/" & Me._Year)
        EndDate = StartDate.AddDays(Date.DaysInMonth(StartDate.Year, StartDate.Month) - 1)

        dt = oDO.GetTimeGoalPieGraph(CStr(Session("EmpCode")), StartDate, EndDate)

        Dim DisplayTable As New DataTable
        Me.BuildDisplayTable(DisplayTable)

        If dt.Rows(0).Item(0) < 0.01 And dt.Rows(0).Item(1) < 0.01 Then
            dt = oDO.GetMontlyGoal(CStr(Session("EmpCode")))

            If dt.Rows(0).Item(0) < 0.01 Then
                Me.AddRowToDisplayTable(DisplayTable, "No Hours or Monthly goal", "")
            Else

                Me.AddRowToDisplayTable(DisplayTable, "Goal for " & _Month & ", " & _Year, dt.Rows(0).Item(0))
                Me.AddRowToDisplayTable(DisplayTable, "Billable Hours", "0.00")
                Me.AddRowToDisplayTable(DisplayTable, "Hours To Goal", dt.Rows(0).Item(0))

                _UpperLimit = dt.Rows(0).Item(0)
                _LowerLimit = 0.0
                _DataValue = 0.0

                dt.Rows(0).Item(0) = 0

            End If
        ElseIf dt.Rows(0).Item(0) < 0.01 Then
            dt = oDO.GetMontlyGoal(CStr(Session("EmpCode")))

            Me.AddRowToDisplayTable(DisplayTable, "Goal for " & _Month & ", " & _Year, dt.Rows(0).Item(0))
            Me.AddRowToDisplayTable(DisplayTable, "Billable Hours", "0.00")
            Me.AddRowToDisplayTable(DisplayTable, "Hours To Goal", dt.Rows(0).Item(0))

            _UpperLimit = dt.Rows(0).Item(0)
            _LowerLimit = 0.0
            _DataValue = 0.0

            dt.Rows(0).Item(0) = 0.0

        Else
            Me.AddRowToDisplayTable(DisplayTable, "Goal for " & _Month & ", " & _Year, dt.Rows(0).Item(0) + dt.Rows(0).Item(1))
            Me.AddRowToDisplayTable(DisplayTable, "Billable Hours", dt.Rows(0).Item(0))
            If dt.Rows(0).Item(0) + dt.Rows(0).Item(1) > 0 Then
                Me.AddRowToDisplayTable(DisplayTable, "Hours To Goal", dt.Rows(0).Item(1))
            End If

            _UpperLimit = dt.Rows(0).Item(0) + dt.Rows(0).Item(1)
            _LowerLimit = 0.0
            _DataValue = dt.Rows(0).Item(0)

        End If

        If _DataValue > _UpperLimit Then _UpperLimit = _DataValue

        Me.RadGridDisplay.DataSource = DisplayTable

        If _DataValue = 0.0 Then

            _UpperLimit = 160
            _LowerLimit = 0

        Else

            If _UpperLimit > 0 Then

                Dim MajorUnit As Decimal = _UpperLimit / 4
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

        Me.RadRadialGaugeBillableHoursGoal.Scale.Max = _UpperLimit
        Me.RadRadialGaugeBillableHoursGoal.Scale.Min = _LowerLimit
        Me.RadRadialGaugeBillableHoursGoal.Pointer.Value = _DataValue

    End Sub

End Class