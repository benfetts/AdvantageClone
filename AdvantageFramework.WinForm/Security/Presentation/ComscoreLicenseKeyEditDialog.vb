Namespace Security.Presentation

    Public Class ComscoreLicenseKeyEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = ""
        Private _ComscoreClientID As String = ""
        Private _AgencyName As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ClientCode As String, ComscoreClientID As String, AgencyName As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ClientCode = ClientCode
            _ComscoreClientID = ComscoreClientID
            _AgencyName = AgencyName

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ClientCode As String, ComscoreClientID As String, AgencyName As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ComscoreLicenseKeyEditDialog As AdvantageFramework.Security.Presentation.ComscoreLicenseKeyEditDialog = Nothing

            ComscoreLicenseKeyEditDialog = New AdvantageFramework.Security.Presentation.ComscoreLicenseKeyEditDialog(ClientCode, ComscoreClientID, AgencyName)

            ShowFormDialog = ComscoreLicenseKeyEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ComscoreLicenseKeyEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            TextBoxForm_AgencyName.ReadOnly = True
            TextBoxForm_AgencyName.MaxLength = 40
            TextBoxForm_ClientID.MaxLength = 100

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                If Client IsNot Nothing Then

                    TextBoxForm_AgencyName.Text = _AgencyName
                    TextBoxForm_ClientID.Text = _ComscoreClientID

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The client you are trying to create license key for does not exist.")

                    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Create.Click

            'objects
            Dim EncryptedLicenseKey As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Folder As String = ""
            Dim CreatedDate As Date = Nothing
            Dim ComscoreLicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.ComscoreLicenseKeyHistory = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.ComscoreCreate(_AgencyName, TextBoxForm_ClientID.GetText)

                    If EncryptedLicenseKey <> "" Then

                        CreatedDate = Now

                        ComscoreLicenseKeyHistory = DbContext.Database.SqlQuery(Of AdvantageFramework.Security.LicenseKey.Classes.ComscoreLicenseKeyHistory)("SELECT * FROM [dbo].[ComscoreLicenseKeyHistory] WHERE ClientCode = '" & _ClientCode & "' AND AgencyName = '" & _AgencyName.Replace("'", "`") & "'").FirstOrDefault

                        If ComscoreLicenseKeyHistory IsNot Nothing Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ComscoreLicenseKeyHistory] SET [UserCode] = '{0}', [EmployeeCode] = '{1}', [EmployeeName] = '{2}', " &
                                                                                  "[CreatedDate] = '{3}', [ComscoreClientID] = '{4}', [EncrpytedLicenseKey] = '{5}' WHERE [ClientCode] = '{6}'",
                                                                                  Me.Session.UserCode, Employee.Code, Employee.ToString, CreatedDate, TextBoxForm_ClientID.Text, EncryptedLicenseKey, _ClientCode)) = 1 Then

                                If CheckBoxForm_CreateFileAfterKeyCreated.Checked Then

                                    If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                                        My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & "ComscoreLicenseKey_" & _ClientCode & "_" & _AgencyName & "_" & Now.ToString("MMddyyyy") & ".advlic", EncryptedLicenseKey, False)

                                    End If

                                End If

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            End If

                        Else

                            If DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO [dbo].[ComscoreLicenseKeyHistory]([ClientCode], [AgencyName], [UserCode], [EmployeeCode], [EmployeeName], " &
                                                                                  "[CreatedDate], [ComscoreClientID], [EncrpytedLicenseKey]) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                                                                                  _ClientCode, _AgencyName.Replace("'", "`"), Me.Session.UserCode, Employee.Code, Employee.ToString, CreatedDate, TextBoxForm_ClientID.Text, EncryptedLicenseKey)) > 0 Then

                                If CheckBoxForm_CreateFileAfterKeyCreated.Checked Then

                                    If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                                        My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & "ComscoreLicenseKey_" & _ClientCode & "_" & Now.ToString("MMddyyyy") & ".advlic", EncryptedLicenseKey, False)

                                    End If

                                End If

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Creating comscore license key failed")

                            End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Creating comscore license key failed")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Creating comscore license key failed")

                End If

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
