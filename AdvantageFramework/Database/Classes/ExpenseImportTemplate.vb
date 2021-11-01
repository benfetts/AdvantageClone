Namespace Database.Classes

    <Serializable()>
    Public Class ExpenseImportTemplate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FieldPosition
            FieldValue
            PropertyValue
        End Enum

#End Region

#Region " Variables "

        Private _FieldPosition As Nullable(Of Short) = Nothing
        Private _FieldValue As String = Nothing
        Private _PropertyValue As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldPosition() As Nullable(Of Short)
            Get
                FieldPosition = _FieldPosition
            End Get
            Set(value As Nullable(Of Short))
                _FieldPosition = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FieldValue() As String
            Get
                FieldValue = _FieldValue
            End Get
            Set(value As String)
                _FieldValue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PropertyValue() As Nullable(Of Short)
            Get
                PropertyValue = _PropertyValue
            End Get
            Set(ByVal value As Nullable(Of Short))
                _PropertyValue = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace