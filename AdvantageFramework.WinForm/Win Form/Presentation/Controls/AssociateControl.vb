Namespace WinForm.Presentation.Controls

    Public Class AssociateControl
        Public Event SelectedAssociateChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasOnlyOneSelectedAssociate As Boolean
            Get
                HasOnlyOneSelectedAssociate = If(DataGridViewForm_VendorEmployeeAssociate.Visible, DataGridViewForm_VendorEmployeeAssociate.HasOnlyOneSelectedRow, DataGridViewForm_AllAssociates.HasOnlyOneSelectedRow)
            End Get
        End Property
        Public ReadOnly Property IsNewItemRow As Boolean
            Get
                IsNewItemRow = If(DataGridViewForm_VendorEmployeeAssociate.Visible, DataGridViewForm_VendorEmployeeAssociate.CurrentView.IsNewItemRow(DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedRowHandle), False)
            End Get
        End Property
        Public ReadOnly Property AllAssociates As Generic.List(Of AdvantageFramework.Database.Entities.Associate)
            Get
                AllAssociates = _Associates
            End Get
        End Property
        Public ReadOnly Property ViewingAll As Boolean
            Get
                ViewingAll = CheckBoxForm_ViewAll.Checked
            End Get
        End Property
        Public ReadOnly Property AssociatesInCurrentView As Generic.List(Of AdvantageFramework.Database.Entities.Associate)
            Get
                AssociatesInCurrentView = If(DataGridViewForm_VendorEmployeeAssociate.Visible, DataGridViewForm_VendorEmployeeAssociate.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Associate).ToList, Nothing)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Associate)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            SearchableComboBoxForm_Client.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Associate.Properties.ClientCode)
                            SearchableComboBoxForm_Division.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Associate.Properties.DivisionCode)
                            SearchableComboBoxForm_Product.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Associate.Properties.ProductCode)

                            DbContext.Database.Connection.Open()

                            SearchableComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(DbContext)
                            SearchableComboBoxForm_Division.DataSource = AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                            SearchableComboBoxForm_Product.DataSource = AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                            ComboBoxForm_MediaType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AssociateMediaType))

                            DbContext.Database.Connection.Close()

                            ComboBoxForm_MediaType.ByPassUserEntryChanged = True
                            CheckBoxForm_ViewAll.ByPassUserEntryChanged = True

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewForm_AllAssociates.Visible = CheckBoxForm_ViewAll.Checked
            DataGridViewForm_VendorEmployeeAssociate.Visible = Not CheckBoxForm_ViewAll.Checked
            ComboBoxForm_MediaType.Enabled = Not CheckBoxForm_ViewAll.Checked
            DataGridViewForm_VendorEmployeeAssociate.HideOrShowColumn("MediaType", False)

        End Sub
        Private Sub LoadAssociatesByMediaType(ByVal Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate))

            'objects
            Dim SelectedAssociates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

            If Associates IsNot Nothing Then

                Try

                    If ComboBoxForm_MediaType.HasASelectedValue Then

                        SelectedAssociates = Associates.Where(Function(Associate) Associate.MediaType IsNot Nothing AndAlso Associate.MediaType.ToUpper = ComboBoxForm_MediaType.GetSelectedValue).ToList

                    Else

                        SelectedAssociates = Associates.Where(Function(Associate) Associate.MediaType Is Nothing OrElse Associate.MediaType = "").ToList

                    End If

                Catch ex As Exception
                    SelectedAssociates = New Generic.List(Of AdvantageFramework.Database.Entities.Associate)
                End Try

                DataGridViewForm_VendorEmployeeAssociate.DataSource = SelectedAssociates
                DataGridViewForm_VendorEmployeeAssociate.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadAssociates()

            'objects
            Dim Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    _Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                    SearchableComboBoxForm_Client.SelectedValue = _ClientCode
                    SearchableComboBoxForm_Division.SelectedValue = _DivisionCode
                    SearchableComboBoxForm_Product.SelectedValue = _ProductCode

                    If _Associates IsNot Nothing Then

                        LoadAssociatesByMediaType(_Associates)

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    _Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList

                    SearchableComboBoxForm_Client.SelectedValue = _ClientCode
                    SearchableComboBoxForm_Division.SelectedValue = _DivisionCode

                    If _Associates IsNot Nothing Then

                        LoadAssociatesByMediaType(_Associates)

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    _Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientCode(DbContext, _ClientCode).ToList

                    SearchableComboBoxForm_Client.SelectedValue = _ClientCode

                    If _Associates IsNot Nothing Then

                        LoadAssociatesByMediaType(_Associates)

                    End If

                Else

                    _Associates = New Generic.List(Of AdvantageFramework.Database.Entities.Associate)

                End If

                DataGridViewForm_AllAssociates.DataSource = _Associates
                DataGridViewForm_AllAssociates.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub SpinEditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim Cancel As Boolean = False
            Dim SpinEdit As DevExpress.XtraEditors.SpinEdit = Nothing

            Try

                SpinEdit = DirectCast(sender, DevExpress.XtraEditors.SpinEdit)

            Catch ex As Exception
                SpinEdit = Nothing
            End Try

            If SpinEdit IsNot Nothing Then

                If e.NewValue > SpinEdit.Properties.MaxValue Then

                    Cancel = True

                End If

            End If

            If Cancel Then

                e.Cancel = True

                AdvantageFramework.Navigation.ShowMessageBox("Total percent cannot exceed 100.")

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Associate As AdvantageFramework.Database.Entities.Associate = Nothing
            Dim Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                SearchableComboBoxForm_Client.Enabled = False
                SearchableComboBoxForm_Division.Enabled = False
                SearchableComboBoxForm_Product.Enabled = False

                LoadAssociates()

            ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                SearchableComboBoxForm_Client.Enabled = False
                SearchableComboBoxForm_Division.Enabled = False
                SearchableComboBoxForm_Product.Enabled = False

                LoadAssociates()

            ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                SearchableComboBoxForm_Client.Enabled = False
                SearchableComboBoxForm_Division.Enabled = False
                SearchableComboBoxForm_Product.Enabled = False

                LoadAssociates()

            Else

                SearchableComboBoxForm_Client.Enabled = True
                SearchableComboBoxForm_Division.Enabled = True
                SearchableComboBoxForm_Product.Enabled = True

                DataGridViewForm_VendorEmployeeAssociate.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Associate)

            End If

            If DataGridViewForm_VendorEmployeeAssociate.Columns("Percent") IsNot Nothing Then

                DataGridViewForm_VendorEmployeeAssociate.Columns("Percent").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                DataGridViewForm_VendorEmployeeAssociate.Columns("Percent").SummaryItem.DisplayFormat = "Total: {0}"
                DataGridViewForm_VendorEmployeeAssociate.Columns("Percent").AllowSummaryMenu = False

            End If

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            SearchableComboBoxForm_Client.SelectedValue = Nothing
            SearchableComboBoxForm_Division.SelectedValue = Nothing
            SearchableComboBoxForm_Product.SelectedValue = Nothing
            ComboBoxForm_MediaType.SelectedIndex = 0

            DataGridViewForm_VendorEmployeeAssociate.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.Associate))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Associate As AdvantageFramework.Database.Entities.Associate = Nothing
            Dim MediaType As String = Nothing
            Dim MediaTypeDescription As String = Nothing
            Dim DoSave As Boolean = True
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each MediaType In Me.AllAssociates.Select(Function(Assoc) Assoc.MediaType).Distinct

                        If MediaType Is Nothing Then

                            If (From Entity In Me.AllAssociates
                                Where Entity.MediaType Is Nothing OrElse
                                      Entity.MediaType = ""
                                Select Entity.Percent).Sum > 100 Then

                                DoSave = False

                            End If

                        Else

                            If (From Entity In Me.AllAssociates
                                Where Entity.MediaType = MediaType
                                Select Entity.Percent).Sum > 100 Then

                                DoSave = False

                            End If

                        End If

                        If DoSave = False Then

                            Try

                                MediaTypeDescription = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AssociateMediaType)).ToList
                                                        Where Entity.Code = MediaType
                                                        Select Entity.Description).FirstOrDefault

                            Catch ex As Exception
                                MediaTypeDescription = "[none]"
                            End Try

                            ErrorMessage = String.Format("Total percent for media type '{0}' cannot exceed 100.", MediaTypeDescription)

                            Exit For

                        End If

                    Next

                    If ErrorMessage = "" Then

                        For Each Associate In Me.AllAssociates

                            If AdvantageFramework.Database.Procedures.Associate.Update(DbContext, Associate) Then

                                Saved = True

                            End If

                        Next

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Associate As AdvantageFramework.Database.Entities.Associate = Nothing
            Dim AssociateID As String = Nothing
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If CheckBoxForm_ViewAll.Checked AndAlso DataGridViewForm_AllAssociates.HasOnlyOneSelectedRow Then

                        AssociateID = DataGridViewForm_AllAssociates.CurrentView.GetRowCellValue(DataGridViewForm_AllAssociates.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ID.ToString)

                        Associate = AdvantageFramework.Database.Procedures.Associate.LoadByID(DbContext, AssociateID)

                    ElseIf DataGridViewForm_VendorEmployeeAssociate.Visible AndAlso DataGridViewForm_VendorEmployeeAssociate.HasOnlyOneSelectedRow Then

                        Try

                            Associate = DataGridViewForm_VendorEmployeeAssociate.GetFirstSelectedRowDataBoundItem

                        Catch ex As Exception
                            Associate = Nothing
                        End Try

                    End If

                    If Associate IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Associate.Delete(DbContext, Associate) Then

                            Deleted = True

                            LoadAssociates()

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Sub CancelNewItemRow()

            DataGridViewForm_VendorEmployeeAssociate.CancelNewItemRow()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub AssociateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_VendorEmployeeAssociate_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_VendorEmployeeAssociate.AddNewRowEvent

            'objects
            Dim Associate As AdvantageFramework.Database.Entities.Associate = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.Associate Then

                Me.ShowWaitForm("Processing...")

                Associate = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Associate.IsEntityBeingAdded() Then

                        Associate.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Associate.Insert(DbContext, Associate) Then

                            LoadAssociates()

                            DataGridViewForm_VendorEmployeeAssociate.SelectRow(Associate.ID)

                        Else

                            LoadAssociates()

                        End If

                        EnableOrDisableActions()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.CellValueChangedEvent

            'objects
            Dim Associates As Generic.List(Of AdvantageFramework.Database.Entities.Associate) = Nothing
            Dim PercentSum As Decimal = Nothing
            Dim NewValue As Decimal = Nothing

            If DataGridViewForm_VendorEmployeeAssociate.CurrentView.IsNewItemRow(e.RowHandle) = False AndAlso e.Value IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                        Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                    ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                        Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList

                    ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                        Associates = AdvantageFramework.Database.Procedures.Associate.LoadByClientCode(DbContext, _ClientCode).ToList

                    Else

                        Associates = New Generic.List(Of AdvantageFramework.Database.Entities.Associate)

                    End If

                    If e.Column.FieldName = AdvantageFramework.Database.Entities.Associate.Properties.EmployeeCode.ToString Then

                        If Associates.Where(Function(Associate) Associate.EmployeeCode = e.Value).Any Then

                            AdvantageFramework.WinForm.MessageBox.Show("Duplicate associates are not allowed.")

                            LoadAssociates()

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.Associate.Properties.VendorCode.ToString Then

                        If Associates.Where(Function(Associate) Associate.VendorCode = e.Value).Any Then

                            AdvantageFramework.WinForm.MessageBox.Show("Duplicate associates are not allowed.")

                            LoadAssociates()

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.Associate.Properties.Percent.ToString Then

                        Try

                            PercentSum = (From Entity In DataGridViewForm_VendorEmployeeAssociate.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Associate).ToList
                                          Select Entity.Percent).Sum

                        Catch ex As Exception
                            PercentSum = 0
                        End Try

                        If PercentSum <> Nothing AndAlso PercentSum > 100 Then

                            NewValue = 100 - (PercentSum - e.Value)

                            DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.Percent, NewValue)

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_CustomSummaryCalculateEvent(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.CustomSummaryCalculateEvent

            Dim TotalPercent As Decimal = Nothing

            Try

                TotalPercent = DataGridViewForm_VendorEmployeeAssociate.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Associate)().Select(Function(Associate) Associate.Percent).Sum

            Catch ex As Exception
                TotalPercent = Nothing
            End Try

            e.TotalValue = TotalPercent

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.InitNewRowEvent

            'objects
            Dim MediaType As String = Nothing

            MediaType = ComboBoxForm_MediaType.GetSelectedValue

            DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ClientCode.ToString, _ClientCode)
            DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.DivisionCode.ToString, _DivisionCode)
            DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ProductCode.ToString, _ProductCode)
            DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.MediaType.ToString, MediaType)

            If String.IsNullOrWhiteSpace(_ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_DivisionCode) AndAlso String.IsNullOrWhiteSpace(_ProductCode) Then

                If String.IsNullOrWhiteSpace(MediaType) Then

                    DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ReportLevel.ToString, 1)

                Else

                    DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ReportLevel.ToString, 3)

                End If

            ElseIf String.IsNullOrWhiteSpace(_ClientCode) = False AndAlso String.IsNullOrWhiteSpace(_DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(_ProductCode) = False Then

                If String.IsNullOrWhiteSpace(MediaType) Then

                    DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ReportLevel.ToString, 2)

                Else

                    DataGridViewForm_VendorEmployeeAssociate.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.Associate.Properties.ReportLevel.ToString, 4)

                End If

            End If

            RaiseEvent SelectedAssociateChangedEvent()

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_NewItemRowCanceledEvent() Handles DataGridViewForm_VendorEmployeeAssociate.NewItemRowCanceledEvent

            RaiseEvent SelectedAssociateChangedEvent()

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.SelectionChangedEvent

            RaiseEvent SelectedAssociateChangedEvent()

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.ShowingEditorEvent

            'objects
            Dim FieldName As String = Nothing
            Dim VendorCode As String = Nothing
            Dim EmployeeCode As String = Nothing

            FieldName = DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedColumn.FieldName
            EmployeeCode = DataGridViewForm_VendorEmployeeAssociate.CurrentView.GetRowCellValue(DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Associate.Properties.EmployeeCode.ToString)
            VendorCode = DataGridViewForm_VendorEmployeeAssociate.CurrentView.GetRowCellValue(DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Associate.Properties.VendorCode.ToString)

            If (FieldName = AdvantageFramework.Database.Entities.Associate.Properties.EmployeeCode.ToString AndAlso VendorCode IsNot Nothing) OrElse
                    (FieldName = AdvantageFramework.Database.Entities.Associate.Properties.VendorCode.ToString AndAlso EmployeeCode IsNot Nothing) Then

                e.Cancel = True

                Try

                    DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedColumn = DataGridViewForm_VendorEmployeeAssociate.CurrentView.Columns(AdvantageFramework.Database.Entities.Associate.Properties.Percent.ToString)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewForm_VendorEmployeeAssociate_ShownEditorEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_VendorEmployeeAssociate.ShownEditorEvent

            Dim SpinEdit As DevExpress.XtraEditors.SpinEdit = Nothing
            Dim PercentSum As Decimal = Nothing
            Dim CurrentRowPercent As Decimal = Nothing
            Dim MaxValue As Decimal = Nothing

            If DataGridViewForm_VendorEmployeeAssociate.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.Associate.Properties.Percent.ToString Then

                SpinEdit = DataGridViewForm_VendorEmployeeAssociate.CurrentView.ActiveEditor

                Try

                    CurrentRowPercent = DataGridViewForm_VendorEmployeeAssociate.CurrentView.ActiveEditor.EditValue

                Catch ex As Exception
                    CurrentRowPercent = 0
                End Try

                Try

                    PercentSum = (From Associate In DataGridViewForm_VendorEmployeeAssociate.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.Associate).ToList _
                                  Select Associate.Percent).Sum

                Catch ex As Exception
                    PercentSum = 0
                End Try

                MaxValue = (100 - PercentSum) + CurrentRowPercent

                If MaxValue >= 0 Then

                    SpinEdit.Properties.MaxValue = MaxValue

                Else

                    SpinEdit.Properties.MaxValue = 0

                End If

                SpinEdit.Properties.Mask.UseMaskAsDisplayFormat = True
                SpinEdit.Properties.MinValue = 0.0

                AddHandler SpinEdit.EditValueChanging, AddressOf SpinEditValueChanging

            End If

        End Sub
        Private Sub ComboBoxForm_MediaType_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_MediaType.SelectedValueChanged

            LoadAssociatesByMediaType(_Associates)

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxForm_ViewAll_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxForm_ViewAll.CheckedChanged

            EnableOrDisableActions()

            RaiseEvent SelectedAssociateChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
