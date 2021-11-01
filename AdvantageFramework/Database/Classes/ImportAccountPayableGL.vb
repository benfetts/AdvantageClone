Namespace Database.Classes

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
        Private _ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader = Nothing

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

#End Region

#Region " Methods "

        Public Sub New()

            _ImportAccountPayableGL = New AdvantageFramework.Database.Entities.ImportAccountPayableGL
            _ImportAccountPayableHeader = New AdvantageFramework.Database.Classes.ImportAccountPayableHeader

        End Sub
        Public Sub New(ByVal ImportAccountPayableGL As AdvantageFramework.Database.Entities.ImportAccountPayableGL, _
                       ByVal ImportAccountPayableHeader As AdvantageFramework.Database.Classes.ImportAccountPayableHeader)

            _ImportAccountPayableGL = ImportAccountPayableGL
            _ImportAccountPayableHeader = ImportAccountPayableHeader

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
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Classes.ImportAccountPayableGL.Properties.GLOfficeCode.ToString

                    PropertyValue = Value

                    If _ImportAccountPayableHeader.IsAPLimitByOfficeEnabled AndAlso _ImportAccountPayableHeader.OfficeCode <> PropertyValue Then

                        IsValid = False

                        ErrorText = "Office does not match header."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

