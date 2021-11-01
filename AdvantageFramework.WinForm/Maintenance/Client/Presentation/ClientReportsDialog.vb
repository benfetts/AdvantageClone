Namespace Maintenance.Client.Presentation

    Public Class ClientReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SelectedClientCodes() As String = Nothing
        Private _AvailableClientCodes() As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal AvailableClientCodes() As String, ByVal SelectedClientCodes() As String)

            ' This call is required by the designer.
            InitializeComponent()

            _SelectedClientCodes = SelectedClientCodes
            _AvailableClientCodes = AvailableClientCodes

        End Sub
        Private Sub LoadGrid()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DataGridViewForm_Clients.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext)

                    DataGridViewForm_Clients.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub SelectGridRows()

            If _SelectedClientCodes IsNot Nothing Then

                DataGridViewForm_Clients.CurrentView.BeginSelection()

                DataGridViewForm_Clients.CurrentView.ClearSelection()

                For Each ClientCode In _SelectedClientCodes

                    DataGridViewForm_Clients.SelectRow(0, ClientCode, False)

                Next

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByVal AvailableClientCodes() As String = Nothing, Optional ByVal SelectedClientCodes() As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientReportsDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientReportsDialog = Nothing

            ClientReportsDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientReportsDialog(AvailableClientCodes, SelectedClientCodes)

            ShowFormDialog = ClientReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            DataGridViewForm_Clients.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim ClientList As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim ClientCodes As String() = Nothing

            If Me.Validator Then

                If DataGridViewForm_Clients.HasASelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ClientCodes = (From Entity In DataGridViewForm_Clients.GetAllSelectedRowsBookmarkValues().OfType(Of String)()
                                       Select Entity).ToArray

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        ReportType = Reporting.ReportTypes.ClientDetail

                        ClientList = (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext).Include("ClientDiscount")
                                      Where ClientCodes.Contains(Entity.Code)
                                      Select Entity
                                      Order By Entity.Code).ToList

                        If ClientList IsNot Nothing AndAlso ClientList.Count > 0 Then

                            ParameterList.Add("DataSource", ClientList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one client.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace