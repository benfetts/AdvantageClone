Namespace GeneralLedger.Classes

    <Serializable()>
    Public Class JournalEntryImportSetting
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GeneralLedgerSource
            PostPeriodCode
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerSource As String = Nothing
        Private _PostPeriodCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property GeneralLedgerSource() As String
            Get
                GeneralLedgerSource = _GeneralLedgerSource
            End Get
            Set(value As String)
                _GeneralLedgerSource = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.PropertyTypes.PostPeriodCode, CustomColumnCaption:="Posting Period")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(GeneralLedgerSource As String, PostPeriodCode As String)

            _GeneralLedgerSource = GeneralLedgerSource
            _PostPeriodCode = PostPeriodCode

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.GeneralLedger.Classes.JournalEntryImportSetting.Properties.PostPeriodCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please select an open GL posting period."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace