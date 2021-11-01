Namespace Maintenance.Reports.Presentation

    Public Class MaintenanceReports

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
        Private Sub LoadReports()

            Dim ReportList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Report) = Nothing

            ReportList = AdvantageFramework.Reporting.LoadAvailableReportsByReportType(Me.Session, 1)

            If ReportList.Count > 0 Then

                ListBoxLeftSection_Reports.DataSource = ReportList

                ListBoxLeftSection_Reports.AutoSizeInLayoutControl = True

            End If

        End Sub
        Private Sub LoadDivisions()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Divisions"

                    DataGridViewLeftSection_AvailableSelections.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                              Where Entity.IsActive = 1 AndAlso Entity.Client.IsActive = 1
                                                                              Select Entity).ToList

                    DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadOfficeDefaults()

            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

                    DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Office Defaults"

                    DataGridViewLeftSection_AvailableSelections.DataSource = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                    DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub LoadOfficeSalesClassDefaults()

            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim OfficeSalesClassAccounts As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassAccount) = Nothing
            Dim OfficeSalesClassList As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassAccount) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

                    EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode).ToList

                    OfficeSalesClassAccounts = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Load(DbContext).ToList

                    OfficeSalesClassList = New Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesClassAccount)

                    For Each EmployeeOffice In EmployeeOffices

                        For Each OfficeSalesClass In OfficeSalesClassAccounts

                            If EmployeeOffice.OfficeCode = OfficeSalesClass.OfficeCode Then
                                OfficeSalesClassList.Add(OfficeSalesClass)
                            End If

                        Next

                    Next

                End Using

                DataGridViewLeftSection_AvailableSelections.DataSource = OfficeSalesClassList

                DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Office Sales Class Defaults"

                DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadOfficeTaxDefaults()

            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim EmployeeOffices As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim OfficeSalesTaxAccounts As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) = Nothing
            Dim OfficeSalesTaxList As Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesTaxAccount) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

                    EmployeeOffices = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, User.EmployeeCode).ToList

                    OfficeSalesTaxAccounts = AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.Load(DbContext).ToList

                    OfficeSalesTaxList = New Generic.List(Of AdvantageFramework.Database.Entities.OfficeSalesTaxAccount)

                    For Each EmployeeOffice In EmployeeOffices

                        For Each OfficeSalesTax In OfficeSalesTaxAccounts

                            If EmployeeOffice.OfficeCode = OfficeSalesTax.OfficeCode Then
                                OfficeSalesTaxList.Add(OfficeSalesTax)
                            End If

                        Next

                    Next

                End Using

                DataGridViewLeftSection_AvailableSelections.DataSource = OfficeSalesTaxList

                DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Office Sales Tax Defaults"

                DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadProducts()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Products"

                    DataGridViewLeftSection_AvailableSelections.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode, False)
                                                                              Where Entity.IsActive = 1 AndAlso Entity.Client.IsActive = 1 AndAlso Entity.Division.IsActive = 1
                                                                              Select Entity).ToList

                    DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MaintenanceReports As AdvantageFramework.Maintenance.Reports.Presentation.MaintenanceReports = Nothing

            MaintenanceReports = New AdvantageFramework.Maintenance.Reports.Presentation.MaintenanceReports

            MaintenanceReports.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MaintenanceReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.PrintImage

            RibbonBarOptions_ReportBy.Visible = False

            ListBoxLeftSection_Reports.SelectionMode = Windows.Forms.SelectionMode.One

            DataGridViewLeftSection_AvailableSelections.ShowSelectDeselectAllButtons = True

            LoadReports()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ListBoxLeftSection_Reports_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxLeftSection_Reports.SelectedIndexChanged

            Static PreviousValueWasBank As Boolean

            Me.ShowWaitForm("Processing...")

            DataGridViewLeftSection_AvailableSelections.DataSource = Nothing
            DataGridViewLeftSection_AvailableSelections.Columns.Clear()

            If ListBoxLeftSection_Reports.SelectedValue = "BANK.QRP" Then
                RibbonBarOptions_ReportBy.Visible = False
                PanelForm_RightSection.Visible = False
                PreviousValueWasBank = True
            Else
                RibbonBarOptions_ReportBy.Visible = True
                If PreviousValueWasBank Then
                    ButtonItemReportBy_All.Checked = True
                    PanelForm_RightSection.Visible = False
                    PreviousValueWasBank = False
                End If
            End If

            Select Case ListBoxLeftSection_Reports.SelectedValue

                Case "CLIENT.QRP"
                    DataGridViewLeftSection_AvailableSelections.ItemDescription = "Available Clients"

                    DataGridViewLeftSection_AvailableSelections.DataSource = AdvantageFramework.Reporting.LoadReportCriteria(Me.Session)

                    DataGridViewLeftSection_AvailableSelections.CurrentView.BestFitColumns()


                Case "DIVISION.QRP"
                    LoadDivisions()

                Case "OFFDFLTS.QRP"
                    LoadOfficeDefaults()

                Case "OFFSLSCL.QRP"
                    LoadOfficeSalesClassDefaults()

                Case "OFFTAX.QRP"
                    LoadOfficeTaxDefaults()

                Case "PRODLONG.QRP", "PRODS.QRP"
                    LoadProducts()

            End Select

            Me.CloseWaitForm()

        End Sub

        Private Sub ButtonItemActions_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Print.Click

            Dim ReportType As Reporting.ReportTypes = Nothing

            Dim BankList As Generic.List(Of AdvantageFramework.Database.Entities.Bank) = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing

            ParameterList = New Generic.Dictionary(Of String, Object)

            Select Case ListBoxLeftSection_Reports.SelectedValue

                Case "BANK.QRP"

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        BankList = (From Entity In AdvantageFramework.Database.Procedures.Bank.Load(DbContext).Include("GeneralLedgerAccount5").Include("GeneralLedgerAccount7")
                                    Select Entity).ToList

                    End Using

                    If BankList IsNot Nothing Then

                        ParameterList.Add("DataSource", BankList)

                    End If

                    ReportType = Reporting.ReportTypes.BankReport

                Case "CLIENT.QRP"

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientList = (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
                                      Select Entity).ToList

                    End Using

                    If ClientList IsNot Nothing Then

                        ParameterList.Add("DataSource", ClientList)

                    End If

                    ReportType = Reporting.ReportTypes.ClientReport

                Case "DIVISION.QRP"

                Case "OFFDFLTS.QRP"

                Case "OFFSLSCL.QRP"

                Case "OFFTAX.QRP"

                Case "PRODLONG.QRP"

                Case "PRODS.QRP"


            End Select

            If ParameterList.Count > 0 Then

                If AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub

        Private Sub ButtonItemReportBy_All_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemReportBy_All.Click

            PanelForm_RightSection.Visible = False

        End Sub

        Private Sub ButtonItemReportBy_List_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemReportBy_List.Click

            PanelForm_RightSection.Visible = True

        End Sub

#End Region

#End Region

    End Class

End Namespace