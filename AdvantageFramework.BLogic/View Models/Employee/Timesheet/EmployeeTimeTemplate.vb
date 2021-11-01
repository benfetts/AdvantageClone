Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class EmployeeTimeTemplate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            EmployeeTimeTemplateID
            EmployeeCode
            EmployeeFirstName
            EmployeeMiddleInitial
            EmployeeLastName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            CategoryCode
            IsTimeCategory
            FunctionCategoryDescription
            Comment
            JobAndComponent
            DepartmentTeamCode
            Hours
            ApplyToDays
            ClientCode
            DivisionCode
            ProductCode
            ClientName
            DivisionName
            ProductName
            JobProcessControl
            IsClosed
            HasAccessToFunction

        End Enum

#End Region

#Region " Variables "

        Private _StringBuilder As System.Text.StringBuilder = Nothing

#End Region

#Region " Properties "

        Public Property EmployeeTimeTemplateID As Integer = 0
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeFirstName As String = String.Empty
        Public Property EmployeeMiddleInitial As String = String.Empty
        Public Property EmployeeLastName As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Short? = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property FunctionCode As String = String.Empty
        Public Property CategoryCode As String = String.Empty
        Public Property IsTimeCategory As Boolean = False
        Public Property FunctionCategoryDescription As String = String.Empty
        Public Property Comment As String = String.Empty
        Public Property JobAndComponentNumbers As String = String.Empty
        Public Property DepartmentTeamCode As String = String.Empty
        Public Property Hours As Decimal = 0.00
        Public Property ApplyToDays As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobProcessControl As Short = 0
        Public Property IsClosed As Boolean = False
        Public Property HasAccessToFunction As Boolean = False
        Public ReadOnly Property CDPDisplay As String
            Get

                _StringBuilder.Clear()

                If String.IsNullOrWhiteSpace(ClientName) = False Then

                    _StringBuilder.Append(ClientName)

                    If String.IsNullOrWhiteSpace(DivisionName) = False AndAlso DivisionName <> ClientName Then

                        _StringBuilder.Append("|")
                        _StringBuilder.Append(DivisionName)

                        If String.IsNullOrWhiteSpace(ProductName) = False AndAlso ProductName <> DivisionName Then

                            _StringBuilder.Append("|")
                            _StringBuilder.Append(ProductName)

                        End If

                    End If

                End If

                Return _StringBuilder.ToString

            End Get
        End Property
        Public ReadOnly Property JobDisplay As String
            Get

                _StringBuilder.Clear()

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
        Public ReadOnly Property ApplyToDaysAbbrev As String
            Get
                If String.IsNullOrWhiteSpace(ApplyToDays) = True Then

                    Return String.Empty

                Else

                    Return ApplyToDays.Replace("0", "Sun").Replace("1", "Mon").Replace("2", "Tue").Replace("3", "Wed").Replace("4", "Thu").Replace("5", "Fri").Replace("6", "Sat").Replace(",", ", ")

                End If

            End Get
        End Property
#End Region

#Region " Methods "

        Sub New()

            _StringBuilder = New Text.StringBuilder

        End Sub

#End Region

    End Class

End Namespace
