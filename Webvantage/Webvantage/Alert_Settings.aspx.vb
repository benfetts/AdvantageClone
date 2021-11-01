Public Class Alert_Settings
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

    Private Sub CheckBoxCloseAfterComment_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCloseAfterComment.CheckedChanged

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

        av.getAllAppVars()
        av.setAppVar("CloseAfterComment", Me.CheckBoxCloseAfterComment.Checked, "Boolean")

        av.SaveAllAppVars()

    End Sub
    Private Sub CheckBoxCloseAfterReassigning_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCloseAfterReassigning.CheckedChanged

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

        av.getAllAppVars()
        av.setAppVar("CloseAfterReassign", Me.CheckBoxCloseAfterReassigning.Checked, "Boolean")

        av.SaveAllAppVars()

    End Sub
    Private Sub CheckBoxDefaultInformationSectionToCollapsed_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDefaultInformationSectionToCollapsed.CheckedChanged

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

        av.getAllAppVars()
        av.setAppVar("DefaultInfoSectionCollapsed", Me.CheckBoxDefaultInformationSectionToCollapsed.Checked, "Boolean")

        av.SaveAllAppVars()

    End Sub
    Private Sub CheckBoxShowFullComments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowFullComments.CheckedChanged

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

        av.getAllAppVars()
        av.setAppVar("ShowFullComments", Me.CheckBoxShowFullComments.Checked, "Boolean")

        av.SaveAllAppVars()

    End Sub
    Private Sub RadSliderScreenSplit_ValueChanged(sender As Object, e As EventArgs) Handles RadSliderScreenSplit.ValueChanged

        Dim LeftSide As Integer = RadSliderScreenSplit.Value
        Dim RightSide As Integer = 100 - LeftSide

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

        av.getAllAppVars()
        av.setAppVar("LeftSide", LeftSide, "Integer")
        av.setAppVar("RightSide", RightSide, "Integer")

        av.SaveAllAppVars()

        Me.LabelScreenSplit.Text = LeftSide.ToString & "/" & RightSide.ToString & " %"

    End Sub

#End Region
#Region " Page "

    Private Sub Alert_Settings_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)

            av.getAllAppVars()

            Me.CheckBoxCloseAfterComment.Checked = av.getAppVar("CloseAfterComment", "Boolean", "False").ToString.ToLower = "true"
            Me.CheckBoxCloseAfterReassigning.Checked = av.getAppVar("CloseAfterReassign", "Boolean", "False").ToString.ToLower = "true"
            Me.CheckBoxDefaultInformationSectionToCollapsed.Checked = av.getAppVar("DefaultInfoSectionCollapsed", "Boolean", "False").ToString.ToLower = "true"
            Me.CheckBoxShowFullComments.Checked = av.getAppVar("ShowFullComments", "Boolean", "False").ToString.ToLower = "true"

            Dim LeftSide As Integer = 50
            Dim RightSide As Integer = 50
            Try

                LeftSide = av.getAppVar("LeftSide", "Integer", "50")

            Catch ex As Exception
                LeftSide = 50
            End Try
            Me.RadSliderScreenSplit.Value = LeftSide

            RightSide = 100 - LeftSide

            Me.LabelScreenSplit.Text = LeftSide.ToString & "/" & RightSide.ToString & " %"


        End If

    End Sub



#End Region

#End Region

End Class