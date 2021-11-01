Namespace Media.Presentation

    Public Class MediaManagerGenerateOrdersSentInfoDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Private _GenerateRFPs As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP) = Nothing
        Private _Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GenerateOrders = GenerateOrders

        End Sub
        Private Sub New(GenerateRFPs As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GenerateRFPs = GenerateRFPs

        End Sub
        Private Sub New(Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Generates = Generates

        End Sub
        Private Sub LoadGridGenerateOrders()

            'objects
            Dim VendorRepInfo = Nothing
            Dim MediaManagerGeneratedReportSentInfos As Generic.List(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo) = Nothing
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerGeneratedReportSentInfos = New Generic.List(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo)

                For Each GenerateOrder In _GenerateOrders

                    For Each MediaManagerGeneratedReport In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext).Where(Function(Entity) Entity.OrderNumber = GenerateOrder.OrderNumber).ToList

                        DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportDetails).Load()

                        If MediaManagerGeneratedReport.MediaManagerGeneratedReportDetails.Any(Function(Entity) Entity.LineNumber = GenerateOrder.LineNumber) Then

                            DbContext.Entry(MediaManagerGeneratedReport).Collection(Function(Entity) Entity.MediaManagerGeneratedReportSentInfos).Load()

                            For Each MediaManagerGeneratedReportSentInfo In MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos.ToList

                                If MediaManagerGeneratedReportSentInfos.Any(Function(Entity) Entity.VendorCode = MediaManagerGeneratedReportSentInfo.VendorCode AndAlso Entity.VendorRepresentativeCode = MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode) = False Then

                                    MediaManagerGeneratedReportSentInfos.Add(MediaManagerGeneratedReportSentInfo)

                                End If

                            Next

                        End If

                    Next

                Next

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                VendorRepresentatives = AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext).ToList

                VendorRepInfo = (From MediaManagerGeneratedReportSentInfo In MediaManagerGeneratedReportSentInfos
                                 From VendorRep In VendorRepresentatives.Where(Function(Entity) Entity.VendorCode = MediaManagerGeneratedReportSentInfo.VendorCode AndAlso Entity.Code = MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode).DefaultIfEmpty
                                 Where VendorRep IsNot Nothing
                                 Select New With {.VendorRepCode = VendorRep.Code,
                                                  .VendorCode = VendorRep.VendorCode,
                                                  .Name = VendorRep.ToString(),
                                                  .Email = MediaManagerGeneratedReportSentInfo.Email}).ToList

            End Using

            DataGridViewDetails_Details.DataSource = VendorRepInfo

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGridGenerateRFPs()

            'objects
            Dim MediaRFPHeaderIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaManagerRFPVendorRecipients As Generic.List(Of AdvantageFramework.Database.Classes.MediaManagerRFPVendorRecipient) = Nothing

            MediaRFPHeaderIDs = _GenerateRFPs.Select(Function(RFP) RFP.MediaRFPHeaderID).Distinct.ToArray

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerRFPVendorRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.MediaManagerRFPVendorRecipient)(String.Format("exec dbo.advsp_media_manager_rfp_recipients '{0}'", String.Join(",", MediaRFPHeaderIDs))).ToList

            End Using

            DataGridViewDetails_Details.DataSource = MediaManagerRFPVendorRecipients

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGridGenerates()

            'objects
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficVendorRecipients As Generic.List(Of AdvantageFramework.Database.Classes.MediaTrafficVendorRecipient) = Nothing

            MediaTrafficVendorIDs = _Generates.Select(Function(RFP) RFP.MediaTrafficVendorID).Distinct.ToArray

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficVendorRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.MediaTrafficVendorRecipient)(String.Format("exec dbo.advsp_media_traffic_recipients '{0}'", String.Join(",", MediaTrafficVendorIDs))).ToList

            End Using

            DataGridViewDetails_Details.DataSource = MediaTrafficVendorRecipients

            DataGridViewDetails_Details.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGenerateOrdersSentInfoDialog As MediaManagerGenerateOrdersSentInfoDialog = Nothing

            MediaManagerGenerateOrdersSentInfoDialog = New MediaManagerGenerateOrdersSentInfoDialog(GenerateOrders)

            ShowFormDialog = MediaManagerGenerateOrdersSentInfoDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(GenerateRFPs As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGenerateOrdersSentInfoDialog As MediaManagerGenerateOrdersSentInfoDialog = Nothing

            MediaManagerGenerateOrdersSentInfoDialog = New MediaManagerGenerateOrdersSentInfoDialog(GenerateRFPs)

            ShowFormDialog = MediaManagerGenerateOrdersSentInfoDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGenerateOrdersSentInfoDialog As MediaManagerGenerateOrdersSentInfoDialog = Nothing

            MediaManagerGenerateOrdersSentInfoDialog = New MediaManagerGenerateOrdersSentInfoDialog(Generates)

            ShowFormDialog = MediaManagerGenerateOrdersSentInfoDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerGenerateOrdersSentInfoDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewDetails_Details.ItemDescription = "Vendor Rep(s)"

        End Sub
        Private Sub MediaManagerGenerateOrdersSentInfoDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading
            Me.ShowWaitForm("Loading...")

            If _GenerateOrders IsNot Nothing Then

                LoadGridGenerateOrders()

            ElseIf _GenerateRFPs IsNot Nothing Then

                LoadGridGenerateRFPs()

            ElseIf _Generates IsNot Nothing Then

                LoadGridGenerates()

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace