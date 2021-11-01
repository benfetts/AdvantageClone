Partial Public Class CreateAdvantageConnectionPage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property AdvantageConnectionFolder As String
        Get
            AdvantageConnectionFolder = ButtonEditForm_Folder.Text
        End Get
        Set(value As String)
            ButtonEditForm_Folder.Text = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Function LoadConnectionDatabaseProfileList(XMLFile As String) As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

        'objects
        Dim XmlTextReader As System.Xml.XmlTextReader = Nothing
        Dim XML As String = String.Empty
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing

        'XMLFile = AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & "AdvantageConnectionConfiguration.xml"

        ConnectionDatabaseProfileList = New Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile)

        If My.Computer.FileSystem.FileExists(XMLFile) Then

            Try

                XmlTextReader = New System.Xml.XmlTextReader(XMLFile)

                Do Until XmlTextReader.Read() = False

                    If XmlTextReader.Name = "ConnectionDatabaseProfile" Then

                        XML = XmlTextReader.ReadOuterXml

                        ConnectionDatabaseProfile = AdvantageFramework.BaseClasses.ImportFromXML(XML, GetType(AdvantageFramework.Database.ConnectionDatabaseProfile))

                        If ConnectionDatabaseProfile IsNot Nothing Then

                            ConnectionDatabaseProfile.Password = AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)

                            ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                        End If

                    End If

                Loop

            Catch ex As Exception
                XML = ""
            Finally

                If XmlTextReader IsNot Nothing Then

                    XmlTextReader.Close()

                End If

                XmlTextReader = Nothing

            End Try

        End If

        LoadConnectionDatabaseProfileList = ConnectionDatabaseProfileList

    End Function
    Private Function SaveConnectionDatabaseProfileList(XMLFile As String, ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile), ByRef ErrorMessage As String) As Boolean

        'objects
        Dim Saved As Boolean = False
        Dim StreamWriter As System.IO.StreamWriter = Nothing
        Dim IsValid As Boolean = True
        Dim CDPList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
        Dim CDP As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing

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

                StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(XMLFile, False)

                XmlSerializer.Serialize(StreamWriter, CDPList)

                Saved = True

            Else

                ErrorMessage = "One or more settings are invalid. Please fix errors and try again."

            End If

        Catch ex As Exception

            ErrorMessage = ex.Message

            If ex.InnerException IsNot Nothing Then

                ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                If ex.InnerException.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                End If

            End If

        Finally

            If StreamWriter IsNot Nothing Then

                StreamWriter.Close()

                StreamWriter.Dispose()

            End If

            StreamWriter = Nothing

        End Try

        SaveConnectionDatabaseProfileList = Saved

    End Function
    Public Sub Create()

        SimpleButtonForm_Create.PerformClick()

    End Sub
    Public Sub Skip()

        Me.WizardViewModel.Next()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Create_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Create.Click

        Dim CreatedAdvantageConnection As Boolean = False
        Dim Folder As String = String.Empty
        Dim ValidFolder As Boolean = False
        Dim FullFileName As String = String.Empty
        Dim ErrorMessage As String = String.Empty
        Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
        Dim ConnectionDatabaseProfileList As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

        Folder = ButtonEditForm_Folder.Text

        If String.IsNullOrWhiteSpace(Folder) = False Then

            Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

            If My.Computer.FileSystem.DirectoryExists(Folder) Then

                ValidFolder = True

            Else

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageConnectionPage", "Please select a valid folder.")

                Else

                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select a valid folder.")

                End If

            End If

        Else

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageConnectionPage", "Please select a valid folder.")

            Else

                DevExpress.XtraEditors.XtraMessageBox.Show("Please select a valid folder.")

            End If

        End If

        If ValidFolder Then

            OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

            FullFileName = Folder & AdvantageFramework.Security.AdvantageConnectionConfigurationFileName

            ConnectionDatabaseProfileList = LoadConnectionDatabaseProfileList(FullFileName)

            If ConnectionDatabaseProfileList IsNot Nothing Then

                Try

                    ConnectionDatabaseProfile = ConnectionDatabaseProfileList.SingleOrDefault(Function(Entity) Entity.ServerName = Me.WizardViewModel.WizardInputs.ServerName AndAlso Entity.DatabaseName = Me.WizardViewModel.WizardInputs.Database)

                Catch ex As Exception
                    ConnectionDatabaseProfile = Nothing
                End Try

                If ConnectionDatabaseProfile IsNot Nothing Then

                    ConnectionDatabaseProfile.UserName = Me.WizardViewModel.WizardInputs.AdvantageUserName
                    ConnectionDatabaseProfile.Password = Me.WizardViewModel.WizardInputs.AdvantagePassword

                Else

                    ConnectionDatabaseProfile = New AdvantageFramework.Database.ConnectionDatabaseProfile

                    ConnectionDatabaseProfile.ServerName = Me.WizardViewModel.WizardInputs.ServerName
                    ConnectionDatabaseProfile.DatabaseName = Me.WizardViewModel.WizardInputs.Database
                    ConnectionDatabaseProfile.UserName = Me.WizardViewModel.WizardInputs.AdvantageUserName
                    ConnectionDatabaseProfile.Password = Me.WizardViewModel.WizardInputs.AdvantagePassword

                    ConnectionDatabaseProfileList.Add(ConnectionDatabaseProfile)

                End If

                If SaveConnectionDatabaseProfileList(FullFileName, ConnectionDatabaseProfileList, ErrorMessage) Then

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                    CreatedAdvantageConnection = True

                Else

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                    If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageConnectionPage", "Failed to saving to the connection configuration file.")

                        Else

                            CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageConnectionPage", "Failed to saving to the connection configuration file." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    Else

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            DevExpress.XtraEditors.XtraMessageBox.Show("Failed to saving to the connection configuration file.")

                        Else

                            DevExpress.XtraEditors.XtraMessageBox.Show("Failed to saving to the connection configuration file." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                End If

            Else

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("AdvantageConnectionPage", "Failed loading connection configuration file.")

                Else

                    DevExpress.XtraEditors.XtraMessageBox.Show("Failed loading connection configuration file.")

                End If

            End If

        End If

        If CreatedAdvantageConnection Then

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub
    Private Sub ButtonEditForm_Folder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEditForm_Folder.ButtonClick

        Dim FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = Nothing

        FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()

        If FolderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            ButtonEditForm_Folder.Text = FolderBrowserDialog.SelectedPath

        End If

    End Sub

#End Region

#End Region

End Class
