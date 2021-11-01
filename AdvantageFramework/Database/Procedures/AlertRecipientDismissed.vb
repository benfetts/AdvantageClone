Namespace Database.Procedures.AlertRecipientDismissed

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

        Public Function LoadByCCRecipientsAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed)

            LoadByCCRecipientsAlertID = From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                                        Where AlertRecipientDismissed.AlertID = AlertID And (AlertRecipientDismissed.IsCurrentNotify Is Nothing Or AlertRecipientDismissed.IsCurrentNotify = 0)
                                        Select AlertRecipientDismissed

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed)

            LoadByAlertID = From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                            Where AlertRecipientDismissed.AlertID = AlertID
                            Select AlertRecipientDismissed

        End Function
        Public Function LoadByAlertIDAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipientDismissed

            LoadByAlertIDAndEmployeeCode = (From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                                            Where AlertRecipientDismissed.AlertID = AlertID _
                                            And AlertRecipientDismissed.EmployeeCode = EmployeeCode
                                            Select AlertRecipientDismissed).SingleOrDefault

        End Function
        Public Function LoadAssigneeByAlertIDAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipientDismissed

            LoadAssigneeByAlertIDAndEmployeeCode = (From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                                                    Where AlertRecipientDismissed.AlertID = AlertID And
                                                          AlertRecipientDismissed.EmployeeCode = EmployeeCode And
                                                          AlertRecipientDismissed.IsCurrentNotify = 1
                                                    Select AlertRecipientDismissed).SingleOrDefault

        End Function
        Public Function LoadAssigneeByAlertIDEmployeeCodeTemplateState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                                       ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipientDismissed

            Try

                LoadAssigneeByAlertIDEmployeeCodeTemplateState = (From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                                                                  Where AlertRecipientDismissed.AlertID = Alert.ID And
                                                                      AlertRecipientDismissed.EmployeeCode = EmployeeCode And
                                                                      AlertRecipientDismissed.IsCurrentNotify = 1 And
                                                                      AlertRecipientDismissed.AlertTemplateID = Alert.AlertAssignmentTemplateID And
                                                                      AlertRecipientDismissed.AlertStateID = Alert.AlertStateID
                                                                  Select AlertRecipientDismissed).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed)

            Load = From AlertRecipientDismissed In DbContext.GetQuery(Of Database.Entities.AlertRecipientDismissed)
                   Select AlertRecipientDismissed

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, _
                               ByVal EmployeeCode As String, ByVal EmployeeEmail As String, ByVal ProcessedDate As Nullable(Of Date), _
                               ByVal IsNewAlert As Nullable(Of Short), ByVal HasBeenRead As Nullable(Of Short), _
                               ByRef AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                AlertRecipientDismissed = New AdvantageFramework.Database.Entities.AlertRecipientDismissed

                AlertRecipientDismissed.DbContext = DbContext
                AlertRecipientDismissed.AlertID = AlertID
                AlertRecipientDismissed.EmployeeCode = EmployeeCode
                AlertRecipientDismissed.EmployeeEmail = EmployeeEmail
                AlertRecipientDismissed.ProcessedDate = ProcessedDate
                AlertRecipientDismissed.IsNewAlert = IsNewAlert
                AlertRecipientDismissed.HasBeenRead = HasBeenRead

                Inserted = Insert(DbContext, AlertRecipientDismissed)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertRecipientDismisseds.Add(AlertRecipientDismissed)

                ErrorText = AlertRecipientDismissed.ValidateEntity(IsValid)

                If IsValid Then

                    If AlertRecipientDismissed.ID = 0 Then

                        Try

                            AlertRecipientDismissed.ID = (From Entity In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertRecipientDismissed.AlertID) _
                                                          Select Entity.ID).Max + 1

                        Catch ex As Exception
                            AlertRecipientDismissed.ID = 1
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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertRecipientDismissed)

                ErrorText = AlertRecipientDismissed.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertRecipientDismissed)

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
