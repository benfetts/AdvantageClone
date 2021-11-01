Namespace Database.Procedures.GeneralDescription

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

        Public Function LoadStateTaxLabel(ByVal DbContext As Database.DbContext) As String

            Try

                LoadStateTaxLabel = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralDescription).FirstOrDefault(Function(Entity) Entity.FieldName = "STATE_TAX").FieldDescription

            Catch ex As Exception
                LoadStateTaxLabel = ""
            End Try

        End Function
        Public Function LoadCountyTaxLabel(ByVal DbContext As Database.DbContext) As String

            Try

                LoadCountyTaxLabel = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralDescription).FirstOrDefault(Function(Entity) Entity.FieldName = "COUNTY_TAX").FieldDescription

            Catch ex As Exception
                LoadCountyTaxLabel = ""
            End Try

        End Function
        Public Function LoadCityTaxLabel(ByVal DbContext As Database.DbContext) As String

            Try

                LoadCityTaxLabel = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.GeneralDescription).FirstOrDefault(Function(Entity) Entity.FieldName = "CITY_TAX").FieldDescription

            Catch ex As Exception
                LoadCityTaxLabel = ""
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.GeneralDescription)

            Load = From GeneralDescription In DbContext.GetQuery(Of Database.Entities.GeneralDescription)
                   Select GeneralDescription

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralDescription As AdvantageFramework.Database.Entities.GeneralDescription) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(GeneralDescription)

                ErrorText = GeneralDescription.ValidateEntity(IsValid)

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
