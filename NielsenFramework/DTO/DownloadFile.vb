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

            Select Case DownloadFile.FileType

                Case Database.Entities.Methods.DownloadFileType.TVSpot

                    Me.FileType = "TV Spot"

                Case Database.Entities.Methods.DownloadFileType.Radio

                    Me.FileType = "Radio"

                Case Database.Entities.Methods.DownloadFileType.NCC

                    Me.FileType = "NCC"

                Case Database.Entities.Methods.DownloadFileType.EastlanRadio

                    Me.FileType = "Eastlan"

                Case Database.Entities.Methods.DownloadFileType.RadioCounty

                    Me.FileType = "Radio County"

            End Select

            Me.LastWriteTime = DownloadFile.LastWriteTime
            Me.ProcessedTime = DownloadFile.ProcessedTime

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
