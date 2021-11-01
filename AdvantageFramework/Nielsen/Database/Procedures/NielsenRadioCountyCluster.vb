Namespace Nielsen.Database.Procedures.NielsenRadioCountyCluster

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

        Public Function GetMaxIDByNielsenRadioCountyPeriodID(DbContext As Nielsen.Database.DbContext, NielsenRadioCountyPeriodID As Integer) As Long

            Try

                GetMaxIDByNielsenRadioCountyPeriodID = (From NielsenRadioCountyCluster In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyCluster)
                                                        Where NielsenRadioCountyCluster.NielsenRadioCountyPeriodID = NielsenRadioCountyPeriodID
                                                        Select NielsenRadioCountyCluster.ID).Max

            Catch ex As Exception
                GetMaxIDByNielsenRadioCountyPeriodID = 0
            End Try

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioCountyCluster)

            Load = From NielsenRadioCountyCluster In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioCountyCluster)
                   Select NielsenRadioCountyCluster

        End Function
        Public Function Insert(DbContext As Nielsen.Database.DbContext, NielsenRadioCountyCluster As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioCountyCluster, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.NielsenRadioCountyClusters.Add(NielsenRadioCountyCluster)

                ErrorText = NielsenRadioCountyCluster.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                While ex.InnerException IsNot Nothing

                    ex = ex.InnerException

                End While

                ErrorText = ex.Message

            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
