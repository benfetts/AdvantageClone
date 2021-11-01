Namespace Reporting.Presentation

    Public Class MediaCurrentStatusSummaryInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadVendors()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectVendors_Vendors.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext))

                DataGridViewSelectVendors_Vendors.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadMarkets()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectMarkets_Markets.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)

                DataGridViewSelectMarkets_Markets.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MediaCurrentStatusSummaryInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaCurrentStatusSummaryInitialLoadingDialog = Nothing

            MediaCurrentStatusSummaryInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaCurrentStatusSummaryInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = MediaCurrentStatusSummaryInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaCurrentStatusSummaryInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaCurrentStatusSummaryInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TabControlForm_MCS.SelectedTab = TabItemMCS_OptionsTab

            DateTimePickerNonDailyBroadcast_From.SetRequired(True)
            DateTimePickerNonDailyBroadcast_To.SetRequired(True)

            DateTimePickerNonDailyBroadcast_From.ButtonDropDown.Visible = True
            DateTimePickerNonDailyBroadcast_To.ButtonDropDown.Visible = True

            NumericInputMonthlyBroadcast_FromYear.SetRequired(True)
            NumericInputMonthlyBroadcast_ToYear.SetRequired(True)

            NumericInputMonthlyBroadcast_FromYear.Properties.MinValue = 1900
            NumericInputMonthlyBroadcast_ToYear.Properties.MinValue = 1900

            ComboBoxMonthlyBroadcast_FromMonth.SetRequired(True)
            ComboBoxMonthlyBroadcast_ToMonth.SetRequired(True)

            ComboBoxMonthlyBroadcast_FromMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxMonthlyBroadcast_ToMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

            CheckBoxMediaTypes_All.Checked = True

            Me.TabItemMCS_SelectVendorsTab.Visible = False
            Me.TabItemMCS_SelectMarketsTab.Visible = False

            If _ParameterDictionary IsNot Nothing Then

                Try

                    If _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.OrderStatus.ToString).ToString.ToUpper = "O" Then

                        RadioButtonInclude_OpenOnly.Checked = True

                    Else

                        RadioButtonInclude_OpenAndClosed.Checked = True

                    End If

                Catch ex As Exception
                    RadioButtonInclude_OpenOnly.Checked = True
                End Try

                Try

                    DateTimePickerNonDailyBroadcast_From.Value = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartDate.ToString)

                Catch ex As Exception
                    DateTimePickerNonDailyBroadcast_From.Value = Now
                End Try

                Try

                    ComboBoxMonthlyBroadcast_FromMonth.SelectedValue = CLng(_ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartMonth.ToString))

                Catch ex As Exception
                    ComboBoxMonthlyBroadcast_FromMonth.SelectedValue = CLng(Now.Month)
                End Try

                Try

                    NumericInputMonthlyBroadcast_FromYear.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartYear.ToString)

                Catch ex As Exception
                    NumericInputMonthlyBroadcast_FromYear.EditValue = Now.Year
                End Try

                Try

                    DateTimePickerNonDailyBroadcast_To.Value = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndDate.ToString)

                Catch ex As Exception
                    DateTimePickerNonDailyBroadcast_To.Value = Now
                End Try

                Try

                    ComboBoxMonthlyBroadcast_ToMonth.SelectedValue = CLng(_ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndMonth.ToString))

                Catch ex As Exception
                    ComboBoxMonthlyBroadcast_ToMonth.SelectedValue = CLng(Now.Month)
                End Try

                Try

                    NumericInputMonthlyBroadcast_ToYear.EditValue = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndYear.ToString)

                Catch ex As Exception
                    NumericInputMonthlyBroadcast_ToYear.EditValue = Now.Year
                End Try

                Try

                    CheckBoxMediaTypes_Internet.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeInternet.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_Internet.Checked = True
                End Try

                Try

                    CheckBoxMediaTypes_Magazine.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeMagazine.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_Magazine.Checked = True
                End Try

                Try

                    CheckBoxMediaTypes_Newspaper.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeNewspaper.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_Newspaper.Checked = True
                End Try

                Try

                    CheckBoxMediaTypes_OutOfHome.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeOutOfHome.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_OutOfHome.Checked = True
                End Try

                Try

                    CheckBoxMediaTypes_Radio.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeRadio.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_Radio.Checked = True
                End Try

                Try

                    CheckBoxMediaTypes_Television.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeTelevision.ToString)

                Catch ex As Exception
                    CheckBoxMediaTypes_Television.Checked = True
                End Try

                Try

                    CheckBoxBroadcastDates.Checked = _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.BroadcastDates.ToString)

                Catch ex As Exception
                    CheckBoxBroadcastDates.Checked = False
                End Try

            Else

                ComboBoxMonthlyBroadcast_FromMonth.SelectedValue = CLng(Now.Month)
                ComboBoxMonthlyBroadcast_ToMonth.SelectedValue = CLng(Now.Month)

                NumericInputMonthlyBroadcast_FromYear.EditValue = Now.Year
                NumericInputMonthlyBroadcast_ToYear.EditValue = Now.Year

                DateTimePickerNonDailyBroadcast_From.Value = Now
                DateTimePickerNonDailyBroadcast_To.Value = Now

            End If

        End Sub
        Private Sub MediaCurrentStatusSummaryInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim VendorCodesList As Generic.List(Of String) = Nothing
            Dim MarketCodesList As Generic.List(Of String) = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If RadioButtonInclude_OpenOnly.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.OrderStatus.ToString) = "O"

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.OrderStatus.ToString) = "A"

                End If

                If RadioButtonSelectOffices_AllOffices.Checked Then
                    _ParameterDictionary("SelectedOffices") = Nothing
                Else
                    _ParameterDictionary("SelectedOffices") = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If

                If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                    ClientCodeList = Nothing
                    DivisionCodeList = Nothing
                    ProductCodeList = Nothing

                Else

                    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                        ClientCodeList = SelectedCodesList
                        DivisionCodeList = Nothing
                        ProductCodeList = Nothing

                    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                        ClientCodeList = Nothing
                        DivisionCodeList = SelectedCodesList
                        ProductCodeList = Nothing

                    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                        ClientCodeList = Nothing
                        DivisionCodeList = Nothing
                        ProductCodeList = SelectedCodesList

                    End If

                End If

                _ParameterDictionary("SelectedClients") = ClientCodeList
                _ParameterDictionary("SelectedDivisions") = DivisionCodeList
                _ParameterDictionary("SelectedProducts") = ProductCodeList

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    VendorCodesList = DataGridViewSelectVendors_Vendors.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                End If

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    MarketCodesList = DataGridViewSelectMarkets_Markets.GetAllSelectedRowsBookmarkValues().OfType(Of String).ToList

                End If

                _ParameterDictionary("SelectedVendors") = VendorCodesList
                _ParameterDictionary("SelectedMarkets") = MarketCodesList

                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartDate.ToString) = DateTimePickerNonDailyBroadcast_From.Value
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartMonth.ToString) = ComboBoxMonthlyBroadcast_FromMonth.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartYear.ToString) = NumericInputMonthlyBroadcast_FromYear.EditValue
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndDate.ToString) = DateTimePickerNonDailyBroadcast_To.Value
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndMonth.ToString) = ComboBoxMonthlyBroadcast_ToMonth.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndYear.ToString) = NumericInputMonthlyBroadcast_ToYear.EditValue
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeInternet.ToString) = CheckBoxMediaTypes_Internet.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeMagazine.ToString) = CheckBoxMediaTypes_Magazine.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeNewspaper.ToString) = CheckBoxMediaTypes_Newspaper.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeOutOfHome.ToString) = CheckBoxMediaTypes_OutOfHome.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeRadio.ToString) = CheckBoxMediaTypes_Radio.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeTelevision.ToString) = CheckBoxMediaTypes_Television.Checked

                _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.BroadcastDates.ToString) = CheckBoxBroadcastDates.Checked

                Dim sStartDate As String, sEndDate As String
                Dim dStartDate As DateTime, dEndDate As DateTime
                sStartDate = ComboBoxMonthlyBroadcast_FromMonth.SelectedValue.ToString + "-01-" + NumericInputMonthlyBroadcast_FromYear.EditValue.ToString
                sEndDate = ComboBoxMonthlyBroadcast_ToMonth.SelectedValue.ToString + "-01-" + NumericInputMonthlyBroadcast_ToYear.EditValue.ToString
                dStartDate = sStartDate
                dEndDate = sEndDate
                dEndDate = dEndDate.AddMonths(1)
                dEndDate = dEndDate.AddDays(-1)

                If CheckBoxBroadcastDates.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString) = dStartDate
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString) = dEndDate
                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.MEDIA_RPT_ORDERS WHERE [USER_ID] = '{0}'", Me.Session.UserCode))

                End Using

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
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
        Private Sub CheckBoxMediaTypes_All_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_All.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                CheckBoxMediaTypes_Internet.Checked = CheckBoxMediaTypes_All.Checked
                CheckBoxMediaTypes_Magazine.Checked = CheckBoxMediaTypes_All.Checked
                CheckBoxMediaTypes_Newspaper.Checked = CheckBoxMediaTypes_All.Checked
                CheckBoxMediaTypes_OutOfHome.Checked = CheckBoxMediaTypes_All.Checked
                CheckBoxMediaTypes_Radio.Checked = CheckBoxMediaTypes_All.Checked
                CheckBoxMediaTypes_Television.Checked = CheckBoxMediaTypes_All.Checked

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_Internet_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_Internet.CheckedChanged

            If CheckBoxMediaTypes_Internet.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_Magazine_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_Magazine.CheckedChanged

            If CheckBoxMediaTypes_Magazine.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_Newspaper_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_Newspaper.CheckedChanged

            If CheckBoxMediaTypes_Newspaper.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_OutOfHome_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_OutOfHome.CheckedChanged

            If CheckBoxMediaTypes_OutOfHome.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_Radio_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_Radio.CheckedChanged

            If CheckBoxMediaTypes_Radio.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxMediaTypes_Television_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMediaTypes_Television.CheckedChanged

            If CheckBoxMediaTypes_Television.Checked = False Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying

                CheckBoxMediaTypes_All.Checked = False

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                End If

            End If

        End Sub

        Private Sub CheckBoxBroadcastDates_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxBroadcastDates.CheckedChanged
            If CheckBoxBroadcastDates.Checked = True Then
                LabelOptions_NonDailyBroadcast.Visible = False
                LabelNonDailyBroadcast_From.Visible = False
                LabelNonDailyBroadcast_To.Visible = False
                DateTimePickerNonDailyBroadcast_From.Visible = False
                DateTimePickerNonDailyBroadcast_To.Visible = False
            Else
                LabelOptions_NonDailyBroadcast.Visible = True
                LabelNonDailyBroadcast_From.Visible = True
                LabelNonDailyBroadcast_To.Visible = True
                DateTimePickerNonDailyBroadcast_From.Visible = True
                DateTimePickerNonDailyBroadcast_To.Visible = True
            End If
        End Sub

        Private Sub RadioButtonDates_Broadcast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_Broadcast.CheckedChanged
            If RadioButtonDates_Broadcast.Checked = True Then
                CheckBoxBroadcastDates.Checked = True
            End If
        End Sub

        Private Sub RadioButtonDates_Standard_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_Standard.CheckedChanged
            If RadioButtonDates_Standard.Checked = True Then
                CheckBoxBroadcastDates.Checked = False
            End If
        End Sub

        Private Sub RadioButtonSelectVendors_AllVendors_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectVendors_AllVendors.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectVendors_AllVendors.Checked Then

                    DataGridViewSelectVendors_Vendors.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectVendors_ChooseVendors_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectVendors_ChooseVendors.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    If DataGridViewSelectVendors_Vendors.HasRows = False Then

                        LoadVendors()

                    End If

                    DataGridViewSelectVendors_Vendors.Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectVendors_Vendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectVendors_Vendors.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectVendors_ChooseVendors.Checked Then

                    'ClearOrders()

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectMarkets_AllMarkets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectMarkets_AllMarkets.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectMarkets_AllMarkets.Checked Then

                    DataGridViewSelectMarkets_Markets.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectMarkets_ChooseMarkets_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectMarkets_ChooseMarkets.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    If DataGridViewSelectMarkets_Markets.HasRows = False Then

                        LoadMarkets()

                    End If

                    DataGridViewSelectMarkets_Markets.Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewSelectMarkets_Markets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSelectMarkets_Markets.SelectionChangedEvent

            If Me.FormShown Then

                If RadioButtonSelectMarkets_ChooseMarkets.Checked Then

                    'ClearOrders()

                End If

            End If

        End Sub


#End Region

#End Region

    End Class

End Namespace
