Namespace Database.Procedures.BoardDetail

    <HideModuleName()>
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

        Public Function LoadFirstStateByBoardHeaderIDandBoardColumnID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal BoardHeaderID As Integer,
                                                                      ByVal BoardColumnID As Integer) As AdvantageFramework.Database.Entities.BoardDetail

            Dim Detail As AdvantageFramework.Database.Entities.BoardDetail = Nothing

            Try

                Detail = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.BoardDetail)(String.Format("SELECT TOP 1 BD.ID AS ID, BD.BOARD_HDR_ID AS BoardHeaderID, BD.BOARD_COL_ID AS BoardColumnID, BD.SEQ_NBR AS SequenceNumber, BD.ALERT_STATE_ID AS AlertStateID FROM BOARD_DTL BD INNER JOIN BOARD_HDR BH ON BH.ID = BD.BOARD_HDR_ID INNER JOIN ALERT_NOTIFY_HDR ANH ON BH.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID INNER JOIN ALERT_NOTIFY_STATES ANS ON BH.ALRT_NOTIFY_HDR_ID = ANS.ALRT_NOTIFY_HDR_ID WHERE BOARD_HDR_ID = {0} AND BOARD_COL_ID = {1} ORDER BY ANS.SORT_ORDER;",
                                                                                                                        BoardHeaderID, BoardColumnID)).SingleOrDefault

            Catch ex As Exception
                Detail = Nothing
            End Try

            If Detail Is Nothing Then

                Try

                    Detail = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.BoardDetail)(String.Format("SELECT TOP 1 BD.ID AS ID, BD.BOARD_HDR_ID AS BoardHeaderID, BD.BOARD_COL_ID AS BoardColumnID, BD.SEQ_NBR AS SequenceNumber, BD.ALERT_STATE_ID AS AlertStateID FROM BOARD_DTL BD INNER JOIN BOARD_HDR B ON B.ID = BD.BOARD_HDR_ID INNER JOIN ALERT_NOTIFY_STATES ANS ON ANS.ALRT_NOTIFY_HDR_ID = B.ALRT_NOTIFY_HDR_ID AND ANS.ALERT_STATE_ID = BD.ALERT_STATE_ID WHERE BD.BOARD_HDR_ID = {0} AND BD.BOARD_COL_ID = {1} ORDER BY ANS.SORT_ORDER;",
                                                                                                                            BoardHeaderID, BoardColumnID)).SingleOrDefault

                Catch ex As Exception
                    Detail = Nothing
                End Try

            End If

            If Detail Is Nothing Then

                Try

                    Detail = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Entities.BoardDetail)(String.Format("SELECT TOP 1 BD.ID AS ID, BD.BOARD_HDR_ID AS BoardHeaderID, BD.BOARD_COL_ID AS BoardColumnID, BD.SEQ_NBR AS SequenceNumber, BD.ALERT_STATE_ID AS AlertStateID FROM BOARD_DTL BD WHERE BD.BOARD_HDR_ID = {0} AND BD.BOARD_COL_ID = {1} ORDER BY BD.SEQ_NBR, BD.ALERT_STATE_ID;",
                                                                                                                            BoardHeaderID, BoardColumnID)).SingleOrDefault

                Catch ex As Exception
                    Detail = Nothing
                End Try

            End If

            Return Detail

        End Function
        Public Function LoadByBoardHeaderIDandBoardColumnIDandAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                           ByVal BoardHeaderID As Integer,
                                                                           ByVal BoardColumnID As Integer,
                                                                           ByVal AlertStateID As Integer) As AdvantageFramework.Database.Entities.BoardDetail

            LoadByBoardHeaderIDandBoardColumnIDandAlertStateID = (From BoardDetail In DbContext.GetQuery(Of Database.Entities.BoardDetail)
                                                                  Where BoardDetail.BoardHeaderID = BoardHeaderID And BoardDetail.BoardColumnID = BoardColumnID And BoardDetail.AlertStateID = AlertStateID
                                                                  Select BoardDetail).SingleOrDefault

        End Function

        Public Function LoadByBoardHeaderIDandBoardColumnID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal BoardHeaderID As Integer, ByVal BoardColumnID As Integer) As AdvantageFramework.Database.Entities.BoardDetail

            LoadByBoardHeaderIDandBoardColumnID = (From BoardDetail In DbContext.GetQuery(Of Database.Entities.BoardDetail)
                                                   Where BoardDetail.BoardHeaderID = BoardHeaderID And BoardDetail.BoardColumnID = BoardColumnID
                                                   Select BoardDetail).SingleOrDefault

        End Function
        Public Function LoadByBoardHeaderIDandStateID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal BoardHeaderID As Integer, ByVal StateID As Integer) As AdvantageFramework.Database.Entities.BoardDetail

            LoadByBoardHeaderIDandStateID = (From BoardDetail In DbContext.GetQuery(Of Database.Entities.BoardDetail)
                                             Where BoardDetail.BoardHeaderID = BoardHeaderID And BoardDetail.AlertStateID = StateID
                                             Select BoardDetail).SingleOrDefault

        End Function
        Public Function LoadWithState(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardHeaderID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardDetail)

            LoadWithState = From BoardDetail In DbContext.GetQuery(Of Database.Entities.BoardDetail).Include("AlertState")
                            Where BoardDetail.BoardHeaderID = BoardHeaderID
                            Order By BoardDetail.SequenceNumber
                            Select BoardDetail

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardDetail)

            Load = From BoardDetail In DbContext.GetQuery(Of Database.Entities.BoardDetail)
                   Select BoardDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardDetail As AdvantageFramework.Database.Entities.BoardDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BoardDetails.Add(BoardDetail)

                ErrorText = BoardDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardDetail As AdvantageFramework.Database.Entities.BoardDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BoardDetail)

                ErrorText = BoardDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal BoardDetail As AdvantageFramework.Database.Entities.BoardDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.BoardHeader.IsInUse(DataContext, BoardHeader.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.BoardHeaderRole.LoadByBoardHeaderCode(DataContext, BoardHeader.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(BoardDetail)

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
