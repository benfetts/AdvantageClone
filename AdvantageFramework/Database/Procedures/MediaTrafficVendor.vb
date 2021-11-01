Namespace Database.Procedures.MediaTrafficVendor

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const _GENERATED As String = "Cannot delete vendor as instruction has already been generated."

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ID As Integer) As Database.Entities.MediaTrafficVendor

            LoadByID = (From MediaTrafficVendor In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendor)
                        Where MediaTrafficVendor.ID = ID
                        Select MediaTrafficVendor).SingleOrDefault

        End Function
        Public Function LoadByMediaTrafficRevisionIDs(ByVal DbContext As Database.DbContext, RevisionIDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendor)

            LoadByMediaTrafficRevisionIDs = From MediaTrafficVendor In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendor)
                                            Where RevisionIDs.Contains(MediaTrafficVendor.MediaTrafficRevisionID) = True
                                            Select MediaTrafficVendor

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendor)

            Load = From MediaTrafficVendor In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendor)
                   Select MediaTrafficVendor

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficVendors.Add(MediaTrafficVendor)

                ErrorText = MediaTrafficVendor.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaTrafficVendor)

                ErrorText = MediaTrafficVendor.ValidateEntity(IsValid)

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
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficVendorID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                If AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID).Where(Function(MTVS) MTVS.MediaTrafficStatusID = Entities.Methods.MediaTrafficStatusID.Generated).Any Then

                    IsValid = False

                    ErrorText = _GENERATED

                End If

                If IsValid Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_STATUS WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC_VENDOR WHERE MEDIA_TRAFFIC_VENDOR_ID = {0}", MediaTrafficVendorID))

                    Deleted = True

                End If

            Catch ex As Exception
                Deleted = False
                ErrorText = ex.Message
            Finally
                DeleteByID = Deleted
            End Try

        End Function
        Public Function HasInstructionBeenGenerated(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficVendorID As Integer, ByRef Message As String) As Boolean

            Message = _GENERATED

            HasInstructionBeenGenerated = AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, MediaTrafficVendorID).Where(Function(MTVS) MTVS.MediaTrafficStatusID = Entities.Methods.MediaTrafficStatusID.Generated).Any

        End Function

#End Region

    End Module

End Namespace
