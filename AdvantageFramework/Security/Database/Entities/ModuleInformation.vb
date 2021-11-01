Namespace Security.Database.Entities

	<Table("SEC_MODULE_INFO")>
	Public Class ModuleInformation
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ImageName
			SortOrder
			HasCustomPermission
			WebvantageURL
			WebvantageImagePathActive
			WebvantageImagePath
			ApplicationName
			MenuName
			ApplicationCode
			CommandString
			IconIndex
			AllowMultipleInstances
			DesktopObjectName
			DesktopObjectSize
			ReportURL
			ReportImagePathActive
			ReportImagePath
			ReportDescription
			ReportPreviewLocation
			ReportIsLocked
			WebvantageLargeImagePath
			ReportLargeImagePath
			Modules

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SEC_MODULE_INFO_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("IMAGENAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImageName() As String
		<Required>
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Integer
		<Required>
		<Column("CUSTOM_PERMISSION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasCustomPermission() As Boolean
		<Required>
		<MaxLength(100)>
		<Column("WV_URL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebvantageURL() As String
		<Required>
		<MaxLength(100)>
		<Column("WV_IMAGEPATHACTIVE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebvantageImagePathActive() As String
		<Required>
		<MaxLength(100)>
		<Column("WV_IMAGEPATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebvantageImagePath() As String
		<Required>
		<MaxLength(100)>
		<Column("PB_APPNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplicationName() As String
		<Required>
		<MaxLength(100)>
		<Column("PB_MENU", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MenuName() As String
		<Required>
		<MaxLength(10)>
		<Column("PB_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplicationCode() As String
		<Required>
		<MaxLength(128)>
		<Column("PB_COMMAND_STRING", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommandString() As String
		<Required>
		<Column("PB_ICON")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IconIndex() As Integer
		<Required>
		<Column("PB_ALLOW_MULTI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AllowMultipleInstances() As Integer
		<Required>
		<MaxLength(50)>
		<Column("WV_DO_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DesktopObjectName() As String
		<Required>
		<Column("WV_DO_DSIZE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DesktopObjectSize() As Integer
		<Required>
		<MaxLength(50)>
		<Column("WV_RPT_URL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportURL() As String
		<Required>
		<MaxLength(50)>
		<Column("WV_RPT_IMAGEPATHACTIVE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportImagePathActive() As String
		<Required>
		<MaxLength(50)>
		<Column("WV_RPT_IMAGEPATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportImagePath() As String
		<Required>
		<MaxLength(2000)>
		<Column("WV_RPT_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportDescription() As String
		<Required>
		<MaxLength(255)>
		<Column("WV_RPT_PREVIEWLOCATION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportPreviewLocation() As String
		<Required>
		<Column("WV_RPT_LOCKED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportIsLocked() As Boolean
		<Required>
		<MaxLength(50)>
		<Column("WV_IMAGEPATHLARGE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebvantageLargeImagePath() As String
		<Required>
		<MaxLength(50)>
		<Column("WV_RPT_IMAGEPATHLARGE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportLargeImagePath() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
