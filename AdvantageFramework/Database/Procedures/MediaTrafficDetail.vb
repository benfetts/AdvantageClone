Namespace Database.Procedures.MediaTrafficDetail

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaTrafficDetail

            LoadByID = (From MediaTrafficDetail In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetail)
                        Where MediaTrafficDetail.ID = ID
                        Select MediaTrafficDetail).SingleOrDefault

        End Function
        Public Function LoadByMediaTrafficCreativeGroupID(DbContext As Database.DbContext, MediaTrafficCreativeGroupID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficDetail)

            LoadByMediaTrafficCreativeGroupID = From MediaTrafficDetail In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetail)
                                                Where MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroupID
                                                Select MediaTrafficDetail

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficDetail)

            Load = From MediaTrafficDetail In DbContext.GetQuery(Of Database.Entities.MediaTrafficDetail)
                   Select MediaTrafficDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficDetails.Add(MediaTrafficDetail)

                ErrorText = MediaTrafficDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficDetailID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail = Nothing
            Dim DocumentList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentCount As Integer = 0

            Try

                MediaTrafficDetail = DbContext.MediaTrafficDetails.Find(MediaTrafficDetailID)

                If MediaTrafficDetail IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.HasAnyVendorGeneratedInstructionForCreativeGroupID(DbContext, MediaTrafficDetail.MediaTrafficCreativeGroupID) Then

                        IsValid = False

                        ErrorText = "Cannot delete detail as instruction has already been generated."

                    End If

                    If IsValid Then

                        DocumentList = New System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document)

                        DocumentList.AddRange((From Entity In AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Load(DbContext)
                                               Where Entity.MediaTrafficDetail.ID = MediaTrafficDetail.ID
                                               Select Entity.Document).ToList)

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE MTDD FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT MTDD " &
                                                                           "INNER JOIN dbo.MEDIA_TRAFFIC_DETAIL MTD ON MTDD.MEDIA_TRAFFIC_DETAIL_ID = MTD.MEDIA_TRAFFIC_DETAIL_ID WHERE MTD.MEDIA_TRAFFIC_DETAIL_ID = {0}", MediaTrafficDetailID))

                        For Each Doc In DocumentList

                            DocumentCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT count(1) FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT WHERE DOCUMENT_ID = {0}", Doc.ID)).First

                            If DocumentCount = 0 Then

                                DbContext.TryAttach(Doc)

                                AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Doc)

                            End If

                        Next

                        DbContext.Entry(MediaTrafficDetail).State = Entity.EntityState.Deleted

                        DbContext.SaveChanges()

                        Deleted = True

                    End If

                Else

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
                ErrorText = ex.Message
            Finally
                DeleteByID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
