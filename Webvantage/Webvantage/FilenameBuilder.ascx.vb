Public Class FilenameBuilder
    Inherits Webvantage.BaseUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.PanelEdit.Visible = False

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub LinkButtonEdit_Click(sender As Object, e As EventArgs) Handles LinkButtonEdit.Click

        Me.PanelEdit.Visible = Not Me.PanelEdit.Visible

    End Sub

    Private Sub LinkButtonSave_Click(sender As Object, e As EventArgs) Handles LinkButtonSave.Click

    End Sub

#End Region

#Region " Methods "



#End Region

End Class