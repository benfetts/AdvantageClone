Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobServiceFeeContractReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            CampaignID
            CampaignCode
            CampaignName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            SalesClassCode
            SalesClassDescription
            FeeSetupDate
            FeeStartDate
            FeeEndDate
            Frequency
            NumberOfFees
            FeeTypeDescription
            FunctionCode
            FunctionDescription
            Amount
            MaxAmount
            ContractNotes
            ClientComments
            CreatedDate
            CreatedByUserCode
            ModifiedByUserCode
            ModifiedDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _Description As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _FeeSetupDate As Nullable(Of Date) = Nothing
        Private _FeeStartDate As Nullable(Of Date) = Nothing
        Private _FeeEndDate As Nullable(Of Date) = Nothing
        Private _Frequency As String = Nothing
        Private _NumberOfFees As Nullable(Of Integer) = Nothing
        Private _FeeTypeDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _MaxAmount As Nullable(Of Decimal) = Nothing
        Private _ContractNotes As String = Nothing
        Private _ClientComments As String = Nothing
        Private _CreatedByUserCode As String = Nothing
        Private _CreatedDate As Nullable(Of Date) = Nothing
        Private _ModifiedByUserCode As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
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
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
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
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
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
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
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
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
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
		<AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
		Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
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
        Public Property FeeSetupDate() As Nullable(Of Date)
            Get
                FeeSetupDate = _FeeSetupDate
            End Get
            Set(value As Nullable(Of Date))
                _FeeSetupDate = value
            End Set
        End Property
        Public Property FeeStartDate() As Nullable(Of Date)
            Get
                FeeStartDate = _FeeStartDate
            End Get
            Set(value As Nullable(Of Date))
                _FeeStartDate = value
            End Set
        End Property
        Public Property FeeEndDate() As Nullable(Of Date)
            Get
                FeeEndDate = _FeeEndDate
            End Get
            Set(value As Nullable(Of Date))
                _FeeEndDate = value
            End Set
        End Property
        Public Property Frequency() As String
            Get
                Frequency = _Frequency
            End Get
            Set(value As String)
                _Frequency = value
            End Set
        End Property
        Public Property NumberOfFees() As Nullable(Of Integer)
            Get
                NumberOfFees = _NumberOfFees
            End Get
            Set(value As Nullable(Of Integer))
                _NumberOfFees = value
            End Set
        End Property
        Public Property FeeTypeDescription() As String
            Get
                FeeTypeDescription = _FeeTypeDescription
            End Get
            Set(value As String)
                _FeeTypeDescription = value
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
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="n2")>
        Public Property MaxAmount() As Nullable(Of Decimal)
            Get
                MaxAmount = _MaxAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _MaxAmount = value
            End Set
        End Property
        Public Property ContractNotes() As String
            Get
                ContractNotes = _ContractNotes
            End Get
            Set(value As String)
                _ContractNotes = value
            End Set
        End Property
        Public Property ClientComments() As String
            Get
                ClientComments = _ClientComments
            End Get
            Set(value As String)
                _ClientComments = value
            End Set
        End Property
        Public Property CreatedDate() As Nullable(Of Date)
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(value As Nullable(Of Date))
                _CreatedDate = value
            End Set
        End Property
        Public Property CreatedByUserCode() As String
            Get
                CreatedByUserCode = _CreatedByUserCode
            End Get
            Set(value As String)
                _CreatedByUserCode = value
            End Set
        End Property
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        Public Property ModifiedByUserCode() As String
            Get
                ModifiedByUserCode = _ModifiedByUserCode
            End Get
            Set(value As String)
                _ModifiedByUserCode = value
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
