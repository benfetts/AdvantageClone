Namespace ViewModels.Maintenance

    Public Class ClientSetupDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Client As Database.Entities.Client = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _Client.ID
            End Get
            Set(value As Integer)
                _Client.ID = value
            End Set
        End Property
        <System.ComponentModel.DataAnnotations.MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String
            Get
                Name = _Client.Name
            End Get
            Set(value As String)
                _Client.Name = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _Client.IsInactive
            End Get
            Set(value As Boolean)
                _Client.IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _Client = New Database.Entities.Client

        End Sub
        Public Sub New(Client As Database.Entities.Client)

            _Client = Client

        End Sub
        Public Function GetClientEntity() As Database.Entities.Client

            GetClientEntity = _Client

        End Function

#End Region

    End Class

End Namespace

