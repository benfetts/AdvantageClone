Namespace Database.Procedures.ClientPortalAlertRecipient

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient)

            LoadByAlertID = From ClientPortalAlertRecipient In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipient)
                            Where ClientPortalAlertRecipient.AlertID = AlertID
                            Select ClientPortalAlertRecipient

        End Function
        Public Function LoadByAlertIDAndContactID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal ClientContactID As Integer) As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

            LoadByAlertIDAndContactID = (From ClientPortalAlertRecipient In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipient)
                                         Where ClientPortalAlertRecipient.AlertID = AlertID _
                                        And ClientPortalAlertRecipient.ClientContactID = ClientContactID
                                         Select ClientPortalAlertRecipient).SingleOrDefault

        End Function

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient)

            Load = From ClientPortalAlertRecipient In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipient)
                   Select ClientPortalAlertRecipient

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, _
                               ByVal ClientContactID As Integer, ByVal EmailAddress As String, ByVal ProcessedDate As Nullable(Of Date), _
                               ByVal IsNewAlert As Nullable(Of Short), ByVal HasBeenRead As Nullable(Of Short), _
                               ByRef ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ClientPortalAlertRecipient = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipient

                ClientPortalAlertRecipient.DbContext = DbContext
                ClientPortalAlertRecipient.AlertID = AlertID
                ClientPortalAlertRecipient.ClientContactID = ClientContactID
                ClientPortalAlertRecipient.EmailAddress = EmailAddress
                ClientPortalAlertRecipient.ProcessedDate = ProcessedDate
                ClientPortalAlertRecipient.IsNewAlert = IsNewAlert
                ClientPortalAlertRecipient.HasBeenRead = HasBeenRead

                Inserted = Insert(DbContext, ClientPortalAlertRecipient)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientPortalAlertRecipients.Add(ClientPortalAlertRecipient)

                ErrorText = ClientPortalAlertRecipient.ValidateEntity(IsValid)

                If IsValid Then

                    If ClientPortalAlertRecipient.AlertRecipientID = 0 Then

                        Try

                            ClientPortalAlertRecipient.AlertRecipientID = (From Entity In AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, ClientPortalAlertRecipient.AlertID) _
                                                                           Select Entity.AlertRecipientID).Max + 1

                        Catch ex As Exception
                            ClientPortalAlertRecipient.AlertRecipientID = 1
                        End Try

                    End If

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientPortalAlertRecipient)

                ErrorText = ClientPortalAlertRecipient.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then
                    
                    DbContext.DeleteEntityObject(ClientPortalAlertRecipient)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
