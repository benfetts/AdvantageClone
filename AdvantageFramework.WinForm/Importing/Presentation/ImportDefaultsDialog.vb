Imports DevExpress.XtraVerticalGrid.Events

Namespace Importing.Presentation

    Public Class ImportDefaultsDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _SelectedItemIndex As Integer = Nothing
        Private _NumberOfItems As Integer = Nothing
        Private _ImportedItems As IEnumerable = Nothing
        Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes
            Get
                ImportTemplateType = _ImportTemplateType
            End Get
        End Property
        Public ReadOnly Property ImportedItems As IEnumerable
            Get
                ImportedItems = _ImportedItems
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef ImportedItems As IEnumerable)

            ' This call is required by the designer.
            InitializeComponent()

            _ImportTemplateType = ImportTemplateType
            _ImportedItems = ImportedItems

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonControlForm_FromBlank.Checked Then

                ButtonForm_SelectFirst.Visible = False
                ButtonForm_SelectLast.Visible = False
                ButtonForm_SelectNext.Visible = False
                ButtonForm_SelectPrevious.Visible = False

            Else

                ButtonForm_SelectFirst.Visible = True
                ButtonForm_SelectLast.Visible = True
                ButtonForm_SelectNext.Visible = True
                ButtonForm_SelectPrevious.Visible = True

                ButtonForm_SelectFirst.Enabled = Convert.ToBoolean(_SelectedItemIndex)
                ButtonForm_SelectLast.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectNext.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectPrevious.Enabled = Convert.ToBoolean(_SelectedItemIndex)

            End If

        End Sub
        Private Sub LoadObject()

            'objects
            Dim SelectedObject = Nothing
            Dim ImportedItem As Object = Nothing

            If RadioButtonControlForm_FromBlank.Checked Then

                Try

                    ImportedItem = (From Item In _ImportedItems
                                    Select Item).FirstOrDefault

                Catch ex As Exception
                    ImportedItem = Nothing
                End Try

                If ImportedItem IsNot Nothing Then

                    Try

                        If ImportedItem.GetType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                            SelectedObject = System.Activator.CreateInstance(ImportedItem.GetType)

                        End If

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

            Else

                Try

                    ImportedItem = _ImportedItems(_SelectedItemIndex)

                Catch ex As Exception
                    ImportedItem = Nothing
                End Try

                If ImportedItem IsNot Nothing Then

                    Try

                        SelectedObject = ImportedItem

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

                If TypeOf SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                    If DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).IsNonBillable.GetValueOrDefault(0) = 0 Then

                        DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).JobGLACode = Nothing

                    End If

                End If

            End If

            PropertyGridControlForm_Properties.SelectedObject = SelectedObject

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef ImportedItems As IEnumerable) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportDefaultsDialog As AdvantageFramework.Importing.Presentation.ImportDefaultsDialog = Nothing

            ImportDefaultsDialog = New AdvantageFramework.Importing.Presentation.ImportDefaultsDialog(ImportTemplateType, ImportedItems)

            ShowFormDialog = ImportDefaultsDialog.ShowDialog()

            ImportedItems = ImportDefaultsDialog.ImportedItems
            ImportTemplateType = ImportDefaultsDialog.ImportTemplateType

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportDefaultsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _NumberOfItems = (From Item In ImportedItems
                              Select Item).Count

            RadioButtonControlForm_FromBlank.Checked = True

            PropertyGridControlForm_Properties.ControlType = WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.ImportTemplate

            PropertyGridControlForm_Properties.AutoFilterLookupColumns = True
            PropertyGridControlForm_Properties.AutoloadRepositoryDatasource = True

            LoadObject()
            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedObject As Object = Nothing
            Dim Value As Object = Nothing
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Core.JobComponent) = Nothing
            Dim JobComponentID As Integer = Nothing
            Dim ReplaceJobComponentNumberWithID As Boolean = False
            Dim NonBillableJobGLACode As String = Nothing
            Dim Jobs As Generic.List(Of AdvantageFramework.Database.Entities.Job) = Nothing
            Dim ImportAccountPayables As IEnumerable(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable) = Nothing
            Dim ImportAccountPayableJobBillingRates As Generic.List(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJobBillingRate) = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim UseAPAccountOnImport As Boolean = False
            Dim OfficeList As Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing
            Dim GeneralLedgerOfficeCrossReferenceList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Auto Filling ...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SelectedObject = PropertyGridControlForm_Properties.SelectedObject

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                    If _ImportTemplateType = ImportTemplateTypes.ExpenseReport_CreditCard OrElse
                        _ImportTemplateType = ImportTemplateTypes.ExpenseReport_NonCreditCard Then

                        JobComponents = AdvantageFramework.Database.Procedures.JobComponent.LoadCore(DbContext).ToList

                        ReplaceJobComponentNumberWithID = True

                    ElseIf _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                        UseAPAccountOnImport = AdvantageFramework.Database.Procedures.Agency.UseAPAccountOnImport(DbContext)

                        OfficeList = AdvantageFramework.Database.Procedures.Office.Load(DbContext).ToList
                        GeneralLedgerAccountList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).ToList
                        GeneralLedgerOfficeCrossReferenceList = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Load(DbContext).ToList

                    End If

                    For Each ImportItem In (From Entity In _ImportedItems
                                            Select Entity).ToList

                        For Each PropertyDescriptor In PropertyDescriptors

                            Try

                                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                            Catch ex As Exception
                                EntityAttribute = Nothing
                            End Try

                            If PropertyGridControlForm_Properties.VisibleRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.EditorRow).Any(Function(EditorRow) EditorRow.Properties.FieldName = PropertyDescriptor.Name) Then

                                Value = PropertyDescriptor.GetValue(SelectedObject)

                                If Value IsNot Nothing Then

                                    Try

                                        If Value.GetType Is GetType(String) Then

                                            If String.IsNullOrEmpty(Value) = False Then

                                                PropertyDescriptor.SetValue(ImportItem, PropertyDescriptor.GetValue(SelectedObject))

                                            End If

                                        Else

                                            PropertyDescriptor.SetValue(ImportItem, PropertyDescriptor.GetValue(SelectedObject))

                                        End If

                                    Catch ex As Exception

                                    End Try

                                    If TypeOf ImportItem Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                                        If (PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaType.ToString OrElse
                                                PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.SalesClassCode.ToString) AndAlso
                                                DirectCast(ImportItem, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableMediaID = 0 Then

                                            PropertyDescriptor.SetValue(ImportItem, Nothing)

                                        End If

                                        If (PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString OrElse
                                                PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString OrElse
                                                PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString OrElse
                                                PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString) AndAlso
                                                DirectCast(ImportItem, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableJobID = 0 Then

                                            PropertyDescriptor.SetValue(ImportItem, Nothing)

                                        End If

                                        If PropertyDescriptor.Name = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString AndAlso
                                                DirectCast(ImportItem, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ImportAccountPayableGLID = 0 Then

                                            PropertyDescriptor.SetValue(ImportItem, Nothing)

                                        End If

                                    End If

                                End If

                            End If

                        Next

                        If TypeOf ImportItem Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                            ImportAccountPayable = DirectCast(ImportItem, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                            ImportAccountPayable.Modified = True

                            If ImportAccountPayable IsNot Nothing Then

                                If DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).OfficeCode IsNot Nothing AndAlso
                                        DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).GLAccount Is Nothing Then

                                    If UseAPAccountOnImport = False Then

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, ImportAccountPayable.VendorCode)

                                        GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, ImportAccountPayable.OfficeCode)

                                        If Vendor IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                            GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeSegment(DbContext, Vendor.DefaultAPAccount, GeneralLedgerOfficeCrossReference.Code)

                                            If GeneralLedgerAccount IsNot Nothing Then

                                                ImportAccountPayable.GLAccount = GeneralLedgerAccount.Code

                                            End If

                                        End If

                                    Else

                                        ImportAccountPayable.GLAccount = OfficeList.Where(Function(Entity) Entity.Code = ImportAccountPayable.OfficeCode).Select(Function(Entity) Entity.AccountsPayableGLACode).FirstOrDefault

                                    End If

                                ElseIf DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).GLAccount IsNot Nothing Then

                                    GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerAccountList.Where(Function(Entity) Entity.Code = ImportAccountPayable.GLAccount).Select(Function(Entity) Entity.GeneralLedgerOfficeCrossReferenceCode).FirstOrDefault

                                    If GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                                        ImportAccountPayable.OfficeCode = GeneralLedgerOfficeCrossReferenceList.Where(Function(Entity) Entity.Code = GeneralLedgerOfficeCrossReferenceCode).Select(Function(Entity) Entity.OfficeCode).FirstOrDefault

                                    End If

                                End If

                            End If

                        End If

                    Next

                    If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_Generic OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedInternet OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_StrataFixedPrint OrElse
                            _ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                        NonBillableJobGLACode = DirectCast(SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).JobGLACode

                        Jobs = AdvantageFramework.Database.Procedures.Job.Load(DbContext).ToList

                        ImportAccountPayables = _ImportedItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).ToList

                        ImportAccountPayableJobBillingRates = (From IAP In ImportAccountPayables
                                                               Join J In Jobs On IAP.JobNumber Equals J.Number
                                                               Select New AdvantageFramework.AccountPayable.Classes.ImportAccountPayableJobBillingRate(DbContext, IAP, J)).ToList

                        For Each ImportAccountPayableJobBillingRate In ImportAccountPayableJobBillingRates

                            _ImportedItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Where(Function(Entity) Entity.ImportAccountPayableJobID = ImportAccountPayableJobBillingRate.ImportAccountPayableJobID).First.IsNonBillable = ImportAccountPayableJobBillingRate.NonBillFlag.GetValueOrDefault(0)

                            If ImportAccountPayableJobBillingRate.NonBillFlag = 1 Then

                                If NonBillableJobGLACode IsNot Nothing Then

                                    _ImportedItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Where(Function(Entity) Entity.ImportAccountPayableJobID = ImportAccountPayableJobBillingRate.ImportAccountPayableJobID).First.JobGLACode = NonBillableJobGLACode

                                End If

                            Else

                                _ImportedItems.OfType(Of AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).Where(Function(Entity) Entity.ImportAccountPayableJobID = ImportAccountPayableJobBillingRate.ImportAccountPayableJobID).First.JobGLACode = ImportAccountPayableJobBillingRate.GLACodeWIP

                            End If

                        Next

                    End If

                End Using

                Me.CloseWaitForm()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonControlForm_UpdateFromSelected_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonControlForm_UpdateFromSelected.CheckedChanged

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectFirst_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectFirst.Click

            _SelectedItemIndex = 0

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectLast_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectLast.Click

            If _NumberOfItems > 0 Then

                _SelectedItemIndex = _NumberOfItems - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectNext_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectNext.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex + 1 < _NumberOfItems Then

                _SelectedItemIndex = _SelectedItemIndex + 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectPrevious_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectPrevious.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex - 1 >= 0 Then

                _SelectedItemIndex = _SelectedItemIndex - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub PropertyGridControlForm_Properties_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridControlForm_Properties.CellValueChanged

            Select Case _ImportTemplateType

                Case ImportTemplateTypes.DigitalResults_Default

                    DigitalResults_CellValueChanged(e)

                Case ImportTemplateTypes.AccountsPayable_Generic, ImportTemplateTypes.AccountsPayable_Custom, ImportTemplateTypes.AccountsPayable_4AsBroadcast,
                        ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast, ImportTemplateTypes.AccountsPayable_StrataFixedInternet, ImportTemplateTypes.AccountsPayable_StrataFixedPrint

                    AccountPayable_CellValueChanged(e)

            End Select

        End Sub
        Private Sub PropertyGridControlForm_Properties_CustomDrawRowHeaderCell(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CustomDrawRowHeaderCellEventArgs) Handles PropertyGridControlForm_Properties.CustomDrawRowHeaderCell

            If TypeOf _ImportedItems(_SelectedItemIndex) Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                If e.Row.RowPropertiesCount > 0 AndAlso e.Row.GetRowProperties(0).FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                    e.Caption = "Non Billable Account"

                End If

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_DataSourceChanged(sender As Object, e As EventArgs) Handles PropertyGridControlForm_Properties.DataSourceChanged

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                If _ImportTemplateType = ImportTemplateTypes.AccountsPayable_4AsBroadcast Then

                    PropertyGridControlForm_Properties.GetRowByFieldName(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString).Visible = True

                Else

                    PropertyGridControlForm_Properties.GetRowByFieldName(AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString).Visible = False

                End If

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridControlForm_Properties.QueryPopupNeedDatasource

            Select Case _ImportTemplateType

                Case ImportTemplateTypes.AccountsPayable_Generic, ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast,
                     ImportTemplateTypes.AccountsPayable_StrataFixedInternet, ImportTemplateTypes.AccountsPayable_StrataFixedPrint,
                     ImportTemplateTypes.AccountsPayable_4AsBroadcast

                    AccountPayable_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

                Case ImportTemplateTypes.DigitalResults_Default

                    DigitalResults_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

                Case ImportTemplateTypes.JournalEntry_Default,
                        ImportTemplateTypes.JournalEntry_MOGLIFACE

                    JournalEntry_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

                Case ImportTemplateTypes.ExpenseReport_CreditCard,
                     ImportTemplateTypes.ExpenseReport_NonCreditCard

                    ExpenseReport_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

            End Select

        End Sub
        Private Sub PropertyGridControlForm_Properties_RowChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.RowChangedEventArgs) Handles PropertyGridControlForm_Properties.RowChanged

            Select Case _ImportTemplateType

                Case ImportTemplateTypes.AccountsPayable_Generic, ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast,
                     ImportTemplateTypes.AccountsPayable_StrataFixedInternet, ImportTemplateTypes.AccountsPayable_StrataFixedPrint

                    AccountPayable_RowChanged(e)

            End Select

        End Sub
        Private Sub PropertyGridControlForm_Properties_ShowingEditor(sender As Object, e As ComponentModel.CancelEventArgs) Handles PropertyGridControlForm_Properties.ShowingEditor

            Select Case _ImportTemplateType

                Case ImportTemplateTypes.DigitalResults_Default

                    DigitalResults_ShowingEditor(e)

                Case ImportTemplateTypes.AccountsPayable_Generic, ImportTemplateTypes.AccountsPayable_Custom, ImportTemplateTypes.AccountsPayable_4AsBroadcast,
                        ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast, ImportTemplateTypes.AccountsPayable_StrataFixedInternet, ImportTemplateTypes.AccountsPayable_StrataFixedPrint

                    AccountPayable_ShowingEditor(e)

            End Select

        End Sub
        Private Sub PropertyGridControlForm_Properties_ShownEditor(sender As Object, e As EventArgs) Handles PropertyGridControlForm_Properties.ShownEditor

            Select Case _ImportTemplateType

                Case ImportTemplateTypes.DigitalResults_Default

                    DigitalResults_ShownEditor()

            End Select

        End Sub

