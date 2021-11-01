Namespace ProjectManagement.Classes

    <Serializable()>
    Public Class QouteVsActualInvoiceBillingSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AR_INV_NBR
            AR_INV_SEQ
            AR_TYPE
            AR_INV_DATE
            AR_POST_PERIOD
            cc_hrs_billed
            cc_net_amt_billed
            cc_markup_billed
            cc_advance_refrained
            cc_actual_billed
            cc_resale_billed
            cc_total_billed
            AttachmentCount
            Paid
            PaidAmount
        End Enum

#End Region

#Region " Variables "

        Private _AR_INV_NBR As Integer = Nothing
        Private _AR_INV_SEQ As Short = Nothing
        Private _AR_TYPE As String = Nothing
        Private _AR_INV_DATE As Date = Nothing
        Private _AR_POST_PERIOD As String = Nothing
        Private _cc_hrs_billed As Decimal = Nothing
        Private _cc_net_amt_billed As Decimal = Nothing
        Private _cc_markup_billed As Decimal = Nothing
        Private _cc_advance_refrained As Decimal = Nothing
        Private _cc_actual_billed As Decimal = Nothing
        Private _cc_resale_billed As Decimal = Nothing
        Private _cc_total_billed As Decimal = Nothing
        Private _AttachmentCount As Integer = Nothing
        Private _Paid As String = Nothing
        Private _PaidAmount As Decimal = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Invoice Number")>
        Public Property AR_INV_NBR() As Integer
            Get
                AR_INV_NBR = _AR_INV_NBR
            End Get
            Set(value As Integer)
                _AR_INV_NBR = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AR_INV_SEQ() As Short
            Get
                AR_INV_SEQ = _AR_INV_SEQ
            End Get
            Set(value As Short)
                _AR_INV_SEQ = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Invoice Type")>
        Public Property AR_TYPE() As String
            Get
                AR_TYPE = _AR_TYPE
            End Get
            Set(value As String)
                _AR_TYPE = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Invoice Date")>
        Public Property AR_INV_DATE() As Date
            Get
                AR_INV_DATE = _AR_INV_DATE
            End Get
            Set(value As Date)
                _AR_INV_DATE = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Posting Period")>
        Public Property AR_POST_PERIOD() As String
            Get
                AR_POST_PERIOD = _AR_POST_PERIOD
            End Get
            Set(value As String)
                _AR_POST_PERIOD = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Hours Billed")>
        Public Property cc_hrs_billed() As Decimal
            Get
                cc_hrs_billed = _cc_hrs_billed
            End Get
            Set(value As Decimal)
                _cc_hrs_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net Amount Billed")>
        Public Property cc_net_amt_billed() As Decimal
            Get
                cc_net_amt_billed = _cc_net_amt_billed
            End Get
            Set(value As Decimal)
                _cc_net_amt_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Markup Amount Billed")>
        Public Property cc_markup_billed() As Decimal
            Get
                cc_markup_billed = _cc_markup_billed
            End Get
            Set(value As Decimal)
                _cc_markup_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Retained Advance Amount")>
        Public Property cc_advance_refrained() As Decimal
            Get
                cc_advance_refrained = _cc_advance_refrained
            End Get
            Set(value As Decimal)
                _cc_advance_refrained = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Amount Billed")>
        Public Property cc_actual_billed() As Decimal
            Get
                cc_actual_billed = _cc_actual_billed
            End Get
            Set(value As Decimal)
                _cc_actual_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Resale Tax Billed")>
        Public Property cc_resale_billed() As Decimal
            Get
                cc_resale_billed = _cc_resale_billed
            End Get
            Set(value As Decimal)
                _cc_resale_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Billed")>
        Public Property cc_total_billed() As Decimal
            Get
                cc_total_billed = _cc_total_billed
            End Get
            Set(value As Decimal)
                _cc_total_billed = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AttachmentCount() As Integer
            Get
                AttachmentCount = _AttachmentCount
            End Get
            Set(value As Integer)
                _AttachmentCount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Has Documents")>
        Public ReadOnly Property HasDocuments() As Boolean
            Get
                HasDocuments = If(_AttachmentCount > 0, True, False)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Paid")>
        Public Property Paid() As String
            Get
                Paid = _Paid
            End Get
            Set(value As String)
                _Paid = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Paid Amount")>
        Public Property PaidAmount() As Decimal
            Get
                PaidAmount = _PaidAmount
            End Get
            Set(value As Decimal)
                _PaidAmount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace