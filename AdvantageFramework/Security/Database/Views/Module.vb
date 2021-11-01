Namespace Security.Database.Views

    <Table("V_SEC_MODULES")>
    Public Class ModuleView
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ApplicationID
            ApplicationName
            ApplicationDescription
            ModuleCode
            ModuleInformationID
            ModuleID
            ModuleDescription
            IsInactive
            IsMenuItem
            IsCategory
            IsApplication
            IsReport
            IsDesktopObject
            IsDashQuery
            ParentModuleID
            ReportIsLocked
            ReportPreviewLocation
            ReportDescription
            ReportImagePath
            ReportImagePathActive
            ReportURL
            DesktopObjectSize
            DesktopObjectName
            ImageName
            SortOrder
            HasCustomPermission
            WebvantageURL
            WebvantageImagePathActive
            WebvantageImagePath
            AdvantageApplicationName
            AdvantageMenuName
            AdvantageApplicationCode
            AdvantageCommandString
            AdvantageIconIndex
            AdvantageAllowMultipleInstances
            ID
            ReportLargeImagePath
            WebvantageLargeImagePath
            ParentModuleCode
            ParentModuleDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        <Column("ID")>
        Public Property ID() As Long
        <Column("ApplicationID")>
        Public Property ApplicationID() As Integer
        <Column("ApplicationName", TypeName:="varchar")>
        Public Property ApplicationName() As String
        <Column("ApplicationDescription", TypeName:="varchar")>
        Public Property ApplicationDescription() As String
        <Column("ModuleCode", TypeName:="varchar")>
        Public Property ModuleCode() As String
        <Column("ModuleInformationID")>
        Public Property ModuleInformationID() As Integer
        <Column("ModuleID")>
        Public Property ModuleID() As Integer
        <Column("ModuleDescription", TypeName:="varchar")>
        Public Property ModuleDescription() As String
        <Column("IsInactive")>
        Public Property IsInactive() As Boolean
        <Column("IsMenuItem")>
        Public Property IsMenuItem() As Boolean
        <Column("IsCategory")>
        Public Property IsCategory() As Boolean
        <Column("IsApplication")>
        Public Property IsApplication() As Boolean
        <Column("IsReport")>
        Public Property IsReport() As Boolean
        <Column("IsDesktopObject")>
        Public Property IsDesktopObject() As Boolean
        <Column("IsDashQuery")>
        Public Property IsDashQuery() As Boolean
        <Column("ParentModuleID")>
        Public Property ParentModuleID() As Nullable(Of Integer)
        <Column("ReportIsLocked")>
        Public Property ReportIsLocked() As Boolean
        <Column("ReportPreviewLocation", TypeName:="varchar")>
        Public Property ReportPreviewLocation() As String
        <Column("ReportDescription", TypeName:="varchar")>
        Public Property ReportDescription() As String
        <Column("ReportImagePath", TypeName:="varchar")>
        Public Property ReportImagePath() As String
        <Column("ReportImagePathActive", TypeName:="varchar")>
        Public Property ReportImagePathActive() As String
        <Column("ReportLargeImagePath", TypeName:="varchar")>
        Public Property ReportLargeImagePath() As String
        <Column("ReportURL", TypeName:="varchar")>
        Public Property ReportURL() As String
        <Column("DesktopObjectSize")>
        Public Property DesktopObjectSize() As Integer
        <Column("DesktopObjectName", TypeName:="varchar")>
        Public Property DesktopObjectName() As String
        <Column("ImageName", TypeName:="varchar")>
        Public Property ImageName() As String
        <Column("SortOrder")>
        Public Property SortOrder() As Integer
        <Column("HasCustomPermission")>
        Public Property HasCustomPermission() As Boolean
        <Column("WebvantageURL", TypeName:="varchar")>
        Public Property WebvantageURL() As String
        <Column("WebvantageImagePathActive", TypeName:="varchar")>
        Public Property WebvantageImagePathActive() As String
        <Column("WebvantageImagePath", TypeName:="varchar")>
        Public Property WebvantageImagePath() As String
        <Column("WebvantageLargeImagePath", TypeName:="varchar")>
        Public Property WebvantageLargeImagePath() As String
        <Column("AdvantageApplicationName", TypeName:="varchar")>
        Public Property AdvantageApplicationName() As String
        <Column("AdvantageMenuName", TypeName:="varchar")>
        Public Property AdvantageMenuName() As String
        <Column("AdvantageApplicationCode", TypeName:="varchar")>
        Public Property AdvantageApplicationCode() As String
        <Column("AdvantageCommandString", TypeName:="varchar")>
        Public Property AdvantageCommandString() As String
        <Column("AdvantageIconIndex")>
        Public Property AdvantageIconIndex() As Integer
        <Column("AdvantageAllowMultipleInstances")>
        Public Property AdvantageAllowMultipleInstances() As Integer
        <Column("ParentModuleCode", TypeName:="varchar")>
        Public Property ParentModuleCode() As String
        <Column("ParentModuleDescription", TypeName:="varchar")>
        Public Property ParentModuleDescription() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ApplicationID

        End Function

#End Region

    End Class

End Namespace
