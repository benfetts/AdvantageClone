Option Strict On

Namespace Media

    Public Class BroadcastInvoiceDetailSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUnmatchedLinePrinting As Boolean = False
        Private _Date1Visible As Boolean = False
        Private _Date2Visible As Boolean = False
        Private _Date3Visible As Boolean = False
        Private _Date4Visible As Boolean = False
        Private _Date5Visible As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastInvoiceDetailSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelApprovedSpotsDate1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelApprovedSpotsDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedSpotsDate2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelApprovedSpotsDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedSpotsDate3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelApprovedSpotsDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedSpotsDate4_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelApprovedSpotsDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedSpotsDate5_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelApprovedSpotsDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Line_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Line.BeforePrint

            If CShort(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport.Properties.Line.ToString)) = Int16.MaxValue OrElse
                    CBool(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport.Properties.IsOrdered.ToString)) = False Then

                LabelDetail_Line.Text = Nothing

            End If

            If CShort(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport.Properties.Line.ToString)) = Int16.MaxValue Then

                _IsUnmatchedLinePrinting = True

            Else

                _IsUnmatchedLinePrinting = False

            End If

        End Sub
        Private Sub GroupHeaderBand1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            Dim BroadcastInvoiceDetailSubReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport) = Nothing

            BroadcastInvoiceDetailSubReports = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport))

            If BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date1.HasValue).Any Then

                Me.LabelGroupHeader_Date1.Text = BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date1.HasValue).Select(Function(SR) SR.Date1.Value).First.ToString("MM/dd")
                _Date1Visible = True

            Else

                Me.LabelGroupHeader_Date1.Text = Nothing
                _Date1Visible = False

            End If

            If BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date2.HasValue).Any Then

                Me.LabelGroupHeader_Date2.Text = BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date2.HasValue).Select(Function(SR) SR.Date2.Value).First.ToString("MM/dd")
                _Date2Visible = True

            Else

                Me.LabelGroupHeader_Date2.Text = Nothing
                _Date2Visible = False

            End If

            If BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date3.HasValue).Any Then

                Me.LabelGroupHeader_Date3.Text = BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date3.HasValue).Select(Function(SR) SR.Date3.Value).First.ToString("MM/dd")
                _Date3Visible = True

            Else

                Me.LabelGroupHeader_Date3.Text = Nothing
                _Date3Visible = False

            End If

            If BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date4.HasValue).Any Then

                Me.LabelGroupHeader_Date4.Text = BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date4.HasValue).Select(Function(SR) SR.Date4.Value).First.ToString("MM/dd")
                _Date4Visible = True

            Else

                Me.LabelGroupHeader_Date4.Text = Nothing
                _Date4Visible = False

            End If

            If BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date5.HasValue).Any Then

                Me.LabelGroupHeader_Date5.Text = BroadcastInvoiceDetailSubReports.Where(Function(SR) SR.Date5.HasValue).Select(Function(SR) SR.Date5.Value).First.ToString("MM/dd")
                _Date5Visible = True

            Else

                Me.LabelGroupHeader_Date5.Text = Nothing
                _Date5Visible = False

            End If

        End Sub
        Private Sub GroupFooterBand1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterBand1.BeforePrint

            If _IsUnmatchedLinePrinting Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBand1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBand1.BeforePrint

            If CShort(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport.Properties.Line.ToString)) <> Int16.MaxValue Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedSpotsDate1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedSpotsDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedSpotsDate2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedSpotsDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedSpotsDate3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedSpotsDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedSpotsDate4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedSpotsDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedSpotsDate5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedSpotsDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelOrderedGrossDate1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelOrderedGrossDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelOrderedGrossDate2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelOrderedGrossDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelOrderedGrossDate3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelOrderedGrossDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelOrderedGrossDate4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelOrderedGrossDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelOrderedGrossDate5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelOrderedGrossDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedGrossDate1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApprovedGrossDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedGrossDate2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApprovedGrossDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedGrossDate3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApprovedGrossDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedGrossDate4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApprovedGrossDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelApprovedGrossDate5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApprovedGrossDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedGrossDate1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedGrossDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedGrossDate2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedGrossDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedGrossDate3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedGrossDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedGrossDate4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedGrossDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelMissedGrossDate5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelMissedGrossDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandLabelSpotsDate1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandLabelSpotsDate1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandLabelSpotsDate2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandLabelSpotsDate2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandLabelSpotsDate3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandLabelSpotsDate3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandLabelSpotsDate4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandLabelSpotsDate4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubBandLabelSpotsDate5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubBandLabelSpotsDate5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooterSpots1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooterOrderedSpots1.BeforePrint,
                LabelReportFooterApprovedSpots1.BeforePrint, LabelReportFooterMissedSpots1.BeforePrint, LabelReportFooterUnmatchedSpots1.BeforePrint,
                LabelReportFooterOrderedGross1.BeforePrint, LabelReportFooterApprovedGross1.BeforePrint, LabelReportFooterMissedGross1.BeforePrint,
                LabelReportFooterUnmatchedGross1.BeforePrint, LabelReportFooterOrderedNet1.BeforePrint, LabelReportFooterApprovedNet1.BeforePrint,
                LabelReportFooterMissedNet1.BeforePrint, LabelReportFooterUnmatchedNet1.BeforePrint

            If _Date1Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooterSpots2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooterOrderedSpots2.BeforePrint,
                LabelReportFooterApprovedSpots2.BeforePrint, LabelReportFooterMissedSpots2.BeforePrint, LabelReportFooterUnmatchedSpots2.BeforePrint,
                LabelReportFooterOrderedGross2.BeforePrint, LabelReportFooterApprovedGross2.BeforePrint, LabelReportFooterMissedGross2.BeforePrint,
                LabelReportFooterUnmatchedGross2.BeforePrint, LabelReportFooterOrderedNet2.BeforePrint, LabelReportFooterApprovedNet2.BeforePrint,
                LabelReportFooterMissedNet2.BeforePrint, LabelReportFooterUnmatchedNet2.BeforePrint

            If _Date2Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooterSpots3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooterOrderedSpots3.BeforePrint,
                LabelReportFooterApprovedSpots3.BeforePrint, LabelReportFooterMissedSpots3.BeforePrint, LabelReportFooterUnmatchedSpots3.BeforePrint,
                LabelReportFooterOrderedGross3.BeforePrint, LabelReportFooterApprovedGross3.BeforePrint, LabelReportFooterMissedGross3.BeforePrint,
                LabelReportFooterUnmatchedGross3.BeforePrint, LabelReportFooterOrderedNet3.BeforePrint, LabelReportFooterApprovedNet3.BeforePrint,
                LabelReportFooterMissedNet3.BeforePrint, LabelReportFooterUnmatchedNet3.BeforePrint

            If _Date3Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooterSpots4_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooterOrderedSpots4.BeforePrint,
                LabelReportFooterApprovedSpots4.BeforePrint, LabelReportFooterMissedSpots4.BeforePrint, LabelReportFooterUnmatchedSpots4.BeforePrint,
                LabelReportFooterOrderedGross4.BeforePrint, LabelReportFooterApprovedGross4.BeforePrint, LabelReportFooterMissedGross4.BeforePrint,
                LabelReportFooterUnmatchedGross4.BeforePrint, LabelReportFooterOrderedNet4.BeforePrint, LabelReportFooterApprovedNet4.BeforePrint,
                LabelReportFooterMissedNet4.BeforePrint, LabelReportFooterUnmatchedNet4.BeforePrint

            If _Date4Visible = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooterSpots5_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooterOrderedSpots5.BeforePrint,
                LabelReportFooterApprovedSpots5.BeforePrint, LabelReportFooterMissedSpots5.BeforePrint, LabelReportFooterUnmatchedSpots5.BeforePrint,
                LabelReportFooterOrderedGross5.BeforePrint, LabelReportFooterApprovedGross5.BeforePrint, LabelReportFooterMissedGross5.BeforePrint,
                LabelReportFooterUnmatchedGross5.BeforePrint, LabelReportFooterOrderedNet5.BeforePrint, LabelReportFooterApprovedNet5.BeforePrint,
                LabelReportFooterMissedNet5.BeforePrint, LabelReportFooterUnmatchedNet5.BeforePrint

            If _Date5Visible = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
