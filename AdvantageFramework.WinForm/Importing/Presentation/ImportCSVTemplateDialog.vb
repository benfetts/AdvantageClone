Namespace Importing.Presentation

    Public Class ImportCSVTemplateDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
        Private _ImportTemplateID As Short = Nothing
        Private _IsEditing As Boolean = Nothing
        Private _CSVPositionDisabled As Boolean = False
        Private _FieldNameDisabled As Boolean = False

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

                    Me.Text &= " Accounts Payable Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                    Me.Text &= " Client Import Template"

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

                Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                    Me.Text &= " Media Results Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                    Me.Text &= " Avalara Tax Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                    Me.Text &= " Cash Receipt Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                    Me.Text &= " Client Contact Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                    Me.Text &= " PTO Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                    Me.Text &= " Journal Entry Import Template"

                Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                    Me.Text &= " Employee Hours Import Template"

            End Select

        End Sub
        Private Sub LoadImportDialog()

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ImportTemplateDetailCSV As AdvantageFramework.Database.Classes.ImportTemplateDetailCSV = Nothing
            Dim ImportTemplateDetailCSVs As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) = Nothing
            Dim ImportTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplateDetail) = Nothing
            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim KeyValuePair As KeyValuePair(Of Long, String) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            'Dim AgencyImportPath As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ImportTemplateDetailCSVs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV)

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

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties))

                                    If KeyValuePair.Key > 2 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                                For Each ImpTempDtl In AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties), ImpTempDtl.FieldName))
                                    ImportTemplateDetailCSV.CSVPosition = ImpTempDtl.CSVPosition
                                    ImportTemplateDetailCSV.ID = ImpTempDtl.ID
                                    ImportTemplateDetailCSV.TemplateID = ImpTempDtl.TemplateID
                                    ImportTemplateDetailCSV.DateFormat = ImpTempDtl.DateFormat

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.AccountPayableImportColumns))

                                    If KeyValuePair.Key > 1 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties))

									If KeyValuePair.Key > 2 Then

										ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

										ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

										Try

											ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
																	Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
																	Select ImpTempDtl).SingleOrDefault

										Catch ex As Exception
											ImportTemplateDetail = Nothing
										End Try

										If ImportTemplateDetail IsNot Nothing Then

											ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
											ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
											ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
											ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

										End If

										ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

									End If

								Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties))

                                    If KeyValuePair.Key > 4 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties))

                                    If KeyValuePair.Key > 3 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties))

                                    If KeyValuePair.Key > 3 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties))

                                    If KeyValuePair.Key > 3 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties))

                                    If KeyValuePair.Key > 3 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties))

                                    If KeyValuePair.Key > 0 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames()

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    Try

                                        ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                Select ImpTempDtl).SingleOrDefault

                                    Catch ex As Exception
                                        ImportTemplateDetail = Nothing
                                    End Try

                                    If ImportTemplateDetail IsNot Nothing Then

                                        ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                        ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                        ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                        ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                    End If

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties))

                                    If KeyValuePair.Key > 3 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.CashReceiptImportColumns))

                                    If KeyValuePair.Key > 1 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties))

                                    If KeyValuePair.Key > 2 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties))

                                    If KeyValuePair.Key > 2 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                            Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                                ImportTemplateDetails = AdvantageFramework.Database.Procedures.ImportTemplateDetail.LoadByTemplateID(DbContext, _ImportTemplateID).ToList

                                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties))

                                    If KeyValuePair.Key > 2 Then

                                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                        ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                        Try

                                            ImportTemplateDetail = (From ImpTempDtl In ImportTemplateDetails
                                                                    Where ImpTempDtl.FieldName.ToUpper = KeyValuePair.Value.Replace(" ", "").ToUpper
                                                                    Select ImpTempDtl).SingleOrDefault

                                        Catch ex As Exception
                                            ImportTemplateDetail = Nothing
                                        End Try

                                        If ImportTemplateDetail IsNot Nothing Then

                                            ImportTemplateDetailCSV.ID = ImportTemplateDetail.ID
                                            ImportTemplateDetailCSV.CSVPosition = ImportTemplateDetail.CSVPosition
                                            ImportTemplateDetailCSV.TemplateID = ImportTemplateDetail.TemplateID
                                            ImportTemplateDetailCSV.DateFormat = ImportTemplateDetail.DateFormat

                                        End If

                                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                    End If

                                Next

                        End Select

                    End If

                Else

                    Select Case _ImportTemplateType

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                                AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.AccountPayableImportColumns))

                                If KeyValuePair.Key > 1 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Client_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties))

								If KeyValuePair.Key > 2 Then

									ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

									ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

									ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

								End If

							Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties))

                                If KeyValuePair.Key > 4 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Division_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Product_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Function_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties))

                                If KeyValuePair.Key > 0 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                            For Each KeyValuePair In AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames()

                                ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties))

                                If KeyValuePair.Key > 3 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.CashReceiptImportColumns))

                                If KeyValuePair.Key > 1 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                            For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties))

                                If KeyValuePair.Key > 2 Then

                                    ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                                    ImportTemplateDetailCSV.FieldName = CShort(KeyValuePair.Key)

                                    ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                                End If

                            Next

                    End Select

                End If

                DataGridViewForm_Items.DataSource = ImportTemplateDetailCSVs.OrderBy(Function(Entity) Entity.CSVPosition Is Nothing).ThenBy(Function(Entity) Entity.CSVPosition)

                DataGridViewForm_Items.CurrentView.BestFitColumns()

                DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString).Visible = False
                DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVPosition.ToString).OptionsColumn.FixedWidth = True

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

                SubItemGridLookUpEditControl = DirectCast(DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

            Catch ex As Exception
                SubItemGridLookUpEditControl = Nothing
            End Try

            If SubItemGridLookUpEditControl IsNot Nothing Then

                Select Case _ImportTemplateType

                    Case AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard,
                            AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 1 AndAlso
                                                                         KeyValuePair.Value <> "Job Component ID"
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

                    Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames()
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = If(KeyValuePair.Value = "Result Date", "Start Date", KeyValuePair.Value)
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 3
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                    Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.CashReceiptImportColumns)).ToList
                                                                   Where KeyValuePair.Key > 1
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

                    Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                        SubItemGridLookUpEditControl.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties)).ToList
                                                                   Where KeyValuePair.Key > 2
                                                                   Select [Code] = CShort(KeyValuePair.Key),
                                                                          [Description] = KeyValuePair.Value
                                                                   Order By Description Ascending).ToList

                End Select

            End If

        End Sub
        Private Sub AddImportTemplateDetailCSVs(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateID As Short)

            Dim ImportTemplateDetail As AdvantageFramework.Database.Entities.ImportTemplateDetail = Nothing
            Dim ImportTemplateDetailCSVs As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) = Nothing

            Me.ShowWaitForm("Processing...")

            Try

                ImportTemplateDetailCSVs = DataGridViewForm_Items.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV)().ToList

                For Each ImportTemplateDtl In ImportTemplateDetailCSVs.Where(Function(ImportTempDetail) ImportTempDetail.CSVPosition.HasValue AndAlso ImportTempDetail.FieldName.HasValue)

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

                        Case AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Importing.CashReceiptImportColumns).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportPTOStaging.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties).ToString

                        Case AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours

                            ImportTemplateDetail.FieldName = DirectCast(CInt(ImportTemplateDtl.FieldName), AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString

                    End Select

                    ImportTemplateDetail.CSVPosition = ImportTemplateDtl.CSVPosition
                    ImportTemplateDetail.DateFormat = ImportTemplateDtl.DateFormat

                    AdvantageFramework.Database.Procedures.ImportTemplateDetail.Insert(DbContext, ImportTemplateDetail)

                Next

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub EnableOrDisableColumns()

            Try

                If DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString).Visible = True AndAlso
                   DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString).Visible = True AndAlso
                   DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString).Visible = False Then

                    If _IsEditing Then

                        _CSVPositionDisabled = False
                        _FieldNameDisabled = False

                    Else

                        _CSVPositionDisabled = False
                        _FieldNameDisabled = True

                    End If

                Else

                    _CSVPositionDisabled = True
                    _FieldNameDisabled = False

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Function ValidateTemplate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim ImportTemplateDetailCSVs As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) = Nothing

            Try

                ImportTemplateDetailCSVs = DataGridViewForm_Items.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV)().ToList

                If DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString).Visible Then

                    'loaded from file
                    If (From Entity In ImportTemplateDetailCSVs
                        Where Entity.FieldName IsNot Nothing
                        Select Entity.FieldName).Distinct.Count <> (From Entity In ImportTemplateDetailCSVs
                                                                    Where Entity.FieldName IsNot Nothing
                                                                    Select Entity.FieldName).Count Then

                        IsValid = False
                        ErrorMessage = "You cannot assign the same import field to more than one CSV field." & vbCrLf

                    End If

                Else

                    If (From Entity In ImportTemplateDetailCSVs
                        Where Entity.CSVPosition IsNot Nothing
                        Select Entity.CSVPosition).Distinct.Count <> (From Entity In ImportTemplateDetailCSVs
                                                                      Where Entity.CSVPosition IsNot Nothing
                                                                      Select Entity.CSVPosition).Count Then

                        IsValid = False
                        ErrorMessage = "You cannot assign the same import field to more than one CSV field." & vbCrLf

                    End If

                End If

            Catch ex As Exception
                IsValid = True
            Finally
                ValidateTemplate = IsValid
            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, Optional ByVal ImportTemplateID As Short = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportCSVTemplateDialog As AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog = Nothing

            ImportCSVTemplateDialog = New AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog(ImportTemplateType, ImportTemplateID)

            ShowFormDialog = ImportCSVTemplateDialog.ShowDialog()

            ImportTemplateID = ImportCSVTemplateDialog.ImportTemplateID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportCSVTemplateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

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

                DataGridViewForm_Items.OptionsView.ShowViewCaption = False

                SetupImportDialog()

                LoadImportDialog()

                SetDefaultLookupProperties()

                EnableOrDisableColumns()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Updated As Boolean = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim TemplateDetailsValid As Boolean = Nothing

            TemplateDetailsValid = ValidateTemplate(ErrorMessage)

            If Me.Validator AndAlso TemplateDetailsValid Then

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

                                AddImportTemplateDetailCSVs(DbContext, _ImportTemplateID)

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
            Dim ImportTemplateDetailCSVs As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) = Nothing
            Dim TemplateDetailsValid As Boolean = True

            TemplateDetailsValid = ValidateTemplate(ErrorMessage)

            If Me.Validator AndAlso TemplateDetailsValid Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        ImportTemplate = New AdvantageFramework.Database.Entities.ImportTemplate

                        ImportTemplate.DbContext = DbContext

                        ImportTemplate.Name = TextBoxForm_Name.Text
                        ImportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                        ImportTemplate.Type = _ImportTemplateType
                        ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV
                        ImportTemplate.RecordSourceID = ComboBoxForm_RecordSource.GetSelectedValue

                        If AdvantageFramework.Database.Procedures.ImportTemplate.Insert(DbContext, ImportTemplate) Then

                            AddImportTemplateDetailCSVs(DbContext, ImportTemplate.ID)

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

            'objects
            Dim CSVLine As String() = Nothing
            Dim ImportTemplateDetailCSV As AdvantageFramework.Database.Classes.ImportTemplateDetailCSV = Nothing
            Dim ImportTemplateDetailCSVs As Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV) = Nothing
            Dim CSVItemPosition As Short = 0
            Dim FieldName As Short? = Nothing
            Dim MaxValue As Integer = Nothing

            If TextBoxForm_File.Text <> "" Then

                Try

                    CSVLine = AdvantageFramework.Importing.LoadFirstCSVLine(TextBoxForm_File.Text)

                Catch ex As Exception
                    CSVLine = Nothing
                End Try

                If CSVLine IsNot Nothing Then

                    ImportTemplateDetailCSVs = New Generic.List(Of AdvantageFramework.Database.Classes.ImportTemplateDetailCSV)

                    For Each CSVItem In CSVLine

                        ImportTemplateDetailCSV = New AdvantageFramework.Database.Classes.ImportTemplateDetailCSV

                        ImportTemplateDetailCSV.CSVPosition = CSVItemPosition
                        ImportTemplateDetailCSV.CSVField = CSVItem

                        If _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard OrElse
                                _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard Then

                            If (CSVItemPosition + 3) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 3) ' skips ID & JobComponentID

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic Then

                            If (CSVItemPosition + 2) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Importing.AccountPayableImportColumns)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 2)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.Client_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportClientStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default Then

                            If (CSVItemPosition + 5) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportClientContactStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 5)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.Division_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportDivisionStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.Product_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportProductStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.Function_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportGeneralLedgerAccountStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default Then

                            If (CSVItemPosition + 1) <= CInt([Enum].GetValues(GetType(AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 1)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default Then

                            Try

                                FieldName = Nothing

                                For Each KeyValue In AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames()

                                    If KeyValue.Value.Replace(" ", "").ToUpper = CSVItem.Replace(" ", "").ToUpper Then

                                        FieldName = CShort(KeyValue.Key)
                                        Exit For

                                    ElseIf KeyValue.Value.Replace(" ", "").ToUpper = AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ResultDate.ToString.ToUpper Then

                                        If "StartDate".ToUpper = CSVItem.Replace(" ", "").ToUpper Then

                                            FieldName = CShort(KeyValue.Key)
                                            Exit For

                                        End If

                                    End If

                                Next

                                If FieldName.HasValue = False Then

                                    Try

                                        FieldName = CShort(AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames().Skip(CSVItemPosition).Take(1).FirstOrDefault.Key)

                                    Catch ex As Exception
                                        FieldName = Nothing
                                    End Try

                                End If

                                If FieldName.HasValue Then

                                    While (From Entity In ImportTemplateDetailCSVs
                                           Where Entity.FieldName = FieldName
                                           Select Entity).Any

                                        FieldName = FieldName + 1

                                    End While

                                    If (From KeyValue In AdvantageFramework.Importing.LoadDigitalResultsTemplateFieldNames()
                                        Where KeyValue.Key = CLng(FieldName)
                                        Select KeyValue).Any = False Then

                                        FieldName = Nothing

                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                            ImportTemplateDetailCSV.FieldName = FieldName

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default Then

                            If (CSVItemPosition + 4) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportAvalaraTaxStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 4)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic Then

                            If (CSVItemPosition + 2) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Importing.CashReceiptImportColumns)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 2)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default Then

                            If (CSVItemPosition + 3) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportPTOStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 3)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default Then

                            If (CSVItemPosition + 3) <= CInt([Enum].GetValues(GetType(AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 3)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        ElseIf _ImportTemplateType = AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours Then

                            If (CSVItemPosition + 3) <= CInt([Enum].GetValues(GetType(AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties)).Cast(Of Integer).Max) Then

                                ImportTemplateDetailCSV.FieldName = CShort(CSVItemPosition + 3)

                            Else

                                ImportTemplateDetailCSV.FieldName = Nothing

                            End If

                        Else

                            ImportTemplateDetailCSV.FieldName = CSVItemPosition

                        End If

                        ImportTemplateDetailCSVs.Add(ImportTemplateDetailCSV)

                        CSVItemPosition = CSVItemPosition + 1

                    Next

                    DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString).Visible = True
                    DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVPosition.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewForm_Items.CurrentView.Columns(AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString).OptionsColumn.AllowEdit = True

                    DataGridViewForm_Items.DataSource = ImportTemplateDetailCSVs
                    DataGridViewForm_Items.CurrentView.BestFitColumns()

                    SetDefaultLookupProperties()

                End If

            End If

            EnableOrDisableColumns()

        End Sub
        Private Sub ButtonForm_Reset_Click(sender As System.Object, e As System.EventArgs) Handles ButtonForm_Reset.Click

            ResetFields()

            LoadImportDialog()

            SetDefaultLookupProperties()

            EnableOrDisableColumns()

        End Sub
        Private Sub DataGridViewForm_Items_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Items.CellValueChangedEvent

            Dim FieldNameValue As Integer = 0

            If e.Column.FieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString Then

                FieldNameValue = CInt(DataGridViewForm_Items.CurrentView.GetRowCellValue(DataGridViewForm_Items.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString))

                Select Case _ImportTemplateType

                    Case ImportTemplateTypes.AccountsPayable_Generic

                        If DirectCast(FieldNameValue, AdvantageFramework.Importing.AccountPayableImportColumns).ToString <> Importing.AccountPayableImportColumns.InvoiceDate.ToString AndAlso _
                                DirectCast(FieldNameValue, AdvantageFramework.Importing.AccountPayableImportColumns).ToString <> Importing.AccountPayableImportColumns.LineDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.AccountsReceivable_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties).ToString <> AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.InvoiceDate.ToString AndAlso _
                                DirectCast(FieldNameValue, AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties).ToString <> AdvantageFramework.AccountReceivable.Classes.ImportAccountReceivableStaging.Properties.DueDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.ClearedChecks_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportClearedChecksStaging.Properties.CheckClearedDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.CashReceipt_Generic

                        If DirectCast(FieldNameValue, AdvantageFramework.Importing.CashReceiptImportColumns).ToString <> Importing.CashReceiptImportColumns.CheckDate.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Importing.CashReceiptImportColumns).ToString <> Importing.CashReceiptImportColumns.DepositDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.PTO_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportPTOStaging.Properties).ToString <> Database.Entities.ImportPTOStaging.Properties.ActivityDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.JournalEntry_Default

                        If DirectCast(FieldNameValue, AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties).ToString <> AdvantageFramework.GeneralLedger.Classes.ImportJournalEntry.Properties.TransactionDate.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                    Case ImportTemplateTypes.Employee_Hours

                        If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateFrom.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateTo.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateFrom.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateTo.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateFrom.ToString AndAlso
                                DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateTo.ToString Then

                            DataGridViewForm_Items.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString, Nothing)

                        End If

                End Select

            End If

        End Sub
        Private Sub DataGridViewForm_Items_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Items.ShowingEditorEvent

            'objects
            Dim Cancel As Boolean = False
            Dim FocusToFieldName As String = Nothing
            Dim FieldNameValue As Integer = 0

            Select Case DataGridViewForm_Items.CurrentView.FocusedColumn.FieldName

                Case AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVField.ToString

                    Cancel = True
                    FocusToFieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString

                Case AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVPosition.ToString

                    Cancel = _CSVPositionDisabled
                    FocusToFieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString

                Case AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString

                    Cancel = _FieldNameDisabled
                    FocusToFieldName = AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.CSVPosition.ToString

                Case AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.DateFormat.ToString

                    FieldNameValue = CInt(DataGridViewForm_Items.CurrentView.GetRowCellValue(DataGridViewForm_Items.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ImportTemplateDetailCSV.Properties.FieldName.ToString))

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

                        Case ImportTemplateTypes.DigitalResults_Default

                            If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportDigitalResultsStaging.Properties.ResultDate.ToString Then

                                Cancel = True

                            End If

                        Case ImportTemplateTypes.CashReceipt_Generic

                            If DirectCast(FieldNameValue, AdvantageFramework.Importing.CashReceiptImportColumns).ToString <> Importing.CashReceiptImportColumns.CheckDate.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Importing.CashReceiptImportColumns).ToString <> Importing.CashReceiptImportColumns.DepositDate.ToString Then

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

                        Case ImportTemplateTypes.Employee_Hours

                            If DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateFrom.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.PersonalHoursDateTo.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateFrom.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.SickDateTo.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateFrom.ToString AndAlso
                                    DirectCast(FieldNameValue, AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties).ToString <> AdvantageFramework.Database.Entities.ImportEmployeeHoursStaging.Properties.VacationDateTo.ToString Then

                                Cancel = True

                            End If

                        Case Else

                            Cancel = True
                          
                    End Select

            End Select

            e.Cancel = Cancel

            If Cancel AndAlso FocusToFieldName IsNot Nothing Then

                Try

                    DataGridViewForm_Items.CurrentView.FocusedColumn = DataGridViewForm_Items.CurrentView.Columns(FocusToFieldName)

                Catch ex As Exception

                End Try

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