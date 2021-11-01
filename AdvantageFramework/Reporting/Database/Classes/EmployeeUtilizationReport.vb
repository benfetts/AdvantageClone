Namespace Reporting.Database.Classes

    <Serializable>
    Public Class EmployeeUtilizationReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeOffice
            EmployeeOfficeName
            EmployeeDepartment
            EmployeeDepartmentName
            EmployeeCode
            EmployeeName
            EmployeeFirstName
            EmployeeLastName
            EmploymentDate
            SupervisorCode
            Supervisor
            EmployeeDate
            EmployeeTerminationDate
            PostPeriod
            Month
            Year
            StandardAnnualHours
            RequiredHours
            DirectHoursGoal
            BillableHoursGoal
            BillableHours
            BillableAmount
            NonBillableHours
            NonBillableAmount
            ClientHours
            ClientAmount
            AgencyHours
            AgencyAmount
            NewBusinessHours
            NewBusinessAmount
            TotalDirectHours
            TotalDirectAmount
            NonDirectHours
            TotalHours
            Variance
            PercentDirect
            PercentNonDirect
            PercentOfRequiredHours
            PercentOfDirectHoursGoal
            PercentOfBillableHoursGoal
            BilledHours
            BilledAmount
            WIPHours
            WIPAmount
            WriteUpDownAmount
            PercentBilled
            PercentBilledOfDirectHoursGoal
            PercentBilledOfBillableHoursGoal
            PercentBilledOfRequiredHours
            AverageHourlyRateBilled
            AverageHourlyRateAchieved

        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _EmployeeOffice As String = Nothing
        Private _EmployeeOfficeName As String = Nothing
        Private _EmployeeDepartment As String = Nothing
        Private _EmployeeDepartmentName As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _EmploymentDate As Nullable(Of Date) = Nothing
        Private _SupervisorCode As String = Nothing
        Private _Supervisor As String = Nothing
        Private _EmployeeDate As Nullable(Of Date) = Nothing
        Private _EmployeeTerminationDate As Nullable(Of Date) = Nothing
        Private _PostPeriod As String = Nothing
        Private _Month As String = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _StandardAnnualHours As Nullable(Of Decimal) = Nothing
        Private _RequiredHours As Nullable(Of Decimal) = Nothing
        Private _DirectHoursGoal As Nullable(Of Decimal) = Nothing
        Private _BillableHoursGoal As Nullable(Of Decimal) = Nothing
        Private _BillableHours As Nullable(Of Decimal) = Nothing
        Private _BillableAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _ClientHours As Nullable(Of Decimal) = Nothing
        Private _ClientAmount As Nullable(Of Decimal) = Nothing
        Private _AgencyHours As Nullable(Of Decimal) = Nothing
        Private _AgencyAmount As Nullable(Of Decimal) = Nothing
        Private _NewBusinessHours As Nullable(Of Decimal) = Nothing
        Private _NewBusinessAmount As Nullable(Of Decimal) = Nothing
        Private _TotalDirectHours As Nullable(Of Decimal) = Nothing
        Private _TotalDirectAmount As Nullable(Of Decimal) = Nothing
        Private _NonDirectHours As Nullable(Of Decimal) = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _Variance As Nullable(Of Decimal) = Nothing
        Private _PercentDirect As Nullable(Of Decimal) = Nothing
        Private _PercentNonDirect As Nullable(Of Decimal) = Nothing
        Private _PercentOfRequiredHours As Nullable(Of Decimal) = Nothing
        Private _PercentOfDirectHoursGoal As Nullable(Of Decimal) = Nothing
        Private _PercentOfBillableHoursGoal As Nullable(Of Decimal) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _WIPHours As Nullable(Of Decimal) = Nothing
        Private _WIPAmount As Nullable(Of Decimal) = Nothing
        Private _WriteUpDownAmount As Nullable(Of Decimal) = Nothing
        Private _PercentBilled As Nullable(Of Decimal) = Nothing
        Private _PercentBilledOfDirectHoursGoal As Nullable(Of Decimal) = Nothing
        Private _PercentBilledOfBillableHoursGoal As Nullable(Of Decimal) = Nothing
        Private _PercentBilledOfRequiredHours As Nullable(Of Decimal) = Nothing
        Private _AverageHourlyRateBilled As Nullable(Of Decimal) = Nothing
        Private _AverageHourlyRateAchieved As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of Integer))
                _ID = value
            End Set
        End Property
        Public Property EmployeeOffice() As String
            Get
                EmployeeOffice = _EmployeeOffice
            End Get
            Set(value As String)
                _EmployeeOffice = value
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
        Public Property EmployeeDepartment() As String
            Get
                EmployeeDepartment = _EmployeeDepartment
            End Get
            Set(value As String)
                _EmployeeDepartment = value
            End Set
        End Property
        Public Property EmployeeDepartmentName() As String
            Get
                EmployeeDepartmentName = _EmployeeDepartmentName
            End Get
            Set(value As String)
                _EmployeeDepartmentName = value
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
        Public Property EmployeeFirstName() As String
            Get
                EmployeeFirstName = _EmployeeFirstName
            End Get
            Set(value As String)
                _EmployeeFirstName = value
            End Set
        End Property
        Public Property EmployeeLastName() As String
            Get
                EmployeeLastName = _EmployeeLastName
            End Get
            Set(value As String)
                _EmployeeLastName = value
            End Set
        End Property
        Public Property EmploymentDate() As Nullable(Of Date)
            Get
                EmploymentDate = _EmploymentDate
            End Get
            Set(value As Nullable(Of Date))
                _EmploymentDate = value
            End Set
        End Property
        Public Property EmployeeTerminationDate() As Nullable(Of Date)
            Get
                EmployeeTerminationDate = _EmployeeTerminationDate
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeTerminationDate = value
            End Set
        End Property
        Public Property SupervisorCode() As String
            Get
                SupervisorCode = _SupervisorCode
            End Get
            Set(ByVal value As String)
                _SupervisorCode = value
            End Set
        End Property
        Public Property Supervisor() As String
            Get
                Supervisor = _Supervisor
            End Get
            Set(ByVal value As String)
                _Supervisor = value
            End Set
        End Property
        Public Property EmployeeDate() As Nullable(Of Date)
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeDate = value
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
        Public Property Month() As String
            Get
                Month = _Month
            End Get
            Set(value As String)
                _Month = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property StandardAnnualHours() As Nullable(Of Decimal)
            Get
                StandardAnnualHours = _StandardAnnualHours
            End Get
            Set
                _StandardAnnualHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property RequiredHours() As Nullable(Of Decimal)
            Get
                RequiredHours = _RequiredHours
            End Get
            Set
                _RequiredHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DirectHoursGoal() As Nullable(Of Decimal)
            Get
                DirectHoursGoal = _DirectHoursGoal
            End Get
            Set
                _DirectHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillableHoursGoal() As Nullable(Of Decimal)
            Get
                BillableHoursGoal = _BillableHoursGoal
            End Get
            Set
                _BillableHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillableHours() As Nullable(Of Decimal)
            Get
                BillableHours = _BillableHours
            End Get
            Set
                _BillableHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BillableAmount() As Nullable(Of Decimal)
            Get
                BillableAmount = _BillableAmount
            End Get
            Set
                _BillableAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableHours() As Nullable(Of Decimal)
            Get
                NonBillableHours = _NonBillableHours
            End Get
            Set
                _NonBillableHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount
            End Get
            Set
                _NonBillableAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ClientHours() As Nullable(Of Decimal)
            Get
                ClientHours = _ClientHours
            End Get
            Set
                _ClientHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ClientAmount() As Nullable(Of Decimal)
            Get
                ClientAmount = _ClientAmount
            End Get
            Set
                _ClientAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AgencyHours() As Nullable(Of Decimal)
            Get
                AgencyHours = _AgencyHours
            End Get
            Set
                _AgencyHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AgencyAmount() As Nullable(Of Decimal)
            Get
                AgencyAmount = _AgencyAmount
            End Get
            Set
                _AgencyAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NewBusinessHours() As Nullable(Of Decimal)
            Get
                NewBusinessHours = _NewBusinessHours
            End Get
            Set
                _NewBusinessHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NewBusinessAmount() As Nullable(Of Decimal)
            Get
                NewBusinessAmount = _NewBusinessAmount
            End Get
            Set
                _NewBusinessAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalDirectHours() As Nullable(Of Decimal)
            Get
                TotalDirectHours = _TotalDirectHours
            End Get
            Set
                _TotalDirectHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalDirectAmount() As Nullable(Of Decimal)
            Get
                TotalDirectAmount = _TotalDirectAmount
            End Get
            Set
                _TotalDirectAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NonDirectHours() As Nullable(Of Decimal)
            Get
                NonDirectHours = _NonDirectHours
            End Get
            Set
                _NonDirectHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalHours() As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set
                _TotalHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Variance() As Nullable(Of Decimal)
            Get
                Variance = _Variance
            End Get
            Set
                _Variance = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentDirect() As Nullable(Of Decimal)
            Get
                PercentDirect = _PercentDirect
            End Get
            Set
                _PercentDirect = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentNonDirect() As Nullable(Of Decimal)
            Get
                PercentNonDirect = _PercentNonDirect
            End Get
            Set
                _PercentNonDirect = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentOfRequiredHours() As Nullable(Of Decimal)
            Get
                PercentOfRequiredHours = _PercentOfRequiredHours
            End Get
            Set
                _PercentOfRequiredHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentOfDirectHoursGoal() As Nullable(Of Decimal)
            Get
                PercentOfDirectHoursGoal = _PercentOfDirectHoursGoal
            End Get
            Set
                _PercentOfDirectHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentOfBillableHoursGoal() As Nullable(Of Decimal)
            Get
                PercentOfBillableHoursGoal = _PercentOfBillableHoursGoal
            End Get
            Set
                _PercentOfBillableHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours
            End Get
            Set
                _BilledHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount
            End Get
            Set
                _BilledAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property WIPHours() As Nullable(Of Decimal)
            Get
                WIPHours = _WIPHours
            End Get
            Set
                _WIPHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property WIPAmount() As Nullable(Of Decimal)
            Get
                WIPAmount = _WIPAmount
            End Get
            Set
                _WIPAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property WriteUpDownAmount() As Nullable(Of Decimal)
            Get
                WriteUpDownAmount = _WriteUpDownAmount
            End Get
            Set
                _WriteUpDownAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentBilled() As Nullable(Of Decimal)
            Get
                PercentBilled = _PercentBilled
            End Get
            Set
                _PercentBilled = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentBilledOfDirectHoursGoal() As Nullable(Of Decimal)
            Get
                PercentBilledOfDirectHoursGoal = _PercentBilledOfDirectHoursGoal
            End Get
            Set
                _PercentBilledOfDirectHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentBilledOfBillableHoursGoal() As Nullable(Of Decimal)
            Get
                PercentBilledOfBillableHoursGoal = _PercentBilledOfBillableHoursGoal
            End Get
            Set
                _PercentBilledOfBillableHoursGoal = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PercentBilledOfRequiredHours() As Nullable(Of Decimal)
            Get
                PercentBilledOfRequiredHours = _PercentBilledOfRequiredHours
            End Get
            Set
                _PercentBilledOfRequiredHours = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AverageHourlyRateBilled() As Nullable(Of Decimal)
            Get
                AverageHourlyRateBilled = _AverageHourlyRateBilled
            End Get
            Set
                _AverageHourlyRateBilled = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AverageHourlyRateAchieved() As Nullable(Of Decimal)
            Get
                AverageHourlyRateAchieved = _AverageHourlyRateAchieved
            End Get
            Set
                _AverageHourlyRateAchieved = Value
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
