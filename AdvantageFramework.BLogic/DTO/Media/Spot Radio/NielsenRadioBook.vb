Namespace DTO.Media.SpotRadio

    Public Class NielsenRadioBook
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NielsenRadioPeriodID1
            NielsenRadioPeriodID2
            NielsenRadioPeriodID3
            NielsenRadioPeriodID4
            NielsenRadioPeriodID5
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Book 1", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID1() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Book 2", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID2() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Book 3", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID3() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Book 4", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID4() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Book 5", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioPeriod)>
        Public Property NielsenRadioPeriodID5() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaSpotRadioResearchBook As AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook)

            Me.NielsenRadioPeriodID1 = MediaSpotRadioResearchBook.NielsenRadioPeriodID1
            Me.NielsenRadioPeriodID2 = MediaSpotRadioResearchBook.NielsenRadioPeriodID2
            Me.NielsenRadioPeriodID3 = MediaSpotRadioResearchBook.NielsenRadioPeriodID3
            Me.NielsenRadioPeriodID4 = MediaSpotRadioResearchBook.NielsenRadioPeriodID4
            Me.NielsenRadioPeriodID5 = MediaSpotRadioResearchBook.NielsenRadioPeriodID5

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotRadioResearchBook As AdvantageFramework.Database.Entities.MediaSpotRadioResearchBook)

            MediaSpotRadioResearchBook.NielsenRadioPeriodID1 = Me.NielsenRadioPeriodID1
            MediaSpotRadioResearchBook.NielsenRadioPeriodID2 = Me.NielsenRadioPeriodID2
            MediaSpotRadioResearchBook.NielsenRadioPeriodID3 = Me.NielsenRadioPeriodID3
            MediaSpotRadioResearchBook.NielsenRadioPeriodID4 = Me.NielsenRadioPeriodID4
            MediaSpotRadioResearchBook.NielsenRadioPeriodID5 = Me.NielsenRadioPeriodID5

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.NielsenRadioPeriodID1.ToString

        End Function

#End Region

    End Class

End Namespace
