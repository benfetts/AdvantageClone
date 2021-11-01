Namespace Database.Presentation

    Public Class ServerSetupDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ConnectionString As String = ""
        Private _ServerName As String = ""
        Private _DataSource As String = ""

#End Region

#Region " Properties "

        Private ReadOnly Property ConnectionString() As String
            Get
                ConnectionString = _ConnectionString
            End Get
        End Property
        Private ReadOnly Property ServerName() As String
            Get
                ServerName = _ServerName
            End Get
        End Property
        Private ReadOnly Property DataSource() As String
            Get
                DataSource = _DataSource
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadDatabaseServerInstances()

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources

            ComboBoxForm_DatabaseServerInstance.DataSource = (From DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)() _
                                                              Where IsDBNull(DataRow("InstanceName")) = False _
                                                              Select New With {.ServerAndInstanceName = DataRow("ServerName") & "\" & DataRow("InstanceName")}).Union(From DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)() _
                                                                                                                                                                      Where IsDBNull(DataRow("InstanceName")) = True _
                                                                                                                                                                      Select New With {.ServerAndInstanceName = DataRow("ServerName")}).ToList.OrderBy(Function(Entity) Entity.ServerAndInstanceName)

        End Sub
        Private Sub LoadDatabases()

            'objects
            Dim ConnectionString As String = ""
            Dim Databases As Generic.List(Of AdvantageFramework.Database.MasterDatabase.Entities.Database) = Nothing

            Try

                If ComboBoxForm_DatabaseServerInstance.HasASelectedValue Then

                    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ComboBoxForm_DatabaseServerInstance.Text, "master", RadioButtonForm_WindowsAuthentication.Checked, TextBoxForm_UserName.Text, TextBoxForm_Password.Text, "AdvantageFramework")

                    Using DataContext = New AdvantageFramework.Database.MasterDatabase.DataContext(ConnectionString, "AdvantageFramework")

                        Databases = AdvantageFramework.Database.MasterDatabase.Procedures.Database.Load(DataContext).OrderBy(Function(Database) Database.Name).ToList

                    End Using

                End If

            Catch ex As Exception
                Databases = Nothing
            Finally
                ComboBoxForm_Database.DataSource = Databases
            End Try

        End Sub
        Private Function TestConnection(ByVal SuppressMessage As Boolean) As Boolean

            'objects
            Dim ConnectionString As String = ""
            Dim IsTestSucessful As Boolean = False

            ConnectionString = AdvantageFramework.Database.CreateConnectionString(ComboBoxForm_DatabaseServerInstance.Text, "master", RadioButtonForm_WindowsAuthentication.Checked, TextBoxForm_UserName.Text, TextBoxForm_Password.Text, "AdvantageFramework")

            IsTestSucessful = AdvantageFramework.Database.TestConnectionString(ConnectionString)

            If SuppressMessage = False Then

                If IsTestSucessful Then

                    AdvantageFramework.Navigation.ShowMessageBox("Test Successful!")

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Test Failed.")

                End If

            End If

            TestConnection = IsTestSucessful

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ConnectionString As String, ByRef ServerName As String, ByRef DataSource As String, Optional ByVal FormText As String = "Database Server Setup") As System.Windows.Forms.DialogResult

            'objects
            Dim ServerSetupDialog As ServerSetupDialog = Nothing

            ServerSetupDialog = New ServerSetupDialog

            ServerSetupDialog.Text = FormText

            ShowFormDialog = ServerSetupDialog.ShowDialog()

            ConnectionString = ServerSetupDialog.ConnectionString
            ServerName = ServerSetupDialog.ServerName
            DataSource = ServerSetupDialog.DataSource

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DatabaseServerSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadDatabaseServerInstances()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_DatabaseServerInstance_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_DatabaseServerInstance.SelectedValueChanged

            'objects
            Dim EnableControls As Boolean = False

            LoadDatabases()

            EnableControls = ComboBoxForm_DatabaseServerInstance.HasASelectedValue

            RadioButtonForm_WindowsAuthentication.Enabled = EnableControls
            RadioButtonForm_DatabaseServerAuthentication.Enabled = EnableControls

            ComboBoxForm_Database.Enabled = EnableControls

            ButtonForm_RefreshDatabases.Enabled = EnableControls

            TextBoxForm_UserName.Enabled = RadioButtonForm_DatabaseServerAuthentication.Checked
            TextBoxForm_Password.Enabled = RadioButtonForm_DatabaseServerAuthentication.Checked

        End Sub
        Private Sub ButtonForm_RefreshDatabaseServersInstances_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RefreshDatabaseServersInstances.Click

            LoadDatabaseServerInstances()

        End Sub
        Private Sub ButtonForm_RefreshDatabases_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_RefreshDatabases.Click

            LoadDatabases()

        End Sub
        Private Sub ComboBoxForm_Database_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Database.SelectedValueChanged

            'objects
            Dim EnableControls As Boolean = False

            EnableControls = ComboBoxForm_Database.HasASelectedValue

            ButtonForm_TestConnection.Enabled = EnableControls

        End Sub
        Private Sub RadioButtonForm_DatabaseServerAuthentication_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_DatabaseServerAuthentication.CheckedChanged

            If RadioButtonForm_DatabaseServerAuthentication.Checked Then

                TextBoxForm_UserName.Enabled = True
                TextBoxForm_Password.Enabled = True

                LoadDatabases()

            End If

        End Sub
        Private Sub RadioButtonForm_WindowsAuthentication_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_WindowsAuthentication.CheckedChanged

            If RadioButtonForm_WindowsAuthentication.Checked Then

                TextBoxForm_UserName.Enabled = False
                TextBoxForm_Password.Enabled = False

                LoadDatabases()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If ComboBoxForm_DatabaseServerInstance.HasASelectedValue AndAlso ComboBoxForm_Database.HasASelectedValue Then

                If TestConnection(True) Then

                    _ServerName = ComboBoxForm_DatabaseServerInstance.Text
                    _DataSource = ComboBoxForm_Database.Text

                    _ConnectionString = AdvantageFramework.Database.CreateConnectionString(ComboBoxForm_DatabaseServerInstance.Text, ComboBoxForm_Database.Text, RadioButtonForm_WindowsAuthentication.Checked, TextBoxForm_UserName.Text, TextBoxForm_Password.Text)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Failed to establish connection.")

                End If

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select a Server and/or Database.")

            End If

        End Sub
        Private Sub ButtonForm_TestConnection_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_TestConnection.Click

            If ComboBoxForm_DatabaseServerInstance.HasASelectedValue AndAlso ComboBoxForm_Database.HasASelectedValue Then

                TestConnection(False)

            Else

                AdvantageFramework.Navigation.ShowMessageBox("Please select a Server and/or Database.")

            End If

        End Sub
        Private Sub TextBoxForm_Password_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_Password.Validated

            LoadDatabases()

        End Sub
        Private Sub TextBoxForm_UserName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxForm_UserName.Validated

            LoadDatabases()

        End Sub

#End Region

#End Region

    End Class

End Namespace