Namespace Database.Classes
    ''' <summary>
    ''' FOR ADVANTAGE SERVICES ONLY
    ''' </summary>
    ''' <remarks>FOR ADVANTAGE SERVICES ONLY</remarks>
    <Serializable()>
    Public Class Campaign

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CampaignClient
            Code
            Name
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _CampaignClient As String = ""
        Private _Code As String = ""
        Private _Name As String = ""

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Client")>
        Public Property CampaignClient() As String
            Get
                CampaignClient = _CampaignClient
            End Get
            Set(value As String)
                _CampaignClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ID As Integer, ByVal CampaignClient As String, ByVal Code As String, ByVal Name As String)

            'objects
            Dim CampaignName As String = ""

            _ID = ID
            _CampaignClient = CampaignClient
            _Code = Code

            If Name.Contains("-") Then

                CampaignName = Name.Substring(Name.IndexOf("-") + 1).Trim

            Else

                CampaignName = Name

            End If

            _Name = CampaignName

        End Sub

#End Region

    End Class

End Namespace
