Namespace EmployeeTimeForecast.Classes

    <Serializable()>
    Public Class EmployeeTimeForecastDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            Employee
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OfficeCode
            OfficeName
            DepartmentCode
            DepartmentName
            JobAndJobComponent
            SalesClass
            AccountExecutive
            ActualHours
            ForecastedHours
            VarianceHours
            ActualAmount
            ForecastedAmount
            VarianceAmount
            IsAlternateEmployee
            AlternateEmployeeID
            Month
            MonthNumber
            Year
            ClientHours
            AgencyHours
            NewBusinessHours
            IndirectHours
            DirectPercent
            ClientPercent
            NewBusinessPercent
            AgencyPercent
            IndirectPercent
            RequiredHours
            DirectHoursGoal
            TotalHours
            Variance
            RequiredPercent
            BillableHours
            BillablePercent
            ActualHoursCurrent
            ClientHoursCurrent
            DirectPercentCurrent
            ClientPercentCurrent
            FTECurrent
            FTETotal

        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _DepartmentCode As String = Nothing
        Private _DepartmentName As String = Nothing
        Private _JobAndJobComponent As String = Nothing
        Private _SalesClass As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ActualHours As Nullable(Of Decimal) = Nothing
        Private _ForecastedHours As Nullable(Of Decimal) = Nothing
        Private _VarianceHours As Nullable(Of Decimal) = Nothing
        Private _ActualAmount As Nullable(Of Decimal) = Nothing
        Private _ForecastedAmount As Nullable(Of Decimal) = Nothing
        Private _VarianceAmount As Nullable(Of Decimal) = Nothing
        Private _IsAlternateEmployee As Boolean = Nothing
        Private _AlternateEmployeeID As Nullable(Of Integer) = Nothing
        Private _Month As String = Nothing
        Private _MonthNumber As Nullable(Of Short) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _ClientHours As Nullable(Of Decimal) = Nothing
        Private _AgencyHours As Nullable(Of Decimal) = Nothing
        Private _NewBusinessHours As Nullable(Of Decimal) = Nothing
        Private _IndirectHours As Nullable(Of Decimal) = Nothing
        Private _DirectPercent As Nullable(Of Decimal) = Nothing
        Private _ClientPercent As Nullable(Of Decimal) = Nothing
        Private _NewBusinessPercent As Nullable(Of Decimal) = Nothing
        Private _AgencyPercent As Nullable(Of Decimal) = Nothing
        Private _IndirectPercent As Nullable(Of Decimal) = Nothing
        Private _RequiredHours As Nullable(Of Decimal) = Nothing
        Private _DirectHoursGoal As Nullable(Of Decimal) = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _Variance As Nullable(Of Decimal) = Nothing
        Private _RequiredPercent As Nullable(Of Decimal) = Nothing
        Private _BillableHours As Nullable(Of Decimal) = Nothing
        Private _BillablePercent As Nullable(Of Decimal) = Nothing
        Private _ActualHoursCurrent As Nullable(Of Decimal) = Nothing
        Private _ClientHoursCurrent As Nullable(Of Decimal) = Nothing
        Private _DirectPercentCurrent As Nullable(Of Decimal) = Nothing
        Private _ClientPercentCurrent As Nullable(Of Decimal) = Nothing
        Private _FTECurrent As Nullable(Of Decimal) = Nothing
        Private _FTETotal As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(value As String)
                _Employee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(value As String)
                _DepartmentCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property DepartmentName() As String
            Get
                DepartmentName = _DepartmentName
            End Get
            Set(value As String)
                _DepartmentName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property JobAndJobComponent() As String
            Get
                JobAndJobComponent = _JobAndJobComponent
            End Get
            Set(value As String)
                _JobAndJobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property SalesClass() As String
            Get
                SalesClass = _SalesClass
            End Get
            Set(value As String)
                _SalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualHours() As Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastedHours() As Nullable(Of Decimal)
            Get
                ForecastedHours = _ForecastedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastedHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VarianceHours() As Nullable(Of Decimal)
            Get
                VarianceHours = _VarianceHours
            End Get
            Set(value As Nullable(Of Decimal))
                _VarianceHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActualAmount() As Nullable(Of Decimal)
            Get
                ActualAmount = _ActualAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ForecastedAmount() As Nullable(Of Decimal)
            Get
                ForecastedAmount = _ForecastedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VarianceAmount() As Nullable(Of Decimal)
            Get
                VarianceAmount = _VarianceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VarianceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsAlternateEmployee() As Boolean
            Get
                IsAlternateEmployee = _IsAlternateEmployee
            End Get
            Set(value As Boolean)
                _IsAlternateEmployee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateEmployeeID() As Nullable(Of Integer)
            Get
                AlternateEmployeeID = _AlternateEmployeeID
            End Get
            Set(value As Nullable(Of Integer))
                _AlternateEmployeeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Month() As String
            Get
                Month = _Month
            End Get
            Set(value As String)
                _Month = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthNumber() As Nullable(Of Short)
            Get
                MonthNumber = _MonthNumber
            End Get
            Set(value As Nullable(Of Short))
                _MonthNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientHours() As Nullable(Of Decimal)
            Get
                ClientHours = _ClientHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ClientHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AgencyHours() As Nullable(Of Decimal)
            Get
                AgencyHours = _AgencyHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AgencyHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewBusinessHours() As Nullable(Of Decimal)
            Get
                NewBusinessHours = _NewBusinessHours
            End Get
            Set(value As Nullable(Of Decimal))
                _NewBusinessHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndirectHours() As Nullable(Of Decimal)
            Get
                IndirectHours = _IndirectHours
            End Get
            Set(value As Nullable(Of Decimal))
                _IndirectHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectPercent() As Nullable(Of Decimal)
            Get
                DirectPercent = _DirectPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientPercent() As Nullable(Of Decimal)
            Get
                ClientPercent = _ClientPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _ClientPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NewBusinessPercent() As Nullable(Of Decimal)
            Get
                NewBusinessPercent = _NewBusinessPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _NewBusinessPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AgencyPercent() As Nullable(Of Decimal)
            Get
                AgencyPercent = _AgencyPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _AgencyPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property IndirectPercent() As Nullable(Of Decimal)
            Get
                IndirectPercent = _IndirectPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _IndirectPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property RequiredHours() As Nullable(Of Decimal)
            Get
                RequiredHours = _RequiredHours
            End Get
            Set(value As Nullable(Of Decimal))
                _RequiredHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectHoursGoal() As Nullable(Of Decimal)
            Get
                DirectHoursGoal = _DirectHoursGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectHoursGoal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalHours() As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Variance() As Nullable(Of Decimal)
            Get
                Variance = _Variance
            End Get
            Set(value As Nullable(Of Decimal))
                _Variance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property RequiredPercent() As Nullable(Of Decimal)
            Get
                RequiredPercent = _RequiredPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _RequiredPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillableHours() As Nullable(Of Decimal)
            Get
                BillableHours = _BillableHours
            End Get
            Set(value As Nullable(Of Decimal))
                _BillableHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillablePercent() As Nullable(Of Decimal)
            Get
                BillablePercent = _BillablePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _BillablePercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualHoursCurrent() As Nullable(Of Decimal)
            Get
                ActualHoursCurrent = _ActualHoursCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualHoursCurrent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientHoursCurrent() As Nullable(Of Decimal)
            Get
                ClientHoursCurrent = _ClientHoursCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _ClientHoursCurrent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectPercentCurrent() As Nullable(Of Decimal)
            Get
                DirectPercentCurrent = _DirectPercentCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectPercentCurrent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientPercentCurrent() As Nullable(Of Decimal)
            Get
                ClientPercentCurrent = _ClientPercentCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _ClientPercentCurrent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FTECurrent() As Nullable(Of Decimal)
            Get
                FTECurrent = _FTECurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _FTECurrent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FTETotal() As Nullable(Of Decimal)
            Get
                FTETotal = _FTETotal
            End Get
            Set(value As Nullable(Of Decimal))
                _FTETotal = value
            End Set
        End Property

#End Region


#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode.ToString

        End Function

#End Region

    End Class

End Namespace
