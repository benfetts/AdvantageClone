Namespace Maintenance.Accounting.Presentation

    Public Class VendorImportStagingForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _DataContext As AdvantageFramework.Database.DataContext = Nothing
        Private _ValidatingAllRows As Boolean = False
        Private _Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
        Private _Vendors As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Vendor) = Nothing
        Private _GeneralLedgerAccounts As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
        Private _Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Office) = Nothing
        Private _VendorTerms As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.VendorTerm) = Nothing
        Private _VendorCategories As System.Collections.Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
        Private _Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
        Private _GeneralLedgerOfficeCrossReferences As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference) = Nothing
        Private _AllowCostOfSaleEntry As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            _DbContext.Database.Connection.Open()

            Try

                DataGridViewForm_ImportedVendors.DataSource = AdvantageFramework.Database.Procedures.ImportVendorStaging.Load(_DbContext).ToList

            Catch ex As Exception
                DataGridViewForm_ImportedVendors.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ImportVendorStaging)
            End Try

            DataGridViewForm_ImportedVendors.CurrentView.BestFitColumns()

            _ValidatingAllRows = True

            LoadCacheData()

            Try

                DataGridViewForm_ImportedVendors.ValidateAllRowsAndClearChanged()

            Catch ex As Exception

            End Try

            ClearCacheData()

            _ValidatingAllRows = False

            _DbContext.Database.Connection.Close()

        End Sub
        Private Sub LoadCacheData()

            Try

                _Vendors = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.Load(_DbContext)).ToList
                _GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(_DbContext)).ToList
                _Offices = AdvantageFramework.Database.Procedures.Office.Load(_DbContext).ToList
                _VendorTerms = AdvantageFramework.Database.Procedures.VendorTerm.Load(_DbContext).ToList
                _VendorCategories = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportVendorCategories))
                _Functions = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.Load(_DbContext)).ToList
                _GeneralLedgerOfficeCrossReferences = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Load(_DbContext).ToList
                _AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(_DbContext)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ClearCacheData()

            Try

                _Vendors = Nothing
                _GeneralLedgerAccounts = Nothing
                _Offices = Nothing
                _VendorTerms = Nothing
                _VendorCategories = Nothing
                _Functions = Nothing
                _GeneralLedgerOfficeCrossReferences = Nothing

            Catch ex As Exception

            End Try

        End Sub
        Private Sub Save()

            For Each ImportVendorStaging In DataGridViewForm_ImportedVendors.GetAllModifiedRows.OfType(Of AdvantageFramework.Database.Entities.ImportVendorStaging).ToList

                _DbContext.UpdateObject(ImportVendorStaging)

            Next

            _DbContext.SaveChanges()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Import.Enabled = DataGridViewForm_ImportedVendors.HasASelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_ImportedVendors.HasASelectedRow
            ButtonItemActions_Refresh.Enabled = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim VendorImportStagingForm As VendorImportStagingForm = Nothing

            VendorImportStagingForm = New VendorImportStagingForm()

            VendorImportStagingForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorImportStagingForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            DataGridViewForm_ImportedVendors.RunStandardValidation = False

            _DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
            _DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
            _Properties = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ImportVendorStaging)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

        End Sub
        Private Sub VendorImportStagingForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            LoadGrid()

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

            If DataGridViewForm_ImportedVendors.HasRows = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There are no vendor records to import.")

            End If

        End Sub
        Private Sub VendorImportStagingForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub VendorImportStagingForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            If DataGridViewForm_ImportedVendors.HasRows Then

                DataGridViewForm_ImportedVendors.CurrentView.CloseEditorForUpdating()

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Saving...")

                Try

                    Save()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                DataGridViewForm_ImportedVendors.ClearChanged()
                Me.ClearChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Import.Click

            'objects
            Dim IsValid As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorImported As Boolean = False
            Dim ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewForm_ImportedVendors.HasRows Then

                Me.FormAction = WinForm.Presentation.FormActions.Saving
                Me.ShowWaitForm("Importing...")

                DataGridViewForm_ImportedVendors.CurrentView.CloseEditorForUpdating()

                RowHandlesAndDataBoundItems = DataGridViewForm_ImportedVendors.GetAllRowsRowHandlesAndDataBoundItems

                _DbContext.Database.Connection.Open()

                LoadCacheData()

                For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                    Try

                        If TypeOf RowHandleAndDataBoundItem.Value Is AdvantageFramework.Database.Entities.ImportVendorStaging Then

                            ImportVendorStaging = RowHandleAndDataBoundItem.Value

                        End If

                    Catch ex As Exception
                        ImportVendorStaging = Nothing
                    End Try

                    If ImportVendorStaging IsNot Nothing AndAlso ImportVendorStaging.HasError = False Then

                        IsValid = True
                        VendorImported = False

                        Try

                            ImportVendorStaging.DbContext = _DbContext

                            If ImportVendorStaging.OnHold = False Then

                                ImportVendorStaging.ValidateEntity(IsValid, _Properties, _Vendors, _GeneralLedgerAccounts, _Offices, _VendorTerms, _VendorCategories, _Functions, _GeneralLedgerOfficeCrossReferences, _AllowCostOfSaleEntry)

                                If IsValid Then

                                    If ImportVendorStaging.IsNew Then

                                        If ImportVendorStaging.VendorPayToCode = ImportVendorStaging.VendorCode AndAlso _
                                                (ImportVendorStaging.VendorPayToAddressLine1 Is Nothing OrElse ImportVendorStaging.VendorPayToAddressLine1 = Nothing OrElse ImportVendorStaging.VendorPayToAddressLine1.Trim = "") AndAlso _
                                                (ImportVendorStaging.VendorPayToAddressLine2 Is Nothing OrElse ImportVendorStaging.VendorPayToAddressLine2 = Nothing OrElse ImportVendorStaging.VendorPayToAddressLine2.Trim = "") AndAlso _
                                                (ImportVendorStaging.VendorPayToStreetAddressLine3 Is Nothing OrElse ImportVendorStaging.VendorPayToStreetAddressLine3 = Nothing OrElse ImportVendorStaging.VendorPayToStreetAddressLine3.Trim = "") Then

                                            ImportVendorStaging.VendorPayToAddressLine1 = ImportVendorStaging.VendorStreetAddressLine1
                                            ImportVendorStaging.VendorPayToAddressLine2 = ImportVendorStaging.VendorStreetAddressLine2
                                            ImportVendorStaging.VendorPayToStreetAddressLine3 = ImportVendorStaging.VendorStreetAddressLine3
                                            ImportVendorStaging.VendorPayToCity = ImportVendorStaging.VendorCity
                                            ImportVendorStaging.VendorPayToCounty = ImportVendorStaging.VendorCounty
                                            ImportVendorStaging.VendorPayToState = ImportVendorStaging.VendorState
                                            ImportVendorStaging.VendorPayToCountry = ImportVendorStaging.VendorCountry
                                            ImportVendorStaging.VendorPayToZipCode = ImportVendorStaging.VendorZipCode
                                            ImportVendorStaging.VendorPayToPhoneNumber = ImportVendorStaging.VendorPhoneNumber
                                            ImportVendorStaging.VendorPayToPhoneNumberExtension = ImportVendorStaging.VendorPhoneNumberExtension
                                            ImportVendorStaging.VendorPayToFaxPhoneNumber = ImportVendorStaging.VendorFaxPhoneNumber
                                            ImportVendorStaging.VendorPayToFaxPhoneNumberExtension = ImportVendorStaging.VendorFaxPhoneNumberExtension

                                        End If

                                        If AdvantageFramework.Database.Procedures.ImportVendorStaging.Update(_DbContext, ImportVendorStaging) Then

                                            If AdvantageFramework.Database.Procedures.ImportVendorStaging.ImportVendorFromImportVendorStaging(_DbContext, ImportVendorStaging.ID, _DbContext.UserCode, False) Then

                                                VendorImported = AdvantageFramework.Database.Procedures.ImportVendorStaging.Delete(_DbContext, ImportVendorStaging)

                                            End If

                                        End If

                                    Else

                                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(_DbContext, ImportVendorStaging.VendorCode)

                                        If Vendor IsNot Nothing Then

                                            ImportVendorStaging.VendorName = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Name, ImportVendorStaging.VendorName)
                                            ImportVendorStaging.VendorStreetAddressLine1 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.StreetAddressLine1, ImportVendorStaging.VendorStreetAddressLine1)
                                            ImportVendorStaging.VendorStreetAddressLine2 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.StreetAddressLine2, ImportVendorStaging.VendorStreetAddressLine2)
                                            ImportVendorStaging.VendorStreetAddressLine3 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.StreetAddressLine3, ImportVendorStaging.VendorStreetAddressLine3)
                                            ImportVendorStaging.VendorCity = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.City, ImportVendorStaging.VendorCity)
                                            ImportVendorStaging.VendorCounty = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.County, ImportVendorStaging.VendorCounty)
                                            ImportVendorStaging.VendorState = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.State, ImportVendorStaging.VendorState)
                                            ImportVendorStaging.VendorCountry = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Country, ImportVendorStaging.VendorCountry)
                                            ImportVendorStaging.VendorZipCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.ZipCode, ImportVendorStaging.VendorZipCode)
                                            ImportVendorStaging.VendorPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PhoneNumber, ImportVendorStaging.VendorPhoneNumber)
                                            ImportVendorStaging.VendorPhoneNumberExtension = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PhoneNumberExtension, ImportVendorStaging.VendorPhoneNumberExtension)
                                            ImportVendorStaging.VendorFaxPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.FaxPhoneNumber, ImportVendorStaging.VendorFaxPhoneNumber)
                                            ImportVendorStaging.VendorFaxPhoneNumberExtension = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.FaxPhoneNumberExtension, ImportVendorStaging.VendorFaxPhoneNumberExtension)
                                            ImportVendorStaging.VendorPayToCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToCode, ImportVendorStaging.VendorPayToCode)
                                            ImportVendorStaging.VendorPayToName = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToName, ImportVendorStaging.VendorPayToName)
                                            ImportVendorStaging.VendorPayToAddressLine1 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToAddressLine1, ImportVendorStaging.VendorPayToAddressLine1)
                                            ImportVendorStaging.VendorPayToAddressLine2 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToAddressLine2, ImportVendorStaging.VendorPayToAddressLine2)
                                            ImportVendorStaging.VendorPayToStreetAddressLine3 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToStreetAddressLine3, ImportVendorStaging.VendorPayToStreetAddressLine3)
                                            ImportVendorStaging.VendorPayToCity = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToCity, ImportVendorStaging.VendorPayToCity)
                                            ImportVendorStaging.VendorPayToCounty = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToCounty, ImportVendorStaging.VendorPayToCounty)
                                            ImportVendorStaging.VendorPayToState = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToState, ImportVendorStaging.VendorPayToState)
                                            ImportVendorStaging.VendorPayToCountry = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToCountry, ImportVendorStaging.VendorPayToCountry)
                                            ImportVendorStaging.VendorPayToZipCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToZipCode, ImportVendorStaging.VendorPayToZipCode)
                                            ImportVendorStaging.VendorPayToPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToPhoneNumber, ImportVendorStaging.VendorPayToPhoneNumber)
                                            ImportVendorStaging.VendorPayToPhoneNumberExtension = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToPhoneNumberExtension, ImportVendorStaging.VendorPayToPhoneNumberExtension)
                                            ImportVendorStaging.VendorPayToFaxPhoneNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToFaxPhoneNumber, ImportVendorStaging.VendorPayToFaxPhoneNumber)
                                            ImportVendorStaging.VendorPayToFaxPhoneNumberExtension = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PayToFaxPhoneNumberExtension, ImportVendorStaging.VendorPayToFaxPhoneNumberExtension)
                                            ImportVendorStaging.VendorTermCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.VendorTermCode, ImportVendorStaging.VendorTermCode)
                                            ImportVendorStaging.VendorTaxID = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.TaxID, ImportVendorStaging.VendorTaxID)
                                            ImportVendorStaging.Vendor1099Flag = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099Flag, ImportVendorStaging.Vendor1099Flag)
                                            ImportVendorStaging.VendorCategory = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.VendorCategory, ImportVendorStaging.VendorCategory)
                                            ImportVendorStaging.DefaultAPAccount = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.DefaultAPAccount, ImportVendorStaging.DefaultAPAccount)
                                            ImportVendorStaging.VendorNotes = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Notes, ImportVendorStaging.VendorNotes)
                                            ImportVendorStaging.DefaultExpenseAccount = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.DefaultExpenseAccount, ImportVendorStaging.DefaultExpenseAccount)
                                            ImportVendorStaging.AssociateWithOffice = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.AssociateWithOffice, ImportVendorStaging.AssociateWithOffice)
                                            ImportVendorStaging.OfficeCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.OfficeCode, ImportVendorStaging.OfficeCode)
                                            ImportVendorStaging.Vendor1099StreetAddressLine1 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099StreetAddressLine1, ImportVendorStaging.Vendor1099StreetAddressLine1)
                                            ImportVendorStaging.Vendor1099StreetAddressLine2 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099StreetAddressLine2, ImportVendorStaging.Vendor1099StreetAddressLine2)
                                            ImportVendorStaging.Vendor1099StreetAddressLine3 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099StreetAddressLine3, ImportVendorStaging.Vendor1099StreetAddressLine3)
                                            ImportVendorStaging.Vendor1099City = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099City, ImportVendorStaging.Vendor1099City)
                                            ImportVendorStaging.Vendor1099State = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099State, ImportVendorStaging.Vendor1099State)
                                            ImportVendorStaging.Vendor1099ZipCode = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099ZipCode, ImportVendorStaging.Vendor1099ZipCode)
                                            ImportVendorStaging.Vendor1099County = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099County, ImportVendorStaging.Vendor1099County)
                                            ImportVendorStaging.Vendor1099Country = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.Vendor1099Country, ImportVendorStaging.Vendor1099Country)
                                            ImportVendorStaging.UseAlternativeAddressFor1099 = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.UseAlternativeAddressFor1099, ImportVendorStaging.UseAlternativeAddressFor1099)
                                            ImportVendorStaging.VendorAccountNumber = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.AccountNumber, ImportVendorStaging.VendorAccountNumber)
                                            ImportVendorStaging.DefaultFunction = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.FunctionCode, ImportVendorStaging.DefaultFunction)
                                            ImportVendorStaging.EmployeeVendor = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.EmployeeVendor, ImportVendorStaging.EmployeeVendor)
                                            ImportVendorStaging.OneCheckPerInvoice = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.OneCheckPerInvoice, ImportVendorStaging.OneCheckPerInvoice)
                                            ImportVendorStaging.VendorEmailAddress = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.EmailAddress, ImportVendorStaging.VendorEmailAddress)
                                            ImportVendorStaging.PaymentManagerEmailAddress = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.PaymentManagerEmailAddress, ImportVendorStaging.PaymentManagerEmailAddress)
                                            ImportVendorStaging.ActiveFlag = AdvantageFramework.Importing.LoadImportedDataToUpdate(Vendor.ActiveFlag, ImportVendorStaging.ActiveFlag)

                                            If AdvantageFramework.Database.Procedures.ImportVendorStaging.Update(_DbContext, ImportVendorStaging) Then

                                                If AdvantageFramework.Database.Procedures.ImportVendorStaging.ImportVendorFromImportVendorStaging(_DbContext, ImportVendorStaging.ID, _DbContext.UserCode, True) Then

                                                    VendorImported = AdvantageFramework.Database.Procedures.ImportVendorStaging.Delete(_DbContext, ImportVendorStaging)

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                            VendorImported = False
                        End Try

                        If VendorImported Then

                            DataGridViewForm_ImportedVendors.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                        End If

                    End If

                Next

                _DbContext.Database.Connection.Close()

                ClearCacheData()

                If DataGridViewForm_ImportedVendors.CheckForModifiedRows = False Then

                    Me.ClearChanged()

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ImportVendorStagingIDs As Generic.List(Of Integer) = Nothing

            If DataGridViewForm_ImportedVendors.HasASelectedRow Then

                DataGridViewForm_ImportedVendors.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Deleting
                    Me.ShowWaitForm("Deleting...")

                    Try

                        RowHandlesAndDataBoundItems = DataGridViewForm_ImportedVendors.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        ImportVendorStagingIDs = RowHandlesAndDataBoundItems.Select(Function(KeyValue) KeyValue.Value).OfType(Of AdvantageFramework.Database.Entities.ImportVendorStaging).Select(Function(Entity) Entity.ID).ToList

                        If AdvantageFramework.Database.Procedures.ImportVendorStaging.DeleteByImportVendorStagingIDs(_DbContext, ImportVendorStagingIDs.ToArray) Then

                            DataGridViewForm_ImportedVendors.CurrentView.BeginDataUpdate()

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                                DataGridViewForm_ImportedVendors.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                            Next

                            DataGridViewForm_ImportedVendors.CurrentView.EndDataUpdate()

                        End If

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If DataGridViewForm_ImportedVendors.CheckForModifiedRows = False Then

                        Me.ClearChanged()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            'objects
            Dim ContinueRefreshing As Boolean = True

            DataGridViewForm_ImportedVendors.CurrentView.CloseEditorForUpdating()

            If DataGridViewForm_ImportedVendors.CheckForModifiedRows Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.FormAction = WinForm.Presentation.FormActions.Saving
                    Me.ShowWaitForm("Saving...")

                    Try

                        Save()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    DataGridViewForm_ImportedVendors.ClearChanged()
                    Me.ClearChanged()

                Else

                    ContinueRefreshing = False

                End If

            End If

            If ContinueRefreshing Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                LoadGrid()

                EnableOrDisableActions()

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedVendors_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_ImportedVendors.QueryPopupNeedDatasourceEvent

            Dim AllowCostOfSaleEntry As Boolean = False

            If FieldName = AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultAPAccount.ToString Then

                OverrideDefaultDatasource = True

                Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, True, "5"))

            ElseIf FieldName = AdvantageFramework.Database.Entities.ImportVendorStaging.Properties.DefaultExpenseAccount.ToString Then

                OverrideDefaultDatasource = True

                Try

                    AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(_DbContext)

                Catch ex As Exception
                    AllowCostOfSaleEntry = False
                End Try

                If AllowCostOfSaleEntry Then

                    Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, False))

                Else

                    Datasource = From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(_DbContext, True, False))
                                 Where Entity.Type <> "8" AndAlso _
                                       Entity.Type <> "13"
                                 Select Entity

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedVendors_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_ImportedVendors.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ImportedVendors_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_ImportedVendors.ValidateRowEvent

            If TypeOf e.Row Is AdvantageFramework.Database.Entities.ImportVendorStaging Then

                If _ValidatingAllRows Then

                    CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).DbContext = _DbContext
                    CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).DataContext = _DataContext

                    e.ErrorText = CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).ValidateEntity(e.Valid, _Properties, _Vendors, _GeneralLedgerAccounts, _Offices, _VendorTerms, _VendorCategories, _Functions, _GeneralLedgerOfficeCrossReferences, _AllowCostOfSaleEntry)

                    e.Valid = True

                Else

                    CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).DbContext = _DbContext
                    CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).DataContext = _DataContext

                    e.ErrorText = CType(e.Row, AdvantageFramework.Database.Entities.ImportVendorStaging).ValidateEntity(e.Valid, _Properties)

                    e.Valid = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ImportedVendors_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_ImportedVendors.ValidatingEditorEvent

            'objects
            Dim ImportVendorStaging As AdvantageFramework.Database.Entities.ImportVendorStaging = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                ImportVendorStaging = DataGridViewForm_ImportedVendors.CurrentView.GetFocusedRow

            Catch ex As Exception
                ImportVendorStaging = Nothing
            End Try

            Try

                PropertyDescriptor = _Properties.SingleOrDefault(Function(PD) PD.Name = DataGridViewForm_ImportedVendors.CurrentView.FocusedColumn.FieldName)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            If ImportVendorStaging IsNot Nothing AndAlso PropertyDescriptor IsNot Nothing Then

                ImportVendorStaging.DbContext = _DbContext
                ImportVendorStaging.DataContext = _DataContext

                e.ErrorText = ImportVendorStaging.ValidateEntityProperty(PropertyDescriptor, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace