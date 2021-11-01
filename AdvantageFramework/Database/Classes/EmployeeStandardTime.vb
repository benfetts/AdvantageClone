Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeStandardTime
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DayOfWeek
            DoesWork
            Hours
            StartTime
            EndTime
        End Enum

#End Region

#Region " Variables "

        Private _DayOfWeek As AdvantageFramework.DateUtilities.Days = Nothing
        Private _DoesWork As Boolean = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _StartTime As Nullable(Of Date) = Nothing
        Private _EndTime As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DayOfWeek As AdvantageFramework.DateUtilities.Days
            Get
                DayOfWeek = _DayOfWeek
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:=" ")>
        Public Property DoesWork As Boolean
            Get
                DoesWork = _DoesWork
            End Get
            Set(value As Boolean)
                _DoesWork = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", UseMaxValue:=True, MaxValue:=999999.999)>
        Public Property Hours As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StartTime As Nullable(Of Date)
            Get
                StartTime = _StartTime
            End Get
            Set(value As Nullable(Of Date))
                _StartTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EndTime As Nullable(Of Date)
            Get
                EndTime = _EndTime
            End Get
            Set(value As Nullable(Of Date))
                _EndTime = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal DayOfWeek As AdvantageFramework.DateUtilities.Days)

            _DayOfWeek = DayOfWeek

        End Sub

#End Region

    End Class

End Namespace
