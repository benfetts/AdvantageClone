Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class TimesheetLineViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertSubject As String = String.Empty
        Public Property AlertID As Integer? = 0
        <Newtonsoft.Json.JsonIgnore>
        Public Property LineID As String = String.Empty
        '<Newtonsoft.Json.JsonIgnore>
        'Public Property LineIdentifier As String = String.Empty
        Public Property NonEditMessage As String = String.Empty
        Public Property JobProcessControl As Integer? = 0
        Public Property ClientName As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductDescription As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Short? = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property FunctionCategory As String = String.Empty
        Public Property FunctionCategoryDescription As String = String.Empty
        Public Property DepartmentTeamCode As String = String.Empty
        Public Property ProductCategory As String = String.Empty
        Public Property TimeType As String = String.Empty
        Public ReadOnly Property ClientDivisionProductDisplay
            Get

                Dim StringBuilder As New Text.StringBuilder

                StringBuilder.Append(ClientName)

                If DivisionName <> ClientName Then

                    StringBuilder.Append("|")
                    StringBuilder.Append(DivisionName)

                End If
                If ProductDescription <> DivisionName Then

                    StringBuilder.Append("|")
                    StringBuilder.Append(ProductDescription)

                End If
                Return StringBuilder.ToString

            End Get
        End Property
        Public ReadOnly Property JobComponentDisplay
            Get

                Dim Val As String = String.Empty

                If JobNumber IsNot Nothing AndAlso JobComponentNumber IsNot Nothing AndAlso JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Dim StringBuilder As New Text.StringBuilder

                    StringBuilder.Append(JobNumber.ToString.PadLeft(6, "0"))
                    StringBuilder.Append("/")
                    StringBuilder.Append(JobComponentNumber.ToString.PadLeft(2, "0"))
                    StringBuilder.Append(" - ")
                    StringBuilder.Append(JobDescription)

                    If JobComponentDescription <> JobDescription Then

                        StringBuilder.Append("|")
                        StringBuilder.Append(JobComponentDescription)

                    End If

                    Val = StringBuilder.ToString

                End If

                Return Val

            End Get
        End Property

        'Public Property TotalHours As Double? = 0.0
        Public ReadOnly Property TotalHours As Decimal
            Get
                If Entries Is Nothing Then

                    Return 0.00

                Else

                    Return (From Entity In Entries
                            Select Entity.Hours).Sum

                End If
            End Get
        End Property
        Public Property QuotedAmount As Double? = 0.0
        Public Property QuotedHours As Double? = 0.0
        Public Property ActualAmount As Double? = 0.0
        Public Property ActualHours As Double? = 0.0
        Public Property Threshold As Integer? = 0
        Public Property IsOverThreshold As Boolean? = False
        Public Property ProgressIsShowingTrafficHours As Boolean? = False
        Public Property ProgressIsShowingOnlyEmployee As Boolean? = False
        Public Property CannotEditDueToProcessingControl As Boolean? = False
        Public Property ClientCommentRequired As Boolean? = False

        Public Property Entries As Generic.List(Of TimesheetEntryViewModel) = Nothing

#End Region

#Region " Methods "

        Sub New()

            Entries = New List(Of TimesheetEntryViewModel)

        End Sub

#End Region

    End Class

End Namespace
