Namespace Billing.Reports.Presentation.Classes

    Public Class InvoicePrintingPageSetting

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PageSettings As System.IO.MemoryStream = Nothing
        Public Property WatermarkSettings As System.IO.MemoryStream = Nothing
        Public Property PageColor As System.Drawing.Color = Drawing.Color.White
        Public Property ScaleFactor As Single = 0
        Public Property AutoFitToPagesWidth As Integer = 0

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub SetSettings(PrintingSystem As DevExpress.XtraPrinting.PrintingSystemBase)

            If PrintingSystem IsNot Nothing Then

                Me.PageSettings = New System.IO.MemoryStream

                PrintingSystem.PageSettings.SaveToStream(Me.PageSettings)

                Me.PageSettings.Position = 0

                Me.WatermarkSettings = New System.IO.MemoryStream

                PrintingSystem.Watermark.SaveToStream(Me.WatermarkSettings)

                Me.WatermarkSettings.Position = 0

                Me.PageColor = PrintingSystem.Graph.PageBackColor
                Me.ScaleFactor = PrintingSystem.Document.ScaleFactor
                Me.AutoFitToPagesWidth = PrintingSystem.Document.AutoFitToPagesWidth

            End If

        End Sub
        Public Sub PlaceSettingsOnReport(Report As DevExpress.XtraReports.UI.XtraReport)

            Try

                If Report.Pages.Count = 0 Then

                    Report.CreateDocument()

                End If

            Catch ex As Exception

            End Try

            Me.PageSettings.Position = 0
            Me.WatermarkSettings.Position = 0

            Report.PrintingSystem.PageSettings.RestoreFromStream(Me.PageSettings)
            Report.PrintingSystem.Watermark.RestoreFromStream(Me.WatermarkSettings)

            Report.PrintingSystem.Graph.PageBackColor = Me.PageColor

            If Me.AutoFitToPagesWidth = 0 AndAlso Me.ScaleFactor <> 0 Then

                Report.PrintingSystem.Document.ScaleFactor = Me.ScaleFactor

            ElseIf Me.AutoFitToPagesWidth >= 1 Then

                Report.PrintingSystem.Document.AutoFitToPagesWidth = Me.AutoFitToPagesWidth

            End If

        End Sub

#End Region

    End Class

End Namespace
