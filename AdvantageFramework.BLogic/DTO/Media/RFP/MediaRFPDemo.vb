Namespace DTO.Media.RFP

    Public Class MediaRFPDemo
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IDRank
            Type
            Group
            AgeFrom
            AgeTo
            MediaDemoID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaRFPHeaderID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property IDRank As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Type As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Group As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property AgeFrom As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property AgeTo As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic, CustomColumnCaption:="Demographic")>
        Public Property MediaDemoID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property WorksheetHasDemos As Boolean

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPDemo As AdvantageFramework.Database.Entities.MediaRFPDemo)

            MediaRFPDemo.IDRank = Me.IDRank
            MediaRFPDemo.Type = Me.Type
            MediaRFPDemo.Group = Me.Group
            MediaRFPDemo.AgeFrom = Me.AgeFrom
            MediaRFPDemo.AgeTo = Me.AgeTo
            MediaRFPDemo.MediaDemoID = Me.MediaDemoID

        End Sub

#End Region

    End Class

End Namespace
