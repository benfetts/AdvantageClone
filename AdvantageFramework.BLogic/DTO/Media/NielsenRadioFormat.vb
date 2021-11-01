Namespace DTO.Media

    Public Class NielsenRadioFormat
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Code() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioFormat As AdvantageFramework.Database.Entities.NielsenRadioFormat)

            Me.Code = NielsenRadioFormat.Code
            Me.Name = NielsenRadioFormat.Name

        End Sub
        Public Sub New(MediaSpotRadioResearchFormat As AdvantageFramework.Database.Entities.MediaSpotRadioResearchFormat)

            Me.Code = MediaSpotRadioResearchFormat.NielsenRadioFormatCode
            Me.Name = MediaSpotRadioResearchFormat.NielsenRadioFormat.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
