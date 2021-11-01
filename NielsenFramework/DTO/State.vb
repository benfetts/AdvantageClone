Namespace DTO

    Public Class State
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Code() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Code As String, Description As String)

            Me.Code = Code
            Me.Description = Description

        End Sub

#End Region

    End Class

End Namespace
