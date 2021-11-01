Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Collections.Generic

#Region " Class Objects "

<Serializable()> _
Public Class UITheme

    Public Enum Themes

        Bootstrap
        Metro

    End Enum

    Public Property [Name] As String = ""
    Public Property [TelerikName] As String = ""
    Public Property [ImagePath] As String = ""
    Public Property [ImageFileNameName] As String = ""

    Sub New()
    End Sub

End Class

#End Region
<Serializable()> Public Class UserThemeSettings

#Region " Constants "

    Public Const DefaultWallpaper As String = "default_wallpaper.jpg"
    Public Const DefaultIcon As String = "Window_Icon.png"
    Public Const DefaultLogo As String = "aqualogo_FFFFFF.png"
    Public Const DefaultTelerikTheme As String = "Metro"
    Public Const DefaultBackgroundType As ImageType = ImageType.SolidColor
    Public Const DefaultBackgroundColor As String = "#2196F3"
    Public Const IconLimit As Integer = 81920
    Public Const LogoLimit As Integer = 204800
    Public Const WallpaperLimit As Integer = 614400
    Public Const EmployeeLimit As Integer = 512000

#End Region

#Region " Enum "

    Public Enum ImageType

        Logo = 0
        Wallpaper = 1
        SolidColor = 2
        Custom = 3
        Icon = 4
        EmployeePictrue = 5

    End Enum
    Public Enum ImageLevel

        Webvantage
        ClientPortal
        Agency
        Employee

    End Enum
    Public Enum CustomImageId

        WV_DEFAULT_ICON
        WV_DEFAULT_LOGO
        WV_DEFAULT_WP
        CP_DEFAULT_LOGO
        CP_DEFAULT_WP

    End Enum

    Public Enum AppThemes

        Bootstrap
        Metro

    End Enum
    Public Enum DevExpressThemes

        DxDefault
        MetropolisBlue
        Office2010Black
        Office2010Blue
        Office2010Silver
        Office2003Blue ' similar to Office2007
        Aqua 'similar to Windows7, WebBlue
        PlasticBlue
        SoftOrange
        Youthful
        BlackGlass

    End Enum

    Public Enum Layout
        TopMenu
        Simple
    End Enum

    Public Enum IconStyle
        Color = 0
        White = 1
        DarkGrey = 2
    End Enum

    Public Enum WorkspaceLogoPosition
        TopLeft = 0
        TopRight = 1
        BottomRight = 2
        BottomLeft = 3
        Center = 4
    End Enum

    Public Enum RadEditorToolBarShow
        Always = 1
        Never = 2
        OnFocus = 3
    End Enum


#End Region

#Region " Variables "

#End Region

#Region " Properties "

    Public Property TelerikTheme As String = DefaultTelerikTheme
    Public ReadOnly Property AppTheme() As String
        Get
            Return Me.SetAppTheme(Me.TelerikTheme)
        End Get
    End Property
    Public Property Agency_TelerikTheme As String = DefaultTelerikTheme
    Public ReadOnly Property Agency_AppTheme As String
        Get
            Return Me.SetAppTheme(Me.TelerikTheme)
        End Get
    End Property
    Public ReadOnly Property DevExpressTheme As DevExpressThemes
        Get
            Return Me.SetDevExpressTheme()
        End Get
    End Property

    Public Property BackgroundType As ImageType = ImageType.Wallpaper
    Public Property Logo As String = DefaultLogo
    Public Property Wallpaper As String = DefaultWallpaper
    Public Property CustomWallpaper As String = ""
    Public Property Icon As String = DefaultIcon
    Public Property BackgroundColor As String = "#2196F3"
    Public Property TextColor As String = ""
    Public Property FullPathToWallpaper As String = ""
    Public Property FullPathToLogo As String = ""
    Public Property FullPathToIcon As String = ""
    Public Property UseBackgroundColorOnSignInPage As Boolean = True
    Public Property FloatDesktopObjects As Boolean = True
    Public Property SingleNodeMainMenu As Boolean = False
    Public Property ClickToOpenAppMenu As Boolean = False
    Public Property ClickToOpenUserMenu As Boolean = True
    Public Property EnableWeather As Boolean = False
    Public Property UseLayout As Layout = Layout.Simple
    Public Property TimeZoneID As String = String.Empty
    Public Property ShowRadEditorToolbar As RadEditorToolBarShow = RadEditorToolBarShow.OnFocus
    Public Property SimpleLayoutBackgroundColor As String = "#2196F3"
    Public Property SimpleLayoutSideBarColor As String = "#2196F3"
    Public Property SimpleLayoutIconStyle As IconStyle = IconStyle.White
    Public Property SimpleLayoutShowNewMenu As Boolean = True
    Public Property SimpleLayoutShowAppMenu As Boolean = True
    Public Property ShowDatabaseName As Boolean = False
    Public Property IsDarkMode As Boolean = False
    Public ReadOnly Property SimpleLayoutDarkHighlightColor As String
        Get
            Try

                Dim Colors As New AdvantageFramework.Web.Presentation.Colors

                Return Colors.LoadDarkColorHexByHex(SimpleLayoutSideBarColor)

            Catch ex As Exception

                Return SimpleLayoutSideBarColor

            End Try

        End Get
    End Property
    Public ReadOnly Property SimpleLayoutLightHighlightColor As String
        Get
            Try

                Dim Colors As New AdvantageFramework.Web.Presentation.Colors

                Return Colors.LoadLightColorHexByHex(SimpleLayoutSideBarColor)

            Catch ex As Exception

                Return SimpleLayoutSideBarColor

            End Try

        End Get
    End Property

    Public ReadOnly Property CssFile As String
        Get
            Try

                Dim PrimaryColors As New Dictionary(Of String, String)
                Dim Colors As New AdvantageFramework.Web.Presentation.Colors

                'PrimaryColors = Colors.LoadColorsDictionary(AdvantageFramework.Web.Presentation.Colors.ColorFamily.Dark)

                Dim Name As String '= PrimaryColors.Item(SimpleLayoutSideBarColor.ToUpper).ToString().Replace(" ", "")

                If SimpleLayoutSideBarColor.ToUpper = "#F44336" Then
                    Name = "Red"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#2196F3" Then
                    Name = "Blue"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#FFEB3B" Then
                    Name = "Yellow"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#4CAF50" Then
                    Name = "Green"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#808080" Then
                    Name = "Grey"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#FF9800" Then
                    Name = "Orange"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#795548" Then
                    Name = "Brown"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#009688" Then
                    Name = "Teal"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#00BCD4" Then
                    Name = "Cyan"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#3F51B5" Then
                    Name = "Indigo"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#EFC1B4" Then
                    Name = "Peach"
                ElseIf SimpleLayoutSideBarColor.ToUpper = "#2A579A" Then
                    Name = "Advantage"
                Else
                    Name = "Advantage"
                End If

                Return "Bootstrap." & Name & ".css"

            Catch ex As Exception

                Return "Bootstrap.Advantage.css"

            End Try

        End Get
    End Property

    Public Property Agency_UseAgencyBranding As Boolean = False
    Public Property Agency_Logo As String = DefaultLogo
    Public Property Agency_Icon As String = DefaultIcon
    Public Property Agency_BackgroundType As ImageType = ImageType.Wallpaper
    Public Property Agency_Wallpaper As String = DefaultWallpaper
    Public Property Agency_AllowUserToSetColors As Boolean = False
    Public Property Agency_BackgroundColor As String = DefaultBackgroundColor
    Public Property Agency_TextColor As String = DefaultBackgroundColor
    Public Property Agency_AllowUserToSetTheme As Boolean = False
    Public Property Agency_FloatDesktopObjects As Boolean = True
    Public Property Agency_SingleNodeMainMenu As Boolean = False
    Public Property Agency_ClickToOpenAppMenu As Boolean = False
    Public Property Agency_ClickToOpenUserMenu As Boolean = True
    Public Property Agency_FullPathToWallpaper As String = ""
    Public Property Agency_FullPathToLogo As String = ""
    Public Property Agency_EnableWeather As Boolean = False

    Public Property Agency_SimpleLayoutBackgroundColor As String = "#2196F3"
    Public Property Agency_SimpleLayoutSideBarColor As String = "#2196F3"
    Public Property Agency_SimpleLayoutIconStyle As IconStyle = IconStyle.White

    Public Property Agency_ShowLogoOnWorkspace As Boolean = False
    Public Property Agency_WorkspaceLogoPosition As WorkspaceLogoPosition = WorkspaceLogoPosition.Center
    Public Property Agency_UseBackgroundColorOnSignInPage As Boolean = False

    Public Property ClientPortal_IsUsingDefaultClientPortalLogo As Boolean = False
    Public Property ClientPortal_IsUsingDefaultClientPortalWallpaper As Boolean = False

