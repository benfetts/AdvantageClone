Namespace DTO.GeneralLedger.Processing

    Public Class GLSourcePost
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SourceType
            SourceDescription
            Post
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SourceType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SourceDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Post() As Boolean

#End Region

#Region " Methods "

        Public Sub New(Source As String, Description As String)

            Me.SourceType = Source
            Me.SourceDescription = Description
            Me.Post = True

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.SourceType.ToString

        End Function

#End Region

    End Class

End Namespace
