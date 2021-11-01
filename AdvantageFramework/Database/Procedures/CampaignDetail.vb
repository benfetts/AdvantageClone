Namespace Database.Procedures.CampaignDetail

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

        Public Function LoadByCampaignID(ByVal DbContext As Database.DbContext, ByVal CampaignID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CampaignDetail)

            LoadByCampaignID = From CampaignDetail In DbContext.GetQuery(Of Database.Entities.CampaignDetail)
                               Where CampaignDetail.CampaignID = CampaignID
                               Select CampaignDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CampaignDetail)

            Load = From CampaignDetail In DbContext.GetQuery(Of Database.Entities.CampaignDetail)
                   Select CampaignDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext, ByVal CampaignID As Integer, ByVal ID As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.CampaignDetail)

            Load = From CampaignDetail In DbContext.GetQuery(Of Database.Entities.CampaignDetail)
                   Where CampaignDetail.CampaignID = CampaignID And CampaignDetail.ID = ID
                   Select CampaignDetail
        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.CampaignDetails.Add(CampaignDetail)

                ErrorText = CampaignDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.CampaignDetail.LoadByCampaignID(DbContext, CampaignDetail.CampaignID).Count = 0 Then

                        CampaignDetail.ID = 1

                    Else

                        CampaignDetail.ID = (From Entity In AdvantageFramework.Database.Procedures.CampaignDetail.LoadByCampaignID(DbContext, CampaignDetail.CampaignID)
                                             Select Entity.ID).Max + 1

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(CampaignDetail)

                ErrorText = CampaignDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(CampaignDetail)

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
        Public Function DeleteByCampaignID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignID As Integer) As Boolean
            
            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CAMPAIGN_DETAIL WHERE CMP_IDENTIFIER = {0}", CampaignID))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByCampaignID = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
