Namespace Database.Procedures.PartnerAllocation

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

        Public Function LoadByOrderNumber(ByVal DbContext As Database.DbContext, ByVal OrderNumber As Integer) As Database.Entities.PartnerAllocation

            Try

                LoadByOrderNumber = (From PartnerAllocation In DbContext.GetQuery(Of Database.Entities.PartnerAllocation)
                                     Where PartnerAllocation.OrderNumber = OrderNumber
                                     Select PartnerAllocation).SingleOrDefault

            Catch ex As Exception
                LoadByOrderNumber = Nothing
            End Try

        End Function
        Public Function LoadByCampaignID(ByVal DbContext As Database.DbContext, ByVal CampaignID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PartnerAllocation)

            LoadByCampaignID = From PartnerAllocation In DbContext.GetQuery(Of Database.Entities.PartnerAllocation)
                               Where PartnerAllocation.CampaignID = CampaignID
                               Select PartnerAllocation

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.PartnerAllocation)

            Load = From PartnerAllocation In DbContext.GetQuery(Of Database.Entities.PartnerAllocation)
                   Select PartnerAllocation

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.PartnerAllocations.Add(PartnerAllocation)

                ErrorText = PartnerAllocation.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(PartnerAllocation)

                ErrorText = PartnerAllocation.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal PartnerAllocation As AdvantageFramework.Database.Entities.PartnerAllocation) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each Detail In AdvantageFramework.Database.Procedures.PartnerAllocationDetail.LoadByOrderNumber(DbContext, PartnerAllocation.OrderNumber).ToList

                        DbContext.DeleteEntityObject(Detail)

                    Next

                    DbContext.DeleteEntityObject(PartnerAllocation)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CampaignID As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In LoadByCampaignID(DbContext, CampaignID).ToList

                        For Each Detail In AdvantageFramework.Database.Procedures.PartnerAllocationDetail.LoadByOrderNumber(DbContext, EntityClass.OrderNumber).ToList

                            DbContext.DeleteEntityObject(Detail)

                        Next

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

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
