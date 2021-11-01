Namespace Database.Procedures.AlertState

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

        Public Function LoadFirstStateByAlertAssignmentTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                  ByVal AlertAssignmentTemplateID As Integer) As AdvantageFramework.Database.Entities.AlertState

            Dim FirstAlertStateID As Integer = 0

            Try

                FirstAlertStateID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 ISNULL(ANS.ALERT_STATE_ID, 0) FROM ALERT_NOTIFY_STATES ANS WITH(NOLOCK) WHERE ANS.ALRT_NOTIFY_HDR_ID = {0} ORDER BY SORT_ORDER;", AlertAssignmentTemplateID)).SingleOrDefault

            Catch ex As Exception
                FirstAlertStateID = 0
            End Try
            Try

                LoadFirstStateByAlertAssignmentTemplateID = (From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                                                             Where AlertState.ID = FirstAlertStateID
                                                             Select AlertState).SingleOrDefault

            Catch ex As Exception
                LoadFirstStateByAlertAssignmentTemplateID = Nothing
            End Try

        End Function

        Public Function LoadByAlertAssignmentTemplateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAssignmentTemplateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertState)

            Try

                LoadByAlertAssignmentTemplateID = From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                                                  Join AlertAssignmentTemplateState In AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateID(DbContext, AlertAssignmentTemplateID)
                                                  On AlertAssignmentTemplateState.AlertStateID Equals AlertState.ID
                                                  Order By AlertAssignmentTemplateState.SortOrder
                                                  Select AlertState




            Catch ex As Exception
                LoadByAlertAssignmentTemplateID = Nothing
            End Try

        End Function
        Public Function LoadByStateName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Name As String) As AdvantageFramework.Database.Entities.AlertState

            Try

                LoadByStateName = (From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                                   Where AlertState.Name.ToLower.Trim = Name.ToLower.Trim
                                   Select AlertState).SingleOrDefault

            Catch ex As Exception
                LoadByStateName = Nothing
            End Try

        End Function

        Public Function LoadByAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertStateID As Integer) As AdvantageFramework.Database.Entities.AlertState

            Try

                LoadByAlertStateID = (From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                                      Where AlertState.ID = AlertStateID
                                      Select AlertState).SingleOrDefault

            Catch ex As Exception
                LoadByAlertStateID = Nothing
            End Try

        End Function

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertState)

            LoadAllActive = From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                            Where AlertState.IsActive = True And AlertState.ID > 0
                            Order By AlertState.Name
                            Select AlertState

        End Function
        Public Function LoadAllActiveWithNoTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.AlertState)
            'Dim UsedStates As Integer()

            'UsedStates = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DISTINCT ANS.ALERT_STATE_ID FROM ALERT_NOTIFY_STATES ANS WITH(NOLOCK);")).ToArray

            'LoadAllActiveWithNoTemplate = From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
            '                              Where AlertState.IsActive = True And AlertState.ID > 0 And UsedStates.Contains(AlertState.ID) = False
            '                              Order By AlertState.Name
            '                              Select AlertState

            LoadAllActiveWithNoTemplate = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.AlertState)(String.Format("SELECT ALERT_STATE_ID AS ID, ALERT_STATE_NAME AS Name, SORT_ORDER AS SortOrder, ACTIVE_FLAG AS IsActive, DFLT_ALERT_CAT_ID AS DefaultAlertCategoryID" &
                                                                                                                                        " FROM ALERT_STATES WITH(NOLOCK)" &
                                                                                                                                        " WHERE ALERT_STATES.ACTIVE_FLAG = 1 AND ALERT_STATE_ID > 0 AND ALERT_STATE_ID NOT IN (SELECT DISTINCT ANS.ALERT_STATE_ID FROM ALERT_NOTIFY_STATES ANS WITH(NOLOCK)) " &
                                                                                                                                        " ORDER BY ALERT_STATE_NAME;")).ToList

        End Function


        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertState)

            Load = From AlertState In DbContext.GetQuery(Of Database.Entities.AlertState)
                   Where AlertState.ID > 0
                   Select AlertState

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertState As AdvantageFramework.Database.Entities.AlertState) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertStates.Add(AlertState)

                ErrorText = AlertState.ValidateEntity(IsValid)

                If IsValid Then

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

        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertState As AdvantageFramework.Database.Entities.AlertState) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertState)

                ErrorText = AlertState.ValidateEntity(IsValid)

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

        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertState As AdvantageFramework.Database.Entities.AlertState) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim ErrorText As String = String.Empty

            Deleted = DeleteByID(DbContext, AlertState.ID, ErrorText)

            If Deleted = False AndAlso String.IsNullOrWhiteSpace(ErrorText) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

            End If

            Delete = Deleted

        End Function
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertStateID As Integer, ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = False

            Try

                ErrorMessage = DbContext.Database.SqlQuery(Of String)(String.Format("EXEC [dbo].[usp_wv_ALERT_STATES_DELETE] {0};", AlertStateID)).SingleOrDefault

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    Deleted = True
                    ErrorMessage = String.Empty

                Else

                    Deleted = False

                End If

            Catch ex As Exception
                Deleted = False
                ErrorMessage = ex.Message.ToString
            Finally
                DeleteByID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
