Public Class AdvantageConnectionConfiguratorForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected Friend _SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator = Nothing
    Protected Friend _ErrorProvider As System.Windows.Forms.ErrorProvider = Nothing
    Protected Friend _Highlighter As DevComponents.DotNetBar.Validator.Highlighter = Nothing
    Private _SaveEnabled As Boolean = False
    Private _ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
    Private _AdvantageConfigurator As AdvantageFramework.WinForm.AdvantageConfigurator = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetupValidatorAndHighlighControls()

    End Sub
    Private Sub SetupValidatorAndHighlighControls()

        Me.SuspendLayout()

        _SuperValidator = New DevComponents.DotNetBar.Validator.SuperValidator
        _ErrorProvider = New System.Windows.Forms.ErrorProvider
        _Highlighter = New DevComponents.DotNetBar.Validator.Highlighter

        _SuperValidator.CancelValidatingOnControl = False
        _SuperValidator.ContainerControl = Me
        _SuperValidator.Enabled = True
        _SuperValidator.ErrorProvider = _ErrorProvider
        _SuperValidator.Highlighter = _Highlighter
        _SuperValidator.SteppedValidation = True
        _SuperValidator.ValidationType = DevComponents.DotNetBar.Validator.eValidationType.ValidatingEventPerControl
        _SuperValidator.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

        _ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        _ErrorProvider.ContainerControl = Me

        _Highlighter.ContainerControl = Me
        _Highlighter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"

        Me.ResumeLayout(True)

    End Sub
    Protected Sub ClearValidations()

        If _SuperValidator IsNot Nothing Then

            _SuperValidator.ClearFailedValidations()

        End If

    End Sub
    Protected Function Validator() As Boolean

        'objects
        Dim IsValid As Boolean = True

        If _SuperValidator IsNot Nothing Then

            IsValid = _SuperValidator.Validate()

        End If

        Validator = IsValid

    End Function
    Private Sub LoadSettings()

        _ConnectionDatabaseProfileList = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

        For Each ConnectionDatabaseProfile In _ConnectionDatabaseProfileList

            ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

        Next

        _AdvantageConfigurator = AdvantageFramework.WinForm.AdvantageConfigurator.Load

        ButtonItemNTAuth_AutoEnable.Checked = _AdvantageConfigurator.NTAuthAutoEnable

        DataGridViewForm_ConnectionDatabaseProfiles.DataSource = _ConnectionDatabaseProfileList

        DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.BestFitColumns()

        'If DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.Columns("Password") IsNot Nothing Then

        '    DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.Columns("Password").ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways

        'End If

    End Sub
    Private Sub SaveSettings(ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile))

        'objects
        Dim StreamWriter As System.IO.StreamWriter = Nothing
        Dim IsValid As Boolean = True
        Dim CDPList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
        Dim CDP As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim XMLFile As String = String.Empty
        Dim XML As String = String.Empty

        _AdvantageConfigurator.NTAuthAutoEnable = ButtonItemNTAuth_AutoEnable.Checked

        Try

            XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.WinForm.AdvantageConfigurator.AdvantageConfigurationFileName

            XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(AdvantageFramework.WinForm.AdvantageConfigurator))

            StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(XMLFile, False)

            XmlSerializer.Serialize(StreamWriter, _AdvantageConfigurator)

        Catch ex As Exception

        End Try

        XmlSerializer = Nothing

        If StreamWriter IsNot Nothing Then

            StreamWriter.Close()

            StreamWriter.Dispose()

        End If

        StreamWriter = Nothing

        CDPList = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

        Try

            For Each ConnectionDatabaseProfile In ConnectionDatabaseProfileList

                IsValid = True

                ConnectionDatabaseProfile.ValidateEntity(IsValid)

                If IsValid = False Then

                    Exit For

                Else

                    CDP = ConnectionDatabaseProfile.Copy

                    CDP.Password = AdvantageFramework.Security.Encryption.Encrypt(CDP.Password)

                    CDPList.Add(CDP)

                End If

            Next

            If IsValid Then

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(CDPList.GetType())

                StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & AdvantageFramework.Security.AdvantageConnectionConfigurationFileName, False)

                XmlSerializer.Serialize(StreamWriter, CDPList)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("One or more settings are invalid. Please fix errors and try again.")

            End If

        Catch ex As Exception
            AdvantageFramework.WinForm.MessageBox.Show("Error saving settings.")
        Finally

            If StreamWriter IsNot Nothing Then

                StreamWriter.Close()

                StreamWriter.Dispose()

            End If

            StreamWriter = Nothing

        End Try

    End Sub
    Private Sub DeleteSettings()

        DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.CloseEditor()

        For Each RowHandle In DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.GetSelectedRows

            DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.DeleteRow(RowHandle)

        Next

        'SaveSettings()

        'LoadSettings()

    End Sub
    Private Sub CloseGridEditorAndSaveValueToDataSource()

        If DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.PostEditor() Then

            DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.UpdateCurrentRow()

        End If

    End Sub
    Private Sub AddNewRowEvent(RowObject As Object)

        'objects
        Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        If TypeOf RowObject Is AdvantageFramework.Database.ConnectionDatabaseProfile Then

            ConnectionDatabaseProfileList = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

            For Each ConnectionDatabaseProfile In ConnectionDatabaseProfileList

                ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

            Next

            ConnectionDatabaseProfile = CType(RowObject, AdvantageFramework.Database.ConnectionDatabaseProfile).Copy

            ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

            SaveSettings(ConnectionDatabaseProfileList)

            'ButtonItemActions_Save.Enabled = True
            '_SaveEnabled = True

        End If

    End Sub
    Private Sub RepositoryItemButtonEdit_Click(sender As Object, e As EventArgs)

        'objects
        Dim EditorButton As DevExpress.XtraEditors.Controls.EditorButton = Nothing
        Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

        If TypeOf sender Is DevExpress.XtraEditors.Controls.EditorButton Then

            EditorButton = sender

            RepositoryItemButtonEdit = EditorButton.Tag

            If RepositoryItemButtonEdit.UseSystemPasswordChar Then

                RepositoryItemButtonEdit.UseSystemPasswordChar = False

            Else


                RepositoryItemButtonEdit.UseSystemPasswordChar = True

            End If

        End If

    End Sub
    Protected Sub LoadStartUpInformation(ByRef CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String))

        'objects
        Dim CommandLineMode As Boolean = False
        Dim ServerName As String = ""
        Dim DatabaseName As String = ""
        Dim UserName As String = ""
        Dim Password As String = ""
        Dim IsValid As Boolean = True
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        For Each CommandLine In CommandLineArgs

            If CommandLine.StartsWith("-s") Then

                ServerName = CommandLine.Replace("-s", "")

            ElseIf CommandLine.StartsWith("-d") Then

                DatabaseName = CommandLine.Replace("-d", "")

            ElseIf CommandLine.StartsWith("-u") Then

                UserName = CommandLine.Replace("-u", "")

            ElseIf CommandLine.StartsWith("-p") Then

                Password = CommandLine.Replace("-p", "")

            ElseIf CommandLine.StartsWith("-x") Then

                CommandLineMode = True

            End If

        Next

        If CommandLineMode Then

            LoadSettings()

            ConnectionDatabaseProfile = New AdvantageFramework.Database.ConnectionDatabaseProfile With {.ServerName = ServerName, .DatabaseName = DatabaseName, .UserName = UserName, .Password = Password}

            ConnectionDatabaseProfile.ValidateEntity(IsValid)

            If IsValid Then

                If _ConnectionDatabaseProfileList.Any(Function(Entity) Entity.DatabaseName = ConnectionDatabaseProfile.DatabaseName) Then

                    IsValid = False

                End If

            End If

            If IsValid Then

                _ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                SaveSettings(_ConnectionDatabaseProfileList)

            End If

            System.Windows.Forms.Application.Exit()

        End If

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageConfiguratorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

        Catch ex As Exception

            Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

        End Try

        ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
        ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
        ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
        ButtonItemActions_Validate.Image = AdvantageFramework.My.Resources.ReviewAllImage

        ButtonItemNTAuth_AutoEnable.Image = AdvantageFramework.My.Resources.PowerOnImage

        DataGridViewForm_ConnectionDatabaseProfiles.MultiSelect = False
        DataGridViewForm_ConnectionDatabaseProfiles.RunStandardValidation = False

        ButtonItemActions_Delete.Enabled = False
        ButtonItemActions_Cancel.Enabled = False
        ButtonItemActions_Validate.Enabled = False

        LoadStartUpInformation(My.Application.CommandLineArgs)

        LoadSettings()

        ButtonItemActions_Save.Enabled = False
        _SaveEnabled = False

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

        CloseGridEditorAndSaveValueToDataSource()

        If DataGridViewForm_ConnectionDatabaseProfiles.HasASelectedRow Then

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                DeleteSettings()

                ButtonItemActions_Save.Enabled = True
                _SaveEnabled = True

            End If

        End If

    End Sub
    Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

        CloseGridEditorAndSaveValueToDataSource()

        DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.CloseEditor()

        DataGridViewForm_ConnectionDatabaseProfiles.ValidateAllRows()

        If DataGridViewForm_ConnectionDatabaseProfiles.HasAnyInvalidRows() = False Then

            SaveSettings(DataGridViewForm_ConnectionDatabaseProfiles.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.ConnectionDatabaseProfile).ToList)

            ButtonItemActions_Save.Enabled = False
            _SaveEnabled = False

        Else

            AdvantageFramework.WinForm.MessageBox.Show("Please fix invalid rows before continuing.")

        End If

    End Sub
    Private Sub ButtonItemActions_Validate_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Validate.Click

        'objects
        Dim IsValid As Boolean = True
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        CloseGridEditorAndSaveValueToDataSource()

        ConnectionDatabaseProfile = DataGridViewForm_ConnectionDatabaseProfiles.GetFirstSelectedRowDataBoundItem

        IsValid = True

        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Validating...")

        ConnectionDatabaseProfile.ValidateEntity(IsValid)

        If IsValid Then

            If AdvantageFramework.Database.ValidateServerAndDatabase(ConnectionDatabaseProfile.ServerName, ConnectionDatabaseProfile.DatabaseName, False, ConnectionDatabaseProfile.UserName,
                                                                     ConnectionDatabaseProfile.Password, "Advantage", False, "") Then

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show(Me, ConnectionDatabaseProfile.ToString & " is valid")

            Else

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                AdvantageFramework.WinForm.MessageBox.Show(Me, "Validation failed for " & ConnectionDatabaseProfile.ToString)

            End If

        End If

    End Sub
    Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

        If DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow Then

            DataGridViewForm_ConnectionDatabaseProfiles.CancelNewItemRow()

        End If

    End Sub
    Private Sub ButtonItemNTAuth_AutoEnable_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemNTAuth_AutoEnable.CheckedChanged

        ButtonItemActions_Save.Enabled = True
        _SaveEnabled = True

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.CellValueChangedEvent

        If DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow(DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.FocusedRowHandle) = False Then

            ButtonItemActions_Save.Enabled = True
            _SaveEnabled = True

        End If

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.ShowingEditorEvent

        'If DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow(DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.FocusedRowHandle) = False Then

        '    If DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.FocusedColumn IsNot Nothing AndAlso DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.FocusedColumn.FieldName = "Password" Then

        '        e.Cancel = True

        '    End If

        'End If

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_ConnectionDatabaseProfiles.AddNewRowEvent

        ''objects
        'Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        'Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        'If TypeOf RowObject Is AdvantageFramework.Database.ConnectionDatabaseProfile Then

        '    ConnectionDatabaseProfileList = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage(True)

        '    ConnectionDatabaseProfile = CType(RowObject, AdvantageFramework.Database.ConnectionDatabaseProfile).Copy

        '    ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

        '    SaveSettings(ConnectionDatabaseProfileList)

        '    'ButtonItemActions_Save.Enabled = True
        '    '_SaveEnabled = True

        'End If

        AddNewRowEvent(RowObject)

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.InitNewRowEvent

        ButtonItemActions_Cancel.Enabled = True

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_NewItemRowCanceledEvent() Handles DataGridViewForm_ConnectionDatabaseProfiles.NewItemRowCanceledEvent

        ButtonItemActions_Cancel.Enabled = False

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.CustomRowCellEditEvent

        If e.Column.FieldName = "Password" Then

            If TypeOf e.RepositoryItem Is DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit Then

                CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).UseSystemPasswordChar = True

                'If CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Buttons.Count = 0 Then

                '    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search))

                '    CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Buttons(0).Tag = e.RepositoryItem

                '    AddHandler CType(e.RepositoryItem, DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit).Buttons(0).Click, AddressOf RepositoryItemButtonEdit_Click

                'End If

            End If

        End If

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.SelectionChangedEvent

        If DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow Then

            ButtonItemActions_Save.Enabled = False

        Else

            ButtonItemActions_Save.Enabled = _SaveEnabled

        End If

        ButtonItemActions_Cancel.Enabled = DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow
        ButtonItemActions_Delete.Enabled = DataGridViewForm_ConnectionDatabaseProfiles.HasASelectedRow
        ButtonItemActions_Validate.Enabled = DataGridViewForm_ConnectionDatabaseProfiles.HasASelectedRow

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.ValidatingEditorEvent

        Dim FocusedRow As Object = Nothing

        FocusedRow = DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.GetFocusedRow

        If FocusedRow IsNot Nothing Then

            If TypeOf FocusedRow Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

                e.ErrorText = DirectCast(FocusedRow, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntityProperty(DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End If

    End Sub
    Private Sub DataGridViewForm_ConnectionDatabaseProfiles_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_ConnectionDatabaseProfiles.ValidateRowEvent

        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

        If TypeOf e.Row Is AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase Then

            e.ErrorText = DirectCast(e.Row, AdvantageFramework.BaseClasses.Interfaces.IValidatingClassBase).ValidateEntity(e.Valid)

            ConnectionDatabaseProfile = e.Row

            If _ConnectionDatabaseProfileList.Any(Function(Entity) Entity.GUID <> ConnectionDatabaseProfile.GUID AndAlso
                                                                   Entity.DatabaseName.ToUpper = ConnectionDatabaseProfile.DatabaseName.ToUpper) Then

                ConnectionDatabaseProfile.SetError("Please enter an unique database name.")

                e.Valid = False

            End If

            If DataGridViewForm_ConnectionDatabaseProfiles.IsNewItemRow(e.RowHandle) = False Then

                e.Valid = True

            Else

                DataGridViewForm_ConnectionDatabaseProfiles.CurrentView.NewItemRowText = e.ErrorText

                If e.Valid Then

                    AddNewRowEvent(e.Row)

                End If

            End If

        End If

    End Sub

#End Region

#End Region

End Class
