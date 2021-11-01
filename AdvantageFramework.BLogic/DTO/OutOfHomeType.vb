Namespace DTO

    Public Class OutOfHomeType
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            Code
            Description
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Code() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(OutOfHomeType As AdvantageFramework.Database.Entities.OutOfHomeType)

            Me.Code = OutOfHomeType.Code
            Me.Description = OutOfHomeType.Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
