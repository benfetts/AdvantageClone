Namespace Maintenance.Accounting.Presentation

    Public Class VendorReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedVendorCodes() As String = Nothing
        Private _AvailableVendorCodes() As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal AvailableVendorCodes() As String, ByVal SelectedVendorCodes() As String)

            ' This call is required by the designer.
            InitializeComponent()

            _SelectedVendorCodes = SelectedVendorCodes
            _AvailableVendorCodes = AvailableVendorCodes

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Classes.Vendor) = Nothing
            Dim NielsenTVStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing
            Dim NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing

            If Me.Session.IsNielsenSetup Then

                Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    NielsenTVStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                            Where Entity.SourceType = "B"
                                            Select Entity).ToList

                    NielsenRadioStationList = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen).ToList

                End Using

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Vendors = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, Me.Session).Include("Office").Include("Market")
                           Select Vendor.Code,
                                  Vendor.Name,
                                  [VendorType] = Vendor.VendorCategory,
                                  [Office] = If(Vendor.Office Is Nothing, "", Vendor.Office.Code + " - " + Vendor.Office.Name),
                                  Vendor.DefaultAPAccount,
                                  [Market] = If(Vendor.Market Is Nothing, "", Vendor.Market.Code + " - " + Vendor.Market.Description),
                                  [VendorCity] = Vendor.City,
                                  [VendorState] = Vendor.State,
                                  [ActiveFlag] = Vendor.ActiveFlag,
                                  [IsCableSystem] = Vendor.IsCableSystem,
                                  [NielsenRadioStationComboID] = Vendor.NielsenRadioStationComboID,
                                  [NielsenTVStationCode] = Vendor.NielsenTVStationCode).ToList _
                           .Select(Function(Vendor) New AdvantageFramework.Database.Classes.Vendor With {.Code = Vendor.Code,
                                                                                                         .Name = Vendor.Name,
                                                                                                         .VendorType = Vendor.VendorType,
                                                                                                         .Office = Vendor.Office,
                                                                                                         .DefaultAPAccount = Vendor.DefaultAPAccount,
                                                                                                         .Market = Vendor.Market,
                                                                                                         .VendorCity = Vendor.VendorCity,
                                                                                                         .VendorState = Vendor.VendorState,
                                                                                                         .IsCableSystem = Vendor.IsCableSystem,
                                                                                                         .CallLetters = If(Vendor.NielsenTVStationCode IsNot Nothing AndAlso
                                                                                                                           NielsenTVStationList IsNot Nothing AndAlso
                                                                                                                           NielsenTVStationList.Count > 0 AndAlso
                                                                                                                           NielsenTVStationList.Where(Function(E) E.StationCode = Vendor.NielsenTVStationCode).Any, NielsenTVStationList.Where(Function(E) E.StationCode = Vendor.NielsenTVStationCode).FirstOrDefault.CallLetters,
                                                                                                                        If(Vendor.NielsenRadioStationComboID IsNot Nothing AndAlso
                                                                                                                           NielsenRadioStationList IsNot Nothing AndAlso
                                                                                                                           NielsenRadioStationList.Count > 0 AndAlso
                                                                                                                           NielsenRadioStationList.Where(Function(E) E.ComboID = Vendor.NielsenRadioStationComboID).Any, NielsenRadioStationList.Where(Function(E) E.ComboID = Vendor.NielsenRadioStationComboID).FirstOrDefault.Name, "")),
                                                                                                         .IsInactive = Not CBool(Vendor.ActiveFlag.GetValueOrDefault(0))}).ToList

                If _AvailableVendorCodes IsNot Nothing Then

                    DataGridViewForm_Vendors.DataSource = (From Vendor In Vendors
                                                           Where _AvailableVendorCodes.Contains(Vendor.Code)
                                                           Select Vendor).ToList

                Else

                    DataGridViewForm_Vendors.DataSource = Vendors

                End If

            End Using

            DataGridViewForm_Vendors.CurrentView.BestFitColumns()

        End Sub
        Private Sub SelectGridRows()

            If _SelectedVendorCodes IsNot Nothing Then

                DataGridViewForm_Vendors.CurrentView.BeginSelection()

                DataGridViewForm_Vendors.CurrentView.ClearSelection()

                For Each VendorCode In _SelectedVendorCodes

                    DataGridViewForm_Vendors.SelectRow(0, VendorCode, False)

                Next

            End If

        End Sub
        Private Sub LoadReports()

            'objects
            Dim ReportList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Report) = Nothing
            Dim Report As AdvantageFramework.Security.Database.Entities.Report = Nothing
            Dim DoesUserHaveAccessVendorMaintenance As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ReportList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Report)

                DoesUserHaveAccessVendorMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Me.Session.Application, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString, Me.Session.User.ID)

                For Each Report In AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 103).ToList

                    If DoesUserHaveAccessVendorMaintenance OrElse AdvantageFramework.Security.DoesUserHaveAccessToReport(Me.Session, Report.Code) Then

                        ReportList.Add(Report)

                    End If

                Next

                ListBoxForm_Reports.DataSource = ReportList

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal AvailableVendorCodes() As String = Nothing, Optional ByVal SelectedVendorCodes() As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorReportsDialog As AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog = Nothing

            VendorReportsDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorReportsDialog(AvailableVendorCodes, SelectedVendorCodes)

            ShowFormDialog = VendorReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ' Objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            DateTimePickerVendorHistory_DateFrom.Value = Now
            DateTimePickerVendorHistory_DateTo.Value = Now

            RadioButtonControlSortBy_VendorCode.Checked = True
            ListBoxForm_Reports.SelectionMode = Windows.Forms.SelectionMode.One
            PanelForm_VendorHistoryPrintOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder

            Try

                LoadReports()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            DataGridViewForm_Vendors.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim VendorList As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim DateFrom As System.DateTime = Nothing
            Dim DateTo As System.DateTime = Nothing
            Dim VendorHistoryList As Generic.List(Of AdvantageFramework.Database.Entities.VendorHistory) = Nothing
            Dim VendorCodes As String() = Nothing
            Dim VendorContractList As Generic.List(Of AdvantageFramework.Database.Entities.VendorContract) = Nothing
			Dim UserCode As String = String.Empty

			If Me.Validator Then

                If DataGridViewForm_Vendors.HasASelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        VendorCodes = (From Entity In DataGridViewForm_Vendors.GetAllSelectedRowsBookmarkValues().OfType(Of String)()
                                       Select Entity).ToArray

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        Select Case ListBoxForm_Reports.SelectedValue

                            Case "d_vendor_list_det_rpt"

                                ReportType = Reporting.ReportTypes.VendorDetail

                            Case "d_vendor_list_cont_rpt"

                                ReportType = Reporting.ReportTypes.VendorDetailVendorContacts

                            Case "d_vendor_list_media_rpt"

                                ReportType = Reporting.ReportTypes.VendorDetailMedia

                            Case "d_vendor_list_production_rpt"

                                ReportType = Reporting.ReportTypes.VendorDetailProduction

                            Case "d_vendor_list_sum1_rpt"

                                ReportType = Reporting.ReportTypes.VendorSummaryVendorList

                            Case "d_vendor_list_sum2_rpt"

                                ReportType = Reporting.ReportTypes.VendorSummaryVendorListWithPayToEEOC

                            Case "d_vendor_history_rpt"

                                ReportType = Reporting.ReportTypes.VendorHistoryReport

                            Case "Vendor Contract"

                                ReportType = Reporting.ReportTypes.VendorContract

                        End Select

                        If ReportType <> Reporting.ReportTypes.VendorHistoryReport Then

                            If RadioButtonControlSortBy_VendorCode.Checked Then

                                VendorList = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                              Where VendorCodes.Contains(Entity.Code)
                                              Select Entity
                                              Order By Entity.Code).ToList

                                ParameterList.Add("SortedBy", "Sorted by Vendor")

                            ElseIf RadioButtonControlSortBy_CategoryVendorCode.Checked Then

                                VendorList = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                              Where VendorCodes.Contains(Entity.Code)
                                              Select Entity
                                              Order By Entity.VendorCategory, Entity.Code).ToList

                                ParameterList.Add("SortedBy", "Sorted by Category")

                            ElseIf RadioButtonControlSortBy_OfficeVendorCode.Checked Then

                                VendorList = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                              Where VendorCodes.Contains(Entity.Code)
                                              Select Entity
                                              Order By Entity.OfficeCode, Entity.Code).ToList

                                ParameterList.Add("SortedBy", "Sorted by Office")

                            End If

                            If VendorList IsNot Nothing AndAlso VendorList.Count > 0 Then

                                If ReportType = Reporting.ReportTypes.VendorContract Then

                                    VendorContractList = (From Item In DbContext.VendorContracts.Include("VendorContractContacts").Include("VendorContractDocuments")
                                                          Where VendorCodes.Contains(Item.VendorCode)
                                                          Select Item).ToList

                                    If RadioButtonControlSortBy_VendorCode.Checked Then

                                        VendorContractList = (From Item In VendorContractList
                                                              Join Vendor In VendorList On Item.VendorCode Equals Vendor.Code
                                                              Select Item
                                                              Order By Item.Code).ToList

                                    ElseIf RadioButtonControlSortBy_CategoryVendorCode.Checked Then

                                        VendorContractList = (From Item In VendorContractList
                                                              Join Vendor In VendorList On Item.VendorCode Equals Vendor.Code
                                                              Order By Vendor.VendorCategory, Item.Code
                                                              Select Item).ToList

                                    ElseIf RadioButtonControlSortBy_OfficeVendorCode.Checked Then

                                        VendorContractList = (From Item In VendorContractList
                                                              Join Vendor In VendorList On Item.VendorCode Equals Vendor.Code
                                                              Order By Vendor.OfficeCode, Item.Code
                                                              Select Item).ToList

                                    End If

                                    If VendorContractList IsNot Nothing AndAlso VendorContractList.Count > 0 Then

                                        ParameterList.Add("DataSource", VendorContractList)

                                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                Else

                                    ParameterList.Add("DataSource", VendorList)

                                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                End If

                            End If

                        Else

                            DateFrom = DateTimePickerVendorHistory_DateFrom.Value
							DateTo = CDate(DateTimePickerVendorHistory_DateTo.Value.ToShortDateString & " 23:59:59")

							If String.IsNullOrWhiteSpace(TextBoxVendorHistory_User.Text) = False Then

								UserCode = TextBoxVendorHistory_User.Text.ToUpper

							End If

							Try

								VendorHistoryList = (From Entity In AdvantageFramework.Database.Procedures.VendorHistory.Load(DbContext)
													 Where Entity.Date >= DateFrom AndAlso
														   Entity.Date <= DateTo AndAlso
														   Entity.User = If(UserCode <> "", UserCode, Entity.User) AndAlso
														   VendorCodes.Contains(Entity.Code) = True AndAlso
														   ((Entity.Action = "NEW" AndAlso CheckBoxVendorHistory_NewRecordsOnly.Checked) OrElse
														   (Not CheckBoxVendorHistory_NewRecordsOnly.Checked))
													 Select Entity).ToList

							Catch ex As Exception
                                VendorHistoryList = Nothing
                            End Try

                            If VendorHistoryList Is Nothing OrElse VendorHistoryList.Count = 0 Then

                                AdvantageFramework.Navigation.ShowMessageBox("There is no history for the search criteria.")

                            Else

                                If CheckBoxForm_Export.Checked Then

                                    DataGridViewForm_Export.DataSource = VendorHistoryList

                                    DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Vendor History Dataset")

                                Else

                                    ParameterList.Add("DataSource", VendorHistoryList)

                                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                                End If

                            End If

                        End If

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one vendor.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ListBoxForm_Reports_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ListBoxForm_Reports.SelectedValueChanged

            If ListBoxForm_Reports.SelectedValue = "d_vendor_history_rpt" Then

                PanelForm_VendorHistoryPrintOptions.Visible = True
                PanelForm_PrintOptions.Visible = False

            Else

                PanelForm_VendorHistoryPrintOptions.Visible = False
                PanelForm_PrintOptions.Visible = True

            End If

            DateTimePickerVendorHistory_DateFrom.SetRequired(PanelForm_VendorHistoryPrintOptions.Visible)
            DateTimePickerVendorHistory_DateTo.SetRequired(PanelForm_VendorHistoryPrintOptions.Visible)

        End Sub

#End Region

#End Region

    End Class

End Namespace