#End Region

#Region " Methods "

    Public Function BindWallpaperComboBox(ByRef rcb As Telerik.Web.UI.RadComboBox) As Boolean
        rcb.Items.Clear()
        Dim wp As Dictionary(Of String, String)
        wp = Me.LoadWebvantageWallpapers()
        Dim item As KeyValuePair(Of String, String)
        For Each item In wp
            Dim RcbItem As New Telerik.Web.UI.RadComboBoxItem
            With RcbItem
                .Value = item.Value
                .Text = item.Key
                .ImageUrl = "Images/Wallpaper/ItemSize/" & item.Value
            End With
            rcb.Items.Add(RcbItem)
        Next
    End Function
    Public Function BindThemeComboBox(ByRef rcb As Telerik.Web.UI.RadComboBox, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            rcb.Items.Clear()
            For Each theme As UITheme In Me.LoadWebvantageThemes()
                Dim item As New Telerik.Web.UI.RadComboBoxItem
                With item
                    .Text = theme.Name
                    .Value = theme.TelerikName
                    .ImageUrl = theme.ImagePath & theme.ImageFileNameName
                End With
                rcb.Items.Add(item)
            Next
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function
    Public Function BindColorPicker(ByRef cp As Telerik.Web.UI.RadColorPicker, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim Colors As New AdvantageFramework.Web.Presentation.Colors
            cp.Items.Clear()
            For Each c As String In Colors.LoadColors()
                Dim item As New Telerik.Web.UI.ColorPickerItem
                item.Value = ColorTranslator.FromHtml(c)
                cp.Items.Add(item)
            Next
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function
    Public Function BindPrimaryColorPicker(ByRef cp As Telerik.Web.UI.RadColorPicker, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            cp.Items.Clear()
            Dim Colors As New AdvantageFramework.Web.Presentation.Colors
            For Each Color In Colors.LoadColors()

                Dim item As New Telerik.Web.UI.ColorPickerItem
                item.Value = ColorTranslator.FromHtml(Color)
                cp.Items.Add(item)

            Next
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function

    Private Function LoadWebvantageWallpapers() As Dictionary(Of String, String)
        Dim dict As New Dictionary(Of String, String)
        With dict
        End With
        Return dict
    End Function
    Private Function LoadWebvantageThemes() As List(Of UITheme)
        Dim list As New List(Of UITheme)

        'list.Add(Me.AddTheme("Large", "Bootstrap", "Images/Theme/", "Bootstrap.png"))
        list.Add(Me.AddTheme("Small", "Metro", "Images/Theme/", "Metro.png"))

        Return list

    End Function

    Private Function AddTheme(ByVal Text As String, ByVal Value As String, ByVal ImagePath As String, ByVal ImageFileNameName As String) As UITheme
        Dim t As New UITheme
        With t
            .Name = Text
            .TelerikName = Value
            .ImagePath = ImagePath
            .ImageFileNameName = ImageFileNameName
        End With
        Return t
    End Function
    Private Function SetAppTheme(ByVal value As String) As String
        'Select Case value
        '    Case "Bootstrap", "Metro"
        '        Return value
        '    Case Else
        Return DefaultTelerikTheme
        'End Select
    End Function
    Private Function SetDevExpressTheme() As DevExpressThemes

        Return DevExpressThemes.MetropolisBlue

    End Function

    Public Sub New()

    End Sub

#End Region

#Region " Classes "

    <Serializable()>
    Public Class ColorsCodes

        Public Property Base As String = String.Empty
        Public Property Dark As String = String.Empty
        Public Property Darker As String = String.Empty
        Public Property Light As String = String.Empty
        Public Property Lighter As String = String.Empty

        Sub New()

        End Sub

    End Class

#End Region

End Class
<Serializable()> Public Class UserTheme

#Region " Constants "

    Public Const DefaultTelerikTheme As String = "Metro"

#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Public Settings As UserThemeSettings

#End Region

#Region " Properties "

    Private Property _LocalKey As String = cAppVars.Application.MY_SETTINGS.ToString() & "_Dev_vNEXT"
    Private Property _SettingKey As cAppVars.Application = cAppVars.Application.MY_SETTINGS
    Private Property _EmpCode As String = ""
    Private Property _UserCode As String = ""
    Private Property _ConnString As String = ""
    Private Property _IsClientPortal As Boolean = False
    Private Property _ClientPortalClCode As String = ""

#End Region

#Region " Methods "

    Private Function FileIsInTempFolder(ByVal Filename As String) As Boolean
        Filename = Filename.Trim()
        If Filename = "" Then
            Return False
        Else
            Return File.Exists(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & Filename)
        End If
    End Function
    Private Function GetWallpaperFromDatabaseAndSaveToTemp(ByVal AppImageLevel As UserThemeSettings.ImageLevel,
    ByVal Filename As String,
    Optional ByRef ErrorMessage As String = "") As Boolean
        If Filename = Settings.DefaultWallpaper Then Exit Function
        Dim ReturnValue As Boolean = False
        Dim SQL As String = ""
        Select Case AppImageLevel
            Case UserThemeSettings.ImageLevel.Webvantage
                'only wallpaper allowed here
                SQL = "SELECT EMP_WALLPAPER AS BINARY_IMAGE_VALUE FROM EMPLOYEE_PICTURE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;"
            Case UserThemeSettings.ImageLevel.Agency
                SQL = "SELECT BINARY_IMAGE_VALUE FROM AGY_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CODE = 'WV_DEFAULT_WP';"
            Case UserThemeSettings.ImageLevel.ClientPortal
                If Me._ClientPortalClCode = "" Then
                    SQL = "SELECT BINARY_IMAGE_WP AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT IS NULL;"
                Else
                    SQL = "SELECT BINARY_IMAGE_WP AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT = '" & Me._ClientPortalClCode & "';"
                End If
            Case UserThemeSettings.ImageLevel.Employee
                SQL = "SELECT EMP_WALLPAPER AS BINARY_IMAGE_VALUE FROM EMPLOYEE_PICTURE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;"
        End Select
        If SQL <> "" Then
            Dim ImageAsBytes() As Byte = Nothing
            Using MyConn As New SqlConnection(Me._ConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = SQL
                    .Connection = MyConn
                End With
                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = Me._EmpCode
                MyCommand.Parameters.Add(pEmpCode)
                MyConn.Open()
                Dim Reader As SqlDataReader
                Reader = MyCommand.ExecuteReader()
                If Reader.HasRows = True Then
                    Do While Reader.Read()
                        If IsDBNull(Reader("BINARY_IMAGE_VALUE")) = False Then
                            ImageAsBytes = CType(Reader("BINARY_IMAGE_VALUE"), Byte())
                            Exit Do
                        End If
                    Loop
                End If
            End Using
            If Not ImageAsBytes Is Nothing Then
                Dim TheImage As System.Drawing.Image
                Dim ms As New MemoryStream(ImageAsBytes)
                TheImage = System.Drawing.Image.FromStream(ms)
                If Not TheImage Is Nothing Then
                    Dim TheImageFormat As System.Drawing.Imaging.ImageFormat
                    If Filename.ToLower().Contains("jpeg") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
                    ElseIf Filename.ToLower().Contains("jpg") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg
                    ElseIf Filename.ToLower().Contains("gif") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Gif
                    ElseIf Filename.ToLower().Contains("ico") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Icon
                    ElseIf Filename.ToLower().Contains("bmp") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Bmp
                    ElseIf Filename.ToLower().Contains("png") = True Then
                        TheImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    Else
                        TheImageFormat = TheImage.RawFormat
                    End If
                    TheImage.Save(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & Filename, TheImageFormat)
                    ReturnValue = True
                End If
            End If
        End If
        Return ReturnValue
    End Function
    Private Function GetLogoFromDatabaseAndSaveToTemp(ByVal AppImageLevel As UserThemeSettings.ImageLevel,
                                                        ByVal Filename As String,
                                                        Optional ByRef ErrorMessage As String = "") As Boolean
        If Filename = Settings.DefaultLogo Then Exit Function
        Dim ReturnValue As Boolean = False
        Dim SQL As String = ""
        Select Case AppImageLevel
            Case UserThemeSettings.ImageLevel.Agency
                SQL = "SELECT BINARY_IMAGE_VALUE FROM AGY_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CODE = 'WV_DEFAULT_LOGO';"
            Case UserThemeSettings.ImageLevel.ClientPortal
                If Me._ClientPortalClCode = "" Or Settings.Agency_UseAgencyBranding = False Then
                    SQL = "SELECT BINARY_IMAGE_LOGO AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT IS NULL;"
                Else
                    SQL = "SELECT BINARY_IMAGE_LOGO AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT = '" & Me._ClientPortalClCode & "';"
                End If
        End Select
        If SQL <> "" Then
            Dim ImageAsBytes() As Byte = Nothing
            Using MyConn As New SqlConnection(Me._ConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = SQL
                    .Connection = MyConn
                End With
                MyConn.Open()
                Dim Reader As SqlDataReader
                Reader = MyCommand.ExecuteReader()
                If Reader.HasRows = True Then
                    Do While Reader.Read()
                        If IsDBNull(Reader("BINARY_IMAGE_VALUE")) = False Then
                            ImageAsBytes = CType(Reader("BINARY_IMAGE_VALUE"), Byte())
                            Exit Do
                        End If
                    Loop
                End If
            End Using
            If Not ImageAsBytes Is Nothing Then
                Dim TheImage As System.Drawing.Image
                Dim ms As New MemoryStream(ImageAsBytes)
                Try
                    TheImage = System.Drawing.Image.FromStream(ms)
                Catch ex As Exception
                End Try
                If Not TheImage Is Nothing Then
                    TheImage.Save(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & Filename, TheImage.RawFormat)
                    ReturnValue = True
                End If
            End If
        End If
        Return ReturnValue
    End Function
    Private Function GetIconFromDatabaseAndSaveToTemp(ByVal AppImageLevel As UserThemeSettings.ImageLevel,
    ByVal Filename As String,
    Optional ByRef ErrorMessage As String = "") As Boolean
        Dim ReturnValue As Boolean = False
        Dim SQL As String = ""
        Select Case AppImageLevel
            Case UserThemeSettings.ImageLevel.Agency
                SQL = "SELECT BINARY_IMAGE_VALUE FROM AGY_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CODE = 'WV_DEFAULT_ICON';"
            Case UserThemeSettings.ImageLevel.ClientPortal
                If Me._ClientPortalClCode = "" Or Settings.Agency_UseAgencyBranding = False Then
                    SQL = "SELECT BINARY_IMAGE_ICON AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT IS NULL;"
                Else
                    SQL = "SELECT BINARY_IMAGE_ICON AS BINARY_IMAGE_VALUE FROM CP_BINARY_IMAGES WITH(NOLOCK) WHERE BINARY_IMAGE_CLIENT = '" & Me._ClientPortalClCode & "';"
                End If
        End Select
        If SQL <> "" Then
            Dim ImageAsBytes() As Byte = Nothing
            Using MyConn As New SqlConnection(Me._ConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = SQL
                    .Connection = MyConn
                End With
                MyConn.Open()
                Dim Reader As SqlDataReader
                Reader = MyCommand.ExecuteReader()
                If Reader.HasRows = True Then
                    Do While Reader.Read()
                        If IsDBNull(Reader("BINARY_IMAGE_VALUE")) = False Then
                            ImageAsBytes = CType(Reader("BINARY_IMAGE_VALUE"), Byte())
                            Exit Do
                        End If
                    Loop
                End If
            End Using
            If Not ImageAsBytes Is Nothing Then
                Dim TheImage As System.Drawing.Image
                Dim ms As New MemoryStream(ImageAsBytes)
                TheImage = System.Drawing.Image.FromStream(ms)
                If Not TheImage Is Nothing Then
                    TheImage.Save(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & Filename, TheImage.RawFormat)
                    ReturnValue = True
                End If
            End If
        End If
        Return ReturnValue
    End Function
    Public Sub Save()
        Me.SaveDatabase()
        'Me.SaveCookie()
        'Me.SaveSession()
    End Sub
    Public Sub Load()
        If HttpContext.Current.Session(Me._LocalKey) Is Nothing Then
            Me.LoadFromDatabase()
            Me.SaveSession()
        Else
            Me.LoadFromSession()
        End If
    End Sub
    Public Sub Reload()
        Me.DeleteSession()
        Me.DeleteCookie()
        Me.Load()
        Me.SaveCookie()
    End Sub
    Private Sub SaveSession()
        HttpContext.Current.Session(Me._LocalKey) = Me.Settings
    End Sub
    Private Sub SaveCookie()
        'Me.DeleteCookie()
        Dim formatter As New LosFormatter()
        Dim c As New System.Web.HttpCookie(Me._LocalKey)
        Using writer As New StringWriter()
            formatter.Serialize(writer, Settings)
            c.Value = writer.ToString()
            c.Expires = DateTime.Now.AddDays(7)
        End Using
        HttpContext.Current.Response.Cookies.Add(c)
    End Sub
    Private Sub SaveDatabase()

        Dim oAppVars As New cAppVars(Me._SettingKey)
        With oAppVars

            .getAllAppVars()

            .setAppVar("WALLPAPER", Settings.Wallpaper, "String")
            .setAppVar("MY_WALLPAPER", Settings.Wallpaper, "String")
            .setAppVar("TELERIK_THEME", Settings.TelerikTheme, "String")
            .setAppVar("BG_COLOR", Settings.BackgroundColor, "String")
            .setAppVar("TEXT_COLOR", Settings.TextColor, "String")
            .setAppVar("BG_TYPE", Settings.BackgroundType, "String")
            .setAppVar("USE_WALLPAPER_ON_SIGN_IN", Settings.UseBackgroundColorOnSignInPage.ToString(), "String")
            .setAppVar("SINGLE_NODE_MAIN_MENU", Settings.SingleNodeMainMenu.ToString(), "String")
            .setAppVar("FLOAT_DESKTOP_OBJECTS", Settings.FloatDesktopObjects.ToString(), "String")
            .setAppVar("CLICK_OPEN_APP_MENU", Settings.ClickToOpenAppMenu, "String")
            .setAppVar("CLICK_OPEN_USER_MENU", Settings.ClickToOpenUserMenu, "String")
            .setAppVar("LOGO", Settings.Logo, "String")
            .setAppVar("SIGN_IN_LOGO", Settings.Logo, "String")
            .setAppVar("ENABLE_WEATHER", Settings.EnableWeather, "String")
            .setAppVar("LAYOUT_TYPE", "1", "Integer")
            .setAppVar("TIME_ZONE_ID", Settings.TimeZoneID, "String")

            .setAppVar("SMPL_ICON", CType(Settings.SimpleLayoutIconStyle, Integer), "Integer")
            .setAppVar("SMPL_SIDEBR", Settings.SimpleLayoutSideBarColor, "String")
            .setAppVar("SMPL_BG_COLOR", Settings.SimpleLayoutBackgroundColor, "String")

            .setAppVar("SMPL_MENU_NEW", Settings.SimpleLayoutShowNewMenu.ToString(), "String")
            .setAppVar("SMPL_MENU_APPS", Settings.SimpleLayoutShowAppMenu.ToString(), "String")
            .setAppVar("EDITOR_SHOW", CType(Settings.ShowRadEditorToolbar, Integer), "Integer")
            .setAppVar("SHOW_DB_NAME", Settings.ShowDatabaseName, "String")
            .setAppVar("IS_DARK_MODE", Settings.IsDarkMode, "Boolean")

            .SaveAllAppVars()

        End With

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnString, Me._UserCode)

                If String.IsNullOrWhiteSpace(Settings.TimeZoneID) = True Then

                    If MiscFN.IsClientPortal = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE EMPLOYEE SET TIME_ZONE_ID = NULL WHERE EMP_CODE = '{0}';", Me._EmpCode))

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CP_USER SET TIME_ZONE_ID = NULL WHERE CDP_CONTACT_ID = {0};", HttpContext.Current.Session("UserID")))

                    End If

                Else

                    If MiscFN.IsClientPortal = False Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE EMPLOYEE SET TIME_ZONE_ID = '{0}' WHERE EMP_CODE = '{1}';", Settings.TimeZoneID, Me._EmpCode))

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE CP_USER SET TIME_ZONE_ID = '{0}' WHERE CDP_CONTACT_ID = {1};", Settings.TimeZoneID, HttpContext.Current.Session("UserID")))

                    End If

                End If

                cEmployee.ResetTimeZoneOffsetSession()

            End Using

        Catch ex As Exception
        End Try

    End Sub
    Private Function LoadFromSession() As Boolean
        If Not HttpContext.Current.Session(Me._LocalKey) Is Nothing Then
            Me.Settings = CType(HttpContext.Current.Session(Me._LocalKey), UserThemeSettings)
        End If
    End Function
    Public Function LoadFromCookie() As Boolean
        Try
            If Not HttpContext.Current.Request.Cookies(Me._LocalKey) Is Nothing Then
                Dim formatter As New LosFormatter()
                Settings = DirectCast(formatter.Deserialize(HttpContext.Current.Request.Cookies(Me._LocalKey).Value.ToString()), UserThemeSettings)
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadFromDatabase() As Boolean
        Try

            Me.Agency_LoadDefaultOptions()

            Me.User_Load()

            If Me._IsClientPortal = False And Settings.Agency_UseAgencyBranding = True Then

                Me.Agency_Load()

            End If
            If Me._IsClientPortal = True And Settings.Agency_UseAgencyBranding = True Then

                Me.ClientPortal_Load(Me._ClientPortalClCode)

            ElseIf Me._IsClientPortal = True Then

                Me.ClientPortal_Load("")

            End If
            'Final check
            If Settings.FullPathToIcon.Trim() = "" Then
                Settings.FullPathToIcon = "Images/Blue/" & Settings.DefaultIcon
            End If
            If Settings.FullPathToLogo.Trim() = "" Then
                Settings.FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
            End If
            If Settings.FullPathToWallpaper.Trim() = "" Then
                Settings.FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
            End If
            If Settings.Logo.Trim() = "" Then
                Settings.Logo = Settings.DefaultLogo
            End If
            If Settings.Wallpaper.Trim() = "" Then
                Settings.Wallpaper = Settings.DefaultWallpaper
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub DeleteCookie()
        'If (Not HttpContext.Current.Request.Cookies(Me._SettingKey) Is Nothing) Then
        '    HttpContext.Current.Request.Cookies(Me._SettingKey).Expires = DateTime.Now.AddDays(-1)
        'End If
        Dim OatmealRaisin As New HttpCookie(Me._LocalKey)
        OatmealRaisin.Value = ""
        OatmealRaisin.Expires = DateTime.Now.AddDays(-1)
        HttpContext.Current.Response.Cookies.Add(OatmealRaisin)
    End Sub
    Private Sub DeleteSession()
        If Not HttpContext.Current.Session(Me._LocalKey) Is Nothing Then
            HttpContext.Current.Session(Me._LocalKey) = Nothing
        End If
    End Sub
    Public Function Agency_Save(Optional ByRef ErrorMessage As String = "") As Boolean

        Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(Me._ConnString, Me._UserCode, HttpContext.Current)
        Dim cAgency As New cAgency(Me._ConnString)
        Dim PathToTempFolder As String = HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\"

        With AgyStg.SettingsDictionary

            .Add(AdvantageFramework.Agency.Settings.WV_BRND_ENABLE, Me.Settings.Agency_UseAgencyBranding)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_BG_TYPE, Me.Settings.Agency_BackgroundType)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_BGCLR, Me.Settings.Agency_BackgroundColor)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_TXCLR, Me.Settings.Agency_TextColor)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_USR_BG, Me.Settings.Agency_AllowUserToSetColors)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_USR_THM, Me.Settings.Agency_AllowUserToSetTheme)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_THEME, DefaultTelerikTheme)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_FLT_DTO, Me.Settings.Agency_FloatDesktopObjects)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_SHRT_MNU, Me.Settings.Agency_SingleNodeMainMenu)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_CLK_APP, Me.Settings.Agency_ClickToOpenAppMenu)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_CLK_USR, Me.Settings.Agency_ClickToOpenUserMenu)
            .Add(AdvantageFramework.Agency.Settings.WV_ENABLE_WTHR, Me.Settings.Agency_EnableWeather)

            .Add(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_BG_CLR, Me.Settings.Agency_SimpleLayoutBackgroundColor)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_SB_CLR, Me.Settings.Agency_SimpleLayoutSideBarColor)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_SMPL_ICON, Me.Settings.Agency_SimpleLayoutIconStyle)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_LOGO_ON_WP, Me.Settings.Agency_ShowLogoOnWorkspace)
            .Add(AdvantageFramework.Agency.Settings.WV_BRND_LOGO_POS, Me.Settings.Agency_WorkspaceLogoPosition)

        End With

        Dim s As String = ""
        If AgyStg.UpdateValues(s) = False Then

            ErrorMessage = s
            Return False

        Else

            ErrorMessage = ""
            Return True

        End If

    End Function
    Public Function ClientPortal_Save(Optional ClCode As String = "", Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Using MyConn As New SqlConnection(Me._ConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_SaveClientPortalBranding"
                    .Connection = MyConn
                End With
                Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                If ClCode = "" Or ClCode = "default" Then
                    pCL_CODE.Value = System.DBNull.Value
                Else
                    pCL_CODE.Value = ClCode
                End If
                MyCommand.Parameters.Add(pCL_CODE)
                Dim pWV_BRND_ENABLE As New SqlParameter("@WV_BRND_ENABLE", SqlDbType.Bit)
                pWV_BRND_ENABLE.Value = Me.Settings.Agency_UseAgencyBranding
                MyCommand.Parameters.Add(pWV_BRND_ENABLE)
                Dim pWV_BRND_BG_TYPE As New SqlParameter("@WV_BRND_BG_TYPE", SqlDbType.TinyInt)
                pWV_BRND_BG_TYPE.Value = Me.Settings.Agency_BackgroundType
                MyCommand.Parameters.Add(pWV_BRND_BG_TYPE)
                Dim pWV_BRND_BG As New SqlParameter("@WV_BRND_BG", SqlDbType.VarChar, 500)
                If Me.Settings.Agency_Wallpaper = "" Then
                    pWV_BRND_BG.Value = System.DBNull.Value
                Else
                    pWV_BRND_BG.Value = Me.Settings.Agency_Wallpaper
                End If
                MyCommand.Parameters.Add(pWV_BRND_BG)
                Dim pWV_BRND_BGCLR As New SqlParameter("@WV_BRND_BGCLR", SqlDbType.VarChar, 500)
                pWV_BRND_BGCLR.Value = Me.Settings.Agency_BackgroundColor
                MyCommand.Parameters.Add(pWV_BRND_BGCLR)
                Dim pWV_BRND_CLK_APP As New SqlParameter("@WV_BRND_CLK_APP", SqlDbType.Bit)
                pWV_BRND_CLK_APP.Value = Me.Settings.Agency_ClickToOpenAppMenu
                MyCommand.Parameters.Add(pWV_BRND_CLK_APP)
                Dim pWV_BRND_CLK_USR As New SqlParameter("@WV_BRND_CLK_USR", SqlDbType.Bit)
                pWV_BRND_CLK_USR.Value = Me.Settings.Agency_ClickToOpenUserMenu
                MyCommand.Parameters.Add(pWV_BRND_CLK_USR)
                Dim pWV_BRND_FLT_DTO As New SqlParameter("@WV_BRND_FLT_DTO", SqlDbType.Bit)
                pWV_BRND_FLT_DTO.Value = Me.Settings.Agency_FloatDesktopObjects
                MyCommand.Parameters.Add(pWV_BRND_FLT_DTO)
                Dim pWV_BRND_ICON As New SqlParameter("@WV_BRND_ICON", SqlDbType.VarChar, 500)
                pWV_BRND_ICON.Value = Me.Settings.Agency_Icon
                MyCommand.Parameters.Add(pWV_BRND_ICON)
                Dim pWV_BRND_LOGO As New SqlParameter("@WV_BRND_LOGO", SqlDbType.VarChar, 500)
                If Me.Settings.Agency_Logo = "" Then
                    pWV_BRND_LOGO.Value = System.DBNull.Value
                Else
                    pWV_BRND_LOGO.Value = Me.Settings.Agency_Logo
                End If
                MyCommand.Parameters.Add(pWV_BRND_LOGO)
                Dim pWV_BRND_SHRT_MNU As New SqlParameter("@WV_BRND_SHRT_MNU", SqlDbType.Bit)
                pWV_BRND_SHRT_MNU.Value = Me.Settings.Agency_SingleNodeMainMenu
                MyCommand.Parameters.Add(pWV_BRND_SHRT_MNU)
                Dim pWV_BRND_USR_BG As New SqlParameter("@WV_BRND_USR_BG", SqlDbType.Bit)
                pWV_BRND_USR_BG.Value = Me.Settings.Agency_AllowUserToSetColors
                MyCommand.Parameters.Add(pWV_BRND_USR_BG)
                Dim pWV_BRND_USR_THM As New SqlParameter("@WV_BRND_USR_THM", SqlDbType.Bit)
                pWV_BRND_USR_THM.Value = Me.Settings.Agency_AllowUserToSetTheme
                MyCommand.Parameters.Add(pWV_BRND_USR_THM)
                Dim pWV_BRND_THEME As New SqlParameter("@WV_BRND_THEME", SqlDbType.VarChar, 50)
                pWV_BRND_THEME.Value = DefaultTelerikTheme
                MyCommand.Parameters.Add(pWV_BRND_THEME)
                Dim pWV_BRND_WKSPCLR As New SqlParameter("@WV_BRND_WKSPCLR", SqlDbType.VarChar, 50)
                pWV_BRND_WKSPCLR.Value = Me.Settings.SimpleLayoutBackgroundColor
                MyCommand.Parameters.Add(pWV_BRND_WKSPCLR)
                Dim pWV_BRND_SBCLR As New SqlParameter("@WV_BRND_SBCLR", SqlDbType.VarChar, 50)
                pWV_BRND_SBCLR.Value = Me.Settings.SimpleLayoutSideBarColor
                MyCommand.Parameters.Add(pWV_BRND_SBCLR)
                Dim pWV_BRND_ICON_STYLE As New SqlParameter("@WV_BRND_ICON_STYLE", SqlDbType.TinyInt)
                pWV_BRND_ICON_STYLE.Value = Me.Settings.SimpleLayoutIconStyle
                MyCommand.Parameters.Add(pWV_BRND_ICON_STYLE)

                MyConn.Open()
                MyCommand.ExecuteNonQuery()
            End Using
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function
    Public Function ClientPortal_UpdateImageSetting(ByVal ImageNameOrColorCode As String, ByVal ImageType As UserThemeSettings.ImageType,
    Optional ClCode As String = "", Optional ByRef ErrorMessage As String = "") As Boolean
        Dim SQL As New System.Text.StringBuilder
        With SQL
            .Append("UPDATE CP_THEME_SETTINGS WITH(ROWLOCK) SET ")
            Select Case ImageType
                Case UserThemeSettings.ImageType.Custom, UserThemeSettings.ImageType.Wallpaper
                    .Append("WV_BRND_BG = @IMAGE_NAME")
                    .Append(", WV_BRND_BG_TYPE = ")
                    .Append(CType(ImageType, Integer))
                Case UserThemeSettings.ImageType.SolidColor
                    .Append("WV_BRND_BGCLR = @IMAGE_NAME")
                    .Append(", WV_BRND_BG_TYPE = ")
                    .Append(CType(ImageType, Integer))
                Case UserThemeSettings.ImageType.Icon
                    .Append("WV_BRND_ICON = @IMAGE_NAME")
                Case UserThemeSettings.ImageType.Logo
                    .Append("WV_BRND_LOGO = @IMAGE_NAME")
            End Select
            .Append(" WHERE CL_CODE ")
            If ClCode = "" Then
                .Append(" IS NULL;")
            Else
                .Append(" = @CL_CODE;")
            End If
        End With
        Using MyConn As New SqlConnection(Me._ConnString)
            Dim MyCommand As New SqlCommand()
            With MyCommand
                .CommandType = CommandType.Text
                .CommandText = SQL.ToString()
                .Connection = MyConn
            End With
            Dim pImageName As New SqlParameter("@IMAGE_NAME", SqlDbType.VarChar, 500)
            pImageName.Value = ImageNameOrColorCode
            MyCommand.Parameters.Add(pImageName)
            If ClCode <> "" Then
                Dim pClCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                pClCode.Value = ClCode
                MyCommand.Parameters.Add(pClCode)
            End If
            MyConn.Open()
            MyCommand.ExecuteScalar()
        End Using
    End Function
    Public Sub Agency_Load()
        Dim AgencySettings As New AdvantageFramework.Web.AgencySettings.Methods(Me._ConnString, Me._UserCode, HttpContext.Current)
        AgencySettings.GetValuesFromDatabase(AdvantageFramework.Agency.SettingApps.AgencyBranding)
        If Not AgencySettings.SettingsDictionary Is Nothing AndAlso AgencySettings.SettingsDictionary.Count > 0 Then
            For Each item As KeyValuePair(Of AdvantageFramework.Agency.Settings, String) In AgencySettings.SettingsDictionary
                Select Case item.Key
                    Case AdvantageFramework.Agency.Settings.WV_BRND_ENABLE
                        Me.Settings.Agency_UseAgencyBranding = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_BG_TYPE
                        If IsNumeric(item.Value) = True Then Me.Settings.Agency_BackgroundType = CType(item.Value, Integer)
                    Case AdvantageFramework.Agency.Settings.WV_BRND_BG
                        Me.Settings.Agency_Wallpaper = item.Value.ToString()
                    Case AdvantageFramework.Agency.Settings.WV_BRND_BGCLR
                        Me.Settings.Agency_BackgroundColor = item.Value.ToString()
                    Case AdvantageFramework.Agency.Settings.WV_BRND_CLK_APP
                        Me.Settings.Agency_ClickToOpenAppMenu = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_CLK_USR
                        Me.Settings.Agency_ClickToOpenUserMenu = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_FLT_DTO
                        Me.Settings.Agency_FloatDesktopObjects = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_ICON
                        Me.Settings.Agency_Icon = item.Value.ToString()
                    Case AdvantageFramework.Agency.Settings.WV_BRND_LOGO
                        Me.Settings.Agency_Logo = item.Value.ToString()
                    Case AdvantageFramework.Agency.Settings.WV_BRND_SHRT_MNU
                        Me.Settings.Agency_SingleNodeMainMenu = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_USR_BG
                        Me.Settings.Agency_AllowUserToSetColors = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_USR_THM
                        Me.Settings.Agency_AllowUserToSetTheme = item.Value = "1"
                    Case AdvantageFramework.Agency.Settings.WV_BRND_THEME
                        Me.Settings.Agency_TelerikTheme = DefaultTelerikTheme
                        'Select Case item.Value.ToString()
                        '    Case "Bootstrap", "Metro"
                        '        Me.Settings.Agency_TelerikTheme = item.Value.ToString()
                        '    Case Else
                        '        Me.Settings.Agency_TelerikTheme = "Bootstrap"
                        'End Select
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_SMPL_BG_CLR
                        Me.Settings.Agency_SimpleLayoutBackgroundColor = item.Value.ToString()
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_SMPL_SB_CLR
                        Me.Settings.Agency_SimpleLayoutSideBarColor = item.Value.ToString()
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_SMPL_ICON
                        If IsNumeric(item.Value) = True Then Me.Settings.Agency_SimpleLayoutIconStyle = CType(CType(item.Value, Integer), UserThemeSettings.IconStyle)
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_LOGO_ON_WP
                        Me.Settings.Agency_ShowLogoOnWorkspace = item.Value = "1"
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_LOGO_POS
                        If IsNumeric(item.Value) = True Then Me.Settings.Agency_WorkspaceLogoPosition = CType(CType(item.Value, Integer), UserThemeSettings.WorkspaceLogoPosition)
                    Case AdvantageFramework.Agency.Methods.Settings.WV_BRND_CLR_SN_IN
                        Me.Settings.Agency_UseBackgroundColorOnSignInPage = item.Value = "1"
                End Select
            Next
        End If
        Me.SetFullPathToImages()
    End Sub
    Private Sub Agency_LoadDefaultOptions()

        Try

            If String.IsNullOrWhiteSpace(Me._ConnString) = False Then


                Dim AgencySettings As New AdvantageFramework.Web.AgencySettings.Methods(Me._ConnString, Me._UserCode, HttpContext.Current)
                AgencySettings.GetValuesFromDatabase(AdvantageFramework.Agency.SettingApps.AgencyBranding)
                If Not AgencySettings.SettingsDictionary Is Nothing AndAlso AgencySettings.SettingsDictionary.Count > 0 Then
                    For Each item As KeyValuePair(Of AdvantageFramework.Agency.Settings, String) In AgencySettings.SettingsDictionary
                        Select Case item.Key
                            Case AdvantageFramework.Agency.Settings.WV_BRND_BG_TYPE
                                If IsNumeric(item.Value) = True Then Settings.BackgroundType = CType(CType(item.Value, Integer), UserThemeSettings.ImageType)
                            Case AdvantageFramework.Agency.Settings.WV_BRND_BG
                                Settings.CustomWallpaper = item.Value.ToString()
                            Case AdvantageFramework.Agency.Settings.WV_BRND_BGCLR
                                Settings.BackgroundColor = item.Value.ToString()
                            Case AdvantageFramework.Agency.Settings.WV_BRND_CLK_APP
                                Settings.ClickToOpenAppMenu = item.Value = "1"
                            Case AdvantageFramework.Agency.Settings.WV_BRND_CLK_USR
                                Settings.ClickToOpenUserMenu = item.Value = "1"
                            Case AdvantageFramework.Agency.Settings.WV_BRND_FLT_DTO
                                Settings.FloatDesktopObjects = item.Value = "1"
                            Case AdvantageFramework.Agency.Settings.WV_BRND_SHRT_MNU
                                Settings.SingleNodeMainMenu = item.Value = "1"
                        End Select
                    Next
                End If

            End If

        Catch ex As Exception
        End Try


    End Sub
    Public Sub ClientPortal_Load(Optional ClCode As String = "")

        Try

            If String.IsNullOrWhiteSpace(Me._ConnString) = False Then
                'Override agency values with client portal values
                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim SQL As String = ""
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_cp_GetTheme"
                        .Connection = MyConn
                    End With
                    Dim pClCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                    If ClCode = "" Or ClCode = "default" Then
                        pClCode.Value = System.DBNull.Value
                    Else
                        pClCode.Value = ClCode
                    End If
                    MyCommand.Parameters.Add(pClCode)
                    MyConn.Open()
                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()
                    If Reader.HasRows = True Then
                        Do While Reader.Read()
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_ENABLE")) = False Then
                                Me.Settings.Agency_UseAgencyBranding = Reader.GetValue(Reader.GetOrdinal("WV_BRND_ENABLE"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_BG_TYPE")) = False Then
                                Me.Settings.Agency_BackgroundType = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BG_TYPE"))
                                Me.Settings.BackgroundType = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BG_TYPE"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_BG")) = False Then
                                Me.Settings.Agency_Wallpaper = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BG"))
                                Me.Settings.Wallpaper = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BG"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_BGCLR")) = False Then
                                Me.Settings.Agency_BackgroundColor = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BGCLR"))
                                Me.Settings.BackgroundColor = Reader.GetValue(Reader.GetOrdinal("WV_BRND_BGCLR"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_CLK_APP")) = False Then
                                Me.Settings.Agency_ClickToOpenAppMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_CLK_APP"))
                                Me.Settings.ClickToOpenAppMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_CLK_APP"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_CLK_USR")) = False Then
                                Me.Settings.Agency_ClickToOpenUserMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_CLK_USR"))
                                Me.Settings.ClickToOpenUserMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_CLK_USR"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_FLT_DTO")) = False Then
                                Me.Settings.Agency_FloatDesktopObjects = Reader.GetValue(Reader.GetOrdinal("WV_BRND_FLT_DTO"))
                                Me.Settings.FloatDesktopObjects = Reader.GetValue(Reader.GetOrdinal("WV_BRND_FLT_DTO"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_ICON")) = False Then
                                Me.Settings.Agency_Icon = Reader.GetValue(Reader.GetOrdinal("WV_BRND_ICON"))
                                Me.Settings.Icon = Reader.GetValue(Reader.GetOrdinal("WV_BRND_ICON"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_LOGO")) = False Then
                                Me.Settings.Agency_Logo = Reader.GetValue(Reader.GetOrdinal("WV_BRND_LOGO"))
                                Me.Settings.Logo = Reader.GetValue(Reader.GetOrdinal("WV_BRND_LOGO"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_SHRT_MNU")) = False Then
                                Me.Settings.Agency_SingleNodeMainMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_SHRT_MNU"))
                                Me.Settings.SingleNodeMainMenu = Reader.GetValue(Reader.GetOrdinal("WV_BRND_SHRT_MNU"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_USR_BG")) = False Then
                                Me.Settings.Agency_AllowUserToSetColors = Reader.GetValue(Reader.GetOrdinal("WV_BRND_USR_BG"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_USR_THM")) = False Then
                                Me.Settings.Agency_AllowUserToSetTheme = Reader.GetValue(Reader.GetOrdinal("WV_BRND_USR_THM"))
                            End If
                            'If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_THEME")) = False Then
                            '    Dim s As String = Reader.GetValue(Reader.GetOrdinal("WV_BRND_THEME"))

                            '    Select Case s
                            '        Case "Bootstrap", "Metro"

                            '            s = s

                            '        Case Else

                            '            s = "Bootstrap"

                            '    End Select

                            Me.Settings.Agency_TelerikTheme = DefaultTelerikTheme
                            Me.Settings.TelerikTheme = DefaultTelerikTheme

                            'End If
                            If Reader.IsDBNull(Reader.GetOrdinal("IS_USING_DFLT_LOGO")) = False Then
                                Me.Settings.ClientPortal_IsUsingDefaultClientPortalLogo = Reader.GetValue(Reader.GetOrdinal("IS_USING_DFLT_LOGO"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("IS_USING_DFLT_WALLPAPER")) = False Then
                                Me.Settings.ClientPortal_IsUsingDefaultClientPortalWallpaper = Reader.GetValue(Reader.GetOrdinal("IS_USING_DFLT_WALLPAPER"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_WKSPCLR")) = False Then
                                Me.Settings.SimpleLayoutBackgroundColor = Reader.GetValue(Reader.GetOrdinal("WV_BRND_WKSPCLR"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_SBCLR")) = False Then
                                Me.Settings.SimpleLayoutSideBarColor = Reader.GetValue(Reader.GetOrdinal("WV_BRND_SBCLR"))
                            End If
                            If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_ICON_STYLE")) = False Then
                                Me.Settings.SimpleLayoutIconStyle = Reader.GetValue(Reader.GetOrdinal("WV_BRND_ICON_STYLE"))
                            End If

                        Loop

                    End If

                    Me.ClientPortal_User_Load()

                End Using

                Me.SetFullPathToImages()

            End If

        Catch ex As Exception
        End Try

    End Sub
    Public Sub User_Load()

        Try

            If String.IsNullOrWhiteSpace(Me._ConnString) = False Then

                Using MyConn As New SqlConnection(Me._ConnString)
                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT VARIABLE_NAME, VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE USERID = @USER_CODE AND APPLICATION = @APP;"
                        .Connection = MyConn
                    End With
                    Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    pUserCode.Value = Me._UserCode
                    Dim pApp As New SqlParameter("@APP", SqlDbType.VarChar, 40)
                    pApp.Value = Me._SettingKey
                    MyCommand.Parameters.Add(pUserCode)
                    MyCommand.Parameters.Add(pApp)
                    MyConn.Open()
                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()
                    If Reader.HasRows = True Then
                        Dim Key As String = ""
                        Dim Value As String = ""
                        Do While Reader.Read()
                            Try
                                Key = ""
                                Value = ""
                                If Reader.IsDBNull(Reader.GetOrdinal("VARIABLE_NAME")) = False Then
                                    Key = Reader.GetValue(Reader.GetOrdinal("VARIABLE_NAME"))
                                    If Reader.IsDBNull(Reader.GetOrdinal("VARIABLE_VALUE")) = False Then
                                        Value = Reader.GetValue(Reader.GetOrdinal("VARIABLE_VALUE"))
                                    End If
                                    Select Case Key
                                        Case "SIGN_IN_LOGO", "LOGO"

                                            If Value <> "" Then

                                                Settings.Logo = Value

                                                If Value.Contains("aqualogo_") Then

                                                    'Settings.FullPathToLogo = "Images/Logos/" & Value
                                                    Settings.FullPathToLogo = "Images/Logos/aqualogo_FFFFFF.png"

                                                End If

                                            End If

                                        Case "BG_COLOR"
                                            Settings.BackgroundColor = Value
                                        Case "TEXT_COLOR"
                                            Settings.TextColor = Value
                                        Case "BG_TYPE"
                                            If IsNumeric(Value) = True Then
                                                Settings.BackgroundType = CType(CType(Value, Integer), UserThemeSettings.ImageType)
                                            End If
                                        Case "CLICK_OPEN_APP_MENU"
                                            Settings.ClickToOpenAppMenu = Value.ToLower() = "true"
                                        Case "CLICK_OPEN_USER_MENU"
                                            Settings.ClickToOpenUserMenu = Value.ToLower() = "true"
                                        Case "FLOAT_DESKTOP_OBJECTS"
                                            Settings.FloatDesktopObjects = Value.ToLower() = "true"
                                        Case "MY_WALLPAPER"
                                            Settings.CustomWallpaper = Value
                                        Case "USE_WALLPAPER_ON_SIGN_IN"
                                            Settings.UseBackgroundColorOnSignInPage = Value.ToLower() = "true"
                                        Case "SINGLE_NODE_MAIN_MENU"
                                            Settings.SingleNodeMainMenu = Value.ToLower() = "true"
                                        Case "TELERIK_THEME"

                                            Select Case Value
                                                Case "Bootstrap", "Metro"

                                                    Settings.TelerikTheme = "Metro"

                                                Case Else

                                                    Settings.TelerikTheme = "Metro"

                                            End Select

                                        Case "WALLPAPER"
                                            Settings.Wallpaper = Value
                                        Case "ENABLE_WEATHER"
                                            Settings.EnableWeather = Value.ToLower() = "true"
                                        Case "LAYOUT_TYPE"
                                            Settings.UseLayout = UserThemeSettings.Layout.Simple
                                        Case "SMPL_ICON"
                                            Settings.SimpleLayoutIconStyle = CType(CType(Value, Integer), UserThemeSettings.IconStyle)
                                        Case "SMPL_SIDEBR"
                                            Settings.SimpleLayoutSideBarColor = Value
                                        Case "SMPL_BG_COLOR"
                                            Settings.SimpleLayoutBackgroundColor = Value
                                        Case "SMPL_MENU_NEW"
                                            Settings.SimpleLayoutShowNewMenu = Value.ToLower() = "true"
                                        Case "SMPL_MENU_APPS"
                                            Settings.SimpleLayoutShowAppMenu = Value.ToLower() = "true"
                                        Case "TIME_ZONE_ID" 'just for client portal...
                                            Settings.TimeZoneID = Value
                                        Case "EDITOR_SHOW"

                                            Try

                                                If IsNumeric(Value) = True Then Settings.ShowRadEditorToolbar = CType(CType(Value, Integer), UserThemeSettings.RadEditorToolBarShow)

                                            Catch ex As Exception
                                                Settings.ShowRadEditorToolbar = UserThemeSettings.RadEditorToolBarShow.OnFocus
                                            End Try
                                        Case "SHOW_DB_NAME"
                                            Settings.ShowDatabaseName = Value.ToLower() = "true"
                                        Case "IS_DARK_MODE"
                                            Settings.IsDarkMode = Value.ToLower() = "true"
                                    End Select
                                End If
                            Catch ex As Exception
                                Key = ""
                                Value = ""
                            End Try
                        Loop
                    End If
                End Using
                Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnString, Me._UserCode)

                    Try

                        Settings.TimeZoneID = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(TIME_ZONE_ID, '') FROM EMPLOYEE WHERE EMP_CODE = '{0}';", Me._EmpCode)).FirstOrDefault

                    Catch ex As Exception
                        Settings.TimeZoneID = String.Empty
                    End Try

                End Using

                If Me._IsClientPortal = False Then

                    Dim AgencySettings As New AdvantageFramework.Web.AgencySettings.Methods(Me._ConnString, Me._UserCode, HttpContext.Current)
                    Settings.Agency_UseAgencyBranding = AgencySettings.GetValue(AdvantageFramework.Agency.Settings.WV_BRND_ENABLE, "")

                    If AgencySettings.GetValue(AdvantageFramework.Agency.Settings.WV_ENABLE_WTHR, "") = False Then

                        Settings.EnableWeather = False
                        Settings.Agency_EnableWeather = False

                    Else

                        Settings.Agency_EnableWeather = True

                    End If

                Else

                    Using MyConn As New SqlConnection(Me._ConnString)
                        Dim SQL As String = ""
                        Dim MyCommand As New SqlCommand()
                        With MyCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_cp_GetTheme"
                            .Connection = MyConn
                        End With
                        Dim pClCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                        If Me._ClientPortalClCode = "" Or Me._ClientPortalClCode = "default" Then
                            pClCode.Value = System.DBNull.Value
                        Else
                            pClCode.Value = Me._ClientPortalClCode
                        End If
                        MyCommand.Parameters.Add(pClCode)
                        MyConn.Open()
                        Dim Reader As SqlDataReader
                        Reader = MyCommand.ExecuteReader()
                        If Reader.HasRows = True Then
                            Do While Reader.Read()
                                If Reader.IsDBNull(Reader.GetOrdinal("WV_BRND_ENABLE")) = False Then
                                    Me.Settings.Agency_UseAgencyBranding = Reader.GetValue(Reader.GetOrdinal("WV_BRND_ENABLE"))
                                End If
                            Loop
                        End If
                    End Using
                End If

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub ClientPortal_User_Load()

        Try

            Using MyConn As New SqlConnection(Me._ConnString)
                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT VARIABLE_NAME, VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE USERID = @USER_CODE AND APPLICATION = @APP UNION SELECT AGY_SETTINGS_CODE AS VARIABLE_NAME, ISNULL(CAST(AGY_SETTINGS_VALUE AS VARCHAR), '0') AS VARIABLE_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'WV_ENABLE_WTHR';"
                    .Connection = MyConn
                End With
                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = Me._UserCode
                Dim pApp As New SqlParameter("@APP", SqlDbType.VarChar, 40)
                pApp.Value = Me._SettingKey
                MyCommand.Parameters.Add(pUserCode)
                MyCommand.Parameters.Add(pApp)
                MyConn.Open()
                Dim Reader As SqlDataReader
                Reader = MyCommand.ExecuteReader()
                If Reader.HasRows = True Then
                    Dim Key As String = ""
                    Dim Value As String = ""
                    Do While Reader.Read()
                        Try
                            Key = ""
                            Value = ""
                            If Reader.IsDBNull(Reader.GetOrdinal("VARIABLE_NAME")) = False Then
                                Key = Reader.GetValue(Reader.GetOrdinal("VARIABLE_NAME"))
                                If Reader.IsDBNull(Reader.GetOrdinal("VARIABLE_VALUE")) = False Then
                                    Value = Reader.GetValue(Reader.GetOrdinal("VARIABLE_VALUE"))
                                End If
                                Select Case Key
                                    Case "FLOAT_DESKTOP_OBJECTS"
                                        Settings.FloatDesktopObjects = Value.ToLower() = "true"
                                    Case "SINGLE_NODE_MAIN_MENU"
                                        Settings.SingleNodeMainMenu = Value.ToLower() = "true"
                                    Case "WV_ENABLE_WTHR"
                                        Settings.EnableWeather = Value = "1"
                                        Settings.Agency_EnableWeather = Value = "1"
                                    Case "TIME_ZONE_ID"
                                        Settings.TimeZoneID = Value
                                End Select
                            End If
                        Catch ex As Exception
                            Key = ""
                            Value = ""
                        End Try
                    Loop
                End If
            End Using

        Catch ex As Exception
        End Try

    End Sub
    Private Sub SetFullPathToImages()

        Dim CurrentLevel As UserThemeSettings.ImageLevel
        If Me._IsClientPortal = False Then
            CurrentLevel = UserThemeSettings.ImageLevel.Agency
        Else
            CurrentLevel = UserThemeSettings.ImageLevel.ClientPortal
        End If
        If Settings.Agency_Logo <> "" AndAlso Settings.Agency_Logo <> Settings.DefaultLogo Then
            If Me.FileIsInTempFolder(Settings.Agency_Logo) = True Then
                Settings.FullPathToLogo = "TEMP/" & Settings.Agency_Logo
            Else
                If Me.GetLogoFromDatabaseAndSaveToTemp(CurrentLevel, Settings.Agency_Logo) = True Then
                    Settings.FullPathToLogo = "TEMP/" & Settings.Agency_Logo
                Else
                    Settings.FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
                End If
            End If
        Else
            Settings.FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
        End If
        If Settings.Agency_Icon <> "" AndAlso Settings.Agency_Icon <> Settings.DefaultIcon Then
            If Me.FileIsInTempFolder(Settings.Agency_Icon) = True Then
                Settings.FullPathToIcon = "TEMP/" & Settings.Agency_Icon
            Else
                If Me.GetIconFromDatabaseAndSaveToTemp(CurrentLevel, Settings.Agency_Icon) = True Then
                    Settings.FullPathToIcon = "TEMP/" & Settings.Agency_Icon
                Else
                    Settings.FullPathToIcon = "Images/Blue/" & Settings.DefaultIcon
                End If
            End If
        Else
            Settings.FullPathToIcon = "Images/Blue/" & Settings.DefaultIcon
        End If
        Select Case Settings.Agency_BackgroundType
            Case UserThemeSettings.ImageType.Wallpaper
                If Settings.Agency_Wallpaper <> "" Then
                    Settings.Agency_FullPathToWallpaper = "Images/Wallpaper/" & Settings.Agency_Wallpaper
                End If
            Case UserThemeSettings.ImageType.Custom
                If Settings.Agency_Wallpaper <> "" AndAlso Settings.Agency_Wallpaper <> Settings.DefaultWallpaper Then
                    If Me.FileIsInTempFolder(Settings.Agency_Wallpaper) = True Then
                        Settings.Agency_FullPathToWallpaper = "TEMP/" & Settings.Agency_Wallpaper
                    Else
                        If Me.GetWallpaperFromDatabaseAndSaveToTemp(CurrentLevel, Settings.Agency_Wallpaper) = True Then
                            Settings.Agency_FullPathToWallpaper = "TEMP/" & Settings.Agency_Wallpaper
                        Else
                            Settings.Agency_FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
                        End If
                    End If
                Else
                    Settings.Agency_FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
                End If
        End Select
        If Settings.Agency_AllowUserToSetColors = False And Me._IsClientPortal = False Then

            Settings.SimpleLayoutBackgroundColor = Settings.Agency_SimpleLayoutBackgroundColor
            Settings.SimpleLayoutSideBarColor = Settings.Agency_SimpleLayoutSideBarColor
            Settings.SimpleLayoutIconStyle = Settings.Agency_SimpleLayoutIconStyle
            Settings.UseBackgroundColorOnSignInPage = Settings.Agency_UseBackgroundColorOnSignInPage

        End If
        If Settings.FullPathToIcon.Trim() = "" Then
            Settings.FullPathToIcon = "Images/Blue/" & Settings.DefaultIcon
        End If
        If Settings.FullPathToLogo.Trim() = "" Then
            Settings.FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
        End If
        If Settings.Agency_FullPathToLogo.Trim() = "" Then
            Settings.Agency_FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
        End If
        If Settings.FullPathToWallpaper.Trim() = "" Then
            Settings.FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
        End If
        If Settings.Agency_FullPathToWallpaper = "" Then
            Settings.Agency_FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
        End If
        If Settings.Agency_AllowUserToSetTheme = False Then
            Settings.TelerikTheme = Settings.Agency_TelerikTheme
        End If
    End Sub
    Private Sub SetDefaultsIfNotFound()
        If Settings.FullPathToIcon.Trim() = "" Then
            Settings.FullPathToIcon = "Images/Blue/" & Settings.DefaultIcon
        End If
        If Settings.FullPathToLogo.Trim() = "" Then
            Settings.FullPathToLogo = "Images/Logos/" & Settings.DefaultLogo
        End If
        If Settings.FullPathToWallpaper.Trim() = "" Then
            Settings.FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
        End If
        If Settings.Logo.Trim() = "" Then
            Settings.Logo = Settings.DefaultLogo
        End If
        If Settings.Wallpaper.Trim() = "" Then
            Settings.Wallpaper = Settings.DefaultWallpaper
        End If
        If Settings.TelerikTheme = "" Then
            Settings.TelerikTheme = Settings.DefaultTelerikTheme
        End If
        If Settings.Agency_TelerikTheme = "" Then
            Settings.Agency_TelerikTheme = Settings.DefaultTelerikTheme
        End If
        If Settings.Agency_FullPathToWallpaper.Trim() = "" Then
            Settings.Agency_FullPathToWallpaper = "Images/Wallpaper/" & Settings.DefaultWallpaper
        End If
    End Sub

    Public Sub New(Optional ByVal EmpCode As String = "", Optional ByVal UserCode As String = "", Optional ByVal ConnString As String = "",
    Optional IsClientPortal As Boolean = False, Optional ClientPortalClCode As String = "")
        'IsClientPortal = True
        'ClientPortalClCode = "amerx"
        If MiscFN.IsClientPortal = True Or IsClientPortal = True Then
            Me._SettingKey = cAppVars.Application.MY_SETTINGS_CP
            Me._IsClientPortal = True
        Else
            Me._SettingKey = cAppVars.Application.MY_SETTINGS
            Me._IsClientPortal = False
        End If
        Me.Settings = New UserThemeSettings()
        If EmpCode = "" Then
            If Not HttpContext.Current.Session("EmpCode") Is Nothing Then
                EmpCode = HttpContext.Current.Session("EmpCode")
            End If
        End If
        Me._EmpCode = EmpCode
        If UserCode = "" Then
            If Not HttpContext.Current.Session("UserCode") Is Nothing Then
                UserCode = HttpContext.Current.Session("UserCode")
            End If
        End If
        Me._UserCode = UserCode
        If ConnString = "" Then
            If Not HttpContext.Current.Session("ConnString") Is Nothing Then
                ConnString = HttpContext.Current.Session("ConnString")
            End If
        End If
        Me._ConnString = ConnString
        If ClientPortalClCode = "" Then
            If Not HttpContext.Current.Session("CL_CODE") Is Nothing Then
                ClientPortalClCode = HttpContext.Current.Session("CL_CODE")
            End If
        End If
        Me._ClientPortalClCode = ClientPortalClCode
    End Sub

#End Region

End Class
