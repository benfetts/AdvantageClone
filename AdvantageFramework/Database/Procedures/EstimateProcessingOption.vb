Namespace Database.Procedures.EstimateProcessingOption

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

        Public Function LoadPurchaseOrderOption(ByVal DbContext As Database.DbContext) As Database.Entities.EstimateProcessingOption

            Try

                LoadPurchaseOrderOption = (From EstimateProcessingOption In DbContext.GetQuery(Of Database.Entities.EstimateProcessingOption)
                                           Where EstimateProcessingOption.Description = "Purchase Orders"
                                           Select EstimateProcessingOption).SingleOrDefault

            Catch ex As Exception
                LoadPurchaseOrderOption = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EstimateProcessingOption)

            Load = From EstimateProcessingOption In DbContext.GetQuery(Of Database.Entities.EstimateProcessingOption)
                   Select EstimateProcessingOption

        End Function
        Public Function LoadByOptionID(ByVal DbContext As Database.DbContext, ByVal OptionID As Int16) As Database.Entities.EstimateProcessingOption

            Try

                LoadByOptionID = (From EstimateProcessingOption In DbContext.GetQuery(Of Database.Entities.EstimateProcessingOption)
                                  Where EstimateProcessingOption.OptionID = OptionID
                                  Select EstimateProcessingOption).FirstOrDefault

            Catch ex As Exception
                LoadByOptionID = Nothing
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateProcessingOption As AdvantageFramework.Database.Entities.EstimateProcessingOption) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EstimateProcessingOption)

                ErrorText = EstimateProcessingOption.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
