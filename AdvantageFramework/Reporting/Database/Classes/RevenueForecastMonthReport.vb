Namespace Reporting.Database.Classes

    <Serializable>
    Public Class RevenueForecastMonthReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            JobComponent
            Type
            Type2
            JobProcessControl
            EstimatedGrossIncome
            CurrentRevenue
            PriorRevenue
            TotalHours
            PercentCompleteToDate
            Month
            EstimateHours
            ActualHours
            ForecastedHours
            ProjectedHours
            RemainingHours
            EstimateAmount
            ActualAmount
            ForecastedAmount
            ProjectedAmount
            RemainingAmount

        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _Type As String = Nothing
        Private _Type2 As String = Nothing
        Private _JobProcessControl As String = Nothing
        Private _EstimatedGrossIncome As System.Nullable(Of Decimal) = Nothing
        Private _CurrentRevenue As System.Nullable(Of Decimal) = Nothing
        Private _PriorRevenue As System.Nullable(Of Decimal) = Nothing
        Private _TotalHours As System.Nullable(Of Decimal) = Nothing
        Private _PercentCompleteToDate As System.Nullable(Of Decimal) = Nothing
        Private _Month As System.Nullable(Of Integer) = Nothing
        Private _EstimateHours As System.Nullable(Of Decimal) = Nothing
        Private _ActualHours As System.Nullable(Of Decimal) = Nothing
        Private _ForecastedHours As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedHours As System.Nullable(Of Decimal) = Nothing
        Private _RemainingHours As System.Nullable(Of Decimal) = Nothing
        Private _EstimateAmount As System.Nullable(Of Decimal) = Nothing
        Private _ActualAmount As System.Nullable(Of Decimal) = Nothing
        Private _ForecastedAmount As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedAmount As System.Nullable(Of Decimal) = Nothing
        Private _RemainingAmount As System.Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(ByVal value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type2() As String
            Get
                Type2 = _Type2
            End Get
            Set(ByVal value As String)
                _Type2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControl() As String
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(ByVal value As String)
                _JobProcessControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimatedGrossIncome() As System.Nullable(Of Decimal)
            Get
                EstimatedGrossIncome = _EstimatedGrossIncome
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimatedGrossIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentRevenue() As System.Nullable(Of Decimal)
            Get
                CurrentRevenue = _CurrentRevenue
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _CurrentRevenue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PriorRevenue() As System.Nullable(Of Decimal)
            Get
                PriorRevenue = _PriorRevenue
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _PriorRevenue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHours() As System.Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PercentCompleteToDate() As System.Nullable(Of Decimal)
            Get
                PercentCompleteToDate = _PercentCompleteToDate
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _PercentCompleteToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Month() As System.Nullable(Of Integer)
            Get
                Month = _Month
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _Month = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateHours() As System.Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualHours() As System.Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ActualHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastedHours() As System.Nullable(Of Decimal)
            Get
                ForecastedHours = _ForecastedHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ForecastedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedHours() As System.Nullable(Of Decimal)
            Get
                ProjectedHours = _ProjectedHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RemainingHours() As System.Nullable(Of Decimal)
            Get
                RemainingHours = _RemainingHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _RemainingHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateAmount() As System.Nullable(Of Decimal)
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _EstimateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualAmount() As System.Nullable(Of Decimal)
            Get
                ActualAmount = _ActualAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ActualAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastedAmount() As System.Nullable(Of Decimal)
            Get
                ForecastedAmount = _ForecastedAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ForecastedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedAmount() As System.Nullable(Of Decimal)
            Get
                ProjectedAmount = _ProjectedAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RemainingAmount() As System.Nullable(Of Decimal)
            Get
                RemainingAmount = _RemainingAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _RemainingAmount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
