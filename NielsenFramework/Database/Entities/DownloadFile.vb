Namespace Database.Entities

    <Table("DOWNLOAD_FILE")>
    Public Class DownloadFile
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            FileName
            FileType
            DownloadDate
            ProcessedTime
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("DOWNLOAD_FILE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
        <Required>
        <MaxLength(200)>
        <Column("FILENAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FileName() As String
        <Required>
        <Column("FILETYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FileType() As Database.Entities.DownloadFileType
        <Required>
        <Column("LAST_WRITE_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property LastWriteTime() As Date
        <Column("PROCESSED_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ProcessedTime() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
