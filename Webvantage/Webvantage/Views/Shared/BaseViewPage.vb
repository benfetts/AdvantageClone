Public MustInherit Class BaseViewPage(Of TModel)
    Inherits System.Web.Mvc.WebViewPage(Of TModel)

#Region " Enum "

    Public Enum LayoutPageType
        LayoutPageBase
    End Enum

#End Region

#Region " Variables "

    Private _IsClientPortal As Boolean = False
    Private _QueryString As AdvantageFramework.Web.QueryString = Nothing
    Private _DarkColor As String = "#80DEEA"
    Private _BaseColor As String = "#2A579A"
    Private _CssFile As String = "Bootstrap.Advantage.css"
    Private _IsDarkMode As Boolean = False

#End Region

#Region " Properties "

    Public ReadOnly Property QueryString As AdvantageFramework.Web.QueryString
        Get
            Return _QueryString
        End Get
    End Property
    Public ReadOnly Property IsClientPortal As Boolean
        Get
            Return _IsClientPortal
        End Get
    End Property
    Public ReadOnly Property Locale As String
        Get
            Dim CultureCode As String = "en-US"
            Try

                If HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.Request IsNot Nothing Then

                    If Not HttpContext.Current.Request.Cookies("LoGloCode") Is Nothing AndAlso Not HttpContext.Current.Request.Cookies("LoGloCode").Value Is Nothing Then

                        CultureCode = HttpContext.Current.Request.Cookies("LoGloCode").Value

                    Else

                        CultureCode = "en-US"

                    End If
                End If

            Catch ex As Exception
                CultureCode = "en-US"
            End Try
            Return CultureCode
        End Get
    End Property
    Public ReadOnly Property DarkColor As String
        Get
            Return _DarkColor
        End Get
    End Property
    Public ReadOnly Property BaseColor As String
        Get
            Return _BaseColor
        End Get
    End Property
    Public ReadOnly Property CssFile As String
        Get
            Return _CssFile
        End Get
    End Property
    Public ReadOnly Property IsDarkMode As Boolean
        Get
            Return Me._IsDarkMode
        End Get
    End Property
#End Region

#Region " Methods "

    Public Sub New()

        _IsClientPortal = Webvantage.MiscFN.IsClientPortal()
        _QueryString = New AdvantageFramework.Web.QueryString()
        _QueryString = _QueryString.FromCurrent

        Try

            If HttpContext.Current.Session("ConnString") IsNot Nothing AndAlso
                HttpContext.Current.Session("UserCode") IsNot Nothing AndAlso
                HttpContext.Current.Session("EmpCode") IsNot Nothing Then

                Dim cUserTheme As New Webvantage.UserTheme(HttpContext.Current.Session("EmpCode"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("ConnString"))
                cUserTheme.Load()

                _CssFile = cUserTheme.Settings.CssFile
                _DarkColor = cUserTheme.Settings.SimpleLayoutDarkHighlightColor
                _BaseColor = cUserTheme.Settings.SimpleLayoutSideBarColor
                _IsDarkMode = cUserTheme.Settings.IsDarkMode

            Else

                Dim cookieUserTheme As New Webvantage.UserTheme()

                If cookieUserTheme IsNot Nothing Then

                    cookieUserTheme.LoadFromCookie()

                    If cookieUserTheme.Settings IsNot Nothing Then

                        _CssFile = cookieUserTheme.Settings.CssFile
                        _DarkColor = cookieUserTheme.Settings.SimpleLayoutDarkHighlightColor
                        _BaseColor = cookieUserTheme.Settings.SimpleLayoutSideBarColor
                        _IsDarkMode = cookieUserTheme.Settings.IsDarkMode

                    End If

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

#End Region

End Class

Public MustInherit Class BaseViewPage
    Inherits Webvantage.BaseViewPage(Of Object)

    '
    ' DO NOT ADD ANYTHING TO THIS CLASS!!!
    '

End Class