#End Region

#Region " Import Template Types "

#Region " Account Payable "

        Private Sub AccountPayable_QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim OfficeCode As String = Nothing
            Dim AllowCostOfSaleEntry As Boolean = False
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing
            Dim ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable = Nothing
            Dim AllowVendorNotOnOrder As Boolean = False

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                If FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobComponentNumber.ToString Then

                    If PropertyGridControlForm_Properties.VisibleRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.EditorRow).Any(Function(EditorRow) EditorRow.Properties.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString) Then

                        JobNumber = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).JobNumber

                        If JobNumber IsNot Nothing Then

                            OverrideDefaultDatasource = True

                            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Datasource = AdvantageFramework.AccountPayable.GetJobComponentsByJob(DbContext, JobNumber)

                            End Using

                        End If

                    End If

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobNumber.ToString Then

                    OverrideDefaultDatasource = True

                    If PropertyGridControlForm_Properties.VisibleRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.EditorRow).Any(Function(EditorRow) EditorRow.Properties.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString) Then

                        OfficeCode = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).OfficeCode

                        If String.IsNullOrEmpty(OfficeCode) Then

                            OfficeCode = Nothing

                        End If

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, OfficeCode, Nothing, Nothing, Nothing)

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.FunctionCode.ToString Then

                    OverrideDefaultDatasource = True

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "V")

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.JobGLACode.ToString Then

                    OverrideDefaultDatasource = True

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, Nothing, Session)

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLACode.ToString Then

                    OverrideDefaultDatasource = True

                    OfficeCode = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).OfficeCode

                    If String.IsNullOrEmpty(OfficeCode) Then

                        OfficeCode = Nothing

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Session, OfficeCode, Nothing)

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString Then

                    OverrideDefaultDatasource = True

                    OfficeCode = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).OfficeCode

                    If String.IsNullOrEmpty(OfficeCode) Then

                        OfficeCode = Nothing

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, OfficeCode)

                        If Office IsNot Nothing Then

                            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Office.Code)

                            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code

                            End If

                        End If

                        Datasource = AdvantageFramework.AccountPayable.GetAccountPayableGeneralLedgerDatasource(DbContext, GeneralLedgerOfficeCrossReferenceCode, Session)

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString Then

                    OverrideDefaultDatasource = True

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Session).ToList

                    End Using

                ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString Then

                    OverrideDefaultDatasource = True

                    ImportAccountPayable = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

                    If String.IsNullOrWhiteSpace(ImportAccountPayable.VendorCode) Then

                        AllowVendorNotOnOrder = True

                    End If

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case ImportAccountPayable.MediaType

                            Case "I"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                          ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                          Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.OrderDescription).Distinct.ToList

                            Case "M"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                          ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                          Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.OrderDescription).Distinct.ToList

                            Case "N"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                           ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                           Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.OrderDescription).Distinct.ToList

                            Case "O"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                           ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                           Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.OrderDescription).Distinct.ToList

                            Case "R"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                       ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                       ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.Description).Distinct.ToList

                            Case "T"

                                Datasource = (From Entity In AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, AllowVendorNotOnOrder, ImportAccountPayable.VendorCode, ImportAccountPayable.OfficeCode,
                                                                                                                    ImportAccountPayable.MediaClientCode, ImportAccountPayable.MediaDivisionCode, ImportAccountPayable.MediaProductCode,
                                                                                                                    ImportAccountPayable.Month, ImportAccountPayable.Year, Nothing, ImportAccountPayable.SourceCode, ImportAccountPayable.OrderID, ImportAccountPayable.LineDate)
                                              Select Entity.VendorCode, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode, Entity.OrderNumber, Entity.Description).Distinct.ToList

                        End Select

                    End Using

                End If

            End If

        End Sub
        Private Sub AccountPayable_RowChanged(e As DevExpress.XtraVerticalGrid.Events.RowChangedEventArgs)

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                If e.Row.Properties.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OfficeCode.ToString Then

                    DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).GLAccount = Nothing

                End If

            End If

        End Sub
        Private Sub AccountPayable_ShowingEditor(ByVal e As ComponentModel.CancelEventArgs)

            'objects
            Dim FieldName As String = Nothing

            FieldName = PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                    If FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.GLAccount.ToString Then

                        e.Cancel = (AdvantageFramework.Database.Procedures.Agency.APLockGLAccountCode(DbContext) = 1)

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString AndAlso
                            String.IsNullOrWhiteSpace(DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaClientCode) Then

                        e.Cancel = True

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaProductCode.ToString AndAlso
                            String.IsNullOrWhiteSpace(DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaDivisionCode) Then

                        e.Cancel = True

                    ElseIf FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.OrderNumber.ToString AndAlso
                            String.IsNullOrWhiteSpace(DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaType) Then

                        e.Cancel = True

                    End If

                End If

            End Using

        End Sub
        Private Sub AccountPayable_CellValueChanged(e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)

            'objects
            Dim MediaClientCode As String = Nothing
            Dim Division As AdvantageFramework.Database.Core.Division = Nothing
            Dim Product As AdvantageFramework.Database.Core.Product = Nothing

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.AccountPayable.Classes.ImportAccountPayable Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If e.Row.Properties.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaClientCode.ToString AndAlso Not String.IsNullOrWhiteSpace(e.Value) Then

                        If (From Entity In AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                            Where Entity.ClientCode = e.Value AndAlso
                                  Entity.IsActive = 1
                            Select Entity).Count = 1 Then

                            Division = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadCore(DbContext)
                                        Where Entity.ClientCode = e.Value AndAlso
                                              Entity.IsActive = 1
                                        Select Entity).SingleOrDefault

                            If Division IsNot Nothing Then

                                DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaDivisionCode = Division.Code

                                If (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                                    Where Entity.ClientCode = e.Value AndAlso
                                          Entity.DivisionCode = Division.Code AndAlso
                                          Entity.IsActive = 1
                                    Select Entity).Count = 1 Then

                                    Product = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                                               Where Entity.ClientCode = e.Value AndAlso
                                                     Entity.DivisionCode = Division.Code AndAlso
                                                     Entity.IsActive = 1
                                               Select Entity).SingleOrDefault

                                    If Product IsNot Nothing Then

                                        DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaProductCode = Product.Code

                                    End If

                                Else

                                    DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaProductCode = Nothing

                                End If

                            End If

                        Else

                            DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaDivisionCode = Nothing

                            DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaProductCode = Nothing

                        End If

                    ElseIf e.Row.Properties.FieldName = AdvantageFramework.AccountPayable.Classes.ImportAccountPayable.Properties.MediaDivisionCode.ToString AndAlso Not String.IsNullOrWhiteSpace(e.Value) Then

                        MediaClientCode = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaClientCode

                        If (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                            Where Entity.ClientCode = MediaClientCode AndAlso
                                  Entity.DivisionCode = e.Value AndAlso
                                  Entity.IsActive = 1
                            Select Entity).Count = 1 Then

                            Product = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadCore(DbContext)
                                       Where Entity.ClientCode = MediaClientCode AndAlso
                                             Entity.DivisionCode = e.Value AndAlso
                                             Entity.IsActive = 1
                                       Select Entity).SingleOrDefault

                            If Product IsNot Nothing Then

                                DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaProductCode = Product.Code

                            End If

                        Else

                            DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.AccountPayable.Classes.ImportAccountPayable).MediaProductCode = Nothing

                        End If

                    End If

                End Using

            End If

        End Sub

