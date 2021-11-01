Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_PROGRAM_BOOK")>
    Public Class NielsenTVProgramBook
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Year
            Month
            Validated
            ReportingService
            Exclusion
            Ethnicity
            DownloadFileID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_PROGRAM_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_MARKET_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenMarketNumber() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Short
        <Required>
        <Column("MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Month() As Short
        <Required>
        <Column("VALIDATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Validated() As Boolean
        <Required>
        <MaxLength(1)>
        <Column("REPORTING_SERVICE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ReportingService() As String
        <Required>
        <MaxLength(2)>
        <Column("EXCLUSION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Exclusion() As String
        <Required>
        <MaxLength(5)>
        <Column("ETHNICITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Ethnicity() As String
        <Column("DOWNLOAD_FILE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DownloadFileID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
