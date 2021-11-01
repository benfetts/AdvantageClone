Namespace Database.Procedures.Alert

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

        Public Function LoadTaskWorkItem(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As AdvantageFramework.Database.Entities.Alert

            LoadTaskWorkItem = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                Where (Alert.AlertLevel = "BRD" Or Alert.AlertCategoryID = 71) And
                                       Alert.JobNumber = JobNumber And
                                       Alert.JobComponentNumber = JobComponentNumber And
                                       Alert.TaskSequenceNumber = TaskSequenceNumber
                                Select Alert).SingleOrDefault

        End Function
        Public Function LoadAssignmentsByJobAndComponent(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            LoadAssignmentsByJobAndComponent = From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                               Where Alert.JobNumber = JobNumber And Alert.JobComponentNumber = JobComponentNumber And
                                                     Alert.AlertAssignmentTemplateID IsNot Nothing And Alert.AlertStateID IsNot Nothing
                                               Select Alert

        End Function

        Public Function LoadByConceptShareReviewID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareReviewID As Integer) As AdvantageFramework.Database.Entities.Alert

            Try

                LoadByConceptShareReviewID = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                              Where Alert.ConceptShareReviewID = ConceptShareReviewID
                                              Select Alert).SingleOrDefault

            Catch ex As Exception
                LoadByConceptShareReviewID = Nothing
            End Try

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Long) As AdvantageFramework.Database.Entities.Alert

            Try

                LoadByAlertID = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                 Where Alert.ID = AlertID
                                 Select Alert).SingleOrDefault

            Catch ex As Exception
                LoadByAlertID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            Load = From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                   Select Alert

        End Function
        Public Function LoadByTypeIDAndClientAndDivisionAndProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TypeID As Integer, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            LoadByTypeIDAndClientAndDivisionAndProductCode = From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                                             Where Alert.AlertTypeID = TypeID AndAlso
                                                                   Alert.ClientCode = ClientCode AndAlso
                                                                   Alert.DivisionCode = DivisionCode AndAlso
                                                                   Alert.ProductCode = ProductCode
                                                             Select Alert

        End Function
        Public Function LoadByNonTaskID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NonTaskID As Long) As AdvantageFramework.Database.Entities.Alert

            Try

                LoadByNonTaskID = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                   Where Alert.NonTaskID = NonTaskID
                                   Select Alert).SingleOrDefault

            Catch ex As Exception
                LoadByNonTaskID = Nothing
            End Try

        End Function
        Public Function LoadByJobVersionID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            Try

                LoadByJobVersionID = From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                     Where Alert.JobVersionID = JobVersionID
                                     Select Alert

            Catch ex As Exception
                LoadByJobVersionID = Nothing
            End Try

        End Function
        Public Function LoadClientContactAlerts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContactID As Integer, ByVal Skip As Integer, ByVal Take As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            'LoadClientContactAlerts = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0))
            LoadClientContactAlerts = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                       Join AlertRecipients In ClientPortalAlertRecipient.Load(DbContext)
                                       On Alert.ID Equals AlertRecipients.AlertID
                                       Where AlertRecipients.ClientContactID = ClientContactID
                                       Order By Alert.LastUpdated Descending
                                       Select Alert).Skip(Skip).Take(Take)

        End Function
        Public Function LoadEmployeeAlerts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal Skip As Integer, ByVal Take As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            'LoadEmployeeAlerts = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0))
            LoadEmployeeAlerts = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                  Join AlertRecipients In AlertRecipient.Load(DbContext)
                                  On Alert.ID Equals AlertRecipients.AlertID
                                  Where AlertRecipients.EmployeeCode = EmployeeCode _
                                  AndAlso (AlertRecipients.IsCurrentNotify Is Nothing OrElse AlertRecipients.IsCurrentNotify = 0)
                                  Order By Alert.LastUpdated Descending
                                  Select Alert).Skip(Skip).Take(Take)

        End Function
        Public Function LoadEmployeeAssignments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal Skip As Integer, ByVal Take As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            'LoadEmployeeAssignments = LoadEmployeeAlertsAndAssignments(DbContext, EmployeeCode).Where(Function(Alert) Alert.AlertRecipients.Any(Function(AlertRecipient) AlertRecipient.IsCurrentNotify = 1))
            LoadEmployeeAssignments = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                       Join AlertRecipients In AlertRecipient.Load(DbContext)
                                       On Alert.ID Equals AlertRecipients.AlertID
                                       Where AlertRecipients.EmployeeCode = EmployeeCode _
                                       And AlertRecipients.IsCurrentNotify = 1
                                       Order By Alert.LastUpdated Descending
                                       Select Alert).Skip(Skip).Take(Take)

        End Function
        Public Function LoadEmployeeAlertsAndAssignments(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal Skip As Integer, ByVal Take As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            Dim query As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)
            Dim list As List(Of Integer)

            list = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                    Join AlertRecipients In AlertRecipient.Load(DbContext)
                    On Alert.ID Equals AlertRecipients.AlertID
                    Where AlertRecipients.EmployeeCode = EmployeeCode
                    Order By Alert.LastUpdated Descending
                    Select Alert.ID).Distinct().ToList()

            query = (From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                     Where list.Contains(Alert.ID)
                     Order By Alert.ID
                     Select Alert)

            Return query.Skip(Skip).Take(Take)

        End Function
        Public Function LoadDigitalAssetReviewsByJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Alert)

            LoadDigitalAssetReviewsByJobAndComponentNumber = From Alert In DbContext.GetQuery(Of Database.Entities.Alert)
                                                             Where Alert.JobNumber = JobNumber AndAlso
                                                                   Alert.JobComponentNumber = JobComponentNumber AndAlso
                                                                   Alert.AlertTypeID = 15
                                                             Select Alert

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertTypeID As Integer, ByVal AlertCategoryID As Integer, _
                               ByVal Subject As String, ByVal Body As String, _
                               ByVal GeneratedDate As Nullable(Of Date), ByVal PriorityLevel As Nullable(Of Short), _
                               ByVal EmployeeCode As String, ByVal UserCode As String, _
                               ByVal AlertLevel As String, ByVal EmailBody As String, _
                               ByRef Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                Alert = New AdvantageFramework.Database.Entities.Alert

                Alert.DbContext = DbContext
                Alert.AlertTypeID = AlertTypeID
                Alert.AlertCategoryID = AlertCategoryID
                Alert.Subject = Subject
                Alert.Body = Body
                Alert.GeneratedDate = GeneratedDate
                Alert.PriorityLevel = PriorityLevel
                Alert.EmployeeCode = EmployeeCode
                Alert.UserCode = UserCode
                Alert.AlertLevel = AlertLevel
                Alert.EmailBody = EmailBody
                Alert.LastUpdated = GeneratedDate

                Inserted = Insert(DbContext, Alert)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Alerts.Add(Alert)

                ErrorText = Alert.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        Alert.ID = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext) _
                                     Select Entity.ID).Max + 1

                    Catch ex As Exception
                        Alert.ID = 1
                    End Try

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Alert)

                ErrorText = Alert.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Alert)

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