#End Region

#Region " Digital Results "

        Private Sub DigitalResults_QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                    AdvantageFramework.DigitalResults.LoadColumnEditorDatasouce(DbContext, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging), FieldName, OverrideDefaultDatasource, Datasource)

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResult Then

                    AdvantageFramework.DigitalResults.LoadColumnEditorDatasouce(DbContext, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResult), FieldName, OverrideDefaultDatasource, Datasource)

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                    AdvantageFramework.DigitalResults.LoadColumnEditorDatasouce(DbContext, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResultsView), FieldName, OverrideDefaultDatasource, Datasource)

                End If

            End Using

        End Sub
        Private Sub DigitalResults_ShowingEditor(ByVal e As ComponentModel.CancelEventArgs)

            'objects
            Dim FieldName As String = Nothing

            FieldName = PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                    e.Cancel = AdvantageFramework.DigitalResults.ProcessShowingEditor(FieldName, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging))

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResult Then

                    e.Cancel = AdvantageFramework.DigitalResults.ProcessShowingEditor(FieldName, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResult))

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                    e.Cancel = AdvantageFramework.DigitalResults.ProcessShowingEditor(FieldName, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResultsView))

                End If

            End Using

        End Sub
        Private Sub DigitalResults_CellValueChanged(e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs)

            'objects
            Dim FieldName As String = Nothing
            Dim RefreshGrid As Boolean = False

            FieldName = e.Row.Properties.FieldName

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                AdvantageFramework.DigitalResults.ProcessCellValueChanged(Me.Session, FieldName, e.Value, RefreshGrid, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging))

            ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResult Then

                AdvantageFramework.DigitalResults.ProcessCellValueChanged(Me.Session, FieldName, e.Value, RefreshGrid, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResult))

            ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                AdvantageFramework.DigitalResults.ProcessCellValueChanged(Me.Session, FieldName, e.Value, RefreshGrid, DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResultsView))

            End If

            If RefreshGrid Then



            End If

        End Sub
        Private Sub DigitalResults_ShownEditor()

            'objects
            Dim FieldName As String = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim MediaType As String = Nothing

            FieldName = PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName

            If FieldName = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.MediaPlanDetailID.ToString OrElse
                FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.EstimateID.ToString Then

                If TypeOf PropertyGridControlForm_Properties.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(PropertyGridControlForm_Properties.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    If GridLookUpEdit.Properties.View.Columns("ID") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("ID").VisibleIndex = 0
                        GridLookUpEdit.Properties.View.Columns("ID").Visible = True

                    End If

                End If

            ElseIf FieldName = AdvantageFramework.Database.Entities.DigitalResultsView.Properties.VendorCode.ToString Then

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.ImportDigitalResultsStaging Then

                    MediaType = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging).MediaType

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResult Then

                    MediaType = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResult).MediaType

                ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.DigitalResultsView Then

                    MediaType = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.DigitalResultsView).MediaType

                End If

                If Not String.IsNullOrWhiteSpace(MediaType) AndAlso TypeOf PropertyGridControlForm_Properties.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(PropertyGridControlForm_Properties.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                    GridLookUpEdit.Properties.View.ActiveFilterString = "Category = '" & MediaType & "'"

                End If

            End If

        End Sub

#End Region

#Region " Journal Entry "

        Private Sub JournalEntry_QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            Dim ImportJournalEntry As Object = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry Then

                    If FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.GLSource.ToString Then

                        ImportJournalEntry = (From Item In _ImportedItems
                                              Select Item).FirstOrDefault

                        If ImportJournalEntry IsNot Nothing Then

                            OverrideDefaultDatasource = True

                            Datasource = AdvantageFramework.GeneralLedger.GetValidGeneralLedgerSources(DbContext, DirectCast(ImportJournalEntry, AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry).ImportTemplateType)

                        End If

                    ElseIf FieldName = AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.PostPeriodCode.ToString Then

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.GeneralLedger.GetValidPostPeriods(DbContext)

                    End If

                End If

            End Using

        End Sub

#End Region

#Region " Expense Reports "

        Private Sub ExpenseReport_QueryPopupNeedDatasource(ByVal FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ImportCreditCardStaging As AdvantageFramework.Database.Entities.ImportCreditCardStaging = Nothing
            Dim AllowedProcessControlNumbers As Integer() = {1, 3, 4, 8, 9, 13}

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.Database.Entities.ImportCreditCardStaging Then

                    ImportCreditCardStaging = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.Database.Entities.ImportCreditCardStaging)

                    If FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobNumber.ToString Then

                        OverrideDefaultDatasource = True

                        Datasource = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Me.Session.UserCode, ImportCreditCardStaging.ClientCode, ImportCreditCardStaging.DivisionCode, ImportCreditCardStaging.ProductCode, Nothing, False, AllowedProcessControlNumbers)
                                      Join JobView In AdvantageFramework.Database.Procedures.JobView.Load(DbContext) On Item.JobNumber Equals JobView.JobNumber
                                      Group By [JN] = Item.JobNumber Into G = Group
                                      Select G.First.JobView).ToList

                    ElseIf FieldName = AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties.JobComponentID.ToString Then

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Me.Session.UserCode, ImportCreditCardStaging.ClientCode, ImportCreditCardStaging.DivisionCode, ImportCreditCardStaging.ProductCode, ImportCreditCardStaging.JobNumber.GetValueOrDefault(0), False, AllowedProcessControlNumbers)

                    End If

                End If

            End Using

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace