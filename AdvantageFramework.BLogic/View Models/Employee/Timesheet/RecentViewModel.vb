Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class RecentViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StringBuilder As System.Text.StringBuilder = Nothing

#End Region

#Region " Properties "

        Public Property LastUsed As DateTime? = Nothing
        Public Property AlertID As Integer? = 0
        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property TaskSequenceNumber As Short? = -1
        Public Property Title As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentDescription As String = String.Empty

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
        Public ReadOnly Property JobAndComponentNumbers As String
            Get

                _StringBuilder.Clear()

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

#End Region

#Region " Methods "

        Sub New()

            _StringBuilder = New Text.StringBuilder

        End Sub

#End Region

    End Class

End Namespace
