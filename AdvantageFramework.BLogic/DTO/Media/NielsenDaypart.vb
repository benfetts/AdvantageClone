Namespace DTO.Media

    Public Class NielsenDaypart
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Daypart", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioDaypart)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQH() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cume() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExclusiveCume() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Qualitative() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Diary At Work / In Car")>
        Public Property DiaryAtWorkInCar() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="PPM In Home / Out of Home")>
        Public Property PPMinHomeOutofHome() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Guid() As Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsStandard() As Boolean
            Get
                IsStandard = If((Me.ID >= 64 AndAlso Me.ID <= 70) OrElse (Me.ID >= 75 AndAlso Me.ID <= 115), True, False)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Guid = Guid.NewGuid

        End Sub
        Public Sub New(NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart)

            Guid = Guid.NewGuid

            Me.ID = NielsenRadioDaypart.NielsenDaypartID
            Me.Description = NielsenRadioDaypart.Name
            Me.AQH = NielsenRadioDaypart.AQH
            Me.Cume = NielsenRadioDaypart.Cume
            Me.ExclusiveCume = NielsenRadioDaypart.ExclusiveCume
            Me.Qualitative = NielsenRadioDaypart.Qualitative
            Me.DiaryAtWorkInCar = NielsenRadioDaypart.DiaryAtWorkInCar
            Me.PPMinHomeOutofHome = NielsenRadioDaypart.PPMinHomeOutofHome

        End Sub
        Public Sub New(MediaSpotRadioResearchDaypart As AdvantageFramework.Database.Entities.MediaSpotRadioResearchDaypart,
                       NielsenRadioDaypartList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart))

            'objects
            Dim NielsenRadioDaypart As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart = Nothing

            Guid = Guid.NewGuid
            Me.ID = MediaSpotRadioResearchDaypart.NielsenRadioDaypartID

            NielsenRadioDaypart = NielsenRadioDaypartList.Where(Function(DP) DP.NielsenDaypartID = Me.ID).FirstOrDefault

            If NielsenRadioDaypart IsNot Nothing Then

                Me.Description = NielsenRadioDaypart.Name
                Me.AQH = NielsenRadioDaypart.AQH
                Me.Cume = NielsenRadioDaypart.Cume
                Me.ExclusiveCume = NielsenRadioDaypart.ExclusiveCume
                Me.Qualitative = NielsenRadioDaypart.Qualitative
                Me.DiaryAtWorkInCar = NielsenRadioDaypart.DiaryAtWorkInCar
                Me.PPMinHomeOutofHome = NielsenRadioDaypart.PPMinHomeOutofHome

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotRadioResearchDaypart As AdvantageFramework.Database.Entities.MediaSpotRadioResearchDaypart)

            MediaSpotRadioResearchDaypart.NielsenRadioDaypartID = Me.ID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
