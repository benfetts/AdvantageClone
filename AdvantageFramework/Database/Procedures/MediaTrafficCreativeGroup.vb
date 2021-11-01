Namespace Database.Procedures.MediaTrafficCreativeGroup

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaTrafficCreativeGroup

            LoadByID = (From MediaTrafficCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficCreativeGroup)
                        Where MediaTrafficCreativeGroup.ID = ID
                        Select MediaTrafficCreativeGroup).SingleOrDefault

        End Function
        Public Function LoadByMediaTrafficRevisionID(DbContext As Database.DbContext, MediaTrafficRevisionID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficCreativeGroup)

            LoadByMediaTrafficRevisionID = From MediaTrafficCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficCreativeGroup)
                                           Where MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficRevisionID
                                           Select MediaTrafficCreativeGroup

        End Function        '
        Public Function LoadByMediaTrafficRevisionIDs(DbContext As Database.DbContext, MediaTrafficRevisionIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficCreativeGroup)

            LoadByMediaTrafficRevisionIDs = From MediaTrafficCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficCreativeGroup)
                                            Where MediaTrafficRevisionIDs.Contains(MediaTrafficCreativeGroup.MediaTrafficRevisionID)
                                            Select MediaTrafficCreativeGroup

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficCreativeGroup)

            Load = From MediaTrafficCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficCreativeGroup)
                   Select MediaTrafficCreativeGroup

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficCreativeGroups.Add(MediaTrafficCreativeGroup)

                ErrorText = MediaTrafficCreativeGroup.ValidateEntity(IsValid)

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
        Public Function HasAnyVendorGeneratedInstructionForCreativeGroupID(DbContext As AdvantageFramework.Database.DbContext, MediaTrafficCreativeGroupID As Integer) As Boolean

            'objects
            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing
            Dim HasBeenGenerated As Boolean = False

            MediaTrafficCreativeGroup = DbContext.MediaTrafficCreativeGroups.Find(MediaTrafficCreativeGroupID)

            If MediaTrafficCreativeGroup IsNot Nothing Then

                MediaTrafficVendorIDs = AdvantageFramework.Database.Procedures.MediaTrafficVendor.LoadByMediaTrafficRevisionIDs(DbContext, {MediaTrafficCreativeGroup.MediaTrafficRevisionID}).Select(Function(MTV) MTV.ID).ToArray

                If AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorIDs(DbContext, MediaTrafficVendorIDs).Where(Function(MTVS) MTVS.MediaTrafficStatusID = Entities.Methods.MediaTrafficStatusID.Generated).Any Then

                    HasBeenGenerated = True

                End If

            End If

            HasAnyVendorGeneratedInstructionForCreativeGroupID = HasBeenGenerated

        End Function
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficCreativeGroupID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim DocumentList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentCount As Integer = 0

            Try

                If HasAnyVendorGeneratedInstructionForCreativeGroupID(DbContext, MediaTrafficCreativeGroupID) Then

                    IsValid = False

                    ErrorText = "Cannot delete creative group as instruction has already been generated."

                End If

                If IsValid Then

                    DocumentList = New System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Document)

                    DocumentList.AddRange((From Entity In AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Load(DbContext)
                                           Where Entity.MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroupID
                                           Select Entity.Document).ToList)

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE MTDD FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT MTDD " &
                                                                           "INNER JOIN dbo.MEDIA_TRAFFIC_DETAIL MTD ON MTDD.MEDIA_TRAFFIC_DETAIL_ID = MTD.MEDIA_TRAFFIC_DETAIL_ID WHERE MTD.MEDIA_TRAFFIC_CREATIVE_GROUP_ID = {0}", MediaTrafficCreativeGroupID))

                    For Each Doc In DocumentList

                        DocumentCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT count(1) FROM dbo.MEDIA_TRAFFIC_DETAIL_DOCUMENT WHERE DOCUMENT_ID = {0}", Doc.ID)).First

                        If DocumentCount = 0 Then

                            DbContext.TryAttach(Doc)

                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Doc)

                        End If

                    Next

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_DETAIL WHERE MEDIA_TRAFFIC_CREATIVE_GROUP_ID = {0}", MediaTrafficCreativeGroupID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_CREATIVE_GROUP_ID = {0}", MediaTrafficCreativeGroupID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_CREATIVE_GROUP_ID = {0}", MediaTrafficCreativeGroupID))

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
