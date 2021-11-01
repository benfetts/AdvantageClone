Namespace GeneralLedger.Classes

    <Serializable()>
    Public Class ImportJournalEntry
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BatchName
            IsOnHold
            TransactionID
            IDSeq
            Description
            TransactionDate
            GLAccount
            GLDescription
            Amount
            Remark
            ClientCode
            DivisionCode
            ProductCode
            PostPeriodCode
            GLSource
        End Enum

        Public Enum GLSourceStandard
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IJ", "")>
            IJ
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PR", "")>
            PR
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("FA", "")>
            FA
        End Enum

        Public Enum GLSourceMOGLIFACE
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("01", "")>
            One
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("02", "")>
            Two
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("03", "")>
            Three
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("04", "")>
            Four
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("05", "")>
            Five
        End Enum

#End Region

#Region " Variables "

        Private _ImportJournalEntryHeader As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader = Nothing
        Private _ImportJournalEntryDetail As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail = Nothing
        Private _Modified As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportJournalEntryHeader.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property BatchName() As String
            Get
                BatchName = _ImportJournalEntryHeader.BatchName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsOnHold() As Boolean
            Get
                IsOnHold = _ImportJournalEntryHeader.IsOnHold
            End Get
            Set(value As Boolean)
                _ImportJournalEntryHeader.IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property TransactionID() As String
            Get
                TransactionID = _ImportJournalEntryHeader.TransactionID
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Description() As String
            Get
                Description = _ImportJournalEntryHeader.Description
            End Get
            Set(value As String)
                _ImportJournalEntryHeader.Description = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Balance() As Decimal
            Get
                Balance = _ImportJournalEntryHeader.Balance
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.Methods.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLAccount() As String
            Get
                GLAccount = _ImportJournalEntryDetail.GLAccount
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.GLAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.GeneralLedgerAccountDescription)>
        Public Property GLDescription() As String
            Get
                GLDescription = _ImportJournalEntryDetail.GLDescription
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.GLDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _ImportJournalEntryDetail.Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportJournalEntryDetail.Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Remark() As String
            Get
                Remark = _ImportJournalEntryDetail.Remark
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.Remark = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", PropertyType:=BaseClasses.Methods.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ImportJournalEntryDetail.ClientCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", PropertyType:=BaseClasses.Methods.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _ImportJournalEntryDetail.DivisionCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", PropertyType:=BaseClasses.Methods.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ImportJournalEntryDetail.ProductCode
            End Get
            Set(value As String)
                _ImportJournalEntryDetail.ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Post Period", PropertyType:=BaseClasses.Methods.PropertyTypes.PostPeriodCode, IsImportDefaultProperty:=True)>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _ImportJournalEntryHeader.PostPeriodCode
            End Get
            Set(value As String)
                _ImportJournalEntryHeader.PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TransactionDate() As Nullable(Of Date)
            Get
                TransactionDate = _ImportJournalEntryHeader.TransactionDate
            End Get
            Set(value As Nullable(Of Date))
                _ImportJournalEntryHeader.TransactionDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.Methods.PropertyTypes.GeneralLedgerSource, IsImportDefaultProperty:=True)>
        Public Property GLSource() As String
            Get
                GLSource = _ImportJournalEntryHeader.GLSource
            End Get
            Set(value As String)
                _ImportJournalEntryHeader.GLSource = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DetailID() As Integer
            Get
                DetailID = _ImportJournalEntryDetail.ID
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportJournalEntryDetail As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail
            Get
                ImportJournalEntryDetail = _ImportJournalEntryDetail
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportJournalEntryHeader As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader
            Get
                ImportJournalEntryHeader = _ImportJournalEntryHeader
            End Get
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes
            Get
                ImportTemplateType = _ImportJournalEntryHeader.ImportTemplateType
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ExternalID() As Nullable(Of Integer)
            Get
                ExternalID = _ImportJournalEntryDetail.ExternalID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified() As Boolean
            Get
                Modified = _Modified
            End Get
            Set(value As Boolean)
                _Modified = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportJournalEntryHeader = New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader
            _ImportJournalEntryDetail = New AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail

        End Sub
        Public Sub New(ByVal ImportJournalEntryHeader As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryHeader,
                       ByVal ImportJournalEntryDetail As AdvantageFramework.GeneralLedger.Classes.ImportJournalEntryDetail)

            _ImportJournalEntryHeader = ImportJournalEntryHeader
            _ImportJournalEntryDetail = ImportJournalEntryDetail

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            Dim ErrorText As String = ""
            Dim SubItemIsValid As Boolean = True

            _ImportJournalEntryHeader.DbContext = Me.DbContext

            _EntityError = _ImportJournalEntryHeader.ValidateEntity(IsValid)

            ErrorText = _ImportJournalEntryDetail.ValidateEntity(SubItemIsValid)

            If SubItemIsValid = False Then

                IsValid = False

                _EntityError = If(_EntityError = "", ErrorText, _EntityError & vbNewLine & ErrorText)

            End If

            RefreshErrorHashtable()

            ValidateEntity = _EntityError

        End Function
        Public Sub RefreshErrorHashtable()

            Dim ErrorString As String = Nothing

            _ErrorHashtable.Clear()

            For Each Key In _ImportJournalEntryHeader.ErrorHashtable.Keys

                If _ImportJournalEntryHeader.ErrorHashtable.Item(Key) <> "" AndAlso _ErrorHashtable.ContainsKey(Key) = False Then

                    _ErrorHashtable.Add(Key, _ImportJournalEntryHeader.ErrorHashtable.Item(Key))

                End If

            Next

            For Each Key In _ImportJournalEntryDetail.ErrorHashtable.Keys

                If _ImportJournalEntryDetail.ErrorHashtable.Item(Key) <> "" AndAlso _ErrorHashtable.ContainsKey(Key) = False Then

                    _ErrorHashtable.Add(Key, _ImportJournalEntryDetail.ErrorHashtable.Item(Key))

                End If

            Next

            For Each Key In _ErrorHashtable.Keys

                ErrorString = If(ErrorString Is Nothing, _ErrorHashtable.Item(Key).ToString, ErrorString + vbNewLine + _ErrorHashtable.Item(Key).ToString)

            Next

            _EntityError = ErrorString

        End Sub
        Public Overrides Function LoadErrorText(PropertyName As String) As String

            'objects
            Dim ErrorText As String = ""

            Try

                If (PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLAccount.ToString OrElse
                        PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.Amount.ToString OrElse
                        PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.Remark.ToString OrElse
                        PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.ClientCode.ToString OrElse
                        PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.DivisionCode.ToString OrElse
                        PropertyName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.ProductCode.ToString) AndAlso
                        _ImportJournalEntryDetail.ErrorHashtable.Item(PropertyName) = "" Then

                    ErrorText = Nothing

                Else

                    ErrorText = _ErrorHashtable(PropertyName)

                End If

            Catch ex As Exception
                ErrorText = ""
            Finally
                LoadErrorText = ErrorText
            End Try

        End Function
        Public Function GetHeader() As AdvantageFramework.Database.Entities.ImportJournalEntry

            GetHeader = _ImportJournalEntryHeader.GetEntity

        End Function
        Public Function GetDetail() As AdvantageFramework.Database.Entities.ImportJournalEntryDetail

            GetDetail = _ImportJournalEntryDetail.GetEntity

        End Function

#End Region

    End Class

End Namespace
