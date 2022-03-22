Option Strict On

Namespace Media

    Public Class BroadcastInvoiceDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _BroadcastInvoiceDetailList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail) = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ParameterDictionary As Dictionary(Of String, Object)
            Set(ByVal value As Dictionary(Of String, Object))
                _ParameterDictionary = value
            End Set
        End Property
        Public WriteOnly Property LocationEntity As AdvantageFramework.Database.Entities.Location
            Set(ByVal value As AdvantageFramework.Database.Entities.Location)
                _LocationEntity = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastInvoiceDetailReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _BroadcastInvoiceDetailList = AdvantageFramework.Reporting.LoadBroadcastInvoiceDetail(DbContext, _ParameterDictionary)

                    For Each BroadcastInvoiceDetail In _BroadcastInvoiceDetailList.Where(Function(BID) BID.OrderLineNumber Is Nothing)

                        BroadcastInvoiceDetail.OrderLineNumber = Int16.MaxValue 'set unmatched lines to max int so they sort at bottom

                    Next

                End Using

            Else

                _BroadcastInvoiceDetailList = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail)

            End If

            Me.DataSource = _BroadcastInvoiceDetailList

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelInvoiceHeader_Requester_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelInvoiceHeader_Requester.BeforePrint

            LabelInvoiceHeader_Requester.Text = _Session.EmployeeName

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub XrSubreport1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreport1.BeforePrint

            Dim InvoiceNumber As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim MonthOfService As String = Nothing
            Dim SpotLine As AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport = Nothing
            Dim OrderLineSpots As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport) = Nothing
            Dim DateCounter As Integer = 1
            Dim MaxDate As Date = DateSerial(2078, 12, 31)
            Dim MainSpotLines As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport) = Nothing

            InvoiceNumber = CStr(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail.Properties.InvoiceNumber.ToString))
            OrderNumber = CInt(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail.Properties.OrderNumber.ToString))
            MonthOfService = CStr(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetail.Properties.MonthOfService.ToString))

            OrderLineSpots = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport)

            'load main order/line here - not the spots
            For Each SL In (From Entity In _BroadcastInvoiceDetailList
                            Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                  Entity.OrderNumber = OrderNumber AndAlso
                                  Entity.MonthOfService = MonthOfService AndAlso
                                  Entity.OrderLineNumber <> Int16.MaxValue
                            Select Entity.OrderLineNumber, Entity.Days, Entity.Times, Entity.Program, Entity.Daypart, Entity.Length, Entity.Rate).Distinct.ToList

                SpotLine = New AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport(SL.OrderLineNumber.Value, SL.Days, SL.Times, SL.Program, SL.Daypart, SL.Length, SL.Rate)

                DateCounter = 1

                'we want all weeks for all lines for this Invoice/Order/Month
                For Each WeekOfSpots In (From Entity In _BroadcastInvoiceDetailList
                                         Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                               Entity.OrderNumber = OrderNumber AndAlso
                                               Entity.MonthOfService = MonthOfService AndAlso
                                               Entity.WeekOf IsNot Nothing
                                         Select Entity.WeekOf.Value).Distinct.OrderBy(Function(W) W).ToList

                    Select Case DateCounter

                        Case 1

                            SpotLine.Date1 = WeekOfSpots
                            SpotLine.Spots1 = (From Entity In _BroadcastInvoiceDetailList
                                               Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                     Entity.OrderNumber = OrderNumber AndAlso
                                                     Entity.MonthOfService = MonthOfService AndAlso
                                                     Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                     Entity.WeekOf = WeekOfSpots
                                               Select Entity.Spots).Max

                            SpotLine.OrderedSpots1 = SpotLine.Spots1
                            SpotLine.OrderedGross1 = (From Entity In _BroadcastInvoiceDetailList
                                                      Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MonthOfService = MonthOfService AndAlso
                                                            Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                            Entity.WeekOf = WeekOfSpots
                                                      Select Entity.Rate).Max * SpotLine.Spots1

                        Case 2

                            SpotLine.Date2 = WeekOfSpots
                            SpotLine.Spots2 = (From Entity In _BroadcastInvoiceDetailList
                                               Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                     Entity.OrderNumber = OrderNumber AndAlso
                                                     Entity.MonthOfService = MonthOfService AndAlso
                                                     Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                     Entity.WeekOf = WeekOfSpots
                                               Select Entity.Spots).Max

                            SpotLine.OrderedSpots2 = SpotLine.Spots2
                            SpotLine.OrderedGross2 = (From Entity In _BroadcastInvoiceDetailList
                                                      Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MonthOfService = MonthOfService AndAlso
                                                            Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                            Entity.WeekOf = WeekOfSpots
                                                      Select Entity.Rate).Max * SpotLine.Spots2

                        Case 3

                            SpotLine.Date3 = WeekOfSpots
                            SpotLine.Spots3 = (From Entity In _BroadcastInvoiceDetailList
                                               Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                     Entity.OrderNumber = OrderNumber AndAlso
                                                     Entity.MonthOfService = MonthOfService AndAlso
                                                     Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                     Entity.WeekOf = WeekOfSpots
                                               Select Entity.Spots).Max

                            SpotLine.OrderedSpots3 = SpotLine.Spots3
                            SpotLine.OrderedGross3 = (From Entity In _BroadcastInvoiceDetailList
                                                      Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MonthOfService = MonthOfService AndAlso
                                                            Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                            Entity.WeekOf = WeekOfSpots
                                                      Select Entity.Rate).Max * SpotLine.Spots3

                        Case 4

                            SpotLine.Date4 = WeekOfSpots
                            SpotLine.Spots4 = (From Entity In _BroadcastInvoiceDetailList
                                               Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                     Entity.OrderNumber = OrderNumber AndAlso
                                                     Entity.MonthOfService = MonthOfService AndAlso
                                                     Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                     Entity.WeekOf = WeekOfSpots
                                               Select Entity.Spots).Max

                            SpotLine.OrderedSpots4 = SpotLine.Spots4
                            SpotLine.OrderedGross4 = (From Entity In _BroadcastInvoiceDetailList
                                                      Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MonthOfService = MonthOfService AndAlso
                                                            Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                            Entity.WeekOf = WeekOfSpots
                                                      Select Entity.Rate).Max * SpotLine.Spots4

                        Case 5

                            SpotLine.Date5 = WeekOfSpots
                            SpotLine.Spots5 = (From Entity In _BroadcastInvoiceDetailList
                                               Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                     Entity.OrderNumber = OrderNumber AndAlso
                                                     Entity.MonthOfService = MonthOfService AndAlso
                                                     Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                     Entity.WeekOf = WeekOfSpots
                                               Select Entity.Spots).Max

                            SpotLine.OrderedSpots5 = SpotLine.Spots5
                            SpotLine.OrderedGross5 = (From Entity In _BroadcastInvoiceDetailList
                                                      Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MonthOfService = MonthOfService AndAlso
                                                            Entity.OrderLineNumber = SpotLine.Line AndAlso
                                                            Entity.WeekOf = WeekOfSpots
                                                      Select Entity.Rate).Max * SpotLine.Spots5

                    End Select

                    DateCounter += 1

                Next

                OrderLineSpots.Add(SpotLine)

            Next

            MainSpotLines = OrderLineSpots.ToList

            For Each MainSpotLine In MainSpotLines

                'load spots here
                For Each SL In (From Entity In _BroadcastInvoiceDetailList
                                Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                      Entity.OrderNumber = OrderNumber AndAlso
                                      Entity.MonthOfService = MonthOfService AndAlso
                                      Entity.SpotDate IsNot Nothing AndAlso
                                      Entity.OrderLineNumber = MainSpotLine.Line
                                Select Entity).ToList

                    SpotLine = New AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport(SL.OrderLineNumber, SL.SpotDayOfWeek & Space(1) & SL.SpotDate.Value.ToString("M/d/yy"),
                        SL.SpotRunTime, SL.SpotProgramName, SL.SpotAdNumber, SL.SpotVariantCode, SL.SpotRate, True, SL.SpotLength)

                    If SL.SpotDate.Value >= MainSpotLine.Date1.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLine.Date2.GetValueOrDefault(MaxDate) Then

                        SpotLine.Spots1 = SL.SpotSpots
                        SpotLine.ApprovedSpots1 = SL.SpotSpots
                        SpotLine.ApprovedGross1 = SL.SpotGrossTotal

                    ElseIf SL.SpotDate.Value >= MainSpotLine.Date2.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLine.Date3.GetValueOrDefault(MaxDate) Then

                        SpotLine.Spots2 = SL.SpotSpots
                        SpotLine.ApprovedSpots2 = SL.SpotSpots
                        SpotLine.ApprovedGross2 = SL.SpotGrossTotal

                    ElseIf SL.SpotDate.Value >= MainSpotLine.Date3.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLine.Date4.GetValueOrDefault(MaxDate) Then

                        SpotLine.Spots3 = SL.SpotSpots
                        SpotLine.ApprovedSpots3 = SL.SpotSpots
                        SpotLine.ApprovedGross3 = SL.SpotGrossTotal

                    ElseIf SL.SpotDate.Value >= MainSpotLine.Date4.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLine.Date5.GetValueOrDefault(MaxDate) Then

                        SpotLine.Spots4 = SL.SpotSpots
                        SpotLine.ApprovedSpots4 = SL.SpotSpots
                        SpotLine.ApprovedGross4 = SL.SpotGrossTotal

                    ElseIf SL.SpotDate.Value >= MainSpotLine.Date5.GetValueOrDefault(MaxDate) Then

                        SpotLine.Spots5 = SL.SpotSpots
                        SpotLine.ApprovedSpots5 = SL.SpotSpots
                        SpotLine.ApprovedGross5 = SL.SpotGrossTotal

                    End If

                    OrderLineSpots.Add(SpotLine)

                Next

            Next

            'load unmatched spots here
            For Each SL In (From Entity In _BroadcastInvoiceDetailList
                            Where Entity.InvoiceNumber = InvoiceNumber AndAlso
                                  Entity.OrderNumber = OrderNumber AndAlso
                                  Entity.MonthOfService = MonthOfService AndAlso
                                  Entity.OrderLineNumber = Int16.MaxValue
                            Select Entity).ToList

                SpotLine = New AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceDetailSubReport(SL.OrderLineNumber, SL.SpotDayOfWeek & Space(1) & SL.SpotDate.Value.ToString("M/d/yy"),
                        SL.SpotRunTime, SL.SpotProgramName, SL.SpotAdNumber, SL.SpotVariantCode, SL.SpotRate, False, SL.SpotLength)

                If MainSpotLines.Count > 0 AndAlso SL.SpotDate.Value >= MainSpotLines.First.Date1.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLines.First.Date2.GetValueOrDefault(MaxDate) Then

                    SpotLine.Spots1 = SL.SpotSpots
                    SpotLine.UnmatchedSpots1 = SL.SpotSpots
                    SpotLine.UnmatchedGross1 = SL.SpotGrossTotal

                ElseIf MainSpotLines.Count > 0 AndAlso SL.SpotDate.Value >= MainSpotLines.First.Date2.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLines.First.Date3.GetValueOrDefault(MaxDate) Then

                    SpotLine.Spots2 = SL.SpotSpots
                    SpotLine.UnmatchedSpots2 = SL.SpotSpots
                    SpotLine.UnmatchedGross2 = SL.SpotGrossTotal

                ElseIf MainSpotLines.Count > 0 AndAlso SL.SpotDate.Value >= MainSpotLines.First.Date3.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLines.First.Date4.GetValueOrDefault(MaxDate) Then

                    SpotLine.Spots3 = SL.SpotSpots
                    SpotLine.UnmatchedSpots3 = SL.SpotSpots
                    SpotLine.UnmatchedGross3 = SL.SpotGrossTotal

                ElseIf MainSpotLines.Count > 0 AndAlso SL.SpotDate.Value >= MainSpotLines.First.Date4.GetValueOrDefault(MaxDate) AndAlso SL.SpotDate.Value < MainSpotLines.First.Date5.GetValueOrDefault(MaxDate) Then

                    SpotLine.Spots4 = SL.SpotSpots
                    SpotLine.UnmatchedSpots4 = SL.SpotSpots
                    SpotLine.UnmatchedGross4 = SL.SpotGrossTotal

                ElseIf MainSpotLines.Count > 0 AndAlso SL.SpotDate.Value >= MainSpotLines.First.Date5.GetValueOrDefault(MaxDate) Then

                    SpotLine.Spots5 = SL.SpotSpots
                    SpotLine.UnmatchedSpots5 = SL.SpotSpots
                    SpotLine.UnmatchedGross5 = SL.SpotGrossTotal

                End If

                OrderLineSpots.Add(SpotLine)

            Next

            Try

                XrSubreport1.ReportSource.DataSource = OrderLineSpots

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
