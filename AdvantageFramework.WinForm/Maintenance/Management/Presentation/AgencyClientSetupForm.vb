Namespace Maintenance.Management.Presentation

    Public Class AgencyClientSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadAgencyClients()

			Dim SelectedClientCodes() As String = Nothing
			Dim ClientCodes() As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				ClientCodes = (From AgencyClient In AdvantageFramework.Database.Procedures.AgencyClient.Load(DbContext)
							   Select AgencyClient.ClientCode).Distinct.ToArray

				DataGridViewLeftSection_Clients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
															  Where ClientCodes.Contains(Client.Code) = False
															  Select Client
															  Order By Client.Code,
																	   Client.Name).ToList

				DataGridViewLeftSection_Clients.CurrentView.BestFitColumns()

				DataGridViewRightSection_AgencyClients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
                                                                     Where ClientCodes.Contains(Client.Code) = True
                                                                     Select Client
                                                                     Order By Client.Code,
                                                                              Client.Name).ToList

                DataGridViewRightSection_AgencyClients.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub EnableOrDisableButtons()

            ButtonRightSection_AddClients.Enabled = DataGridViewLeftSection_Clients.HasASelectedRow
            ButtonRightSection_AddAllClients.Enabled = DataGridViewLeftSection_Clients.HasRows
            ButtonRightSection_RemoveClients.Enabled = DataGridViewRightSection_AgencyClients.HasASelectedRow
            ButtonRightSection_RemoveAllClients.Enabled = DataGridViewRightSection_AgencyClients.HasRows

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AgencyClientSetupForm As AdvantageFramework.Maintenance.Management.Presentation.AgencyClientSetupForm = Nothing

            AgencyClientSetupForm = New AdvantageFramework.Maintenance.Management.Presentation.AgencyClientSetupForm()

            AgencyClientSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AgencyClientSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            LoadAgencyClients()

            EnableOrDisableButtons()

            DataGridViewLeftSection_Clients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            DataGridViewRightSection_AgencyClients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Clients_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Clients.SelectionChangedEvent

            EnableOrDisableButtons()

        End Sub
        Private Sub DataGridViewRightSection_AgencyClients_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_AgencyClients.SelectionChangedEvent

            EnableOrDisableButtons()

        End Sub
        Private Sub ButtonRightSection_AddAllClients_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddAllClients.Click

            'objects
            Dim ClientCodesList As IEnumerable(Of Object) = Nothing
            Dim AgencyClient As AdvantageFramework.Database.Entities.AgencyClient = Nothing

            If DataGridViewLeftSection_Clients.HasRows Then

                ClientCodesList = DataGridViewLeftSection_Clients.GetAllRowsBookmarkValues

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ClientCode In ClientCodesList

                            AgencyClient = New AdvantageFramework.Database.Entities.AgencyClient

                            AgencyClient.DbContext = DbContext
                            AgencyClient.ClientCode = ClientCode

                            AdvantageFramework.Database.Procedures.AgencyClient.Insert(DbContext, AgencyClient)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadAgencyClients()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_AddClients_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddClients.Click

            'objects
            Dim ClientCodesList As IEnumerable(Of Object) = Nothing
            Dim AgencyClient As AdvantageFramework.Database.Entities.AgencyClient = Nothing

            If DataGridViewLeftSection_Clients.HasASelectedRow Then

                ClientCodesList = DataGridViewLeftSection_Clients.GetAllSelectedRowsBookmarkValues

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ClientCode In ClientCodesList

                            AgencyClient = New AdvantageFramework.Database.Entities.AgencyClient

                            AgencyClient.DbContext = DbContext
                            AgencyClient.ClientCode = ClientCode

                            AdvantageFramework.Database.Procedures.AgencyClient.Insert(DbContext, AgencyClient)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadAgencyClients()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveAllClients_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveAllClients.Click

            'objects
            Dim ClientCodesList As IEnumerable(Of Object) = Nothing

            If DataGridViewRightSection_AgencyClients.HasRows Then

                ClientCodesList = DataGridViewRightSection_AgencyClients.GetAllRowsBookmarkValues

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ClientCode In ClientCodesList

                            AdvantageFramework.Database.Procedures.AgencyClient.DeleteByClientCode(DbContext, ClientCode)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadAgencyClients()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveClients_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveClients.Click

            'objects
            Dim ClientCodesList As IEnumerable(Of Object) = Nothing

            If DataGridViewRightSection_AgencyClients.HasASelectedRow Then

                ClientCodesList = DataGridViewRightSection_AgencyClients.GetAllSelectedRowsBookmarkValues

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ClientCode In ClientCodesList

                            AdvantageFramework.Database.Procedures.AgencyClient.DeleteByClientCode(DbContext, ClientCode)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadAgencyClients()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Export.Click

            DataGridViewRightSection_AgencyClients.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub

#End Region

#End Region

    End Class

End Namespace