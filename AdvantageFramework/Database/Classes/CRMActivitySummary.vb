Namespace Database.Classes

    <Serializable()>
    Public Class CRMActivitySummary
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            ActivityDate
            EmployeeName
            ActivityType
            Level
            Subject
            Body
            AllDay
        End Enum

#End Region

#Region " Variables "

        Private _AlertID As Nullable(Of Integer) = Nothing
        Private _ActivityDate As Nullable(Of Date) = Nothing
        Private _EmployeeName As String = Nothing
        Private _ActivityType As String = Nothing
        Private _Level As String = Nothing
        Private _Subject As String = Nothing
        Private _Body As String = Nothing
        Private _AllDay As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ActivityDate() As Nullable(Of Date)
            Get
                ActivityDate = _ActivityDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ActivityType As String
            Get
                ActivityType = _ActivityType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Level As String
            Get
                Level = _Level
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Subject As String
            Get
                Subject = _Subject
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Body As String
            Get
                Body = _Body
            End Get
            Set(value As String)
                '_Body = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AllDay As String
            Get
                AllDay = _AllDay
            End Get
            Set(value As String)
                '_Body = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property AlertID As Nullable(Of Integer)
            Get
                AlertID = _AlertID
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert)

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            _AlertID = Alert.ID

            _ActivityDate = If(Alert.GeneratedDate IsNot Nothing, Alert.GeneratedDate, Nothing)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Alert.EmployeeCode)

            If Employee IsNot Nothing Then

                _EmployeeName = Employee.FirstName & " " & Employee.LastName

            End If

            If Alert.AlertTypeID = 6 Then

                _ActivityType = "Alert"

            ElseIf Alert.AlertTypeID = 11 Then

                _ActivityType = "Diary"

            End If

            If Alert.JobNumber IsNot Nothing Then

                _Level = Alert.JobNumber & "-" & Alert.JobComponentNumber.ToString.PadRight(2, "0")

            ElseIf Alert.ProductCode IsNot Nothing Then

                _Level = "P"

            ElseIf Alert.DivisionCode IsNot Nothing Then

                _Level = "D"

            ElseIf Alert.ClientCode IsNot Nothing Then

                _Level = "C"

            End If

            _Subject = Alert.Subject

            _Body = Alert.Body

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask)

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            _ActivityDate = If(EmployeeNonTask.StartDateAndTime IsNot Nothing, EmployeeNonTask.StartDateAndTime, Nothing)

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeNonTask.EmployeeCode)

            If Employee IsNot Nothing Then

                _EmployeeName = Employee.FirstName & " " & Employee.LastName

            End If

            If EmployeeNonTask.Type = "C" Then

                _ActivityType = "Call"

            ElseIf EmployeeNonTask.Type = "M" Then

                _ActivityType = "Meeting"

            ElseIf EmployeeNonTask.Type = "TD" Then

                _ActivityType = "To Do"

            ElseIf EmployeeNonTask.Type = "EL" Then

                _ActivityType = "Email"

            End If

            If EmployeeNonTask.JobNumber IsNot Nothing Then

                _Level = EmployeeNonTask.JobNumber & "-" & EmployeeNonTask.JobComponentNumber.ToString.PadRight(2, "0")

            Else

                If EmployeeNonTask.ProductCode IsNot Nothing AndAlso EmployeeNonTask.ProductCode <> "" Then

                    _Level = "P"

                ElseIf EmployeeNonTask.DivisionCode IsNot Nothing AndAlso EmployeeNonTask.DivisionCode <> "" Then

                    _Level = "D"

                Else

                    _Level = "C"

                End If

            End If

            _Subject = EmployeeNonTask.Description

            _Body = EmployeeNonTask.NontaskDescription

            If EmployeeNonTask.IsAllDay = 1 Then

                _AllDay = "Yes"

            Else

                _AllDay = "No"

            End If

        End Sub

#End Region

    End Class

End Namespace
