Namespace Importing.Presentation

    Public Class ImportFixedTemplateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
        Private _ImportTemplateID As Short = Nothing
        Private _IsEditing As Boolean = Nothing
        Private _IsChangingSelection As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ImportTemplateID As Short
            Get
                ImportTemplateID = _ImportTemplateID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef ImportTemplateID As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _ImportTemplateType = ImportTemplateType
            _ImportTemplateID = ImportTemplateID

        End Sub
        Private Sub SetupImportDialog()

            If _ImportTemplateID <> Nothing Then

                Me.Text = "Edit "

            Else

                Me.Text = "Create "

            End If

            Select Case _ImportTemplateType

                Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard, _
                        AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                    Me.Text &= " Expense Report Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                    Me.Text &= " Cleared Checks Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                    Me.Text &= " Accounts Payable Generic Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                    Me.Text &= " Client Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                    Me.Text &= " Client Contact Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                    Me.Text &= " Division Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                    Me.Text &= " Product Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                    Me.Text &= " Function Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                    Me.Text &= " Chart of Accounts Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                    Me.Text &= " Accounts Receivable Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                    Me.Text &= " Avalara Tax Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                    Me.Text &= " PTO Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                    Me.Text &= " Journal Entry Import Template"

            End Select

        End Sub
        Private Sub LoadImportDialog()

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ImportTemplateDetailFixed As AdvantageFramework.Database.Classes.ImportTemplateDetailFixed = Nothing
            Dim ImportTemplateDetailFixeds As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed) = Nothing
            'Dim AgencyImportPath As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ImportTemplateDetailFixeds = New Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    TextBoxForm_DefaultDirectory.Enabled = False

                End If

                ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportTemplateID)

                If ImportTemplate IsNot Nothing Then

                    TextBoxForm_DefaultDirectory.Text = ImportTemplate.DefaultDirectory

                End If

                If _IsEditing Then

                    If ImportTemplate IsNot Nothing Then

                        TextBoxForm_Name.Text = ImportTemplate.Name

                        ComboBoxForm_RecordSource.SelectedValue = ImportTemplate.RecordSourceID

                        Select Case _ImportTemplateType

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                    AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Importing.AccountPayableImportColumns), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailFixed.Start = ImpTempDtl.Start
                                    ImportTemplateDetailFixed.Length = ImpTempDtl.Length
                                    ImportTemplateDetailFixed.ID = ImpTempDtl.ID
                                    ImportTemplateDetailFixed.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailFixed.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                Next

                        End Select

                    End If

                Else

                    Select Case _ImportTemplateType

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.AccountPayableImportColumns))

                                If KeyValuePair.Key > 1 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties))

								If KeyValuePair.Key > 2 Then

									ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

									ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

									ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

								End If

							Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties))

                                If KeyValuePair.Key > 4 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties))

                                If KeyValuePair.Key > 0 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailFixed = New AdvantageFramework.Database.Classes.ImportTemplateDetailFixed

                                    ImportTemplateDetailFixed.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailFixeds.Add(ImportTemplateDetailFixed)

                                End If

                            Next

                    End Select

                End If

                DataGridViewForm_Items.DataSource = ImportTemplateDetailFixeds.OrderBy(Function(Entity) Entity.Start Is Nothing).ThenBy(Function(Entity) Entity.Start)

                DataGridViewForm_Items.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub ResetFields()

            TextBoxForm_File.Text = ""
            TextBoxForm_Name.Text = ""
            TextBoxForm_DefaultDirectory.Text = ""
            DataGridViewForm_Items.ClearGridCustomization()

        End Sub
        Private Sub SetDefaultLookupProperties()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Try

                SubItemGridLookUpEditControl = DirectCast(DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            End Try

            If SubItemGridLookUpEditControl IsNot Nothing Then

                Select Case _ImportTemplateType

                    Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                            AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 2
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.AccountPayableImportColumns)).ToList
                                                                   Where KeyValuePair.Key > 1
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

						SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties)).ToList
																   Where KeyValuePair.Key > 2
																   Select [Code] = CShort(KeyValuePair.Key),
																		  [Description] = KeyValuePair.Value
																   Order By Description Ascending).ToList

					Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 4
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 0
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 2
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties)).ToList
                                                                   Where KeyValuePair.Key > 2
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                End Select

            End If

        End Sub
        Private Sub AddImportTemplateDetailFixeds(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateID As Short)

            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim ImportTemplateDetailFixeds As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed) = Nothing

            Me.ShowWaitForm("Processing...")

            Try

                ImportTemplateDetailFixeds = DataGridViewForm_Items.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed)().ToList

                For Each ImportTemplateDtl In ImportTemplateDetailFixeds.Where(Function(ImportTempDetail) ImportTempDetail.FieldName <> 0 AndAlso ImportTempDetail.FieldName IsNot Nothing).ToList

                    ImportTemplateDetail = New AdvantageFramework.Database.Entities.ImportTemplateDetail

                    ImportTemplateDetail.TemplateID = ImportTemplateID

                    Select Case _ImportTemplateType

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Importing.AccountPayableImportColumns).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportClientStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportProductStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportPTOStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties).ToString

                    End Select

                    ImportTemplateDetail.Start = ImportTemplateDtl.Start
                    ImportTemplateDetail.Length = ImportTemplateDtl.Length
                    ImportTemplateDetail.DateFormat = ImportTemplateDtl.DateFormat

                    AdvantageFramework.Database.Procedures.ImportTemplateDetail.Insert(DbContext, ImportTemplateDetail)

                Next

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, Optional ByVal ImportTemplateID As Short = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportFixedTemplateDialog As AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog = Nothing

            ImportFixedTemplateDialog = New AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog(ImportTemplateType, ImportTemplateID)

            ShowFormDialog = ImportFixedTemplateDialog.ShowDialog()

            ImportTemplateID = ImportFixedTemplateDialog.ImportTemplateID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportFixedTemplateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            DataGridViewForm_Items.OptionsView.ShowFooter = False
            DataGridViewForm_Items.OptionsSelection.MultiSelect = False
            DataGridViewForm_Items.OptionsView.ShowViewCaption = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.ImportTemplate.Properties.Name)
                TextBoxForm_DefaultDirectory.SetPropertySettings(AdvantageFramework.Database.Entities.ImportTemplate.Properties.DefaultDirectory)
                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

                If _ImportTemplateID <> Nothing Then

                    _IsEditing = True
                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                Else

                    _IsEditing = False
                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                End If

                SetupImportDialog()

                LoadImportDialog()

                SetDefaultLookupProperties()

                If DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString) IsNot Nothing Then

                    DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString).OptionsColumn.ReadOnly = True

                End If

            End Using

            RichTextBoxForm_FileData.AutoWordSelection = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Updated As Boolean = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportTemplateID)

                    If ImportTemplate IsNot Nothing Then

                        ImportTemplate.DbContext = DbContext

                        ImportTemplate.Name = TextBoxForm_Name.Text
                        ImportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                        ImportTemplate.RecordSourceID = ComboBoxForm_RecordSource.GetSelectedValue

                        If AdvantageFramework.Database.Procedures.ImportTemplate.Update(DbContext, ImportTemplate) Then

                            If AdvantageFramework.Database.Procedures.ImportTemplateDetail.Delete(DbContext, _ImportTemplateID) Then

                                Updated = True

                                AddImportTemplateDetailFixeds(DbContext, _ImportTemplateID)

                            End If

                        End If

                    End If

                End Using

                If Updated Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim Added As Boolean = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ImportTemplateDetailFixeds As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed) = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportTemplateDetailFixeds = DataGridViewForm_Items.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportTemplateDetailFixed)().ToList

                    Try

                        ImportTemplate = New AdvantageFramework.Database.Entities.ImportTemplate

                        ImportTemplate.DbContext = DbContext

                        ImportTemplate.Name = TextBoxForm_Name.Text
                        ImportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                        ImportTemplate.Type = _ImportTemplateType
                        ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.Fixed
                        ImportTemplate.RecordSourceID = ComboBoxForm_RecordSource.GetSelectedValue

                        If AdvantageFramework.Database.Procedures.ImportTemplate.Insert(DbContext, ImportTemplate) Then

                            AddImportTemplateDetailFixeds(DbContext, ImportTemplate.ID)

                            Added = True

                        End If

                    Catch ex As Exception
                        Added = False
                    End Try

                    If Added Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                End Using

                Me.CloseWaitForm()

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
        Private Sub ButtonForm_LoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_LoadFile.Click

            If TextBoxForm_File.Text <> "" Then

                RichTextBoxForm_FileData.Text = My.Computer.FileSystem.ReadAllText(TextBoxForm_File.Text)

            End If

        End Sub
        Private Sub DataGridViewForm_Items_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Items.CellValueChangedEvent

            If DataGridViewForm_Items.Focused Then

                _IsChangingSelection = True

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.Start.ToString Then

                    Try

                        RichTextBoxForm_FileData.SelectionStart = e.Value

                    Catch ex As Exception
                        RichTextBoxForm_FileData.SelectionStart = 0
                    End Try

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.Length.ToString Then

                    Try

                        RichTextBoxForm_FileData.SelectionLength = e.Value

                    Catch ex As Exception
                        RichTextBoxForm_FileData.SelectionLength = 0
                    End Try

                End If

                _IsChangingSelection = False

            End If

        End Sub
        Private Sub DataGridViewForm_Items_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Items.SelectionChangedEvent

            'objects
            Dim ImportTemplateDetailFixed As AdvantageFramework.Database.Classes.ImportTemplateDetailFixed = Nothing
            Dim SelectedText As String = ""

            If DataGridViewForm_Items.HasOnlyOneSelectedRow AndAlso RichTextBoxForm_FileData.Text <> "" Then

                ImportTemplateDetailFixed = DataGridViewForm_Items.GetFirstSelectedRowDataBoundItem

                If ImportTemplateDetailFixed IsNot Nothing Then

                    _IsChangingSelection = True

                    Try

                        RichTextBoxForm_FileData.SelectionStart = ImportTemplateDetailFixed.Start.GetValueOrDefault(0)
                        RichTextBoxForm_FileData.SelectionLength = ImportTemplateDetailFixed.Length.GetValueOrDefault(0)

                    Catch ex As Exception
                        RichTextBoxForm_FileData.SelectionStart = 0
                        RichTextBoxForm_FileData.SelectionLength = 0
                    End Try

                    _IsChangingSelection = False

                End If

            End If

        End Sub
        Private Sub RichTextBoxForm_FileData_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RichTextBoxForm_FileData.SelectionChanged

            'objects
            Dim ImportTemplateDetailFixed As AdvantageFramework.Database.Classes.ImportTemplateDetailFixed = Nothing

            If DataGridViewForm_Items.HasOnlyOneSelectedRow AndAlso _IsChangingSelection = False Then

                ImportTemplateDetailFixed = DataGridViewForm_Items.GetFirstSelectedRowDataBoundItem

                If ImportTemplateDetailFixed IsNot Nothing Then

                    ImportTemplateDetailFixed.Start = RichTextBoxForm_FileData.SelectionStart
                    ImportTemplateDetailFixed.Length = RichTextBoxForm_FileData.SelectionLength

                    DataGridViewForm_Items.CurrentView.RefreshData()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Items_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Items.ShowingEditorEvent

            Dim Cancel As Boolean = False
            Dim FocusToFieldName As String = Nothing
            Dim FieldNameValue As Integer = 0

            If DataGridViewForm_Items.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString Then

                Cancel = True

                FocusToFieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.Start.ToString
                
            ElseIf DataGridViewForm_Items.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.DateFormat.ToString Then

                FieldNameValue = CInt(DataGridViewForm_Items.CurrentView.GetRowCellValue(DataGridViewForm_Items.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.FieldName.ToString))

                Select Case _ImportTemplateType

                    Case ImportTemplateTypes.AccountsPayable_Generic

                        If DirectCast(FieldNameValue, AdvantageFramework.Importing.AccountPayableImportColumns).ToString <> Importing.AccountPayableImportColumns.InvoiceDate.ToString AndAlso _
                                DirectCast(FieldNameValue, AdvantageFramework.Importing.AccountPayableImportColumns).ToString <> Importing.AccountPayableImportColumns.LineDate.ToString Then

                            Cancel = True

                        End If

                    Case ImportTemplateTypes.AccountsReceivable_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties).ToString <> AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.InvoiceDate.ToString AndAlso _
                                DirectCast(FieldNameValue, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties).ToString <> AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.DueDate.ToString Then

                            Cancel = True

                        End If

                    Case ImportTemplateTypes.ClearedChecks_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties.CheckClearedDate.ToString Then

                            Cancel = True

                        End If

                    Case ImportTemplateTypes.PTO_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportPTOStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportPTOStaging.Properties.ActivityDate.ToString Then

                            Cancel = True

                        End If

                    Case ImportTemplateTypes.JournalEntry_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties).ToString <> AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.TransactionDate.ToString Then

                            Cancel = True

                        End If

                    Case Else

                        Cancel = True

                End Select

                e.Cancel = Cancel

                If e.Cancel AndAlso FocusToFieldName IsNot Nothing Then

                    Try

                        DataGridViewForm_Items.CurrentView.FocusedColumn = DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailFixed.Properties.Start.ToString)

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub TextBoxForm_DefaultDirectory_TextChanged(sender As Object, e As EventArgs) Handles TextBoxForm_DefaultDirectory.TextChanged

            TextBoxForm_File.StartingFolderName = TextBoxForm_DefaultDirectory.Text

            TextBoxForm_File.SetAgencyImportPath(TextBoxForm_File.StartingFolderName, False)

        End Sub

#End Region

#End Region

    End Class

End Namespace