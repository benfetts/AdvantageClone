Namespace MediaManager.Classes

    <Serializable()>
    Public Class InternetOrderReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            LocationHeader
            LocationFooter
            PageHeaderLogoPath
            OrderLabel
            PrintDate
            VendorCode
            VendorName
            ClientName
            DivisionName
            ProductionDescription
            CampaignName
            MarketName
            OrderNumber
            LineNumber
            RevisionNumber
            Buyer
            OrderDescription
            OrderDate
            Projected
            Actual
            Headline1
            URL
            CopyArea
            Placement
            Package
            Target
            AdNumber
            AgencyJob
            'MaterialDue
            'SpaceClose
            OrderCopy
            MaterialNotes
            MiscInfo
            OrderComment
            'RevisedCancelled
            'InsertDate
            'EndDate
            'Size
            MaterialCloseDate
            'Amount
            CostType
            NetGross
            'RateType
            MaterialDueFlag
            HeadlineFlag
            VendorTax
            'LineTotalActual
            AgencyComment
            DiscountAmount
            DiscountDescription
            CommissionActual
            'SubTypeDescription
            'Impressions
            'BillTypeFlag
            ShippingAddressFlag
            IncludeRep1
            RepLabel1
            IncludeRep2
            RepLabel2
            DefaultRep1Label
            DefaultRep2Label
            LocationID
            'ChargeTo
            VendorRepCode1
            VendorRepCode2
            NetCharge
            NetChargeDescription
            ExcludeEmployeeSignature
            AgencyCommentFontSize
            OrderHeaderCommentOption
            BuyerEmployeeCode
            LineMarketCode
            LineMarketDescription
            Instructions
            ClientAddress1
            ClientAddress2
            ClientCSZ
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationHeader As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationFooter As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLabel As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDate As Nullable(Of Date) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductionDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber As Integer = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property LineNumber As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property RevisionNumber As Short = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDate As Nullable(Of Date) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Projected As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Actual As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Headline1 As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property CopyArea As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Placement As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Target As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property AdNumber As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property AgencyJob As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property MaterialDue As Nullable(Of Date) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property SpaceClose As Nullable(Of Date) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Instructions As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property OrderCopy As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property MaterialNotes As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property MiscInfo As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderComment As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property RevisedCancelled As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property InsertDate As Nullable(Of Date) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EndDate As Nullable(Of Date) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Size As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Amount As Nullable(Of Decimal) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property CostType As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetGross As Nullable(Of Short) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property RateType As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property MaterialDueFlag As Nullable(Of Short) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property HeadlineFlag As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorTax As Nullable(Of Decimal) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property LineTotalActual As Nullable(Of Decimal) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AgencyComment As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DiscountAmount As Nullable(Of Decimal) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DiscountDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CommissionActual As Nullable(Of Decimal) = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property SubTypeDescription As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Impressions As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property BillTypeFlag As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShippingAddressFlag As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeRep1 As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RepLabel1 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeRep2 As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RepLabel2 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultRep1Label As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultRep2Label As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationID As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property ChargeTo As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode1 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode2 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetCharge As Nullable(Of Decimal) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetChargeDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExcludeEmployeeSignature As Boolean = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AgencyCommentFontSize As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderHeaderCommentOption As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BuyerEmployeeCode As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Target] As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineMarketCode As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Dimensions] As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [CostStructure] As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Package] As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [URL] As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Units] As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [StartDate] As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [EndDate] As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Cost] As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Instructions As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineMarketDescription As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [TargetGroup] As Guid
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientAddress1 As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientAddress2 As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCity As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientState As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientZip As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property ClientCSZ As String
            Get
                If Trim(Me.ClientCity & ", " & Me.ClientState & Space(2) & Me.ClientZip & "") = "," Then
                    ClientCSZ = Nothing
                Else
                    ClientCSZ = Me.ClientCity & ", " & Me.ClientState & Space(2) & Me.ClientZip & ""
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
