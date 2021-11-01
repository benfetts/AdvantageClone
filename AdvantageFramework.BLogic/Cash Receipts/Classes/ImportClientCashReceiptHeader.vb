Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ImportClientCashReceiptHeader
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            CheckNumber
            CheckDate
            CheckAmount
            DepositDate
            IsCleared
            PaymentTypeDescription
        End Enum

#End Region

#Region " Variables "

        Private _ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt = Nothing
        Private _ImportClientCashReceiptDetails As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportCashReceipt.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportCashReceipt.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOnHold() As Short
            Get
                IsOnHold = _ImportCashReceipt.IsOnHold
            End Get
            Set(value As Short)
                _ImportCashReceipt.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property CheckNumber() As String
            Get
                CheckNumber = _ImportCashReceipt.CheckNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property CheckDate() As Nullable(Of Date)
            Get
                CheckDate = _ImportCashReceipt.CheckDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public ReadOnly Property CheckAmount() As Nullable(Of Decimal)
            Get
                CheckAmount = _ImportCashReceipt.CheckAmount
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property DepositDate() As Nullable(Of Date)
            Get
                DepositDate = _ImportCashReceipt.DepositDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCleared() As Nullable(Of Short)
            Get
                IsCleared = _ImportCashReceipt.IsCleared
            End Get
            Set(value As Nullable(Of Short))
                _ImportCashReceipt.IsCleared = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentTypeDescription() As String
            Get
                PaymentTypeDescription = _ImportCashReceipt.PaymentTypeDescription
            End Get
            Set(value As String)
                _ImportCashReceipt.PaymentTypeDescription = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportClientCashReceiptDetails As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail)
            Get
                ImportClientCashReceiptDetails = _ImportClientCashReceiptDetails
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportCashReceipt = New AdvantageFramework.Database.Entities.ImportCashReceipt

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportCashReceipt As AdvantageFramework.Database.Entities.ImportCashReceipt)

            Dim SqlParameterImportID As SqlClient.SqlParameter = Nothing

            _ImportCashReceipt = ImportCashReceipt

            SqlParameterImportID = New SqlClient.SqlParameter("@ImportID", ImportCashReceipt.ID)

            _ImportClientCashReceiptDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail)("exec advsp_cr_import_select_details @ImportID", SqlParameterImportID).ToList

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ClientCode As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceipt.Properties.CheckNumber.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If _ImportClientCashReceiptDetails.GroupBy(Function(Entity) Entity.ClientCode).Distinct.Count > 1 Then

                            IsValid = False

                            ErrorText = "Invoices must belong to the same client for this check."

                        ElseIf _ImportClientCashReceiptDetails IsNot Nothing AndAlso _ImportClientCashReceiptDetails.Count > 0 Then

                            ClientCode = _ImportClientCashReceiptDetails.FirstOrDefault.ClientCode

                            If (From CCR In AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByClient(DbContext, ClientCode)
                                Where CCR.CheckNumber = DirectCast(PropertyValue, String) AndAlso
                                      CCR.Status Is Nothing
                                Select CCR).Any Then

                                IsValid = False

                                ErrorText = "Check number exists for client."

                            End If

                        End If

                    End If

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader.Properties.CheckAmount.ToString

                    PropertyValue = Value

                    If PropertyValue <> _ImportClientCashReceiptDetails.ToList.Sum(Function(Details) Details.PaymentAmount.GetValueOrDefault(0)) Then

                        IsValid = True

                        ErrorText = "Check amount does not match total payments."

                    End If

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader.Properties.PaymentTypeDescription.ToString

                    PropertyValue = Value

                    If String.IsNullOrWhiteSpace(PropertyValue) = False AndAlso CType(_DbContext, AdvantageFramework.Database.DbContext).CashReceiptPaymentTypes.Where(Function(PT) PT.IsInactive = False AndAlso PT.Description = DirectCast(PropertyValue, String)).Any = False Then

                        IsValid = True

                        ErrorText = "Payment type does not exist or is inactive."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorString As String = ""
            Dim ErrorText As String = ""
            Dim SubItemIsValid As Boolean = True

            ErrorString = MyBase.ValidateEntity(IsValid)

            For Each ImportClientCashReceiptDetail In Me.ImportClientCashReceiptDetails

                ImportClientCashReceiptDetail.DbContext = DbContext

                ErrorText = ImportClientCashReceiptDetail.ValidateEntity(SubItemIsValid)

                If SubItemIsValid = False Then

                    IsValid = False

                    ErrorString = If(ErrorString = "", ErrorText, ErrorString & vbNewLine & ErrorText)

                End If

            Next

            ValidateEntity = ErrorString

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function

#End Region

    End Class

End Namespace
