Namespace Database.Classes

    <Serializable()>
    Public Class ImportTemplateDetailCSV
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TemplateID
            FieldName
            CSVPosition
            CSVField
            DateFormat
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _TemplateID As Short = Nothing
        Private _FieldName As Nullable(Of Short) = Nothing
        Private _CSVPosition As Nullable(Of Short) = Nothing
        Private _CSVField As String = Nothing
        Private _DateFormat As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TemplateID() As Short
            Get
                TemplateID = _TemplateID
            End Get
            Set(ByVal value As Short)
                _TemplateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CSVPosition() As Nullable(Of Short)
            Get
                CSVPosition = _CSVPosition
            End Get
            Set(ByVal value As Nullable(Of Short))
                _CSVPosition = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CSVField() As String
            Get
                CSVField = _CSVField
            End Get
            Set(ByVal value As String)
                _CSVField = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldName() As Nullable(Of Short)
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FieldName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateFormat() As String
            Get
                DateFormat = _DateFormat
            End Get
            Set(ByVal value As String)
                _DateFormat = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
