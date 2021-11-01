Namespace Database.Procedures.MediaTrafficRevision

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaTrafficRevision

            LoadByID = (From MediaTrafficRevision In DbContext.GetQuery(Of Database.Entities.MediaTrafficRevision)
                        Where MediaTrafficRevision.ID = ID
                        Select MediaTrafficRevision).SingleOrDefault

        End Function
        Public Function LoadByMediaTrafficID(ByVal DbContext As Database.DbContext, MediaTrafficID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficRevision)

            LoadByMediaTrafficID = From MediaTrafficRevision In DbContext.GetQuery(Of Database.Entities.MediaTrafficRevision)
                                   Where MediaTrafficRevision.MediaTrafficID = MediaTrafficID
                                   Select MediaTrafficRevision

        End Function
        Public Function LoadMaxRevisionByMediaTrafficID(ByVal DbContext As Database.DbContext, MediaTrafficID As Integer) As Database.Entities.MediaTrafficRevision

            LoadMaxRevisionByMediaTrafficID = (From MediaTrafficRevision In DbContext.GetQuery(Of Database.Entities.MediaTrafficRevision)
                                               Where MediaTrafficRevision.MediaTrafficID = MediaTrafficID
                                               Select MediaTrafficRevision).OrderByDescending(Function(Entity) Entity.RevisionNumber).FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficRevision)

            Load = From MediaTrafficRevision In DbContext.GetQuery(Of Database.Entities.MediaTrafficRevision)
                   Select MediaTrafficRevision

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficRevisions.Add(MediaTrafficRevision)

                ErrorText = MediaTrafficRevision.ValidateEntity(IsValid)

                If IsValid Then

                    Try

                        MediaTrafficRevision.RevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficRevision.Load(DbContext)
                                                               Where Entity.MediaTrafficID = MediaTrafficRevision.MediaTrafficID
                                                               Select Entity.RevisionNumber).Max + 1

                    Catch ex As Exception
                        MediaTrafficRevision.RevisionNumber = 0
                    End Try

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
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficRevisionID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficCreativeGroupIDs As IEnumerable(Of Integer) = Nothing
            Dim DocumentList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentCount As Integer = 0

            Try

                MediaTrafficVendorIDs = AdvantageFramework.Database.Procedures.MediaTrafficVendor.LoadByMediaTrafficRevisionIDs(DbContext, {MediaTrafficRevisionID}).Select(Function(MTV) MTV.ID).ToArray

                If AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorIDs(DbContext, MediaTrafficVendorIDs).Where(Function(MTVS) MTVS.MediaTrafficStatusID = Entities.Methods.MediaTrafficStatusID.Generated).Any Then

                    IsValid = False

                    ErrorText = "Cannot delete instruction as it has already been generated."

                End If

                If IsValid Then

                    MediaTrafficCreativeGroupIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficRevisionID)
                                                    Select Entity.ID).ToArray

                    If MediaTrafficCreativeGroupIDs.Count > 0 Then

                        DocumentList = New System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document)

                        For Each MediaTrafficCreativeGroupID In MediaTrafficCreativeGroupIDs

                            DocumentList.AddRange((From Entity In AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Load(DbContext)
                                                   Where Entity.MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroupID
                                                   Select Entity.Document).ToList)

                        Next

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_CREATIVE_GROUP_ID IN ({0})", String.Join(",", MediaTrafficCreativeGroupIDs)))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE MTDD FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT MTDD " &
                                                                           "INNER JOIN dbo.MEDIA_TRAFFIC_DETAIL MTD ON MTDD.MEDIA_TRAFFIC_DETAIL_ID = MTD.MEDIA_TRAFFIC_DETAIL_ID WHERE MTD.MEDIA_TRAFFIC_CREATIVE_GROUP_ID IN ({0})", String.Join(",", MediaTrafficCreativeGroupIDs)))

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_DETAIL WHERE MEDIA_TRAFFIC_CREATIVE_GROUP_ID IN ({0})", String.Join(",", MediaTrafficCreativeGroupIDs)))

                        For Each Doc In DocumentList

                            DocumentCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT count(1) FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT WHERE DOCUMENT_ID = {0}", Doc.ID)).First

                            If DocumentCount = 0 Then

                                DbContext.TryAttach(Doc)

                                AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Doc)

                            End If

                        Next

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_REVISION_ID = {0}", MediaTrafficRevisionID))

                    If MediaTrafficVendorIDs IsNot Nothing AndAlso MediaTrafficVendorIDs.Count > 0 Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_STATUS WHERE MEDIA_TRAFFIC_VENDOR_ID IN ({0})", String.Join(",", MediaTrafficVendorIDs.ToArray)))

                    End If

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR WHERE MEDIA_TRAFFIC_REVISION_ID = {0}", MediaTrafficRevisionID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_REVISION WHERE MEDIA_TRAFFIC_REVISION_ID = {0}", MediaTrafficRevisionID))

                    DbContext.SaveChanges()

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
