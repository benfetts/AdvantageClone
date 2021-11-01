Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls

Partial Public Class _MobileDefault
    Inherits MobileBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lbLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub


End Class