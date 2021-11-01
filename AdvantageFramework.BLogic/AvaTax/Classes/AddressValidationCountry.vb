Namespace AvaTax.Classes

    <Serializable()>
    Public Class AddressValidationCountry

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Name
            Validate
        End Enum

#End Region

#Region " Variables "

        Private _Name As String = Nothing
        Private _Validate As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Validate() As Boolean
            Get
                Validate = _Validate
            End Get
            Set(value As Boolean)
                _Validate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Name As String)

            _Name = Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace

