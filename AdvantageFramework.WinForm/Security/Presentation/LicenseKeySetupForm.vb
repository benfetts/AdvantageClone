Namespace Security.Presentation

    Public Class LicenseKeySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LicenseWrite As Boolean = False
        Private _LicenseRead As Boolean = False
        Private _ComscoreLicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.ComscoreLicenseKeyHistory = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal LicenseRead As Boolean, ByVal LicenseWrite As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _LicenseWrite = LicenseWrite
            _LicenseRead = LicenseRead

        End Sub
        Private Sub LoadClientInformation()

            'objects
            Dim ClientObject As Object = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                ButtonItemActions_CreateNewLicenseKey.Enabled = _LicenseWrite
                ButtonItemActions_RenewLicenseKey.Enabled = _LicenseWrite

                ClientObject = DataGridViewLeftSection_Clients.GetFirstSelectedRowDataBoundItem

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientObject.Code)

                    If Client IsNot Nothing Then

                        LabelRightTopSection_ClientAddress.Text = String.Format("Address: {0}" & vbNewLine & "Address 2: {1}" & vbNewLine & "County: {2}" & vbNewLine &
                                                                             "City: {3} State: {4} Zip: {5}" & vbNewLine & "Country: {6}",
                                                                             Client.Address, Client.Address2, Client.County, Client.City, Client.State,
                                                                             Client.Zip, Client.Country)

                    Else

                        LabelRightTopSection_ClientAddress.Text = String.Format("Address: {0}" & vbNewLine & "Address 2: {1}" & vbNewLine & "County: {2}" & vbNewLine &
                                                                             "City: {3} State: {4} Zip: {5}" & vbNewLine & "Country: {6}",
                                                                             "", "", "", "", "", "", "")

                    End If

                End Using

                LoadClientLicenseKeyHistory()

            Else

                ButtonItemActions_CreateNewLicenseKey.Enabled = False
                ButtonItemActions_RenewLicenseKey.Enabled = False
                ButtonItemActions_CreateLicenseKeyFile.Enabled = False

                ButtonItemComscoreActions_CreateNewLicenseKey.Enabled = False
                ButtonItemComscoreActions_CreateLicenseKeyFile.Enabled = False

                LabelRightTopSection_ClientAddress.Text = String.Format("Address: {0}" & vbNewLine & "Address 2: {1}" & vbNewLine & "County: {2}" & vbNewLine &
                                                                     "City: {3} State: {4} Zip: {5}" & vbNewLine & "Country: {6}",
                                                                     "", "", "", "", "", "", "")

                DataGridViewRightMiddleSection_ClientContacts.DataSource = Nothing
                DataGridViewRightBottomSection_LicenseKeyHistory.DataSource = Nothing

            End If

        End Sub
        Private Sub LoadClientLicenseKeyHistory()

            'objects
            Dim ClientObject As Object = Nothing
            Dim LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                If _LicenseRead Then

                    ClientObject = DataGridViewLeftSection_Clients.GetFirstSelectedRowDataBoundItem

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DataGridViewRightBottomSection_LicenseKeyHistory.DataSource = SecurityDbContext.Database.SqlQuery(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)("SELECT * FROM [dbo].[LicenseKeyHistory] WHERE ClientCode = '" & ClientObject.Code & "' ORDER BY [CreatedDate]").ToList

                        End Using

                    Catch ex As Exception
                        DataGridViewRightBottomSection_LicenseKeyHistory.DataSource = New Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)
                    End Try

                Else

                    DataGridViewRightBottomSection_LicenseKeyHistory.DataSource = New Generic.List(Of AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory)

                End If

                DataGridViewRightBottomSection_LicenseKeyHistory.CurrentView.BestFitColumns()

                If DataGridViewRightBottomSection_LicenseKeyHistory.Columns("EncrpytedLicenseKey") IsNot Nothing Then

                    If DataGridViewRightBottomSection_LicenseKeyHistory.Columns("EncrpytedLicenseKey").Visible Then

                        DataGridViewRightBottomSection_LicenseKeyHistory.Columns("EncrpytedLicenseKey").Visible = False

                    End If

                End If

                ButtonItemActions_CreateLicenseKeyFile.Enabled = (DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow AndAlso _LicenseWrite)

                LoadComscoreLicense()

            End If

        End Sub
        Private Sub LoadComscoreLicense()

            'objects
            Dim ClientObject As Object = Nothing
            Dim LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso _LicenseRead Then

                ClientObject = DataGridViewLeftSection_Clients.GetFirstSelectedRowDataBoundItem

                If DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow Then

                    LicenseKeyHistory = DataGridViewRightBottomSection_LicenseKeyHistory.GetFirstSelectedRowDataBoundItem

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        _ComscoreLicenseKeyHistory = SecurityDbContext.Database.SqlQuery(Of AdvantageFramework.Security.LicenseKey.Classes.ComscoreLicenseKeyHistory)("SELECT * FROM [dbo].[ComscoreLicenseKeyHistory] WHERE ClientCode = '" & ClientObject.Code & "' AND AgencyName = '" & LicenseKeyHistory.AgencyName.Replace("'", "`") & "'").FirstOrDefault

                        If _ComscoreLicenseKeyHistory IsNot Nothing Then

                            LabelRightMiddleSection_ComscoreData.Text = String.Format("Agency: {0}" & Space(10) & " Comscore Client ID: {1}", _ComscoreLicenseKeyHistory.AgencyName, _ComscoreLicenseKeyHistory.ComscoreClientID)

                            ButtonItemComscoreActions_CreateLicenseKeyFile.Enabled = _LicenseWrite

                        Else

                            LabelRightMiddleSection_ComscoreData.Text = String.Format("Agency: {0}" & Space(10) & " Comscore Client ID: {1}", Space(40), "")

                            ButtonItemComscoreActions_CreateLicenseKeyFile.Enabled = False

                        End If

                        ButtonItemComscoreActions_CreateNewLicenseKey.Enabled = True

                        DataGridViewRightMiddleSection_ClientContacts.DataSource = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientCode(SecurityDbContext, ClientObject.Code).ToList

                        DataGridViewRightMiddleSection_ClientContacts.CurrentView.BestFitColumns()

                    End Using

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal LicenseRead As Boolean, ByVal LicenseWrite As Boolean)

            'objects
            Dim LicenseKeySetupForm As AdvantageFramework.Security.Presentation.LicenseKeySetupForm = Nothing

            LicenseKeySetupForm = New AdvantageFramework.Security.Presentation.LicenseKeySetupForm(LicenseRead, LicenseWrite)

            LicenseKeySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub LicenseKeySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_CreateNewLicenseKey.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_RenewLicenseKey.Image = AdvantageFramework.My.Resources.RefreshImage
            ButtonItemActions_CreateLicenseKeyFile.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemComscoreActions_CreateNewLicenseKey.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemComscoreActions_CreateLicenseKeyFile.Image = AdvantageFramework.My.Resources.ProcessImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

                DataGridViewLeftSection_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                DataGridViewLeftSection_Clients.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LicenseKeySetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            ButtonItemActions_CreateNewLicenseKey.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso _LicenseWrite)
            ButtonItemActions_RenewLicenseKey.Enabled = (DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso _LicenseWrite)

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow AndAlso DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow AndAlso _LicenseWrite Then

                ButtonItemActions_CreateLicenseKeyFile.Enabled = True

            Else

                ButtonItemActions_CreateLicenseKeyFile.Enabled = False

            End If

            ButtonItemActions_CreateNewLicenseKey.Enabled = _LicenseWrite
            ButtonItemActions_RenewLicenseKey.Enabled = _LicenseWrite
            ButtonItemActions_CreateLicenseKeyFile.Enabled = _LicenseWrite

            ButtonItemComscoreActions_CreateNewLicenseKey.Enabled = _LicenseWrite

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Clients_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Clients.SelectionChangedEvent

            LoadClientInformation()

        End Sub
        Private Sub DataGridViewRightBottomSection_LicenseKeyHistory_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightBottomSection_LicenseKeyHistory.CellValueChangingEvent

            'objects
            Dim LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

            If e.RowHandle > -1 AndAlso e.Column IsNot Nothing Then

                Try

                    LicenseKeyHistory = DataGridViewRightBottomSection_LicenseKeyHistory.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    LicenseKeyHistory = Nothing
                End Try

                If LicenseKeyHistory IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If e.Column.FieldName = AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory.Properties.IsActive.ToString Then

                            SecurityDbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[LicenseKeyHistory] " &
                                                                      "SET [IsActive] = " & Convert.ToInt16(e.Value) & " " &
                                                                      "WHERE [ID] = " & LicenseKeyHistory.ID & "")

                        ElseIf e.Column.FieldName = AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory.Properties.Comment.ToString Then

                            SecurityDbContext.Database.ExecuteSqlCommand("UPDATE [dbo].[LicenseKeyHistory] " &
                                                                      "SET [Comment] = '" & e.Value & "' " &
                                                                      "WHERE [ID] = " & LicenseKeyHistory.ID & "")

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_LicenseKeyHistory_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightBottomSection_LicenseKeyHistory.SelectionChangedEvent

            LoadComscoreLicense()

            ButtonItemActions_CreateLicenseKeyFile.Enabled = (DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow AndAlso _LicenseWrite)
            ButtonItemActions_RenewLicenseKey.Enabled = (DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow AndAlso _LicenseWrite)

        End Sub
        Private Sub ButtonItemActions_CreateNewLicenseKey_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_CreateNewLicenseKey.Click

            If AdvantageFramework.Security.Presentation.LicenseKeyEditDialog.ShowFormDialog(DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue, Nothing) = Windows.Forms.DialogResult.OK Then

                LoadClientLicenseKeyHistory()

            End If

        End Sub
        Private Sub ButtonItemActions_RenewLicenseKey_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_RenewLicenseKey.Click

            'objects
            Dim LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

            Try

                LicenseKeyHistory = DataGridViewRightBottomSection_LicenseKeyHistory.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                LicenseKeyHistory = Nothing
            End Try

            If AdvantageFramework.Security.Presentation.LicenseKeyEditDialog.ShowFormDialog(DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue, LicenseKeyHistory) = Windows.Forms.DialogResult.OK Then

                LoadClientLicenseKeyHistory()

            End If

        End Sub
        Private Sub ButtonItemActions_CreateLicenseKeyFile_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_CreateLicenseKeyFile.Click

            'objects
            Dim EncryptedLicenseKey As String = ""
            Dim Folder As String = ""
            Dim ClientCode As String = Nothing

            If DataGridViewLeftSection_Clients.HasOnlyOneSelectedRow Then

                ButtonItemActions_CreateNewLicenseKey.Enabled = _LicenseWrite
                ButtonItemActions_RenewLicenseKey.Enabled = _LicenseWrite

                ClientCode = DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue
                EncryptedLicenseKey = DataGridViewRightBottomSection_LicenseKeyHistory.GetFirstSelectedRowDataBoundItem.EncrpytedLicenseKey

                If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                    My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & "LicenseKey_" & ClientCode & "_" & Now.ToString("MMddyyyy") & ".advlic", EncryptedLicenseKey, False)

                End If

            End If

        End Sub
        Private Sub ButtonItemComscoreActions_CreateNewLicenseKey_Click(sender As Object, e As EventArgs) Handles ButtonItemComscoreActions_CreateNewLicenseKey.Click

            Dim ComscoreClientID As String = ""
            Dim LicenseKeyHistory As AdvantageFramework.Security.LicenseKey.Classes.LicenseKeyHistory = Nothing

            If _ComscoreLicenseKeyHistory IsNot Nothing Then

                ComscoreClientID = _ComscoreLicenseKeyHistory.ComscoreClientID

            End If

            If DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow Then

                LicenseKeyHistory = DataGridViewRightBottomSection_LicenseKeyHistory.GetFirstSelectedRowDataBoundItem

                If AdvantageFramework.Security.Presentation.ComscoreLicenseKeyEditDialog.ShowFormDialog(DataGridViewLeftSection_Clients.GetFirstSelectedRowBookmarkValue, ComscoreClientID, LicenseKeyHistory.AgencyName) = Windows.Forms.DialogResult.OK Then

                    LoadClientInformation()

                End If

            End If

        End Sub
        Private Sub ButtonItemComscoreActions_CreateLicenseKeyFile_Click(sender As Object, e As EventArgs) Handles ButtonItemComscoreActions_CreateLicenseKeyFile.Click

            'objects
            Dim EncryptedLicenseKey As String = ""
            Dim Folder As String = ""
            Dim AgencyName As String = Nothing

            If DataGridViewRightBottomSection_LicenseKeyHistory.HasOnlyOneSelectedRow Then

                AgencyName = DataGridViewRightBottomSection_LicenseKeyHistory.GetFirstSelectedRowBookmarkValue

                EncryptedLicenseKey = AdvantageFramework.Security.LicenseKey.ComscoreCreate(_ComscoreLicenseKeyHistory.AgencyName, _ComscoreLicenseKeyHistory.ComscoreClientID)

                If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                    My.Computer.FileSystem.WriteAllText(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\") & "ComscoreLicenseKey_" & AgencyName & "_" & Now.ToString("MMddyyyy") & ".advlic", EncryptedLicenseKey, False)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
