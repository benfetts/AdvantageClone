Public Class AgencySettings_Preview
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PreviewMode

        Agency = 1
        ClientPortal = 2
        Employee = 3 'not fully implemented!

    End Enum

#End Region

#Region " Variables "

    Public BackgroundCSS As String = ""
    Private _ClientPortalClCode As String = ""
    Private _PageMode As PreviewMode = PreviewMode.Agency

#End Region

#Region " Properties "


#End Region

#Region " Page Events "

    Private Sub AgencySettings_Preview_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub
    Private Sub AgencySettings_Preview_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.Get("cp") = "1" Then

            Me._PageMode = PreviewMode.ClientPortal
            Me._ClientPortalClCode = qs.ClientCode

        End If

        'Me.AllowFloat = True

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))


        Select Case Me._PageMode

            Case PreviewMode.Agency

                t.Agency_Load()

                If t.Settings.Agency_UseAgencyBranding = False Then

                    t.Load()

                End If

            Case PreviewMode.ClientPortal

                t.ClientPortal_Load(Me._ClientPortalClCode)

                If t.Settings.Agency_UseAgencyBranding = False Then

                    t.ClientPortal_Load("")

                End If

            Case PreviewMode.Employee

                t.Load()

        End Select

        Me.Theme = t.Settings.Agency_AppTheme
        Me.ImageLogo.ImageUrl = t.Settings.FullPathToLogo

        Me.BackgroundCSS = "background-color: " & t.Settings.Agency_BackgroundColor & ";"

        Me.DivPreviewSidebar.Attributes.Add("style", "float:right; width:66px !important;height:100%;background-color:" & t.Settings.Agency_SimpleLayoutSideBarColor & " !important;")

        Me.RadMenuPreview.Skin = t.Settings.Agency_TelerikTheme
        Me.RadWindowPreview.Skin = t.Settings.Agency_TelerikTheme
        Me.RadToolBarPreview.Skin = t.Settings.Agency_TelerikTheme

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadToolBarPreview_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarPreview.ButtonClick

        Select Case e.Item.Value
            Case "refresh"
                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                MiscFN.ResponseRedirect(qs.ToString(True), True)

        End Select

    End Sub
    Private Sub RadMenuPreview_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenuPreview.ItemClick

        Select Case e.Item.Value
            Case "refresh"
                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                MiscFN.ResponseRedirect(qs.ToString(True), True)

        End Select

    End Sub

#End Region

#Region " Methods "



#End Region

End Class