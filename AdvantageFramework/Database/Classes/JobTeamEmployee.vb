Namespace Database.Classes

    <Serializable()>
    Public Class JobTeamEmployee

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TeamTypeID
            EmployeeCode
            Title
            FirstName
            LastName
            MiddleInitial
            BinaryImage
            Nickname
            TaskCount
            TotalHours
            ActualHours
            DisplayName
            EmailGroupCode
            TrafficColumnCode
            ManagerType
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property TeamTypeID() As Nullable(Of Short)

        Public Property EmployeeCode() As String

        Public Property Title() As String

        Public Property FirstName() As String

        Public Property LastName() As String

        Public Property MiddleInitial() As String

        Public Property BinaryImage() As Byte()

        Public Property Nickname() As String

        Public Property TaskCount() As Integer

        Public Property TotalHours() As Decimal

        Public Property ActualHours() As Decimal

        Public Property DisplayName() As String

        Public Property EmailGroupCode() As String

        Public Property TrafficColumnCode() As String

        Public Property ManagerType() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TeamTypeID.ToString

        End Function

#End Region

    End Class

End Namespace
