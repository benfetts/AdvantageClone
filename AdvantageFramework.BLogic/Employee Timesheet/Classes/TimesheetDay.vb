Namespace EmployeeTimesheet.Classes

    <Serializable()>
    Public Class TimesheetDay
        Inherits BaseClasses.BaseClass

#Region " Enum "

        Public Enum Properties
            DayDate
            TotalHours
            IsDenied
            IsApproved
            IsPendingApproval
            PostPeriodIsClosed
            CanEdit
        End Enum

#End Region

#Region " Variables "

        Private _DayDate As Date = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _IsDenied As Boolean = Nothing
        Private _IsApproved As Boolean = Nothing
        Private _IsPendingApproval As Boolean = Nothing
        Private _PostPeriodIsClosed As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DayDate As Date
            Get
                DayDate = _DayDate
            End Get
            Set(value As Date)
                _DayDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHours As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDenied As Boolean
            Get
                IsDenied = _IsDenied
            End Get
            Set(value As Boolean)
                _IsDenied = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsApproved As Boolean
            Get
                IsApproved = _IsApproved
            End Get
            Set(value As Boolean)
                _IsApproved = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsPendingApproval As Boolean
            Get
                IsPendingApproval = _IsPendingApproval
            End Get
            Set(value As Boolean)
                _IsPendingApproval = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodIsClosed As Boolean
            Get
                PostPeriodIsClosed = _PostPeriodIsClosed
            End Get
            Set(value As Boolean)
                _PostPeriodIsClosed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property CanEdit As Boolean
            Get

                If Me.IsApproved = True OrElse Me.IsPendingApproval = True OrElse Me.PostPeriodIsClosed = True Then

                    CanEdit = False

                Else

                    CanEdit = True

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
