Namespace Media

    Public Class MediaBroadcastWorksheetScheduleBroadcastSummarySubreport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BroadcastSummaryList As List(Of Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport) = Nothing

        Public Property MediaBroadcastWorksheetMarketID As Integer

        Private Property _CurrentLine As Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport = Nothing
#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "
        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            _CurrentLine = TryCast(Me.GetCurrentRow(), Database.Classes.MediaBroadcastWorksheetBroadcastSummaryReport)

            Dim ShowColumn1 As Boolean = _CurrentLine.Week1Date.HasValue
            Dim ShowColumn2 As Boolean = _CurrentLine.Week2Date.HasValue
            Dim ShowColumn3 As Boolean = _CurrentLine.Week3Date.HasValue
            Dim ShowColumn4 As Boolean = _CurrentLine.Week4Date.HasValue
            Dim ShowColumn5 As Boolean = _CurrentLine.Week5Date.HasValue
            Dim ShowColumn6 As Boolean = _CurrentLine.Week6Date.HasValue
            Dim ShowColumn7 As Boolean = _CurrentLine.Week7Date.HasValue
            Dim ShowColumn8 As Boolean = _CurrentLine.Week8Date.HasValue
            Dim ShowColumn9 As Boolean = _CurrentLine.Week9Date.HasValue
            Dim ShowColumn10 As Boolean = _CurrentLine.Week10Date.HasValue
            Dim ShowColumn11 As Boolean = _CurrentLine.Week11Date.HasValue
            Dim ShowColumn12 As Boolean = _CurrentLine.Week12Date.HasValue
            Dim ShowColumn13 As Boolean = _CurrentLine.Week13Date.HasValue
            Dim ShowColumn14 As Boolean = _CurrentLine.Week14Date.HasValue

            Dim ShowTotal As Boolean = _CurrentLine.LastRow = 1

            XrTableCell5.Visible = ShowColumn1
            XrTableCell8.Visible = ShowColumn1
            XrTableCell11.Visible = ShowColumn1
            XrTableCell14.Visible = ShowColumn1

            XrTableCell6.Visible = ShowColumn2
            XrTableCell9.Visible = ShowColumn2
            XrTableCell12.Visible = ShowColumn2
            XrTableCell15.Visible = ShowColumn2

            XrTableCell17.Visible = ShowColumn3
            XrTableCell18.Visible = ShowColumn3
            XrTableCell19.Visible = ShowColumn3
            XrTableCell20.Visible = ShowColumn3

            XrTableCell22.Visible = ShowColumn4
            XrTableCell23.Visible = ShowColumn4
            XrTableCell24.Visible = ShowColumn4
            XrTableCell25.Visible = ShowColumn4

            XrTableCell27.Visible = ShowColumn5
            XrTableCell28.Visible = ShowColumn5
            XrTableCell29.Visible = ShowColumn5
            XrTableCell30.Visible = ShowColumn5

            XrTableCell32.Visible = ShowColumn6
            XrTableCell33.Visible = ShowColumn6
            XrTableCell34.Visible = ShowColumn6
            XrTableCell35.Visible = ShowColumn6

            XrTableCell37.Visible = ShowColumn7
            XrTableCell38.Visible = ShowColumn7
            XrTableCell39.Visible = ShowColumn7
            XrTableCell40.Visible = ShowColumn7

            XrTableCell42.Visible = ShowColumn8
            XrTableCell43.Visible = ShowColumn8
            XrTableCell44.Visible = ShowColumn8
            XrTableCell45.Visible = ShowColumn8

            XrTableCell47.Visible = ShowColumn9
            XrTableCell48.Visible = ShowColumn9
            XrTableCell49.Visible = ShowColumn9
            XrTableCell50.Visible = ShowColumn9

            XrTableCell52.Visible = ShowColumn10
            XrTableCell53.Visible = ShowColumn10
            XrTableCell54.Visible = ShowColumn10
            XrTableCell55.Visible = ShowColumn10

            XrTableCell57.Visible = ShowColumn11
            XrTableCell58.Visible = ShowColumn11
            XrTableCell59.Visible = ShowColumn11
            XrTableCell60.Visible = ShowColumn11

            XrTableCell62.Visible = ShowColumn12
            XrTableCell63.Visible = ShowColumn12
            XrTableCell64.Visible = ShowColumn12
            XrTableCell65.Visible = ShowColumn12

            XrTableCell67.Visible = ShowColumn13
            XrTableCell68.Visible = ShowColumn13
            XrTableCell69.Visible = ShowColumn13
            XrTableCell70.Visible = ShowColumn13

            XrTableCell72.Visible = ShowColumn14
            XrTableCell73.Visible = ShowColumn14
            XrTableCell74.Visible = ShowColumn14
            XrTableCell75.Visible = ShowColumn14

            XrTableCell76.Visible = ShowTotal
            XrTableCell77.Visible = ShowTotal
            XrTableCell78.Visible = ShowTotal
            XrTableCell79.Visible = ShowTotal
            XrTableCell80.Visible = ShowTotal


        End Sub

#End Region

#Region "  Control Event Handlers "

#End Region

#End Region

    End Class

End Namespace
