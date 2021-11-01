Namespace GeneralLedger.Classes

    <Serializable()>
    Public Class ImportJournalEntryDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportID
            IDSeq
            GLAccount
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
            ExternalID
        End Enum

#End Region

#Region " Variables "

        Private _PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
        Private _ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
        Private _DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
        Private _ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
        Private _CDPRequired As Boolean = False
        Private _ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail = Nothing
        Private _GLDescription As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportJournalEntryDetail.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ImportID() As Integer
            Get
                ImportID = _ImportJournalEntryDetail.ImportID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IDSeq() As String
            Get
                IDSeq = _ImportJournalEntryDetail.IDSeq
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property GLAccount() As String
            Get
                GLAccount = _ImportJournalEntryDetail.GLAccount
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.GLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLDescription() As String
            Get
                GLDescription = _GLDescription
            End Get
            Set(value As String)
                _GLDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _ImportJournalEntryDetail.Amount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportJournalEntryDetail.Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Remark() As String
            Get
                Remark = _ImportJournalEntryDetail.Remark
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.Remark = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ImportJournalEntryDetail.ClientCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _ImportJournalEntryDetail.DivisionCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ImportJournalEntryDetail.ProductCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ExternalID() As Nullable(Of Integer)
            Get
                ExternalID = _ImportJournalEntryDetail.ExternalID
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor)
            Set(value As Generic.List(Of System.ComponentModel.PropertyDescriptor))
                _PropertyDescriptors = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount))
                _GeneralLedgerAccountList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.Client))
                _ClientList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.Division))
                _DivisionList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.Product))
                _ProductList = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportJournalEntryDetail = New AdvantageFramework.Database.Entities.ImportJournalEntryDetail

        End Sub
        Public Sub New(ImportJournalEntryDetail As AdvantageFramework.Database.Entities.ImportJournalEntryDetail,
                       GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount))

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            _ImportJournalEntryDetail = ImportJournalEntryDetail

            GeneralLedgerAccount = GeneralLedgerAccounts.Where(Function(GL) GL.Code = ImportJournalEntryDetail.GLAccount).FirstOrDefault

            If GeneralLedgerAccount IsNot Nothing Then

                _GLDescription = GeneralLedgerAccount.Description

            End If

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            If Not String.IsNullOrWhiteSpace(Me.GLAccount) Then

                GeneralLedgerAccount = _GeneralLedgerAccountList.Where(Function(GL) GL.Code = Me.GLAccount).FirstOrDefault

                If GeneralLedgerAccount IsNot Nothing Then

                    _CDPRequired = CBool(GeneralLedgerAccount.CDPRequired.GetValueOrDefault(0))

                End If

            End If

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            If _PropertyDescriptors Is Nothing Then

                _PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            End If

            For Each PropertyDescriptor In _PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.ClientCode.ToString,
                             AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.DivisionCode.ToString,
                             AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.ProductCode.ToString

                        SetRequired(PropertyDescriptor, _CDPRequired)

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.Amount.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Amount cannot be zero."

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.GLAccount.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If (From GL In _GeneralLedgerAccountList
                            Where GL.Code = DirectCast(PropertyValue, String)
                            Select GL).Any = False Then

                            IsValid = False

                            ErrorText = "GL code is not valid or you do not have access."

                        End If

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.ClientCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If (From Entity In _ClientList
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Client code is not valid or you do not have access."

                        End If

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.DivisionCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If (From Entity In _DivisionList
                            Where Entity.Code = DirectCast(PropertyValue, String) AndAlso
                                  Entity.ClientCode = Me.ClientCode
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Division code is not valid or you do not have access."

                        End If

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail.Properties.ProductCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If (From Entity In _ProductList
                            Where Entity.Code = DirectCast(PropertyValue, String) AndAlso
                                  Entity.ClientCode = Me.ClientCode AndAlso
                                  Entity.DivisionCode = Me.DivisionCode
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Product code is not valid or you do not have access."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportJournalEntryDetail

            GetEntity = _ImportJournalEntryDetail

        End Function

#End Region

    End Class

End Namespace
