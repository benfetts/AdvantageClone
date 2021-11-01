Namespace Media.Presentation

    Public Class MediaTrafficGenerateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficGenerateViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Protected _Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor) = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor))

            ' This call is required by the designer.
            InitializeComponent()

            _Vendors = Vendors

        End Sub
        Private Sub SaveViewModel()

            Dim Generate As AdvantageFramework.DTO.Media.Traffic.Generate = Nothing

            For Each Row In DataGridViewDetails_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate)

                Generate = _ViewModel.GenerateList.Where(Function(Entity) Entity.MediaTrafficRevisionID = Row.MediaTrafficRevisionID AndAlso Entity.VendorCode = Row.VendorCode).SingleOrDefault

                If Generate IsNot Nothing Then

                    Generate.AlertRecipientEmployeeCodes = Row.AlertRecipientEmployeeCodes

                End If

            Next

        End Sub
        Private Sub RefreshViewModel(ReloadViewModel As Boolean)

            If ReloadViewModel Then

                _ViewModel = _Controller.Generate_Load(_Vendors)

            End If

            DataGridViewDetails_Details.DataSource = _ViewModel.GenerateList
            DataGridViewDetails_Details.CurrentView.BestFitColumns()

            If DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Generate.Properties.AlertRecipients.ToString) IsNot Nothing Then

                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.DTO.Media.Traffic.Generate.Properties.AlertRecipients.ToString).Width = 800

            End If

            For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)

                If _ViewModel.ContactTypeIDs.Contains(ButtonItem.Tag) Then

                    ButtonItem.Checked = True

                End If

            Next

        End Sub
        Private Sub ButtonItemContactTypes_CheckedChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemContactsDocumentSettings_Save.Enabled = True

            End If

        End Sub
        Private Sub AddSubItemCheckBox(ByVal DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            RepositoryItemCheckEdit.DisplayValueChecked = "Success"
            RepositoryItemCheckEdit.DisplayValueUnchecked = "Faliure"
            RepositoryItemCheckEdit.DisplayValueGrayed = "Pending"

            RepositoryItemCheckEdit.ValueChecked = True
            RepositoryItemCheckEdit.ValueUnchecked = False
            RepositoryItemCheckEdit.ValueGrayed = Nothing

            RepositoryItemCheckEdit.NullText = "Pending"
            RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive

            RepositoryItemCheckEdit.AllowGrayed = True
            RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatRedCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatYellowCircleImage)

            RepositoryItemCheckEdit.Images = ImagesCollection

            RepositoryItemCheckEdit.ImageIndexChecked = 0
            RepositoryItemCheckEdit.ImageIndexUnchecked = 1
            RepositoryItemCheckEdit.ImageIndexGrayed = 2

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            GridColumn.ColumnEdit = RepositoryItemCheckEdit

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Generate.Enabled = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate).Where(Function(G) G.RecipientCount > 0).Any
            ButtonItemView_Recipients.Enabled = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate).Where(Function(G) G.RecipientCount > 0).Any

            ButtonItemSendTo_AlertRecipients.Enabled = DataGridViewDetails_Details.HasASelectedRow

        End Sub
        Private Sub LoadRecipients()

            'objects
            Dim Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate) = Nothing

            If DataGridViewDetails_Details.HasASelectedRow Then

                Generates = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate)().ToList

                AdvantageFramework.Media.Presentation.MediaManagerGenerateOrdersSentInfoDialog.ShowFormDialog(Generates)

            End If

        End Sub
        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowValue As Object = Nothing
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewDetails_Details.GridControl Then

                Try

                    GridView = CType(DataGridViewDetails_Details.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.Generate.Properties.Status.ToString Then

                            If DataGridViewDetails_Details.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.DTO.Media.Traffic.Generate.Properties.Status.ToString) = False Then

                                RowValue = "No valid vendor rep associated with vendor."

                                ToolTipText = RowValue

                            End If

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.Media.Traffic.Generate)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                                      Where [Property].Name = GridHitInfo.Column.FieldName
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                RowValue = DataGridViewDetails_Details.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                            ToolTipText = RowValue

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficGenerateDialog As MediaTrafficGenerateDialog = Nothing

            MediaTrafficGenerateDialog = New MediaTrafficGenerateDialog(Vendors)

            ShowFormDialog = MediaTrafficGenerateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficGenerateDialog_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)

                RemoveHandler ButtonItem.CheckedChanged, AddressOf ButtonItemContactTypes_CheckedChanged

            Next

        End Sub
        Private Sub MediaTrafficGenerateDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            _ToolTipController = New DevExpress.Utils.ToolTipController()
            DataGridViewDetails_Details.GridControl.ToolTipController = _ToolTipController

            If _ObjectTypePropertyDescriptors Is Nothing Then

                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.DTO.Media.Traffic.Generate)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

            End If

            ButtonItemActions_Generate.Image = AdvantageFramework.My.Resources.MediaAddImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_Recipients.Image = AdvantageFramework.My.Resources.EmailSendImage

            ButtonItemContactsDocumentSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemContactsDocumentSettings_ContactTypes.Image = AdvantageFramework.My.Resources.ContactImage
            ButtonItemSendTo_AlertRecipients.Image = AdvantageFramework.My.Resources.EmailSendImage

            ButtonItemContactsDocumentSettings_Save.Enabled = False

            DataGridViewDetails_Details.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
            DataGridViewDetails_Details.OptionsBehavior.Editable = False

            DataGridViewDetails_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate))

            AddSubItemCheckBox(DataGridViewDetails_Details, DataGridViewDetails_Details.Columns(AdvantageFramework.DTO.Media.Traffic.Generate.Properties.Status.ToString))

            DataGridViewDetails_Details.CurrentView.GridControl.ShowOnlyPredefinedDetails = True

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

        End Sub
        Private Sub MediaTrafficGenerateDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            'objects
            Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            _ViewModel = _Controller.Generate_Load(_Vendors)

            For Each ContactType In _ViewModel.ContactTypeList

                ButtonItem = New DevComponents.DotNetBar.ButtonItem(ContactType.ID, ContactType.Description)

                ButtonItem.Name = "ButtonItemContactType" & ContactType.ID
                ButtonItem.AutoCheckOnClick = True
                ButtonItem.Tag = ContactType.ID

                AddHandler ButtonItem.CheckedChanged, AddressOf ButtonItemContactTypes_CheckedChanged

                ButtonItemContactsDocumentSettings_ContactTypes.SubItems.Add(ButtonItem)

            Next

            RefreshViewModel(False)

            DataGridViewDetails_Details.SelectAll()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Generate_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Generate.Click

            Dim GenerateList As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate) = Nothing

            If ButtonItemContactsDocumentSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to save your sent to and document settings?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    ButtonItemContactsDocumentSettings_Save.RaiseClick()

                End If

            End If

            SaveViewModel()

            GenerateList = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate).ToList

            AdvantageFramework.Media.Presentation.MediaTrafficProcessGenerateDialog.ShowFormDialog(GenerateList, _ViewModel.ContactTypeIDs)

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemView_Recipients_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Recipients.Click

            LoadRecipients()

        End Sub
        Private Sub ButtonItemContactsDocumentSettings_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemContactsDocumentSettings_Save.Click

            'objects
            Dim ContactTypes As String = Nothing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving
            Me.ShowWaitForm("Saving...")

            For Each ButtonItem In ButtonItemContactsDocumentSettings_ContactTypes.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                If ButtonItem.Checked Then

                    ContactTypes = If(String.IsNullOrWhiteSpace(ContactTypes), ButtonItem.Tag, ContactTypes & "," & ButtonItem.Tag)

                End If

            Next

            ButtonItemContactsDocumentSettings_Save.Enabled = Not _Controller.Generate_SaveContactTypes(ContactTypes)

            RefreshViewModel(True)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewDetails_Details_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewDetails_Details.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Media.Traffic.Generate.Properties.DefaultCorrespondenceMethod.ToString Then

                If e.CellValue = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email.ToString

                ElseIf e.CellValue = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print Then

                    e.DisplayText = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Print.ToString

                End If

            End If

        End Sub
        Private Sub ButtonItemSendTo_AlertRecipients_Click(sender As Object, e As EventArgs) Handles ButtonItemSendTo_AlertRecipients.Click

            Dim MediaTrafficRevisionIDs As IEnumerable(Of Integer) = Nothing
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee) = Nothing

            MediaTrafficRevisionIDs = DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate).Select(Function(Entity) Entity.MediaTrafficRevisionID).ToArray

            EmployeeCodes = New Generic.List(Of String)

            For Each Generate In DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate).ToList

                If Generate.AlertRecipientEmployeeCodes IsNot Nothing AndAlso Generate.AlertRecipientEmployeeCodes.Count > 0 Then

                    EmployeeCodes.AddRange(Generate.AlertRecipientEmployeeCodes)

                End If

            Next

            If AdvantageFramework.WinForm.MVC.Presentation.AlertRecipientDialog.ShowFormDialog(MediaTrafficRevisionIDs, EmployeeCodes, Employees) = Windows.Forms.DialogResult.OK Then

                For Each Generate In DataGridViewDetails_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Generate)

                    Generate.AlertRecipients = String.Join(", ", Employees.Select(Function(Emp) Emp.ToString).ToArray)
                    Generate.AlertRecipientEmployeeCodes = Employees.Select(Function(Emp) Emp.Code).ToList

                Next

                DataGridViewDetails_Details.CurrentView.RefreshData()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace