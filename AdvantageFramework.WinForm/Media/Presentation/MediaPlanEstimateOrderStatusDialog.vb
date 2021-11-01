Namespace Media.Presentation

    Public Class MediaPlanEstimateOrderStatusDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = 0
        Private _MediaPlanDetailID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlanID As Integer, MediaPlanDetailID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanID = MediaPlanID
            _MediaPlanDetailID = MediaPlanDetailID

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim VendorOrderStatuses As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.VendorOrderStatus) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                VendorOrderStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.VendorOrderStatus)("exec dbo.advsp_media_plan_estimate_vendor_status {0}", _MediaPlanDetailID).ToList

            End Using

            DataGridViewForm_OrderStatus.DataSource = VendorOrderStatuses

            DataGridViewForm_OrderStatus.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanID As Integer, MediaPlanDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanEstimateOrderStatusDialog As AdvantageFramework.Media.Presentation.MediaPlanEstimateOrderStatusDialog = Nothing

            MediaPlanEstimateOrderStatusDialog = New AdvantageFramework.Media.Presentation.MediaPlanEstimateOrderStatusDialog(MediaPlanID, MediaPlanDetailID)

            ShowFormDialog = MediaPlanEstimateOrderStatusDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEstimateOrderStatusDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_OrderStatus.OptionsView.ShowFooter = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanEstimateOrderStatusDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
