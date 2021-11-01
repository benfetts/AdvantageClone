Namespace Security.Classes

    <Serializable()>
    Public Class MenuBuilder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Applications
            Code
            Description
            IsInactive
            IsMenuItem
            IsCategory
            IsApplication
            IsReport
            IsDesktopObject
            IsDashQuery
            ImageName
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
            ParentModuleCode
            SubMmodules
        End Enum

#End Region

#Region " Variables "

        Private _Applications() As AdvantageFramework.Security.Application = Nothing
        Private _Code As String = Nothing
        Private _Description As String = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _IsMenuItem As Boolean = Nothing
        Private _IsCategory As Boolean = Nothing
        Private _IsApplication As Boolean = Nothing
        Private _IsReport As Boolean = Nothing
        Private _IsDesktopObject As Boolean = Nothing
        Private _IsDashQuery As Boolean = Nothing
        Private _ImageName As String = Nothing
        Private _HasCustomPermission As Boolean = Nothing
        Private _WebvantageURL As String = Nothing
        Private _WebvantageImagePathActive As String = Nothing
        Private _WebvantageImagePath As String = Nothing
        Private _ApplicationName As String = Nothing
        Private _MenuName As String = Nothing
        Private _ApplicationCode As String = Nothing
        Private _CommandString As String = Nothing
        Private _IconIndex As Integer = Nothing
        Private _AllowMultipleInstances As Integer = Nothing
        Private _DesktopObjectName As String = Nothing
        Private _DesktopObjectSize As Integer = Nothing
        Private _ReportURL As String = Nothing
        Private _ReportImagePathActive As String = Nothing
        Private _ReportImagePath As String = Nothing
        Private _ReportDescription As String = Nothing
        Private _ReportPreviewLocation As String = Nothing
        Private _ReportIsLocked As Boolean = Nothing
        Private _WebvantageLargeImagePath As String = Nothing
        Private _ReportLargeImagePath As String = Nothing
        Private _ParentModuleCode As String = Nothing
        Private _SubModules As Generic.List(Of MenuBuilder) = Nothing

#End Region

