Namespace AvaTax.API

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum AddressType
            F
            ' Firm or company address
            G
            ' General Delivery address
            H
            ' High-rise or business complex
            P
            ' PO box address
            R
            ' Rural route address
            S
            ' Street or residential address
        End Enum

        Public Enum SeverityLevel
            Success
            Warning
            [Error]
            Exception
        End Enum

        Public Enum DocType
            SalesOrder
            SalesInvoice
            ReturnOrder
            ReturnInvoice
            PurchaseOrder
            PurchaseInvoice
            ReverseChargeOrder
            ReverseChargeInvoice
        End Enum

        Public Enum DetailLevel
            Tax
            Document
            Line
            Diagnostic
        End Enum

        Public Enum SystemCustomerUsageType
            L
            ' "Other",
            A
            ' "Federal government",
            B
            ' "State government",
            C
            ' "Tribe / Status Indian / Indian Band",
            D
            ' "Foreign diplomat",
            E
            ' "Charitable or benevolent organization",
            F
            ' "Regligious or educational organization",
            G
            ' "Resale",
            H
            ' "Commercial agricultural production",
            I
            ' "Industrial production / manufacturer",
            J
            ' "Direct pay permit",
            K
            ' "Direct Mail",
            N
            ' "Local Government",
            P
            ' "Commercial Aquaculture",
            Q
            ' "Commercial Fishery",
            R
            ' "Non-resident"
        End Enum

        Public Enum CancelCode
            Unspecified
            PostFailed
            DocDeleted
            DocVoided
            AdjustmentCancelled
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Module

End Namespace