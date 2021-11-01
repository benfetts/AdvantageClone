Namespace AccountPayable.Classes

    <Serializable()>
    Public Class ImportAccountPayableGL
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportAccountPayableID
            GLACode
            GLNetAmount
            GLComment
            GLOfficeCode
        End Enum

#End Region

#Region " Variables "

        Private _ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL = Nothing
        Private _ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ImportAccountPayableGL.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ImportAccountPayableID() As Integer
            Get
                ImportAccountPayableID = _ImportAccountPayableGL.ImportAccountPayableID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode() As String
            Get
                GLACode = _ImportAccountPayableGL.GLACode
            End Get
            Set(value As String)
                _ImportAccountPayableGL.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property GLNetAmount() As Nullable(Of Decimal)
            Get
                GLNetAmount = _ImportAccountPayableGL.GLNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportAccountPayableGL.GLNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLComment() As String
            Get
                GLComment = _ImportAccountPayableGL.GLComment
            End Get
            Set(value As String)
                _ImportAccountPayableGL.GLComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Office Code")>
        Public Property GLOfficeCode() As String
            Get
                GLOfficeCode = _ImportAccountPayableGL.OfficeCodeDetail
            End Get
            Set(value As String)
                _ImportAccountPayableGL.OfficeCodeDetail = value
            End Set
        End Property
        <System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
            _ImportAccountPayableHeader = New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader

        End Sub
        Public Sub New(ByVal ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL,
                       ByVal ImportAccountPayableHeader As AdvantageFramework.AccountPayable.Classes.ImportAccountPayableHeader,
                       Session As AdvantageFramework.Security.Session)

            _ImportAccountPayableGL = ImportAccountPayableGL
            _ImportAccountPayableHeader = ImportAccountPayableHeader
            _Session = Session

        End Sub
        Public Overrides Function ToString() As String

            ToString = _ImportAccountPayableGL.ID

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ImportAccountPayableGL

            GetEntity = _ImportAccountPayableGL

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

            For Each PropertyDescriptor In PropertyDescriptors

                Select Case PropertyDescriptor.Name

                    Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL.Properties.GLOfficeCode.ToString

                        If _ImportAccountPayableHeader.IsInterCompanyTransactionsEnabled Then

                            SetRequired(PropertyDescriptor, True)

                        Else

                            SetRequired(PropertyDescriptor, False)

                        End If

                End Select

            Next

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim IsCustomNonClientOnlyImportTemplate As Boolean = False

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL.Properties.GLOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

                Case AdvantageFramework.AccountPayable.Classes.ImportAccountPayableGL.Properties.GLACode.ToString

                    PropertyValue = Value

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportAccountPayableHeader.ImportTemplateID)

                    If ImportTemplate IsNot Nothing AndAlso ImportTemplate.Type = Importing.ImportTemplateTypes.AccountsPayable_Custom Then

                        IsCustomNonClientOnlyImportTemplate = True

                    End If

                    If PropertyValue IsNot Nothing AndAlso (From Entity In AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Me.Session, _ImportAccountPayableHeader.OfficeCode, Me.GLOfficeCode, IsCustomNonClientOnlyImportTemplate, Me.GLOfficeCode)
                                                            Where Entity.Code = DirectCast(PropertyValue, String)).Any = False Then

                        IsValid = False

                        ErrorText = "GLA Code is required."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

