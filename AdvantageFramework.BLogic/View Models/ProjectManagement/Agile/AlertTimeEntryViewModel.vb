Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class AlertTimeEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer? = 0
        Public Property Title As String = String.Empty
        Public Property [Date] As DateTime?
        Public Property FunctionCode As String = String.Empty
        Public Property Functions As IEnumerable
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeDefaultFunctionCode As String = String.Empty
        Public Property Hours As Decimal? = 0
        Public Property Comment As String = String.Empty
        Public Property CommentRequired As Boolean = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
