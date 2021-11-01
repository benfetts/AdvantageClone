Namespace DTO.Media.SpotRadioCounty

    Public Class County
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CountyCode
            Name
            State
            MarketNumber
            MarketName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CountyCode() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property State() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.CountyCode.ToString

        End Function

#End Region

    End Class

End Namespace
