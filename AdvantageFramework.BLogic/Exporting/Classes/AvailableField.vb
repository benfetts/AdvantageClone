Namespace Exporting.Classes

    <Serializable()>
    Public Class AvailableField

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FieldName
            PreDefinedLength
        End Enum

#End Region

#Region " Variables "

        Private _FieldName As String = ""
        Private _PreDefinedLength As Integer = 0

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FieldName() As String
            Get
                FieldName = _FieldName
            End Get
            Set(ByVal value As String)
                _FieldName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property PreDefinedLength() As String
            Get
                PreDefinedLength = _PreDefinedLength
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            If PropertyDescriptor IsNot Nothing Then

                _FieldName = PropertyDescriptor.Name

                _PreDefinedLength = AdvantageFramework.Exporting.LoadPreDefinedLength(PropertyDescriptor)

            End If

        End Sub
        Public Sub New(ByVal FieldName As String, ByVal PreDefinedLength As Integer)

            _FieldName = FieldName
            _PreDefinedLength = PreDefinedLength

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.FieldName

        End Function

#End Region

    End Class

End Namespace

