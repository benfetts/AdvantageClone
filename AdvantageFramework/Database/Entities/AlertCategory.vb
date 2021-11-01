Namespace Database.Entities

	<Table("ALERT_CATEGORY")>
	Public Class AlertCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            AlertTypeID
            Description
            AllowPrompt
            GroupLevelSecurityID
            HasPDFAttachment
            IsUserDefined
            IsInactive

            Alerts
            AlertType
            AlertGroupCategories
            AlertStates

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
		<Required>
        <Column("ALERT_CAT_ID")>
        Public Property ID() As Integer
        <Column("ALERT_TYPE_ID")>
        Public Property AlertTypeID() As Nullable(Of Integer)
        <Required>
		<MaxLength(40)>
		<Column("ALERT_DESC", TypeName:="varchar")>
		Public Property Description() As String
		<Column("PROMPT")>
		Public Property AllowPrompt() As Nullable(Of Short)
		<Column("GROUP_LVL_SECURITY")>
		Public Property GroupLevelSecurityID() As Nullable(Of Short)
        <Column("PDF_ATTACHMENT")>
        Public Property HasPDFAttachment() As Nullable(Of Short)
        <Column("IS_USER_DEFINED")>
        Public Property IsUserDefined As Nullable(Of Boolean) = False
        <Column("IS_INACTIVE")>
        Public Property IsInactive As Nullable(Of Boolean) = False

        Public Overridable Property Alerts As ICollection(Of Database.Entities.Alert)
        Public Overridable Property AlertType As Database.Entities.AlertType
        Public Overridable Property AlertGroupCategories As ICollection(Of Database.Entities.AlertGroupCategory)
        Public Overridable Property AlertStates As ICollection(Of Database.Entities.AlertState)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
