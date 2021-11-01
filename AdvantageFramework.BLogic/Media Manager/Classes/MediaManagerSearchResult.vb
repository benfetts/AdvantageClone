Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerSearchResult

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsSelected
            MediaFrom
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CampaignID
            CampaignCode
            CampaignName
            VendorCode
            VendorName
            OrderNumber
            OrderDescription
            LineNumber
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            EmployeeCode
            AccountExecutive
            OrderStatus
            OrderStatusDescription
            VCCCardNumber
            VCCLastFour
            Buyer
            DisplayPONumber
        End Enum

#End Region

#Region " Variables "

        Private _IsSelected As Boolean = False
        Private _MediaFrom As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _OrderStatus As Nullable(Of Short) = Nothing
        Private _OrderStatusDescription As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VCCCardNumber As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSelected() As Boolean
            Get
                IsSelected = _IsSelected
            End Get
            Set(value As Boolean)
                _IsSelected = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Type")>
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OrderStatus() As Nullable(Of Short)
            Get
                OrderStatus = _OrderStatus
            End Get
            Set(value As Nullable(Of Short))
                _OrderStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderStatusDescription() As String
            Get
                OrderStatusDescription = _OrderStatusDescription
            End Get
            Set(value As String)
                _OrderStatusDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VCCCardNumber() As String
            Get
                VCCCardNumber = _VCCCardNumber
            End Get
            Set(value As String)
                _VCCCardNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="VCC Last Four")>
        Public ReadOnly Property VCCLastFour() As String
            Get
                VCCLastFour = If(String.IsNullOrWhiteSpace(_VCCCardNumber), Nothing, Right(AdvantageFramework.Security.Encryption.ASCIIDecoding(_VCCCardNumber), 4))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Buyer() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DisplayPONumber() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace