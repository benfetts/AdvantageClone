Namespace Database.Classes

    <Serializable()>
    Public Class MediaDemographic

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaDemographicID
            IsSelected
            Description
            IsSystem
            ComscoreDemoNumber
        End Enum

#End Region

#Region " Variables "

        Private _MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
        Private _IsSelected As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MediaDemographicID() As Integer
            Get
                MediaDemographicID = _MediaDemographic.ID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSelected() As Boolean
            Get
                IsSelected = _IsSelected
            End Get
            Set(value As Boolean)
                _IsSelected = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Description As String
            Get
                Description = _MediaDemographic.Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IsSystem() As Boolean
            Get
                IsSystem = _MediaDemographic.IsSystem
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ComscoreDemoNumber() As Nullable(Of Integer)
            Get
                ComscoreDemoNumber = _MediaDemographic.ComscoreDemoNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

            _MediaDemographic = MediaDemographic

        End Sub

#End Region

    End Class

End Namespace