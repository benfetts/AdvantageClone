Namespace Database.Procedures.AlertAttachment

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

        Public Function LoadByAlertAttachmentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAttachmentID As Long) As AdvantageFramework.Database.Entities.AlertAttachment

            Try

                LoadByAlertAttachmentID = (From AlertAttachment In DbContext.GetQuery(Of Database.Entities.AlertAttachment)
                                           Where AlertAttachment.ID = AlertAttachmentID
                                           Select AlertAttachment).SingleOrDefault

            Catch ex As Exception
                LoadByAlertAttachmentID = Nothing
            End Try

        End Function
        Public Function LoadByDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DocumentID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAttachment)

            LoadByDocumentID = From AlertAttachment In DbContext.GetQuery(Of Database.Entities.AlertAttachment)
                               Where AlertAttachment.DocumentID = DocumentID
                               Select AlertAttachment

        End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAttachment)

            LoadByAlertID = From AlertAttachment In DbContext.GetQuery(Of Database.Entities.AlertAttachment)
                            Where AlertAttachment.AlertID = AlertID
                            Select AlertAttachment

        End Function
        Public Function LoadByAlertIDAndDocumentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal DocumentID As Integer) As AdvantageFramework.Database.Entities.AlertAttachment

            LoadByAlertIDAndDocumentID = (From AlertAttachment In DbContext.GetQuery(Of Database.Entities.AlertAttachment)
                                          Where AlertAttachment.AlertID = AlertID And
                                          AlertAttachment.DocumentID = DocumentID
                                          Select AlertAttachment).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.AlertAttachment)

            Load = From AlertAttachment In DbContext.GetQuery(Of Database.Entities.AlertAttachment)
                   Select AlertAttachment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, _
                              ByVal AlertID As Integer, ByVal UserCode As String, _
                              ByVal GeneratedDate As Date, ByVal HasEmailBeenSent As Boolean, _
                              ByVal DocumentID As Integer, _
                              ByRef AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                AlertAttachment.DbContext = DbContext
                AlertAttachment.AlertID = AlertID
                AlertAttachment.UserCode = UserCode
                AlertAttachment.GeneratedDate = GeneratedDate
                AlertAttachment.DocumentID = DocumentID
                AlertAttachment.HasEmailBeenSent = HasEmailBeenSent

                Inserted = Insert(DbContext, AlertAttachment)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AlertAttachments.Add(AlertAttachment)

                ErrorText = AlertAttachment.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AlertAttachment)

                ErrorText = AlertAttachment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AlertAttachment)

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
