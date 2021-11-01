Namespace ViewModels.Maintenance.Media

    Public Class DemographicSetupDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            IsInactive
            AgeFrom
            AgeTo
            UseForMarket
            UseForCounty
        End Enum

#End Region

#Region " Variables "

        Private _NielsenDemographics As Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic) = Nothing

#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _MediaDemographic.ID
            End Get
        End Property
        <System.ComponentModel.DataAnnotations.MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Code() As String
            Get
                Code = _MediaDemographic.Code
            End Get
        End Property
        <System.ComponentModel.DataAnnotations.MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property Description() As String
            Get
                Description = _MediaDemographic.Description
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public ReadOnly Property IsInactive() As Boolean
            Get
                IsInactive = _MediaDemographic.IsInactive
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property IsSystem() As Boolean
            Get
                IsSystem = _MediaDemographic.IsSystem
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property HasGenderChecked() As Boolean
            Get
                HasGenderChecked = _MediaDemographic.IsBoys OrElse _MediaDemographic.IsGirls OrElse _MediaDemographic.IsMales OrElse _MediaDemographic.IsFemales OrElse _MediaDemographic.IsChildren OrElse _MediaDemographic.IsWorkingWomen
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property AgeFrom() As Nullable(Of Short)
            Get
                AgeFrom = _MediaDemographic.AgeFrom
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UseForMarket() As Boolean
            Get
                UseForMarket = _MediaDemographic.UseForMarket
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property UseForCounty() As Boolean
            Get
                UseForCounty = _MediaDemographic.UseForCounty
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property NielsenDemographics As Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)
            Get
                NielsenDemographics = _NielsenDemographics
            End Get
            Set(value As Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic))
                _NielsenDemographics = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property RepositoryNielsenDemographicList As Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property AgeFromDatasource As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property AgeToDatasource As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            _MediaDemographic = New AdvantageFramework.Database.Entities.MediaDemographic
            _NielsenDemographics = New Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)

        End Sub
        Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

            _MediaDemographic = MediaDemographic
            _NielsenDemographics = New Generic.List(Of AdvantageFramework.Database.Entities.NielsenDemographic)

            For Each MediaDemographicDetail In MediaDemographic.MediaDemographicDetails

                _NielsenDemographics.Add(MediaDemographicDetail.NielsenDemographic)

            Next

        End Sub
        Public Function GetMediaDemographicEntity() As AdvantageFramework.Database.Entities.MediaDemographic

            GetMediaDemographicEntity = _MediaDemographic

        End Function

#End Region

    End Class

End Namespace

