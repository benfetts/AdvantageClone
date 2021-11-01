Namespace Media.Presentation

    Public Class ComscoreToolForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadDataSources()

            Dim NielsenMarketNumbers As IEnumerable(Of Integer) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                NielsenMarketNumbers = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadDistinctMarketNumbers(DbContext)

                SearchableComboBox_Market.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Market.LoadAllActiveComscore(DbContext, NielsenMarketNumbers).ToList
                                                        Select New AdvantageFramework.DTO.Market(Entity)).ToList

                SearchableComboBox_Demo.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaDemographic.LoadActiveComscoreTV(DbContext).ToList
                                                      Select New DTO.Media.MediaDemographic(Entity)).ToList

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ComscoreToolForm As Media.Presentation.ComscoreToolForm = Nothing

            ComscoreToolForm = New Media.Presentation.ComscoreToolForm

            ComscoreToolForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ComscoreToolForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            LoadDataSources()

        End Sub
        Private Sub ComscoreToolForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            If Debugger.IsAttached Then

                Try

                    SearchableComboBox_Market.SelectedValue = "PIT"
                    DateTimePickerComscore_StartDate.Value = DateSerial(2018, 12, 24)
                    DateTimePickerComscore_StartTime.Value = "3:00 AM"

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub SearchableComboBox_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBox_Market.EditValueChanged

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            SearchableComboBox_ComscoreStation.DataSource = Nothing

            If Me.FormShown AndAlso SearchableComboBox_Market.HasASelectedValue Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, SearchableComboBox_Market.GetSelectedValue)

                    If Market IsNot Nothing AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                        SearchableComboBox_ComscoreStation.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)(String.Format("exec [advsp_comscore_stations] {0}, NULL", Market.ComscoreNewMarketNumber.Value)).ToList.Where(Function(Entity) Entity.ComscorePrimaryMarketNumber IsNot Nothing AndAlso Entity.ComscorePrimaryMarketNumber = Market.ComscoreNewMarketNumber.Value).ToList

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonForm_Submit_Click(sender As Object, e As EventArgs) Handles ButtonForm_Submit.Click

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic = Nothing
            Dim ComscoreTVStation As AdvantageFramework.Database.Entities.ComscoreTVStation = Nothing
            Dim SpotDate As DateTime = Nothing
            Dim ComscoreTool As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData = Nothing

            ButtonShowJson.Tag = ""

            Try

                If SearchableComboBox_Market.HasASelectedValue AndAlso SearchableComboBox_ComscoreStation.HasASelectedValue AndAlso SearchableComboBox_Demo.HasASelectedValue Then

                    Me.ShowWaitForm("Calling API...")

                    SpotDate = DateTimePickerComscore_StartDate.GetValue & " " & DateTimePickerComscore_StartTime.Value.ToString("HH:mm")

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, SearchableComboBox_Market.GetSelectedValue)

                        MediaDemographic = AdvantageFramework.Database.Procedures.MediaDemographic.LoadByID(DbContext, SearchableComboBox_Demo.GetSelectedValue)

                        ComscoreTVStation = AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadByID(DbContext, SearchableComboBox_ComscoreStation.GetSelectedDataRow.ID)

                        If Market IsNot Nothing AndAlso Market.ComscoreMarketNumber.HasValue AndAlso MediaDemographic IsNot Nothing Then

                            ComscoreTool = AdvantageFramework.ComScore.GetLocalTimeViews(DbContext, Market.ComscoreMarketNumber.Value, ComscoreTVStation.Number, MediaDemographic.ComscoreDemoNumber.Value, SpotDate)

                            LabelRating.Text = FormatNumber(ComscoreTool.Rating, 2)
                            LabelImpressions.Text = FormatNumber(ComscoreTool.Impressions, 0)
                            LabelUE.Text = ComscoreTool.Universe
                            LabelShare.Text = FormatNumber(ComscoreTool.Share, 2)
                            LabelSIU.Text = FormatNumber(ComscoreTool.HPUT, 2)
                            LabelElapsedTime.Text = ComscoreTool.ElapsedTime

                            ButtonShowJson.Tag = ComscoreTool.Request

                            ButtonShowJsonResponse.Tag = ComscoreTool.Response

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            Catch ex As Exception
                AdvantageFramework.WinForm.MessageBox.Show("Something went wrong, check all criteria." & vbCrLf & ex.Message)
            End Try

        End Sub
        Private Sub ButtonShowJson_Click(sender As Object, e As EventArgs) Handles ButtonShowJson.Click

            If String.IsNullOrWhiteSpace(ButtonShowJson.Tag) Then

                AdvantageFramework.WinForm.MessageBox.Show("Hit Submit first.")

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ButtonShowJson.Tag)

            End If

        End Sub
        Private Sub ButtonClipboard_Click(sender As Object, e As EventArgs) Handles ButtonClipboard.Click

            If String.IsNullOrWhiteSpace(ButtonShowJson.Tag) Then

                AdvantageFramework.WinForm.MessageBox.Show("Hit Submit first.")

            Else

                My.Computer.Clipboard.SetText(ButtonShowJson.Tag)

            End If

        End Sub
        Private Sub ButtonShowJsonResponse_Click(sender As Object, e As EventArgs) Handles ButtonShowJsonResponse.Click

            If String.IsNullOrWhiteSpace(ButtonShowJsonResponse.Tag) Then

                AdvantageFramework.WinForm.MessageBox.Show("Hit Submit first.")

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ButtonShowJsonResponse.Tag)

            End If

        End Sub
        Private Sub ButtonClipboardResponse_Click(sender As Object, e As EventArgs) Handles ButtonClipboardResponse.Click

            If String.IsNullOrWhiteSpace(ButtonShowJsonResponse.Tag) Then

                AdvantageFramework.WinForm.MessageBox.Show("Hit Submit first.")

            Else

                My.Computer.Clipboard.SetText(ButtonShowJsonResponse.Tag)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
