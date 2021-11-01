Namespace Database.Procedures.MediaTrafficVendorCreativeGroup

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

        Public Function LoadByMediaTrafficCreativeGroupID(DbContext As Database.DbContext, MediaTrafficCreativeGroupID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)

            LoadByMediaTrafficCreativeGroupID = From MediaTrafficVendorCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)
                                                Where MediaTrafficVendorCreativeGroup.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroupID
                                                Select MediaTrafficVendorCreativeGroup

        End Function
        Public Function LoadByMediaTrafficMediaTrafficVendorID(DbContext As Database.DbContext, MediaTrafficVendorID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)

            LoadByMediaTrafficMediaTrafficVendorID = From MediaTrafficVendorCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)
                                                     Where MediaTrafficVendorCreativeGroup.MediaTrafficVendorID = MediaTrafficVendorID
                                                     Select MediaTrafficVendorCreativeGroup

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)

            Load = From MediaTrafficVendorCreativeGroup In DbContext.GetQuery(Of Database.Entities.MediaTrafficVendorCreativeGroup)
                   Select MediaTrafficVendorCreativeGroup

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.MediaTrafficVendorCreativeGroups.Add(MediaTrafficVendorCreativeGroup)

                ErrorText = MediaTrafficVendorCreativeGroup.ValidateEntity(IsValid)

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
        Public Function DeleteByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer, ByRef ErrorText As String) As Boolean

            'objects
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup = Nothing
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                MediaTrafficVendorCreativeGroup = DbContext.MediaTrafficVendorCreativeGroups.Find(ID)

                If MediaTrafficVendorCreativeGroup IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorIDs(DbContext, {MediaTrafficVendorCreativeGroup.MediaTrafficVendorID}).Where(Function(MTVS) MTVS.MediaTrafficStatusID = Entities.Methods.MediaTrafficStatusID.Generated).Any Then

                        IsValid = False

                        ErrorText = "Cannot delete creative group as instruction has already been generated."

                    End If

                    If IsValid Then

                        DbContext.Entry(MediaTrafficVendorCreativeGroup).State = Entity.EntityState.Deleted
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
