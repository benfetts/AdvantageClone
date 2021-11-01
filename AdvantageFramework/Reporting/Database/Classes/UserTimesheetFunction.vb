Namespace Reporting.Database.Classes

    <Serializable>
    Public Class UserTimesheetFunction

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            EmployeeName
            UserCode
            FunctionCode
            FunctionDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode() As String
        Public Property EmployeeName() As String
        Public Property UserCode() As String
        Public Property FunctionCode() As String
        Public Property FunctionDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode.ToString

        End Function

#End Region

    End Class

End Namespace
