Namespace DTO

    Public Class NielsenMarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Number() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Number As Integer, Name As String)

            Me.Number = Number
            Me.Name = Name

        End Sub

#End Region

    End Class

End Namespace
