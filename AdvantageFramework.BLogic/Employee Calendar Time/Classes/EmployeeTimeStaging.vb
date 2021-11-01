Namespace EmployeeCalendarTime.Classes

    <Serializable()>
    Public Class EmployeeTimeStaging

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            StartDate
            EndDate
            StartTime
            EndTime
            Hours
            EmployeeCode
            OutlookID
            GoogleID
            CalendarID
            Comments
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            FunctionCode
            DepartmentCode
            DepartmentName
            ProductCategoryCode
            TimeType

        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property ID As Nullable(Of Integer) = 0
        Public Property StartDate As Nullable(Of Date) = Nothing
        Public Property EndDate As Nullable(Of Date) = Nothing
        Public Property StartTime As Nullable(Of Date) = Nothing
        Public Property EndTime As Nullable(Of Date) = Nothing
        Public Property Hours As Nullable(Of Decimal) = 0
        Public Property EmployeeCode As String = String.Empty
        Public Property OutlookID As String = String.Empty
        Public Property GoogleID As String = String.Empty
        Public Property CalendarID As String = String.Empty
        Public Property Comments As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobNumber As Nullable(Of Integer) = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Nullable(Of Short) = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property FunctionCode As String = String.Empty
        Public Property FunctionName As String = String.Empty
        Public Property DepartmentCode As String = String.Empty
        Public Property DepartmentName As String = String.Empty
        Public Property ProductCategoryCode As String = String.Empty
        Public Property TimeType As String = String.Empty
        Public ReadOnly Property CDPDisplay As String
            Get

                Dim _Stringbuilder As New System.Text.StringBuilder
                _Stringbuilder.Clear()

                If String.IsNullOrWhiteSpace(ClientName) = False Then

                    _Stringbuilder.Append(ClientName)

                    If String.IsNullOrWhiteSpace(DivisionName) = False AndAlso DivisionName <> ClientName Then

                        _Stringbuilder.Append("|")
                        _Stringbuilder.Append(DivisionName)

                        If String.IsNullOrWhiteSpace(ProductName) = False AndAlso ProductName <> DivisionName Then

                            _Stringbuilder.Append("|")
                            _Stringbuilder.Append(ProductName)

                        End If

                    End If

                End If

                Return _Stringbuilder.ToString

            End Get
        End Property
        Public ReadOnly Property JobAndComponentNumbers As String
            Get

                Dim _Stringbuilder As New System.Text.StringBuilder
                _Stringbuilder.Clear()

                If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                    _StringBuilder.Append("(")

                    _StringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                    If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                        _StringBuilder.Append("/")
                        _StringBuilder.Append(JobComponentNumber.ToString.PadLeft(3, "0"))

                    End If

                    _StringBuilder.Append(")")

                End If

                Return _StringBuilder.ToString

            End Get
        End Property
        Public ReadOnly Property JobDisplay As String
            Get

                Dim _Stringbuilder As New System.Text.StringBuilder
                _Stringbuilder.Clear()

                If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                    _StringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))

                    If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                        _StringBuilder.Append("/")
                        _StringBuilder.Append(JobComponentNumber.ToString.PadLeft(3, "0"))

                    End If
                    If String.IsNullOrWhiteSpace(JobDescription) = False Then

                        _StringBuilder.Append(" - ")

                        If String.IsNullOrWhiteSpace(JobComponentDescription) = False AndAlso JobComponentDescription <> JobDescription Then

                            _StringBuilder.Append(JobDescription)
                            _StringBuilder.Append(" | ")
                            _StringBuilder.Append(JobComponentDescription)

                        Else

                            _StringBuilder.Append(JobDescription)

                        End If

                    End If

                End If

                Return _StringBuilder.ToString

            End Get
        End Property
        Public ReadOnly Property DateDisplay As String
            Get

                Dim s As String = String.Empty

                If StartDate IsNot Nothing Then

                    s = CType(StartDate, Date).ToShortDateString

                End If
                'Dim sd As String = String.Empty
                'Dim ed As String = String.Empty

                'Try

                '    If StartDate IsNot Nothing AndAlso EndDate Is Nothing Then
                '        s = CType(StartDate, Date).ToShortDateString
                '    ElseIf StartDate Is Nothing AndAlso EndDate IsNot Nothing Then
                '        s = CType(EndDate, Date).ToShortDateString
                '    ElseIf StartDate IsNot Nothing AndAlso EndDate IsNot Nothing Then
                '        sd = CType(StartDate, Date).ToShortDateString
                '        ed = CType(EndDate, Date).ToShortDateString
                '        If sd = ed Then
                '            s = CType(StartDate, Date).ToShortDateString
                '        Else
                '            s = CType(StartDate, Date).ToShortDateString & " - " & CType(EndDate, Date).ToShortDateString
                '        End If
                '    ElseIf StartDate Is Nothing AndAlso EndDate Is Nothing Then

                '    End If
                '    If String.IsNullOrWhiteSpace(s) = False Then

                '        sd = String.Empty
                '        ed = String.Empty
                '        s &= ",  "
                '        If StartTime IsNot Nothing AndAlso EndTime Is Nothing Then
                '            s &= CType(StartTime, Date).ToShortTimeString
                '        ElseIf StartTime Is Nothing AndAlso EndTime IsNot Nothing Then
                '            s &= CType(EndTime, Date).ToShortTimeString
                '        ElseIf StartTime IsNot Nothing AndAlso EndTime IsNot Nothing Then
                '            sd &= CType(StartTime, Date).ToShortTimeString
                '            ed &= CType(EndTime, Date).ToShortTimeString
                '            If sd = ed Then
                '                s &= CType(StartTime, Date).ToShortTimeString
                '            Else
                '                s &= CType(StartTime, Date).ToShortTimeString & " - " & CType(EndTime, Date).ToShortTimeString
                '            End If
                '        ElseIf StartTime Is Nothing AndAlso EndTime Is Nothing Then

                '        End If

                '    End If

                'Catch ex As Exception
                '    s = String.Empty
                'End Try

                Return s

            End Get
        End Property
        'Public ReadOnly Property HoursFromTime As Decimal
        '    Get

        '        Dim Hours As Decimal = 0.0
        '        Dim HH As Long = 0
        '        Dim MM As Long = 0

        '        Try

        '            If StartTime IsNot Nothing AndAlso EndTime IsNot Nothing Then

        '                HH = DateDiff(DateInterval.Hour, CType(EndTime, DateTime), CType(StartTime, DateTime))
        '                MM = DateDiff(DateInterval.Minute, CType(EndTime, DateTime), CType(StartTime, DateTime))

        '                MM = MM - (HH * 60)

        '                Hours = HH + MM / 60

        '                Hours = Math.Round(Hours, 2)

        '            End If

        '        Catch ex As Exception
        '            Hours = 0.0
        '        End Try

        '        Return HH

        '    End Get
        'End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace

