Namespace Desktop.Presentation

    Public Class UserDefinedReportEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportType As AdvantageFramework.Reporting.UDRTypes = Reporting.UDRTypes.Advanced
        Private _ReportID As Integer = 0
        Private _Type As Integer = 0
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = 0

#End Region

#Region " Properties "

        Private ReadOnly Property Type As Integer
            Get
                Type = _Type
            End Get
        End Property
        Private ReadOnly Property Description As String
            Get
                Description = _Description
            End Get
        End Property
        Private ReadOnly Property UserDefinedReportCategoryID As Nullable(Of Integer)
            Get
                UserDefinedReportCategoryID = _UserDefinedReportCategoryID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal UserDefinedReportType As AdvantageFramework.Reporting.UDRTypes, ByVal ReportID As Integer, ByVal Type As Integer, ByRef Description As String, ByRef UserDefinedReportCategoryID As Nullable(Of Integer), ByVal AllowReportTypeChange As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _UserDefinedReportType = UserDefinedReportType
            _ReportID = ReportID
            _Type = Type
            _Description = Description
            _UserDefinedReportCategoryID = UserDefinedReportCategoryID
            ComboBoxForm_ReportType.Enabled = AllowReportTypeChange

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal UserDefinedReportType As AdvantageFramework.Reporting.UDRTypes, ByVal ReportID As Integer, ByRef Type As Integer, ByRef Description As String, ByRef UserDefinedReportCategoryID As Nullable(Of Integer), ByVal AllowReportTypeChange As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim UserDefinedReportEditDialog As AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog = Nothing

            UserDefinedReportEditDialog = New AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog(UserDefinedReportType, ReportID, Type, Description, UserDefinedReportCategoryID, AllowReportTypeChange)

            ShowFormDialog = UserDefinedReportEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                Type = UserDefinedReportEditDialog.Type
                Description = UserDefinedReportEditDialog.Description
                UserDefinedReportCategoryID = UserDefinedReportEditDialog.UserDefinedReportCategoryID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub UserDefinedReportEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim EstimateReport As AdvantageFramework.Reporting.Database.Entities.EstimateReport = Nothing
            Dim CustomInvoice As AdvantageFramework.Reporting.Database.Entities.CustomInvoice = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _UserDefinedReportType = Reporting.UDRTypes.Advanced Then

                    ComboBoxForm_ReportType.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.UserDefinedReport.Properties.AdvancedReportWriterType)
                    ComboBoxForm_ReportType.DataSource = AdvantageFramework.Reporting.LoadAvailableAdvancedReportWriterDataSets(Me.Session)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.UserDefinedReport.Properties.Description)

                ElseIf _UserDefinedReportType = Reporting.UDRTypes.Dynamic Then

                    ComboBoxForm_ReportType.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Type)
                    ComboBoxForm_ReportType.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReportDataSets(Me.Session)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Description)

                ElseIf _UserDefinedReportType = Reporting.UDRTypes.Estimate Then

                    ComboBoxForm_ReportType.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.EstimateReport.Properties.EstimateReportType)
                    ComboBoxForm_ReportType.DataSource = AdvantageFramework.Estimate.Printing.LoadAvailableEstimateReports(Me.Session)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.EstimateReport.Properties.Description)

                ElseIf _UserDefinedReportType = Reporting.UDRTypes.Invoice Then

                    ComboBoxForm_ReportType.SetRequired(AdvantageFramework.Reporting.Database.Entities.CustomInvoice.Properties.Type)
                    ComboBoxForm_ReportType.DataSource = AdvantageFramework.InvoicePrinting.LoadAvailableInvoices

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.CustomInvoice.Properties.Description)

                    ComboBoxForm_ReportCategory.SecurityEnabled = False

                End If

                ComboBoxForm_ReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).OrderBy(Function(c) c.Description).ToList

                If _ReportID <> 0 Then

                    ButtonForm_Add.Visible = False
                    ButtonForm_Update.Visible = True

                    If _UserDefinedReportType = Reporting.UDRTypes.Advanced Then

                        UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, _ReportID)

                        If UserDefinedReport IsNot Nothing Then

                            ComboBoxForm_ReportType.SelectedValue = CLng(UserDefinedReport.AdvancedReportWriterType)
                            TextBoxForm_Description.Text = UserDefinedReport.Description
                            ComboBoxForm_ReportCategory.SelectedValue = UserDefinedReport.UserDefinedReportCategoryID.GetValueOrDefault(0)

                        End If

                    ElseIf _UserDefinedReportType = Reporting.UDRTypes.Dynamic Then

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _ReportID)

                        If DynamicReport IsNot Nothing Then

                            ComboBoxForm_ReportType.SelectedValue = CLng(DynamicReport.Type)
                            TextBoxForm_Description.Text = DynamicReport.Description
                            ComboBoxForm_ReportCategory.SelectedValue = DynamicReport.UserDefinedReportCategoryID.GetValueOrDefault(0)

                        End If

                    ElseIf _UserDefinedReportType = Reporting.UDRTypes.Estimate Then

                        EstimateReport = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadByEstimateReportID(ReportingDbContext, _ReportID)

                        If EstimateReport IsNot Nothing Then

                            ComboBoxForm_ReportType.SelectedValue = CLng(EstimateReport.EstimateReportType)
                            TextBoxForm_Description.Text = EstimateReport.Description
                            ComboBoxForm_ReportCategory.SelectedValue = EstimateReport.EstimateReportCategoryID.GetValueOrDefault(0)

                        End If

                    ElseIf _UserDefinedReportType = Reporting.UDRTypes.Invoice Then

                        CustomInvoice = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadByCustomInvoiceID(ReportingDbContext, _ReportID)

                        If CustomInvoice IsNot Nothing Then

                            ComboBoxForm_ReportType.SelectedValue = CLng(CustomInvoice.Type)
                            TextBoxForm_Description.Text = CustomInvoice.Description
                            ComboBoxForm_ReportCategory.SelectedValue = 0

                        End If

                    End If

                    If UserDefinedReport Is Nothing AndAlso DynamicReport Is Nothing AndAlso EstimateReport Is Nothing AndAlso CustomInvoice Is Nothing Then

                        AdvantageFramework.WinForm.MessageBox.Show("The report you are trying to edit does not exist anymore.")
                        Me.Close()

                    End If

                Else

                    ComboBoxForm_ReportType.SelectedValue = CLng(_Type)

                    ButtonForm_Add.Visible = True
                    ButtonForm_Update.Visible = False

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    _Type = ComboBoxForm_ReportType.GetSelectedValue
                    _Description = TextBoxForm_Description.Text
                    _UserDefinedReportCategoryID = ComboBoxForm_ReportCategory.GetSelectedValue

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    _Type = ComboBoxForm_ReportType.GetSelectedValue
                    _Description = TextBoxForm_Description.Text
                    _UserDefinedReportCategoryID = ComboBoxForm_ReportCategory.GetSelectedValue

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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

#End Region

#End Region

    End Class

End Namespace