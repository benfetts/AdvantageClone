Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class EntryInfoViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String = String.Empty
        Public Property FunctionCategoryCode As String = String.Empty
        Public Property DepartmentTeamCode As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property EmployeeTimeID As Integer? = 0
        Public Property EmployeeTimeDetailID As Integer? = 0
        Public Property EntryDate As Date = Nothing
        Public Property TimeType As String = String.Empty
        Public Property EditFlag As Integer? = 0
        Public Property CommentsRequired As Boolean? = False
        Public Property HasComments As Boolean? = False
        Public Property Hours As Decimal = 0.00
        Public Property AlertID As Integer = 0

#End Region

#Region " Methods "

        Public Function ToArrayString() As String

            Dim DataKeyStringBuilder As New System.Text.StringBuilder

            DataKeyStringBuilder.Append(EmployeeCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(FunctionCategoryCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(DepartmentTeamCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(JobNumber.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(JobComponentNumber.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(EmployeeTimeID.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(EmployeeTimeDetailID.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(EditFlag.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(TimeType)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(EntryDate.ToShortDateString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(CommentsRequired.ToString().ToLower())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(HasComments.ToString().ToLower())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(Hours.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(AlertID.ToString())

            Return DataKeyStringBuilder.ToString

        End Function

        Sub New()

        End Sub

#End Region

    End Class

End Namespace


