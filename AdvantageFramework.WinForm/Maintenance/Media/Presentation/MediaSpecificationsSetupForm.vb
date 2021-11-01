Namespace Maintenance.Media.Presentation

    Public Class MediaSpecificationsSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsFirstLoad As Boolean = False

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

            'objects
            Dim MediaType As String = ""
            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewForm_MediaSpecifications.CurrentView.AFActiveFilterString

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ButtonItemMediaTypes_Internet.Checked Then

                    MediaType = "I"

                ElseIf ButtonItemMediaTypes_Magazine.Checked Then

                    MediaType = "M"

                ElseIf ButtonItemMediaTypes_Newspaper.Checked Then

                    MediaType = "N"

                ElseIf ButtonItemMediaTypes_OutOfHome.Checked Then

                    MediaType = "O"

                End If

                DataGridViewForm_MediaSpecifications.DataSource = AdvantageFramework.Database.Procedures.AdSizeLabel.LoadByMediaType(DbContext, MediaType).OrderBy(Function(AdSizeLabel) AdSizeLabel.OrderNumber).ToList

            End Using

            If AFActiveFilterString IsNot Nothing Then

                DataGridViewForm_MediaSpecifications.CurrentView.AFActiveFilterString = AFActiveFilterString

            End If

            DataGridViewForm_MediaSpecifications.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_MediaSpecifications.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Me.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim AdSizeLabels As Generic.List(Of AdvantageFramework.Database.Entities.AdSizeLabel) = Nothing
            Dim Saved As Boolean = True
            Dim ErrorMessage As String = ""

            Me.ShowWaitForm()
            Me.ShowWaitForm("Saving...")
            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            Try

                If DataGridViewForm_MediaSpecifications.HasRows Then

                    DataGridViewForm_MediaSpecifications.CurrentView.CloseEditorForUpdating()

                    AdSizeLabels = DataGridViewForm_MediaSpecifications.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AdSizeLabel)().ToList

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each AdSizeLabel In AdSizeLabels

                                If AdvantageFramework.Database.Procedures.AdSizeLabel.Update(DbContext, AdSizeLabel) = False Then

                                    DbContext.UndoChanges(AdSizeLabel)

                                End If

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Try

                        DataGridViewForm_MediaSpecifications.ValidateAllRowsAndClearChanged()

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                Saved = False
            End Try

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
            Me.CloseWaitForm()

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaSpecificationsSetupForm As AdvantageFramework.Maintenance.Media.Presentation.MediaSpecificationsSetupForm = Nothing

            MediaSpecificationsSetupForm = New AdvantageFramework.Maintenance.Media.Presentation.MediaSpecificationsSetupForm()

            MediaSpecificationsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaSpecificationsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemMediaTypes_Internet.Image = AdvantageFramework.My.Resources.InternetImage
            ButtonItemMediaTypes_Magazine.Image = AdvantageFramework.My.Resources.MagazineOrderImage
            ButtonItemMediaTypes_Newspaper.Image = AdvantageFramework.My.Resources.NewspaperOrdersImage
            ButtonItemMediaTypes_OutOfHome.Image = AdvantageFramework.My.Resources.OutOfHomeOrdersImage

            DataGridViewForm_MediaSpecifications.MultiSelect = False
            DataGridViewForm_MediaSpecifications.OptionsView.ShowViewCaption = False

            LoadGrid()

            DataGridViewForm_MediaSpecifications.CurrentView.AFActiveFilterString = "[IsInactive] = 0"

        End Sub
        Private Sub MediaSpecificationsSetupForm__ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub MediaSpecificationsSetupForm__UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    If Me.Save() Then

                        Me.ClearChanged()

                        LoadGrid()

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim MediaType As String = ""

            If ButtonItemMediaTypes_Internet.Checked Then

                MediaType = ButtonItemMediaTypes_Internet.Text

            ElseIf ButtonItemMediaTypes_Magazine.Checked Then

                MediaType = ButtonItemMediaTypes_Magazine.Text

            ElseIf ButtonItemMediaTypes_Newspaper.Checked Then

                MediaType = ButtonItemMediaTypes_Newspaper.Text

            ElseIf ButtonItemMediaTypes_OutOfHome.Checked Then

                MediaType = ButtonItemMediaTypes_OutOfHome.Text

            End If

            DataGridViewForm_MediaSpecifications.Print(DefaultLookAndFeel.LookAndFeel, MediaType)

        End Sub
        Private Sub DataGridViewForm_MediaSpecifications_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_MediaSpecifications.CellValueChangingEvent

            'objects
            Dim AdSizeLabel As AdvantageFramework.Database.Entities.AdSizeLabel = Nothing
            Dim RefreshAdSizeLabels As Boolean = False

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.AdSizeLabel.Properties.IsInactive.ToString Then

                Try

                    AdSizeLabel = DataGridViewForm_MediaSpecifications.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AdSizeLabel = Nothing
                End Try

                If AdSizeLabel IsNot Nothing Then

                    Try

                        AdSizeLabel.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        AdSizeLabel.IsInactive = AdSizeLabel.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.AdSizeLabel.Update(DbContext, AdSizeLabel)

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_MediaSpecifications_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewForm_MediaSpecifications.AddNewRowEvent

            'objects
            Dim AdSizeLabel As AdvantageFramework.Database.Entities.AdSizeLabel = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.AdSizeLabel Then

                Me.ShowWaitForm("Processing...")

                AdSizeLabel = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdSizeLabel.IsEntityBeingAdded() Then

                        AdSizeLabel.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.AdSizeLabel.Insert(DbContext, AdSizeLabel)

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_MediaSpecifications_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_MediaSpecifications.InitNewRowEvent

            'objects
            Dim MediaType As String = ""
            Dim ID As String = ""
            Dim Count As Integer = 0

            If TypeOf DataGridViewForm_MediaSpecifications.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.AdSizeLabel Then

                If ButtonItemMediaTypes_Internet.Checked Then

                    MediaType = "I"

                ElseIf ButtonItemMediaTypes_Magazine.Checked Then

                    MediaType = "M"

                ElseIf ButtonItemMediaTypes_Newspaper.Checked Then

                    MediaType = "N"

                ElseIf ButtonItemMediaTypes_OutOfHome.Checked Then

                    MediaType = "O"

                End If

                DirectCast(DataGridViewForm_MediaSpecifications.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.AdSizeLabel).MediaType = MediaType

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Count = AdvantageFramework.Database.Procedures.AdSizeLabel.LoadByMediaType(DbContext, MediaType).Count

                    ID = "LABEL" & AdvantageFramework.StringUtilities.PadWithCharacter(Count + 1, 2, "0", True)

                End Using

                DirectCast(DataGridViewForm_MediaSpecifications.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.AdSizeLabel).ID = ID

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_MediaSpecifications_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_MediaSpecifications.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_MediaSpecifications.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMediaTypes_Internet_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemMediaTypes_Internet.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.HasLoaded AndAlso ButtonItemMediaTypes_Internet.Checked Then

                ContinueOn = CheckForUnsavedChanges()

                If ContinueOn Then

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaTypes_Magazine_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemMediaTypes_Magazine.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.HasLoaded AndAlso ButtonItemMediaTypes_Magazine.Checked Then

                ContinueOn = CheckForUnsavedChanges()

                If ContinueOn Then

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaTypes_Newspaper_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemMediaTypes_Newspaper.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.HasLoaded AndAlso ButtonItemMediaTypes_Newspaper.Checked Then

                ContinueOn = CheckForUnsavedChanges()

                If ContinueOn Then

                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub ButtonItemMediaTypes_OutOfHome_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemMediaTypes_OutOfHome.CheckedChanged

            'objects
            Dim ContinueOn As Boolean = True

            If Me.HasLoaded AndAlso ButtonItemMediaTypes_OutOfHome.Checked Then

                ContinueOn = CheckForUnsavedChanges()

                If ContinueOn Then

                    LoadGrid()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
