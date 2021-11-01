Namespace Database.Procedures.ClientPortalAlertRecipientDismissed

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

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed)

            LoadByAlertID = From ClientPortalAlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipientDismissed)
                            Where ClientPortalAlertRecipientDismissed.AlertID = AlertID
                            Select ClientPortalAlertRecipientDismissed

        End Function
        Public Function LoadByAlertIDAndContactID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal ClientContactID As Integer) As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed

            LoadByAlertIDAndContactID = (From ClientPortalAlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipientDismissed)
                                         Where ClientPortalAlertRecipientDismissed.AlertID = AlertID _
                                         And ClientPortalAlertRecipientDismissed.ClientContactID = ClientContactID
                                         Select ClientPortalAlertRecipientDismissed).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed)

            Load = From ClientPortalAlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.ClientPortalAlertRecipientDismissed)
                   Select ClientPortalAlertRecipientDismissed

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, _
                               ByVal ClientContactID As Integer, ByVal EmailAddress As String, ByVal ProcessedDate As Nullable(Of Date), _
                               ByVal IsNewAlert As Nullable(Of Short), ByVal HasBeenRead As Nullable(Of Short), _
                               ByRef ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                ClientPortalAlertRecipientDismissed = New AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed

                ClientPortalAlertRecipientDismissed.DbContext = DbContext
                ClientPortalAlertRecipientDismissed.AlertID = AlertID
                ClientPortalAlertRecipientDismissed.ClientContactID = ClientContactID
                ClientPortalAlertRecipientDismissed.EmailAddress = EmailAddress
                ClientPortalAlertRecipientDismissed.ProcessedDate = ProcessedDate
                ClientPortalAlertRecipientDismissed.IsNewAlert = IsNewAlert
                ClientPortalAlertRecipientDismissed.HasBeenRead = HasBeenRead

                Inserted = Insert(DbContext, ClientPortalAlertRecipientDismissed)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ClientPortalAlertRecipientDismisseds.Add(ClientPortalAlertRecipientDismissed)

                ErrorText = ClientPortalAlertRecipientDismissed.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        ClientPortalAlertRecipientDismissed.AlertRecipientID = (From Entity In AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertID(DbContext, ClientPortalAlertRecipientDismissed.AlertID)
                                                                                Select Entity.AlertRecipientID).Max + 1

                    Catch ex As Exception
                        ClientPortalAlertRecipientDismissed.AlertRecipientID = 1
                    End Try

                    DbContext.ClientPortalAlertRecipientDismisseds.Add(ClientPortalAlertRecipientDismissed)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientPortalAlertRecipientDismissed)

                ErrorText = ClientPortalAlertRecipientDismissed.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientPortalAlertRecipientDismissed As AdvantageFramework.Database.Entities.ClientPortalAlertRecipientDismissed) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ClientPortalAlertRecipientDismissed)

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
