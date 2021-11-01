Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableInvoiceFromRecur
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableRecurID
            VendorCode
            VendorName
            InvoiceNumber
            InvoiceAmount
            NumberRemaining
            UnlimitedPostings
            CreateAP
            APCreatedForPostPeriod
            InvoiceDate
            DatePosted
            StartPostPeriod
            CycleCode
            LastLogPostPeriod
        End Enum

#End Region

#Region " Variables "

        Private _AccountPayableRecurID As Integer = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _NumberRemaining As Nullable(Of Integer) = Nothing
        Private _UnlimitedPostings As Nullable(Of Short) = Nothing
        Private _CreateAP As Integer = Nothing
        Private _APCreatedForPostPeriod As Integer = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _DatePosted As Nullable(Of Date) = Nothing
        Private _StartPostPeriod As String = Nothing
        Private _CycleCode As String = Nothing
        Private _LastLogPostPeriod As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableRecurID() As Integer
            Get
                AccountPayableRecurID = _AccountPayableRecurID
            End Get
            Set(ByVal value As Integer)
                _AccountPayableRecurID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceAmount() As Nullable(Of Decimal)
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NumberRemaining() As Nullable(Of Integer)
            Get
                NumberRemaining = _NumberRemaining
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _NumberRemaining = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property UnlimitedPostings() As Nullable(Of Short)
            Get
                UnlimitedPostings = _UnlimitedPostings
            End Get
            Set(ByVal value As Nullable(Of Short))
                _UnlimitedPostings = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Create A/P", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property CreateAP() As Integer
            Get
                CreateAP = _CreateAP
            End Get
            Set(ByVal value As Integer)
                _CreateAP = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="A/P Created For Post Period", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property APCreatedForPostPeriod() As Integer
            Get
                APCreatedForPostPeriod = _APCreatedForPostPeriod
            End Get
            Set(ByVal value As Integer)
                _APCreatedForPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DatePosted() As Nullable(Of Date)
            Get
                DatePosted = _DatePosted
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DatePosted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property StartPostPeriod() As String
            Get
                StartPostPeriod = _StartPostPeriod
            End Get
            Set(ByVal value As String)
                _StartPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CycleCode() As String
            Get
                CycleCode = _CycleCode
            End Get
            Set(ByVal value As String)
                _CycleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property LastLogPostPeriod() As String
            Get
                LastLogPostPeriod = _LastLogPostPeriod
            End Get
            Set(ByVal value As String)
                _LastLogPostPeriod = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableRecurID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.InvoiceNumber.ToString

                    PropertyValue = Value

                    If _CreateAP = 1 AndAlso AdvantageFramework.Database.Procedures.AccountPayable.VendorAndInvoiceNumberExists(Me.DbContext, Me.VendorCode, PropertyValue) Then

                        IsValid = False

                        ErrorText = "Invoice Number exists for " & Me.VendorCode & " - " & Me.VendorName & "."

                    Else

                        IsValid = True

                    End If

                Case AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.CreateAP.ToString()

                    PropertyValue = Value

                    If PropertyValue = 1 Then

                        _CreateAP = 1

                        ValidateCustomProperties(AdvantageFramework.AccountPayable.Classes.AccountPayableInvoiceFromRecur.Properties.InvoiceNumber.ToString, Nothing, _InvoiceNumber)

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

