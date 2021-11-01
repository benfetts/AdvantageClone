Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_RESEARCH_BOOK")>
    Public Class MediaSpotTVResearchBook
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVResearchID
            UseLatest
            LatestStream
            ShareBookID
            HPUTBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVResearchID() As Integer
        <Column("USE_LATEST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property UseLatest() As Boolean
        <Column("LATEST_STREAM")>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property LatestStream() As String
        <Required>
        <Column("SHARE_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ShareBookID() As Nullable(Of Integer)
        <Required>
        <Column("HPUT_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property HPUTBookID() As Nullable(Of Integer)

        <ForeignKey("MediaSpotTVResearchID")>
        Public Overridable Property MediaSpotTVResearch As Database.Entities.MediaSpotTVResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.MediaSpotTVResearchBook.Properties.ShareBookID.ToString

                    PropertyValue = Value

                    If PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Share book is invalid."

                    End If

                Case AdvantageFramework.Database.Entities.MediaSpotTVResearchBook.Properties.HPUTBookID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If PropertyValue = Me.ShareBookID Then

                            IsValid = False

                            ErrorText = "HPUT Book cannot be the same as the share book."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
