Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class ApprovalView
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Enum "

        Public Enum Properties
            TimesheetDate
            CurrentStatus
            EmployeeCode
            StatusCode
        End Enum

        Public Enum DayStatus
            NoHours = 0
            None = 1
            Pending = 2
            Denied = 3
            Approved = 4
        End Enum

#End Region

#Region " Variables "

        Private _TimesheetDate As Date = Nothing
        Private _CurrentStatus As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _StatusCode As Short = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Date")>
        Public Property TimesheetDate As Date
            Get
                TimesheetDate = _TimesheetDate
            End Get
            Set(value As Date)
                _TimesheetDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property StatusCode As Short
            Get
                StatusCode = _StatusCode
            End Get
            Set(value As Short)
                _StatusCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Status")>
        Public ReadOnly Property CurrentStatus As String
            Get

                If _StatusCode = AdvantageFramework.EmployeeTimesheet.Classes.ApprovalView.DayStatus.None Then

                    CurrentStatus = ""

                Else

                    CurrentStatus = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(AdvantageFramework.EmployeeTimesheet.Classes.ApprovalView.DayStatus), _StatusCode).ToString)

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
