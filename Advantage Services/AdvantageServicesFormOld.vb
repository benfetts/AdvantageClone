Public Class AdvantageServicesFormOld

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    'Private _Initialized = False
    'Private _ObjectContext As AdvantageFramework.Database.DbContext = Nothing
    'Private _ExportSelectedDatabase As String = Nothing
    'Private _ExportCampaignIDColumnVisible As Boolean = False
    ''QvA Variables
    'Private _QvAAlertInitialized As Boolean = False
    'Private _QvAAlertLevel1Enabled As Boolean = False
    'Private _QvAAlertLevel1Start As Decimal = 0
    'Private _QvAAlertLevel1End As Decimal = 0
    'Private _QvAAlertLevel1Description As String = ""
    'Private _QvAAlertLevel2Enabled As Boolean = False
    'Private _QvAAlertLevel2Start As Decimal = 0
    'Private _QvAAlertLevel2End As Decimal = 0
    'Private _QvAAlertLevel2Description As String = ""
    'Private _QvAAlertLevel3Enabled As Boolean = False
    'Private _QvAAlertLevel3Start As Decimal = 0
    'Private _QvAAlertLevel3Description As String = ""
    'Private _SendAlertTo As Integer = -1
    'Private _SetAlertLevel As Integer = -1
    'Private _ShowLevel As Integer = -1
    ''Missing Time Variables
    'Private _LoadingDatabaseProfiles As Boolean = False
    'Private _LoadingServiceSettings As Boolean = False
    'Private _LoadingProcessSettings As Boolean = False
    'Private _SelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
    'Private _DisableITContact As Boolean = True
    ''Media Ocean Import Variables
    'Private _MOILoadingDatabaseProfiles As Boolean = False
    'Private _MOILoadingServiceSettings As Boolean = False
    'Private _MOISelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    '#Region "  Email Listener "

    '    Private Sub SetEmailListenerStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelEmailListener_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadEmailListenerSettings()

    '        AdvantageFramework.Services.EmailListener.LoadSettings(NumericInputEmailListenerSettings_RunAtEvery.EditValue, TextBoxEmailListenerSettings_StartofSignatureCode.Text)

    '        LoadEmailListenerDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadEmailListenerDatabaseProfiles()

    '        DataGridViewEmailListenerDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.EmailListener.LoadDatabaseProfiles

    '        ButtonEmailListenerDatabaseProfiles_Remove.Enabled = DataGridViewEmailListenerDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonEmailListenerDatabaseProfiles_Edit.Enabled = DataGridViewEmailListenerDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveEmailListenerAllSettings()

    '        SaveEmailListenerSettings()

    '        SaveEmailListenerDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveEmailListenerSettings()

    '        AdvantageFramework.Services.EmailListener.SaveSettings(NumericInputEmailListenerSettings_RunAtEvery.EditValue, TextBoxEmailListenerSettings_StartofSignatureCode.Text)

    '    End Sub
    '    Private Sub SaveEmailListenerDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewEmailListenerDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.EmailListener.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub EmailListenerEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetEmailListenerStatus(EventLogEntry.Message & "....")

    '    End Sub

    '#End Region

    '#Region "  QvA Alert "

    '    Private Sub SetQvAAlertStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelQvAAlert_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadQvAAlertAllSettings()

    '        LoadQvAAlertSettings()

    '        LoadQvAAlertDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadQvAAlertSettings()

    '        'AdvantageFramework.Services.QvAAlert.LoadSettings(DateTimeInputQvAAlertSettings_RunAt.EditValue, ComboBoxQvAAlertSettings_SendAlertTo.SelectedValue, _
    '        '                                                  CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue, TextBoxThresholds_Level1Description.Text, _
    '        '                                                  CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue, TextBoxThresholds_Level2Description.Text, _
    '        '                                                  CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, TextBoxThresholds_Level3Description.Text, _
    '        '                                                  CheckBoxCalculationOptions_Time.Checked, CheckBoxCalculationOptions_IncomeOnly.Checked, _
    '        '                                                  CheckBoxCalculationOptions_VendorCharges.Checked, CheckBoxCalculationOptions_IncludeEstimate.Checked, _
    '        '                                                  ComboBoxQvAAlertSettings_SetAlertLevel.SelectedValue, ComboBoxQvAAlertSettings_ShowLevel.SelectedValue)

    '        AdvantageFramework.Services.QvAAlert.LoadSettings(DateTimeInputQvAAlertSettings_RunAt.Value, _SendAlertTo, _
    '                                                          _QvAAlertLevel1Enabled, _QvAAlertLevel1Start, _QvAAlertLevel1End, _QvAAlertLevel1Description, _
    '                                                          _QvAAlertLevel2Enabled, _QvAAlertLevel2Start, _QvAAlertLevel2End, _QvAAlertLevel2Description, _
    '                                                          _QvAAlertLevel3Enabled, _QvAAlertLevel3Start, _QvAAlertLevel3Description, _
    '                                                          CheckBoxCalculationOptions_Time.Checked, CheckBoxCalculationOptions_IncomeOnly.Checked, _
    '                                                          CheckBoxCalculationOptions_VendorCharges.Checked, CheckBoxCalculationOptions_IncludeEstimate.Checked, _
    '                                                          _SetAlertLevel, _ShowLevel)

    '    End Sub
    '    Private Sub LoadQvAAlertDatabaseProfiles()

    '        DataGridViewQvAAlertDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.QvAAlert.LoadDatabaseProfiles

    '        ButtonQvAAlertDatabaseProfiles_Remove.Enabled = DataGridViewQvAAlertDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonQvAAlertDatabaseProfiles_Edit.Enabled = DataGridViewQvAAlertDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveQvAAlertAllSettings()

    '        SaveQvAAlertSettings()

    '        SaveQvAAlertDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveQvAAlertSettings()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        If (_QvAAlertInitialized) Then

    '            AdvantageFramework.Services.QvAAlert.SaveSettings(DateTimeInputQvAAlertSettings_RunAt.Value, _SendAlertTo, _
    '                                                              _QvAAlertLevel1Enabled, _QvAAlertLevel1Start, _QvAAlertLevel1End, _QvAAlertLevel1Description, _
    '                                                              _QvAAlertLevel2Enabled, _QvAAlertLevel2Start, _QvAAlertLevel2End, _QvAAlertLevel2Description, _
    '                                                              _QvAAlertLevel3Enabled, _QvAAlertLevel3Start, _QvAAlertLevel3Description, _
    '                                                              CheckBoxCalculationOptions_Time.Checked, CheckBoxCalculationOptions_IncomeOnly.Checked, _
    '                                                              CheckBoxCalculationOptions_VendorCharges.Checked, CheckBoxCalculationOptions_IncludeEstimate.Checked, _
    '                                                              _SetAlertLevel, _ShowLevel)
    '        End If

    '    End Sub
    '    Private Sub SaveQvAAlertDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewQvAAlertDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.QvAAlert.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Function CheckValidValue(ByVal NewValue As Decimal, ByVal Enable As Boolean, ByVal StartValue As Decimal, ByVal EndValue As Decimal)

    '        'objects
    '        Dim IsValidValue As Boolean = True

    '        If Enable Then

    '            If EndValue <> 0 AndAlso StartValue > EndValue Then

    '                If NewValue <= StartValue Then

    '                    If NewValue >= EndValue Then

    '                        IsValidValue = False

    '                    End If

    '                End If

    '            Else

    '                If NewValue >= StartValue Then

    '                    If EndValue = 0 Then

    '                        IsValidValue = False

    '                    Else

    '                        If NewValue <= EndValue Then

    '                            IsValidValue = False

    '                        End If

    '                    End If

    '                End If

    '            End If

    '        End If

    '        CheckValidValue = IsValidValue

    '    End Function
    '    Private Sub QvAAlertEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetQvAAlertStatus(EventLogEntry.Message & "....")

    '    End Sub

    '#End Region

    '#Region "  Export "

    '    Private Sub SetExportStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelExport_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadExportAllSettings()

    '        LoadExportSettings()

    '        LoadExportDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadExportSettings()

    '        'objects
    '        Dim ExportDataEnum As AdvantageFramework.Services.Export.SelectedData = AdvantageFramework.Services.Export.SelectedData.AllDataSelected
    '        Dim StartDate As Date = Nothing
    '        Dim EndDate As Date = Nothing

    '        'get values from Registry 
    '        AdvantageFramework.Services.Export.LoadSettings(DateTimeInputExportSettings_RunAt.Value, TextBoxExportSettings_ExportPath.Text, ExportDataEnum, StartDate, EndDate)

    '        Select Case ExportDataEnum

    '            Case AdvantageFramework.Services.Export.SelectedData.AllDataSelected

    '                RadioButtonExportSettings_AllData.Checked = True
    '                DateTimePickerExportSettings_DataStart.Value = DateTime.Today
    '                DateTimePickerExportSettings_DataEnd.Value = DateTime.Today

    '            Case AdvantageFramework.Services.Export.SelectedData.TodaysDataSelected

    '                RadioButtonExportSettings_TodaysData.Checked = True
    '                DateTimePickerExportSettings_DataStart.Value = DateTime.Today
    '                DateTimePickerExportSettings_DataEnd.Value = DateTime.Today

    '            Case Else

    '                RadioButtonExportSettings_DataFrom.Checked = True
    '                DateTimePickerExportSettings_DataStart.Value = StartDate
    '                DateTimePickerExportSettings_DataEnd.Value = EndDate

    '        End Select

    '    End Sub
    '    Private Sub LoadExportClientCampaigns(ByVal DatabaseProfile As String)

    '        'objects
    '        Dim LoadedCampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

    '        LoadedCampaignList = AdvantageFramework.Services.Export.LoadClientCampaigns(DatabaseProfile).OrderBy(Function(Campaign) Campaign.CampaignClient).ToList

    '        AddCampaignCriteria(LoadedCampaignList, False)

    '    End Sub
    '    Private Sub LoadExportDatabaseProfiles()

    '        DataGridViewExportDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.Export.LoadDatabaseProfiles
    '        ComboBoxExportCriteria_DatabaseProfiles.DataSource = AdvantageFramework.Services.Export.LoadDatabaseProfiles

    '        ButtonExportDatabaseProfiles_Remove.Enabled = DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonExportDatabaseProfiles_Edit.Enabled = DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveExportAllSettings()

    '        SaveExportSettings()

    '        SaveExportClientCampaigns(_ExportSelectedDatabase)

    '        SaveExportDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveExportSettings()

    '        'objects
    '        Dim ExportDataString As String = AdvantageFramework.Services.Export.SelectedData.AllDataSelected.ToString()

    '        If _Initialized Then

    '            If RadioButtonExportSettings_AllData.Checked Then

    '                ExportDataString = AdvantageFramework.Services.Export.SelectedData.AllDataSelected.ToString()

    '            ElseIf RadioButtonExportSettings_TodaysData.Checked Then

    '                ExportDataString = AdvantageFramework.Services.Export.SelectedData.TodaysDataSelected.ToString()

    '            ElseIf RadioButtonExportSettings_DataFrom.Checked Then

    '                ExportDataString = DateTimePickerExportSettings_DataStart.Value.ToString()

    '                If DateTimePickerExportSettings_DataEnd.Value.Date <> DateTime.Today Then

    '                    ExportDataString += "," + DateTimePickerExportSettings_DataEnd.Value.ToString()

    '                End If

    '            End If

    '            AdvantageFramework.Services.Export.SaveSettings(DateTimeInputExportSettings_RunAt.Value, TextBoxExportSettings_ExportPath.Text, ExportDataString)

    '        End If

    '    End Sub
    '    Private Sub SaveExportClientCampaigns(ByVal SelectedDatabase As String)

    '        'objects
    '        Dim SelectedClientCampaigns As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing
    '        Dim NullCampaignClients As String = ""

    '        If SelectedDatabase IsNot Nothing Then

    '            If SelectedDatabase.Length > 0 Then

    '                SelectedClientCampaigns = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

    '                AdvantageFramework.Services.Export.DeleteClientCampaigns(SelectedDatabase)

    '                For Each SelectedClientCampaign In SelectedClientCampaigns

    '                    If SelectedClientCampaign.ID = -1 Then

    '                        If NullCampaignClients.Length > 0 Then

    '                            NullCampaignClients += ","

    '                        End If

    '                        NullCampaignClients += SelectedClientCampaign.CampaignClient

    '                    Else

    '                        AdvantageFramework.Services.Export.SaveClientCampaign(SelectedClientCampaign, SelectedDatabase, False)

    '                    End If

    '                Next

    '                If NullCampaignClients.Length > 0 Then

    '                    AdvantageFramework.Services.Export.SaveNullClientCampaign(NullCampaignClients, SelectedDatabase)

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub SaveExportDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewExportDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.Export.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub ExportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetExportStatus(EventLogEntry.Message & "....")

    '    End Sub
    '    Private Sub AddCampaignCriteria(ByVal CampaignsToAddList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign), ByVal SaveSettings As Boolean)

    '        'objects
    '        Dim CampaignList As List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

    '        If CampaignsToAddList IsNot Nothing Then

    '            CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

    '            If SaveSettings Then

    '                For Each DataBoundItem In DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems()

    '                    CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(DataBoundItem.ID, DataBoundItem.CampaignClient, DataBoundItem.Code, DataBoundItem.Name))

    '                Next

    '            End If

    '            For Each CampaignToAdd In CampaignsToAddList

    '                CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(CampaignToAdd.ID, CampaignToAdd.CampaignClient, CampaignToAdd.Code, CampaignToAdd.Name))

    '            Next

    '            DataGridViewExportCriteria_SelectedCampaigns.ItemDescription = "Selected Campaign(s)"

    '            DataGridViewExportCriteria_SelectedCampaigns.DataSource = CampaignList

    '            If Not _ExportCampaignIDColumnVisible Then

    '                If DataGridViewExportCriteria_SelectedCampaigns.Columns("ID") IsNot Nothing Then

    '                    DataGridViewExportCriteria_SelectedCampaigns.Columns("ID").Visible = False

    '                End If

    '            End If

    '            DataGridViewExportCriteria_SelectedCampaigns.CurrentView.BestFitColumns()

    '            LoadAvailableCampaigns()

    '            If SaveSettings Then

    '                SaveExportClientCampaigns(_ExportSelectedDatabase)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RemoveCampaignCriteria(ByVal CampaignsToRemoveList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign))

    '        'objects
    '        Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

    '        If CampaignsToRemoveList IsNot Nothing Then

    '            CampaignList = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

    '            For Each CampaignToRemove As AdvantageFramework.Database.Classes.Campaign In CampaignsToRemoveList

    '                CampaignList.Remove(CampaignToRemove)

    '            Next

    '            DataGridViewExportCriteria_SelectedCampaigns.DataSource = CampaignList

    '            DataGridViewExportCriteria_SelectedCampaigns.CurrentView.BestFitColumns()

    '            LoadAvailableCampaigns()

    '            SaveExportClientCampaigns(_ExportSelectedDatabase)

    '        End If

    '    End Sub
    '    Private Function GetAllCampaignsByClientPlusNull(ByVal ClientCode As String, ByVal ClientName As String) As Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

    '        'objects
    '        Dim NewCampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
    '        Dim NullCampaign As AdvantageFramework.Database.Entities.Campaign = Nothing
    '        Dim NewClient As AdvantageFramework.Database.Entities.Client = Nothing

    '        NewCampaignList = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)()

    '        NullCampaign = New AdvantageFramework.Database.Entities.Campaign()
    '        NullCampaign.ID = -1

    '        NewClient = New AdvantageFramework.Database.Entities.Client()
    '        NewClient.Code = ClientCode

    '        If ClientName.IndexOf("-") > 0 Then

    '            NewClient.Name = ClientName.Substring(ClientName.IndexOf("-") + 1).Trim

    '        Else

    '            NewClient.Name = ClientName

    '        End If

    '        NullCampaign.Client = NewClient
    '        NullCampaign.Code = ""
    '        NullCampaign.Name = "No Campaign"

    '        NewCampaignList.Add(NullCampaign)

    '        For Each Campaign In AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(_ObjectContext, ClientCode).Include("Office").Include("Client").Include("Division").Include("Product").ToList

    '            NewCampaignList.Add(Campaign)

    '        Next

    '        GetAllCampaignsByClientPlusNull = NewCampaignList

    '    End Function
    '    Private Sub LoadAvailableCampaigns()

    '        'objects
    '        Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing
    '        Dim FoundCampaign As Boolean = False
    '        Dim AllCampaignListPlusNull As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing
    '        Dim AvailableCampaignList As Generic.List(Of AdvantageFramework.Database.Entities.Campaign) = Nothing

    '        If ComboBoxExportCriteria_Clients.SelectedItem IsNot Nothing Then

    '            CampaignList = DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList

    '            AllCampaignListPlusNull = GetAllCampaignsByClientPlusNull(ComboBoxExportCriteria_Clients.SelectedItem.Code, ComboBoxExportCriteria_Clients.SelectedItem.Name)

    '            If CampaignList.Count = 0 Then

    '                DataGridViewExportCriteria_Campaigns.DataSource = AllCampaignListPlusNull

    '            Else

    '                AvailableCampaignList = New Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

    '                For Each Campaign In AllCampaignListPlusNull

    '                    FoundCampaign = False

    '                    For Each SelectedCampaign In CampaignList

    '                        If SelectedCampaign.ID = Campaign.ID AndAlso SelectedCampaign.CampaignClient = Campaign.Client.ToString() Then

    '                            FoundCampaign = True
    '                            Exit For

    '                        End If

    '                    Next

    '                    If FoundCampaign = False Then

    '                        AvailableCampaignList.Add(Campaign)

    '                    End If

    '                Next

    '                DataGridViewExportCriteria_Campaigns.DataSource = AvailableCampaignList

    '            End If

    '            DataGridViewExportCriteria_Campaigns.CurrentView.BestFitColumns()

    '        End If

    '    End Sub

    '#End Region

    '#Region "  Task "

    '    Private Sub SetTaskStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelTask_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadTaskAllSettings()

    '        LoadTaskSettings()

    '        LoadTaskDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadTaskSettings()

    '        'objects
    '        Dim RunAtDay As String = ""
    '        Dim UpcomingDays As String = ""
    '        Dim SplitString() As String
    '        Dim StartDays As Integer = 0
    '        Dim EndDays As Integer = 0

    '        'get values from Registry 
    '        AdvantageFramework.Services.Task.LoadSettings(DateTimeInputTaskSettings_RunAt.Value, RunAtDay, CheckBoxTaskSettings_PastDue.Checked, TextBoxTaskSettings_PastDue_CustomMessage.Text,
    '                                                      CheckBoxTaskSettings_Upcoming.Checked, TextBoxTaskSettings_Upcoming_CustomMessage.Text, UpcomingDays)
    '        SplitString = UpcomingDays.Split(",")

    '        Integer.TryParse(SplitString(0), StartDays)
    '        Integer.TryParse(SplitString(1), EndDays)

    '        NumericInputTaskSettings_Upcoming_StartDays.EditValue = StartDays
    '        NumericInputTaskSettings_Upcoming_EndDays.EditValue = EndDays

    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Daily.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Sunday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Monday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Tuesday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Wednesday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Thursday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Friday.ToString())
    '        ComboBoxTaskSettings_RunDay.Items.Add(AdvantageFramework.Services.Task.RunDayofWeek.Saturday.ToString())

    '        ComboBoxTaskSettings_RunDay.SelectedItem = RunAtDay

    '        UpdatePastDueSettings()

    '        UpdateUpcomingSettings()

    '    End Sub
    '    Private Sub LoadTaskDatabaseProfiles()

    '        DataGridViewTaskDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.Task.LoadDatabaseProfiles

    '        ButtonTaskDatabaseProfiles_Remove.Enabled = DataGridViewTaskDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonTaskDatabaseProfiles_Edit.Enabled = DataGridViewTaskDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveTaskAllSettings()

    '        SaveTaskSettings()

    '        SaveTaskDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveTaskSettings()

    '        ' objects
    '        Dim UpcomingDays As String = ""

    '        If _Initialized Then

    '            UpcomingDays = NumericInputTaskSettings_Upcoming_StartDays.EditValue.ToString() + "," + NumericInputTaskSettings_Upcoming_EndDays.EditValue.ToString()

    '            AdvantageFramework.Services.Task.SaveSettings(DateTimeInputTaskSettings_RunAt.Value, ComboBoxTaskSettings_RunDay.SelectedItem.ToString(), CheckBoxTaskSettings_PastDue.Checked, TextBoxTaskSettings_PastDue_CustomMessage.Text,
    '                                                          CheckBoxTaskSettings_Upcoming.Checked, TextBoxTaskSettings_Upcoming_CustomMessage.Text, UpcomingDays)

    '        End If

    '    End Sub
    '    Private Sub SaveTaskDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewTaskDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.Task.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub TaskEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetTaskStatus(EventLogEntry.Message & "....")

    '    End Sub
    '    Private Sub UpdatePastDueSettings()

    '        If (CheckBoxTaskSettings_PastDue.Checked) Then

    '            TextBoxTaskSettings_PastDue_CustomMessage.Enabled = True

    '        Else

    '            TextBoxTaskSettings_PastDue_CustomMessage.Enabled = False

    '        End If

    '    End Sub
    '    Private Sub UpdateUpcomingSettings()

    '        If (CheckBoxTaskSettings_Upcoming.Checked) Then

    '            TextBoxTaskSettings_Upcoming_CustomMessage.Enabled = True
    '            NumericInputTaskSettings_Upcoming_StartDays.Enabled = True
    '            NumericInputTaskSettings_Upcoming_EndDays.Enabled = True

    '        Else

    '            TextBoxTaskSettings_Upcoming_CustomMessage.Enabled = False
    '            NumericInputTaskSettings_Upcoming_StartDays.Enabled = False
    '            NumericInputTaskSettings_Upcoming_EndDays.Enabled = False

    '        End If

    '    End Sub

    '#End Region

    '#Region "  Missing Time "

    '    Private Sub LoadMissingTimeAllSettings()

    '        LoadMissingTimeDatabaseProfiles()

    '        LoadMissingTimeServiceSettings(_SelectedDatabaseProfile)
    '        LoadMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '    End Sub
    '    Private Sub LoadMissingTimeDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfileList As List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        Try

    '            _LoadingDatabaseProfiles = True

    '            DatabaseProfileList = AdvantageFramework.Services.MissingTime.LoadDatabaseProfiles()

    '            DataGridViewMissingTimeDatabaseProfiles_Databases.DataSource = DatabaseProfileList

    '            _SelectedDatabaseProfile = Nothing

    '            ComboBoxMissingTimeAlerts_DatabaseProfile.DataSource = DatabaseProfileList
    '            ComboBoxMissingTimeSettings_DatabaseProfile.DataSource = DatabaseProfileList

    '            If DatabaseProfileList.Count > 0 Then

    '                ComboBoxMissingTimeSettings_DatabaseProfile.Enabled = True
    '                GroupBoxMissingTimeSettings_Interval.Enabled = True

    '                ComboBoxMissingTimeAlerts_DatabaseProfile.Enabled = True
    '                GroupBoxMissingTimeAlerts_Tracking.Enabled = True
    '                GroupBoxMissingTimeAlerts_Recipient.Enabled = True
    '                GroupBoxMissingTimeAlerts_Range.Enabled = True
    '                GroupBoxMissingTimeAlerts_Priority.Enabled = True
    '                GroupBoxMissingTimeAlerts_Other.Enabled = True

    '            Else

    '                ComboBoxMissingTimeSettings_DatabaseProfile.Enabled = False
    '                GroupBoxMissingTimeSettings_Interval.Enabled = False

    '                ComboBoxMissingTimeAlerts_DatabaseProfile.Enabled = False
    '                GroupBoxMissingTimeAlerts_Tracking.Enabled = False
    '                GroupBoxMissingTimeAlerts_Recipient.Enabled = False
    '                GroupBoxMissingTimeAlerts_Range.Enabled = False
    '                GroupBoxMissingTimeAlerts_Priority.Enabled = False
    '                GroupBoxMissingTimeAlerts_Other.Enabled = False

    '            End If

    '            ButtonMissingTimeDatabaseProfiles_Remove.Enabled = DataGridViewMissingTimeDatabaseProfiles_Databases.HasASelectedRow
    '            ButtonMissingTimeDatabaseProfiles_Edit.Enabled = DataGridViewMissingTimeDatabaseProfiles_Databases.HasASelectedRow

    '        Catch ex As Exception
    '            _LoadingDatabaseProfiles = False
    '        Finally
    '            _LoadingDatabaseProfiles = False
    '        End Try

    '    End Sub
    '    Private Sub LoadMissingTimeServiceSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

    '        'objects
    '        Dim DatabaseProfileName As String = ""
    '        Dim ProcessTime As Boolean = False
    '        Dim ProcessTimeValue As Date = Nothing
    '        Dim ProcessTimeDaily As Boolean = False
    '        Dim ProcessTimeWeekday As String = ""
    '        Dim ProcessStopAfterHours As Boolean = False
    '        Dim ProcessAfterHours As Integer = 0
    '        Dim StopAfterHours As Integer = 0

    '        Try

    '            If (DatabaseProfile IsNot Nothing) Then

    '                DatabaseProfileName = DatabaseProfile.Name

    '                If ((DatabaseProfileName IsNot Nothing) AndAlso (DatabaseProfileName.Length > 0)) Then

    '                    _LoadingServiceSettings = True

    '                    AdvantageFramework.Services.MissingTime.LoadServiceSettings(DatabaseProfileName, _
    '                                                                                ProcessTime, _
    '                                                                                ProcessTimeValue, _
    '                                                                                ProcessTimeWeekday, _
    '                                                                                ProcessTimeDaily, _
    '                                                                                ProcessAfterHours, _
    '                                                                                ProcessStopAfterHours, _
    '                                                                                StopAfterHours)

    '                    CheckBoxMissingTimeSettings_Interval_RunAt.Checked = ProcessTime
    '                    DateTimeInputMissingTimeSettings_Interval_RunAtTime.Value = ProcessTimeValue

    '                    If (ComboBoxMissingTimeSettings_Interval_RunDay.Items.Count = 0) Then

    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Daily.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Sunday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Monday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Tuesday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Wednesday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Thursday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Friday.ToString())
    '                        ComboBoxMissingTimeSettings_Interval_RunDay.Items.Add(AdvantageFramework.Services.MissingTime.RunDayofWeek.Saturday.ToString())

    '                    End If

    '                    ComboBoxMissingTimeSettings_Interval_RunDay.SelectedItem = ProcessTimeWeekday

    '                    CheckBoxMissingTimeSettings_Interval_RunEvery.Checked = ProcessTimeDaily

    '                    NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MinValue = 0
    '                    NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MaxValue = 23
    '                    NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValue = ProcessAfterHours

    '                    CheckBoxMissingTimeSettings_Interval_StopAfter.Checked = ProcessStopAfterHours

    '                    NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MinValue = 0
    '                    NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MaxValue = 23
    '                    NumericInputMissingTimeSettings_Interval_StopAfter.EditValue = StopAfterHours

    '                    UpdateMissingTimeIntervalRunAtSettings(ProcessTime)
    '                    UpdateMissingTimeIntervalRunEverySettings(ProcessTimeDaily)

    '                End If

    '            End If

    '        Catch ex As Exception

    '        Finally

    '            _LoadingServiceSettings = False

    '        End Try

    '    End Sub
    '    Private Sub LoadMissingTimeProcessSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

    '        'objects
    '        Dim DatabaseProfileName As String = ""
    '        Dim RangeDaysToCheck As Boolean = False
    '        Dim DaysToCheck As Integer = 0
    '        Dim SendEmailToEmployee As Boolean = False
    '        Dim SendEmailToSupervisor As Boolean = False
    '        Dim SendEmailToITContact As Boolean = True
    '        Dim HighPriority As Boolean = False
    '        Dim MediumPriority As Boolean = False
    '        Dim LowPriority As Boolean = False
    '        Dim DontCountWeekendsHoliday As Boolean = False
    '        Dim MissingTimeOnly As Boolean = False
    '        Dim EmployeeGracePeriod As Integer = 0
    '        Dim SupervisorGracePeriod As Integer = 0
    '        Dim ITContactGracePeriod As Integer = 0
    '        Dim CustomMessage As String = ""
    '        Dim LogFileDirectory As String = ""
    '        Dim LogFileMissingTimeOnly As Boolean = False

    '        Try

    '            If DatabaseProfile IsNot Nothing Then

    '                DatabaseProfileName = DatabaseProfile.Name

    '                If DatabaseProfileName IsNot Nothing AndAlso DatabaseProfileName.Length > 0 Then

    '                    _LoadingProcessSettings = True
    '                    'get values from Registry 
    '                    AdvantageFramework.Services.MissingTime.LoadProcessSettings(DatabaseProfileName, _
    '                                                                                RangeDaysToCheck, _
    '                                                                                DaysToCheck, _
    '                                                                                SendEmailToEmployee, _
    '                                                                                SendEmailToSupervisor, _
    '                                                                                HighPriority, _
    '                                                                                MediumPriority, _
    '                                                                                LowPriority, _
    '                                                                                DontCountWeekendsHoliday, _
    '                                                                                MissingTimeOnly, _
    '                                                                                EmployeeGracePeriod, _
    '                                                                                SupervisorGracePeriod, _
    '                                                                                ITContactGracePeriod, _
    '                                                                                CustomMessage, _
    '                                                                                LogFileDirectory, _
    '                                                                                LogFileMissingTimeOnly)

    '                    If RangeDaysToCheck Then

    '                        RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked = True

    '                    Else

    '                        RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Checked = True

    '                    End If

    '                    NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MinValue = 0
    '                    'NumericInputMissingTimeSettings_Range_DaysToCheck.MaxValue = 7
    '                    NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MaxValue = 99
    '                    NumericInputMissingTimeSettings_Range_DaysToCheck.EditValue = DaysToCheck

    '                    CheckBoxMissingTimeAlerts_Recipient_Employee.Checked = SendEmailToEmployee
    '                    CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked = SendEmailToSupervisor
    '                    CheckBoxMissingTimeAlerts_Recipient_ITContact.Checked = SendEmailToITContact

    '                    If (HighPriority) Then

    '                        RadioButtonMissingTimeSettings_Priority_High.Checked = True

    '                    Else

    '                        If (MediumPriority) Then

    '                            RadioButtonMissingTimeSettings_Priority_Medium.Checked = True

    '                        Else

    '                            If (LowPriority) Then

    '                                RadioButtonMissingTimeSettings_Priority_Low.Checked = True

    '                            End If

    '                        End If

    '                    End If

    '                    CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Checked = DontCountWeekendsHoliday
    '                    CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Checked = MissingTimeOnly

    '                    NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MinValue = 0
    '                    'NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.MaxValue = 7
    '                    NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MaxValue = 99
    '                    NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValue = EmployeeGracePeriod

    '                    NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MinValue = 0
    '                    'NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.MaxValue = 7
    '                    NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MaxValue = 99
    '                    NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValue = SupervisorGracePeriod

    '                    NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MinValue = 0
    '                    'NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.MaxValue = 7
    '                    NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MaxValue = 99
    '                    NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValue = ITContactGracePeriod

    '                    TextBoxMissingTimeAlerts_CustomMessage.Text = CustomMessage

    '                    TextBoxMissingTimeSettings_LogFilePath.Text = LogFileDirectory
    '                    CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Checked = LogFileMissingTimeOnly

    '                    UpdateMissingTimeRangeSettings(RangeDaysToCheck)

    '                    UpdateMissingTimeRecipientEmployeeSettings(SendEmailToEmployee)
    '                    UpdateMissingTimeRecipientSupervisorSettings(SendEmailToSupervisor)
    '                    UpdateMissingTimeRecipientITContactSettings(SendEmailToITContact)

    '                    If (_DisableITContact) Then

    '                        CheckBoxMissingTimeAlerts_Recipient_ITContact.Enabled = False
    '                        CheckBoxMissingTimeAlerts_Recipient_ITContact.Visible = False

    '                    Else

    '                        LabelMissingTimeAlerts_Recipient_ITContact.Visible = False

    '                    End If

    '                End If

    '            End If

    '        Catch ex As Exception

    '        Finally

    '            _LoadingProcessSettings = False

    '        End Try

    '    End Sub
    '    Private Sub SaveMissingTimeAllSettings()

    '        SaveMissingTimeDatabaseProfiles()

    '        SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)
    '        SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '    End Sub
    '    Private Sub SaveMissingTimeProcessSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

    '        'objects
    '        Dim DatabaseProfileName As String = ""

    '        If DatabaseProfile IsNot Nothing Then

    '            DatabaseProfileName = DatabaseProfile.Name

    '            If DatabaseProfileName IsNot Nothing AndAlso DatabaseProfileName.Length > 0 Then

    '                AdvantageFramework.Services.MissingTime.SaveProcessSettings(DatabaseProfileName, _
    '                                                                            RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked, _
    '                                                                            NumericInputMissingTimeSettings_Range_DaysToCheck.EditValue, _
    '                                                                            CheckBoxMissingTimeAlerts_Recipient_Employee.Checked, _
    '                                                                            CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked, _
    '                                                                            RadioButtonMissingTimeSettings_Priority_High.Checked, _
    '                                                                            RadioButtonMissingTimeSettings_Priority_Medium.Checked, _
    '                                                                            RadioButtonMissingTimeSettings_Priority_Low.Checked, _
    '                                                                            CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Checked, _
    '                                                                            CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Checked, _
    '                                                                            NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValue, _
    '                                                                            NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValue, _
    '                                                                            NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValue, _
    '                                                                            TextBoxMissingTimeAlerts_CustomMessage.Text, _
    '                                                                            TextBoxMissingTimeSettings_LogFilePath.Text, _
    '                                                                            CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Checked)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub SaveMissingTimeServiceSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

    '        'objects
    '        Dim DatabaseProfileName As String = ""

    '        If DatabaseProfile IsNot Nothing Then

    '            DatabaseProfileName = DatabaseProfile.Name

    '            If DatabaseProfileName IsNot Nothing AndAlso DatabaseProfileName.Length > 0 Then

    '                AdvantageFramework.Services.MissingTime.SaveServiceSettings(DatabaseProfileName, _
    '                                                                            CheckBoxMissingTimeSettings_Interval_RunAt.Checked, _
    '                                                                            DateTimeInputMissingTimeSettings_Interval_RunAtTime.Value, _
    '                                                                            ComboBoxMissingTimeSettings_Interval_RunDay.SelectedItem.ToString(), _
    '                                                                            CheckBoxMissingTimeSettings_Interval_RunEvery.Checked, _
    '                                                                            NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValue, _
    '                                                                            CheckBoxMissingTimeSettings_Interval_StopAfter.Checked, _
    '                                                                            NumericInputMissingTimeSettings_Interval_StopAfter.EditValue)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub SaveMissingTimeDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewMissingTimeDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.MissingTime.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub UpdateMissingTimeIntervalRunAtSettings(ByVal Setting As Boolean)

    '        DateTimeInputMissingTimeSettings_Interval_RunAtTime.Enabled = Setting
    '        ComboBoxMissingTimeSettings_Interval_RunDay.Enabled = Setting

    '    End Sub
    '    Private Sub UpdateMissingTimeIntervalRunEverySettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeSettings_Interval_RunEveryHours.Enabled = Setting
    '        CheckBoxMissingTimeSettings_Interval_StopAfter.Enabled = Setting

    '        UpdateMissingTimeIntervalStopAfterSettings((Setting) And (CheckBoxMissingTimeSettings_Interval_StopAfter.Checked))

    '    End Sub
    '    Private Sub UpdateMissingTimeIntervalStopAfterSettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeSettings_Interval_StopAfter.Enabled = Setting

    '    End Sub
    '    Private Sub UpdateMissingTimeRangeSettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeSettings_Range_DaysToCheck.Enabled = Setting

    '    End Sub
    '    Private Sub UpdateMissingTimeRecipientEmployeeSettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Enabled = Setting

    '    End Sub
    '    Private Sub UpdateMissingTimeRecipientSupervisorSettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Enabled = Setting

    '    End Sub
    '    Private Sub UpdateMissingTimeRecipientITContactSettings(ByVal Setting As Boolean)

    '        NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Enabled = Setting

    '    End Sub
    '    Private Sub SetMissingTimeStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelMissingTime_StatusDescription, Message)

    '    End Sub
    '    Private Sub MissingTimeEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetMissingTimeStatus(EventLogEntry.Message & "....")

    '    End Sub

    '#End Region

    '#Region "  Google Calendar "

    '    Private Sub SetGoogleCalendarStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelGoogleCalendar_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadGoogleCalendarSettings()

    '        AdvantageFramework.Services.GoogleCalendar.LoadSettings(NumericInputGoogleCalendarSettings_RunAt.EditValue, Nothing)

    '        LoadGoogleCalendarDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadGoogleCalendarDatabaseProfiles()

    '        DataGridViewGoogleCalendarDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.GoogleCalendar.LoadDatabaseProfiles

    '        ButtonGoogleCalendarDatabaseProfiles_Remove.Enabled = DataGridViewGoogleCalendarDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonGoogleCalendarDatabaseProfiles_Edit.Enabled = DataGridViewGoogleCalendarDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveGoogleCalendarAllSettings()

    '        SaveGoogleCalendarSettings()

    '        SaveGoogleCalendarDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveGoogleCalendarSettings()

    '        AdvantageFramework.Services.GoogleCalendar.SaveSettings(NumericInputGoogleCalendarSettings_RunAt.EditValue)

    '    End Sub
    '    Private Sub SaveGoogleCalendarDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewGoogleCalendarDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.GoogleCalendar.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub GoogleCalendarEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetGoogleCalendarStatus(EventLogEntry.Message & "....")

    '    End Sub

    '#End Region

    '#Region "  Core Media Check Export "

    '    Private Sub SetCoreMediaCheckExportStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelCoreMediaCheckExport_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadCoreMediaCheckExportAllSettings()

    '        LoadCoreMediaCheckExportSettings()

    '        LoadCoreMediaCheckExportDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadCoreMediaCheckExportSettings()

    '        AdvantageFramework.Services.CoreMediaCheckExport.LoadSettings(DateTimeInputCoreMediaCheckExportSettings_RunAt.Value, TextBoxCoreMediaCheckExportSettings_ExportPath.Text)

    '    End Sub
    '    Private Sub LoadCoreMediaCheckExportDatabaseProfiles()

    '        DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.CoreMediaCheckExport.LoadDatabaseProfiles

    '        ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Enabled = DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Enabled = DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveCoreMediaCheckExportSettings()

    '        AdvantageFramework.Services.CoreMediaCheckExport.SaveSettings(DateTimeInputCoreMediaCheckExportSettings_RunAt.Value, TextBoxCoreMediaCheckExportSettings_ExportPath.Text)

    '    End Sub
    '    Private Sub SaveCoreMediaCheckExportDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.CoreMediaCheckExport.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub CoreMediaCheckExportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetCoreMediaCheckExportStatus(EventLogEntry.Message & "....")

    '    End Sub

    '#End Region

    '#Region "  Paid Time Off Accruals "

    '    Private Sub SetPaidTimeOffAccrualsStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelPaidTimeOffAccruals_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadPaidTimeOffAccrualsAllSettings()

    '        LoadPaidTimeOffAccrualsSettings()

    '        LoadPaidTimeOffAccrualsDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadPaidTimeOffAccrualsSettings()

    '        AdvantageFramework.Services.PaidTimeOffAccruals.LoadSettings(ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValue)

    '    End Sub
    '    Private Sub LoadPaidTimeOffAccrualsDatabaseProfiles()

    '        DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.PaidTimeOffAccruals.LoadDatabaseProfiles
    '        ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.DataSource = AdvantageFramework.Services.PaidTimeOffAccruals.LoadDatabaseProfiles

    '        ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Enabled = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Enabled = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SavePaidTimeOffAccrualsSettings()

    '        AdvantageFramework.Services.PaidTimeOffAccruals.SaveSettings(ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValue)

    '    End Sub
    '    Private Sub SavePaidTimeOffAccrualsDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.PaidTimeOffAccruals.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub
    '    Private Sub PaidTimeOffAccrualsEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetPaidTimeOffAccrualsStatus(EventLogEntry.Message & "....")

    '    End Sub
    '    Public Function LoadDays() As Generic.List(Of Int32)

    '        Dim DaysList As Generic.List(Of Int32) = Nothing

    '        DaysList = New Generic.List(Of Int32)

    '        DaysList.Add(1)
    '        DaysList.Add(2)
    '        DaysList.Add(3)
    '        DaysList.Add(4)
    '        DaysList.Add(5)
    '        DaysList.Add(6)
    '        DaysList.Add(7)
    '        DaysList.Add(8)
    '        DaysList.Add(9)
    '        DaysList.Add(10)
    '        DaysList.Add(11)
    '        DaysList.Add(12)
    '        DaysList.Add(13)
    '        DaysList.Add(14)
    '        DaysList.Add(15)
    '        DaysList.Add(16)
    '        DaysList.Add(17)
    '        DaysList.Add(18)
    '        DaysList.Add(19)
    '        DaysList.Add(20)
    '        DaysList.Add(21)
    '        DaysList.Add(22)
    '        DaysList.Add(23)
    '        DaysList.Add(24)
    '        DaysList.Add(25)
    '        DaysList.Add(26)
    '        DaysList.Add(27)
    '        DaysList.Add(28)

    '        LoadDays = DaysList

    '    End Function

    '#End Region

    '#Region "  Contract "

    '    Private Sub ContractEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetContractStatus(EventLogEntry.Message & "....")

    '    End Sub
    '    Private Sub SetContractStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelContract_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadContractAllSettings()

    '        LoadContractSettings()

    '        LoadContractDatabaseProfiles()

    '    End Sub
    '    Private Sub LoadContractSettings()

    '        'get values from Registry 
    '        AdvantageFramework.Services.Contract.LoadSettings(DateTimeInputContractAlertSettings_RunAt.Value, CheckBoxContractSettings_ContractRenewal.Checked, NumericInputContractSettings_RenewalDaysPrior.EditValue)

    '    End Sub
    '    Private Sub LoadContractDatabaseProfiles()

    '        DataGridViewContractDatabaseProfiles_Databases.DataSource = AdvantageFramework.Services.Contract.LoadDatabaseProfiles

    '        ButtonContractDatabaseProfiles_Remove.Enabled = DataGridViewContractDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonContractDatabaseProfiles_Edit.Enabled = DataGridViewContractDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub SaveContractAlertAllSettings()

    '        SaveContractAlertSettings()

    '        SaveContractAlertDatabaseProfiles()

    '    End Sub
    '    Private Sub SaveContractAlertSettings()

    '        AdvantageFramework.Services.Contract.SaveSettings(DateTimeInputContractAlertSettings_RunAt.Value, CheckBoxContractSettings_ContractRenewal.Checked, NumericInputContractSettings_RenewalDaysPrior.EditValue)

    '    End Sub
    '    Private Sub SaveContractAlertDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewGoogleCalendarDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.Contract.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub

    '#End Region

    '#Region "  Media Ocean Import "

    '    Private Sub MediaOceanImportEntryLogWritten(ByVal EventLogEntry As System.Diagnostics.EventLogEntry)

    '        SetMediaOceanImportStatus(EventLogEntry.Message & "....")

    '    End Sub
    '    Private Sub SetMediaOceanImportStatus(ByVal Message As String)

    '        AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelMediaOceanImport_StatusDescription, Message)

    '    End Sub
    '    Private Sub LoadMediaOceanImportAllSettings()

    '        LoadMediaOceanImportDatabaseProfiles()

    '        'get values from Registry 
    '        AdvantageFramework.Services.MediaOceanImport.LoadSettings(DateTimeInputMediaOceanImportSettings_RunAt.Value)

    '        LoadMediaOceanImportSettings(_MOISelectedDatabaseProfile)

    '    End Sub
    '    Private Sub LoadMediaOceanImportSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

    '        'objects
    '        Dim DatabaseProfileName As String = ""

    '        Try

    '            If (DatabaseProfile IsNot Nothing) Then

    '                DatabaseProfileName = DatabaseProfile.Name

    '                If ((DatabaseProfileName IsNot Nothing) AndAlso (DatabaseProfileName.Length > 0)) Then

    '                    _MOILoadingServiceSettings = True

    '                    ComboBoxMediaOceanImportSettings_Employee.DataSource = AdvantageFramework.Services.MediaOceanImport.LoadEmployees(DatabaseProfile)

    '                    AdvantageFramework.Services.MediaOceanImport.LoadServiceSettings(DatabaseProfileName, _
    '                                                                                     TextBoxMediaOceanImportSettings_FTPAddress.Text, _
    '                                                                                     TextBoxMediaOceanImportSettings_FTPUser.Text, _
    '                                                                                     TextBoxMediaOceanImportSettings_FTPPassword.Text, _
    '                                                                                     TextBoxMediaOceanImportSettings_LocalFolder.Text, _
    '                                                                                     ComboBoxMediaOceanImportSettings_Employee.SelectedValue)

    '                End If

    '            End If

    '        Catch ex As Exception

    '        Finally

    '            _MOILoadingServiceSettings = False

    '        End Try

    '    End Sub
    '    Private Sub LoadMediaOceanImportDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfileList As List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        Try

    '            _MOILoadingDatabaseProfiles = True

    '            DatabaseProfileList = AdvantageFramework.Services.MediaOceanImport.LoadDatabaseProfiles()

    '            DataGridViewMediaOceanImportDatabaseProfiles_Databases.DataSource = DatabaseProfileList

    '            _MOISelectedDatabaseProfile = Nothing

    '            ComboBoxMediaOceanImportSettings_DatabaseProfile.DataSource = DatabaseProfileList

    '            If DatabaseProfileList.Count > 0 Then

    '                ComboBoxMediaOceanImportSettings_DatabaseProfile.Enabled = True
    '                GroupBoxMediaOceanImportSettings_Settings.Enabled = True

    '            Else

    '                ComboBoxMediaOceanImportSettings_DatabaseProfile.Enabled = False
    '                GroupBoxMediaOceanImportSettings_Settings.Enabled = False

    '            End If

    '            ButtonMediaOceanImportDatabaseProfiles_Remove.Enabled = DataGridViewMediaOceanImportDatabaseProfiles_Databases.HasASelectedRow
    '            ButtonMediaOceanImportDatabaseProfiles_Edit.Enabled = DataGridViewMediaOceanImportDatabaseProfiles_Databases.HasASelectedRow

    '        Catch ex As Exception
    '            _MOILoadingDatabaseProfiles = False
    '        Finally
    '            _MOILoadingDatabaseProfiles = False
    '        End Try

    '    End Sub
    '    Private Sub SaveMediaOceanImportAllSettings()

    '        SaveMediaOceanImportDatabaseProfiles()

    '        SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '    End Sub
    '    Private Sub SaveMediaOceanImportRunAt()

    '        AdvantageFramework.Services.MediaOceanImport.SaveSettings(DateTimeInputMediaOceanImportSettings_RunAt.Value)

    '    End Sub
    '    Private Sub SaveMediaOceanImportServiceSettings(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)


    '        'objects
    '        Dim DatabaseProfileName As String = ""

    '        If DatabaseProfile IsNot Nothing Then

    '            DatabaseProfileName = DatabaseProfile.Name

    '            If DatabaseProfileName IsNot Nothing AndAlso DatabaseProfileName.Length > 0 Then

    '                AdvantageFramework.Services.MediaOceanImport.SaveServiceSettings(DatabaseProfileName, _
    '                                                                                 TextBoxMediaOceanImportSettings_FTPAddress.Text,
    '                                                                                 TextBoxMediaOceanImportSettings_FTPUser.Text,
    '                                                                                 TextBoxMediaOceanImportSettings_FTPPassword.Text,
    '                                                                                 TextBoxMediaOceanImportSettings_LocalFolder.Text,
    '                                                                                 ComboBoxMediaOceanImportSettings_Employee.SelectedValue)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub SaveMediaOceanImportDatabaseProfiles()

    '        'objects
    '        Dim DatabaseProfilesList As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing

    '        DatabaseProfilesList = DataGridViewMediaOceanImportDatabaseProfiles_Databases.BindingSource.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList

    '        For Each DatabaseProfile In DatabaseProfilesList

    '            AdvantageFramework.Services.MediaOceanImport.SaveDatabaseProfile(DatabaseProfile, True)

    '        Next

    '    End Sub

    '#End Region

    '#Region "  Show Form Methods "



    '#End Region

    '#Region "  Form Event Handlers "

    '    Private Sub AdvantageServicesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    '        If e.CloseReason <> CloseReason.ApplicationExitCall Then

    '            e.Cancel = True

    '            Me.Hide()
    '            Me.ShowInTaskbar = False

    '        End If

    '    End Sub
    '    Private Sub AdvantageServicesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '        'objects
    '        Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
    '        Dim ServiceStartupType As AdvantageFramework.Services.ServiceStartupType = Nothing
    '        Dim MissingTimeEnabled As Boolean = False

    '        NotifyIconForm_NotifyIcon.Icon = My.Resources.AdvantageServicesIcon

    '        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show

    '        ToolStripMenuItemMenu_ShutDown.Image = AdvantageFramework.My.Resources.ExitImage
    '        ToolStripMenuItemMenu_ShowLogAndSettings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
    '        ButtonItemDatabaseProfiles_DatabaseProfiles.Image = AdvantageFramework.My.Resources.DatabaseProfileImage
    '        ButtonItemSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
    '        ButtonItemSystem_Hide.Image = AdvantageFramework.My.Resources.HideImage
    '        ButtonItemMainRibbon_Help.Image = AdvantageFramework.My.Resources.HelpImage
    '        ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.UpImage
    '        ButtonItemLog_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

    '        ButtonItemSystem_Exit.Visible = False
    '        '******************************************************************************************************************************************************

    '        LoadEmailListenerSettings()

    '        TextBoxEmailListenerLog_Log.Text = AdvantageFramework.Services.EmailListener.LoadLog(True, LabelEmailListener_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.EmailListener.EntryLogWrittenEvent, AddressOf EmailListenerEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadQvAAlertAllSettings()

    '        ComboBoxQvAAlertSettings_SendAlertTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.SendAlertTo))
    '        ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndex = _SendAlertTo

    '        ComboBoxQvAAlertSettings_SetAlertLevel.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.SetAlertLevel))
    '        ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndex = _SetAlertLevel

    '        ComboBoxQvAAlertSettings_ShowLevel.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Services.QvAAlert.ShowLevel))
    '        ComboBoxQvAAlertSettings_ShowLevel.SelectedIndex = _ShowLevel

    '        NumericInputThresholds_Level1Start.Properties.IsFloatValue = True
    '        NumericInputThresholds_Level1End.Properties.IsFloatValue = True
    '        NumericInputThresholds_Level2Start.Properties.IsFloatValue = True
    '        NumericInputThresholds_Level2End.Properties.IsFloatValue = True
    '        NumericInputThresholds_Level3Start.Properties.IsFloatValue = True

    '        NumericInputThresholds_Level1Start.EditValue = _QvAAlertLevel1Start
    '        NumericInputThresholds_Level1End.EditValue = _QvAAlertLevel1End
    '        TextBoxThresholds_Level1Description.Text = _QvAAlertLevel1Description

    '        NumericInputThresholds_Level2Start.EditValue = _QvAAlertLevel2Start
    '        NumericInputThresholds_Level2End.EditValue = _QvAAlertLevel2End
    '        TextBoxThresholds_Level2Description.Text = _QvAAlertLevel2Description

    '        NumericInputThresholds_Level3Start.EditValue = _QvAAlertLevel3Start
    '        TextBoxThresholds_Level3Description.Text = _QvAAlertLevel3Description

    '        CheckBoxThresholds_Level1.Checked = _QvAAlertLevel1Enabled
    '        CheckBoxThresholds_Level2.Checked = _QvAAlertLevel2Enabled
    '        CheckBoxThresholds_Level3.Checked = _QvAAlertLevel3Enabled

    '        _QvAAlertInitialized = True

    '        TextBoxQvAAlertLog_Log.Text = AdvantageFramework.Services.QvAAlert.LoadLog(True, LabelQvAAlert_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.QvAAlert.EntryLogWrittenEvent, AddressOf QvAAlertEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadExportAllSettings()

    '        TextBoxExportLog_Log.Text = AdvantageFramework.Services.Export.LoadLog(True, LabelExport_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.Export.EntryLogWrittenEvent, AddressOf ExportEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadTaskAllSettings()

    '        TextBoxTaskLog_Log.Text = AdvantageFramework.Services.Task.LoadLog(True, LabelTask_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.Task.EntryLogWrittenEvent, AddressOf TaskEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        AdvantageFramework.Services.MissingTime.LoadMissingTimeEnabled(AdvantageFramework.Registry.SettingsType.Process, MissingTimeEnabled)

    '        If MissingTimeEnabled Then

    '            LoadMissingTimeAllSettings()

    '            TextBoxMissingTimeLog_Log.Text = AdvantageFramework.Services.MissingTime.LoadLog(True, LabelMissingTime_StatusDescription.Text)

    '            AddHandler AdvantageFramework.Services.MissingTime.EntryLogWrittenEvent, AddressOf MissingTimeEntryLogWritten

    '            TabItemServices_MissingTimeTab.Visible = True

    '        Else

    '            TabItemServices_MissingTimeTab.Visible = False

    '        End If

    '        '******************************************************************************************************************************************************

    '        LoadGoogleCalendarSettings()

    '        TextBoxGoogleCalendarLog_Log.Text = AdvantageFramework.Services.GoogleCalendar.LoadLog(True, LabelGoogleCalendar_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.GoogleCalendar.EntryLogWrittenEvent, AddressOf GoogleCalendarEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadCoreMediaCheckExportAllSettings()

    '        TextBoxCoreMediaCheckExportLog_Log.Text = AdvantageFramework.Services.CoreMediaCheckExport.LoadLog(True, LabelCoreMediaCheckExport_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.CoreMediaCheckExport.EntryLogWrittenEvent, AddressOf CoreMediaCheckExportEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadContractAllSettings()

    '        CheckBoxContractSettings_ContractReports.Checked = True

    '        TextBoxContractLog_Log.Text = AdvantageFramework.Services.Contract.LoadLog(True, LabelContract_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.Contract.EntryLogWrittenEvent, AddressOf ContractEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        LoadMediaOceanImportAllSettings()

    '        TextBoxMediaOceanImportLog_Log.Text = AdvantageFramework.Services.MediaOceanImport.LoadLog(True, LabelMediaOceanImport_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.MediaOceanImport.EntryLogWrittenEvent, AddressOf MediaOceanImportEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DataSource = LoadDays()

    '        LoadPaidTimeOffAccrualsAllSettings()

    '        TextBoxPaidTimeOffAccrualsLog_Log.Text = AdvantageFramework.Services.PaidTimeOffAccruals.LoadLog(True, LabelPaidTimeOffAccruals_StatusDescription.Text)

    '        AddHandler AdvantageFramework.Services.PaidTimeOffAccruals.EntryLogWrittenEvent, AddressOf PaidTimeOffAccrualsEntryLogWritten

    '        '******************************************************************************************************************************************************

    '        'Email Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxEMail_AutoStart.Checked = True

    '            Else

    '                CheckBoxEMail_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonEmailListener_Start.Visible = True
    '                ButtonEmailListener_Stop.Visible = False
    '                CheckBoxEMail_AutoStart.Enabled = True

    '            Else

    '                ButtonEmailListener_Start.Visible = False
    '                ButtonEmailListener_Stop.Visible = True
    '                CheckBoxEMail_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.EmailListener.Stop()

    '            ButtonEmailListener_Start.Visible = True
    '            ButtonEmailListener_Stop.Visible = False
    '            CheckBoxEMail_AutoStart.Enabled = True

    '        End If

    '        'QvA Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxQvA_AutoStart.Checked = True

    '            Else

    '                CheckBoxQvA_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonQvA_Start.Visible = True
    '                ButtonQvA_Stop.Visible = False
    '                CheckBoxQvA_AutoStart.Enabled = True

    '            Else

    '                ButtonQvA_Start.Visible = False
    '                ButtonQvA_Stop.Visible = True
    '                CheckBoxQvA_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.EmailListener.Stop()

    '            ButtonQvA_Start.Visible = True
    '            ButtonQvA_Stop.Visible = False
    '            CheckBoxQvA_AutoStart.Enabled = True

    '        End If

    '        'Export Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageExportWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageExportWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxExport_AutoStart.Checked = True

    '            Else

    '                CheckBoxExport_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonExport_Start.Visible = True
    '                ButtonExport_Stop.Visible = False
    '                CheckBoxExport_AutoStart.Enabled = True

    '            Else

    '                ButtonExport_Start.Visible = False
    '                ButtonExport_Stop.Visible = True
    '                CheckBoxExport_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.Export.Stop()

    '            ButtonExport_Start.Visible = True
    '            ButtonExport_Stop.Visible = False
    '            CheckBoxExport_AutoStart.Enabled = True

    '        End If

    '        ' Task Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageTaskWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageTaskWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxTask_AutoStart.Checked = True

    '            Else

    '                CheckBoxTask_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonTask_Start.Visible = True
    '                ButtonTask_Stop.Visible = False
    '                CheckBoxTask_AutoStart.Enabled = True

    '            Else

    '                ButtonTask_Start.Visible = False
    '                ButtonTask_Stop.Visible = True
    '                CheckBoxTask_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.Task.Stop()

    '            ButtonTask_Start.Visible = True
    '            ButtonTask_Stop.Visible = False
    '            CheckBoxTask_AutoStart.Enabled = True

    '        End If

    '        ' Missing Time
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxMissingTime_AutoStart.Checked = True

    '            Else

    '                CheckBoxMissingTime_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonMissingTime_Start.Visible = True
    '                ButtonMissingTime_Stop.Visible = False
    '                CheckBoxMissingTime_AutoStart.Enabled = True

    '            Else

    '                ButtonMissingTime_Start.Visible = False
    '                ButtonMissingTime_Stop.Visible = True
    '                CheckBoxMissingTime_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.MissingTime.Stop()

    '            ButtonMissingTime_Start.Visible = True
    '            ButtonMissingTime_Stop.Visible = False
    '            CheckBoxMissingTime_AutoStart.Enabled = True

    '        End If

    '        'Google Calendar
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxGoogleCalendar_AutoStart.Checked = True

    '            Else

    '                CheckBoxGoogleCalendar_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonGoogleCalendar_Start.Visible = True
    '                ButtonGoogleCalendar_Stop.Visible = False
    '                CheckBoxGoogleCalendar_AutoStart.Enabled = True

    '            Else

    '                ButtonGoogleCalendar_Start.Visible = False
    '                ButtonGoogleCalendar_Stop.Visible = True
    '                CheckBoxGoogleCalendar_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.GoogleCalendar.Stop()

    '            ButtonGoogleCalendar_Start.Visible = True
    '            ButtonGoogleCalendar_Stop.Visible = False
    '            CheckBoxGoogleCalendar_AutoStart.Enabled = True

    '        End If

    '        'Core Media Check Export
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxCoreMediaCheckExport_AutoStart.Checked = True

    '            Else

    '                CheckBoxCoreMediaCheckExport_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonCoreMediaCheckExport_Start.Visible = True
    '                ButtonCoreMediaCheckExport_Stop.Visible = False
    '                CheckBoxCoreMediaCheckExport_AutoStart.Enabled = True

    '            Else

    '                ButtonCoreMediaCheckExport_Start.Visible = False
    '                ButtonCoreMediaCheckExport_Stop.Visible = True
    '                CheckBoxCoreMediaCheckExport_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.CoreMediaCheckExport.Stop()

    '            ButtonCoreMediaCheckExport_Start.Visible = True
    '            ButtonCoreMediaCheckExport_Stop.Visible = False
    '            CheckBoxCoreMediaCheckExport_AutoStart.Enabled = True

    '        End If

    '        'Paid Time Off Accruals
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxPaidTimeOffAccruals_AutoStart.Checked = True

    '            Else

    '                CheckBoxPaidTimeOffAccruals_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonPaidTimeOffAccruals_Start.Visible = True
    '                ButtonPaidTimeOffAccruals_Stop.Visible = False
    '                CheckBoxPaidTimeOffAccruals_AutoStart.Enabled = True

    '            Else

    '                ButtonPaidTimeOffAccruals_Start.Visible = False
    '                ButtonPaidTimeOffAccruals_Stop.Visible = True
    '                CheckBoxPaidTimeOffAccruals_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.PaidTimeOffAccruals.Stop()

    '            ButtonPaidTimeOffAccruals_Start.Visible = True
    '            ButtonPaidTimeOffAccruals_Stop.Visible = False
    '            CheckBoxPaidTimeOffAccruals_AutoStart.Enabled = True

    '        End If

    '        ' Contract Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageContractWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageContractWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxContract_AutoStart.Checked = True

    '            Else

    '                CheckBoxContract_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonContract_Start.Visible = True
    '                ButtonContract_Stop.Visible = False
    '                CheckBoxContract_AutoStart.Enabled = True

    '            Else

    '                ButtonContract_Start.Visible = False
    '                ButtonContract_Stop.Visible = True
    '                CheckBoxContract_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.Contract.Stop()

    '            ButtonContract_Start.Visible = True
    '            ButtonContract_Stop.Visible = False
    '            CheckBoxContract_AutoStart.Enabled = True

    '        End If

    '        ' Media Ocean Service
    '        ServiceController = AdvantageFramework.Services.Load(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService)

    '        If ServiceController IsNot Nothing Then

    '            ServiceStartupType = AdvantageFramework.Services.GetStartupType(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService)

    '            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

    '                CheckBoxMediaOceanImport_AutoStart.Checked = True

    '            Else

    '                CheckBoxMediaOceanImport_AutoStart.Checked = False

    '            End If

    '            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
    '                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

    '                ButtonMediaOceanImport_Start.Visible = True
    '                ButtonMediaOceanImport_Stop.Visible = False
    '                CheckBoxMediaOceanImport_AutoStart.Enabled = True

    '            Else

    '                ButtonMediaOceanImport_Start.Visible = False
    '                ButtonMediaOceanImport_Stop.Visible = True
    '                CheckBoxMediaOceanImport_AutoStart.Enabled = False

    '            End If

    '        Else

    '            AdvantageFramework.Services.MediaOceanImport.Stop()

    '            ButtonMediaOceanImport_Start.Visible = True
    '            ButtonMediaOceanImport_Stop.Visible = False
    '            CheckBoxMediaOceanImport_AutoStart.Enabled = True

    '        End If

    '        If AdvantageFramework.Email.TestMailBee() = False Then

    '            AdvantageFramework.WinForm.MessageBox.Show("MailBee not registered", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK)

    '        End If

    '        If Debugger.IsAttached Then

    '            ButtonEmailListenerDatabaseProfiles_ProcessNow.Visible = True
    '            ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Visible = True

    '        Else

    '            ButtonEmailListenerDatabaseProfiles_ProcessNow.Visible = False
    '            ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Visible = False

    '        End If

    '        _Initialized = True

    '    End Sub
    '    Private Sub AdvantageServicesForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

    '        Me.Hide()
    '        Me.ShowInTaskbar = False

    '    End Sub

    '#End Region

    '#Region "  Control Event Handlers "

    '#Region "   Toolbar"

    '    Private Sub ButtonItemMainRibbon_ShowAndHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMainRibbon_ShowAndHide.Click

    '        If RibbonControlForm_MainRibbon.Expanded Then

    '            RibbonControlForm_MainRibbon.Expanded = False
    '            ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.DownImage

    '        Else

    '            RibbonControlForm_MainRibbon.Expanded = True
    '            ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.UpImage

    '        End If

    '    End Sub
    '    Private Sub ButtonItemMainRibbon_Help_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMainRibbon_Help.Click

    '        AdvantageFramework.WinForm.Presentation.AboutDialog.ShowFormDialog()

    '    End Sub
    '    Private Sub ToolStripMenuItemMenu_ShowLogAndSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMenu_ShowLogAndSettings.Click

    '        Me.Show()
    '        Me.BringToFront()
    '        Me.ShowInTaskbar = True

    '    End Sub
    '    Private Sub ButtonItemSettings_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSettings_Save.Click

    '        If TabControlForm_Services.SelectedTab Is TabItemServices_EmailListenerTab Then

    '            SaveEmailListenerAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_QvAAlertTab Then

    '            SaveQvAAlertAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ExportTab Then

    '            SaveExportAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_TasksTab Then

    '            SaveTaskAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MissingTimeTab Then

    '            SaveMissingTimeAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ContractTab Then

    '            SaveContractAlertAllSettings()

    '        ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaOceanImportTab Then

    '            SaveMediaOceanImportAllSettings()

    '        End If

    '    End Sub
    '    Private Sub ButtonItemDatabaseProfiles_DatabaseProfiles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDatabaseProfiles_DatabaseProfiles.Click

    '        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, False, False)

    '    End Sub
    '    Private Sub ToolStripMenuItemMenu_ShutDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMenu_ShutDown.Click

    '        System.Windows.Forms.Application.Exit()

    '    End Sub
    '    Private Sub ButtonItemSystem_Hide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Hide.Click

    '        Me.Hide()
    '        Me.ShowInTaskbar = False

    '    End Sub
    '    Private Sub ButtonItemLog_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemLog_Refresh.Click

    '        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(AdvantageFramework.WinForm.Presentation.WaitForm))

    '        Try

    '            If TabControlForm_Services.SelectedTab Is TabItemServices_EmailListenerTab Then

    '                TextBoxEmailListenerLog_Log.Text = AdvantageFramework.Services.EmailListener.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_QvAAlertTab Then

    '                TextBoxQvAAlertLog_Log.Text = AdvantageFramework.Services.QvAAlert.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ExportTab Then

    '                TextBoxExportLog_Log.Text = AdvantageFramework.Services.Export.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_TasksTab Then

    '                TextBoxTaskLog_Log.Text = AdvantageFramework.Services.Task.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MissingTimeTab Then

    '                TextBoxMissingTimeLog_Log.Text = AdvantageFramework.Services.MissingTime.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_GoogleCalendarTab Then

    '                TextBoxGoogleCalendarLog_Log.Text = AdvantageFramework.Services.GoogleCalendar.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_CoreMediaCheckExportTab Then

    '                TextBoxCoreMediaCheckExportLog_Log.Text = AdvantageFramework.Services.CoreMediaCheckExport.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_PaidTimeOffAccrualsTab Then

    '                TextBoxPaidTimeOffAccrualsLog_Log.Text = AdvantageFramework.Services.PaidTimeOffAccruals.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_ContractTab Then

    '                TextBoxContractLog_Log.Text = AdvantageFramework.Services.Contract.LoadLogEntries

    '            ElseIf TabControlForm_Services.SelectedTab Is TabItemServices_MediaOceanImportTab Then

    '                TextBoxMediaOceanImportLog_Log.Text = AdvantageFramework.Services.MediaOceanImport.LoadLogEntries

    '            End If

    '        Catch ex As Exception

    '        End Try

    '        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

    '    End Sub

    '#End Region

    '#Region "   Email Listener "

    '    Private Sub ButtonEmailListenerDatabaseProfiles_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListenerDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Proflie In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.EmailListener.SaveDatabaseProfile(Proflie, False)

    '                Next

    '                LoadEmailListenerDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonEmailListenerDatabaseProfiles_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListenerDatabaseProfiles_Edit.Click

    '        If DataGridViewEmailListenerDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewEmailListenerDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewEmailListenerDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadEmailListenerDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonEmailListenerDatabaseProfiles_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListenerDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewEmailListenerDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.EmailListener.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadEmailListenerDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonEmailListener_Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListener_Start.Click

    '        If AdvantageFramework.Services.EmailListener.Start(DataGridViewEmailListenerDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonEmailListener_Start.Visible = False
    '            ButtonEmailListener_Stop.Visible = True
    '            CheckBoxEMail_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonEmailListener_Stop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListener_Stop.Click

    '        AdvantageFramework.Services.EmailListener.Stop()

    '        ButtonEmailListener_Start.Visible = True
    '        ButtonEmailListener_Stop.Visible = False
    '        CheckBoxEMail_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub CheckBoxEMail_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxEMail_AutoStart.CheckedChanged

    '        If CheckBoxEMail_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewEmailListenerSetup_Databases_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewEmailListenerDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonEmailListenerDatabaseProfiles_Remove.Enabled = DataGridViewEmailListenerDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonEmailListenerDatabaseProfiles_Edit.Enabled = DataGridViewEmailListenerDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub NumericInputEmailListenerSettings_RunAtEvery_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputEmailListenerSettings_RunAtEvery.EditValueChanged

    '        SaveEmailListenerSettings()

    '    End Sub
    '    Private Sub TextBoxEmailListenerSettings_StartofSignatureCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEmailListenerSettings_StartofSignatureCode.Validated

    '        SaveEmailListenerSettings()

    '    End Sub
    '    Private Sub ButtonEmailListenerDatabaseProfiles_ProcessNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonEmailListenerDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.EmailListener.ProcessDatabase(DataGridViewEmailListenerDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub

    '#End Region

    '#Region "   QvA"

    '    Private Sub ButtonQvAStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvA_Start.Click

    '        If AdvantageFramework.Services.QvAAlert.Start() Then

    '            ButtonQvA_Start.Visible = False
    '            ButtonQvA_Stop.Visible = True
    '            CheckBoxQvA_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonQvAStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvA_Stop.Click

    '        AdvantageFramework.Services.QvAAlert.Stop()

    '        ButtonQvA_Start.Visible = True
    '        ButtonQvA_Stop.Visible = False
    '        CheckBoxQvA_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonQvAAlertDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvAAlertDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.QvAAlert.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadQvAAlertDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonQvAAlertDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvAAlertDatabaseProfiles_Edit.Click

    '        If DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewQvAAlertDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadQvAAlertDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonQvAAlertDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvAAlertDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewQvAAlertDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.QvAAlert.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadQvAAlertDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonQvAAlert_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQvAAlertDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.QvAAlert.ProcessDatabase(DataGridViewQvAAlertDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub CheckBoxQvA_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxQvA_AutoStart.CheckedChanged

    '        If CheckBoxQvA_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageQvAAlertWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxThresholds_Level1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level1.CheckedChanged

    '        If CheckBoxThresholds_Level1.Checked Then

    '            NumericInputThresholds_Level1Start.Enabled = True
    '            NumericInputThresholds_Level1End.Enabled = True
    '            TextBoxThresholds_Level1Description.Enabled = True

    '        Else

    '            NumericInputThresholds_Level1Start.Enabled = False
    '            NumericInputThresholds_Level1End.Enabled = False
    '            TextBoxThresholds_Level1Description.Enabled = False

    '        End If

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel1Enabled = CheckBoxThresholds_Level1.Checked

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxThresholds_Level2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level2.CheckedChanged

    '        If CheckBoxThresholds_Level2.Checked Then

    '            NumericInputThresholds_Level2Start.Enabled = True
    '            NumericInputThresholds_Level2End.Enabled = True
    '            TextBoxThresholds_Level2Description.Enabled = True

    '        Else

    '            NumericInputThresholds_Level2Start.Enabled = False
    '            NumericInputThresholds_Level2End.Enabled = False
    '            TextBoxThresholds_Level2Description.Enabled = False

    '        End If

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel2Enabled = CheckBoxThresholds_Level2.Checked

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxThresholds_Level3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxThresholds_Level3.CheckedChanged

    '        If CheckBoxThresholds_Level3.Checked Then

    '            NumericInputThresholds_Level3Start.Enabled = True
    '            TextBoxThresholds_Level3Description.Enabled = True

    '        Else

    '            NumericInputThresholds_Level3Start.Enabled = False
    '            TextBoxThresholds_Level3Description.Enabled = False

    '        End If

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel3Enabled = CheckBoxThresholds_Level3.Checked

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxCalculationOptions_Time_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_Time.CheckedChanged

    '        SaveQvAAlertSettings()

    '    End Sub
    '    Private Sub CheckBoxCalculationOptions_IncomeOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncomeOnly.CheckedChanged

    '        SaveQvAAlertSettings()

    '    End Sub
    '    Private Sub CheckBoxCalculationOptions_VendorCharges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_VendorCharges.CheckedChanged

    '        SaveQvAAlertSettings()

    '    End Sub
    '    Private Sub CheckBoxCalculationOptions_IncludeEstimate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCalculationOptions_IncludeEstimate.CheckedChanged

    '        SaveQvAAlertSettings()

    '    End Sub
    '    Private Sub ComboBoxQvAAlertSettings_SendAlertTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndexChanged

    '        If _QvAAlertInitialized Then

    '            _SendAlertTo = ComboBoxQvAAlertSettings_SendAlertTo.SelectedIndex

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub ComboBoxQvAAlertSettings_SetAlertLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndexChanged

    '        If _QvAAlertInitialized Then

    '            _SetAlertLevel = ComboBoxQvAAlertSettings_SetAlertLevel.SelectedIndex

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub ComboBoxQvAAlertSettings_ShowLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxQvAAlertSettings_ShowLevel.SelectedIndexChanged

    '        If _QvAAlertInitialized Then

    '            _ShowLevel = ComboBoxQvAAlertSettings_ShowLevel.SelectedIndex

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub NumericInputThresholds_Level1Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level1Start.EditValueChanged

    '        'objects
    '        Dim SaveValue As Boolean = True
    '        Dim NewValue As Decimal

    '        If _QvAAlertInitialized Then

    '            NewValue = NumericInputThresholds_Level1Start.EditValue

    '            If NewValue <> _QvAAlertLevel1Start Then

    '                If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

    '                    SaveValue = False

    '                Else

    '                    If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

    '                        SaveValue = False

    '                    End If

    '                End If

    '                If SaveValue Then

    '                    _QvAAlertLevel1Start = NumericInputThresholds_Level1Start.EditValue

    '                    SaveQvAAlertSettings()

    '                Else

    '                    AdvantageFramework.Navigation.ShowMessageBox("Invalid value")

    '                    NumericInputThresholds_Level1Start.EditValue = _QvAAlertLevel1Start

    '                    NumericInputThresholds_Level1Start.Focus()

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub NumericInputThresholds_Level1End_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level1End.EditValueChanged

    '        'objects
    '        Dim SaveValue As Boolean = True
    '        Dim NewValue As Decimal

    '        If _QvAAlertInitialized Then

    '            NewValue = NumericInputThresholds_Level1End.EditValue

    '            If NewValue <> _QvAAlertLevel1End Then

    '                If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

    '                    SaveValue = False

    '                Else

    '                    If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

    '                        SaveValue = False

    '                    End If

    '                End If

    '                If SaveValue Then

    '                    _QvAAlertLevel1End = NumericInputThresholds_Level1End.EditValue

    '                    SaveQvAAlertSettings()

    '                Else

    '                    AdvantageFramework.Navigation.ShowMessageBox("Invalid value")

    '                    NumericInputThresholds_Level1End.EditValue = _QvAAlertLevel1End

    '                    NumericInputThresholds_Level1End.Focus()

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub NumericInputThresholds_Level2Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level2Start.EditValueChanged

    '        'objects
    '        Dim SaveValue As Boolean = True
    '        Dim NewValue As Decimal

    '        If _QvAAlertInitialized Then

    '            NewValue = NumericInputThresholds_Level2Start.EditValue

    '            If NewValue <> _QvAAlertLevel2Start Then

    '                If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

    '                    SaveValue = False

    '                Else

    '                    If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

    '                        SaveValue = False

    '                    End If

    '                End If

    '                If SaveValue Then

    '                    _QvAAlertLevel2Start = NumericInputThresholds_Level2Start.EditValue

    '                    SaveQvAAlertSettings()

    '                Else

    '                    AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

    '                    NumericInputThresholds_Level2Start.EditValue = _QvAAlertLevel2Start

    '                    NumericInputThresholds_Level2Start.Focus()

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub NumericInputThresholds_Level2End_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level2End.EditValueChanged

    '        'objects
    '        Dim SaveValue As Boolean = True
    '        Dim NewValue As Decimal = 0

    '        If _QvAAlertInitialized Then

    '            NewValue = NumericInputThresholds_Level2End.EditValue

    '            If NewValue <> _QvAAlertLevel2End Then

    '                If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

    '                    SaveValue = False

    '                Else

    '                    If CheckValidValue(NewValue, CheckBoxThresholds_Level3.Checked, NumericInputThresholds_Level3Start.EditValue, Nothing) = False Then

    '                        SaveValue = False

    '                    End If

    '                End If

    '                If SaveValue Then

    '                    _QvAAlertLevel2End = NumericInputThresholds_Level2End.EditValue

    '                    SaveQvAAlertSettings()

    '                Else

    '                    AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

    '                    NumericInputThresholds_Level2End.EditValue = _QvAAlertLevel2End

    '                    NumericInputThresholds_Level2End.Focus()

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub NumericInputThresholds_Level3Start_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputThresholds_Level3Start.EditValueChanged

    '        'objects
    '        Dim SaveValue As Boolean = True
    '        Dim NewValue As Decimal = 0

    '        If _QvAAlertInitialized Then

    '            NewValue = NumericInputThresholds_Level3Start.EditValue

    '            If NewValue <> _QvAAlertLevel3Start Then

    '                If CheckValidValue(NewValue, CheckBoxThresholds_Level1.Checked, NumericInputThresholds_Level1Start.EditValue, NumericInputThresholds_Level1End.EditValue) = False Then

    '                    SaveValue = False

    '                Else

    '                    If CheckValidValue(NewValue, CheckBoxThresholds_Level2.Checked, NumericInputThresholds_Level2Start.EditValue, NumericInputThresholds_Level2End.EditValue) = False Then

    '                        SaveValue = False

    '                    End If

    '                End If

    '                If SaveValue Then

    '                    _QvAAlertLevel3Start = NumericInputThresholds_Level3Start.EditValue

    '                    SaveQvAAlertSettings()

    '                Else

    '                    AdvantageFramework.Navigation.ShowMessageBox("This value overlaps another Threshold range", , "Error - Invalid Value")

    '                    NumericInputThresholds_Level3Start.EditValue = _QvAAlertLevel3Start

    '                    NumericInputThresholds_Level3Start.Focus()

    '                End If

    '            End If

    '        End If

    '    End Sub
    '    Private Sub TextBoxThresholds_Level1Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level1Description.TextChanged

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel1Description = TextBoxThresholds_Level1Description.Text

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub TextBoxThresholds_Level2Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level2Description.TextChanged

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel2Description = TextBoxThresholds_Level2Description.Text

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub TextBoxThresholds_Level3Description_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxThresholds_Level3Description.TextChanged

    '        If _QvAAlertInitialized Then

    '            _QvAAlertLevel3Description = TextBoxThresholds_Level3Description.Text

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub DateTimeInputQvAAlert_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInputQvAAlertSettings_RunAt.ValueChanged

    '        If _Initialized Then

    '            SaveQvAAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub DataGridViewQvAAlertDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewQvAAlertDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonQvAAlertDatabaseProfiles_Remove.Enabled = DataGridViewQvAAlertDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonQvAAlertDatabaseProfiles_Edit.Enabled = DataGridViewQvAAlertDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub

    '#End Region

    '#Region "   Export"

    '    Private Sub TextBoxExportSettings_ExportPath_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxExportSettings_ExportPath.Validated

    '        SaveExportSettings()

    '    End Sub
    '    Private Sub RadioButtonExportSettings_AllData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonExportSettings_AllData.CheckedChanged

    '        If _Initialized Then

    '            If RadioButtonExportSettings_AllData.Checked Then

    '                SaveExportSettings()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonExportSettings_TodaysData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonExportSettings_TodaysData.CheckedChanged

    '        If _Initialized Then

    '            If RadioButtonExportSettings_TodaysData.Checked Then

    '                SaveExportSettings()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonExportSettings_DataFrom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonExportSettings_DataFrom.CheckedChanged

    '        If _Initialized Then

    '            If RadioButtonExportSettings_DataFrom.Checked Then

    '                SaveExportSettings()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonExport_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport_Start.Click

    '        If AdvantageFramework.Services.Export.Start(DataGridViewExportDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonExport_Start.Visible = False
    '            ButtonExport_Stop.Visible = True
    '            CheckBoxExport_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonExport_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport_Stop.Click

    '        AdvantageFramework.Services.Export.Stop()

    '        ButtonExport_Start.Visible = True
    '        ButtonExport_Stop.Visible = False
    '        CheckBoxExport_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonExportDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.Export.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadExportDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonExportDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDatabaseProfiles_Edit.Click

    '        If DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadExportDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonExportDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewExportDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.Export.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadExportDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonExportDatabaseProfiles_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.Export.ProcessDatabase(DataGridViewExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub ButtonExportCriteriaCampaign_AddSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_AddSelected.Click

    '        'objects
    '        Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

    '        CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

    '        For Each Campaign In DataGridViewExportCriteria_Campaigns.GetAllSelectedRowsDataBoundItems

    '            CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(Campaign.ID, Campaign.Client, Campaign.Code, Campaign.Campaign))

    '        Next

    '        AddCampaignCriteria(CampaignList, True)

    '    End Sub
    '    Private Sub ButtonExportCriteriaCampaign_AddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_AddAll.Click

    '        'objects
    '        Dim CampaignList As Generic.List(Of AdvantageFramework.Database.Classes.Campaign) = Nothing

    '        CampaignList = New Generic.List(Of AdvantageFramework.Database.Classes.Campaign)

    '        For Each Campaign In DataGridViewExportCriteria_Campaigns.GetAllRowsDataBoundItems

    '            CampaignList.Add(New AdvantageFramework.Database.Classes.Campaign(Campaign.ID, Campaign.Client, Campaign.Code, Campaign.Campaign))

    '        Next

    '        AddCampaignCriteria(CampaignList, True)

    '    End Sub
    '    Private Sub ButtonExportCriteriaCampaign_RemoveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_RemoveSelected.Click

    '        RemoveCampaignCriteria(DataGridViewExportCriteria_SelectedCampaigns.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList)

    '    End Sub
    '    Private Sub ButtonExportCriteriaCampaign_RemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCriteriaCampaign_RemoveAll.Click

    '        RemoveCampaignCriteria(DataGridViewExportCriteria_SelectedCampaigns.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.Campaign).ToList)

    '    End Sub
    '    Private Sub CheckBoxExport_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxExport_AutoStart.CheckedChanged

    '        If CheckBoxExport_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageExportWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageExportWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxExportCriteria_DatabaseProfiles_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxExportCriteria_DatabaseProfiles.SelectedValueChanged

    '        'objects
    '        Dim SelectedDatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
    '        Dim ConnectionString As String = ""

    '        If ComboBoxExportCriteria_DatabaseProfiles.SelectedItem IsNot Nothing Then

    '            GroupBoxExportCriteria_SelectedCampaigns.Enabled = True

    '            _ExportSelectedDatabase = ComboBoxExportCriteria_DatabaseProfiles.SelectedItem.Name

    '            SelectedDatabaseProfile = ComboBoxExportCriteria_DatabaseProfiles.SelectedItem

    '            ConnectionString = SelectedDatabaseProfile.ConnectionString

    '            _ObjectContext = New AdvantageFramework.Database.DbContext(ConnectionString, "SYSTEM")

    '            ComboBoxExportCriteria_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(_ObjectContext)

    '            LoadExportClientCampaigns(_ExportSelectedDatabase)

    '        Else

    '            GroupBoxExportCriteria_SelectedCampaigns.Enabled = False

    '        End If

    '    End Sub
    '    Private Sub ComboBoxExportCriteria_Clients_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxExportCriteria_Clients.SelectedValueChanged

    '        If ComboBoxExportCriteria_Clients.SelectedItem IsNot Nothing Then

    '            LoadAvailableCampaigns()

    '        End If

    '    End Sub
    '    Private Sub DataGridViewExportDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewExportDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonExportDatabaseProfiles_Remove.Enabled = DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonExportDatabaseProfiles_Edit.Enabled = DataGridViewExportDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub DateTimeInputExportSettings_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInputExportSettings_RunAt.ValueChanged

    '        If _Initialized Then

    '            SaveExportSettings()

    '        End If

    '    End Sub

    '#End Region

    '#Region "   Task"

    '    Private Sub ButtonTask_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTask_Start.Click

    '        If AdvantageFramework.Services.Task.Start(DataGridViewTaskDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonTask_Start.Visible = False
    '            ButtonTask_Stop.Visible = True
    '            CheckBoxTask_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageTaskWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonTask_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTask_Stop.Click

    '        AdvantageFramework.Services.Task.Stop()

    '        ButtonTask_Start.Visible = True
    '        ButtonTask_Stop.Visible = False
    '        CheckBoxTask_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonTaskDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTaskDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.Task.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadTaskDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonTaskDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTaskDatabaseProfiles_Edit.Click

    '        If DataGridViewTaskDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewTaskDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewTaskDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadTaskDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonTaskDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTaskDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewTaskDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.Task.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadTaskDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonTaskDatabaseProfiles_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTaskDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.Task.ProcessDatabase(DataGridViewTaskDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub CheckBoxTaskSettings_PastDue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTaskSettings_PastDue.CheckedChanged

    '        If _Initialized Then

    '            UpdatePastDueSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxTaskSettings_Upcoming_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTaskSettings_Upcoming.CheckedChanged

    '        If _Initialized Then

    '            UpdateUpcomingSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxTask_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTask_AutoStart.CheckedChanged

    '        If CheckBoxTask_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageTaskWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageTaskWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub NumericInputTaskSettings_Upcoming_StartDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputTaskSettings_Upcoming_StartDays.EditValueChanged

    '        If NumericInputTaskSettings_Upcoming_StartDays.EditValue > NumericInputTaskSettings_Upcoming_EndDays.EditValue Then

    '            NumericInputTaskSettings_Upcoming_EndDays.EditValue = NumericInputTaskSettings_Upcoming_StartDays.EditValue

    '        End If

    '    End Sub
    '    Private Sub NumericInputTaskSettings_Upcoming_EndDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputTaskSettings_Upcoming_EndDays.EditValueChanged

    '        If NumericInputTaskSettings_Upcoming_EndDays.EditValue < NumericInputTaskSettings_Upcoming_StartDays.EditValue Then

    '            NumericInputTaskSettings_Upcoming_StartDays.EditValue = NumericInputTaskSettings_Upcoming_EndDays.EditValue

    '        End If

    '    End Sub
    '    Private Sub DataGridViewTaskDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewTaskDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonTaskDatabaseProfiles_Remove.Enabled = DataGridViewTaskDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonTaskDatabaseProfiles_Edit.Enabled = DataGridViewTaskDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub

    '#End Region

    '#Region "   Missing Time"

    '    Private Sub ButtonMissingTime_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTime_Start.Click

    '        If AdvantageFramework.Services.MissingTime.Start(DataGridViewMissingTimeDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonMissingTime_Start.Visible = False
    '            ButtonMissingTime_Stop.Visible = True
    '            CheckBoxMissingTime_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonMissingTime_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTime_Stop.Click

    '        AdvantageFramework.Services.MissingTime.Stop()

    '        ButtonMissingTime_Start.Visible = True
    '        ButtonMissingTime_Stop.Visible = False
    '        CheckBoxMissingTime_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonMissingTimeDatabaseProfiles_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTimeDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.MissingTime.ProcessDatabase(DataGridViewMissingTimeDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub ButtonMissingTimeDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTimeDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.MissingTime.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadMissingTimeAllSettings()

    '            End If

    '        End If
    '    End Sub
    '    Private Sub ButtonMissingTimeDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTimeDatabaseProfiles_Edit.Click

    '        If DataGridViewMissingTimeDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewMissingTimeDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewMissingTimeDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadMissingTimeDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonMissingTimeDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMissingTimeDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewMissingTimeDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.MissingTime.DeleteServiceSettings(DatabaseProfile.Name)
    '            AdvantageFramework.Services.MissingTime.DeleteProcessSettings(DatabaseProfile.Name)
    '            AdvantageFramework.Services.MissingTime.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadMissingTimeAllSettings()

    '    End Sub
    '    Private Sub CheckBoxMissingTime_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTime_AutoStart.CheckedChanged

    '        If CheckBoxMissingTime_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageMissingTimeWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_Interval_RunEvery_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_RunEvery.CheckedChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            UpdateMissingTimeIntervalRunEverySettings(CheckBoxMissingTimeSettings_Interval_RunEvery.Checked)

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_Interval_RunAt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_RunAt.CheckedChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            UpdateMissingTimeIntervalRunAtSettings(CheckBoxMissingTimeSettings_Interval_RunAt.Checked)

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_Interval_StopAfter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Interval_StopAfter.CheckedChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            UpdateMissingTimeIntervalStopAfterSettings((CheckBoxMissingTimeSettings_Interval_RunEvery.Checked) And (CheckBoxMissingTimeSettings_Interval_StopAfter.Checked))

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_Tracking_DontCountWeekends_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeAlerts_Recipient_Employee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_Employee.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            UpdateMissingTimeRecipientEmployeeSettings(CheckBoxMissingTimeAlerts_Recipient_Employee.Checked)

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeAlerts_Recipient_Supervisor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            UpdateMissingTimeRecipientSupervisorSettings(CheckBoxMissingTimeAlerts_Recipient_Supervisor.Checked)

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeAlerts_Recipient_ITContact_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            UpdateMissingTimeRecipientITContactSettings(CheckBoxMissingTimeAlerts_Recipient_ITContact.Checked)

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxMissingTimeSettings_Interval_RunDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMissingTimeSettings_Interval_RunDay.SelectedIndexChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxMissingTimeAlerts_DatabaseProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMissingTimeAlerts_DatabaseProfile.SelectedIndexChanged

    '        _SelectedDatabaseProfile = ComboBoxMissingTimeAlerts_DatabaseProfile.SelectedItem

    '        If _Initialized AndAlso _LoadingDatabaseProfiles = False Then

    '            ComboBoxMissingTimeSettings_DatabaseProfile.SelectedItem = _SelectedDatabaseProfile

    '            LoadMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxMissingTimeSettings_DatabaseProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMissingTimeSettings_DatabaseProfile.SelectedIndexChanged

    '        _SelectedDatabaseProfile = ComboBoxMissingTimeSettings_DatabaseProfile.SelectedItem

    '        If _Initialized AndAlso _LoadingDatabaseProfiles = False Then

    '            ComboBoxMissingTimeAlerts_DatabaseProfile.SelectedItem = _SelectedDatabaseProfile

    '            LoadMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub DateTimeInputMissingTimeSettings_Interval_RunAtTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInputMissingTimeSettings_Interval_RunAtTime.Click

    '        'If _Initialized AndAlso _LoadingServiceSettings = False Then

    '        '    SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        'End If

    '    End Sub
    '    Private Sub DateTimeInputMissingTimeSettings_Interval_RunAtTime_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimeInputMissingTimeSettings_Interval_RunAtTime.ValueChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeSettings_Interval_RunEveryHours_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValueChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeSettings_Interval_StopAfter_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Interval_StopAfter.EditValueChanged

    '        If _Initialized AndAlso _LoadingServiceSettings = False Then

    '            SaveMissingTimeServiceSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeSettings_Range_DaysToCheck_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeSettings_Range_DaysToCheck.EditValueChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValueChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValueChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValueChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub RadioButtonMissingTimeSettings_Priority_High_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_High.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            If RadioButtonMissingTimeSettings_Priority_High.Checked Then

    '                SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonMissingTimeSettings_Priority_Medium_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_Medium.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            If RadioButtonMissingTimeSettings_Priority_Medium.Checked Then

    '                SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonMissingTimeSettings_Priority_Low_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Priority_Low.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            If RadioButtonMissingTimeSettings_Priority_Low.Checked Then

    '                SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonMissingTimeSettings_Range_DaysToCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Range_DaysToCheck.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            If RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked Then

    '                UpdateMissingTimeRangeSettings(RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked)

    '                SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.CheckedChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            If RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Checked Then

    '                UpdateMissingTimeRangeSettings(RadioButtonMissingTimeSettings_Range_DaysToCheck.Checked)

    '                SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '            End If

    '        End If

    '    End Sub
    '    Private Sub TextBoxMissingTimeSettings_LogFilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxMissingTimeSettings_LogFilePath.TextChanged

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub TextBoxMissingTimeAlerts_CustomMessage_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxMissingTimeAlerts_CustomMessage.Validated

    '        If _Initialized AndAlso _LoadingProcessSettings = False Then

    '            SaveMissingTimeProcessSettings(_SelectedDatabaseProfile)

    '        End If

    '    End Sub

    '#End Region

    '#Region "   Google Calendar"

    '    Private Sub ButtonGoogleCalendarDatabaseProfiles_ProcessNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.GoogleCalendar.ProcessDatabase(DataGridViewGoogleCalendarDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub ButtonGoogleCalendarDatabaseProfiles_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendarDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Proflie In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.GoogleCalendar.SaveDatabaseProfile(Proflie, False)

    '                Next

    '                LoadGoogleCalendarDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonGoogleCalendarDatabaseProfiles_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendarDatabaseProfiles_Edit.Click

    '        If DataGridViewGoogleCalendarDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewGoogleCalendarDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewGoogleCalendarDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadGoogleCalendarDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonGoogleCalendarDatabaseProfiles_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendarDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewGoogleCalendarDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.GoogleCalendar.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadGoogleCalendarDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonGoogleCalendar_Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendar_Start.Click

    '        If AdvantageFramework.Services.GoogleCalendar.Start Then

    '            ButtonGoogleCalendar_Start.Visible = False
    '            ButtonGoogleCalendar_Stop.Visible = True
    '            CheckBoxGoogleCalendar_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonGoogleCalendar_Stop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonGoogleCalendar_Stop.Click

    '        AdvantageFramework.Services.GoogleCalendar.Stop()

    '        ButtonGoogleCalendar_Start.Visible = True
    '        ButtonGoogleCalendar_Stop.Visible = False
    '        CheckBoxGoogleCalendar_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub CheckBoxGoogleCalendar_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxGoogleCalendar_AutoStart.CheckedChanged

    '        If CheckBoxGoogleCalendar_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageGoogleCalendarWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewGoogleCalendarDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewGoogleCalendarDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonGoogleCalendarDatabaseProfiles_Remove.Enabled = DataGridViewGoogleCalendarDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonGoogleCalendarDatabaseProfiles_Edit.Enabled = DataGridViewGoogleCalendarDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub NumericInputGoogleCalendarSettings_RunAt_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputGoogleCalendarSettings_RunAt.EditValueChanged

    '        If _Initialized Then

    '            SaveGoogleCalendarSettings()

    '        End If

    '    End Sub

    '#End Region

    '#Region "   Core Media Check Export"

    '    Private Sub TextBoxCoreMediaCheckExportSettings_ExportPath_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxCoreMediaCheckExportSettings_ExportPath.Validated

    '        SaveCoreMediaCheckExportSettings()

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExport_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExport_Start.Click

    '        If AdvantageFramework.Services.CoreMediaCheckExport.Start(DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonCoreMediaCheckExport_Start.Visible = False
    '            ButtonCoreMediaCheckExport_Stop.Visible = True
    '            CheckBoxCoreMediaCheckExport_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExport_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExport_Stop.Click

    '        AdvantageFramework.Services.CoreMediaCheckExport.Stop()

    '        ButtonCoreMediaCheckExport_Start.Visible = True
    '        ButtonCoreMediaCheckExport_Stop.Visible = False
    '        CheckBoxCoreMediaCheckExport_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExportDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExportDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.CoreMediaCheckExport.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadCoreMediaCheckExportDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExportDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Click

    '        If DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadCoreMediaCheckExportDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExportDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.CoreMediaCheckExport.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadCoreMediaCheckExportDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.CoreMediaCheckExport.ProcessDatabase(DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub CheckBoxCoreMediaCheckExport_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCoreMediaCheckExport_AutoStart.CheckedChanged

    '        If CheckBoxCoreMediaCheckExport_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageCoreMediaCheckExportWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Enabled = DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Enabled = DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub DateTimeInputCoreMediaCheckExportSettings_RunAt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeInputCoreMediaCheckExportSettings_RunAt.ValueChanged

    '        If _Initialized Then

    '            SaveCoreMediaCheckExportSettings()

    '        End If

    '    End Sub

    '#End Region

    '#Region "   Paid Time Off Accruals"

    '    Private Sub ButtonPaidTimeOffAccruals_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccruals_Start.Click

    '        If AdvantageFramework.Services.PaidTimeOffAccruals.Start(DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonPaidTimeOffAccruals_Start.Visible = False
    '            ButtonPaidTimeOffAccruals_Stop.Visible = True
    '            CheckBoxPaidTimeOffAccruals_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonPaidTimeOffAccruals_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccruals_Stop.Click

    '        AdvantageFramework.Services.PaidTimeOffAccruals.Stop()

    '        ButtonPaidTimeOffAccruals_Start.Visible = True
    '        ButtonPaidTimeOffAccruals_Stop.Visible = False
    '        CheckBoxPaidTimeOffAccruals_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonPaidTimeOffAccrualsDatabaseProfiles_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.PaidTimeOffAccruals.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadPaidTimeOffAccrualsDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Click

    '        If DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadPaidTimeOffAccrualsDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.PaidTimeOffAccruals.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadPaidTimeOffAccrualsDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Click

    '        'objects
    '        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
    '        Dim Process As Boolean = False

    '        Try

    '            DatabaseProfile = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem

    '        Catch ex As Exception
    '            DatabaseProfile = Nothing
    '        End Try

    '        If DatabaseProfile IsNot Nothing Then

    '            Using DbContext = New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, "SYSTEM")

    '                If DbContext.ExecuteStoreQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.TIME_RULE_LOG WHERE PROCESS_MONTH = {0} AND PROCESS_YEAR = {1}", Now.Month, Now.Year)).FirstOrDefault > 1 Then

    '                    If AdvantageFramework.WinForm.MessageBox.Show("You have already processed accruals for the current month.  Repeating this process can lead to unintended results. " & vbCrLf & vbCrLf & "Are you sure you wish to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

    '                        Process = True

    '                    End If

    '                Else

    '                    Process = True

    '                End If

    '                If Process Then

    '                    AdvantageFramework.Services.PaidTimeOffAccruals.ProcessDatabase(DatabaseProfile)

    '                End If

    '            End Using

    '        Else

    '            AdvantageFramework.WinForm.MessageBox.Show("Please select a valid database profile.")

    '        End If

    '    End Sub
    '    Private Sub CheckBoxPaidTimeOffAccruals_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPaidTimeOffAccruals_AutoStart.CheckedChanged

    '        If CheckBoxPaidTimeOffAccruals_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantagePaidTimeOffAccrualsWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases_SelectionChangedEvent(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Enabled = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Enabled = DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub ComboBoxPaidTimeOffAccrualsSettings_RunOnDay_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SelectedValueChanged

    '        If _Initialized Then

    '            SavePaidTimeOffAccrualsSettings()

    '        End If

    '    End Sub
    '    Private Sub ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.SelectedValueChanged

    '        'objects
    '        Dim UserCode As String = ""
    '        Dim ProcessDate As Date = Nothing

    '        If ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.HasASelectedValue Then

    '            Try

    '                Using DbContext = New AdvantageFramework.Database.DbContext(ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.SelectedValue, "SYSTEM")

    '                    If DbContext.ExecuteStoreQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.TIME_RULE_LOG WHERE PROCESS_MONTH = {0} AND PROCESS_YEAR = {1}", Now.Month, Now.Year)).FirstOrDefault = 1 Then

    '                        Try

    '                            UserCode = DbContext.ExecuteStoreQuery(Of String)(String.Format("SELECT PROCESSED_BY FROM dbo.TIME_RULE_LOG WHERE PROCESS_MONTH = {0} AND PROCESS_YEAR = {1}", Now.Month, Now.Year)).FirstOrDefault

    '                        Catch ex As Exception
    '                            UserCode = ""
    '                        End Try

    '                        Try

    '                            ProcessDate = DbContext.ExecuteStoreQuery(Of Date)(String.Format("SELECT LOG_DATETIME_STAMP FROM dbo.TIME_RULE_LOG WHERE PROCESS_MONTH = {0} AND PROCESS_YEAR = {1}", Now.Month, Now.Year)).FirstOrDefault

    '                        Catch ex As Exception
    '                            ProcessDate = Now
    '                        End Try

    '                        LabelPaidTimeOffAccrualsSettings_LastRanDetails.Text = String.Format("Accruals were last processed for {0}/{1} by {2} on {3}.", Now.Month, Now.Year, UserCode, ProcessDate.ToShortDateString)

    '                    End If

    '                End Using

    '            Catch ex As Exception
    '                LabelPaidTimeOffAccrualsSettings_LastRanDetails.Text = ""
    '            End Try

    '        Else

    '            LabelPaidTimeOffAccrualsSettings_LastRanDetails.Text = ""

    '        End If

    '    End Sub

    '#End Region

    '#Region "   Contract"

    '    Private Sub ButtonContract_Start_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContract_Start.Click

    '        If AdvantageFramework.Services.Contract.Start(DataGridViewContractDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonContract_Start.Visible = False
    '            ButtonContract_Stop.Visible = True
    '            CheckBoxContract_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageContractWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonContract_Stop_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContract_Stop.Click

    '        AdvantageFramework.Services.Contract.Stop()

    '        ButtonContract_Start.Visible = True
    '        ButtonContract_Stop.Visible = False
    '        CheckBoxContract_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonContractDatabaseProfiles_Select_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContractDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.Contract.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadContractDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonContractDatabaseProfiles_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContractDatabaseProfiles_Edit.Click

    '        If DataGridViewContractDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewContractDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewContractDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadContractDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonContractDatabaseProfiles_Remove_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContractDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewContractDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.Contract.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadContractDatabaseProfiles()

    '    End Sub
    '    Private Sub ButtonContractDatabaseProfiles_ProcessNow_Click(sender As System.Object, e As System.EventArgs) Handles ButtonContractDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.Contract.ProcessDatabase(DataGridViewContractDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub CheckBoxContract_AutoStart_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxContract_AutoStart.CheckedChanged

    '        If CheckBoxContract_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageContractWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageContractWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewContractDatabaseProfiles_Databases_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewContractDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonContractDatabaseProfiles_Remove.Enabled = DataGridViewContractDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonContractDatabaseProfiles_Edit.Enabled = DataGridViewContractDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub DateTimeInputContractAlertSettings_RunAt_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimeInputContractAlertSettings_RunAt.ValueChanged

    '        If _Initialized Then

    '            SaveContractAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub NumericInputContractSettings_RenewalDaysPrior_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericInputContractSettings_RenewalDaysPrior.EditValueChanged

    '        If _Initialized Then

    '            SaveContractAlertSettings()

    '        End If

    '    End Sub
    '    Private Sub CheckBoxContractSettings_ContractRenewal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxContractSettings_ContractRenewal.CheckedChanged

    '        If _Initialized Then

    '            SaveContractAlertSettings()

    '        End If

    '    End Sub

    '#End Region

    '#Region "  Media Ocean Import "

    '    Private Sub ButtonMediaOceanImport_Start_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImport_Start.Click

    '        If AdvantageFramework.Services.MediaOceanImport.Start(DataGridViewMediaOceanImportDatabaseProfiles_Databases.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile).ToList) Then

    '            ButtonMediaOceanImport_Start.Visible = False
    '            ButtonMediaOceanImport_Stop.Visible = True
    '            CheckBoxMediaOceanImport_AutoStart.Enabled = False

    '        Else

    '            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService.ToString()) & " cannot be started.")

    '        End If

    '    End Sub
    '    Private Sub ButtonMediaOceanImport_Stop_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImport_Stop.Click

    '        AdvantageFramework.Services.MediaOceanImport.Stop()

    '        ButtonMediaOceanImport_Start.Visible = True
    '        ButtonMediaOceanImport_Stop.Visible = False
    '        CheckBoxMediaOceanImport_AutoStart.Enabled = True

    '    End Sub
    '    Private Sub ButtonMediaOceanImportDatabaseProfiles_Select_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportDatabaseProfiles_Select.Click

    '        'objects
    '        Dim SelectedProfiles As IEnumerable = Nothing

    '        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, True, True, SelectedProfiles) = Windows.Forms.DialogResult.OK Then

    '            If SelectedProfiles IsNot Nothing Then

    '                For Each Profile In SelectedProfiles.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '                    AdvantageFramework.Services.MediaOceanImport.SaveDatabaseProfile(Profile, False)

    '                Next

    '                LoadMediaOceanImportAllSettings()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonMediaOceanImportDatabaseProfiles_Edit_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportDatabaseProfiles_Edit.Click

    '        If DataGridViewMediaOceanImportDatabaseProfiles_Databases.HasASelectedRow Then

    '            If TypeOf DataGridViewMediaOceanImportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem Is AdvantageFramework.Database.DatabaseProfile Then

    '                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewMediaOceanImportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '                LoadMediaOceanImportDatabaseProfiles()

    '            End If

    '        End If

    '    End Sub
    '    Private Sub ButtonMediaOceanImportDatabaseProfiles_Remove_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportDatabaseProfiles_Remove.Click

    '        For Each DatabaseProfile In DataGridViewMediaOceanImportDatabaseProfiles_Databases.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.DatabaseProfile)()

    '            AdvantageFramework.Services.MediaOceanImport.DeleteServiceSettings(DatabaseProfile.Name)
    '            AdvantageFramework.Services.MediaOceanImport.DeleteDatabaseProfile(DatabaseProfile.Name)

    '        Next

    '        LoadMediaOceanImportAllSettings()

    '    End Sub
    '    Private Sub ButtonMediaOceanImportDatabaseProfiles_ProcessNow_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Click

    '        AdvantageFramework.Services.MediaOceanImport.ProcessDatabase(DataGridViewMediaOceanImportDatabaseProfiles_Databases.GetFirstSelectedRowDataBoundItem)

    '    End Sub
    '    Private Sub CheckBoxMediaOceanImport_AutoStart_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxMediaOceanImport_AutoStart.CheckedChanged

    '        If CheckBoxMediaOceanImport_AutoStart.Checked Then

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService, AdvantageFramework.Services.ServiceStartupType.Automatic)

    '        Else

    '            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.Service.AdvantageMediaOceanImportWindowsService, AdvantageFramework.Services.ServiceStartupType.Manual)

    '        End If

    '    End Sub
    '    Private Sub DataGridViewMediaOceanImportDatabaseProfiles_Databases_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewMediaOceanImportDatabaseProfiles_Databases.SelectionChangedEvent

    '        ButtonMediaOceanImportDatabaseProfiles_Remove.Enabled = DataGridViewMediaOceanImportDatabaseProfiles_Databases.HasASelectedRow
    '        ButtonMediaOceanImportDatabaseProfiles_Edit.Enabled = DataGridViewMediaOceanImportDatabaseProfiles_Databases.HasASelectedRow

    '    End Sub
    '    Private Sub DateTimeInputMediaOceanImportSettings_RunAt_ValueChanged(sender As Object, e As System.EventArgs) Handles DateTimeInputMediaOceanImportSettings_RunAt.ValueChanged

    '        If _Initialized And _MOILoadingServiceSettings = False Then

    '            AdvantageFramework.Services.MediaOceanImport.SaveSettings(DateTimeInputMediaOceanImportSettings_RunAt.Value)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxMediaOceanImportSettings_DatabaseProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaOceanImportSettings_DatabaseProfile.SelectedIndexChanged

    '        _MOISelectedDatabaseProfile = ComboBoxMediaOceanImportSettings_DatabaseProfile.SelectedItem

    '        If _Initialized AndAlso _MOILoadingDatabaseProfiles = False Then

    '            LoadMediaOceanImportSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub TextBoxMediaOceanImportSettings_LocalFolder_Validated(sender As Object, e As System.EventArgs) Handles TextBoxMediaOceanImportSettings_LocalFolder.Validated

    '        If _Initialized AndAlso _MOILoadingServiceSettings = False Then

    '            SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub ComboBoxMediaOceanImportSettings_Employee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaOceanImportSettings_Employee.SelectedIndexChanged

    '        If _Initialized AndAlso _MOILoadingServiceSettings = False Then

    '            SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub TextBoxMediaOceanImportSettings_FTPAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPAddress.TextChanged

    '        If _Initialized AndAlso _MOILoadingServiceSettings = False Then

    '            SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub TextBoxMediaOceanImportSettings_FTPUser_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPUser.TextChanged

    '        If _Initialized AndAlso _MOILoadingServiceSettings = False Then

    '            SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub TextBoxMediaOceanImportSettings_FTPPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxMediaOceanImportSettings_FTPPassword.TextChanged

    '        If _Initialized AndAlso _MOILoadingServiceSettings = False Then

    '            SaveMediaOceanImportServiceSettings(_MOISelectedDatabaseProfile)

    '        End If

    '    End Sub
    '    Private Sub ButtonMediaOceanImportSettings_ValidateFTP_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaOceanImportSettings_ValidateFTP.Click

    '        Dim ErrorMessage As String = Nothing

    '        If AdvantageFramework.FTP.ValidateFTP(TextBoxMediaOceanImportSettings_FTPAddress.Text, TextBoxMediaOceanImportSettings_FTPUser.Text, TextBoxMediaOceanImportSettings_FTPPassword.Text, False, ErrorMessage) Then

    '            MsgBox("FTP Validated!")

    '        Else

    '            MsgBox("Could not validate FTP!")

    '        End If

    '    End Sub

    '#End Region

    '#End Region

#End Region

End Class