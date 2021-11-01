Imports System.Drawing.Printing

Namespace Proofing
    Public Class FeedbackSummaryAssetsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Public Row As FullAssetRow = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "
        Private Sub FeedbackSummaryAssetsSubReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint

        End Sub

#End Region

#Region "  Control Event Handlers "
        Private Sub SubReportComments_BeforePrint(sender As Object, e As PrintEventArgs) Handles SubReportComments.BeforePrint

            Try

                SubReportComments.ReportSource.DataSource = Row.Comments

            Catch ex As Exception
                SubReportComments.ReportSource.DataSource = Nothing
            End Try

        End Sub

        Private Sub Label_Filename_BeforePrint(sender As Object, e As PrintEventArgs)
        End Sub
        Private Sub TableCell_Left_BeforePrint(sender As Object, e As PrintEventArgs) Handles TableCell_Left.BeforePrint

            Me.LoadData()

        End Sub
        Private Sub LoadData()

            Try

                Row = TryCast(Me.GetCurrentRow, FullAssetRow)

            Catch ex As Exception
                Row = Nothing
            End Try

            If Row IsNot Nothing Then

                Dim MemoryStream As System.IO.MemoryStream = Nothing
                Dim Approves As Integer = 0
                Dim Defers As Integer = 0
                Dim Rejects As Integer = 0

                Me.Label_Filename.Text = Row.Asset.FileName
                Me.Label_Filesize.Text = Row.Asset.FileSizeDisplay
                Me.LabelVersion.Text = Row.Asset.VersionNumber.ToString() & " of " & Row.Asset.TotalVersionsForAlertID.ToString()

                If Row.Asset.TotalApproved IsNot Nothing Then

                    Approves = Row.Asset.TotalApproved

                End If
                If Row.Asset.TotalDeferred IsNot Nothing Then

                    Defers = Row.Asset.TotalDeferred

                End If
                If Row.Asset.TotalRejected IsNot Nothing Then

                    Rejects = Row.Asset.TotalRejected

                End If

                'Me.Label_Approvals.Text = String.Format("{0} / {1} / {2}", Approves, Defers, Rejects)

                If Row.Asset.ThumbnailSource IsNot Nothing Then

                    Try

                        MemoryStream = New System.IO.MemoryStream(Row.Asset.ThumbnailSource)

                        PictureBoxAssetThumbnail.Image = System.Drawing.Image.FromStream(MemoryStream)

                    Catch ex As Exception
                        PictureBoxAssetThumbnail.Visible = False
                    End Try

                Else

                    PictureBoxAssetThumbnail.Visible = False

                End If

            Else

                Me.Label_Filename.Text = ""
                Me.Label_Filesize.Text = "0 KB"
                Me.LabelVersion.Text = "0 of 0"
                Me.PictureBoxAssetThumbnail.Visible = False
                Me.Detail.Visible = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
