Public Class AdvantageConfiguratorForm

#Region " Constants "

    Private Const _AdvantageConfigurationFileName As String = "AdvantageConfiguration.xml"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected Friend _SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator = Nothing
    Protected Friend _ErrorProvider As System.Windows.Forms.ErrorProvider = Nothing
    Protected Friend _Highlighter As DevComponents.DotNetBar.Validator.Highlighter = Nothing

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

        DataGridViewForm_SimpleDatabaseProfiles.DataSource = AdvantageFramework.Database.LoadSimpleDatabaseProfileList()

        DataGridViewForm_SimpleDatabaseProfiles.CurrentView.BestFitColumns()

    End Sub
    Private Sub SaveSettings()

        'objects
        Dim StreamWriter As System.IO.StreamWriter = Nothing
        Dim IsValid As Boolean = True
        Dim SimpleDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.SimpleDatabaseProfile) = Nothing
        Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing

        SimpleDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.SimpleDatabaseProfile)

        Try

            DataGridViewForm_SimpleDatabaseProfiles.CurrentView.CloseEditor()

            For Each SimpleDatabaseProfile In DataGridViewForm_SimpleDatabaseProfiles.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.SimpleDatabaseProfile)()

                IsValid = True

                SimpleDatabaseProfile.ValidateEntity(IsValid)

                If IsValid = False Then

                    Exit For

                Else

                    SimpleDatabaseProfileList.Add(SimpleDatabaseProfile)

                End If

            Next

            If IsValid Then

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(SimpleDatabaseProfileList.GetType())

                StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & _AdvantageConfigurationFileName, False)

                XmlSerializer.Serialize(StreamWriter, SimpleDatabaseProfileList)

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

        DataGridViewForm_SimpleDatabaseProfiles.CurrentView.CloseEditor()

        For Each RowHandle In DataGridViewForm_SimpleDatabaseProfiles.CurrentView.GetSelectedRows

            DataGridViewForm_SimpleDatabaseProfiles.CurrentView.DeleteRow(RowHandle)

        Next

        SaveSettings()

        LoadSettings()

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
        ButtonItemActions_Validate.Image = AdvantageFramework.My.Resources.ReviewAllImage

        LoadSettings()

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonItemActions_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Delete.Click

        DeleteSettings()

    End Sub
    Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

        SaveSettings()

    End Sub
    Private Sub ButtonItemActions_Validate_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Validate.Click

        'objects
        Dim IsValid As Boolean = True

        DataGridViewForm_SimpleDatabaseProfiles.CurrentView.CloseEditor()

        For Each SimpleDatabaseProfile In DataGridViewForm_SimpleDatabaseProfiles.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.SimpleDatabaseProfile)()

            IsValid = True

            SimpleDatabaseProfile.ValidateEntity(IsValid)

            If IsValid Then

                If AdvantageFramework.Database.ValidateServerAndDatabase(SimpleDatabaseProfile.ServerName, SimpleDatabaseProfile.DatabaseName, False, "SYSADM", "sysadm", "Advantage", False, "") Then

                    AdvantageFramework.WinForm.MessageBox.Show(SimpleDatabaseProfile.ToString & " is valid")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Validation failed for " & SimpleDatabaseProfile.ToString)

                End If

            End If

        Next

    End Sub

#End Region

#End Region

End Class