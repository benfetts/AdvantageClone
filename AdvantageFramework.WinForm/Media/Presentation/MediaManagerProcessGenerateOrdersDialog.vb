Namespace Media.Presentation

    Public Class MediaManagerProcessGenerateOrdersDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Private _SendToOrderReps As Boolean = True
        Private _ContactTypes As Generic.List(Of Integer) = Nothing
        Private _DocumentTypes As Generic.List(Of Long) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), SendToOrderReps As Boolean, ContactTypes As Generic.List(Of Integer), DocumentTypes As Generic.List(Of Long))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GenerateOrders = GenerateOrders
            _ContactTypes = ContactTypes
            _DocumentTypes = DocumentTypes
            _SendToOrderReps = SendToOrderReps

        End Sub
        Private Sub SaveEmailSettings()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvantageFramework.MediaManager.SaveDefaultEmailSubject(SecurityDbContext, Session.User.ID, TextBoxForm_Subject.Text)
                AdvantageFramework.MediaManager.SaveDefaultEmailBody(SecurityDbContext, Session.User.ID, TextBoxForm_Body.Text)
                AdvantageFramework.MediaManager.SaveDefaultCCSender(SecurityDbContext, Session.User.ID, CheckBoxForm_CCToSender.Checked)
                AdvantageFramework.MediaManager.SaveDefaultUploadDocumentManager(SecurityDbContext, Session.User.ID, ButtonItemOptions_SendToDocumentManager.Checked)
                AdvantageFramework.MediaManager.SaveDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext, Session.User.ID, ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Checked)
                AdvantageFramework.MediaManager.SaveDefaultEmailExecutedCopyToVendor(SecurityDbContext, Session.User.ID, ButtonItemOptions_EmailExecutedCopyToVendor.Checked)

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), SendToOrderReps As Boolean, ContactTypes As Generic.List(Of Integer), DocumentTypes As Generic.List(Of Long)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerProcessGenerateOrdersDialog As MediaManagerProcessGenerateOrdersDialog = Nothing

            MediaManagerProcessGenerateOrdersDialog = New MediaManagerProcessGenerateOrdersDialog(GenerateOrders, SendToOrderReps, ContactTypes, DocumentTypes)

            ShowFormDialog = MediaManagerProcessGenerateOrdersDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerProcessGenerateOrdersDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GenerateOrderVendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDefaultEmailSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemDefaultEmailSettings_Save.Enabled = False

			ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
			ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Image = AdvantageFramework.My.Resources.DocumentCheckImage
            ButtonItemOptions_EmailExecutedCopyToVendor.Image = AdvantageFramework.My.Resources.EmailPersonImage

            DataGridViewForm_VendorReps.ItemDescription = "Vendor Rep(s)"
            DataGridViewForm_VendorReps.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewForm_VendorReps.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep))

            Try

                GridColumn = DataGridViewForm_VendorReps.Columns.ColumnByFieldName(AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep.Properties.DefaultCorrespondenceMethod.ToString)

                If GridColumn IsNot Nothing Then

                    SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                GridColumn.FieldName, Nothing, Nothing,
                                                                                                                                GetType(AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods), True)

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                        SubItemGridLookUpEditControl.ValueType = GetType(Short)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                            End Using

                        End Using

                        DataGridViewForm_VendorReps.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                        GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                    End If

                End If

            Catch ex As Exception

            End Try

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Subject.Text = AdvantageFramework.MediaManager.LoadDefaultEmailSubject(SecurityDbContext, Session.User.ID)
                TextBoxForm_Body.Text = AdvantageFramework.MediaManager.LoadDefaultEmailBody(SecurityDbContext, Session.User.ID)
                CheckBoxForm_CCToSender.Checked = AdvantageFramework.MediaManager.LoadDefaultCCSender(SecurityDbContext, Session.User.ID)
                ButtonItemOptions_SendToDocumentManager.Checked = AdvantageFramework.MediaManager.LoadDefaultUploadDocumentManager(SecurityDbContext, Session.User.ID)
                ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Checked = AdvantageFramework.MediaManager.LoadDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext, Session.User.ID)
                ButtonItemOptions_EmailExecutedCopyToVendor.Checked = AdvantageFramework.MediaManager.LoadDefaultEmailExecutedCopyToVendor(SecurityDbContext, Session.User.ID)

            End Using

            GenerateOrderVendorReps = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep)

            For Each GenerateOrder In _GenerateOrders

                For Each GenerateOrderVendorRep In GenerateOrder.GetGenerateOrderVendorReps.Where(Function(Entity) Entity.Process = True).ToList

                    If GenerateOrderVendorReps.Any(Function(Entity) Entity.VendorCode = GenerateOrderVendorRep.VendorCode AndAlso
                                                                    Entity.VendorRepCode = GenerateOrderVendorRep.VendorRepCode AndAlso
                                                                    Entity.OrderNumber = GenerateOrderVendorRep.OrderNumber) = False Then

                        GenerateOrderVendorReps.Add(GenerateOrderVendorRep)

                    End If

                Next

            Next

            DataGridViewForm_VendorReps.DataSource = GenerateOrderVendorReps

            DataGridViewForm_VendorReps.CurrentView.ClearSorting()
            DataGridViewForm_VendorReps.CurrentView.BeginSort()
            DataGridViewForm_VendorReps.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
            DataGridViewForm_VendorReps.CurrentView.EndSort()

            DataGridViewForm_VendorReps.CurrentView.BestFitColumns()

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaManagerProcessGenerateOrdersDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If DataGridViewForm_VendorReps.HasRows = False Then

                AdvantageFramework.WinForm.MessageBox.Show("No vendor reps available.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim Processed As Boolean = False
            Dim GenerateOrderVendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep) = Nothing
            Dim SendToOrderReps As Boolean = False
            Dim AtLeastOneEmailFailed As Boolean = False

            DataGridViewForm_VendorReps.CurrentView.CloseEditorForUpdating()

            If ButtonItemDefaultEmailSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your email settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    SaveEmailSettings()

                End If

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Printing
            Me.ShowWaitForm("Processing...")

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SendToOrderReps = (AdvantageFramework.MediaManager.LoadDefaultRepType(SecurityDbContext, Session.User.ID) = 0)

                End Using

            Catch ex As Exception
                SendToOrderReps = True
            End Try

            Try

                Try

                    GenerateOrderVendorReps = DataGridViewForm_VendorReps.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.GenerateOrderVendorRep).ToList

                Catch ex As Exception
                    GenerateOrderVendorReps = Nothing
                End Try

                If GenerateOrderVendorReps IsNot Nothing Then

                    For Each GenerateOrderVendorRep In GenerateOrderVendorReps

                        For Each GenerateOrder In _GenerateOrders.Where(Function(Entity) Entity.OrderNumber = GenerateOrderVendorRep.OrderNumber).ToList

                            GenerateOrder.AddOrUpdateGenerateOrderVendorReps(GenerateOrderVendorRep.GetVendorRepresentative, GenerateOrderVendorRep.Process, SendToOrderReps)

                        Next

                    Next

                End If

                Processed = AdvantageFramework.Reporting.Reports.ProcessGenerateOrders(Me.Session, _GenerateOrders, _DocumentTypes, Me.DefaultLookAndFeel.LookAndFeel, TextBoxForm_Subject.GetText,
                                                                                       TextBoxForm_Body.GetText, CheckBoxForm_CCToSender.Checked, ButtonItemOptions_SendToDocumentManager.Checked, AtLeastOneEmailFailed)

            Catch ex As Exception

            End Try

            If Processed Then

                If AtLeastOneEmailFailed Then

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Orders Successful - however one or more emails failed to send.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Generate Orders Successful.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Generate Orders Cancelled.")

            End If

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            For Each GenerateOrder In _GenerateOrders

                GenerateOrder.Status = Nothing
                GenerateOrder.OrderMessage = "User cancellation of order generation."

            Next

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemDefaultEmailSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemDefaultEmailSettings_Save.Click

            SaveEmailSettings()

            ButtonItemDefaultEmailSettings_Save.Enabled = False

        End Sub
        Private Sub TextBoxForm_Subject_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Subject.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub TextBoxForm_Body_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_Body.TextChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
		Private Sub CheckBoxForm_CCToSender_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxForm_CCToSender.CheckedChanged

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				ButtonItemDefaultEmailSettings_Save.Enabled = True

			End If

		End Sub
		Private Sub ButtonItemOptions_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_SendToDocumentManager.Click

			If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

				ButtonItemDefaultEmailSettings_Save.Enabled = True

			End If

		End Sub
        Private Sub ButtonItemOptions_UploadAndSignDocumentWhenSubmitted_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_UploadAndSignDocumentWhenSubmitted.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub ButtonItemOptions_EmailExecutedCopyToVendor_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_EmailExecutedCopyToVendor.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemDefaultEmailSettings_Save.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace