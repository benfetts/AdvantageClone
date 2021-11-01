Namespace Media.Presentation

    Public Class MediaPlanDetailSelectDemoDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan
            _MediaPlanEstimate = MediaPlanEstimate

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailSelectDemoDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailSelectDemoDialog = Nothing

            MediaPlanDetailSelectDemoDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailSelectDemoDialog(MediaPlan, MediaPlanEstimate)

            ShowFormDialog = MediaPlanDetailSelectDemoDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailSelectDemoDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True
            Me.ControlBox = False

            DataGridViewForm_Demos.MultiSelect = False
            DataGridViewForm_Demos.ByPassUserEntryChanged = True
            DataGridViewForm_Demos.OptionsView.ColumnAutoWidth = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _MediaPlanEstimate.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                    DataGridViewForm_Demos.DataSource = AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByMediaDemoSourceID(DbContext, AdvantageFramework.Database.Entities.MediaDemoSourceID.Nielsen).
                                                                                                                Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                                  .Description = Entity.Description}).ToList

                ElseIf _MediaPlanEstimate.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Numeris Then

                    DataGridViewForm_Demos.DataSource = AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByMediaDemoSourceID(DbContext, AdvantageFramework.Database.Entities.MediaDemoSourceID.Numeris).
                                                                                                                Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                                  .Description = Entity.Description}).ToList

                ElseIf _MediaPlanEstimate.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    DataGridViewForm_Demos.DataSource = AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByMediaDemoSourceID(DbContext, AdvantageFramework.Database.Entities.MediaDemoSourceID.Comscore).
                                                                                                                Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                                  .Description = Entity.Description}).ToList

                ElseIf _MediaPlanEstimate.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.OzTAM Then

                    DataGridViewForm_Demos.DataSource = AdvantageFramework.Database.Procedures.MediaDemographic.LoadAllActiveByMediaDemoSourceID(DbContext, AdvantageFramework.Database.Entities.MediaDemoSourceID.OzTAM).
                                                                                                                Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                                                  .Description = Entity.Description}).ToList

                End If

                DataGridViewForm_Demos.SetBookmarkColumnIndex(0)

                DataGridViewForm_Demos.HideOrShowColumn("ID", False)

            End Using

        End Sub
        Private Sub MediaPlanDetailSelectDemoDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If _MediaPlanEstimate.MediaDemographicID.GetValueOrDefault(0) <> 0 Then

                DataGridViewForm_Demos.SelectRow(_MediaPlanEstimate.MediaDemographicID.GetValueOrDefault(0))

            Else

                DataGridViewForm_Demos.HideRowSelection()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Select_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Select.Click

            If DataGridViewForm_Demos.HasASelectedRow Then

                _MediaPlanEstimate.MediaDemographicID = DataGridViewForm_Demos.GetFirstSelectedRowBookmarkValue

            Else

                _MediaPlanEstimate.MediaDemographicID = Nothing

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Clear_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Clear.Click

            _MediaPlanEstimate.MediaDemographicID = Nothing

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Demos_RowDoubleClickEvent() Handles DataGridViewForm_Demos.RowDoubleClickEvent

            ButtonForm_Select.PerformClick()

        End Sub

#End Region

#End Region

    End Class

End Namespace
