Namespace GeneralLedger.Classes

    <Serializable()>
    Public Class ImportJournalEntryHeader
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            TransactionID
            Description
            Balance
            TransactionDate
            PostPeriodCode
            GLSource
        End Enum

#End Region

#Region " Variables "

        Private _ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry = Nothing
        Private _ImportJournalEntryDetails As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail) = Nothing
        Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Importing.Methods.ImportTemplateTypes.JournalEntry_Default
        Private _PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
        Private _GeneralLedgerSourceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportJournalEntry.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportJournalEntry.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _ImportJournalEntry.IsOnHold
            End Get
            Set(value As Boolean)
                _ImportJournalEntry.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TransactionID() As String
            Get
                TransactionID = _ImportJournalEntry.TransactionID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
            Get
                Description = _ImportJournalEntry.Description
            End Get
            Set(value As String)
                _ImportJournalEntry.Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Balance() As Decimal
            Get
                Balance = Me.ImportJournalEntryDetails.ToList.Sum(Function(Det) Det.Amount.GetValueOrDefault(0))
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TransactionDate() As Nullable(Of Date)
            Get
                TransactionDate = _ImportJournalEntry.TransactionDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportJournalEntry.TransactionDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _ImportJournalEntry.PostPeriodCode
            End Get
            Set(value As String)
                _ImportJournalEntry.PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property GLSource() As String
            Get
                GLSource = _ImportJournalEntry.GLSource
            End Get
            Set(value As String)
                _ImportJournalEntry.GLSource = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportJournalEntryDetails As Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail)
            Get
                ImportJournalEntryDetails = _ImportJournalEntryDetails
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes
            Get
                ImportTemplateType = _ImportTemplateType
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod))
                _PostPeriodList = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property GeneralLedgerSourceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource)
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerSource))
                _GeneralLedgerSourceList = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportJournalEntry = New AdvantageFramework.Database.Entities.ImportJournalEntry
            _ImportJournalEntryDetails = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail)

        End Sub
        Public Sub New(ImportJournalEntry As AdvantageFramework.Database.Entities.ImportJournalEntry, ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes,
                       GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount))

            _ImportJournalEntry = ImportJournalEntry
            _ImportJournalEntryDetails = New Generic.List(Of AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail)

            _ImportTemplateType = ImportTemplateType

            If _ImportJournalEntry.ImportJournalEntryDetails.Any Then

                For Each DetailEntity In _ImportJournalEntry.ImportJournalEntryDetails

                    _ImportJournalEntryDetails.Add(New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail(DetailEntity, GeneralLedgerAccounts))

                Next

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.TransactionID.ToString

                    If Me.ImportJournalEntryDetails.Count > 32767 Then

                        IsValid = False

                        ErrorText = "Maximum number of sequences per transaction is 32,767."

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.Balance.ToString

                    If (Me.ImportJournalEntryDetails.Where(Function(Det) Det.Amount Is Nothing).Any OrElse Me.ImportJournalEntryDetails.Sum(Function(Det) Det.Amount.Value) <> 0) Then

                        IsValid = False

                        ErrorText = "Sum of debits and credits must equal 0."

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.PostPeriodCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If _PostPeriodList Is Nothing Then

                            _PostPeriodList = AdvantageFramework.GeneralLedger.GetValidPostPeriods(DbContext)

                        End If

                        If (From Entity In _PostPeriodList
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select an open or future GL posting period."

                        End If

                    End If

                Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.GLSource.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(PropertyValue) Then

                        If _GeneralLedgerSourceList Is Nothing Then

                            _GeneralLedgerSourceList = AdvantageFramework.GeneralLedger.GetValidGeneralLedgerSources(DbContext, _ImportTemplateType)

                        End If

                        If (From Entity In _GeneralLedgerSourceList
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select a valid GL source."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = ""

            SetRequiredFields()

            ErrorText = MyBase.ValidateEntity(IsValid)

            ValidateEntity = ErrorText

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.Description.ToString

                        SetRequired(PropertyDescriptor, True)

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.PostPeriodCode.ToString

                        SetRequired(PropertyDescriptor, True)

                    Case AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader.Properties.GLSource.ToString

                        SetRequired(PropertyDescriptor, True)

                End Select

            Next

        End Sub
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportJournalEntry

            GetEntity = _ImportJournalEntry

        End Function

#End Region

    End Class

End Namespace
