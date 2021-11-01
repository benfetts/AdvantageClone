Namespace Exporting.Presentation

    Public Class ExportYayPayInvoicesForm

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

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ExportYayPayInvoicesForm As AdvantageFramework.Exporting.Presentation.ExportYayPayInvoicesForm = Nothing

            ExportYayPayInvoicesForm = New AdvantageFramework.Exporting.Presentation.ExportYayPayInvoicesForm()

            ExportYayPayInvoicesForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportYayPayInvoicesForm_Load(sender As Object, e As EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            TextBoxForm_Folder.SetRequired(True)

            TextBoxForm_Folder.Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            Dim ErrorMessage As String = String.Empty
            Dim Folder As String = String.Empty
            Dim YayPayInvoiceWithPaymentsAlt As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPaymentsAlt = Nothing
            Dim InvoiceWithPaymentsExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceWithPaymentsDataTable As System.Data.DataTable = Nothing
            Dim InvoiceWithPaymentsFile As String = String.Empty
            Dim InvoiceWithPaymentsFileCreated As Boolean = False
            Dim YayPayInvoiceTransactionAlt As AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAlt = Nothing
            Dim InvoiceTransactionExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim InvoiceTransactionDataTable As System.Data.DataTable = Nothing
            Dim InvoiceTransactionFile As String = String.Empty
            Dim InvoiceTransactionFileCreated As Boolean = False

            If Me.Validator Then

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(TextBoxForm_Folder.Text, "\")

                If My.Computer.FileSystem.DirectoryExists(Folder) Then

                    Me.ShowOverlayWithDefaultImage()

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Try

                            YayPayInvoiceWithPaymentsAlt = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceWithPaymentsAlt(Me.Session.UserCode, "202104", Now, 1, True, 0)

                            InvoiceWithPaymentsExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments)
                                                                 Where Entity.IsSystemTemplate = True
                                                                 Select Entity).SingleOrDefault

                            If InvoiceWithPaymentsExportTemplate IsNot Nothing Then

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                    If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments,
                                                                                                           InvoiceWithPaymentsExportTemplate.ID, YayPayInvoiceWithPaymentsAlt, InvoiceWithPaymentsDataTable) Then

                                        InvoiceWithPaymentsFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceWithPayments,
                                                                                                                                       InvoiceWithPaymentsExportTemplate.ID, Folder, YayPayInvoiceWithPaymentsAlt,
                                                                                                                                       InvoiceWithPaymentsDataTable, InvoiceWithPaymentsFile)

                                    End If

                                End Using

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            YayPayInvoiceTransactionAlt = New AdvantageFramework.Exporting.DataFilterClasses.YayPayInvoiceTransactionAlt(CDate("01/01/1950"), Now)

                            InvoiceTransactionExportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions)
                                                                Where Entity.IsSystemTemplate = True
                                                                Select Entity).SingleOrDefault

                            If InvoiceTransactionExportTemplate IsNot Nothing Then

                                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                    If AdvantageFramework.Exporting.CreateExportDataSourceByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions,
                                                                                                           InvoiceTransactionExportTemplate.ID, YayPayInvoiceTransactionAlt, InvoiceTransactionDataTable) Then

                                        InvoiceTransactionFileCreated = AdvantageFramework.Exporting.CreateExportFileByExportTemplate(DbContext, SecurityDbContext, AdvantageFramework.Exporting.ExportTypes.YayPayInvoiceTransactions,
                                                                                                                                      InvoiceTransactionExportTemplate.ID, Folder, YayPayInvoiceTransactionAlt,
                                                                                                                                      InvoiceTransactionDataTable, InvoiceTransactionFile)

                                    End If

                                End Using

                            End If

                        Catch ex As Exception

                        End Try

                    End Using

                    Me.CloseOverlay()

                    If InvoiceWithPaymentsFileCreated AndAlso InvoiceTransactionFileCreated Then

                        AdvantageFramework.WinForm.MessageBox.Show("File(s) has been create here:" & System.Environment.NewLine & System.Environment.NewLine & System.Environment.NewLine &
                                                                   InvoiceWithPaymentsFile & System.Environment.NewLine & InvoiceTransactionFile)

                        System.Windows.Forms.Application.Exit()

                    Else

                        If InvoiceWithPaymentsFileCreated = False AndAlso InvoiceTransactionFileCreated Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to create file: Invoices")

                        ElseIf InvoiceTransactionFileCreated = False AndAlso InvoiceWithPaymentsFileCreated Then

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to create file: Transactions")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed to create file: Invoices & Transactions")

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a valid folder location.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
