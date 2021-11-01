Namespace DTO

    Public Class DownloadFile
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            FileName
            FileType
            LastWriteTime
            ProcessedTime
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FileName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FileType() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastWriteTime() As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property ProcessedTime() As Date?

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(DownloadFile As Database.Entities.DownloadFile)

            Me.ID = DownloadFile.ID
            Me.FileName = DownloadFile.FileName
            Me.ProcessedTime = DownloadFile.ProcessedTime

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
