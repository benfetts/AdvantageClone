Namespace Database.Entities

    <Table("CS_EXT_REVIEWER")>
    Public Class ConceptShareExternalReviewer
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            FirstName
            LastName
            EmailAddress
            ConceptShareUserID
            AlertID
            ConceptShareReviewID
            LastEmailed
            SequenceNumber

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <MaxLength(50)>
        <Column("FIRST_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FirstName() As String

        <Required>
        <MaxLength(50)>
        <Column("LAST_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LastName() As String

        <Required>
        <MaxLength(500)>
        <Column("EMAIL_ADDRESS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EmailAddress() As String

        <Column("CS_USERID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareUserID() As Nullable(Of Integer)

        <Required>
        <Column("ALERT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AlertID() As Integer

        <Required>
        <Column("CS_REVIEW_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ConceptShareReviewID() As Integer

        <Column("LAST_EMAILED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastEmailed() As Nullable(Of DateTime)

        <Column("SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmailAddress.ToString

        End Function

#End Region

    End Class

End Namespace
