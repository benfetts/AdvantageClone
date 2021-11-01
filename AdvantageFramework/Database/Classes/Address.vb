Namespace Database.Classes

    <Serializable()>
    Public Class Address

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            Address1
            Address2
            City
            State
            Zip
            County
            Country
        End Enum

#End Region

#Region " Variables "

        Private _Code As Short = Nothing
        Private _Description As String = Nothing
        Private _Address1 As String = Nothing
        Private _Address2 As String = Nothing
        Private _City As String = Nothing
        Private _State As String = Nothing
        Private _Zip As String = Nothing
        Private _Country As String = Nothing
        Private _County As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Code As Short
            Get
                Code = _Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property Description As String
            Get
                Description = _Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Address1 As String
            Get
                Address1 = _Address1
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Address2 As String
            Get
                Address2 = _Address1
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property City As String
            Get
                City = _City
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property State As String
            Get
                State = _State
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Zip As String
            Get
                Zip = _Zip
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property County As String
            Get
                County = _County
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Country As String
            Get
                Country = _Country
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Code As Short, ByVal Description As String, ByVal Address1 As String, ByVal Address2 As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal Country As String, ByVal County As String)

            _Code = Code
            _Description = Description
            _Address1 = Address1
            _Address2 = Address2
            _City = City
            _State = State
            _Zip = Zip
            _Country = Country
            _County = County

        End Sub

#End Region

    End Class

End Namespace