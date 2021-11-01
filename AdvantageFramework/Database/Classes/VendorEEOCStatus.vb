Namespace Database.Classes

    <Serializable()>
    Public Class VendorEEOCStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EEOCStatusCode
            EEOCDescription
            InUse
        End Enum

#End Region

#Region " Variables "

        Private _EEOCStatusCode As String = Nothing
        Private _EEOCDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property EEOCStatusCode() As String
            Get
                EEOCStatusCode = _EEOCStatusCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public ReadOnly Property EEOCDescription() As String
            Get
                EEOCDescription = _EEOCDescription
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal EEOCStatusCode As String, ByVal EEOCDescription As String)

            _EEOCStatusCode = EEOCStatusCode
            _EEOCDescription = EEOCDescription

        End Sub

#End Region

    End Class

End Namespace

