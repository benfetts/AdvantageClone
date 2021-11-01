Namespace MediaManager.Classes

    <Serializable()>
    Public Class ApproveInvoice
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            ClientCode
            DivisionCode
            ProductCode
            Vendor
            MonthYear
            OrderNumber
            LineNumber
            InvoiceNumber
            InvoiceDate
            OrderQtySpots
            GrossOrderAmount
            NetOrderAmount
            InvoiceQtySpots
            Unmatched
            APGrossAmount
            APNetAmount
            GrossBalance
            NetBalance
            QtySpotVariance
            LineCancelled
            ApprovalStatus
            ApprovalNotes
            AccountPayableID
            InvoiceDetailMatching
            MonthNumber
            YearNumber
        End Enum

#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _ApprovalStatus As Nullable(Of Short) = Nothing
        Private _ApprovalNotes As String = Nothing
        Private _AccountPayableID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Code")>
        Public Property DivisionCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Code")>
        Public Property ProductCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Vendor() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MonthYear() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice" & vbCrLf & "Number")>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Invoice" & vbCrLf & "Date")>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Gross Order" & vbCrLf & "Rate", DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        'Public Property OrderGrossRate() As Decimal?
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Net Order" & vbCrLf & "Rate", DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        'Public Property OrderNetRate() As Decimal?
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Qty/Spots", DisplayFormat:="n0")>
        Public Property OrderQtySpots() As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Gross Order" & vbCrLf & "Amount")>
        Public Property GrossOrderAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Net Order" & vbCrLf & "Amount")>
        Public Property NetOrderAmount() As Decimal
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Net Invoice" & vbCrLf & "Rate")>
        'Public Property NetInvoiceRate() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n0", CustomColumnCaption:="Invoice" & vbCrLf & "Qty/Spots")>
        Public Property InvoiceQtySpots() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n0", CustomColumnCaption:="Unmatched")>
        Public Property Unmatched() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Gross Invoice" & vbCrLf & "Amount")>
        Public Property APGrossAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2", CustomColumnCaption:="Net Invoice" & vbCrLf & "Amount")>
        Public Property APNetAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross" & vbCrLf & "Balance")>
        Public ReadOnly Property GrossBalance() As Decimal
            Get
                GrossBalance = Me.GrossOrderAmount - Me.APGrossAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Net" & vbCrLf & "Balance")>
        Public ReadOnly Property NetBalance() As Decimal
            Get
                NetBalance = Me.NetOrderAmount - Me.APNetAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0", CustomColumnCaption:="Qty/Spot" & vbCrLf & "Variance")>
        Public ReadOnly Property QtySpotVariance() As Integer
            Get
                QtySpotVariance = (Me.InvoiceQtySpots.GetValueOrDefault(0) + Me.Unmatched.GetValueOrDefault(0)) - Me.OrderQtySpots
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line" & vbCrLf & "Cancelled")>
        Public Property LineCancelled() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalStatus() As Nullable(Of Short)
            Get
                ApprovalStatus = _ApprovalStatus
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ApprovalStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property ApprovalNotes() As String
            Get
                ApprovalNotes = _ApprovalNotes
            End Get
            Set(ByVal value As String)
                _ApprovalNotes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceDetailMatching() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DoesNotHaveAP() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MonthNumber As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property YearNumber As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ApproveInvoice As AdvantageFramework.MediaManager.Classes.ApproveInvoice, LineNumber As Short, MonthNumber As Short?, YearNumber As Short?)

            Me.MediaType = ApproveInvoice.MediaType
            Me.ClientCode = ApproveInvoice.ClientCode
            Me.DivisionCode = ApproveInvoice.DivisionCode
            Me.ProductCode = ApproveInvoice.ProductCode
            Me.Vendor = ApproveInvoice.Vendor
            Me.OrderNumber = ApproveInvoice.OrderNumber
            Me.LineNumber = LineNumber
            Me.InvoiceNumber = ApproveInvoice.InvoiceNumber
            Me.InvoiceDate = ApproveInvoice.InvoiceDate
            Me.OrderQtySpots = ApproveInvoice.OrderQtySpots
            Me.GrossOrderAmount = ApproveInvoice.GrossOrderAmount
            Me.NetOrderAmount = ApproveInvoice.NetOrderAmount
            Me.InvoiceQtySpots = 0
            Me.APGrossAmount = 0
            Me.APNetAmount = 0

            Me.LineCancelled = False
            Me.ApprovalStatus = Nothing
            Me.ApprovalNotes = Nothing
            Me.AccountPayableID = ApproveInvoice.AccountPayableID
            Me.InvoiceDetailMatching = Nothing

            Me.DoesNotHaveAP = True

            Me.MonthNumber = MonthNumber
            Me.YearNumber = YearNumber

            If Me.MonthNumber.HasValue AndAlso Me.YearNumber.HasValue Then

                Me.MonthYear = MonthName(Me.MonthNumber.Value, True).ToUpper & Space(1) & Me.YearNumber.Value.ToString

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                'Case AdvantageFramework.MediaManager.Classes.approveinvoices.Properties.CloseDate.ToString

                '    PropertyValue = Value

                '    If PropertyValue IsNot Nothing AndAlso _StartDate.HasValue Then

                '        If PropertyValue > _StartDate.Value Then

                '            IsValid = False

                '            ErrorText = "Close date must be before or the same as start date."

                '        End If

                '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

    Public Class UserApproveInvoices
        Public Property UserCode As String
        Public Property ApproveInvoice As AdvantageFramework.MediaManager.Classes.ApproveInvoice
    End Class

End Namespace
