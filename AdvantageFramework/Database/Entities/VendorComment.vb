Namespace Database.Entities

	<Table("VENDOR_COMMENTS")>
	Public Class VendorComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			VendorCode
			MaterialNotes
			CloseInfo
			RateInfo
			MiscInfo
			PositionInfo
			Instructions
			FooterInfo
			UseFooter
			DeliveryGeneralInformation
			AcceptedMedia
			PreferenceMaterial
			EFileInfo
			FTPUserName
			FTPPassword
			FTPDirectory
			Vendor

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<Column("MATL_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialNotes() As String
		<Column("CLOSE_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseInfo() As String
		<Column("RATE_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateInfo() As String
		<Column("MISC_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MiscInfo() As String
		<Column("POSITION_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PositionInfo() As String
		<Column("INSTRUCTIONS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Instructions() As String
		<Column("FOOTER_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FooterInfo() As String
		<Column("USE_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseFooter() As Nullable(Of Short)
		<Column("DLVRY_GEN_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeliveryGeneralInformation() As String
		<MaxLength(250)>
		<Column("ACCEPTED_MEDIA", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AcceptedMedia() As String
		<MaxLength(250)>
		<Column("PREF_MATL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PreferenceMaterial() As String
		<MaxLength(250)>
		<Column("EFILE_INFO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EFileInfo() As String
		<MaxLength(100)>
		<Column("FTP_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPUserName() As String
		<MaxLength(100)>
		<Column("FTP_PW", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPPassword() As String
		<MaxLength(100)>
		<Column("FTP_DIR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FTPDirectory() As String

        <ForeignKey("VendorCode")>
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.VendorCode.ToString

        End Function

#End Region

	End Class

End Namespace
