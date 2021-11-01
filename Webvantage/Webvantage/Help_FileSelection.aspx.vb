Public Class Help_FileSelection
    Inherits Webvantage.BaseChildPage

    Private Sub Help_FileSelection_Load(sender As Object, e As EventArgs) Handles Me.Load

        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then

            Me.ImageFileDragAndDrop.ImageUrl = "~/Images/FileDragAndDrop_MAC.gif"

        Else

            Me.ImageFileDragAndDrop.ImageUrl = "~/Images/FileDragAndDrop.gif"

        End If

    End Sub

End Class