Namespace Database.Procedures.SoftwareVersion

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

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SoftwareVersion)

            LoadAllActive = From SoftwareVersion In DbContext.GetQuery(Of Database.Entities.SoftwareVersion)
                            Where SoftwareVersion.IsActive Is Nothing Or SoftwareVersion.IsActive = 1
                            Select SoftwareVersion

        End Function
        Public Function LoadByJobAndComponent(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal JobNumber As Integer,
                                              ByVal JobComponentNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SoftwareVersion)

            LoadByJobAndComponent = (From Entity In DbContext.GetQuery(Of Database.Entities.SoftwareVersion)
                                     Join SoftwareLevel In DbContext.GetQuery(Of Database.Entities.SoftwareLevel) On SoftwareLevel.VersionID Equals Entity.ID
                                     Where SoftwareLevel.JobNumber = JobNumber And (SoftwareLevel.JobComponentNumber Is Nothing OrElse SoftwareLevel.JobComponentNumber = JobComponentNumber)
                                     Select Entity).Distinct

        End Function


#End Region

    End Module

End Namespace