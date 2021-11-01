Namespace DTO.Media

    Public Class NielsenRadioQualitative
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenRadioQualitative As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioQualitative)

            Me.ID = NielsenRadioQualitative.ID

            If Me.ID = 1 Then

                Me.Name = "None"

            Else

                Me.Name = NielsenRadioQualitative.Name

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
