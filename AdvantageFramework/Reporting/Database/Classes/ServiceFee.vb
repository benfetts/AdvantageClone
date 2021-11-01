Namespace Reporting.Database.Classes

    <Serializable>
    Public Class ServiceFee

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            SalesClassCode
            SalesClassDescription
            JobNumber
            JobDescription
            ComponentNumber
            JobComponent
            ComponentDescription
            FunctionCode
            FunctionDescription
            FunctionType
            ServiceFeeTypeCode
            ServiceFeeTypeDescription
            FunctionHeading
            FunctionConsolidation
            EmployeeCode
            EmployeeName
            FeeTimeType
            FeeDate
            Description
            Comment
            PostPeriodCode
            FeeQuantity
            FeeAmount
            ReconciledHours
            ReconciledAmount
            UnreconciledHours
            UnreconciledAmount
            Hours
            Amount
            VarianceHours
            VarianceAmount
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponent As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _ServiceFeeTypeCode As String = Nothing
        Private _ServiceFeeTypeDescription As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionConsolidation As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _FeeTimeType As String = Nothing
        Private _FeeDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _Comment As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _FeeQuantity As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _ReconciledHours As Nullable(Of Decimal) = Nothing
        Private _ReconciledAmount As Nullable(Of Decimal) = Nothing
        Private _UnreconciledHours As Nullable(Of Decimal) = Nothing
        Private _UnreconciledAmount As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _VarianceHours As Nullable(Of Decimal) = Nothing
        Private _VarianceAmount As Nullable(Of Decimal) = Nothing

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
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ComponentNumber = value
            End Set
        End Property
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(value As String)
                _JobComponent = value
            End Set
        End Property
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        Public Property ServiceFeeTypeCode() As String
            Get
                ServiceFeeTypeCode = _ServiceFeeTypeCode
            End Get
            Set(value As String)
                _ServiceFeeTypeCode = value
            End Set
        End Property
        Public Property ServiceFeeTypeDescription() As String
            Get
                ServiceFeeTypeDescription = _ServiceFeeTypeDescription
            End Get
            Set(value As String)
                _ServiceFeeTypeDescription = value
            End Set
        End Property
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(value As String)
                _FunctionHeading = value
            End Set
        End Property
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(value As String)
                _FunctionConsolidation = value
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
        Public Property FeeTimeType() As String
            Get
                FeeTimeType = _FeeTimeType
            End Get
            Set(value As String)
                _FeeTimeType = value
            End Set
        End Property
        Public Property FeeDate() As Nullable(Of Date)
            Get
                FeeDate = _FeeDate
            End Get
            Set(value As Nullable(Of Date))
                _FeeDate = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        Public Property FeeQuantity() As Nullable(Of Decimal)
            Get
                FeeQuantity = _FeeQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeQuantity = value
            End Set
        End Property
        Public Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReconciledHours() As Nullable(Of Decimal)
            Get
                ReconciledHours = _ReconciledHours
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconciledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReconciledAmount() As Nullable(Of Decimal)
            Get
                ReconciledAmount = _ReconciledAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ReconciledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UnreconciledHours() As Nullable(Of Decimal)
            Get
                UnreconciledHours = _UnreconciledHours
            End Get
            Set(value As Nullable(Of Decimal))
                _UnreconciledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UnreconciledAmount() As Nullable(Of Decimal)
            Get
                UnreconciledAmount = _UnreconciledAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _UnreconciledAmount = value
            End Set
        End Property
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        Public Property VarianceHours() As Nullable(Of Decimal)
            Get
                VarianceHours = _VarianceHours
            End Get
            Set(value As Nullable(Of Decimal))
                _VarianceHours = value
            End Set
        End Property
        Public Property VarianceAmount() As Nullable(Of Decimal)
            Get
                VarianceAmount = _VarianceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _VarianceAmount = value
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
