Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeTimeOff
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PTOType
            DateFrom
            DateTo
            HoursAllowed
            TimeRule
        End Enum

#End Region

#Region " Variables "

        Private _PTOType As AdvantageFramework.Database.Entities.PTOTypes = Nothing
        Private _DateFrom As Nullable(Of Date) = Nothing
        Private _DateTo As Nullable(Of Date) = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _TimeRule As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property PTOType As AdvantageFramework.Database.Entities.PTOTypes
            Get
                PTOType = _PTOType
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DateFrom As Nullable(Of Date)
            Get
                DateFrom = _DateFrom
            End Get
            Set(value As Nullable(Of Date))
                _DateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DateTo As Nullable(Of Date)
            Get
                DateTo = _DateTo
            End Get
            Set(value As Nullable(Of Date))
                _DateTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", UseMaxValue:=True, MaxValue:=999999.999, UseMinValue:=True, MinValue:=-999999.999)>
        Public Property HoursAllowed As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllowed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.PTORule)>
        Public Property TimeRule As Nullable(Of Integer)
            Get
                TimeRule = _TimeRule
            End Get
            Set(value As Nullable(Of Integer))
                _TimeRule = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal PTOType As AdvantageFramework.Database.Entities.PTOTypes)

            _PTOType = PTOType

        End Sub
        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
