Namespace DTO.Media.National

    Public Class ProgramType
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            ShortName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Code() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShortName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ProgramType As AdvantageFramework.National.Database.Entities.ProgramType)

            Me.ID = ProgramType.ID
            Me.Code = ProgramType.Code
            Me.Name = ProgramType.Name
            Me.ShortName = ProgramType.ShortName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
