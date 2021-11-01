Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class VirtualCreditCardTransactionEFS

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            OrderNumber
            OrderDescription
            VendorCode
            VendorName
            LineNumber
            JobNumber
            ComponentNumber
            DateToBill
            JobMediaDateToBill
            VCCLastFour
            ExpirationDate
            CardStatus
            VendorCollected
            TotalCostPayableToVendor
            CardAmount
            TotalClearedInRange
            LastClearedDate
            Variance
            LastComment
            LastCommentDate
            CardCTS
            MerchantName
            Action
            Amount
            Reference
            ProcessedDateTime
        End Enum

#End Region

#Region " Variables "

        Private _LastClearedDate As Nullable(Of Date) = Nothing
        Private _LastCommentDate As Nullable(Of Date) = Nothing
        Private _ProcessedDateTime As Nullable(Of Date) = Nothing
        Private _TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset
            Set(value As AdvantageFramework.VCC.Classes.TimezoneOffset)
                _TimezoneOffset = value
            End Set
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As System.Guid = Nothing

        Public Property ClientCode As String = Nothing
        Public Property ClientName As String = Nothing
        Public Property DivisionCode As String = Nothing
        Public Property DivisionName As String = Nothing
        Public Property ProductCode As String = Nothing
        Public Property ProductName As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderNumber As Integer = Nothing

        Public Property OrderDescription As String = Nothing
        Public Property VendorCode As String = Nothing
        Public Property VendorName As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property LineNumber As Short = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property JobNumber As Nullable(Of Integer) = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ComponentNumber As Nullable(Of Short) = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date to Bill")>
        Public Property DateToBill As Date = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Media Date to Bill")>
        Public Property JobMediaDateToBill As Nullable(Of Date) = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CardNumber As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="VCC Last Four")>
        Public ReadOnly Property VCCLastFour As String
            Get

                If String.IsNullOrWhiteSpace(CardNumber) = False Then

                    VCCLastFour = Right(AdvantageFramework.Security.Encryption.ASCIIDecoding(CardNumber), 4)

                Else

                    VCCLastFour = Nothing

                End If

            End Get
        End Property

        Public Property ExpirationDate As Date = Nothing
        Public Property CardStatus As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property VendorCollected As Nullable(Of Decimal) = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Cost Payable to Vendor")>
        Public Property TotalCostPayableToVendor As Nullable(Of Decimal) = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CardAmount As Decimal = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Cleared in Range")>
        Public Property TotalClearedInRange As Nullable(Of Decimal) = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property LastClearedDate As Nullable(Of Date)
            Get
                LastClearedDate = If(_TimezoneOffset IsNot Nothing, AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _LastClearedDate), _LastClearedDate)
            End Get
            Set(value As Nullable(Of Date))
                _LastClearedDate = value
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Variance As Decimal
            Get
                Variance = Me.TotalCostPayableToVendor.GetValueOrDefault(0) - Me.TotalClearedInRange.GetValueOrDefault(0)
            End Get
        End Property

        Public Property LastComment As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property LastCommentDate As Nullable(Of Date)
            Get
                LastCommentDate = If(_TimezoneOffset IsNot Nothing, AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _LastCommentDate), _LastCommentDate)
            End Get
            Set(value As Nullable(Of Date))
                _LastCommentDate = value
            End Set
        End Property

        Public Property CardCTS As String = Nothing

        Public Property MerchantName As String = Nothing
        Public Property Action As String = Nothing

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount As Nullable(Of Decimal) = Nothing

        Public Property Reference As String = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="G")>
        Public Property ProcessedDateTime As Nullable(Of Date)
            Get
                ProcessedDateTime = If(_TimezoneOffset IsNot Nothing, AdvantageFramework.VCC.DisplayLocalDate(_TimezoneOffset, _ProcessedDateTime), _ProcessedDateTime)
            End Get
            Set(value As Nullable(Of Date))
                _ProcessedDateTime = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Detail As AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFSDetail, Card As AdvantageFramework.Reporting.Database.Classes.VirtualCreditCardTransactionEFS)

            If Card IsNot Nothing Then

                Me.ClientCode = Card.ClientCode
                Me.ClientName = Card.ClientName
                Me.DivisionCode = Card.DivisionCode
                Me.DivisionName = Card.DivisionName
                Me.ProductCode = Card.ProductCode
                Me.ProductName = Card.ProductName
                Me.OrderNumber = Card.OrderNumber
                Me.OrderDescription = Card.OrderDescription
                Me.VendorCode = Card.VendorCode
                Me.VendorName = Card.VendorName
                Me.LineNumber = Card.LineNumber
                Me.JobNumber = Card.JobNumber
                Me.ComponentNumber = Card.ComponentNumber
                Me.DateToBill = Card.DateToBill
                Me.JobMediaDateToBill = Card.JobMediaDateToBill
                Me.CardNumber = Card.CardNumber
                Me.ExpirationDate = Card.ExpirationDate
                Me.CardStatus = Card.CardStatus
                Me.VendorCollected = Card.VendorCollected
                Me.TotalCostPayableToVendor = Card.TotalCostPayableToVendor
                Me.CardAmount = Card.CardAmount
                Me.TotalClearedInRange = Card.TotalClearedInRange
                Me.LastClearedDate = Card.LastClearedDate
                Me.LastComment = Card.LastComment
                Me.LastCommentDate = Card.LastCommentDate
                Me.CardCTS = Card.CardCTS

            End If

            If Detail IsNot Nothing Then

                Me.CardCTS = Detail.CardCTS
                Me.MerchantName = Detail.MerchantName
                Me.Action = Detail.Action
                Me.Amount = Detail.Amount
                Me.Reference = Detail.Reference
                Me.ProcessedDateTime = Detail.ProcessedDateTime

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
