Namespace JobAnalysisDetail.Version5

    Public Class AdvancedBillingHistorySubReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            Me.InitializeComponent()
        End Sub
        Private ReadOnly Property resources() As System.Resources.ResourceManager
            Get
                If _resources Is Nothing Then
                    Dim resourceString As String = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" + "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" + "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAAAAAAAAAAAFBBRFBBRFC0AAAA"
                    Me._resources = New DevExpress.XtraReports.Serialization.XRResourceManager(resourceString)
                End If
                Return Me._resources
            End Get
        End Property

        Private Sub XrLabel1_SummaryCalculated(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.TextFormatEventArgs)

            If e.Value = 1 Then

                e.Text = "* Interim Reconciliation"

            Else

                e.Text = ""

            End If

        End Sub

    End Class

End Namespace