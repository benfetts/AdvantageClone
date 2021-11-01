Namespace Reporting.Database.Classes

    <Serializable>
    Public Class EmployeeTimeForecastData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeTimeForecastID
            EmployeeTimeForecastDescription
            EmployeeTimeForecastComment
            RevisionNumber
            OfficeCode
            OfficeName
            PostPeriod
            CreatedBy
            ModifiedBy
            ApprovedBy
            AssignedEmployee
            EmployeeTitle
            EmployeeCode
            EmployeeName
            EmployeeOfficeName
            'ClientCode
            'ClientDescription
            'DivisionCode
            'DivisionDescription
            'ProductCode
            'ProductDescription
            ForecastedDirectHours
            ForecastedAgencyHours
            ForecastedNewBusinessHours
            TotalForecastedDirectHours
            BillRate
            'CostRate
            TotalForecastedRevenue
            TotalForecastedIndirectHours
            TotalForecastedHours
            TotalAvailableHours
            DirectHoursGoalByEmployee
            BillableHoursGoalByEmployee
            AvailableToForecastedVariance
            'Hours
            'RevenueAmount

        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _EmployeeTimeForecastID As Nullable(Of Integer) = Nothing
        Private _EmployeeTimeForecastDescription As String = Nothing
        Private _EmployeeTimeForecastComment As String = Nothing
        Private _RevisionNumber As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _PostPeriod As String = Nothing
        Private _CreatedBy As String = Nothing
        Private _ModifiedBy As String = Nothing
        Private _ApprovedBy As String = Nothing
        Private _AssignedEmployee As String = Nothing

        Private _EmployeeTitle As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeOfficeName As String = Nothing
        'Private _ClientCode As String = Nothing
        'Private _ClientDescription As String = Nothing
        'Private _DivisionCode As String = Nothing
        'Private _DivisionDescription As String = Nothing
        'Private _ProductCode As String = Nothing
        'Private _ProductDescription As String = Nothing

        Private _ForecastedDirectHours As Nullable(Of Decimal) = Nothing
        Private _ForecastedAgencyHours As Nullable(Of Decimal) = Nothing
        Private _ForecastedNewBusinessHours As Nullable(Of Decimal) = Nothing
        Private _TotalForecastedDirectHours As Nullable(Of Decimal) = Nothing
        Private _BillRate As Nullable(Of Decimal) = Nothing
        'Private _CostRate As Nullable(Of Decimal) = Nothing
        Private _TotalForecastedRevenue As Nullable(Of Decimal) = Nothing
        Private _TotalForecastedIndirectHours As Nullable(Of Decimal) = Nothing

        Private _TotalForecastedHours As Nullable(Of Decimal) = Nothing
        Private _TotalAvailableHours As Nullable(Of Decimal) = Nothing
        Private _DirectHoursGoalByEmployee As Nullable(Of Decimal) = Nothing
        Private _BillableHoursGoalByEmployee As Nullable(Of Decimal) = Nothing
        Private _AvailableToForecastedVariance As Nullable(Of Decimal) = Nothing
        'Private _Hours As Nullable(Of Decimal) = Nothing
        'Private _RevenueAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        Public Property EmployeeTimeForecastID() As Integer
            Get
                EmployeeTimeForecastID = _EmployeeTimeForecastID
            End Get
            Set(value As Integer)
                _EmployeeTimeForecastID = value
            End Set
        End Property
        Public Property EmployeeTimeForecastDescription() As String
            Get
                EmployeeTimeForecastDescription = _EmployeeTimeForecastDescription
            End Get
            Set(value As String)
                _EmployeeTimeForecastDescription = value
            End Set
        End Property
        Public Property EmployeeTimeForecastComment() As String
            Get
                EmployeeTimeForecastComment = _EmployeeTimeForecastComment
            End Get
            Set(value As String)
                _EmployeeTimeForecastComment = value
            End Set
        End Property
        Public Property RevisionNumber() As Nullable(Of Integer)
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Nullable(Of Integer))
                _RevisionNumber = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        Public Property PostPeriod() As String
            Get
                PostPeriod = _PostPeriod
            End Get
            Set(value As String)
                _PostPeriod = value
            End Set
        End Property
        Public Property CreatedBy() As String
            Get
                CreatedBy = _CreatedBy
            End Get
            Set(value As String)
                _CreatedBy = value
            End Set
        End Property
        Public Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
            Set(value As String)
                _ModifiedBy = value
            End Set
        End Property
        Public Property ApprovedBy() As String
            Get
                ApprovedBy = _ApprovedBy
            End Get
            Set(value As String)
                _ApprovedBy = value
            End Set
        End Property
        Public Property AssignedEmployee() As String
            Get
                AssignedEmployee = _AssignedEmployee
            End Get
            Set(ByVal value As String)
                _AssignedEmployee = value
            End Set
        End Property
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(value As String)
                _EmployeeTitle = value
            End Set
        End Property
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        Public Property EmployeeOfficeName() As String
            Get
                EmployeeOfficeName = _EmployeeOfficeName
            End Get
            Set(value As String)
                _EmployeeOfficeName = value
            End Set
        End Property

        'Public Property ClientCode() As String
        '    Get
        '        ClientCode = _ClientCode
        '    End Get
        '    Set(ByVal value As String)
        '        _ClientCode = value
        '    End Set
        'End Property
        'Public Property ClientDescription() As String
        '    Get
        '        ClientDescription = _ClientDescription
        '    End Get
        '    Set(value As String)
        '        _ClientDescription = value
        '    End Set
        'End Property
        'Public Property DivisionCode() As String
        '    Get
        '        DivisionCode = _DivisionCode
        '    End Get
        '    Set(value As String)
        '        _DivisionCode = value
        '    End Set
        'End Property
        'Public Property DivisionDescription() As String
        '    Get
        '        DivisionDescription = _DivisionDescription
        '    End Get
        '    Set(value As String)
        '        _DivisionDescription = value
        '    End Set
        'End Property
        'Public Property ProductCode() As String
        '    Get
        '        ProductCode = _ProductCode
        '    End Get
        '    Set(value As String)
        '        _ProductCode = value
        '    End Set
        'End Property
        'Public Property ProductDescription() As String
        '    Get
        '        ProductDescription = _ProductDescription
        '    End Get
        '    Set(value As String)
        '        _ProductDescription = value
        '    End Set
        'End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ForecastedDirectHours() As Nullable(Of Decimal)
            Get
                ForecastedDirectHours = _ForecastedDirectHours
            End Get
            Set
                _ForecastedDirectHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ForecastedAgencyHours() As Nullable(Of Decimal)
            Get
                ForecastedAgencyHours = _ForecastedAgencyHours
            End Get
            Set
                _ForecastedAgencyHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ForecastedNewBusinessHours() As Nullable(Of Decimal)
            Get
                ForecastedNewBusinessHours = _ForecastedNewBusinessHours
            End Get
            Set
                _ForecastedNewBusinessHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalForecastedDirectHours() As Nullable(Of Decimal)
            Get
                TotalForecastedDirectHours = _TotalForecastedDirectHours
            End Get
            Set
                _TotalForecastedDirectHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property BillRate() As Nullable(Of Decimal)
            Get
                BillRate = _BillRate
            End Get
            Set
                _BillRate = Value
            End Set
        End Property

        '<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        'Public Property CostRate() As Nullable(Of Decimal)
        '    Get
        '        CostRate = _CostRate
        '    End Get
        '    Set
        '        _CostRate = Value
        '    End Set
        'End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property TotalForecastedRevenue() As Nullable(Of Decimal)
            Get
                TotalForecastedRevenue = _TotalForecastedRevenue
            End Get
            Set
                _TotalForecastedRevenue = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalForecastedIndirectHours() As Nullable(Of Decimal)
            Get
                TotalForecastedIndirectHours = _TotalForecastedIndirectHours
            End Get
            Set
                _TotalForecastedIndirectHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalForecastedHours() As Nullable(Of Decimal)
            Get
                TotalForecastedHours = _TotalForecastedHours
            End Get
            Set
                _TotalForecastedHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalAvailableHours() As Nullable(Of Decimal)
            Get
                TotalAvailableHours = _TotalAvailableHours
            End Get
            Set
                _TotalAvailableHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DirectHoursGoalByEmployee() As Nullable(Of Decimal)
            Get
                DirectHoursGoalByEmployee = _DirectHoursGoalByEmployee
            End Get
            Set
                _DirectHoursGoalByEmployee = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillableHoursGoalByEmployee() As Nullable(Of Decimal)
            Get
                BillableHoursGoalByEmployee = _BillableHoursGoalByEmployee
            End Get
            Set
                _BillableHoursGoalByEmployee = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvailableToForecastedVariance() As Nullable(Of Decimal)
            Get
                AvailableToForecastedVariance = _AvailableToForecastedVariance
            End Get
            Set
                _AvailableToForecastedVariance = Value
            End Set
        End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        'Public Property Hours() As Nullable(Of Decimal)
        '    Get
        '        Hours = _Hours
        '    End Get
        '    Set
        '        _Hours = Value
        '    End Set
        'End Property
        '<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        'Public Property RevenueAmount() As Nullable(Of Decimal)
        '    Get
        '        RevenueAmount = _RevenueAmount
        '    End Get
        '    Set
        '        _RevenueAmount = Value
        '    End Set
        'End Property


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
