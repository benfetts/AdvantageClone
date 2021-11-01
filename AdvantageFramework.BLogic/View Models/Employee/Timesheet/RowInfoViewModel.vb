Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class RowInfoViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property FunctionCategoryCode As String = String.Empty
        Public Property DepartmentTeamCode As String = String.Empty
        Public Property JobProcessControl As Integer? = 0
        Public Property AlertID As Integer = 0

#End Region

#Region " Methods "

        Public Function ToArrayString() As String

            Dim DataKeyStringBuilder As New System.Text.StringBuilder

            DataKeyStringBuilder.Append(ClientCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(DivisionCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(ProductCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(JobNumber.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(JobComponentNumber.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(FunctionCategoryCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(DepartmentTeamCode)
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(JobProcessControl.ToString())
            DataKeyStringBuilder.Append("|")
            DataKeyStringBuilder.Append(AlertID.ToString())

            Return DataKeyStringBuilder.ToString

        End Function

        Sub New()

        End Sub

#End Region

    End Class

End Namespace