#Region " Properties "

        Public Property Applications() As AdvantageFramework.Security.Application()
            Get
                Applications = _Applications
            End Get
            Set(ByVal value As AdvantageFramework.Security.Application())
                _Applications = value
            End Set
        End Property
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Boolean)
                _IsInactive = value
            End Set
        End Property
        Public Property IsMenuItem() As Boolean
            Get
                IsMenuItem = _IsMenuItem
            End Get
            Set(ByVal value As Boolean)
                _IsMenuItem = value
            End Set
        End Property
        Public Property IsCategory() As Boolean
            Get
                IsCategory = _IsCategory
            End Get
            Set(ByVal value As Boolean)
                _IsCategory = value
            End Set
        End Property
        Public Property IsApplication() As Boolean
            Get
                IsApplication = _IsApplication
            End Get
            Set(ByVal value As Boolean)
                _IsApplication = value
            End Set
        End Property
        Public Property IsReport() As Boolean
            Get
                IsReport = _IsReport
            End Get
            Set(ByVal value As Boolean)
                _IsReport = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property IsDesktopObject() As Boolean
            Get
                IsDesktopObject = _IsDesktopObject
            End Get
            Set(ByVal value As Boolean)
                _IsDesktopObject = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property IsDashQuery() As Boolean
            Get
                IsDashQuery = _IsDashQuery
            End Get
            Set(ByVal value As Boolean)
                _IsDashQuery = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ImageName() As String
            Get
                ImageName = _ImageName
            End Get
            Set(value As String)
                _ImageName = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property HasCustomPermission() As Boolean
            Get
                HasCustomPermission = _HasCustomPermission
            End Get
            Set(value As Boolean)
                _HasCustomPermission = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property WebvantageURL() As String
            Get
                WebvantageURL = _WebvantageURL
            End Get
            Set(value As String)
                _WebvantageURL = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property WebvantageImagePathActive() As String
            Get
                WebvantageImagePathActive = _WebvantageImagePathActive
            End Get
            Set(value As String)
                _WebvantageImagePathActive = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property WebvantageImagePath() As String
            Get
                WebvantageImagePath = _WebvantageImagePath
            End Get
            Set(value As String)
                _WebvantageImagePath = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ApplicationName() As String
            Get
                ApplicationName = _ApplicationName
            End Get
            Set(value As String)
                _ApplicationName = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property MenuName() As String
            Get
                MenuName = _MenuName
            End Get
            Set(value As String)
                _MenuName = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ApplicationCode() As String
            Get
                ApplicationCode = _ApplicationCode
            End Get
            Set(value As String)
                _ApplicationCode = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property CommandString() As String
            Get
                CommandString = _CommandString
            End Get
            Set(value As String)
                _CommandString = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property IconIndex() As Integer
            Get
                IconIndex = _IconIndex
            End Get
            Set(value As Integer)
                _IconIndex = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property AllowMultipleInstances() As Integer
            Get
                AllowMultipleInstances = _AllowMultipleInstances
            End Get
            Set(value As Integer)
                _AllowMultipleInstances = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property DesktopObjectName() As String
            Get
                DesktopObjectName = _DesktopObjectName
            End Get
            Set(value As String)
                _DesktopObjectName = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property DesktopObjectSize() As Integer
            Get
                DesktopObjectSize = _DesktopObjectSize
            End Get
            Set(value As Integer)
                _DesktopObjectSize = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportURL() As String
            Get
                ReportURL = _ReportURL
            End Get
            Set(value As String)
                _ReportURL = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportImagePathActive() As String
            Get
                ReportImagePathActive = _ReportImagePathActive
            End Get
            Set(value As String)
                _ReportImagePathActive = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportImagePath() As String
            Get
                ReportImagePath = _ReportImagePath
            End Get
            Set(value As String)
                _ReportImagePath = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportDescription() As String
            Get
                ReportDescription = _ReportDescription
            End Get
            Set(value As String)
                _ReportDescription = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportPreviewLocation() As String
            Get
                ReportPreviewLocation = _ReportPreviewLocation
            End Get
            Set(value As String)
                _ReportPreviewLocation = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportIsLocked() As Boolean
            Get
                ReportIsLocked = _ReportIsLocked
            End Get
            Set(value As Boolean)
                _ReportIsLocked = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property WebvantageLargeImagePath() As String
            Get
                WebvantageLargeImagePath = _WebvantageLargeImagePath
            End Get
            Set(value As String)
                _WebvantageLargeImagePath = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ReportLargeImagePath() As String
            Get
                ReportLargeImagePath = _ReportLargeImagePath
            End Get
            Set(value As String)
                _ReportLargeImagePath = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property ParentModuleCode() As String
            Get
                ParentModuleCode = _ParentModuleCode
            End Get
            Set(value As String)
                _ParentModuleCode = value
            End Set
        End Property
        <System.ComponentModel.DisplayName("")>
        Public Property SubModules() As Generic.List(Of MenuBuilder)
            Get
                SubModules = _SubModules
            End Get
            Set(ByVal value As Generic.List(Of MenuBuilder))
                _SubModules = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView), ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView, ByVal ParamArray Applications() As AdvantageFramework.Security.Application)

            _Applications = Applications
            _Code = [Module].ModuleCode
            _Description = [Module].ModuleDescription
            _IsInactive = [Module].IsInactive
            _IsMenuItem = [Module].IsMenuItem
            _IsCategory = [Module].IsCategory
            _IsApplication = [Module].IsApplication
            _IsReport = [Module].IsReport
            _IsDesktopObject = [Module].IsDesktopObject
            _IsDashQuery = [Module].IsDashQuery
            _ImageName = [Module].ImageName
            _HasCustomPermission = [Module].HasCustomPermission
            _WebvantageURL = [Module].WebvantageURL
            _WebvantageImagePathActive = [Module].WebvantageImagePathActive
            _WebvantageImagePath = [Module].WebvantageImagePath
            _ApplicationName = [Module].AdvantageApplicationName
            _MenuName = [Module].AdvantageMenuName
            _ApplicationCode = [Module].AdvantageApplicationCode
            _CommandString = [Module].AdvantageCommandString
            _IconIndex = [Module].AdvantageIconIndex
            _AllowMultipleInstances = [Module].AdvantageAllowMultipleInstances
            _DesktopObjectName = [Module].DesktopObjectName
            _DesktopObjectSize = [Module].DesktopObjectSize
            _ReportURL = [Module].ReportURL
            _ReportImagePathActive = [Module].ReportImagePathActive
            _ReportImagePath = [Module].ReportImagePath
            _ReportDescription = [Module].ReportDescription
            _ReportPreviewLocation = [Module].ReportPreviewLocation
            _ReportIsLocked = [Module].ReportIsLocked
            _WebvantageLargeImagePath = [Module].WebvantageLargeImagePath
            _ReportLargeImagePath = [Module].ReportLargeImagePath
            _ParentModuleCode = [Module].ParentModuleCode

            _SubModules = New Generic.List(Of MenuBuilder)

            For Each ChildModule In ModuleList.Where(Function(M) M.ParentModuleID IsNot Nothing AndAlso M.ParentModuleID = [Module].ModuleID).OrderBy(Function(M) M.SortOrder).ToList

                If _SubModules.Any(Function(MB) MB.Code = ChildModule.ModuleCode) = False Then

                    _SubModules.Add(New MenuBuilder(ModuleList, ChildModule, ModuleList.Where(Function(MV) MV.ModuleCode = [Module].ModuleCode).Select(Function(MV) CType(MV.ApplicationID, AdvantageFramework.Security.Application)).ToArray))

                End If

            Next

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code

        End Function

#End Region

    End Class

End Namespace

