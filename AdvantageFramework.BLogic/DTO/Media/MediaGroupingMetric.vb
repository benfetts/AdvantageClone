Namespace DTO.Media

    Public Class MediaGroupingMetric
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

        Public Sub New(ID As Integer, Description As String)

            Me.ID = ID
            Me.Description = Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
