Namespace Database.Classes

    <Serializable()>
    Public Class ImportTemplateDetailFixed
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TemplateID
            FieldName
            Start
            Length
            DateFormat
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _TemplateID As Short = Nothing
        Private _FieldName As Nullable(Of Short) = Nothing
        Private _Start As Nullable(Of Integer) = Nothing
        Private _Length As Nullable(Of Integer) = Nothing
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
        Public Property FieldName() As Nullable(Of Short)
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FieldName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Start() As Nullable(Of Integer)
            Get
                Start = _Start
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Start = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Nullable(Of Integer)
            Get
                Length = _Length
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Length = value
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
