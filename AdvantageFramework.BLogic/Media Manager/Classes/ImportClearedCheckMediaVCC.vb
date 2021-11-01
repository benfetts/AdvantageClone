Namespace MediaManager.Classes

    <Serializable()>
    Public Class ImportClearedCheckMediaVCC
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BankCode
            BankReference
            OrderLine
            CheckNumber
            CheckVoid
            PreviouslyCleared
            TotalCheckAmount
            TotalBankAmount
            TotalVariance
            DetailAmount
            BankAmount
            Variance
            VendorName
            MerchantName
            ClearedDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _BankReference As String = Nothing
        Private _BankCode As String = Nothing
        Private _OrderLine As String = Nothing
        Private _CheckNumber As Nullable(Of Integer) = Nothing
        Private _CheckVoid As Boolean = False
        Private _PreviouslyCleared As Boolean = False
        Private _TotalCheckAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBankAmount As Decimal = Nothing
        Private _DetailAmount As Decimal = Nothing
        Private _BankAmount As Decimal = Nothing
        Private _VendorName As String = Nothing
        Private _MerchantName As String = Nothing
        Private _ClearedDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Bank" & vbCrLf & "Code")>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(value As String)
                _BankCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Bank" & vbCrLf & "Reference")>
        Public Property BankReference() As String
            Get
                BankReference = _BankReference
            End Get
            Set(value As String)
                _BankReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Order/" & vbCrLf & "Line")>
        Public Property OrderLine() As String
            Get
                OrderLine = _OrderLine
            End Get
            Set(value As String)
                _OrderLine = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Check" & vbCrLf & "Number")>
        Public Property CheckNumber() As Nullable(Of Integer)
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(value As Nullable(Of Integer))
                _CheckNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Check" & vbCrLf & "Void")>
        Public Property CheckVoid() As Boolean
            Get
                CheckVoid = _CheckVoid
            End Get
            Set(value As Boolean)
                _CheckVoid = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Previously" & vbCrLf & "Cleared")>
        Public Property PreviouslyCleared() As Boolean
            Get
                PreviouslyCleared = _PreviouslyCleared
            End Get
            Set(value As Boolean)
                _PreviouslyCleared = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Total Check" & vbCrLf & "Amount")>
        Public Property TotalCheckAmount() As Nullable(Of Decimal)
            Get
                TotalCheckAmount = _TotalCheckAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalCheckAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Total Bank" & vbCrLf & "Amount")>
        Public Property TotalBankAmount() As Decimal
            Get
                TotalBankAmount = _TotalBankAmount
            End Get
            Set(value As Decimal)
                _TotalBankAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Total" & vbCrLf & "Variance")>
        Public ReadOnly Property TotalVariance() As Decimal
            Get
                TotalVariance = Me.TotalCheckAmount.GetValueOrDefault(0) - Me.TotalBankAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order/Line" & vbCrLf & "Amount", IsReadOnlyColumn:=True)>
        Public Property DetailAmount() As Decimal
            Get
                DetailAmount = _DetailAmount
            End Get
            Set(value As Decimal)
                _DetailAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Bank Detail" & vbCrLf & "Amount")>
        Public Property BankAmount() As Decimal
            Get
                BankAmount = _BankAmount
            End Get
            Set(value As Decimal)
                _BankAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Detail" & vbCrLf & "Variance")>
        Public ReadOnly Property Variance() As Decimal
            Get
                Variance = Me.BankAmount - Me.DetailAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Check" & vbCrLf & "Vendor Name")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Bank" & vbCrLf & "Merchant Name")>
        Public Property MerchantName() As String
            Get
                MerchantName = _MerchantName
            End Get
            Set(value As String)
                _MerchantName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="G", CustomColumnCaption:="Cleared" & vbCrLf & "Date")>
        Public Property ClearedDate() As Nullable(Of Date)
            Get
                ClearedDate = _ClearedDate
            End Get
            Set(value As Nullable(Of Date))
                _ClearedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsValid() As Boolean
            Get
                IsValid = _PreviouslyCleared = False AndAlso _CheckVoid = False AndAlso _CheckNumber.HasValue AndAlso Me.TotalCheckAmount.GetValueOrDefault(0) = Me.TotalBankAmount
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.MediaManager.Classes.ImportClearedCheckMediaVCC.Properties.CheckNumber.ToString

                    If Me.TotalCheckAmount.GetValueOrDefault(0) <> Me.TotalBankAmount Then

                        IsValid = True

                        ErrorText = "Total Check Amount must match Total Bank Amount."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace