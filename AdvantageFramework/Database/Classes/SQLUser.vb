Namespace Database.Classes

    <Serializable()>
    Public Class SQLUser

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _Name As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
