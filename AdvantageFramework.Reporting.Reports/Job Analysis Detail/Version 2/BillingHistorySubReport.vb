Namespace JobAnalysisDetail.Version2

    Public Class BillingHistorySubReport
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

        Private Sub BillingHistorySubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint
            Try
                Dim InvoiceNumber As Integer = CInt(Me.GetCurrentColumnValue("InvoiceNumber"))
                Dim InvoiceDate As String = Me.GetCurrentColumnValue("CheckDate")


            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrLabel3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabel3.BeforePrint
            Try
                Dim lab As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
                If lab.Text = "1/1/1900" Or lab.Text = "1/01/1900" Then
                    lab.Text = ""
                End If
            Catch ex As Exception

            End Try

        End Sub

        Private Sub Text3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Text3.BeforePrint
            Try
                Dim lab As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
                If lab.Text = "1/1/1900" Or lab.Text = "1/01/1900" Then
                    lab.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Text8_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Text8.BeforePrint
            Try
                Dim InvoiceDate As String = Me.GetCurrentColumnValue("InvoiceDate")
                Dim lab As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
                If InvoiceDate = "1/1/1900" Or lab.Text = "1/01/1900" Then
                    lab.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub
    End Class

End Namespace