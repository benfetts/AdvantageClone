Namespace Database.Classes

    <Serializable()>
    Public Class ProjectSummaryAnalysis
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ClientContactCode
            ClientContactID
            ClientContact
            AccountExecutiveCode
            AccountExecutive
            ManagerCode
            Manager
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            JobComponent
            JobQuantity
            JobTypeCode
            JobTypeDescription
            Status
            GutPercentComplete
            ClientReference
            StartDate
            EndDate
            LabelAssign1
            LabelAssign2
            LabelAssign3
            LabelAssign4
            LabelAssign5
            FunctionCOde
            FunctionDescription
            TaskStartDate
            TaskEndDate
            EmployeeCode
            EmployeeName
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
            PercentSchedule
            QuotedPercentCompleteAdjustedHours
            QuotedPercentCompleteAllHours
            ProjectedPercentCompleteAdjustedHours
            ProjectedPercentCompleteAllHours
            QuotedPercentCompleteAdjustedAmount
            QuotedPercentCompleteAllAmount
            ProjectedPercentCompleteAdjustedAmount
            ProjectedPercentCompleteAllAmount
            NumberOfWeeks
            
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ClientContactCode As String = Nothing
        Private _ClientContactID As System.Nullable(Of Integer) = Nothing
        Private _ClientContact As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ManagerCode As String = Nothing
        Private _Manager As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _JobQuantity As System.Nullable(Of Integer) = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _Status As String = Nothing
        Private _GutPercentComplete As System.Nullable(Of Decimal) = Nothing
        Private _ClientReference As String = Nothing
        Private _StartDate As System.Nullable(Of Date) = Nothing
        Private _EndDate As System.Nullable(Of Date) = Nothing
        Private _LabelAssign1 As String = Nothing
        Private _LabelAssign2 As String = Nothing
        Private _LabelAssign3 As String = Nothing
        Private _LabelAssign4 As String = Nothing
        Private _LabelAssign5 As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _TaskStartDate As System.Nullable(Of Date) = Nothing
        Private _TaskEndDate As System.Nullable(Of Date) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
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
        Private _PercentSchedule As System.Nullable(Of Decimal) = Nothing
        Private _QuotedPercentCompleteAdjustedHours As System.Nullable(Of Decimal) = Nothing
        Private _QuotedPercentCompleteAllHours As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedPercentCompleteAdjustedHours As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedPercentCompleteAllHours As System.Nullable(Of Decimal) = Nothing
        Private _QuotedPercentCompleteAdjustedAmount As System.Nullable(Of Decimal) = Nothing
        Private _QuotedPercentCompleteAllAmount As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedPercentCompleteAdjustedAmount As System.Nullable(Of Decimal) = Nothing
        Private _ProjectedPercentCompleteAllAmount As System.Nullable(Of Decimal) = Nothing
        Private _NumberOfWeeks As System.Nullable(Of Integer) = Nothing


#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(ByVal value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(ByVal value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactCode() As String
            Get
                ClientContactCode = _ClientContactCode
            End Get
            Set(ByVal value As String)
                _ClientContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ClientContactID() As System.Nullable(Of Integer)
            Get
                ClientContactID = _ClientContactID
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _ClientContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(ByVal value As String)
                _ClientContact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ManagerCode() As String
            Get
                ManagerCode = _ManagerCode
            End Get
            Set(ByVal value As String)
                _ManagerCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Manager() As String
            Get
                Manager = _Manager
            End Get
            Set(ByVal value As String)
                _Manager = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobQuantity() As System.Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(ByVal value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GutPercentComplete() As System.Nullable(Of Decimal)
            Get
                GutPercentComplete = _GutPercentComplete
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _GutPercentComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As System.Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As System.Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign1() As String
            Get
                LabelAssign1 = _LabelAssign1
            End Get
            Set(ByVal value As String)
                _LabelAssign1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign2() As String
            Get
                LabelAssign2 = _LabelAssign2
            End Get
            Set(ByVal value As String)
                _LabelAssign2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign3() As String
            Get
                LabelAssign3 = _LabelAssign3
            End Get
            Set(ByVal value As String)
                _LabelAssign3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign4() As String
            Get
                LabelAssign4 = _LabelAssign4
            End Get
            Set(ByVal value As String)
                _LabelAssign4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelAssign5() As String
            Get
                LabelAssign5 = _LabelAssign5
            End Get
            Set(ByVal value As String)
                _LabelAssign5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskStartDate() As System.Nullable(Of Date)
            Get
                TaskStartDate = _TaskStartDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _TaskStartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskEndDate() As System.Nullable(Of Date)
            Get
                TaskEndDate = _TaskEndDate
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                _TaskEndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PercentSchedule() As System.Nullable(Of Decimal)
            Get
                PercentSchedule = _PercentSchedule
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _PercentSchedule = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuotedPercentCompleteAdjustedHours() As System.Nullable(Of Decimal)
            Get
                QuotedPercentCompleteAdjustedHours = _QuotedPercentCompleteAdjustedHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QuotedPercentCompleteAdjustedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuotedPercentCompleteAllHours() As System.Nullable(Of Decimal)
            Get
                QuotedPercentCompleteAllHours = _QuotedPercentCompleteAllHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QuotedPercentCompleteAllHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedPercentCompleteAdjustedHours() As System.Nullable(Of Decimal)
            Get
                ProjectedPercentCompleteAdjustedHours = _ProjectedPercentCompleteAdjustedHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedPercentCompleteAdjustedHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedPercentCompleteAllHours() As System.Nullable(Of Decimal)
            Get
                ProjectedPercentCompleteAllHours = _ProjectedPercentCompleteAllHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedPercentCompleteAllHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuotedPercentCompleteAdjustedAmount() As System.Nullable(Of Decimal)
            Get
                QuotedPercentCompleteAdjustedAmount = _QuotedPercentCompleteAdjustedAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QuotedPercentCompleteAdjustedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuotedPercentCompleteAllAmount() As System.Nullable(Of Decimal)
            Get
                QuotedPercentCompleteAllAmount = _QuotedPercentCompleteAllAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _QuotedPercentCompleteAllAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedPercentCompleteAdjustedAmount() As System.Nullable(Of Decimal)
            Get
                ProjectedPercentCompleteAdjustedAmount = _ProjectedPercentCompleteAdjustedAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedPercentCompleteAdjustedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProjectedPercentCompleteAllAmount() As System.Nullable(Of Decimal)
            Get
                ProjectedPercentCompleteAllAmount = _ProjectedPercentCompleteAllAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ProjectedPercentCompleteAllAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NumberOfWeeks() As System.Nullable(Of Integer)
            Get
                NumberOfWeeks = _NumberOfWeeks
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _NumberOfWeeks = value
            End Set
        End Property
        
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
