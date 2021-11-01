Public Class PermaLink
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub PermaLink_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.TextBoxWebvantageLink.Attributes.Add("onfocus", "this.select();")
            Me.TextBoxClientPortalLink.Attributes.Add("onfocus", "this.select();")

        End If

    End Sub
    Private Sub PermaLink_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)

        Deep.BuildFromQueryString(Me.CurrentQuerystring, Me.TextBoxWebvantageLink.Text, Me.TextBoxClientPortalLink.Text)

    End Sub

#End Region

#End Region

End Class
