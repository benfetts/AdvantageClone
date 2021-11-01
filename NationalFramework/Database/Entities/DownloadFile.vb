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
            ProcessedTime
            Skipped
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
        <MaxLength(100)>
        <Column("FILENAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FileName() As String
        <Column("PROCESSED_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ProcessedTime() As Nullable(Of Date)
        <Required>
        <Column("SKIPPED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Skipped() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
