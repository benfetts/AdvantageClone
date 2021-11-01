Namespace Database.Procedures.AlertRecipient

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

        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertRecipient)

            LoadByAlertID = From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                            Where AlertRecipient.AlertID = AlertID
                            Select AlertRecipient

        End Function
        Public Function LoadByAlertIDAndEmployeeCodeExcludeAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipient

            LoadByAlertIDAndEmployeeCodeExcludeAssignee = (From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                                                           Where AlertRecipient.AlertID = AlertID _
                                                           AndAlso AlertRecipient.EmployeeCode = EmployeeCode _
                                                           AndAlso (AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0)
                                                           Select AlertRecipient).SingleOrDefault

        End Function
        Public Function LoadByAlertIDAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipient

            Try

                LoadByAlertIDAndEmployeeCode = (From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                                                Where AlertRecipient.AlertID = AlertID _
                                                AndAlso AlertRecipient.EmployeeCode = EmployeeCode
                                                Select AlertRecipient).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadAssigneeByAlertIDAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long, ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipient

            Try

                LoadAssigneeByAlertIDAndEmployeeCode = (From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                                                        Where AlertRecipient.AlertID = AlertID And
                                                              AlertRecipient.EmployeeCode = EmployeeCode And
                                                              AlertRecipient.IsCurrentNotify = 1
                                                        Select AlertRecipient).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function LoadAssigneeByAlertIDEmployeeCodeTemplateState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                                       ByVal EmployeeCode As String) As AdvantageFramework.Database.Entities.AlertRecipient

            Try

                LoadAssigneeByAlertIDEmployeeCodeTemplateState = (From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                                                                  Where AlertRecipient.AlertID = Alert.ID And
                                                                      AlertRecipient.EmployeeCode = EmployeeCode And
                                                                      AlertRecipient.IsCurrentNotify = 1 And
                                                                      AlertRecipient.AlertTemplateID = Alert.AlertAssignmentTemplateID And
                                                                      AlertRecipient.AlertStateID = Alert.AlertStateID
                                                                  Select AlertRecipient).SingleOrDefault

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertRecipient)

            Load = From AlertRecipient In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                   Select AlertRecipient

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer,
                               ByVal EmployeeCode As String, ByVal EmployeeEmail As String, ByVal ProcessedDate As Nullable(Of Date),
                               ByVal IsNewAlert As Nullable(Of Short), ByVal HasBeenRead As Nullable(Of Short),
                               ByRef AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                AlertRecipient.DbContext = DbContext
                AlertRecipient.AlertID = AlertID
                AlertRecipient.EmployeeCode = EmployeeCode
                AlertRecipient.EmployeeEmail = EmployeeEmail
                AlertRecipient.ProcessedDate = ProcessedDate
                AlertRecipient.IsNewAlert = IsNewAlert
                AlertRecipient.HasBeenRead = HasBeenRead

                Inserted = Insert(DbContext, AlertRecipient)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function

        Private Function AddAssigneeToTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient) As Boolean

            Dim Success As Boolean = True

            Try

                If DbContext IsNot Nothing AndAlso AlertRecipient IsNot Nothing Then

                    If AlertRecipient.AlertTemplateID IsNot Nothing AndAlso AlertRecipient.AlertTemplateID > 0 AndAlso
                        AlertRecipient.AlertStateID IsNot Nothing AndAlso AlertRecipient.AlertStateID > 0 Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_assignment_template_add_employee_to_template] {0}, {1}, {2}, '{3}';",
                                                                           AlertRecipient.AlertID,
                                                                           AlertRecipient.AlertTemplateID,
                                                                           AlertRecipient.AlertStateID,
                                                                           AlertRecipient.EmployeeCode))

                    End If

                End If


            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AlertRecipient.IsEntityBeingAdded() = True Then <== This doesn't work becaus the ID is part of the Entity Key

                DbContext.AlertRecipients.Add(AlertRecipient)
                ErrorText = AlertRecipient.ValidateEntity(IsValid)

                If IsValid Then

                    If AlertRecipient.ID = 0 Then

                        Try

                            'AlertRecipient.ID = (From Entity In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertRecipient.AlertID) _
                            '                     Select Entity.ID).Max + 1
                            AlertRecipient.ID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(MAX(R.ALERT_RCPT_ID), 0) + 1  FROM ALERT_RCPT R WITH(NOLOCK) WHERE R.ALERT_ID = {0}", AlertRecipient.AlertID)).SingleOrDefault()

                        Catch ex As Exception
                            AlertRecipient.ID = 1
                        End Try

                    End If

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

                If Inserted = True Then

                    AddAssigneeToTemplate(DbContext, AlertRecipient)

                End If

                'End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertRecipient)

                ErrorText = AlertRecipient.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

                If Updated = True Then

                    AddAssigneeToTemplate(DbContext, AlertRecipient)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertRecipient)
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
