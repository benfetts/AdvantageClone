Namespace Maintenance.Accounting.Presentation

    Public Class GeneralDescriptionSetupForm

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

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_GeneralDescription.DataSource = AdvantageFramework.Database.Procedures.GeneralDescription.Load(DbContext).ToList

            End Using

            DataGridViewForm_GeneralDescription.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim GeneralDescriptionSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.GeneralDescriptionSetupForm = Nothing

            GeneralDescriptionSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.GeneralDescriptionSetupForm()

            GeneralDescriptionSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralDescriptionSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage

            DataGridViewForm_GeneralDescription.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

            LoadGrid()

        End Sub
        Private Sub GeneralDescriptionSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GeneralDescriptionSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewForm_GeneralDescription.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim GeneralDescriptions As Generic.List(Of AdvantageFramework.Database.Entities.GeneralDescription) = Nothing

            If DataGridViewForm_GeneralDescription.HasRows Then

                DataGridViewForm_GeneralDescription.CurrentView.CloseEditorForUpdating()

                GeneralDescriptions = DataGridViewForm_GeneralDescription.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.GeneralDescription)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each GeneralDescription In GeneralDescriptions

                            If AdvantageFramework.Database.Procedures.GeneralDescription.Update(DbContext, GeneralDescription) = False Then

                                DbContext.UndoChanges(GeneralDescription)

                            End If

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                Try

                    DataGridViewForm_GeneralDescription.ValidateAllRowsAndClearChanged(True)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace